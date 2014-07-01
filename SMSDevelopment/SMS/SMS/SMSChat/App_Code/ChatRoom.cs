using System;
using System.Collections ;
using System.Collections.Generic;
using SMS.Web.SMSChat;
namespace ASPNETChat
{
	public class ChatRoom : IDisposable
	{
		#region Members
		
		public List<Message> messages = null;
		public string RoomID;
		private Dictionary<string,ChatUser> RoomUsers;
        private int userChatRoomSessionTimeout;
		
		#endregion

		#region IDisposable Members
		public void Dispose()
		{
			this.messages.Clear();
			this.RoomID="";
			foreach(object key in RoomUsers.Keys)
			{
				this.RoomUsers[key.ToString()].Dispose ();
			}
				
			
		}

		#endregion
		
		#region Constructors
		public ChatRoom(string roomID) 
		{
            this.messages = new List<Message>();
			this.RoomID=roomID;
            userChatRoomSessionTimeout = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["UserChatRoomSessionTimeout"]);
            RoomUsers = new Dictionary<string,ChatUser>(Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ChatRoomMaxUsers"]));
		}
		#endregion

		#region Methods
		/// <summary>
		/// Returns the user with the specified id
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public ChatUser GetUser(string userID)
		{
            if (!this.RoomUsers.ContainsKey(userID))
                return null;
			return this.RoomUsers[userID];
		}


		/// <summary>
		/// Determines if the room is empty or not
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			lock(this)
			{
				foreach(object key in RoomUsers.Keys)
				{
					if (this.RoomUsers[key.ToString()].IsActive==true)
						return false;
				}
				return true;
			}
		}

 
		#region Operations Join,Send,Leave
		/// <summary>
		/// Marks the user as inactive
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public void LeaveRoom(string userID)
		{
			//deactivate user 
			ChatUser user=this.GetUser(userID);
            if (user == null)
                return ;
			user.IsActive=false;
			user.LastSeen=DateTime.Now;
            this.RoomUsers.Remove(userID);

			//Add leaving message
			Message msg = new Message(user.UserName ,"",MsgType.Left);
			this.AddMsg(msg);
			
            if (IsEmpty())
                ChatEngine.DeleteRoom(this.RoomID);
			
		}


		/// <summary>
		/// Activates the user and adds a join message to the room
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="userName"></param>
		/// <returns>All the messages sent in the room</returns>
		public string JoinRoom(string userID,string userName)
		{
				
			//activate user 
			ChatUser user=new ChatUser(userID,userName);
			user.IsActive=true;
			user.UserName=userName;
			user.LastSeen=DateTime.Now;
			if (!this.RoomUsers.ContainsKey(userID))
			{
				//Add join message
				Message msg=new Message(user.UserName ,"",MsgType.Join);
				this.AddMsg(msg);
				//Get all the messages to the user
				int lastMsgID;
                List<Message> previousMessages = this.GetMessagesSince(-1, out lastMsgID);
				user.LastMessageReceived=lastMsgID;
				//return the messages to the user
				string str=GenerateMessagesString(previousMessages);
				this.RoomUsers.Add(userID,user);
				return str;
			}
			return "";
		}


		/// <summary>
		/// Adds a message in the room
		/// </summary>
		/// <param name="strMsg"></param>
		/// <param name="senderID"></param>
		/// <returns>All the messages sent from the other user from the last time the user sent a message</returns>
		public string SendMessage(string strMsg,string senderID)
		{
			ChatUser user=this.GetUser(senderID);
			Message msg=new Message(user.UserName ,strMsg,MsgType.Msg);
			user.LastSeen=DateTime.Now;
			this.ExpireUsers(userChatRoomSessionTimeout);
			this.AddMsg(msg);
			int lastMsgID;
            List<Message> previousMsgs = this.GetMessagesSince(user.LastMessageReceived, out lastMsgID);
			if (lastMsgID!=-1)
				user.LastMessageReceived=lastMsgID;
			string res=this.GenerateMessagesString(previousMsgs);
			return res;
		}

		#endregion 

		/// <summary>
		/// Removes the users that hasn't sent any message during the last window secondes 
		/// </summary>
		/// <param name="window">time in secondes</param>
		public void ExpireUsers(int window) 
		{
			lock(this) 
			{
                foreach (object key in RoomUsers.Keys)
                {
                    ChatUser usr = this.RoomUsers[key.ToString()];
                    lock (usr)
                    {
                        if (usr.LastSeen != System.DateTime.MinValue)
                        {
                            TimeSpan span = DateTime.Now - usr.LastSeen;
                            if (span.TotalSeconds > window && usr.IsActive != false)
                            {
                                this.LeaveRoom(usr.UserID);
                            }
                        }
                    }
                }
			}
		}


		/// <summary>
		/// Adds a message to the room
		/// <param name="msg"></param>
		/// <returns> the id of the new message</returns>
		public int AddMsg(Message msg) 
		{
			int count;
			lock(messages) 
			{
				count = messages.Count;
				messages.Add(msg);
			}
			return count;
		}



		/// <summary>
		/// Iterates over the messages array calling ToString() for each message
		/// </summary>
		/// <param name="msgs"></param>
		/// <returns></returns>
        private string GenerateMessagesString(List<Message> msgs)
		{
			string res="";
			for (int i=0;i<msgs.Count;i++)
			{
				res+=((Message)msgs[i]).ToString()+"\n"; 
			}
			return res;
		}

		
		/// <summary>
		/// Returns an array that contains all messages sent after the message with id=msgid
		/// </summary>
		/// <param name="msgid">The id of the message after which all the message will be retuned </param>
		/// <param name="lastMsgID">the id of the last message returned</param>
		/// <returns></returns>
		public List<Message> GetMessagesSince(int msgid,out int lastMsgID) 
		{
			lock(messages) 
			{
				if ((messages.Count) <= (msgid+1))
					lastMsgID=-1;
				else
					lastMsgID=messages.Count-1;
				return messages.GetRange(msgid+1 , messages.Count - (msgid+1));
			}
		}


		/// <summary>
		/// Returns all the messages sent since the last message the user received
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public string UpdateUser(string userID)
		{
			ChatUser user=this.GetUser(userID);
			user.LastSeen=DateTime.Now;
			this.ExpireUsers(userChatRoomSessionTimeout);
			int lastMsgID;
			List<Message> previousMsgs= this.GetMessagesSince( user.LastMessageReceived,out lastMsgID);
			if (lastMsgID!=-1)
				user.LastMessageReceived=lastMsgID;
			string res=this.GenerateMessagesString(previousMsgs);
			return res;
		}



        /// <summary>
        /// Returns the names of the users who aer currently in the rooms
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetRoomUsersNames()
        {
            ExpireUsers(userChatRoomSessionTimeout);
            foreach (object key in RoomUsers.Keys)
            {
                yield return  this.RoomUsers[key.ToString()].UserName ;
            }

        }

		#endregion 

        


        

    }

}
