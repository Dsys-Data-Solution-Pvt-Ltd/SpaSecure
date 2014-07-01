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
    public class GetNewKey
    {
        String _key_no = string.Empty;
        String _Description = string.Empty;
        String _status = string.Empty;
        String _name = string.Empty;
        String _position = string.Empty;
        String _count = string.Empty;
        String _nricno = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
        String _whereClause = string.Empty;
        String _Location_Id = string.Empty;

        public String Location_Id
        {
            get
            {
                return _Location_Id;
            }
            set
            {
                _Location_Id = value;
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

        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public String status
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
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public String position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
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

        public String nricno
        {
            get
            {
                return _nricno;
            }
            set
            {
                _nricno = value;
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
