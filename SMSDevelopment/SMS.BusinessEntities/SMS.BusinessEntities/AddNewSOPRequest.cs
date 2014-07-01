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
    public class AddNewSOPRequest
    {
        private SOP _sop_Request = null;

        public SOP sop_Request
        {
            get { return _sop_Request; }
            set { _sop_Request = value; }
        }
    }
}
