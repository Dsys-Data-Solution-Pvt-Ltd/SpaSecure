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
    public class GetCheckInKey
    {
        String _Chkinkey_id = string.Empty;
        String _key_no = string.Empty;
        String _Designation = string.Empty;
        String _ContNo = string.Empty;
        String _Name = string.Empty;       
        String _count = string.Empty;
        String _Nricno = string.Empty;
        String _Fromdate = string.Empty;
       
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
        public String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }
        public String ContNo
        {
            get
            {
                return _ContNo;
            }
            set
            {
                _ContNo = value;
            }
        }
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }       
        public String count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public String Nricno
        {
            get
            {
                return _Nricno;
            }
            set
            {
                _Nricno = value;
            }
        }
        public String Fromdate
        {
            get
            {
                return _Fromdate;
            }
            set
            {
                _Fromdate = value;
            }
        }
       




    }
}
