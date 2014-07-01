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
    public class GetSOPData
    {

        String _SOP_ID = string.Empty;
        String _SOP_Title = string.Empty;
        String _ImagePathName = string.Empty;
        String _SOP_Subject = string.Empty;
        String _whereClause = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;

        string _Location = string.Empty;

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


        public String SOP_ID
        {
            get
            {
                return _SOP_ID;
            }
            set
            {
                _SOP_ID = value;
            }
        }
        public String SOP_Title
        {
            get
            {
                return _SOP_Title;
            }
            set
            {
                _SOP_Title = value;
            }
        }
        public String ImagePathName
        {
            get
            {
                return _ImagePathName;
            }
            set
            {
                _ImagePathName = value;
            }
        }
        public String SOP_Subject
        {
            get
            {
                return _SOP_Subject;
            }
            set
            {
                _SOP_Subject = value;
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

        public String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }

    }
}
