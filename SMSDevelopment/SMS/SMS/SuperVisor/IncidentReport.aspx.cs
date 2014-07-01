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
using SMS.Services.DataService;
using System.Data.SqlClient;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;

namespace SMS.SuperVisor
{
    public partial class IncidentReport : System.Web.UI.Page
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
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtReportNumber.Focus();
                lblerror.Visible = false;
                lblerr2.Visible = false;
                lblerr3.Visible = false;
               
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security officer")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }                  
                }                   
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
                }
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        private int GetLocationIdbyName(string name)
        {
            int locid = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", name);

            DataTable dtLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dtLocationid.Rows.Count > 0)
            {
                locid = Convert.ToInt32(dtLocationid.Rows[0][0].ToString().Trim());
                return locid;
            }
            return locid;
        }


        protected void btnSearchIncidentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewUserIncidentRequest objAddUserIncident = new AddNewUserIncidentRequest();
                UserIncident ObjUserIncident = new UserIncident();
                //String ZipRegex = "^[0-9 a-z A-Z]+$";
                DateTime datetime;
                if (txtReportNumber.Text.Trim() != "")
                {
                    column = "Report_No";
                    table = "Incident_Master";
                    where = "where Report_No='" + txtReportNumber.Text.Trim() + "'";
                    if (b.isexistBLL(column, table, where))
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Report No. Already Exist ..!";
                        lblerr2.Visible = true;
                        throw new Exception();
                    }


                        ObjUserIncident.Date_of_Incident = DateTime.TryParse(calDateOfIncident.Text, out datetime) ? (DateTime?)datetime : null; ;
                        string dt = TimeSelector1.Date.TimeOfDay.ToString();
                        ObjUserIncident.Time_of_Incident = dt;
                        ObjUserIncident.Assignment = ddllocation.Text.Trim();
                        ObjUserIncident.Place_of_Incident = txtEnterPlaceOfIncident.Text.Trim();
                        
                        ObjUserIncident.Report_No = txtReportNumber.Text.Trim();
                        ObjUserIncident.Location_id = Convert.ToString(GetLocationIdbyName(ddllocation.Text.Trim()));

                        ObjUserIncident.ReportDetail = txtEnterReportstatement.Text;
                        ObjUserIncident.Reported_By = txtReportedBy.Text;

                        ObjUserIncident.Received_By = txtReceivedBy.Text;
                        ObjUserIncident.ReceivedVerified_By = txtReceivedVerifiedBy.Text;
                        ObjUserIncident.followstatus = lblstatusopen.Text;

                        AdminBLL ws = new AdminBLL();
                        ws.AddUserIncident(ObjUserIncident);
                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");                  
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Invalid Report No. ..!";
                    lblerr2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
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
