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
    public class GetCheckinData
    {
        String _checkin_id = string.Empty;
        String _UserID = string.Empty;
        String _user_name = string.Empty;
        String _user_address = string.Empty;
        String _company_from = string.Empty;
        String _telephone = string.Empty;
        String _remarks = string.Empty;
        String _Vehicle_No = string.Empty;
        String _Key_no = string.Empty;
        String _ImagePath = string.Empty;
        String _Pass_No = string.Empty;
        String _pass_type = string.Empty;
        String _to_visit = string.Empty;
        String _purpose = string.Empty;
        String _Item_Declear = string.Empty;
        DateTime? _Checkin_DateTime = DateTime.Now;
        String _whereClause = string.Empty;
        String _Role = string.Empty;
        String _Department = string.Empty;
        String _NRICno = string.Empty;
        String _LocationID = string.Empty;



        public String LocationID
        {
            get
            {
                return _LocationID;
            }
            set
            {
                _LocationID = value;
            }
        }
        public String NRICno
        {
            get
            {
                return _NRICno;
            }
            set
            {
                _NRICno = value;
            }
        }
        public String Role
        {
            get
            {
                return _Role;
            }
            set
            {
                _Role = value;
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
        public String checkin_id
        {
            get
            {
                return _checkin_id;
            }
            set
            {
                _checkin_id = value;
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
        public String user_address
        {
            get
            {
                return _user_address;
            }
            set
            {
                _user_address = value;
            }
        }
        public String company_from
        {
            get
            {
                return _company_from;
            }
            set
            {
                _company_from = value;
            }
        }
        public String telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone = value;
            }
        }
        public String remarks
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }
        public String Vehicle_No
        {
            get
            {
                return _Vehicle_No;
            }
            set
            {
                _Vehicle_No = value;
            }
        }
        public String Key_no
        {
            get
            {
                return _Key_no;
            }
            set
            {
                _Key_no = value;
            }
        }
        public String ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
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
        public String pass_type
        {
            get
            {
                return _pass_type;
            }
            set
            {
                _pass_type = value;
            }
        }
        public String to_visit
        {
            get
            {
                return _to_visit;
            }
            set
            {
                _to_visit = value;
            }
        }
        public String purpose
        {
            get
            {
                return _purpose;
            }
            set
            {
                _purpose = value;
            }
        }
        public String Item_Declear
        {
            get
            {
                return _Item_Declear;
            }
            set
            {
                _Item_Declear = value;
            }
        }
        public DateTime? Checkin_DateTime
        {
            get
            {
                return _Checkin_DateTime;
            }
            set
            {
                _Checkin_DateTime = value;
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




    }
}
