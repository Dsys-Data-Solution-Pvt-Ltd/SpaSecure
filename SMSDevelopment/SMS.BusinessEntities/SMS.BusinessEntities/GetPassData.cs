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
    public class GetPassData
    {
        String _pass_Type = string.Empty;
        String _Pass_No = string.Empty;
        String _Pass_Desciption = string.Empty;
        String _whereClause = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
        String _Status = string.Empty;

        public String WhereClause
        {
            get
            {
                return _whereClause;
            }
            set
            {
                _whereClause = value;
            }
        }

        public String pass_Type
        {
            get
            {
                return _pass_Type;
            }
            set
            {
                _pass_Type = value;
            }
        }
        public String Pass_No
        {
            get
            {
                return _Pass_No;
            }
            set
            {
                _Pass_No = value;
            }
        }
        public String Pass_Desciption
        {
            get
            {
                return _Pass_Desciption;
            }
            set
            {
                _Pass_Desciption = value;
            }
        }

        public String Date_From
        {
            get
            {
                return _Date_From;
            }
            set
            {
                _Date_From = value;
            }
        }

        public String Date_to
        {
            get
            {
                return _Date_to;
            }
            set
            {
                _Date_to = value;
            }
        }

        public String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }



    }
}
