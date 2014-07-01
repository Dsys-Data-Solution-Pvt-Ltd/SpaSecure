using System;
using System.Threading ;
using System.Web;
using System.Collections;
using System.Collections.Generic ;

using System.Text;
using System.Configuration;

namespace ASPNETChat

{

	/// <summary>
	/// The business logic of the chat application
	/// </summary>
	public static class ChatEngine
	{
        #region Members
        private static Dictionary<string, ChatRoom> Rooms = new Dictionary<string, ChatRoom>(Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxChatRooms"]));
        private static int userChatRoomSessionTimeout = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["UserChatRoomSessionTimeout"]);
        #endregion 
		
		
        #region Methods
		/// <summary>
		/// Cleans all the chat roomsDeletes the empty chat rooms
		/// </summary>
		/// <param name="state"></param>
		public static void CleanChatRooms(object state)
        {
            lock (Rooms) 
            {
                foreach (object key in Rooms.Keys)
                {
                    ChatRoom room = Rooms[key.ToString()];
                    room.ExpireUsers(userChatRoomSessionTimeout);
                    if (room.IsEmpty())
                    {
                        room.Dispose();
                        Rooms.Remove(key.ToString());
                    }
                }
            }
        }

		/// <summary>
		/// Returns the chat room for this two users or create a new one if nothing exists
		/// </summary>
		/// <param name="user1ID"></param>
		/// <param name="user2ID"></param>
		/// <returns></returns>
		public static ChatRoom GetRoom(string roomID)
		{
			ChatRoom room=null;
            lock (Rooms)
            {
                if (Rooms.ContainsKey (roomID))
                    room = Rooms[roomID];
                else
                {
                    room = new ChatRoom(roomID);
                    Rooms.Add(roomID, room);
                }
            }
			return room;
		}

		/// <summary>
		/// Deletes the specified room
		/// </summary>
		/// <param name="roomID"></param>
		public static void DeleteRoom(string roomID)
		{
            if (!Rooms.ContainsKey(roomID))
                return;
            lock (Rooms)
            {
                ChatRoom room = Rooms[roomID];
                room.Dispose();
                Rooms.Remove(roomID);
            }
		}

		
		#endregion
	}


	

	

}

