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

namespace SMS.BusinessEntities
{
    public class GetElearnAssignToData
    {
        String _Tutorial_ID = string.Empty;
        String _Tutorial_Name = string.Empty;
        String _UserID = string.Empty;
        String _user_name = string.Empty;
        String _Department = string.Empty;
        String _AssignDate = string.Empty;
        String _AssignTime = string.Empty;

        public String Tutorial_ID
        {
            get
            {
                return _Tutorial_ID;
            }
            set
            {
                _Tutorial_ID = value;
            }
        }
        public String Tutorial_Name
        {
            get
            {
                return _Tutorial_Name;
            }
            set
            {
                _Tutorial_Name = value;
            }
        }
        public String UserID
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
        public String user_name
        {
            get
            {
                return _user_name;
            }
            set
            {
                _user_name = value;
            }
        }
        public String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
            }
        }
        public String AssignDate
        {
            get
            {
                return _AssignDate;
            }
            set
            {
                _AssignDate = value;
            }
        }
        public String AssignTime
        {
            get
            {
                return _AssignTime;
            }
            set
            {
                _AssignTime = value;
            }
        }
        
    }
}
