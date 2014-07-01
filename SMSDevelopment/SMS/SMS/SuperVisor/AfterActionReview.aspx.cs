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
    public partial class AfterActionReview : System.Web.UI.Page
    {
        AdminDAL da = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                
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
                string IssueRaised = txtIssueRaised.Text.ToString().Trim();
                string desc = txtdescProb.Text.ToString().Trim();
                string raisedby = txtBy.Text.ToString().Trim();
                string date1 = calDate.Text.ToString().Trim();
                string query = "insert into tblCustomerComplaint(IssueRaised,strDescription,strRaisedBy,dtmDate,Status)values('" + IssueRaised + "','" + desc + "','" + raisedby + "','" + date1 + "','New')";

                dal.executesql(query);
                lblerror.Text = "Thanks.Complaint submitted to proceed further....";
                lblerror.Visible = true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

           
        }
    }
}
