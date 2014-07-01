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
    public partial class ChangeActionReviewStageMD : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                DataSet ds = dal.getdataset("select * from tblCustomerComplaint with(nolock) where intID=" + id);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtIssueRaised.Text = ds.Tables[0].Rows[0]["IssueRaised"].ToString();
                    txtdescProb.Text = ds.Tables[0].Rows[0]["strDescription"].ToString();
                    txtBy.Text = ds.Tables[0].Rows[0]["strRaisedBy"].ToString();
                    calDate.Text = ds.Tables[0].Rows[0]["dtmDate"].ToString();
                    txtRootCause.Text = ds.Tables[0].Rows[0]["strCause"].ToString();
                    txtAOC.Text = ds.Tables[0].Rows[0]["Analysis"].ToString();
                    txtAO.Text = ds.Tables[0].Rows[0]["AOU"].ToString();
                    txtGO.Text = ds.Tables[0].Rows[0]["Goals"].ToString();
                    txtAR.Text = ds.Tables[0].Rows[0]["strActionFix"].ToString();
                    txtART.Text = ds.Tables[0].Rows[0]["strActionPrevent"].ToString();
                    txtexpected.Text = ds.Tables[0].Rows[0]["dtmExpectedCompletion"].ToString(); 

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string actions = txtAction.Text.ToString().Trim();
            string comments1 = txtcomments1.Text.ToString().Trim();
            string comments2 = txtcomments2.Text.ToString().Trim();
            string comments3 = txtComments3.Text.ToString().Trim();
            string VerifyBy = Txtverifyby.Text.ToString().Trim();
            
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            string update = "update tblCustomerComplaint set dtmActionApproved='" + actions + "',Comments1='" + comments1 + "',Comments2='" + comments2 + "',Comments3='" + comments3 + "',VerifiedBy='" + VerifyBy + "',CreditNote='"+txtcreditNote.Text+"',status='Closed' where intID=" + id;
            dal.executesql(update);
            lblerror.Text = "Done";
            lblerror.Visible = true;
            Response.Redirect("CompleteForm.aspx");

        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=750px,width=850px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
