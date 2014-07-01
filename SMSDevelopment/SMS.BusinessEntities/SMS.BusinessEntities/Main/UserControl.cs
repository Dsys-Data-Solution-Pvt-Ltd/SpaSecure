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

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class UserControl
    {
        public String UsrID { get; set; }
        public String UsrPwd { get; set; }
        public String UsrRole { get; set; }
        public String UsrSecurityQuestion { get; set; }
        public String UsrAnswerSecurity { get; set; }
        public String UsrWorkingStatus { get; set; }

    }
}
