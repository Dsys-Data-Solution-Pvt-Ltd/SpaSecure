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

namespace SMS.ADMIN
{
    public partial class Staff_ViewReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        String iBTID = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Request.QueryString["StaffID_Roster"] != null)
                {
                    iBTID = Request.QueryString["StaffID_Roster"];
                    this.MasterPageFile = "";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    if (Request.QueryString["StaffID"] != null)
                    {
                        iBTID = Request.QueryString["StaffID"];
                    }
                    if (Request.QueryString["StaffID_Roster"] != null)
                    {
                        iBTID = Request.QueryString["StaffID_Roster"];
                    }
                    
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {           
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string fullname = string.Empty;
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@StaffID", argsBGID);                
                DataTable dsStaff = dal.executeprocedure("usp_GetEnrollStaff", para, true);                 
                if (dsStaff.Rows.Count > 0)
                {
                    
                    fullname = dsStaff.Rows[0]["Staff_PreName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["FirstName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["MiddleName"].ToString().Trim();
                    fullname += " ";
                    fullname += dsStaff.Rows[0]["LastName"].ToString().Trim();
                    txtfullname.Text = fullname;

                    txtNRIC.Text = dsStaff.Rows[0]["NRICno"].ToString().Trim();
                    txtDOB.Text = dsStaff.Rows[0]["Staff_DOB"].ToString().Trim();
                    txtSex.Text = dsStaff.Rows[0]["Staff_Sex"].ToString().Trim();
                    txtReligion.Text = dsStaff.Rows[0]["Staff_Religion"].ToString().Trim();
                    txtRace.Text = dsStaff.Rows[0]["Staff_Race"].ToString().Trim();
                    txtAge.Text = dsStaff.Rows[0]["Staff_Age"].ToString().Trim();

                    txtMaritalStatus.Text = dsStaff.Rows[0]["Staff_MaritalStatus"].ToString().Trim();
                    txtRole.Text = dsStaff.Rows[0]["Role"].ToString().Trim();
                    ImgageStaff.ImageUrl = dsStaff.Rows[0]["ImagePathName"].ToString().Trim();
                    //ImgageStaff.ImageUrl = "~/admin/Images/f45d6f3d4f32.jpg";
                    txtContNo.Text = dsStaff.Rows[0]["Staff_Telphone"].ToString().Trim();

                    HypNRICWorkPermit.NavigateUrl = dsStaff.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    NSRSWSQModules.NavigateUrl = dsStaff.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    OtherRecognisedCertificate.NavigateUrl = dsStaff.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    ExemptionCertificate.NavigateUrl = dsStaff.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    SecurityOfficerLicense.NavigateUrl = dsStaff.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    SIRDScreen.NavigateUrl = dsStaff.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();                   
                }

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
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintViewPage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}

