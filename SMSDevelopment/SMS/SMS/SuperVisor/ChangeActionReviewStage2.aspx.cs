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
    public partial class ChangeActionReviewStage2 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
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
                    }
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                string root = txtRootCause.Text.ToString().Trim();
                string AOC = txtAOC.Text.ToString().Trim();
                string AO = txtAO.Text.ToString().Trim();
                string GO = txtGO.Text.ToString().Trim();
                string AR = txtAR.Text.ToString().Trim();
                string ART = txtART.Text.ToString().Trim();
                string expdate = txtexpected.Text.ToString().Trim();
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());

                string update = "update tblCustomerComplaint set strCause='" + root + "',Analysis='" + AOC + "',AOU='" + AO + "',Goals='" + GO + "',strActionFix='" + AR + "',strActionPrevent='" + ART + "',dtmExpectedCompletion='" + expdate + "',status='Operations Replied' where intID=" + id;
                dal.executesql(update);
                lblerror.Text = "Submitted to MD";
                lblerror.Visible = true;                
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
            
           

        }
    }
}
