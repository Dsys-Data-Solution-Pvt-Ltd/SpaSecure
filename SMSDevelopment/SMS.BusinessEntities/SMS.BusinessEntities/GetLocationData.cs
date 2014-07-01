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
    public class GetLocationData
    {
        String _locid = string.Empty;
        String _loc = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
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

        public String locid
        {
            get
            {
                return _locid;
            }
            set
            {
                _locid = value;
            }
        }
        public String loc
        {
            get
            {
                return _loc;
            }
            set
            {
                _loc = value;
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
