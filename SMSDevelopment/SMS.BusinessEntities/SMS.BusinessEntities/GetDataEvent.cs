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
    public class GetDataEvent
    {
        String _Event_ID = string.Empty;
        String _Date_From = string.Empty;
        String _Date_To = string.Empty;
        String _Location_id = string.Empty;
        String _Event_Type = string.Empty;
        String _Start_time = string.Empty;
        String _End_time = string.Empty;
       
        String _Special_Requirment = string.Empty;
        Int32 _Guard_Requirment = Int32.MinValue;
        String _Special_Duty = string.Empty;
        String _Incharg_Name = string.Empty;
        String _Incharg_NricNo = string.Empty;
        String _Incharg_position = string.Empty;
        String _Incharg_ContactNo = string.Empty;
        String _Superior_Name = string.Empty;
        String _whereClause = string.Empty;

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

        public String Event_ID
        {
            get
            {
                return _Event_ID;
            }
            set
            {
                _Event_ID = value;
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
        public String Date_To
        {
            get
            {
                return _Date_To;
            }
            set
            {
                _Date_To = value;
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
        public String Event_Type
        {
            get
            {
                return _Event_Type;
            }
            set
            {
                _Event_Type = value;
            }
        }
        public String Start_time
        {
            get
            {
                return _Start_time;
            }
            set
            {
                _Start_time = value;
            }
        }
        public String End_time
        {
            get
            {
                return _End_time;
            }
            set
            {
                _End_time = value;
            }
        }
      
        public String Special_Requirment
        {
            get
            {
                return _Special_Requirment;
            }
            set
            {
                _Special_Requirment = value;
            }
        }
        public Int32 Guard_Requirment
        {
            get
            {
                return _Guard_Requirment;
            }
            set
            {
                _Guard_Requirment = value;
            }
        }
        public String Special_Duty
        {
            get
            {
                return _Special_Duty;
            }
            set
            {
                _Special_Duty = value;
            }
        }
        public String Incharg_Name
        {
            get
            {
                return _Incharg_Name;
            }
            set
            {
                _Incharg_Name = value;
            }
        }
        public String Incharg_NricNo
        {
            get
            {
                return _Incharg_NricNo;
            }
            set
            {
                _Incharg_NricNo = value;
            }
        }
        public String Incharg_position
        {
            get
            {
                return _Incharg_position;
            }
            set
            {
                _Incharg_position = value;
            }
        }
        public String Incharg_ContactNo
        {
            get
            {
                return _Incharg_ContactNo;
            }
            set
            {
                _Incharg_ContactNo = value;
            }
        }
        public String Superior_Name
        {
            get
            {
                return _Superior_Name;
            }
            set
            {
                _Superior_Name = value;
            }
        }

    }
}
