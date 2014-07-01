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

namespace SMS.Reports
{
    public partial class IncidentReportadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------image display---------------------------
            DBConnectionHandler1 bd = new DBConnectionHandler1();
            SqlConnection cn = bd.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(0) != "")
                {
                    image1.ImageUrl = dr.GetString(0);
                    cn.Close();
                    dr.Close();
                }
            }
            //---------------------------=---------------------------
            String iBTID = string.Empty;
            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();                   
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }
                PopulatePageCntrls(iBTID);
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
                dt = Convert.ToDateTime(ret.Incident[iCount].Date_of_Incident);
                txtdate.Text = dt.ToShortDateString().ToString();
                txttime.Text = ret.Incident[iCount].Time_of_Incident.ToString();
                txtReportno.Text = ret.Incident[iCount].Report_No.ToString();
                txtreportedby.Text = ret.Incident[iCount].Received_By.ToString();               
                txtsite.Text = ret.Incident[iCount].Place_of_Incident.ToString();               
                txtstatement.Text = ret.Incident[iCount].ReportDetail.ToString();
                txtfollownric.Text = ret.Incident[iCount].follownric.ToString();
                txtfollowinvestigate.Text = ret.Incident[iCount].followinvesti.ToString();
                txtfollowverify.Text = ret.Incident[iCount].followverify.ToString();
                txtfollowreport.Text = ret.Incident[iCount].followsremark.ToString();
                txtfollowstatus.Text = ret.Incident[iCount].followstatus.ToString();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
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
