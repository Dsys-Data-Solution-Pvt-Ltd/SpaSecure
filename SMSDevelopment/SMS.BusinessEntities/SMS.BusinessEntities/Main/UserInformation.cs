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
using SMS.BusinessEntities;



namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class UserInformation
    {
        string _UserID = string.Empty;
        string _UserPassword = string.Empty;
        string _StaffID = string.Empty;
        public string UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
            }
        }

        public string StaffID
        {
            get
            {
                return _StaffID;
            }
            set
            {
                _StaffID = value;
            }
        }
    }
}
