using System;

//namespace ASPNETChat
namespace SMS.Web.SMSChat
{
	public class ChatUser:IDisposable
	{
		#region Members
		public string UserID;
		public string UserName;
		public bool IsActive;
		public DateTime LastSeen;
		public int LastMessageReceived;
		#endregion 

		#region Constructors
		public ChatUser(string id,string userName)
		{
			this.UserID=id;
			this.IsActive=false;
			this.LastSeen=DateTime.MinValue ;
			this.UserName=userName;
			this.LastMessageReceived=0;
		}
		#endregion 

		#region IDisposable Members
		public void Dispose()
		{
			this.UserID="";
			this.IsActive=false;
			this.LastSeen=DateTime.MinValue ;
			this.UserName="";
			this.LastMessageReceived=0;
		}
		#endregion
	}

	
}
