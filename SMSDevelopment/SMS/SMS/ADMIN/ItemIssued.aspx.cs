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
using SMS.Services.DataService;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using System.Globalization;
using SMS.SMSAppUtilities;

namespace SMS.ADMIN
{
    public partial class ItemIssued : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string Staff_ID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
                if (!IsPostBack)
                {
                    lblerror1.Text = "Staff Added Successfully.";
                }
               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdIssueItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=0','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }           
        }

        protected void cmdViewIssueItem_Click(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=1','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdbuttonCancelItem_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
           
        }
    }
}
