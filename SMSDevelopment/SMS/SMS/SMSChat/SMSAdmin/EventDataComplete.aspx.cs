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

using Microsoft.SqlServer.Management.Trace;
using log4net;
using log4net.Config;

namespace SMS.SMSAdmin
{
    public partial class EventDataComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (HttpContext.Current.Items["COMPLETE"] != null)
                    switch (HttpContext.Current.Items["COMPLETE"].ToString())
                    {
                        case "UPDATE":
                            tblUpdateMsg.Visible = true;
                            break;
                        case "INSERT":
                            tblInsertMsg.Visible = true;
                            break;
                        case "DELETE":
                            tblDeleteMsg.Visible = true;
                            break;
                    }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SMSCommons/default.aspx");
                //Response.Redirect(CMSAppUtilities.CMSAppUtilities.RetrieveMainURL("UserInfoMain.aspx"));
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
