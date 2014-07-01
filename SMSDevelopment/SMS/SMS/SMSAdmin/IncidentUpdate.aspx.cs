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
using System.Data.SqlClient;


using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;


namespace SMS.SMSAdmin
{
    public partial class IncidentUpdate : System.Web.UI.Page
    {
        SqlConnection cn;
        AdminDAL a = new AdminDAL();

        protected void Page_Load(object sender, EventArgs e)
        { 
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
          {
            String iBTID = string.Empty;
            cn = a.getconnection();

            String q;
            q = "select Description from log where ID='incidenttype'";
            SqlCommand cmd = new SqlCommand(q, cn);
            SqlDataReader rec = cmd.ExecuteReader();
            while (rec.Read())
            {
                if (!IsPostBack)
                    DropDownList2.Items.Add(rec.GetValue(0).ToString());
            }
                rec.Close();
              //========================//
                rec.Dispose();
              //===============================//
            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }
       }

        protected void btnsave_Click(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
            {
            
                UserIncident objincident = new UserIncident();
                AdminBLL ws = new AdminBLL();
                DateTime datetime;

                objincident.Date_of_Incident = DateTime.TryParse(calDateOfIncident.Text, out datetime) ? (DateTime?)datetime : null; ; ; ;
                String dt = TimeSelector1.Date.TimeOfDay.ToString();
                objincident.Time_of_Incident = dt;
                objincident.Report_No = txtReportNumber.Text;
                objincident.ReportDetail = txtEnterReportstatement.Text;
                objincident.Assignment = txtEnterAssignments.Text;
                objincident.Place_of_Incident = txtEnterPlaceOfIncident.Text;
                objincident.Type_of_Incident = DropDownList2.Text;

                objincident.Reported_By = txtReportedBy.Text;
                objincident.Name = txtReportedByName.Text;
                objincident.Verified_By = txtVerifiedBy.Text;

                ws.Updatincident(objincident);
                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");           

           }
          catch (Exception ex)
           {
            logger.Info(ex.Message);
           }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
            try
            {
                Response.Redirect("../Reports/IncidentReport.aspx");

            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetIncidentDataResponse ret = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                    DateTime dt;
                    AdminBLL objAdminBLL = new AdminBLL();
                    GetIncidentData objGetBillingTableRequest = new GetIncidentData();


                    objGetBillingTableRequest.Report_No = argsBGID.ToString();

                    objGetBillingTableRequest.WhereClause = " where Report_No='" + argsBGID.ToString() + "'";
                    ret = objAdminBLL.GetIncidentData(objGetBillingTableRequest);


                    hdnBTID.Value = ret.Incident[iCount].Report_No.ToString();

                    dt = Convert.ToDateTime(ret.Incident[iCount].Date_of_Incident);
                    calDateOfIncident.Text = Convert.ToString(dt);

                    dt = Convert.ToDateTime(ret.Incident[iCount].Time_of_Incident);
                    TimeSelector1.Date = dt;


                    txtReportNumber.Text = ret.Incident[iCount].Report_No.ToString();
                    txtEnterReportstatement.Text = ret.Incident[iCount].ReportDetail.ToString();

                    txtEnterAssignments.Text = ret.Incident[iCount].Assignment.ToString();
                    txtEnterPlaceOfIncident.Text = ret.Incident[iCount].Place_of_Incident.ToString();
                    DropDownList2.Text = ret.Incident[iCount].Type_of_Incident.ToString();
                    txtReportedBy.Text = ret.Incident[iCount].Reported_By.ToString();
                    txtReportedByName.Text = ret.Incident[iCount].Name.ToString();
                    txtVerifiedBy.Text = ret.Incident[iCount].Verified_By.ToString();

               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void calDateOfIncident_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEnterReportstatement_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}
