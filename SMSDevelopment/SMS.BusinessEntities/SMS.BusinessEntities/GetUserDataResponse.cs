using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;

using SMS.BusinessEntities.Main;


namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetUserDataResponse
    {
        private List<User_Info> _UserID = null;
        private List<User_Info> _Staff_ID = null;

        public List<User_Info> UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public List<User_Info> Staff_ID
        {
            get { return _Staff_ID; }
            set { _Staff_ID = value; }
        }
    }
}
