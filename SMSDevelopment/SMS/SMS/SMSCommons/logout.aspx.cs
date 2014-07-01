using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SMS.SMSAppUtilities;


namespace SMS.SMSUsers
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[SessionKeys.SESSION_LOGIN_USER] = null;
            Session[SessionKeys.SESSION_MENU_ITEMS] = null;
            Session["Staff_ID"] = null;
            Session["ManagementRole"] = null;
            Session["SubRole"] = null;
            Session["LCID"] = null;

            Server.Transfer("login.aspx");
        }
    }
}
