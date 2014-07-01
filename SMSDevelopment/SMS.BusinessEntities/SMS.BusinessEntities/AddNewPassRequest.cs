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
    public class AddNewPassRequest
    {
        private Pass _Pass_Request = null;

        public Pass Pass_Request
        {
            get { return _Pass_Request; }
            set { _Pass_Request = value; }
        }
    }
}
