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
    public class GetContractorData
    {
        String _checkout_id = string.Empty;
        String _checkin_id = string.Empty;
        String _NRICno = string.Empty;
        String _user_id = string.Empty;
        String _user_name = string.Empty;
        String _user_address = string.Empty;
        String _company_from = string.Empty;
        String _telephone = string.Empty;
        String _remarks = string.Empty;
        String _vehicle_no = string.Empty;
        String _key_no = string.Empty;
        String _user_image = string.Empty;
        String _pass_no = string.Empty;
        String _PassType = string.Empty;
        String _to_visit = string.Empty;
        String _purpose = string.Empty;
        String _checkin_time = string.Empty;
        String _checkout_time = string.Empty;
        String _Role = string.Empty;
        String _Department = string.Empty;

        String _Location_id = string.Empty;
        String _whereClause = string.Empty;

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

        public String checkout_id
        {
            get
            {
                return _checkout_id;
            }
            set
            {
                _checkout_id = value;
            }
        }
        public String user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                _user_id = value;
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
        public String vehicle_no
        {
            get
            {
                return _vehicle_no;
            }
            set
            {
                _vehicle_no = value;
            }
        }
        public String key_no
        {
            get
            {
                return _key_no;
            }
            set
            {
                _key_no = value;
            }
        }
        public String user_image
        {
            get
            {
                return _user_image;
            }
            set
            {
                _user_image = value;
            }
        }
        public String pass_no
        {
            get
            {
                return _pass_no;
            }
            set
            {
                _pass_no = value;
            }
        }
        public String PassType
        {
            get
            {
                return _PassType;
            }
            set
            {
                _PassType = value;
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
        public String checkin_time
        {
            get
            {
                return _checkin_time;
            }
            set
            {
                _checkin_time = value;
            }
        }
        public String checkout_time
        {
            get
            {
                return _checkout_time;
            }
            set
            {
                _checkout_time = value;
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


        



    }
}
