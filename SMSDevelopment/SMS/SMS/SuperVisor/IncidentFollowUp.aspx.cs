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


using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;


namespace SMS.SuperVisor
{
    public partial class IncidentFollowUp : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        AdminBLL b = new AdminBLL();
        String column = string.Empty;
        String table = string.Empty;
        String where = string.Empty;
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;
            lblerr2.Visible = false;
            lblerror.Visible = false;
            lblerr3.Visible = false;
            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                   Incident_id.Text= iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                getReportNo(iBTID);
            }
        }
        private void getReportNo(string incidentid)
        {
            string id = string.Empty;
            DataSet dsget = dal.getdataset("Select Report_No,Date_of_Incident,Time_of_Incident,Place_of_Incident,ReportDetail,Reported_By,followstatus from Incident_Master where Incident_id = '" + incidentid + "' ");
            if (dsget.Tables[0].Rows.Count > 0)
            {
                txtReportNumber.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                calDateOfIncident.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                TimeSelector1.Date = Convert.ToDateTime(dsget.Tables[0].Rows[0][2].ToString().Trim());
                
                txtEnterPlaceOfIncident.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                txtEnterReportstatement.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                txtInvestigationby.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                lblStatus.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                
            }
            
        }


        protected void btnIncidentFollowUp_Click(object sender, EventArgs e)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewUserIncidentRequest objAddUserIncident = new AddNewUserIncidentRequest();
                UserIncident ObjUserIncident = new UserIncident();
                DateTime datetime;
                    if (lblStatus.Text == "Open")
                    {
                        
                        cn.Open();
                        SqlCommand _cmd = new SqlCommand("update Incident_Master set Report_No=@Report_No, Place_of_Incident=@Place_of_Incident, followstatus=@followstatus, Time_of_Incident=@Time_of_Incident, ReportDetail=@ReportDetail, Assignment=@Assignment, Date_of_Incident=@Date_of_Incident, Verified_By=@Verified_By, followinvesti=@followinvesti where Incident_id=@Incident_id  ", cn);
                        //SqlCommand _cmd = new SqlCommand("update Incident_Master set Report_No=@Report_No, Place_of_Incident=@Place_of_Incident, followstatus=@followstatus,ReportDetail=@ReportDetail, Assignment=@Assignment,Verified_By=@Verified_By, followinvesti=@followinvesti where Incident_id=@Incident_id ", cn);
                        _cmd.Parameters.AddWithValue("@Report_No",txtReportNumber.Text.Trim());
                        _cmd.Parameters.AddWithValue("@Place_of_Incident",txtEnterPlaceOfIncident.Text);
                        _cmd.Parameters.AddWithValue("@followstatus","Close");
                        _cmd.Parameters.AddWithValue("@Time_of_Incident",TimeSelector1.Date.TimeOfDay.ToString());
                        _cmd.Parameters.AddWithValue("@ReportDetail",txtEnterReportstatement.Text.Trim());
                        _cmd.Parameters.AddWithValue("@Assignment", txtFollowStatement.Text.Trim());
                        _cmd.Parameters.AddWithValue("@Date_of_Incident",Convert.ToDateTime(calDateOfIncident.Text));
                        _cmd.Parameters.AddWithValue("@Verified_By", txtFollowVerified.Text.Trim());
                        _cmd.Parameters.AddWithValue("@followinvesti",txtInvestigationby.Text.Trim());
                        _cmd.Parameters.AddWithValue("@Incident_id",Incident_id.Text.Trim());
                        int result=_cmd.ExecuteNonQuery();
                        if (result > 0) { Server.Transfer("CompleteForm.aspx"); cn.Close(); }
                        /*ObjUserIncident.Report_No = txtReportNumber.Text.Trim();
                        ObjUserIncident.Incident_id = Incident_id.Text.Trim();
                        ObjUserIncident.Place_of_Incident = txtEnterPlaceOfIncident.Text;
                        //.Date_of_Incident = DateTime.TryParse(calDateOfIncident.Text, out datetime) ? (DateTime?)datetime : null; ;
                        ObjUserIncident.Date_of_Incident = Convert.ToDateTime(calDateOfIncident.Text);
                        ObjUserIncident.followstatus = "Close";
                        ObjUserIncident.Time_of_Incident = TimeSelector1.Date.TimeOfDay.ToString();
                        ObjUserIncident.ReportDetail = txtEnterReportstatement.ToString().Trim();
                        ObjUserIncident.followsremark = txtFollowStatement.ToString().Trim();
                        ObjUserIncident.followinvesti = txtInvestigationby.ToString().Trim();
                        ObjUserIncident.Verified_By = txtFollowVerified.ToString().Trim();
                        AdminBLL ws = new AdminBLL();
                        ws.Updatincident(ObjUserIncident);
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("CompleteForm.aspx");*/
                        //======================//
                        cn.Close();
                        //======================//
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Already Follow-Up Incident ..!";
                        lblerr2.Visible = true;

                    }

            }
            catch (Exception ex)
            {
                cn.Close();
                logger.Info(ex.Message);
            }
        }

        private int getIncidentid(string reportno)
        {
            int i = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Report_No", reportno);
            DataTable dt = dal.executeprocedure("sp_GetIncidentIDbyReportNo", para, false);

            if (dt.Rows.Count > 0)
            {
                i = Convert.ToInt32(dt.Rows[0][0].ToString());
                return i;
            }
            return i;
        }




    }
}
