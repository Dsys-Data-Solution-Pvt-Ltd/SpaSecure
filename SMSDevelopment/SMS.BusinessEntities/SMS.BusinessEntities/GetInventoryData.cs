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
    public class GetInventoryData
    {
        String _Itemid = string.Empty;
        String _ItemName = string.Empty;
        String _Itemqty = string.Empty;
        String _CreatedBy = string.Empty;
        String _EditBy = string.Empty;
        String _EditTime = string.Empty;
        String _CreatedTime = string.Empty;
        String _whereClause = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;

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

        public String Itemid
        {
            get
            {
                return _Itemid;
            }
            set
            {
                _Itemid = value;
            }
        }

        public String ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }

        public String Itemqty
        {
            get
            {
                return _Itemqty;
            }
            set
            {
                _Itemqty = value;
            }
        }

        public String CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        public String EditBy
        {
            get
            {
                return _EditBy;
            }
            set
            {
                _EditBy = value;
            }
        }


        public String EditTime
        {
            get
            {
                return _EditTime;
            }
            set
            {
                _EditTime = value;
            }
        }

        public String CreatedTime
        {
            get
            {
                return _CreatedTime;
            }
            set
            {
                _CreatedTime = value;
            }
        }
        //Add By Ruchi
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
