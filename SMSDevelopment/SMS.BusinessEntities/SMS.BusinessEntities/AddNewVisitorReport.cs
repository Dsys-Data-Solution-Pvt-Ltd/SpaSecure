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
using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class AddNewVisitorReport
    {
        private Visitor _visitor_Request = null;

        public Visitor visitor_Request
        {
            get { return _visitor_Request; }
            set { _visitor_Request = value; }
        }
    }
}
