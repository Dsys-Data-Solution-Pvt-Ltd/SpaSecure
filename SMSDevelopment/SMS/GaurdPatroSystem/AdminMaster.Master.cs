using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Mywisetutor.ADMIN
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
               // lnknewclient.Visible = false;
                if (Session["RoleInfo"] != null)
                {
                    if (Session["RoleInfo"].ToString() == "Client")
                    {
                        //lnknewclient.Visible = false;
                    }
                    else
                    {
                        //lnknewclient.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
