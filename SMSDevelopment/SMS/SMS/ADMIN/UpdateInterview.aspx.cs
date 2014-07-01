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
namespace SMS.ADMIN
{
    public partial class UpdateInterview : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString["id"].ToString());
                        PopulatePageCntrls(id);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void PopulatePageCntrls(int id)
        {
            DataSet ds = dal.getdataset("select * from InterviewManager with(nolock) where Interview_id ="+id);
            if (ds != null && ds.Tables[0].Rows.Count >= 1)
            {
                string status = ds.Tables[0].Rows[0]["Status"].ToString();
                if (status == "Prescreen")
                    ddlInterviewStatus.SelectedIndex = 0;
                if (status == "Invite for Interview")
                    ddlInterviewStatus.SelectedIndex = 1;
                if (status == "Rejected")
                    ddlInterviewStatus.SelectedIndex = 2;
                txtCandidateName.Text = ds.Tables[0].Rows[0]["Candidate_Name"].ToString();
                txtCandidatePhone.Text = ds.Tables[0].Rows[0]["Candiddate_PhoneNo"].ToString();
                calDateOfIncident.Text = ds.Tables[0].Rows[0]["Prescreen_date"].ToString();
                txtInterviewDate.Text = ds.Tables[0].Rows[0]["Interview_Date"].ToString();
                interviewtime.Visible = false;
                //if (ds.Tables[0].Rows[0]["Interview_Time"].ToString() != "" || ds.Tables[0].Rows[0]["Interview_Time"].ToString()!=null)
                //    interviewtime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Interview_Time"].ToString().Trim());
                txtinterviewerPerson.Text = ds.Tables[0].Rows[0]["Interviewer_PersonName"].ToString();
                txtComment.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            }
        }

        protected void btnSearchIncidentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                string status = ddlInterviewStatus.SelectedValue;
                string candidate_Name = txtCandidateName.Text.ToString().Trim();
                string candidatePhone = txtCandidatePhone.Text.ToString().Trim();
                DateTime InterviewDate = Convert.ToDateTime(txtInterviewDate.Text);
                DateTime InterViewTime = Convert.ToDateTime(interviewtime.Date.ToShortTimeString());
                string interviewer = txtinterviewerPerson.Text;
                string comment = txtComment.Text;
                string UpdateQuery = "update InterviewManager set status='" + status + "',Candidate_Name='" + candidate_Name + "',Candiddate_PhoneNo='" + candidatePhone + "',Interview_Date='" + InterviewDate + "',Comments='" + comment + "',Interviewer_PersonName='" + interviewer + "' where Interview_id=" + id;
                dal.executesql(UpdateQuery);
                Response.Redirect("InterviewManagement.aspx");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
