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
    public class AddNewKeyRequest
    {
        private AdminAddNewKey _AddKey_Request = null;

        public AdminAddNewKey AddKey_Request
        {
            get { return _AddKey_Request; }
            set { _AddKey_Request = value; }
        }
    }
}
