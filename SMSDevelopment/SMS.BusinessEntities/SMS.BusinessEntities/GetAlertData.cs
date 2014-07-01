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
    [Serializable]
    public class GetAlertData
    {
        String _Location_id = string.Empty;
        String _Alert_ID = string.Empty;
        String _P_Name = string.Empty;
        String _P_NRIC_no = string.Empty;
        String _P_Passport = string.Empty;
        String _P_Nationality = string.Empty;

        String _V_Type = string.Empty;
        String _V_Color = string.Empty;
        String _V_ResgistNo = string.Empty;
        String _V_OwnerName = string.Empty;
        String _V_OwnerNricNo = string.Empty;

        String _Alert_Type = string.Empty;
        String _Comment = string.Empty;
        String _AlertBy_NRICNo = string.Empty;
        String _AlertBy_Name = string.Empty;
        String _AlertDepartment = string.Empty;
        String _AlertDesignation = string.Empty;
        String _AlertContNo = string.Empty;      
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;

        String _whereClause = string.Empty;
        String _status = string.Empty;

        public String Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

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
        public String Location_id
        {
            get
            {
                return _Location_id;
            }
            set
            {
                _Location_id = value;
            }
        }

        public String Alert_ID
        {
            get
            {
                return _Alert_ID;
            }
            set
            {
                _Alert_ID = value;
            }
        }
        public String P_NRIC_no
        {
            get
            {
                return _P_NRIC_no;
            }
            set
            {
                _P_NRIC_no = value;
            }
        }
        public String P_Name
        {
            get
            {
                return _P_Name;
            }
            set
            {
                _P_Name = value;
            }
        }
        public String P_Passport
        {
            get
            {
                return _P_Passport;
            }
            set
            {
                _P_Passport = value;
            }
        }
        public String P_Nationality
        {
            get
            {
                return _P_Nationality;
            }
            set
            {
                _P_Nationality = value;
            }
        }

        public String V_Type
        {
            get
            {
                return _V_Type;
            }
            set
            {
                _V_Type = value;
            }
        }
        public String V_Color
        {
            get
            {
                return _V_Color;
            }
            set
            {
                _V_Color = value;
            }
        }
        public String V_ResgistNo
        {
            get
            {
                return _V_ResgistNo;
            }
            set
            {
                _V_ResgistNo = value;
            }
        }
        public String V_OwnerName
        {
            get
            {
                return _V_OwnerName;
            }
            set
            {
                _V_OwnerName = value;
            }
        }
        public String V_OwnerNricNo
        {
            get
            {
                return _V_OwnerNricNo;
            }
            set
            {
                _V_OwnerNricNo = value;
            }
        }

        public String Alert_Type
        {
            get
            {
                return _Alert_Type;
            }
            set
            {
                _Alert_Type = value;
            }
        }
        public String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
            }
        }
        public String AlertBy_NRICNo
        {
            get
            {
                return _AlertBy_NRICNo;
            }
            set
            {
                _AlertBy_NRICNo = value;
            }
        }
        public String AlertBy_Name
        {
            get
            {
                return _AlertBy_Name;
            }
            set
            {
                _AlertBy_Name = value;
            }
        }
        public String AlertDepartment
        {
            get
            {
                return _AlertDepartment;
            }
            set
            {
                _AlertDepartment = value;
            }
        }
        public String AlertDesignation
        {
            get
            {
                return _AlertDesignation;
            }
            set
            {
                _AlertDesignation = value;
            }
        }
        public String AlertContNo
        {
            get
            {
                return _AlertContNo;
            }
            set
            {
                _AlertContNo = value;
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





    }
}
