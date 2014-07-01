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
using SMS.master;
namespace SMS.ADMIN
{
    public partial class profile_viewreport : System.Web.UI.Page
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

                    
                        if (Session["StaffID1"] != null)
                        {
                            iBTID = Session["StaffID1"].ToString();
                            PopulatePageCntrls(iBTID);
                        }
                    
                   
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
                Session["ctrl"] = printview;
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

                    HypNRICWorkPermit.ToolTip = dsStaff.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    NSRSWSQModules.ToolTip = dsStaff.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    OtherRecognisedCertificate.ToolTip = dsStaff.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    ExemptionCertificate.ToolTip = dsStaff.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    SecurityOfficerLicense.ToolTip = dsStaff.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    SIRDScreen.ToolTip = dsStaff.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();
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

        # region Google viewer
        protected void ButtonCancelViewer_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupViewer.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void Nricworkpermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];



                if (HypNRICWorkPermit.ToolTip != "")
                {
                    string[] name = HypNRICWorkPermit.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void NSRSWSQModules_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (NSRSWSQModules.ToolTip != "")
                {

                    string[] name = NSRSWSQModules.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();


                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void OtherRecognisedCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (OtherRecognisedCertificate.ToolTip != "")
                {
                    string[] name = OtherRecognisedCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ExemptionCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (ExemptionCertificate.ToolTip != "")
                {
                    string[] name = ExemptionCertificate.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SecurityOfficerLicense_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SecurityOfficerLicense.ToolTip != "")
                {
                    string[] name = SecurityOfficerLicense.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void SIRDScreen_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                var domainname = Request.ServerVariables["HTTP_HOST"];
                if (SIRDScreen.ToolTip != "")
                {
                    string[] name = SIRDScreen.ToolTip.Split('/');

                    string s = " https://docs.google.com/viewer?url=http://" + domainname + "/FileUpload/" + name[2] + "&embedded=true";
                    ViewerDoc.Attributes.Add("src", s);
                    ModalPopupViewer.Show();
                    ModalPopupViewer.Show();
                }
                else
                {

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("No Document Attached..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion
    }
}