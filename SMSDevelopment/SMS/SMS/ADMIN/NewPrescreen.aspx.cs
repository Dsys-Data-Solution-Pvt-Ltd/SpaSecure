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

namespace SMS.ADMIN
{
    public partial class NewPrescreen : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    calDateOfIncident.Text = DateTime.Now.ToString();
                }
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnSearchIncidentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string Candidate_Name = txtCandidateName.Text.ToString().Trim();
                string Phone = txtCandidatePhone.Text.ToString().Trim();
                DateTime PrescreenDate = Convert.ToDateTime(calDateOfIncident.Text);
                string status = ddlInterviewStatus.SelectedItem.Text.ToString();
                DateTime InterviewDate = Convert.ToDateTime(txtInterviewDate.Text);
                string interviewerperson = txtinterviewerPerson.Text;
                string comment = txtComment.Text;

                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@Candidate_Name", Candidate_Name);
                para[1] = new SqlParameter("@Candiddate_PhoneNo", Phone);
                para[2] = new SqlParameter("@Comments", comment);
                para[3] = new SqlParameter("@Interviewer_PersonName", interviewerperson);

                para[4] = new SqlParameter("@Prescreen_date", PrescreenDate);
                para[5] = new SqlParameter("@Interview_Date", InterviewDate);
                para[6] = new SqlParameter("@Interview_Time", interviewtime.Date.ToString());
                dal.exeprocedure("SP_InsertInterview", para);

                //dal.executesql("insert into InterviewManager(Candidate_Name,Prescreen_date,Candiddate_PhoneNo,Interview_Date,Interview_Time,Comments,Interviewer_PersonName,Status) values('" + Candidate_Name + "','" + dt.ToString() + "','" + Phone + "','" + InterviewDate + "','" + interviewtime.Date.ToString() + "',"+interviewer+"' ,'" + comment + "','Prescreen')");
                lblerror.Text = "Inserted Successfully .....";
                lblerror.Visible = true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
