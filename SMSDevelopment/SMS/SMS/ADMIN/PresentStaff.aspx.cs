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
using System.Collections.Generic;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using System.IO;
using System.Globalization;
using SMS.master;
using DPFP.Verification;
using DPFP;
namespace SMS.ADMIN
{
    public partial class PresentStaff : System.Web.UI.Page
    {
        string iBTID = string.Empty;
        DataAccessLayer dal = new DataAccessLayer();
        string Staff_ID = string.Empty;
        int goout = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {


                //errFname.Visible = false;
                //errUserid.Visible = false;
                //lblnri5.Visible = false;
                //errnri.Visible = false;
                //errUserPassword.Visible = false;






                // txtnric.Focus();
                if (!IsPostBack)
                {
                    fillrole();
                    fillroleUpda();


                    fillSecurityqust();
                    fillSecurityqustUpda();
                    ColorTab();
                    lnkPresent.BackColor = System.Drawing.Color.Maroon;
                    lnkPresent.ForeColor = System.Drawing.Color.White;

                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvLoctionTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilter();


                                }
                                else
                                {

                                }

                            }
                        }
                    }
                }
                else
                {
                    BindGridWithFilter();

                }
                if (Session["Staff_ID_LOCAL"] == null)
                {
                    SqlDataReader rd = dal.getDataReader("SELECT part from SplitString(convert(varchar(100),newid()),'-')where id = (select max(id) from SplitString(convert(varchar(100),newid()),'-'))");
                    if (rd.Read())
                    {
                        Staff_ID = rd.GetValue(0).ToString().Trim();
                        Session["Staff_ID_LOCAL"] = Staff_ID.ToString();
                    }
                    rd.Dispose();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void ColorTab()
        {
            lnkPresent.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            lnkPast.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetUserData objReq = new GetUserData();
                string WhereClause = ReturnWhere();
                if (goout == 0)
                {
                    DataSet dsgrid = dal.getdataset("Select * from UserInformation with(nolock) where Staff_Status='Present'");
                    GetUserDataResponse ret = ws.GetUserStaffInfo(objReq);
                    //gvLoctionTable.PageIndex = dal.gridpageindex;
                    int pageSize = 20;
                    gvLoctionTable.PageSize = pageSize;
                    gvLoctionTable.DataSource = dsgrid.Tables[0];
                    gvLoctionTable.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            //string rol = Session["role"].ToString();
            string rol = Session["user_role"].ToString();//change by rakesh
            int subrole = 0;

            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");
                if (str != "")
                {
                    str += " and Staff_Status= 'Present'";
                }
                if (str == "")
                {
                    if (arr.Count == 1)
                    {
                        //DataSet subroleid = dal.getdataset("Select submenuid from Submenu where SubRole='" + rol + "'");
                        DataSet subroleid = dal.getdataset("Select id from UserRoleMaster where UserRole='" + rol + "'");

                        if (subroleid.Tables[0].Rows.Count > 0)
                        {
                            subrole = Convert.ToInt32(subroleid.Tables[0].Rows[0][0].ToString());
                        }

                        str += " and Staff_Status= 'Present'";
                        DataSet dsrole = dal.getdataset("select Role,* from Userinformation where role in (Select UserRole from UserRoleMaster Where id >'" + subrole + "')" + str + " ");
                        if (dsrole.Tables[0].Rows.Count > 0)
                        {
                            int pageSize = ContextKeys.GRID_PAGE_SIZE;
                            //  gvLoctionTable.PageIndex = dal.gridpageindex;
                            // gvLoctionTable.PageSize = pageSize;
                            gvLoctionTable.DataSource = dsrole.Tables[0];
                            gvLoctionTable.DataBind();
                            //throw new Exception();
                            goout = 1;
                        }
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Staff_Status= 'Present'";
                    }
                }
                else
                {
                    goout = 0;
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
            return (str);
        }



        protected void btnNewLocation_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../ADMIN/AddNewStaff.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //  fillrole();
                //  txtdatefrom.Text = "";
                //  txtdateto.Text = "";               
                //   txtStaffName.Text = "";
                //   txtnric.Text = "";
                //ddlorderby.Text = "";
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLoctionTable_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void lnkPresent_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("PresentStaff.aspx", false);
            }
            catch (Exception ex)
            {
                logger.Info("PresentSite(lnkShowInfo_Click):" + ex.Message);
            }
        }
        protected void lnkPast_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtPastStaff = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "62");

                if (dtPastStaff.Rows.Count > 0)
                {
                    Response.Redirect("PastStaff.aspx", false);
                }
                else
                {


                    MyMasterPage.ShowErrorMessage("You Donot Have Permission..!");
                }

            }
            catch (Exception ex)
            {
                logger.Info("PresentSite(lnkShowInfo_Click):" + ex.Message);
            }
        }
        protected void imgAdd_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            DataTable dtAddStaff = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "61");

            if (dtAddStaff.Rows.Count > 0)
            {
                pnlAdd.Visible = true;
                pnlpopupEdit.Visible = false;
            }
            else
            {


                MyMasterPage.ShowErrorMessage("You Donot Have Permission..!");
            }

        }


        protected void cmdbuttonCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            //ModalPopupAdd.Hide();
            //  ModalPopupEdit.Hide();
            pnlpopupEdit.Visible = false;
            BindGridWithFilter();
        }

        #region Update Staff
        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["Staff_ID"] != null)
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtPresentStaff = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "60");

                if (dtPresentStaff.Rows.Count > 0)
                {
                    pnlpopupEdit.Visible = true;
                    pnlAdd.Visible = false;
                    //ModalPopupEdit.Show();
                    PopulatePageCntrls(iBTID);
                }
                else
                {


                    MyMasterPage.ShowErrorMessage("You Donot Have Permission..!");
                }
            }


        }


        private void fillroleUpda()
        {
            ddlRoleUpda.Items.Clear();
            ddlRoleUpda.Items.Add(" ");
            DataSet dsgrole = dal.getdataset("Select UserRole from UserRoleMaster order by UserRole Asc");
            if (dsgrole.Tables[0].Rows.Count > 0)
            {
                for (int h = 0; h < dsgrole.Tables[0].Rows.Count; h++)
                {
                    ddlRoleUpda.Items.Add(dsgrole.Tables[0].Rows[h][0].ToString());
                }
            }
        }

        private void fillSecurityqustUpda()
        {
            string ID = "securityquestion";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dt1.Rows.Count > 0)
            {
                ddlStaffSecQuesUpda.DataSource = dt1;
                ddlStaffSecQuesUpda.DataTextField = "Description";
                ddlStaffSecQuesUpda.DataBind();
                ddlStaffSecQuesUpda.Items.Insert(0, new ListItem(" ", " ", true));


            }

        }


        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetUserDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                hdnBTID.Value = argsBGID;

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@StaffID", argsBGID);
                string Staff_ID1 = ViewState["Staff_ID"].ToString().Trim();
                //DataTable dt = dal.executeprocedure("usp_GetEnrollStaff", para, false);
                string Bquery = " Select Staff_ID,Staff_PreName,FirstName,MiddleName,LastName,staff_Address,Staff_Telphone,Staff_HPno,Staff_Mobile,Staff_DOB,Staff_POB,Staff_Race,NRICno,Staff_Age,Staff_Religion,Staff_Sex,Staff_DriverLicense,Staff_IncomeTax,Staff_MaritalStatus,Staff_Occupation,Staff_NoOfChile,Staff_MarriedSpousName,Staff_EmergencyName,Staff_EmergencyAdd,Staff_EmergencyTelphone,Staff_PrimarySchoolName,Staff_PrimaryAddress,Staff_PrimaryFrom,Staff_PrimaryTo,Staff_PrimaryQualification,Staff_SecondarySchoolName,Staff_SecondaryAddress,Staff_SecondaryFrom,Staff_SecondaryTo,Staff_SecondaryQualification,Staff_VocationSchoolName,Staff_VocationAddress, Staff_VocationFrom,Staff_VocationTo,Staff_VocationQualification,Staff_OtherSchoolName,Staff_OtherAddress,Staff_OtherFrom,Staff_OtherTo,Staff_OtherQualification,Staff_OtherTraining,Staff_Hobbies,Staff_NSFrom,Staff_NSTo,Staff_NSTypeOfDischarge,Staff_NSVocation,Staff_NSNextInCamp,Staff_NSLastRank,Staff_NSExempted,Staff_NSReason, Staff_NSDateOFRegistration,Staff_EmpExCompName1,Staff_EmpExFrom1,Staff_EmpExTo1,Staff_EmpExReasonLeaving1,Staff_EmpExLastDrawnSalary1,Staff_EmpExCompName2,Staff_EmpExFrom2,Staff_EmpExTo2,Staff_EmpExReasonLeaving2,Staff_EmpExLastDrawnSalary2,Staff_EmpExCompName3,Staff_EmpExFrom3,Staff_EmpExTo3,Staff_EmpExReasonLeaving3,Staff_EmpExLastDrawnSalary3,Staff_EmpExCompName4,Staff_EmpExFrom4,Staff_EmpExTo4,Staff_EmpExReasonLeaving4,Staff_EmpExLastDrawnSalary4,Staff_ExpectedSalary,Staff_CommenceWork,Staff_LAWResion,Staff_InjuryResion,UserID,UserPassword,Role,UserSecretAns,Staff_NRICWorkPermitCertificate,Staff_NSRSWSQModulesCertificate,Staff_OtherRecognisedCertificate,Staff_ExemptionCertificate,Staff_SecurityOfficerLicenseCertificate,Staff_SIRDScreenCertificate,Staff_MalasianIC,Staff_MalasianOLDIC,Staff_MalasianPassportNo,Staff_MalasianPassportExpire,Staff_MalasianWorkPermit,Staff_MalasianWorkPermitExpire,Staff_MalasianEducationLevel,Staff_Citizenship,Squrity_Question,Staff_Mobile,ImagePathName,ThumbImage From UserInformation Where Staff_ID = '" + Staff_ID1 + "'  ";

                DataTable dt = dal.getdata(Bquery);
                if (dt.Rows.Count > 0)
                {
                    string Staffid = dt.Rows[0]["Staff_ID"].ToString().Trim();
                    txtStaff_ID.Text = dt.Rows[0]["Staff_ID"].ToString().Trim();
                    DropDownList1.Text = dt.Rows[0]["Staff_PreName"].ToString().Trim();

                    txtFnameUpda.Text = dt.Rows[0]["FirstName"].ToString().Trim();
                    txtMnameUpda.Text = dt.Rows[0]["MiddleName"].ToString().Trim();
                    txtLnameUpda.Text = dt.Rows[0]["LastName"].ToString().Trim();
                    txtHomeAdressUpda.Text = dt.Rows[0]["staff_Address"].ToString().Trim();
                    txtPhoneUpda.Text = dt.Rows[0]["Staff_Telphone"].ToString().Trim();
                    txtHPUpda.Text = dt.Rows[0]["Staff_HPno"].ToString().Trim();
                    txtMobNoUpda.Text = dt.Rows[0]["Staff_Mobile"].ToString().Trim();
                    txtDOBUpda.Text = dt.Rows[0]["Staff_DOB"].ToString().Trim();

                    txtPOBUpda.Text = dt.Rows[0]["Staff_POB"].ToString().Trim();
                    txtraceUpda.Text = dt.Rows[0]["Staff_Race"].ToString().Trim();
                    txtnricUpda.Text = dt.Rows[0]["NRICno"].ToString().Trim();

                    txtageUpda.Text = dt.Rows[0]["Staff_Age"].ToString().Trim();
                    txtreligionUpda.Text = dt.Rows[0]["Staff_Religion"].ToString().Trim();

                    DropDownList3Upda.Text = dt.Rows[0]["Staff_Sex"].ToString().Trim();
                    txtDlicenseUpda.Text = dt.Rows[0]["Staff_DriverLicense"].ToString().Trim();
                    txtincometaxUpda.Text = dt.Rows[0]["Staff_IncomeTax"].ToString().Trim();
                    DropDownList9.Text = dt.Rows[0]["Staff_MaritalStatus"].ToString().Trim();
                    txtOccupationUpda.Text = dt.Rows[0]["Staff_Occupation"].ToString().Trim();
                    txtnoOfChildernUpda.Text = dt.Rows[0]["Staff_NoOfChile"].ToString().Trim();

                    txtSpousenameUpda.Text = dt.Rows[0]["Staff_MarriedSpousName"].ToString().Trim();
                    txtEmergencyNameUpda.Text = dt.Rows[0]["Staff_EmergencyName"].ToString().Trim();

                    txtEmergenAddressUpda.Text = dt.Rows[0]["Staff_EmergencyAdd"].ToString().Trim();
                    txtEmergencContNoUpda.Text = dt.Rows[0]["Staff_EmergencyTelphone"].ToString().Trim();

                    txtEDnameofSchool1Upda.Text = dt.Rows[0]["Staff_PrimarySchoolName"].ToString().Trim();
                    txtEDaddres1Upda.Text = dt.Rows[0]["Staff_PrimaryAddress"].ToString().Trim();
                    txtEDFrom1Upda.Text = dt.Rows[0]["Staff_PrimaryFrom"].ToString().Trim();
                    txtEDTo1Upda.Text = dt.Rows[0]["Staff_PrimaryTo"].ToString().Trim();
                    txtEDqualification1Upda.Text = dt.Rows[0]["Staff_PrimaryQualification"].ToString().Trim();

                    txtEDnameofSchool2Upda.Text = dt.Rows[0]["Staff_SecondarySchoolName"].ToString().Trim();
                    txtEDaddres2Upda.Text = dt.Rows[0]["Staff_SecondaryAddress"].ToString().Trim();
                    txtEDFrom2Upda.Text = dt.Rows[0]["Staff_SecondaryFrom"].ToString().Trim();
                    txtEDTo2Upda.Text = dt.Rows[0]["Staff_SecondaryTo"].ToString().Trim();
                    txtEDqualification2Upda.Text = dt.Rows[0]["Staff_SecondaryQualification"].ToString().Trim();

                    txtEDnameofSchool3Upda.Text = dt.Rows[0]["Staff_VocationSchoolName"].ToString().Trim();
                    txtEDaddres3Upda.Text = dt.Rows[0]["Staff_VocationAddress"].ToString().Trim();
                    txtEDFrom3Upda.Text = dt.Rows[0]["Staff_VocationFrom"].ToString().Trim();
                    txtEDTo3Upda.Text = dt.Rows[0]["Staff_VocationTo"].ToString().Trim();
                    txtEDqualification3Upda.Text = dt.Rows[0]["Staff_VocationQualification"].ToString().Trim();

                    txtEDnameofSchool4Upda.Text = dt.Rows[0]["Staff_OtherSchoolName"].ToString().Trim();
                    txtEDaddres4Upda.Text = dt.Rows[0]["Staff_OtherAddress"].ToString().Trim();
                    txtEDFrom4Upda.Text = dt.Rows[0]["Staff_OtherFrom"].ToString().Trim();
                    txtEDTo4Upda.Text = dt.Rows[0]["Staff_OtherTo"].ToString().Trim();
                    txtEDqualification4Upda.Text = dt.Rows[0]["Staff_OtherQualification"].ToString().Trim();


                    txtotherSkillsUpda.Text = dt.Rows[0]["Staff_OtherTraining"].ToString().Trim();
                    txthobbiesUpda.Text = dt.Rows[0]["Staff_Hobbies"].ToString().Trim();

                    txtNSTimeUpda.Text = dt.Rows[0]["Staff_NSFrom"].ToString().Trim();
                    txtNSToUpda.Text = dt.Rows[0]["Staff_NSTo"].ToString().Trim();
                    txtNSTypeofDischargeUpda.Text = dt.Rows[0]["Staff_NSTypeOfDischarge"].ToString().Trim();
                    txtNSVocationUpda.Text = dt.Rows[0]["Staff_NSVocation"].ToString().Trim();
                    txtNSNextInCampUpda.Text = dt.Rows[0]["Staff_NSNextInCamp"].ToString().Trim();
                    txtNSLastRankUpda.Text = dt.Rows[0]["Staff_NSLastRank"].ToString().Trim();

                    txtNSExemptedUpda.Text = dt.Rows[0]["Staff_NSExempted"].ToString().Trim();
                    txtNSReasonUpda.Text = dt.Rows[0]["Staff_NSReason"].ToString().Trim();
                    txtNSPeriod.Text = dt.Rows[0]["Staff_NSDateOFRegistration"].ToString().Trim();

                    txtEnameofCompany1Upda.Text = dt.Rows[0]["Staff_EmpExCompName1"].ToString().Trim();
                    txtEFrom1Upda.Text = dt.Rows[0]["Staff_EmpExFrom1"].ToString().Trim();
                    txtETo1Upda.Text = dt.Rows[0]["Staff_EmpExTo1"].ToString().Trim();
                    txtEReasonleave1Upda.Text = dt.Rows[0]["Staff_EmpExReasonLeaving1"].ToString().Trim();
                    txtELastDraw1Upda.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary1"].ToString().Trim();

                    txtEnameofCompany2Upda.Text = dt.Rows[0]["Staff_EmpExCompName2"].ToString().Trim();
                    txtEFrom2Upda.Text = dt.Rows[0]["Staff_EmpExFrom2"].ToString().Trim();
                    txtETo2Upda.Text = dt.Rows[0]["Staff_EmpExTo2"].ToString().Trim();
                    txtEReasonleave2Upda.Text = dt.Rows[0]["Staff_EmpExReasonLeaving2"].ToString().Trim();
                    txtELastDraw2Upda.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary2"].ToString().Trim();

                    txtEnameofCompany3Upda.Text = dt.Rows[0]["Staff_EmpExCompName3"].ToString().Trim();
                    txtEFrom3Upda.Text = dt.Rows[0]["Staff_EmpExFrom3"].ToString().Trim();
                    txtETo3Upda.Text = dt.Rows[0]["Staff_EmpExTo3"].ToString().Trim();
                    txtEReasonleave3Upda.Text = dt.Rows[0]["Staff_EmpExReasonLeaving3"].ToString().Trim();
                    txtELastDraw3Upda.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary3"].ToString().Trim();

                    txtEnameofCompany4Upda.Text = dt.Rows[0]["Staff_EmpExCompName4"].ToString().Trim();
                    txtEFrom4Upda.Text = dt.Rows[0]["Staff_EmpExFrom4"].ToString().Trim();
                    txtETo4Upda.Text = dt.Rows[0]["Staff_EmpExTo4"].ToString().Trim();
                    txtEReasonleave4Upda.Text = dt.Rows[0]["Staff_EmpExReasonLeaving4"].ToString().Trim();
                    txtELastDraw4Upda.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary4"].ToString().Trim();
                    // ImgageStaffUpda.ImageUrl = dt.Rows[0]["ImagePathName"].ToString().Trim();
                    txtexpectedSalaryUpda.Text = dt.Rows[0]["Staff_ExpectedSalary"].ToString().Trim();
                    txtcommenceworkUpda.Text = dt.Rows[0]["Staff_CommenceWork"].ToString().Trim();
                    // DropDownList5.Text = dt.Rows[0][78].ToString().Trim();
                    txtLAWyesUpda.Text = dt.Rows[0]["Staff_LAWResion"].ToString().Trim();
                    if (txtLAWyesUpda.Text != "")
                    {
                        DropDownList5Upda.Text = "Yes";
                        Panel1.Visible = true;
                    }
                    else
                    {

                        DropDownList5Upda.Text = "No";
                        Panel1.Visible = false;
                    }
                    // DropDownList6.Text = dt.Rows[0][80].ToString().Trim();
                    txtInjuryyes.Text = dt.Rows[0]["Staff_InjuryResion"].ToString().Trim();

                    if (txtInjuryyesUpda.Text != "")
                    {
                        DropDownList6Upda.Text = "Yes";
                        Panel2Upda.Visible = true;
                    }
                    else
                    {
                        DropDownList6Upda.Text = "No";
                        Panel2Upda.Visible = false;
                    }

                    txtStaffUseridUpda.Text = dt.Rows[0]["UserID"].ToString().Trim();
                    txtStaffUserPasswordUpda.Text = dt.Rows[0]["UserPassword"].ToString().Trim();
                    txtStaffuserConfigPasswordUpda.Text = dt.Rows[0]["UserPassword"].ToString().Trim();
                    ddlRoleUpda.SelectedValue = dt.Rows[0]["Role"].ToString().Trim();
                    AddNewLabelUpda.Text = dt.Rows[0]["Role"].ToString().Trim();
                    txtStaffSeurityqtyUpda.Text = dt.Rows[0]["UserSecretAns"].ToString().Trim();

                    //lnkLabel1Upda.Text = hypNRICWorkPermit.NavigateUrl = dt.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    //lnkLabel2Upda.Text = hypNSRSWSQModule.NavigateUrl = dt.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    //lnkLabel3Upda.Text = hypOtherRecoQualify.NavigateUrl = dt.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    //lnkLabel4Upda.Text = hypExemptionCertificate.NavigateUrl = dt.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    //lnkLabel5Upda.Text = hypSecurityOfficerLicense.NavigateUrl = dt.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    //lnkLabel6Upda.Text = hypSIRDScreen.NavigateUrl = dt.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();

                    hypNRICWorkPermit.Text = dt.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    hypNSRSWSQModule.Text = dt.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    hypOtherRecoQualify.Text = dt.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    hypExemptionCertificate.Text = dt.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    hypSecurityOfficerLicense.Text = dt.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    hypSIRDScreen.Text = dt.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();

                    txtMalaysianICnoUpda.Text = dt.Rows[0]["Staff_MalasianIC"].ToString().Trim();
                    txtMalaysianOldICUpda.Text = dt.Rows[0]["Staff_MalasianOLDIC"].ToString().Trim();
                    txtMalasianPassportUpda.Text = dt.Rows[0]["Staff_MalasianPassportNo"].ToString().Trim();
                    txtMalasianPassportExpdateUpda.Text = dt.Rows[0]["Staff_MalasianPassportExpire"].ToString().Trim();
                    txtMalasianWorkPermitNoUpda.Text = dt.Rows[0]["Staff_MalasianWorkPermit"].ToString().Trim();
                    txtMalasianWorkPermitExpUpda.Text = dt.Rows[0]["Staff_MalasianWorkPermitExpire"].ToString().Trim();
                    DropDownList7Upda.Text = dt.Rows[0]["Staff_MalasianEducationLevel"].ToString().Trim();
                    DropDownList10.Text = dt.Rows[0]["Staff_Citizenship"].ToString().Trim();
                    if (dt.Rows[0]["Squrity_Question"].ToString() != "")
                    {
                        ddlStaffSecQuesUpda.Text = dt.Rows[0]["Squrity_Question"].ToString().Trim();
                    }
                    Session["CaptureImagePath"] = dt.Rows[0]["ImagePathName"].ToString().Trim();
                    ImgageStaff.ImageUrl = dt.Rows[0]["ImagePathName"].ToString().Trim();
                    string CaptureImage = dt.Rows[0]["ImagePathName"].ToString().Trim();
                    if (CaptureImage == "")
                    {
                        Session["CaptureImagePath"] = null;
                    }

                    string thpth = dt.Rows[0]["ThumbImage"].ToString();
                    //byte[] ss1 = System.Text.ASCIIEncoding.ASCII.GetBytes(thpth);
                    //thpth = System.Text.ASCIIEncoding.ASCII.GetString(ss1);
                    //lblheading.Text = thpth.ToString();
                    //int cou = ss1.Length;
                    //if (cou <= 0)
                    //{
                    //    Session["ThumbPath"] = null;
                    //}
                    //else
                    //{
                    Session["ThumbPath"] = dt.Rows[0]["ThumbImage"].ToString().Trim();
                    //if (thpth == "")
                    //{ 

                    //}

                    //hdnFP.Value = Session["ThumbPath"].ToString();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void cmdbuttonSave_Click(object sender, EventArgs e)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (txtFnameUpda.Text.Trim() == "")
                {
                    errFname.Visible = true;
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill First Name..!");
                    //  lblerror1Upda.Text = "Please Fill First Name...!";
                    throw new Exception();
                }
                if (txtMobNoUpda.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill Mob. No ..!");
                    throw new Exception();
                }
                if (txtnricUpda.Text.Trim() == "")
                {
                    errnri.Visible = true;
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill NRIC No ..!");
                    //lblerror1Upda.Text = "Please Fill NRIC No...!";
                    throw new Exception();
                }
                if (txtStaffUseridUpda.Text.Trim() == "")
                {
                    errUserid.Visible = true;
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill User ID ..!");
                    //   lblerror1Upda.Text = "Please Fill User ID...!";
                    throw new Exception();
                }
                if (txtStaffUserPasswordUpda.Text.Trim() == "")
                {
                    errUserPassword.Visible = true;
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill User Password ..!");
                    // lblerror1Upda.Text = "Please Fill User Password...!";
                    throw new Exception();
                }
                if (txtStaffuserConfigPasswordUpda.Text.Trim() != txtStaffUserPasswordUpda.Text.Trim())
                {
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Re-Confirm Password..!");
                    // lblerror1Upda.Text = "Re-Confirm Password...!";
                    throw new Exception();
                }
                string Staff_ID = txtStaff_ID.Text.Trim();
                string Staff_PreName = DropDownList8.SelectedItem.Value.Trim();
                string Staff_FName = txtFnameUpda.Text.Trim();
                string Staff_MName = txtMnameUpda.Text.Trim();
                string Staff_LName = txtLnameUpda.Text.Trim();
                string Staff_Address = txtHomeAdressUpda.Text.Trim();
                string Staff_Telphone = txtPhoneUpda.Text.Trim();
                string Staff_HPno = txtHPUpda.Text.Trim();
                string Staff_DOB = txtDOBUpda.Text.Trim();
                string Staff_POB = txtPOBUpda.Text.Trim();
                string Staff_Race = txtraceUpda.Text.Trim();
                string Staff_NRICno = txtnricUpda.Text.Trim();
                string Staff_Citizenship = DropDownList10.SelectedItem.Value.Trim();
                string Staff_Age = txtageUpda.Text.Trim();
                string Staff_Religion = txtreligionUpda.Text.Trim();
                string Staff_Sex = DropDownList3Upda.SelectedItem.Value.Trim();
                string Staff_DriverLicense = txtDlicenseUpda.Text.Trim();
                string Staff_MaritalStatus = DropDownList9.SelectedItem.Value.Trim();
                string Staff_NoOfChile = txtnoOfChildernUpda.Text.Trim();
                string Staff_MarriedSpousName = txtSpousenameUpda.Text.Trim();
                string Staff_EmergencyName = txtEmergencyNameUpda.Text.Trim();
                string Staff_EmergencyAdd = txtEmergenAddressUpda.Text.Trim();
                string Staff_EmergencyTelphone = txtEmergencContNoUpda.Text.Trim();
                string Staff_UserID = txtStaffUseridUpda.Text.Trim();
                string Staff_UserPassword = txtStaffUserPasswordUpda.Text.Trim();
                string Staff_ComfirmPassword = txtStaffuserConfigPasswordUpda.Text.Trim();
                string Staff_SecurityAns = txtStaffSeurityqtyUpda.Text.Trim();
                string Staff_SubRole = string.Empty;
                string SecurityQuestion = string.Empty;
                string role = ddlRoleUpda.SelectedItem.Value.ToString();
                if (role.ToString() != " ")
                {
                    Staff_SubRole = ddlRoleUpda.SelectedValue.ToString();

                }
                else
                {
                    Staff_SubRole = AddNewLabelUpda.Text;
                }
                string sequestion = ddlStaffSecQuesUpda.SelectedValue.ToString();
                if (sequestion.ToString() != " ")
                {
                    SecurityQuestion = ddlStaffSecQuesUpda.SelectedValue.ToString();

                }
                else
                {
                    SecurityQuestion = securityanswer.Text;
                }
                cn.Open();
                SqlCommand _cmd = new SqlCommand("update UserInformation set Staff_PreName=@Staff_PreName, FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Staff_Address=@Staff_Address, Staff_MaritalStatus=@Staff_MaritalStatus, Staff_MarriedSpousName=@Staff_MarriedSpousName, Staff_NoOfChile=@Staff_NoOfChile, Staff_Telphone=@Staff_Telphone, Staff_HPno=@Staff_HPno, Staff_DOB=@Staff_DOB, Staff_POB=@Staff_POB, Staff_Race=@Staff_Race, NRICno=@NRICno, Staff_Citizenship=@Staff_Citizenship, Staff_Age=@Staff_Age, Staff_MalasianIC=@Staff_MalasianIC, Staff_MalasianOLDIC=@Staff_MalasianOLDIC, Staff_MalasianPassportNo=@Staff_MalasianPassportNo, Staff_MalasianPassportExpire=@Staff_MalasianPassportExpire, Staff_MalasianWorkPermit=@Staff_MalasianWorkPermit, Staff_MalasianWorkPermitExpire=@Staff_MalasianWorkPermitExpire, Staff_MalasianEducationLevel=@Staff_MalasianEducationLevel, Staff_Religion=@Staff_Religion, Staff_Sex=@Staff_Sex, Staff_DriverLicense=@Staff_DriverLicense, Staff_EmergencyName=@Staff_EmergencyName, Staff_EmergencyAdd=@Staff_EmergencyAdd, Staff_EmergencyTelphone=@Staff_EmergencyTelphone, Role=@Role, UserID=@UserID, UserPassword=@UserPassword, Staff_ComfirmPassword=@Staff_ComfirmPassword, Squrity_Question=@Squrity_Question,UserSecretAns=@UserSecretAns where Staff_ID=@Staff_ID", cn);
                _cmd.Parameters.AddWithValue("@Staff_PreName", DropDownList1.SelectedValue.Trim());
                _cmd.Parameters.AddWithValue("@FirstName", txtFnameUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@MiddleName", txtMnameUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@LastName", txtLnameUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Address", txtHomeAdressUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MaritalStatus", DropDownList4.SelectedValue.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MarriedSpousName", txtSpousenameUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_NoOfChile", txtnoOfChildernUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Telphone", txtPhoneUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_HPno", txtHPUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_DOB", txtDOBUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_POB", txtPOBUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Race", txtraceUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@NRICno", txtnricUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Citizenship", DropDownList2.SelectedValue.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Age", txtageUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianIC", txtMalaysianICnoUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianOLDIC", txtMalaysianOldICUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianPassportNo", txtMalasianPassportUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianPassportExpire", txtMalasianPassportExpdateUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianWorkPermit", txtMalasianWorkPermitNoUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianWorkPermitExpire", txtMalasianWorkPermitExpUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_MalasianEducationLevel", DropDownList7Upda.SelectedValue.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Religion", txtreligionUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Sex", DropDownList3Upda.SelectedValue.Trim());

                _cmd.Parameters.AddWithValue("@Staff_DriverLicense", txtDlicenseUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_EmergencyName", txtEmergencyNameUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_EmergencyAdd", txtEmergenAddressUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_EmergencyTelphone", txtEmergencContNoUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Role", Staff_SubRole);
                _cmd.Parameters.AddWithValue("@UserID", txtStaffUseridUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@UserPassword", txtStaffUserPasswordUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_ComfirmPassword", txtStaffuserConfigPasswordUpda.Text.Trim());
                _cmd.Parameters.AddWithValue("@Squrity_Question", SecurityQuestion);
                _cmd.Parameters.AddWithValue("@UserSecretAns", Staff_SecurityAns);
                _cmd.Parameters.AddWithValue("Staff_ID", Staff_ID);
                int result = _cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    cn.Close();
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                    BindGridWithFilter();
                    //  lblerror1Upda.Text = "Update Successfully ..!";

                }

                //HttpContext.Current.Items.Add("COMPLETE", "UPDATE");
                //Server.Transfer("CompleteForm.aspx");

            }
            catch (Exception ex)
            {
                cn.Close();
                logger.Info(ex.Message);
            }


        }


        public byte[] HexsToArrayUpda(string sHexString)
        {
            byte[] ra = new byte[sHexString.Length / 2];
            for (Int32 i = 0; i <= sHexString.Length - 1; i += 2)
            {
                ra[i / 2] = byte.Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber);
            }
            return ra;
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void DropDownList2_SelectedIndexChangedUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList2.SelectedItem.Text.Trim() == "Malaysian")
                {
                    Panel3.Visible = true;
                }
                else
                {
                    Panel3.Visible = false;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void DropDownList3_SelectedIndexChangedUpda(object sender, EventArgs e)
        {

        }
        protected void DropDownList4_SelectedIndexChangedUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList4.SelectedItem.Text.Trim() == "Married")
                {
                    Panel4.Visible = true;
                }
                else
                {
                    Panel4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void DropDownList5_SelectedIndexChangedUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList5Upda.SelectedItem.Text.Trim() == "Yes")
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void DropDownList6_SelectedIndexChangedUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (DropDownList6Upda.SelectedItem.Text.Trim() == "Yes")
                {
                    Panel2Upda.Visible = true;
                }
                else
                {
                    Panel2Upda.Visible = false;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlStaffSecQues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        //Server.Transfer("PresentStaff.aspx");
        //        if (Session["path"].ToString() == "PresentStaff.aspx")
        //        {
        //            Response.Redirect("PresentStaff.aspx");
        //        }
        //        if (Session["path"].ToString() == "PastStaff.aspx")
        //        {
        //            Response.Redirect("PastStaff.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        protected void cmdbuttonadd_ClickUpda(object sender, EventArgs e)
        {

        }

        protected void cmdViewIssueItem_ClickUpda(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=1','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
        }

        protected void txtDOB_TextChangedUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string dob = string.Empty;
                int actualage = 0;
                if (txtDOBUpda.Text.Trim() != "")
                {
                    dob = txtDOBUpda.Text.Substring(6, 4);
                    int currdate = Convert.ToInt32(DateTime.Now.Year);
                    int youdob = Convert.ToInt32(dob);
                    if (currdate >= youdob)
                    {
                        actualage = currdate - youdob;
                        txtageUpda.Text = actualage.ToString();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnNRICWorkpermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string NRICWorkpermitPath = hypNRICWorkPermit.Text.ToString();
                string path = Server.MapPath(NRICWorkpermitPath);
                dal.executesql("Update Userinformation set Staff_NRICWorkPermitCertificate='' where Staff_ID = '" + ViewState["Staff_ID"].ToString() + "'");
                File.Delete(path);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void cmdbuttonSave1_Click(object sender, EventArgs e)
        {

        }
        protected void cmdbuttonSave2_Click(object sender, EventArgs e)
        {
            string UserID = ViewState["Staff_ID"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Staff_ID"].ToString() != "")
                {


                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_PrimarySchoolName=@Staff_PrimarySchoolName,Staff_PrimaryAddress=@Staff_PrimaryAddress,Staff_PrimaryLevel=@Staff_PrimaryLevel,Staff_PrimaryFrom=@Staff_PrimaryFrom,Staff_PrimaryTo=@Staff_PrimaryTo,Staff_PrimaryQualification=@Staff_PrimaryQualification,Staff_SecondarySchoolName=@Staff_SecondarySchoolName,Staff_SecondaryAddress=@Staff_SecondaryAddress,Staff_SecondaryLevel=@Staff_SecondaryLevel,Staff_SecondaryFrom=@Staff_SecondaryFrom,Staff_SecondaryTo=@Staff_SecondaryTo,Staff_SecondaryQualification=@Staff_SecondaryQualification,Staff_VocationSchoolName=@Staff_VocationSchoolName,Staff_VocationAddress=@Staff_VocationAddress,Staff_VocationLevel=@Staff_VocationLevel,Staff_VocationFrom=@Staff_VocationFrom,Staff_VocationTo=@Staff_VocationTo,Staff_VocationQualification=@Staff_VocationQualification,Staff_OtherSchoolName=@Staff_OtherSchoolName,Staff_OtherAddress=@Staff_OtherAddress,Staff_OtherLevel=@Staff_OtherLevel,Staff_OtherFrom=@Staff_OtherFrom,Staff_OtherTo=@Staff_OtherTo,Staff_OtherQualification=@Staff_OtherQualification,Staff_OtherTraining=@Staff_OtherTraining where Staff_ID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_PrimarySchoolName", txtEDnameofSchool1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryAddress", txtEDaddres1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryLevel", txtEDLeve1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryFrom", txtEDFrom1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryTo", txtEDTo1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryQualification", txtEDqualification1Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondarySchoolName", txtEDnameofSchool2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryAddress", txtEDaddres2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryLevel", txtEDLeve2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryFrom", txtEDFrom2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryTo", txtEDTo2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryQualification", txtEDqualification2Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationSchoolName", txtEDnameofSchool3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationAddress", txtEDaddres3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationLevel", txtEDLeve3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationFrom", txtEDFrom3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationTo", txtEDTo3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationQualification", txtEDqualification3Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherSchoolName", txtEDnameofSchool4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherAddress", txtEDaddres4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherLevel", txtEDLeve4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherFrom", txtEDFrom4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherTo", txtEDTo4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherQualification", txtEDqualification4Upda.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherTraining", txtotherSkillsUpda.Text);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                        MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                        BindGridWithFilter();
                        // lblerror1Upda.Text = "Update Successfully ...!";
                        cn.Close();
                    }
                }
                else
                {
                    //lblerror1.Visible = true;
                    //lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdbuttonSave3_ClickUpda(object sender, EventArgs e)
        {
            string UserID = ViewState["Staff_ID"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Staff_ID"].ToString() != "")
                {

                    //cmdbuttonNext3.Enabled = true;
                    //cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_NSFrom=@Staff_NSFrom,Staff_NSTo=@Staff_NSTo,Staff_NSTypeOfDischarge=@Staff_NSTypeOfDischarge,Staff_NSVocation=@Staff_NSVocation,Staff_NSNextInCamp=@Staff_NSNextInCamp,Staff_NSLastRank=@Staff_NSLastRank,Staff_NSExempted=@Staff_NSExempted,Staff_NSReason=@Staff_NSReason,Staff_NSDateOFRegistration=@Staff_NSDateOFRegistration  where Staff_ID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_NSFrom", txtNSTimeUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSTo", txtNSToUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSTypeOfDischarge", txtNSTypeofDischargeUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSVocation", txtNSVocationUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSNextInCamp", txtNSNextInCampUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSLastRank", txtNSLastRankUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSExempted", txtNSExemptedUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSReason", txtNSReasonUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSDateOFRegistration", txtNSPeriodUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                        MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                        BindGridWithFilter();
                        // lblerror1Upda.Text = "Update Successfully ...!";
                        cn.Close();
                    }
                }
                else
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill First Information ..!");
                    //lblerror1.Visible = true;
                    //lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }




        }

        protected void cmdbuttonSave4Upda_Click(object sender, EventArgs e)
        {
            string UserID = ViewState["Staff_ID"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Staff_ID"].ToString() != "")
                {
                    string Nricworkpermit = string.Empty;
                    string NSRSWSQModules = string.Empty;
                    string OtherRecognisedCertificate = string.Empty;

                    string ExemptionCertificate = string.Empty;
                    string SecurityOfficerLicense = string.Empty;
                    string SIRDScreen = string.Empty;
                    if (txtNricworkpermitUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtNricworkpermitUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe"))
                        {
                        }
                        else
                        {
                            Nricworkpermit = "~/FileUpload/" + f.FileName;
                        }


                    }
                    else
                    {
                        Nricworkpermit = hypNRICWorkPermit.Text;
                        //Nricworkpermit = lnkLabel1Upda.Text;
                    }
                    if (txtNSRSWQUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtNSRSWQUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe"))
                        {

                        }
                        else
                        {
                            NSRSWSQModules = "~/FileUpload/" + f.FileName;
                        }

                    }
                    else
                    {
                        //NSRSWSQModules = lnkLabel2Upda.Text;
                        NSRSWSQModules = hypNSRSWSQModule.Text;
                    }
                    if (txtotherRecognisedUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtotherRecognisedUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe"))
                        {
                        }
                        else
                        {
                            OtherRecognisedCertificate = "~/FileUpload/" + f.FileName;
                        }

                    }
                    else
                    {
                        //OtherRecognisedCertificate = lnkLabel3Upda.Text;
                        OtherRecognisedCertificate = hypOtherRecoQualify.Text;
                    }
                    if (txtExemptionCertificateUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtExemptionCertificateUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe")) { }
                        else { ExemptionCertificate = "~/FileUpload/" + f.FileName; }

                    }
                    else
                    {
                        //ExemptionCertificate = lnkLabel4Upda.Text;
                        ExemptionCertificate = hypExemptionCertificate.Text;
                    }
                    if (txtSecurityOfficerLicenseUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtSecurityOfficerLicenseUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe")) { }
                        else { SecurityOfficerLicense = "~/FileUpload/" + f.FileName; }

                    }
                    else
                    {
                        //SecurityOfficerLicense = lnkLabel5Upda.Text;
                        SecurityOfficerLicense = hypSecurityOfficerLicense.Text;
                    }
                    if (txtSIRDscreenUpda.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtSIRDscreenUpda.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        if (f.FileName.EndsWith(".exe")) { }
                        else { SIRDScreen = "~/FileUpload/" + f.FileName; }

                    }
                    else
                    {
                        //SIRDScreen = lnkLabel6Upda.Text;
                        SIRDScreen = hypSIRDScreen.Text;
                    }
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_EmpExCompName1=@Staff_EmpExCompName1,Staff_EmpExFrom1=@Staff_EmpExFrom1,Staff_EmpExTo1=@Staff_EmpExTo1,Staff_EmpExReasonLeaving1=@Staff_EmpExReasonLeaving1, Staff_EmpExLastDrawnSalary1=@Staff_EmpExLastDrawnSalary1, Staff_EmpExCompName2=@Staff_EmpExCompName2,Staff_EmpExFrom2=@Staff_EmpExFrom2,Staff_EmpExTo2=@Staff_EmpExTo2,Staff_EmpExReasonLeaving2=@Staff_EmpExReasonLeaving2,Staff_EmpExLastDrawnSalary2=@Staff_EmpExLastDrawnSalary2,Staff_EmpExCompName3=@Staff_EmpExCompName3,Staff_EmpExFrom3=@Staff_EmpExFrom3,Staff_EmpExTo3=@Staff_EmpExTo3,Staff_EmpExReasonLeaving3=@Staff_EmpExReasonLeaving3,Staff_EmpExLastDrawnSalary3=@Staff_EmpExLastDrawnSalary3,Staff_EmpExCompName4=@Staff_EmpExCompName4,Staff_EmpExFrom4=@Staff_EmpExFrom4,Staff_EmpExTo4=@Staff_EmpExTo4,Staff_EmpExReasonLeaving4=@Staff_EmpExReasonLeaving4,Staff_EmpExLastDrawnSalary4=@Staff_EmpExLastDrawnSalary4,Staff_ExpectedSalary=@Staff_ExpectedSalary,Staff_CommenceWork=@Staff_CommenceWork,Staff_LAW=@Staff_LAW,Staff_LAWResion=@Staff_LAWResion,Staff_Injury=@Staff_Injury,Staff_InjuryResion=@Staff_InjuryResion,Staff_NRICWorkPermitCertificate=@Staff_NRICWorkPermitCertificate,Staff_NSRSWSQModulesCertificate=@Staff_NSRSWSQModulesCertificate,Staff_OtherRecognisedCertificate=@Staff_OtherRecognisedCertificate,Staff_ExemptionCertificate=@Staff_ExemptionCertificate,Staff_SecurityOfficerLicenseCertificate=@Staff_SecurityOfficerLicenseCertificate,Staff_SIRDScreenCertificate=@Staff_SIRDScreenCertificate where Staff_ID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName1", txtEnameofCompany1Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom1", txtEFrom1Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo1", txtETo1Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving1", txtEReasonleave1Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary1", txtELastDraw1Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName2", txtEnameofCompany2Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom2", txtEFrom2Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo2", txtETo2Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving2", txtEReasonleave2Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary2", txtELastDraw2Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName3", txtEnameofCompany3Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom3", txtEFrom3Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo3", txtETo3Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving3", txtEReasonleave3Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary3", txtELastDraw3Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName4", txtEnameofCompany4Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom4", txtEFrom4Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo4", txtETo4Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving4", txtEReasonleave4Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary4", txtELastDraw4Upda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_ExpectedSalary", txtexpectedSalaryUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_CommenceWork", txtcommenceworkUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_LAW", DropDownList5Upda.SelectedItem.Value.Trim());
                    cmd.Parameters.AddWithValue("@Staff_LAWResion", txtLAWyesUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_Injury", DropDownList6Upda.SelectedItem.Value.Trim());
                    cmd.Parameters.AddWithValue("@Staff_InjuryResion", txtInjuryyesUpda.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NRICWorkPermitCertificate", Nricworkpermit);
                    cmd.Parameters.AddWithValue("@Staff_NSRSWSQModulesCertificate", NSRSWSQModules);
                    cmd.Parameters.AddWithValue("@Staff_OtherRecognisedCertificate", OtherRecognisedCertificate);
                    cmd.Parameters.AddWithValue("@Staff_ExemptionCertificate", ExemptionCertificate);
                    cmd.Parameters.AddWithValue("@Staff_SecurityOfficerLicenseCertificate", SecurityOfficerLicense);
                    cmd.Parameters.AddWithValue("@Staff_SIRDScreenCertificate", SIRDScreen);

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                        MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                        BindGridWithFilter();
                        //  lblerror1Upda.Text = "Update Successfully ...!";
                        cn.Close();

                    }
                }
                else
                {
                    lblerror1Upda.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill First Information ..!");
                    //lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }


        }

        protected void cmdbuttonSave5_ClickUpda(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();

            string path = "";
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                if (ViewState["Staff_ID"].ToString() != "")
                {

                    if (Session["CaptureImagePath"] == null)
                    {
                        if (FileUpload1Upda.UploadedFiles.Count > 0)
                        {
                            para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                            UploadedFile upp = null;
                            upp = FileUpload1Upda.UploadedFiles[0];
                            // string file = FileUpload1Upda.PostedFile.FileName;
                            upp.SaveAs(Server.MapPath(upp.FileName));
                            string thubpath = ("~/ADMIN" + "/" + upp.FileName);
                            // FileUpload1Upda.PostedFile.SaveAs(Server.MapPath(file));
                            para[0].Value = thubpath;
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                            cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1Upda.Visible = true;
                                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                // lblerror1Upda.Text = "Update Successfully ...!";
                                cn.Close();
                                // Response.Redirect("CompleteForm.aspx");
                            }
                        }
                        else
                        {
                            para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                            if (Session["CaptureImage"] == null)
                            {
                                para[0].Value = "~/ADMIN/" + String.Empty;
                            }
                            else
                            {
                                para[0].Value = "~/ADMIN/" + Session["CaptureImage"].ToString();
                            }
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                            cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1Upda.Visible = true;
                                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                //  lblerror1Upda.Text = "Update Successfully ...!";
                                cn.Close();
                                // Response.Redirect("CompleteForm.aspx");
                            }
                        }

                    }
                    else
                    {
                        if (Session["CaptureImage"] != null)
                        {
                            if (FileUpload1Upda.UploadedFiles.Count > 0)
                            {
                                para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                                UploadedFile uploadfile = null;
                                //string file = FileUpload1Upda.PostedFile.FileName;
                                uploadfile = FileUpload1Upda.UploadedFiles[0];
                                uploadfile.SaveAs(Server.MapPath(uploadfile.FileName));
                                // uploadfile.SaveAs("~/ADMIN" + "/" + uploadfile.FileName);
                                string thubpath = ("~/ADMIN" + "/" + uploadfile.FileName);
                                // FileUpload1Upda.PostedFile.SaveAs(Server.MapPath(file));
                                //para[0].Value = "~/ADMIN/" + Session["CaptureImage"].ToString();
                                para[0].Value = thubpath;
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                                cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    lblerror1Upda.Visible = true;
                                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                    MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                    //   lblerror1Upda.Text = "Update Successfully ...!";
                                    cn.Close();
                                    // Response.Redirect("CompleteForm.aspx");
                                }
                            }
                            else
                            {
                                para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                                para[0].Value = "~/ADMIN/" + Session["CaptureImage"].ToString();
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                                //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    // lblerror1.Visible = true;
                                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                    MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                    BindGridWithFilter();
                                    // lblerror1.Text = "Update Successfully ...!";
                                    cn.Close();
                                    //Response.Redirect("CompleteForm.aspx");
                                }
                            }

                            //Session["CaptureImage"] = null;
                        }
                        else
                        {
                            if (FileUpload1Upda.UploadedFiles.Count > 0)
                            {
                                para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                                UploadedFile uupp = null;
                                //   string file = FileUpload1Upda.PostedFile.FileName;
                                uupp = FileUpload1Upda.UploadedFiles[0];
                                uupp.SaveAs(Server.MapPath(uupp.FileName));
                                // uupp.SaveAs("~/ADMIN" + "/" + uupp.FileName);
                                string thubpath = ("~/ADMIN" + "/" + uupp.FileName);
                                // FileUpload1Upda.PostedFile.SaveAs(Server.MapPath(file));
                                para[0].Value = thubpath;
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                                //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    lblerror1Upda.Visible = true;
                                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                    MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                    BindGridWithFilter();
                                    // lblerror1Upda.Text = "Update Successfully ...!";
                                    cn.Close();
                                    //Response.Redirect("CompleteForm.aspx");
                                }
                                //Could not find a part of the path 'D:\D-sys\dsys prjct\
                                // PedroSecure\tspsecure\SMSDevelopment\SMSDevelopment\SMS\SMS\ADMIN\ADMIN\shakil (2).jpg'

                            }

                        }
                    }
                    if (Session["ThumbPath"] != null)
                    {
                        if (hdnFPUpda.Value.Length > 15)
                        {
                            para[1] = new SqlParameter("@ThumbPrint", SqlDbType.VarBinary);
                            para[1].Value = HexsToArray(hdnFPUpda.Value);
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ThumbImage=@ThumbImage where Staff_ID=@UserID", cn);
                            //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@ThumbImage", para[1].Value);
                            cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1Upda.Visible = true;
                                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                                BindGridWithFilter();
                                //lblerror1Upda.Text = "Update Successfully ...!";
                                cn.Close();
                                // Response.Redirect("CompleteForm.aspx");
                            }
                        }
                        else
                        {
                            para[1] = new SqlParameter("@ThumbPrint", SqlDbType.VarBinary);
                            para[1].Value = HexsToArray(hdnFPUpda.Value);
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ThumbImage=@ThumbImage where Staff_ID=@UserID", cn);
                            //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@ThumbImage", para[1].Value);
                            cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                            //if (cmd.ExecuteNonQuery() > 0)
                            //{
                            //    lblerror1.Visible = true;
                            //    lblerror1.Text = "Update Successfully ...!";
                            //    cn.Close();
                            //    Response.Redirect("CompleteForm.aspx");
                            //}
                            lblerror1Upda.Visible = true;
                            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                            MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                            // lblerror1Upda.Text = "Update successfully.!";
                            //Response.Redirect("CompleteForm.aspx");
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                        cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                        cmd.Parameters.AddWithValue("@UserID", ViewState["Staff_ID"].ToString());
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            lblerror1Upda.Visible = true;
                            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                            MyMasterPage.ShowErrorMessage("Update Successfully ..!");
                            BindGridWithFilter();
                            //  lblerror1Upda.Text = "Update Successfully ...!";
                            cn.Close();
                            //Response.Redirect("CompleteForm.aspx");
                        }
                    }
                }
                //  Response.Redirect("CompleteForm.aspx", false);
                pnlpopupEdit.Visible = false;
            }
            catch (Exception ex)
            {
                cn.Close();
                logger.Info(ex.Message);
            }
        }



        protected void imgDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["Staff_ID"] != null)
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtPresentStaff = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "60");

                if (dtPresentStaff.Rows.Count > 0)
                {
                    ModalPopupDelete.Show();
                    pnlAdd.Visible = false;
                    pnlpopupEdit.Visible = false;
                }
                else
                {


                    MyMasterPage.ShowErrorMessage("You Donot Have Permission..!");
                }
            }

        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            if (ViewState["Staff_ID"] != null)
            {
                DeleteItem(ViewState["Staff_ID"].ToString());
            }
        }
        //private void DeleteItem()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        if (ViewState["Staff_ID"].ToString() != "")
        //        {
        //            string argStaffid = ViewState["Staff_ID"].ToString();
        //            if (!string.IsNullOrEmpty(argStaffid))
        //            {
        //                AdminBLL ws = new AdminBLL();
        //                DeleteUserRequest _req = new DeleteUserRequest();
        //                _req.UserNo = argStaffid.ToString();
        //                ws.DeleteUserStaff(_req);
        //                dal.executesql("Delete from UserInformation where Staff_ID = '" + argStaffid + "' ");
        //                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
        //                // Server.Transfer("CompleteForm.aspx");
        //                ModalPopupDelete.Hide();
        //                BindGridWithFilter();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        private void DeleteItem(string argStaffid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argStaffid))
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    AdminBLL ws = new AdminBLL();
                    DeleteUserRequest _req = new DeleteUserRequest();
                    _req.UserNo = argStaffid.ToString();
                    ws.DeleteUserStaff(_req);
                    dal.executesql("Delete from StaffLocationMap where StaffID = '" + argStaffid + "' ");
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    ModalPopupDelete.Hide();
                    BindGridWithFilter();
                    MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            ModalPopupDelete.Hide();
            BindGridWithFilter();
        }




        #endregion Update Staff
        #region Add Staff
        #region Personal Detail
        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;

            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvLoctionTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvLoctionTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvLoctionTable.Items[ro].Selected = true;


                        ViewState["Staff_ID"] = item.OwnerTableView.DataKeyValues[ro]["Staff_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }

            }




        }
        private void fillSecurityqust()
        {
            string ID = "securityquestion";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dt1.Rows.Count > 0)
            {
                ddlStaffSecQues.DataSource = dt1;
                ddlStaffSecQues.DataTextField = "Description";
                // ddlStaffSecQues.DataValueField = "Pass_id";
                ddlStaffSecQues.DataBind();
                ddlStaffSecQues.Items.Insert(0, new ListItem(" ", " ", true));

                //for (int p = 0; p < dt1.Rows.Count; p++)
                //{
                //    ddlStaffSecQues.Items.Add(dt1.Rows[p][0].ToString());
                //}
            }
        }
        private void fillrole()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add(" ");
            //string rol = Session["role"].ToString();
            string rol = Session["user_role"].ToString();//change by rakesh
            int subrole = 0;

            if ("Superuser" == rol)
            {
                //DataSet dsgrole = dal.getdataset("Select RoleName from RoleMaster order by RoleName Asc");
                DataSet dsgrole = dal.getdataset("Select UserRole from UserRoleMaster order by UserRole Asc");//change by rakesh

                if (dsgrole.Tables[0].Rows.Count > 0)
                {
                    for (int h = 0; h < dsgrole.Tables[0].Rows.Count; h++)
                    {
                        ddlRole.Items.Add(dsgrole.Tables[0].Rows[h][0].ToString());
                    }
                }
            }
            else
            {
                //DataSet subroleid = dal.getdataset("Select submenuid from Submenu where SubRole='" + rol + "'");
                DataSet subroleid = dal.getdataset("Select id from UserRoleMaster where UserRole='" + rol + "'");//change by rakesh
                if (subroleid.Tables[0].Rows.Count > 0)
                {
                    subrole = Convert.ToInt32(subroleid.Tables[0].Rows[0][0].ToString());
                }
                //DataSet dsgrole = dal.getdataset("Select SubRole from Submenu Where submenuid > "+subrole+" ");
                DataSet dsgrole = dal.getdataset("Select UserRole from UserRoleMaster Where id> " + subrole + " ");//change by rakesh
                if (dsgrole.Tables[0].Rows.Count > 0)
                {
                    for (int h = 0; h < dsgrole.Tables[0].Rows.Count; h++)
                    {
                        ddlRole.Items.Add(dsgrole.Tables[0].Rows[h][0].ToString());
                    }
                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList2.SelectedItem.Text.Trim() == "Malaysian")
                {
                    Panel3.Visible = true;
                }
                else
                {
                    Panel3.Visible = false;
                }
                if (DropDownList2.SelectedItem.Text.Trim() == "Other")
                {
                    txtothercitizen.Visible = true;
                }
                else
                {
                    txtothercitizen.Visible = false;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList4.SelectedItem.Text.Trim() == "Married")
                {
                    Panel4.Visible = true;
                }
                else
                {
                    Panel4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string dob = string.Empty;
                int actualage = 0;
                if (txtDOB.Text.Trim() != "")
                {
                    dob = txtDOB.Text.Substring(6, 4);
                    int currdate = Convert.ToInt32(DateTime.Now.Year);
                    int youdob = Convert.ToInt32(dob);
                    if (currdate >= youdob)
                    {
                        actualage = currdate - youdob;
                        txtage.Text = actualage.ToString();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {

        }

        protected void cmdbuttonSave_Click1(object sender, EventArgs e)
        {



            //protected void Button1_Click(object sender, EventArgs e)

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string Staff_ID = string.Empty;

                SqlDataReader rd = dal.getDataReader("SELECT part from SplitString(convert(varchar(100),newid()),'-')where id = (select max(id) from SplitString(convert(varchar(100),newid()),'-'))");
                if (rd.Read())
                {
                    Staff_ID = rd.GetValue(0).ToString().Trim();
                }

                rd.Dispose();

                if (txtFname.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errFname.Visible = true;
                    //lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill First Name ..!");
                    // lblerror1.Text = "Please Fill First Name...!";
                    throw new Exception();
                }
                if (txtnric.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errnri.Visible = true;
                    // lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill NRIC NO..!");
                    //  lblerror1.Text = "Please Fill NRIC No...!";
                    throw new Exception();
                }
                if (txtMobNo.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errnri.Visible = true;
                    // lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill Mob No ..!");
                    // lblerror1.Text = "Please Fill Mob No...!";
                    throw new Exception();
                }
                if (txtnric.Text.Trim() != "")
                {
                    DataTable dtverifyUserid = dal.getdata("Select UserID from UserInformation where NRICno='" + txtnric.Text.Trim() + "' ");
                    if (dtverifyUserid.Rows.Count > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                        //  lblerror1.Visible = true;
                        MyMasterPage.ShowErrorMessage("NRIC No Already Exists..!");
                        //lblerror1.Text = "NRINo Already Exists..!";
                        throw new Exception();
                    }
                }
                if (txtStaffUserid.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errUserid.Visible = true;
                    // lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill User ID ..!");
                    // lblerror1.Text = "Please Fill User ID...!";

                    throw new Exception();
                }
                if (txtStaffUserPassword.Text.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errUserPassword.Visible = true;
                    //lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill User Password ..!");
                    //lblerror1.Text = "Please Fill User Password...!";
                    throw new Exception();
                }
                if (txtStaffuserConfigPassword.Text.Trim() != txtStaffUserPassword.Text.Trim())
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    //  lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Re-Confirm Password..!");
                    // lblerror1.Text = "Re-Confirm Password..!";
                    throw new Exception();
                }
                if (ddlRole.SelectedValue.Trim() == "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    errddlRole.Visible = true;
                    // lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill User SubRole ..!");
                    //lblerror1.Text = "Please Fill User SubRole...!";
                    throw new Exception();
                }
                if (txtStaffUserid.Text.Trim() != "")
                {
                    DataTable dtverifyUserid = dal.getdata("Select NRICno from UserInformation where UserID='" + txtStaffUserid.Text.Trim() + "' ");
                    if (dtverifyUserid.Rows.Count > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                        //  lblerror1.Visible = true;
                        MyMasterPage.ShowErrorMessage("UserID Already Exists..!");
                        throw new Exception();
                    }
                }



                string Staff_PreName = DropDownList1.SelectedItem.Value.Trim();
                string Staff_FName = txtFname.Text.Trim();
                string Staff_MName = txtMname.Text.Trim();
                string Staff_LName = txtLname.Text.Trim();
                string Staff_Address = txtHomeAdress.Text.Trim();
                string Staff_Telphone = txtPhone.Text.Trim();
                string Staff_HPno = txtHP.Text.Trim();

                string Staff_DOB = txtDOB.Text.Trim();

                string Staff_POB = txtPOB.Text.Trim();
                string Staff_Race = txtrace.Text.Trim();
                string Staff_NRICno = txtnric.Text.Trim();

                // string newcitizenship = DropDownList2.SelectedItem.Value.Trim();
                string Staff_Citizenship = string.Empty;
                if (txtothercitizen.Text != "")
                {
                    Staff_Citizenship = txtothercitizen.Text.Trim();
                }
                else
                {
                    Staff_Citizenship = DropDownList2.SelectedItem.Value.Trim();
                }

                string Staff_Mobile = txtMobNo.Text.Trim();
                string Staff_Age = txtage.Text.Trim();
                string Staff_Religion = txtreligion.Text.Trim();
                string Staff_Sex = DropDownList3.SelectedItem.Value.Trim();
                string Staff_DriverLicense = txtDlicense.Text.Trim();

                string Staff_IncomeTax = txtincometax.Text.Trim();
                string Staff_MaritalStatus = DropDownList4.SelectedItem.Value.Trim();
                string Staff_NoOfChile = txtnoOfChildern.Text.Trim();
                string Staff_MarriedSpousName = txtSpousename.Text.Trim();
                string Staff_EmergencyName = txtEmergencyName.Text.Trim();
                string Staff_EmergencyAdd = txtEmergenAddress.Text.Trim();
                string Staff_EmergencyTelphone = txtEmergencContNo.Text.Trim();

                string Staff_PrimarySchoolName = txtEDnameofSchool1.Text.Trim();
                string Staff_PrimaryAddress = txtEDaddres1.Text.Trim();
                string Staff_PrimaryLevel = txtEDLeve1.Text.Trim();
                string Staff_PrimaryFrom = txtEDFrom1.Text.Trim();
                string Staff_PrimaryTo = txtEDTo1.Text.Trim();
                string Staff_PrimaryQualification = txtEDqualification1.Text.Trim();

                string Staff_SecondarySchoolName = txtEDnameofSchool2.Text.Trim();
                string Staff_SecondaryAddress = txtEDaddres2.Text.Trim();
                string Staff_SecondaryLevel = txtEDLeve2.Text.Trim();
                string Staff_SecondaryFrom = txtEDFrom2.Text.Trim();
                string Staff_SecondaryTo = txtEDTo2.Text.Trim();
                string Staff_SecondaryQualification = txtEDqualification2.Text.Trim();

                string Staff_VocationSchoolName = txtEDnameofSchool3.Text.Trim();
                string Staff_VocationAddress = txtEDaddres3.Text.Trim();
                string Staff_VocationLevel = txtEDLeve3.Text.Trim();
                string Staff_VocationFrom = txtEDFrom3.Text.Trim();
                string Staff_VocationTo = txtEDTo3.Text.Trim();
                string Staff_VocationQualification = txtEDqualification3.Text.Trim();

                string Staff_OtherSchoolName = txtEDnameofSchool4.Text.Trim();
                string Staff_OtherAddress = txtEDaddres4.Text.Trim();
                string Staff_OtherLevel = txtEDLeve4.Text.Trim();
                string Staff_OtherFrom = txtEDFrom4.Text.Trim();
                string Staff_OtherTo = txtEDTo4.Text.Trim();
                string Staff_OtherQualification = txtEDqualification4.Text.Trim();

                string Staff_OtherTraining = txtotherSkills.Text.Trim();
                string Staff_Hobbies = txthobbies.Text.Trim();

                string Staff_NSFrom = txtNSTime.Text.Trim();
                string Staff_NSTo = txtNSTo.Text.Trim();
                string Staff_NSTypeOfDischarge = txtNSTypeofDischarge.Text.Trim();
                string Staff_NSVocation = txtNSVocation.Text.Trim();
                string Staff_NSNextInCamp = txtNSNextInCamp.Text.Trim();
                string Staff_NSLastRank = txtNSLastRank.Text.Trim();

                string Staff_NSExempted = txtNSExempted.Text.Trim();
                string Staff_NSReason = txtNSReason.Text.Trim();
                string Staff_NSDateOFRegistration = txtNSPeriod.Text.Trim();

                string Staff_EmpExCompName1 = txtEnameofCompany1.Text.Trim();
                string Staff_EmpExFrom1 = txtEFrom1.Text.Trim();
                string Staff_EmpExTo1 = txtETo1.Text.Trim();
                string Staff_EmpExReasonLeaving1 = txtEReasonleave1.Text.Trim();
                string Staff_EmpExLastDrawnSalary1 = txtELastDraw1.Text.Trim();

                string Staff_EmpExCompName2 = txtEnameofCompany2.Text.Trim();
                string Staff_EmpExFrom2 = txtEFrom2.Text.Trim();
                string Staff_EmpExTo2 = txtETo2.Text.Trim();
                string Staff_EmpExReasonLeaving2 = txtEReasonleave2.Text.Trim();
                string Staff_EmpExLastDrawnSalary2 = txtELastDraw2.Text.Trim();

                string Staff_EmpExCompName3 = txtEnameofCompany3.Text.Trim();
                string Staff_EmpExFrom3 = txtEFrom3.Text.Trim();
                string Staff_EmpExTo3 = txtETo3.Text.Trim();
                string Staff_EmpExReasonLeaving3 = txtEReasonleave3.Text.Trim();
                string Staff_EmpExLastDrawnSalary3 = txtELastDraw3.Text.Trim();

                string Staff_EmpExCompName4 = txtEnameofCompany4.Text.Trim();
                string Staff_EmpExFrom4 = txtEFrom4.Text.Trim();
                string Staff_EmpExTo4 = txtETo4.Text.Trim();
                string Staff_EmpExReasonLeaving4 = txtEReasonleave4.Text.Trim();
                string Staff_EmpExLastDrawnSalary4 = txtELastDraw4.Text.Trim();


                string Staff_ExpectedSalary = txtexpectedSalary.Text.Trim();
                string Staff_CommenceWork = txtcommencework.Text.Trim();

                string Staff_LAW = DropDownList5.SelectedItem.Value.Trim();
                string Staff_LAWResion = txtLAWyes.Text.Trim();
                string Staff_Injury = DropDownList6.SelectedItem.Value.Trim();
                string Staff_InjuryResion = txtInjuryyes.Text.Trim();


                string Staff_UserID = txtStaffUserid.Text.Trim();
                Session["Local_User_Id"] = txtStaffUserid.Text.Trim();
                //string var = Session["Local_User_Id"].ToString();
                string Staff_UserPassword = txtStaffUserPassword.Text.Trim();
                ViewState["password"] = Staff_UserPassword;
                string Staff_ComfirmPassword = txtStaffuserConfigPassword.Text.Trim();

                string Staff_SubRole = ddlRole.SelectedItem.Value.Trim();
                string Staff_SecurityAns = txtStaffSeurityqty.Text.Trim();

                string Nricworkpermit = string.Empty;
                string NSRSWSQModules = string.Empty;
                string OtherRecognisedCertificate = string.Empty;

                string ExemptionCertificate = string.Empty;
                string SecurityOfficerLicense = string.Empty;
                string SIRDScreen = string.Empty;

                string MalasianWorkPermitExpire = string.Empty;
                string MalasianPassportExpire = string.Empty;
                string MalasianIC = string.Empty;
                string MalasianOLDIC = string.Empty;
                string MalasianPassportNo = string.Empty;
                string MalasianWorkPermit = string.Empty;
                string MalasianEducationLevel = string.Empty;

                string SecurityQus = ddlStaffSecQues.Text.Trim();


                if (txtNricworkpermit.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtNricworkpermit.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    Nricworkpermit = "~/FileUpload/" + f.FileName;

                }
                if (txtNSRSWQ.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtNSRSWQ.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    NSRSWSQModules = "~/FileUpload/" + f.FileName;
                }
                if (txtotherRecognised.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtotherRecognised.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    OtherRecognisedCertificate = "~/FileUpload/" + f.FileName;
                }
                if (txtExemptionCertificate.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtExemptionCertificate.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    ExemptionCertificate = "~/FileUpload/" + f.FileName;
                }
                if (txtSecurityOfficerLicense.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtSecurityOfficerLicense.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    SecurityOfficerLicense = "~/FileUpload/" + f.FileName;
                }
                if (txtSIRDscreen.UploadedFiles.Count > 0)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    UploadedFile f = null;
                    f = txtSIRDscreen.UploadedFiles[0];
                    f.SaveAs(path + f.FileName);
                    SIRDScreen = "~/FileUpload/" + f.FileName;
                }


                string Staff_Status = "Present";

                //SqlParameter[] para = new SqlParameter[106];
                SqlParameter[] para = new SqlParameter[107];
                //= new SqlParameter[106];

                para[0] = new SqlParameter("@Staff_PreName", SqlDbType.VarChar, 300);
                para[0].Value = Staff_PreName;

                para[1] = new SqlParameter("@FName", SqlDbType.VarChar, 300);
                para[1].Value = Staff_FName;

                para[2] = new SqlParameter("@Staff_Address", SqlDbType.VarChar, 300);
                para[2].Value = Staff_Address;

                para[3] = new SqlParameter("@Staff_Telphone", SqlDbType.VarChar, 300);
                para[3].Value = Staff_Telphone;

                para[4] = new SqlParameter("@Staff_HPno", SqlDbType.VarChar, 300);
                para[4].Value = Staff_HPno;

                para[5] = new SqlParameter("@Staff_DOB", SqlDbType.VarChar, 300);
                para[5].Value = Staff_DOB;

                para[6] = new SqlParameter("@Staff_POB", SqlDbType.VarChar, 300);
                para[6].Value = Staff_POB;

                para[7] = new SqlParameter("@Staff_Race", SqlDbType.VarChar, 300);
                para[7].Value = Staff_Race;

                para[8] = new SqlParameter("@Staff_NRICno", SqlDbType.VarChar, 300);
                para[8].Value = Staff_NRICno;

                para[9] = new SqlParameter("@Staff_Citizenship", SqlDbType.VarChar, 300);
                para[9].Value = Staff_Citizenship;

                para[10] = new SqlParameter("@Staff_Age", SqlDbType.VarChar, 300);
                para[10].Value = Staff_Age;

                para[11] = new SqlParameter("@Staff_Religion", SqlDbType.VarChar, 300);
                para[11].Value = Staff_Religion;

                para[12] = new SqlParameter("@Staff_Sex", SqlDbType.VarChar, 300);
                para[12].Value = Staff_Sex;

                para[13] = new SqlParameter("@Staff_DriverLicense", SqlDbType.VarChar, 300);
                para[13].Value = Staff_DriverLicense;

                para[14] = new SqlParameter("@Staff_IncomeTax", SqlDbType.VarChar, 300);
                para[14].Value = Staff_IncomeTax;

                para[15] = new SqlParameter("@Staff_MaritalStatus", SqlDbType.VarChar, 300);
                para[15].Value = Staff_MaritalStatus;

                para[16] = new SqlParameter("@Staff_NoOfChile", SqlDbType.VarChar, 300);
                para[16].Value = Staff_NoOfChile;

                para[17] = new SqlParameter("@Staff_MarriedSpousName", SqlDbType.VarChar, 300);
                para[17].Value = Staff_MarriedSpousName;

                para[18] = new SqlParameter("@Staff_EmergencyName", SqlDbType.VarChar, 300);
                para[18].Value = Staff_EmergencyName;

                para[19] = new SqlParameter("@Staff_EmergencyAdd", SqlDbType.VarChar, 300);
                para[19].Value = Staff_EmergencyAdd;

                para[20] = new SqlParameter("@Staff_EmergencyTelphone", SqlDbType.VarChar, 300);
                para[20].Value = Staff_EmergencyTelphone;

                para[21] = new SqlParameter("@Staff_PrimarySchoolName", SqlDbType.VarChar, 300);
                para[21].Value = Staff_PrimarySchoolName;

                para[22] = new SqlParameter("@Staff_PrimaryAddress", SqlDbType.VarChar, 300);
                para[22].Value = Staff_PrimaryAddress;

                para[23] = new SqlParameter("@Staff_PrimaryLevel", SqlDbType.VarChar, 300);
                para[23].Value = Staff_PrimaryLevel;

                para[24] = new SqlParameter("@Staff_PrimaryFrom", SqlDbType.VarChar, 300);
                para[24].Value = Staff_PrimaryFrom;

                para[25] = new SqlParameter("@Staff_PrimaryTo", SqlDbType.VarChar, 300);
                para[25].Value = Staff_PrimaryTo;

                para[26] = new SqlParameter("@Staff_PrimaryQualification", SqlDbType.VarChar, 300);
                para[26].Value = Staff_PrimaryQualification;

                para[27] = new SqlParameter("@Staff_SecondarySchoolName", SqlDbType.VarChar, 300);
                para[27].Value = Staff_SecondarySchoolName;

                para[28] = new SqlParameter("@Staff_SecondaryAddress", SqlDbType.VarChar, 300);
                para[28].Value = Staff_SecondaryAddress;

                para[29] = new SqlParameter("@Staff_SecondaryLevel", SqlDbType.VarChar, 300);
                para[29].Value = Staff_SecondaryLevel;

                para[30] = new SqlParameter("@Staff_SecondaryFrom", SqlDbType.VarChar, 300);
                para[30].Value = Staff_SecondaryFrom;

                para[31] = new SqlParameter("@Staff_SecondaryTo", SqlDbType.VarChar, 300);
                para[31].Value = Staff_SecondaryTo;

                para[32] = new SqlParameter("@Staff_SecondaryQualification", SqlDbType.VarChar, 300);
                para[32].Value = Staff_SecondaryQualification;

                para[33] = new SqlParameter("@Staff_VocationSchoolName", SqlDbType.VarChar, 300);
                para[33].Value = Staff_VocationSchoolName;

                para[34] = new SqlParameter("@Staff_VocationAddress", SqlDbType.VarChar, 300);
                para[34].Value = Staff_VocationAddress;

                para[35] = new SqlParameter("@Staff_VocationLevel", SqlDbType.VarChar, 300);
                para[35].Value = Staff_VocationLevel;

                para[36] = new SqlParameter("@Staff_VocationFrom", SqlDbType.VarChar, 300);
                para[36].Value = Staff_VocationFrom;

                para[37] = new SqlParameter("@Staff_VocationTo", SqlDbType.VarChar, 300);
                para[37].Value = Staff_VocationTo;

                para[38] = new SqlParameter("@Staff_VocationQualification", SqlDbType.VarChar, 300);
                para[38].Value = Staff_VocationQualification;

                para[39] = new SqlParameter("@Staff_OtherSchoolName", SqlDbType.VarChar, 300);
                para[39].Value = Staff_OtherSchoolName;

                para[40] = new SqlParameter("@Staff_OtherAddress", SqlDbType.VarChar, 300);
                para[40].Value = Staff_OtherAddress;

                para[41] = new SqlParameter("@Staff_OtherLevel", SqlDbType.VarChar, 300);
                para[41].Value = Staff_OtherLevel;

                para[42] = new SqlParameter("@Staff_OtherFrom", SqlDbType.VarChar, 300);
                para[42].Value = Staff_OtherFrom;

                para[43] = new SqlParameter("@Staff_OtherTo", SqlDbType.VarChar, 300);
                para[43].Value = Staff_OtherTo;

                para[44] = new SqlParameter("@Staff_OtherQualification", SqlDbType.VarChar, 300);
                para[44].Value = Staff_OtherQualification;

                para[45] = new SqlParameter("@Staff_OtherTraining", SqlDbType.VarChar, 300);
                para[45].Value = Staff_OtherTraining;

                para[46] = new SqlParameter("@Staff_Hobbies", SqlDbType.VarChar, 300);
                para[46].Value = Staff_Hobbies;

                para[47] = new SqlParameter("@Staff_NSFrom", SqlDbType.VarChar, 300);
                para[47].Value = Staff_NSFrom;
                para[48] = new SqlParameter("@Staff_NSTo", SqlDbType.VarChar, 300);
                para[48].Value = Staff_NSTo;
                para[49] = new SqlParameter("@Staff_NSTypeOfDischarge", SqlDbType.VarChar, 300);
                para[49].Value = Staff_NSTypeOfDischarge;
                para[50] = new SqlParameter("@Staff_NSVocation", SqlDbType.VarChar, 300);
                para[50].Value = Staff_NSVocation;
                para[51] = new SqlParameter("@Staff_NSNextInCamp", SqlDbType.VarChar, 300);
                para[51].Value = Staff_NSNextInCamp;
                para[52] = new SqlParameter("@Staff_NSLastRank", SqlDbType.VarChar, 300);
                para[52].Value = Staff_NSLastRank;
                para[53] = new SqlParameter("@Staff_NSExempted", SqlDbType.VarChar, 300);
                para[53].Value = Staff_NSExempted;
                para[54] = new SqlParameter("@Staff_NSReason", SqlDbType.VarChar, 300);
                para[54].Value = Staff_NSReason;
                para[55] = new SqlParameter("@Staff_NSDateOFRegistration", SqlDbType.VarChar, 300);
                para[55].Value = Staff_NSDateOFRegistration;
                para[56] = new SqlParameter("@Staff_EmpExCompName1", SqlDbType.VarChar, 300);
                para[56].Value = Staff_EmpExCompName1;
                para[57] = new SqlParameter("@Staff_EmpExFrom1", SqlDbType.VarChar, 300);
                para[57].Value = Staff_EmpExFrom1;
                para[58] = new SqlParameter("@Staff_EmpExTo1", SqlDbType.VarChar, 300);
                para[58].Value = Staff_EmpExTo1;
                para[59] = new SqlParameter("@Staff_EmpExReasonLeaving1", SqlDbType.VarChar, 300);
                para[59].Value = Staff_EmpExReasonLeaving1;
                para[60] = new SqlParameter("@Staff_EmpExLastDrawnSalary1", SqlDbType.VarChar, 300);
                para[60].Value = Staff_EmpExLastDrawnSalary1;

                para[61] = new SqlParameter("@Staff_EmpExCompName2", SqlDbType.VarChar, 300);
                para[61].Value = Staff_EmpExCompName2;

                para[62] = new SqlParameter("@Staff_EmpExFrom2", SqlDbType.VarChar, 300);
                para[62].Value = Staff_EmpExFrom2;

                para[63] = new SqlParameter("@Staff_EmpExTo2", SqlDbType.VarChar, 300);
                para[63].Value = Staff_EmpExTo2;
                para[64] = new SqlParameter("@Staff_EmpExReasonLeaving2", SqlDbType.VarChar, 300);

                para[64].Value = Staff_EmpExReasonLeaving2;
                para[65] = new SqlParameter("@Staff_EmpExLastDrawnSalary2", SqlDbType.VarChar, 300);

                para[65].Value = Staff_EmpExLastDrawnSalary2;

                para[66] = new SqlParameter("@Staff_EmpExCompName3", SqlDbType.VarChar, 300);
                para[67] = new SqlParameter("@Staff_EmpExFrom3", SqlDbType.VarChar, 300);
                para[68] = new SqlParameter("@Staff_EmpExTo3", SqlDbType.VarChar, 300);
                para[69] = new SqlParameter("@Staff_EmpExReasonLeaving3", SqlDbType.VarChar, 300);
                para[70] = new SqlParameter("@Staff_EmpExLastDrawnSalary3", SqlDbType.VarChar, 300);
                para[66].Value = Staff_EmpExCompName3;
                para[67].Value = Staff_EmpExFrom3;
                para[68].Value = Staff_EmpExTo3;
                para[69].Value = Staff_EmpExReasonLeaving3;
                para[70].Value = Staff_EmpExLastDrawnSalary3;

                para[71] = new SqlParameter("@Staff_EmpExCompName4", SqlDbType.VarChar, 300);
                para[72] = new SqlParameter("@Staff_EmpExFrom4", SqlDbType.VarChar, 300);
                para[73] = new SqlParameter("@Staff_EmpExTo4", SqlDbType.VarChar, 300);
                para[74] = new SqlParameter("@Staff_EmpExReasonLeaving4", SqlDbType.VarChar, 300);
                para[75] = new SqlParameter("@Staff_EmpExLastDrawnSalary4", SqlDbType.VarChar, 300);

                para[71].Value = Staff_EmpExCompName4;
                para[72].Value = Staff_EmpExFrom4;
                para[73].Value = Staff_EmpExTo4;
                para[74].Value = Staff_EmpExReasonLeaving4;
                para[75].Value = Staff_EmpExLastDrawnSalary4;

                para[76] = new SqlParameter("@Staff_ExpectedSalary", SqlDbType.VarChar, 300);
                para[76].Value = Staff_ExpectedSalary;
                para[77] = new SqlParameter("@Staff_CommenceWork", SqlDbType.VarChar, 300);
                para[77].Value = Staff_CommenceWork;
                para[78] = new SqlParameter("@Staff_LAW", SqlDbType.VarChar, 300);
                para[78].Value = Staff_LAW;
                para[79] = new SqlParameter("@Staff_LAWResion", SqlDbType.VarChar, 300);
                para[79].Value = Staff_LAWResion;
                para[80] = new SqlParameter("@Staff_Injury", SqlDbType.VarChar, 300);
                para[80].Value = Staff_Injury;
                para[81] = new SqlParameter("@Staff_InjuryResion", SqlDbType.VarChar, 300);
                para[81].Value = Staff_InjuryResion;
                para[82] = new SqlParameter("@Staff_UserID", SqlDbType.VarChar, 300);
                para[82].Value = Staff_UserID;
                para[83] = new SqlParameter("@Staff_UserPassword", SqlDbType.VarChar, 300);
                para[83].Value = Staff_UserPassword;
                para[84] = new SqlParameter("@Staff_ComfirmPassword", SqlDbType.VarChar, 300);
                para[84].Value = Staff_ComfirmPassword;
                para[85] = new SqlParameter("@Staff_SubRole", SqlDbType.VarChar, 300);
                para[85].Value = Staff_SubRole;
                para[86] = new SqlParameter("@Staff_SecurityAns", SqlDbType.VarChar, 300);
                para[86].Value = Staff_SecurityAns;
                para[87] = new SqlParameter("@Staff_Status", SqlDbType.VarChar, 300);
                para[87].Value = Staff_Status;

                //para[88] = new SqlParameter("@ThumbPrint", SqlDbType.VarBinary);
                //para[88].Value = HexsToArray(hdnFP.Value);
                //para[88].Value = "";
                para[88] = new SqlParameter("@MName", SqlDbType.VarChar, 300);
                para[88].Value = Staff_MName;

                para[89] = new SqlParameter("@LName", SqlDbType.VarChar, 300);
                para[89].Value = Staff_LName;

                //para[91] = new SqlParameter("@UserImage", SqlDbType.VarChar, 500);
                //if (Session["CaptureImage"] != null)
                //{
                //    para[91].Value = "~/admin/" + Session["CaptureImage"].ToString();
                //    Session["CaptureImage"] = null;
                //}
                //else
                //{
                //para[91].Value = "";
                //}

                para[90] = new SqlParameter("@Staff_NRICWorkPermitCertificate", SqlDbType.VarChar, 300);
                para[90].Value = Nricworkpermit;

                para[91] = new SqlParameter("@Staff_NSRSWSQModulesCertificate", SqlDbType.VarChar, 300);
                para[91].Value = NSRSWSQModules;

                para[92] = new SqlParameter("@Staff_OtherRecognisedCertificate", SqlDbType.VarChar, 300);
                para[92].Value = OtherRecognisedCertificate;

                para[93] = new SqlParameter("@Staff_ExemptionCertificate", SqlDbType.VarChar, 300);
                para[93].Value = ExemptionCertificate;

                para[94] = new SqlParameter("@Staff_SecurityOfficerLicenseCertificate", SqlDbType.VarChar, 300);
                para[94].Value = SecurityOfficerLicense;

                para[95] = new SqlParameter("@Staff_SIRDScreenCertificate", SqlDbType.VarChar, 300);
                para[95].Value = SIRDScreen;


                para[96] = new SqlParameter("@Staff_MalasianWorkPermitExpire", SqlDbType.VarChar, 300);
                para[96].Value = MalasianWorkPermitExpire;

                para[97] = new SqlParameter("@Staff_MalasianPassportExpire", SqlDbType.VarChar, 300);
                para[97].Value = MalasianPassportExpire;

                para[98] = new SqlParameter("@Staff_MalasianIC", SqlDbType.VarChar, 300);
                para[98].Value = MalasianIC;

                para[99] = new SqlParameter("@Staff_MalasianOLDIC", SqlDbType.VarChar, 300);
                para[99].Value = MalasianOLDIC;

                para[100] = new SqlParameter("@Staff_MalasianPassportNo", SqlDbType.VarChar, 300);
                para[100].Value = MalasianPassportNo;

                para[101] = new SqlParameter("@Staff_MalasianWorkPermit", SqlDbType.VarChar, 300);
                para[101].Value = MalasianWorkPermit;

                para[102] = new SqlParameter("@Staff_MalasianEducationLevel", SqlDbType.VarChar, 300);
                para[102].Value = MalasianEducationLevel;

                para[103] = new SqlParameter("@StaffID", SqlDbType.VarChar, 300);
                para[103].Value = Session["Staff_ID_LOCAL"].ToString().Trim();

                para[104] = new SqlParameter("@Squrity_Question", SqlDbType.VarChar, 50);
                para[104].Value = SecurityQus;

                para[105] = new SqlParameter("@Staff_Mobile", SqlDbType.VarChar, 50);
                para[105].Value = Staff_Mobile;
                para[106] = new SqlParameter("@LastActivityTime", SqlDbType.DateTime, 50);
                string date = DateTime.Now.ToString();
                para[106].Value = date;

                int result = dal.executeprocedure("usp_EnrollStaff", para);
                if (result > 0)
                {
                    SpaMaster MyMasterPage1 = (SpaMaster)Page.Master;
                    TabContainer1.ActiveTabIndex = 2;
                    // MyMasterPage1.ShowErrorMessage("Record Insert Sucessfull..!");
                    BindGridWithFilter();
                    // AllClear();
                    if (Staff_SubRole == "Security Officers" || Staff_SubRole == "Supervisor")
                    {
                        AssignAllLocation(Session["Staff_ID_LOCAL"].ToString());
                    }
                    UpdateStock();
                    cmdbuttonNext.Enabled = true;
                    cmdbuttonFinish.Enabled = true;

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    ViewState["Staff_ID"] = Session["Staff_ID_LOCAL"].ToString();
                    Session["Staff_ID_LOCAL"] = null;
                    // Server.Transfer("..//ADMIN//ItemIssued.aspx");
                }




            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            cmdbuttonNext.Enabled = true;
            cmdbuttonFinish.Enabled = true;


        }
        protected void cmdbuttonNext_Click(object sender, EventArgs e)
        {
            if (txtStaffUserid.Text == "")
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                MyMasterPage.ShowErrorMessage("Please Fill UserId..!");

            }
            else if (txtStaffUserPassword.Text == "")
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                MyMasterPage.ShowErrorMessage("Please Fill UserPassword..!");
            }
            else
            {
                TabContainer1.ActiveTabIndex = 2;
            }



        }
        protected void cmdbuttonFinish_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }

        protected void cmdbuttonNext3_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 3;

        }

        protected void cmdbuttonFinish3_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }
        protected void cmdbuttonSave4_Click(object sender, EventArgs e)
        {
            cmdbuttonNext4.Enabled = true;
            cmdbuttonFinish4.Enabled = true;
            string UserID = Session["Local_User_Id"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (Session["Local_User_Id"].ToString() != "")
                {

                    cmdbuttonNext3.Enabled = true;
                    cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_NSFrom=@Staff_NSFrom,Staff_NSTo=@Staff_NSTo,Staff_NSTypeOfDischarge=@Staff_NSTypeOfDischarge,Staff_NSVocation=@Staff_NSVocation,Staff_NSNextInCamp=@Staff_NSNextInCamp,Staff_NSLastRank=@Staff_NSLastRank,Staff_NSExempted=@Staff_NSExempted,Staff_NSReason=@Staff_NSReason,Staff_NSDateOFRegistration=@Staff_NSDateOFRegistration  where UserID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_NSFrom", txtNSTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSTo", txtNSTo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSTypeOfDischarge", txtNSTypeofDischarge.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSVocation", txtNSVocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSNextInCamp", txtNSNextInCamp.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSLastRank", txtNSLastRank.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSExempted", txtNSExempted.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSReason", txtNSReason.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NSDateOFRegistration", txtNSPeriod.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                        SpaMaster MyMasterPage1 = (SpaMaster)Page.Master;
                        TabContainer1.ActiveTabIndex = 4;
                        //   MyMasterPage1.ShowErrorMessage("Record Insert Sucessfull..!");
                        BindGridWithFilter();
                    }
                }
                else
                {
                    //  lblerror1.Visible = true;
                    MyMasterPage.ShowErrorMessage("Please Fill First Information....!");
                    // lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void cmdbuttonNext4_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 4;

        }

        protected void cmdbuttonFinish4_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }
        protected void cmdbuttonSave5_Click(object sender, EventArgs e)
        {
            cmdbuttonNext5.Enabled = true;
            cmdbuttonFinish5.Enabled = true;
            string UserID = Session["Local_User_Id"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Local_User_Id"].ToString() != "")
                {
                    string Nricworkpermit = string.Empty;
                    string NSRSWSQModules = string.Empty;
                    string OtherRecognisedCertificate = string.Empty;

                    string ExemptionCertificate = string.Empty;
                    string SecurityOfficerLicense = string.Empty;
                    string SIRDScreen = string.Empty;
                    if (txtNricworkpermit.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtNricworkpermit.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        Nricworkpermit = "~/FileUpload/" + f.FileName;

                    }
                    if (txtNSRSWQ.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtNSRSWQ.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        NSRSWSQModules = "~/FileUpload/" + f.FileName;
                    }
                    if (txtotherRecognised.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtotherRecognised.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        OtherRecognisedCertificate = "~/FileUpload/" + f.FileName;
                    }
                    if (txtExemptionCertificate.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtExemptionCertificate.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        ExemptionCertificate = "~/FileUpload/" + f.FileName;
                    }
                    if (txtSecurityOfficerLicense.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtSecurityOfficerLicense.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        SecurityOfficerLicense = "~/FileUpload/" + f.FileName;
                    }
                    if (txtSIRDscreen.UploadedFiles.Count > 0)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        UploadedFile f = null;
                        f = txtSIRDscreen.UploadedFiles[0];
                        f.SaveAs(path + f.FileName);
                        SIRDScreen = "~/FileUpload/" + f.FileName;
                    }
                    cmdbuttonNext3.Enabled = true;
                    cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_EmpExCompName1=@Staff_EmpExCompName1,Staff_EmpExFrom1=@Staff_EmpExFrom1,Staff_EmpExTo1=@Staff_EmpExTo1,Staff_EmpExReasonLeaving1=@Staff_EmpExReasonLeaving1, Staff_EmpExLastDrawnSalary1=@Staff_EmpExLastDrawnSalary1, Staff_EmpExCompName2=@Staff_EmpExCompName2,Staff_EmpExFrom2=@Staff_EmpExFrom2,Staff_EmpExTo2=@Staff_EmpExTo2,Staff_EmpExReasonLeaving2=@Staff_EmpExReasonLeaving2,Staff_EmpExLastDrawnSalary2=@Staff_EmpExLastDrawnSalary2,Staff_EmpExCompName3=@Staff_EmpExCompName3,Staff_EmpExFrom3=@Staff_EmpExFrom3,Staff_EmpExTo3=@Staff_EmpExTo3,Staff_EmpExReasonLeaving3=@Staff_EmpExReasonLeaving3,Staff_EmpExLastDrawnSalary3=@Staff_EmpExLastDrawnSalary3,Staff_EmpExCompName4=@Staff_EmpExCompName4,Staff_EmpExFrom4=@Staff_EmpExFrom4,Staff_EmpExTo4=@Staff_EmpExTo4,Staff_EmpExReasonLeaving4=@Staff_EmpExReasonLeaving4,Staff_EmpExLastDrawnSalary4=@Staff_EmpExLastDrawnSalary4,Staff_ExpectedSalary=@Staff_ExpectedSalary,Staff_CommenceWork=@Staff_CommenceWork,Staff_LAW=@Staff_LAW,Staff_LAWResion=@Staff_LAWResion,Staff_Injury=@Staff_Injury,Staff_InjuryResion=@Staff_InjuryResion,Staff_NRICWorkPermitCertificate=@Staff_NRICWorkPermitCertificate,Staff_NSRSWSQModulesCertificate=@Staff_NSRSWSQModulesCertificate,Staff_OtherRecognisedCertificate=@Staff_OtherRecognisedCertificate,Staff_ExemptionCertificate=@Staff_ExemptionCertificate,Staff_SecurityOfficerLicenseCertificate=@Staff_SecurityOfficerLicenseCertificate,Staff_SIRDScreenCertificate=@Staff_SIRDScreenCertificate where UserID=@UserID", cn);
                    
                   // SqlCommand cmd = new SqlCommand("update UserInformation set Staff_EmpExCompName1=@Staff_EmpExCompName1  where UserID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName1", txtEnameofCompany1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom1", txtEFrom1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo1", txtETo1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving1", txtEReasonleave1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary1", txtELastDraw1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName2", txtEnameofCompany2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom2", txtEFrom2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo2", txtETo2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving2", txtEReasonleave2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary2", txtELastDraw2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName3", txtEnameofCompany3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom3", txtEFrom3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo3", txtETo3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving3", txtEReasonleave3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary3", txtELastDraw3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExCompName4", txtEnameofCompany4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExFrom4", txtEFrom4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExTo4", txtETo4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExReasonLeaving4", txtEReasonleave4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_EmpExLastDrawnSalary4", txtELastDraw4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_ExpectedSalary", txtexpectedSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_CommenceWork", txtcommencework.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_LAW", DropDownList5.SelectedItem.Value.Trim());
                    cmd.Parameters.AddWithValue("@Staff_LAWResion", txtLAWyes.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_Injury", DropDownList6.SelectedItem.Value.Trim());
                    cmd.Parameters.AddWithValue("@Staff_InjuryResion", txtInjuryyes.Text.Trim());
                    cmd.Parameters.AddWithValue("@Staff_NRICWorkPermitCertificate", Nricworkpermit);
                    cmd.Parameters.AddWithValue("@Staff_NSRSWSQModulesCertificate", NSRSWSQModules);
                    cmd.Parameters.AddWithValue("@Staff_OtherRecognisedCertificate", OtherRecognisedCertificate);
                    cmd.Parameters.AddWithValue("@Staff_ExemptionCertificate", ExemptionCertificate);
                    cmd.Parameters.AddWithValue("@Staff_SecurityOfficerLicenseCertificate", SecurityOfficerLicense);
                    cmd.Parameters.AddWithValue("@Staff_SIRDScreenCertificate", SIRDScreen);

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                        TabContainer1.ActiveTabIndex = 5;
                        //MyMasterPage.ShowErrorMessage("Record Insert Sucessfull..!");
                        BindGridWithFilter();
                    }
                }
                else
                {
                    // lblerror1.Visible = true;
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill First Information ..!");
                    //lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdbuttonNext5_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 5;

        }

        protected void cmdbuttonFinish5_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }
        protected void cmdbuttonSave6_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            bool success = false;
            cn.Open();
            if (Session["Local_User_Id"] != null)
            {
                try
                {
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@ThumbImage", SqlDbType.VarBinary);
                    //para[0].Value = HexsToArray(TextBox1.Text);
                    //     Template template1 = new Template();
                    //     FeatureSet featureSet = new FeatureSet();

                    //// para[0] = new SqlParameter("Staff_ID", Session["StaffID"].ToString());
                    //     DataTable dt = dal.getdata("Sp_GetThumbPrints");
                    //     foreach (DataRow dr in dt.Rows)
                    //     {
                    //         featureSet = new DPFP.FeatureSet();
                    //         featureSet.DeSerialize(HexsToArray(hdnFP.Value));
                    //         template1 = new DPFP.Template();
                    //         template1.DeSerialize((byte[])dr["ThumbImage"]);
                    //         if (VerifyFingerprints(template1, featureSet))
                    //         {
                    para[0].Value = HexsToArray(hdnFP.Value);
                    if (Session["CaptureImage"] != null)
                    {
                        para[1] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                        para[1].Value = "~/admin/" + Session["CaptureImage"].ToString();
                        Session["CaptureImage"] = null;
                    }
                    else
                    {
                        //para[1] = new SqlParameter("@UserImage", SqlDbType.VarChar, 500);
                        //para[1].Value = "";

                        if (FileUpload1.UploadedFiles.Count > 0)
                        {
                            para[1] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                            UploadedFile file = null;
                            file = FileUpload1.UploadedFiles[0];
                            // string  = FileUpload1.;
                            string thubpath = ("~/ADMIN" + "/" + file.FileName);
                            file.SaveAs(Server.MapPath(file.FileName));
                            //FileUpload1.PostedFile.SaveAs();
                            para[1].Value = thubpath;

                        }
                        else
                        {
                            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                            // lblerror1.Visible = true;
                            MyMasterPage.ShowErrorMessage("Image is not saved please select file or Capture Image");
                            // lblerror1.Text = "Please choose file !!!";
                        }
                    }

                    SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName,ThumbImage=@ThumbImage where UserID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@ImagePathName", para[1].Value);
                    cmd.Parameters.AddWithValue("@ThumbImage", para[0].Value);
                    cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id"].ToString());
                    //int x=cmd.e
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                        if (Session["Staff_ID_LOCAL"] != null && ViewState["password"] != null && Session["Local_User_Id"] != null)
                        {
                            lblok.Text = "Staff Created Successfully <br/>StaffID=" + Session["Staff_ID_LOCAL"].ToString() + " <br/>UserID=" + Session["Local_User_Id"].ToString() + "<br/> password=" + ViewState["password"].ToString();
                            ModalPopupOK.Show();
                        }
                        // MyMasterPage.ShowErrorMessage("Record insert Successfully..!");
                        BindGridWithFilter();
                        // pnlAdd.Visible = false;
                        //lblerror1.Visible = true;
                        // lblerror1.Text = "Add Successfully ...!";
                        cn.Close();
                        Session["CaptureImagePath2"] = "";
                    }
                    //    }
                    //    if (!success)
                    //    {
                    //        if (!(lblerror.Text.ToLower().Contains("already")))
                    //        {
                    //            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    //            MyMasterPage.ShowErrorMessage("Invalid Thumbprint. Please Put Correct Finger..!");
                    //           // lblerror.Text = "Invalid Thumbprint. Please Put Correct Finger.";
                    //           /// lblerror.Visible = true;
                    //        }
                    //    }
                    //}

                }
                catch (Exception exc)
                {
                    logger.Info(exc.Message);
                }
            }
            //cmdbuttonFinish6.Enabled = true;
        }


        protected void cmdbuttonFinish6_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
            //cmdbuttonNext2.Enabled = true;

        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            //Response.Redirect("TabPanel5" + TabPanel5.TabIndex.ToString() + "TabPanel4" + TabPanel4.TabIndex.ToString() + "TabPanel3" + TabPanel3.TabIndex.ToString() + "TabPanel2" + TabPanel2.TabIndex.ToString() + "TabPanel1" + TabPanel1.TabIndex.ToString());
        }



        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList5.SelectedItem.Text.Trim() == "Yes")
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (DropDownList6.SelectedItem.Text.Trim() == "Yes")
                {
                    Panel2Upda.Visible = true;
                }
                else
                {
                    Panel2Upda.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmdIssueItem_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=0','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
        }

        protected void cmdViewIssueItem_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=1','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
        }

        private void AssignAllLocation(string staffID)
        {
            //DataSet dsstaffid = dal.getdataset("select Staff_id,role from userinformation where role='SuperVisor' OR role='Security Officer'");
            //if (dsstaffid.Tables[0].Rows.Count > 0)
            //{
            //    for (int k = 0; k < dsstaffid.Tables[0].Rows.Count; k++)
            //    {
            // string staffid = dsstaffid.Tables[0].Rows[k][0].ToString();
            DataSet dslocation = dal.getdataset("select location_id from location where Current_Status='Present'");
            if (dslocation.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < dslocation.Tables[0].Rows.Count; j++)
                {
                    string locid = dslocation.Tables[0].Rows[j][0].ToString();
                    dal.executesql("Insert into StaffLocationMap(StaffID,LocationID)values('" + staffID + "','" + locid + "')");
                }
            }
            //}
            //}
        }
        private void UpdateStock()
        {
            DataSet ds = dal.getdataset("select * from NewInventory_Temp with(nolock)where Staff_ID='" + Session["Staff_ID_LOCAL"].ToString() + "'");
            string Item_type = String.Empty;
            string Item_name = String.Empty;
            int qty = 0;
            if (ds != null && ds.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Item_type = ds.Tables[0].Rows[i]["Item_Type"].ToString();
                    Item_name = ds.Tables[0].Rows[i]["Item_Name"].ToString();
                    qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Item_Qty"].ToString());
                    UpdateStockCommit(Item_type, Item_name, qty);
                }
            }
        }

        public byte[] HexsToArray(string sHexString)
        {
            byte[] ra = new byte[sHexString.Length / 2];
            for (Int32 i = 0; i <= sHexString.Length - 1; i += 2)
            {
                ra[i / 2] = byte.Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber);
            }
            return ra;
        }
        private void UpdateStockCommit(string type, string name, int qty)
        {
            string UpdateQuery = "update AddNEwINvetory set Item_qty = Item_qty -" + qty + " where item_name='" + name + "' and Item_Type='" + type + "'";
            dal.executesql(UpdateQuery);
        }
        #endregion

        #region Education Detail

        protected void cmdbuttonSave3_Click(object sender, EventArgs e)
        {
            string UserID = Session["Local_User_Id"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Local_User_Id"].ToString() != "")
                {

                    cmdbuttonNext3.Enabled = true;
                    cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_PrimarySchoolName=@Staff_PrimarySchoolName,Staff_PrimaryAddress=@Staff_PrimaryAddress,Staff_PrimaryLevel=@Staff_PrimaryLevel,Staff_PrimaryFrom=@Staff_PrimaryFrom,Staff_PrimaryTo=@Staff_PrimaryTo,Staff_PrimaryQualification=@Staff_PrimaryQualification,Staff_SecondarySchoolName=@Staff_SecondarySchoolName,Staff_SecondaryAddress=@Staff_SecondaryAddress,Staff_SecondaryLevel=@Staff_SecondaryLevel,Staff_SecondaryFrom=@Staff_SecondaryFrom,Staff_SecondaryTo=@Staff_SecondaryTo,Staff_SecondaryQualification=@Staff_SecondaryQualification,Staff_VocationSchoolName=@Staff_VocationSchoolName,Staff_VocationAddress=@Staff_VocationAddress,Staff_VocationLevel=@Staff_VocationLevel,Staff_VocationFrom=@Staff_VocationFrom,Staff_VocationTo=@Staff_VocationTo,Staff_VocationQualification=@Staff_VocationQualification,Staff_OtherSchoolName=@Staff_OtherSchoolName,Staff_OtherAddress=@Staff_OtherAddress,Staff_OtherLevel=@Staff_OtherLevel,Staff_OtherFrom=@Staff_OtherFrom,Staff_OtherTo=@Staff_OtherTo,Staff_OtherQualification=@Staff_OtherQualification,Staff_OtherTraining=@Staff_OtherTraining where UserID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@Staff_PrimarySchoolName", txtEDnameofSchool1.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryAddress", txtEDaddres1.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryLevel", txtEDLeve1.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryFrom", txtEDFrom1.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryTo", txtEDTo1.Text);
                    cmd.Parameters.AddWithValue("@Staff_PrimaryQualification", txtEDqualification1.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondarySchoolName", txtEDnameofSchool2.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryAddress", txtEDaddres2.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryLevel", txtEDLeve2.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryFrom", txtEDFrom2.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryTo", txtEDTo2.Text);
                    cmd.Parameters.AddWithValue("@Staff_SecondaryQualification", txtEDqualification2.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationSchoolName", txtEDnameofSchool3.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationAddress", txtEDaddres3.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationLevel", txtEDLeve3.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationFrom", txtEDFrom3.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationTo", txtEDTo3.Text);
                    cmd.Parameters.AddWithValue("@Staff_VocationQualification", txtEDqualification3.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherSchoolName", txtEDnameofSchool4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherAddress", txtEDaddres4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherLevel", txtEDLeve4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherFrom", txtEDFrom4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherTo", txtEDTo4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherQualification", txtEDqualification4.Text);
                    cmd.Parameters.AddWithValue("@Staff_OtherTraining", txtotherSkills.Text);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                        SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                        TabContainer1.ActiveTabIndex = 3;
                        // MyMasterPage.ShowErrorMessage("Record insert sucessfully ..!");
                        BindGridWithFilter();
                    }
                }
                else
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Please Fill First Information ..!");
                    // lblerror1.Visible = true;
                    // lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            //-------------------------------------------------------------
        }

        #endregion

        #endregion Add Staff


        protected void btnok_Click(object sender, EventArgs e)
        {
            //pnlAdd.Visible = false;
            lblok.Text = "";
            ModalPopupOK.Hide();
            //pnlAdd.Visible = false;
            Response.Redirect(Request.RawUrl.ToString());
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


        protected void hypNRICWorkPermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypNRICWorkPermit.Text != "")
                {
                    path = hypNRICWorkPermit.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void hypNSRSWSQModule_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypNSRSWSQModule.Text != "")
                {
                    path = hypNSRSWSQModule.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void hypOtherRecoQualify_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypOtherRecoQualify.Text != "")
                {
                    path = hypOtherRecoQualify.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void hypExemptionCertificate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypExemptionCertificate.Text != "")
                {
                    path = hypExemptionCertificate.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void hypSecurityOfficerLicenset_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypSecurityOfficerLicense.Text != "")
                {
                    path = hypSecurityOfficerLicense.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void hypSIRDScreen_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string path = "";

                if (hypSIRDScreen.Text != "")
                {
                    path = hypSIRDScreen.Text;
                    path = path.Replace("~/", "");
                }

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #endregion
    }
}
