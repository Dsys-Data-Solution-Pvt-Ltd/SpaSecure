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

namespace SMS.SuperVisor
{
    public partial class ChangeNotification_View : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id =Convert.ToInt32(Request.QueryString["id"].ToString());
                DataSet ds = dal.getdataset("select * from ChangeNotification with(nolock) where Notification_id="+id);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblRefNo.Text = ds.Tables[0].Rows[0]["RefNumber"].ToString();
                    lbldate.Text = ds.Tables[0].Rows[0]["NotifyDate"].ToString();
                    lblAttn.Text = ds.Tables[0].Rows[0]["Attn"].ToString();
                    lblreplaced.Text = ds.Tables[0].Rows[0]["replacedon"].ToString();
                    txtguardfrom.Text = ds.Tables[0].Rows[0]["SecurityGuardFromName"].ToString();
                    txtguardfromNric.Text = ds.Tables[0].Rows[0]["SecurityGuardFromNRIC"].ToString();
                    txtToguard.Text = ds.Tables[0].Rows[0]["SecurityGuardToName"].ToString();
                    txtToguardnric.Text = ds.Tables[0].Rows[0]["SecurityGuardToNRIC"].ToString();

                }
            }
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
    }
}
