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

using System.Collections.Generic;

using SMS.BusinessEntities.Main;


namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetAlertDataResponse
    {
        private List<AlertHandlingUser> _Alert_ID = null;

        public List<AlertHandlingUser>Alert_ID
        {
            get { return _Alert_ID; }
            set { _Alert_ID = value; }
        }
    }
}
