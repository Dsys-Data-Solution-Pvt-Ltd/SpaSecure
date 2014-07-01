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

namespace SMS.ADMIN
{
    public partial class GuardSystem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //string url = "http://localhost:50670/loginhome.aspx";
                string newurl = "http://tspsecure.com/gaurdPatroSystem/loginhome.aspx";
               //string newurl = "http://spasecure.com/gaurdPatroSystem/loginhome.aspx";
                frmguardtime.Attributes["src"] = newurl;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
