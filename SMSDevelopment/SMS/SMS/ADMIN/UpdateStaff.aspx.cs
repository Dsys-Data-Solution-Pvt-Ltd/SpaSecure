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
using SMS.Services.DALUtilities;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using System.Globalization;

using SMS.SMSAppUtilities;
using System.IO;


namespace SMS.ADMIN
{
    public partial class UpdateStaff : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        String status = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = String.Empty;
            errFname.Visible = false;
            errUserid.Visible = false;
            lblnri5.Visible = false;
            errnri.Visible = false;
            errUserPassword.Visible = false;
            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                
                if (!IsPostBack)
                {
                    fillrole();
                    fillSecurityqust();
                    
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, cmdbuttonSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        Session["Local_User_Id1"] = iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                        string path = Request["path"];
                        Session["path"] = path;
                    }
                    if (Request.QueryString["StaffID"] != null)
                    {
                        iBTID = Request.QueryString["StaffID"];
                    }

                    fillrole();
                    fillSecurityqust();
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void fillrole()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add(" ");
            DataSet dsgrole = dal.getdataset("Select UserRole from UserRoleMaster order by UserRole Asc");
            if (dsgrole.Tables[0].Rows.Count > 0)
            {
                for (int h = 0; h < dsgrole.Tables[0].Rows.Count; h++)
                {
                    ddlRole.Items.Add(dsgrole.Tables[0].Rows[h][0].ToString());
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
                ddlStaffSecQues.DataBind();
                ddlStaffSecQues.Items.Insert(0, new ListItem(" ", " ", true));

              
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
                Session["Staff_ID"] = argsBGID.ToString().Trim();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@StaffID", argsBGID);

                //DataTable dt = dal.executeprocedure("usp_GetEnrollStaff", para, false);
                string Bquery = " Select Staff_ID,Staff_PreName,FirstName,MiddleName,LastName,staff_Address,Staff_Telphone,Staff_HPno,Staff_Mobile,Staff_DOB,Staff_POB,Staff_Race,NRICno,Staff_Age,Staff_Religion,Staff_Sex,Staff_DriverLicense,Staff_IncomeTax,Staff_MaritalStatus,Staff_Occupation,Staff_NoOfChile,Staff_MarriedSpousName,Staff_EmergencyName,Staff_EmergencyAdd,Staff_EmergencyTelphone,Staff_PrimarySchoolName,Staff_PrimaryAddress,Staff_PrimaryFrom,Staff_PrimaryTo,Staff_PrimaryQualification,Staff_SecondarySchoolName,Staff_SecondaryAddress,Staff_SecondaryFrom,Staff_SecondaryTo,Staff_SecondaryQualification,Staff_VocationSchoolName,Staff_VocationAddress, Staff_VocationFrom,Staff_VocationTo,Staff_VocationQualification,Staff_OtherSchoolName,Staff_OtherAddress,Staff_OtherFrom,Staff_OtherTo,Staff_OtherQualification,Staff_OtherTraining,Staff_Hobbies,Staff_NSFrom,Staff_NSTo,Staff_NSTypeOfDischarge,Staff_NSVocation,Staff_NSNextInCamp,Staff_NSLastRank,Staff_NSExempted,Staff_NSReason, Staff_NSDateOFRegistration,Staff_EmpExCompName1,Staff_EmpExFrom1,Staff_EmpExTo1,Staff_EmpExReasonLeaving1,Staff_EmpExLastDrawnSalary1,Staff_EmpExCompName2,Staff_EmpExFrom2,Staff_EmpExTo2,Staff_EmpExReasonLeaving2,Staff_EmpExLastDrawnSalary2,Staff_EmpExCompName3,Staff_EmpExFrom3,Staff_EmpExTo3,Staff_EmpExReasonLeaving3,Staff_EmpExLastDrawnSalary3,Staff_EmpExCompName4,Staff_EmpExFrom4,Staff_EmpExTo4,Staff_EmpExReasonLeaving4,Staff_EmpExLastDrawnSalary4,Staff_ExpectedSalary,Staff_CommenceWork,Staff_LAWResion,Staff_InjuryResion,UserID,UserPassword,Role,UserSecretAns,Staff_NRICWorkPermitCertificate,Staff_NSRSWSQModulesCertificate,Staff_OtherRecognisedCertificate,Staff_ExemptionCertificate,Staff_SecurityOfficerLicenseCertificate,Staff_SIRDScreenCertificate,Staff_MalasianIC,Staff_MalasianOLDIC,Staff_MalasianPassportNo,Staff_MalasianPassportExpire,Staff_MalasianWorkPermit,Staff_MalasianWorkPermitExpire,Staff_MalasianEducationLevel,Staff_Citizenship,Squrity_Question,Staff_Mobile,ImagePathName,ThumbImage From UserInformation Where Staff_ID = '" + argsBGID + "'  ";

                DataTable dt = dal.getdata(Bquery);
                if (dt.Rows.Count > 0)
                {
                    string Staffid = dt.Rows[0]["Staff_ID"].ToString().Trim();
                    txtStaff_ID.Text = dt.Rows[0]["Staff_ID"].ToString().Trim();
                    DropDownList1.Text = dt.Rows[0]["Staff_PreName"].ToString().Trim();

                    txtFname.Text = dt.Rows[0]["FirstName"].ToString().Trim();
                    txtMname.Text = dt.Rows[0]["MiddleName"].ToString().Trim();
                    txtLname.Text = dt.Rows[0]["LastName"].ToString().Trim();
                    txtHomeAdress.Text = dt.Rows[0]["staff_Address"].ToString().Trim();
                    txtPhone.Text = dt.Rows[0]["Staff_Telphone"].ToString().Trim();
                    txtHP.Text = dt.Rows[0]["Staff_HPno"].ToString().Trim();
                    txtMobNo.Text = dt.Rows[0]["Staff_Mobile"].ToString().Trim();
                    txtDOB.Text = dt.Rows[0]["Staff_DOB"].ToString().Trim();

                    txtPOB.Text = dt.Rows[0]["Staff_POB"].ToString().Trim();
                    txtrace.Text = dt.Rows[0]["Staff_Race"].ToString().Trim();
                    txtnric.Text = dt.Rows[0]["NRICno"].ToString().Trim();

                    txtage.Text = dt.Rows[0]["Staff_Age"].ToString().Trim();
                    txtreligion.Text = dt.Rows[0]["Staff_Religion"].ToString().Trim();

                    DropDownList3.Text = dt.Rows[0]["Staff_Sex"].ToString().Trim();
                    txtDlicense.Text = dt.Rows[0]["Staff_DriverLicense"].ToString().Trim();
                    txtincometax.Text = dt.Rows[0]["Staff_IncomeTax"].ToString().Trim();
                    DropDownList4.Text = dt.Rows[0]["Staff_MaritalStatus"].ToString().Trim();
                    txtOccupation.Text = dt.Rows[0]["Staff_Occupation"].ToString().Trim();
                    txtnoOfChildern.Text = dt.Rows[0]["Staff_NoOfChile"].ToString().Trim();

                    txtSpousename.Text = dt.Rows[0]["Staff_MarriedSpousName"].ToString().Trim();
                    txtEmergencyName.Text = dt.Rows[0]["Staff_EmergencyName"].ToString().Trim();

                    txtEmergenAddress.Text = dt.Rows[0]["Staff_EmergencyAdd"].ToString().Trim();
                    txtEmergencContNo.Text = dt.Rows[0]["Staff_EmergencyTelphone"].ToString().Trim();

                    txtEDnameofSchool1.Text = dt.Rows[0]["Staff_PrimarySchoolName"].ToString().Trim();
                    txtEDaddres1.Text = dt.Rows[0]["Staff_PrimaryAddress"].ToString().Trim();
                    txtEDFrom1.Text = dt.Rows[0]["Staff_PrimaryFrom"].ToString().Trim();
                    txtEDTo1.Text = dt.Rows[0]["Staff_PrimaryTo"].ToString().Trim();
                    txtEDqualification1.Text = dt.Rows[0]["Staff_PrimaryQualification"].ToString().Trim();

                    txtEDnameofSchool2.Text = dt.Rows[0]["Staff_SecondarySchoolName"].ToString().Trim();
                    txtEDaddres2.Text = dt.Rows[0]["Staff_SecondaryAddress"].ToString().Trim();
                    txtEDFrom2.Text = dt.Rows[0]["Staff_SecondaryFrom"].ToString().Trim();
                    txtEDTo2.Text = dt.Rows[0]["Staff_SecondaryTo"].ToString().Trim();
                    txtEDqualification2.Text = dt.Rows[0]["Staff_SecondaryQualification"].ToString().Trim();

                    txtEDnameofSchool3.Text = dt.Rows[0]["Staff_VocationSchoolName"].ToString().Trim();
                    txtEDaddres3.Text = dt.Rows[0]["Staff_VocationAddress"].ToString().Trim();
                    txtEDFrom3.Text = dt.Rows[0]["Staff_VocationFrom"].ToString().Trim();
                    txtEDTo3.Text = dt.Rows[0]["Staff_VocationTo"].ToString().Trim();
                    txtEDqualification3.Text = dt.Rows[0]["Staff_VocationQualification"].ToString().Trim();

                    txtEDnameofSchool4.Text = dt.Rows[0]["Staff_OtherSchoolName"].ToString().Trim();
                    txtEDaddres4.Text = dt.Rows[0]["Staff_OtherAddress"].ToString().Trim();
                    txtEDFrom4.Text = dt.Rows[0]["Staff_OtherFrom"].ToString().Trim();
                    txtEDTo4.Text = dt.Rows[0]["Staff_OtherTo"].ToString().Trim();
                    txtEDqualification4.Text = dt.Rows[0]["Staff_OtherQualification"].ToString().Trim();


                    txtotherSkills.Text = dt.Rows[0]["Staff_OtherTraining"].ToString().Trim();
                    txthobbies.Text = dt.Rows[0]["Staff_Hobbies"].ToString().Trim();

                    txtNSTime.Text = dt.Rows[0]["Staff_NSFrom"].ToString().Trim();
                    txtNSTo.Text = dt.Rows[0]["Staff_NSTo"].ToString().Trim();
                    txtNSTypeofDischarge.Text = dt.Rows[0]["Staff_NSTypeOfDischarge"].ToString().Trim();
                    txtNSVocation.Text = dt.Rows[0]["Staff_NSVocation"].ToString().Trim();
                    txtNSNextInCamp.Text = dt.Rows[0]["Staff_NSNextInCamp"].ToString().Trim();
                    txtNSLastRank.Text = dt.Rows[0]["Staff_NSLastRank"].ToString().Trim();

                    txtNSExempted.Text = dt.Rows[0]["Staff_NSExempted"].ToString().Trim();
                    txtNSReason.Text = dt.Rows[0]["Staff_NSReason"].ToString().Trim();
                    txtNSPeriod.Text = dt.Rows[0]["Staff_NSDateOFRegistration"].ToString().Trim();

                    txtEnameofCompany1.Text = dt.Rows[0]["Staff_EmpExCompName1"].ToString().Trim();
                    txtEFrom1.Text = dt.Rows[0]["Staff_EmpExFrom1"].ToString().Trim();
                    txtETo1.Text = dt.Rows[0]["Staff_EmpExTo1"].ToString().Trim();
                    txtEReasonleave1.Text = dt.Rows[0]["Staff_EmpExReasonLeaving1"].ToString().Trim();
                    txtELastDraw1.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary1"].ToString().Trim();

                    txtEnameofCompany2.Text = dt.Rows[0]["Staff_EmpExCompName2"].ToString().Trim();
                    txtEFrom2.Text = dt.Rows[0]["Staff_EmpExFrom2"].ToString().Trim();
                    txtETo2.Text = dt.Rows[0]["Staff_EmpExTo2"].ToString().Trim();
                    txtEReasonleave2.Text = dt.Rows[0]["Staff_EmpExReasonLeaving2"].ToString().Trim();
                    txtELastDraw2.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary2"].ToString().Trim();

                    txtEnameofCompany3.Text = dt.Rows[0]["Staff_EmpExCompName3"].ToString().Trim();
                    txtEFrom3.Text = dt.Rows[0]["Staff_EmpExFrom3"].ToString().Trim();
                    txtETo3.Text = dt.Rows[0]["Staff_EmpExTo3"].ToString().Trim();
                    txtEReasonleave3.Text = dt.Rows[0]["Staff_EmpExReasonLeaving3"].ToString().Trim();
                    txtELastDraw3.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary3"].ToString().Trim();

                    txtEnameofCompany4.Text = dt.Rows[0]["Staff_EmpExCompName4"].ToString().Trim();
                    txtEFrom4.Text = dt.Rows[0]["Staff_EmpExFrom4"].ToString().Trim();
                    txtETo4.Text = dt.Rows[0]["Staff_EmpExTo4"].ToString().Trim();
                    txtEReasonleave4.Text = dt.Rows[0]["Staff_EmpExReasonLeaving4"].ToString().Trim();
                    txtELastDraw4.Text = dt.Rows[0]["Staff_EmpExLastDrawnSalary4"].ToString().Trim();
                    ImgageStaff.ImageUrl = dt.Rows[0]["ImagePathName"].ToString().Trim();
                    txtexpectedSalary.Text = dt.Rows[0]["Staff_ExpectedSalary"].ToString().Trim();
                    txtcommencework.Text = dt.Rows[0]["Staff_CommenceWork"].ToString().Trim();
                    // DropDownList5.Text = dt.Rows[0][78].ToString().Trim();
                    txtLAWyes.Text = dt.Rows[0]["Staff_LAWResion"].ToString().Trim();
                    if (txtLAWyes.Text != "")
                    {
                        DropDownList5.Text = "Yes";
                        Panel1.Visible = true;
                    }
                    else
                    {

                        DropDownList5.Text = "No";
                        Panel1.Visible = false;
                    }
                    // DropDownList6.Text = dt.Rows[0][80].ToString().Trim();
                    txtInjuryyes.Text = dt.Rows[0]["Staff_InjuryResion"].ToString().Trim();

                    if (txtInjuryyes.Text != "")
                    {
                        DropDownList6.Text = "Yes";
                        Panel2.Visible = true;
                    }
                    else
                    {
                        DropDownList6.Text = "No";
                        Panel2.Visible = false;
                    }

                    txtStaffUserid.Text = dt.Rows[0]["UserID"].ToString().Trim();
                    txtStaffUserPassword.Text = dt.Rows[0]["UserPassword"].ToString().Trim();
                    txtStaffuserConfigPassword.Text = dt.Rows[0]["UserPassword"].ToString().Trim();
                    //ddlRole.Text = dt.Rows[0]["Role"].ToString().Trim();
                    AddNewLabel.Text = dt.Rows[0]["Role"].ToString().Trim();
                    txtStaffSeurityqty.Text = dt.Rows[0]["UserSecretAns"].ToString().Trim();

                    lnkLabel1.Text = hypNRICWorkPermit.NavigateUrl = dt.Rows[0]["Staff_NRICWorkPermitCertificate"].ToString().Trim();
                    lnkLabel2.Text = hypNSRSWSQModule.NavigateUrl = dt.Rows[0]["Staff_NSRSWSQModulesCertificate"].ToString().Trim();
                    lnkLabel3.Text = hypOtherRecoQualify.NavigateUrl = dt.Rows[0]["Staff_OtherRecognisedCertificate"].ToString().Trim();
                    lnkLabel4.Text = hypExemptionCertificate.NavigateUrl = dt.Rows[0]["Staff_ExemptionCertificate"].ToString().Trim();
                    lnkLabel5.Text = hypSecurityOfficerLicense.NavigateUrl = dt.Rows[0]["Staff_SecurityOfficerLicenseCertificate"].ToString().Trim();
                    lnkLabel6.Text = hypSIRDScreen.NavigateUrl = dt.Rows[0]["Staff_SIRDScreenCertificate"].ToString().Trim();

                    txtMalaysianICno.Text = dt.Rows[0]["Staff_MalasianIC"].ToString().Trim();
                    txtMalaysianOldIC.Text = dt.Rows[0]["Staff_MalasianOLDIC"].ToString().Trim();
                    txtMalasianPassport.Text = dt.Rows[0]["Staff_MalasianPassportNo"].ToString().Trim();
                    txtMalasianPassportExpdate.Text = dt.Rows[0]["Staff_MalasianPassportExpire"].ToString().Trim();
                    txtMalasianWorkPermitNo.Text = dt.Rows[0]["Staff_MalasianWorkPermit"].ToString().Trim();
                    txtMalasianWorkPermitExp.Text = dt.Rows[0]["Staff_MalasianWorkPermitExpire"].ToString().Trim();
                    DropDownList7.Text = dt.Rows[0]["Staff_MalasianEducationLevel"].ToString().Trim();
                    DropDownList2.Text = dt.Rows[0]["Staff_Citizenship"].ToString().Trim();
                    securityanswer.Text = dt.Rows[0]["Squrity_Question"].ToString().Trim();
                    Session["CaptureImagePath"] = dt.Rows[0]["ImagePathName"].ToString().Trim();
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

                if (txtFname.Text.Trim() == "")
                {
                    errFname.Visible = true;
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill First Name...!";
                    throw new Exception();
                }
                if (txtnric.Text.Trim() == "")
                {
                    errnri.Visible = true;
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill NRIC No...!";
                    throw new Exception();
                }
                if (txtStaffUserid.Text.Trim() == "")
                {
                    errUserid.Visible = true;
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill User ID...!";
                    throw new Exception();
                }
                if (txtStaffUserPassword.Text.Trim() == "")
                {
                    errUserPassword.Visible = true;
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill User Password...!";
                    throw new Exception();
                }
                if (txtStaffuserConfigPassword.Text.Trim() != txtStaffUserPassword.Text.Trim())
                {
                    lblerror1.Visible = true;
                    lblerror1.Text = "Re-Confirm Password...!";
                    throw new Exception();
                }
                string Staff_ID = txtStaff_ID.Text.Trim();
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
                string Staff_Citizenship = DropDownList2.SelectedItem.Value.Trim();
                string Staff_Age = txtage.Text.Trim();
                string Staff_Religion = txtreligion.Text.Trim();
                string Staff_Sex = DropDownList3.SelectedItem.Value.Trim();
                string Staff_DriverLicense = txtDlicense.Text.Trim();
                string Staff_MaritalStatus = DropDownList4.SelectedItem.Value.Trim();
                string Staff_NoOfChile = txtnoOfChildern.Text.Trim();
                string Staff_MarriedSpousName = txtSpousename.Text.Trim();
                string Staff_EmergencyName = txtEmergencyName.Text.Trim();
                string Staff_EmergencyAdd = txtEmergenAddress.Text.Trim();
                string Staff_EmergencyTelphone = txtEmergencContNo.Text.Trim();
                 string Staff_UserID = txtStaffUserid.Text.Trim();
                string Staff_UserPassword = txtStaffUserPassword.Text.Trim();
                string Staff_ComfirmPassword = txtStaffuserConfigPassword.Text.Trim();
                string Staff_SecurityAns = txtStaffSeurityqty.Text.Trim();
                string Staff_SubRole=string.Empty;
                string SecurityQuestion=string.Empty;
                string role = ddlRole.SelectedItem.Value.ToString();
                if ( role.ToString()!= " ")
                {
                    Staff_SubRole = ddlRole.SelectedValue.ToString();

                }
                else
                {
                    Staff_SubRole = AddNewLabel.Text;
                }
                string sequestion=ddlStaffSecQues.SelectedValue.ToString();
                if (sequestion.ToString()!=" ")
                {
                    SecurityQuestion = ddlStaffSecQues.SelectedValue.ToString();

                }
                else
                {
                    SecurityQuestion = securityanswer.Text;
                }
                cn.Open();
                SqlCommand _cmd = new SqlCommand("update UserInformation set Staff_PreName=@Staff_PreName, FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Staff_Address=@Staff_Address, Staff_MaritalStatus=@Staff_MaritalStatus, Staff_MarriedSpousName=@Staff_MarriedSpousName, Staff_NoOfChile=@Staff_NoOfChile, Staff_Telphone=@Staff_Telphone, Staff_HPno=@Staff_HPno, Staff_DOB=@Staff_DOB, Staff_POB=@Staff_POB, Staff_Race=@Staff_Race, NRICno=@NRICno, Staff_Citizenship=@Staff_Citizenship, Staff_Age=@Staff_Age, Staff_MalasianIC=@Staff_MalasianIC, Staff_MalasianOLDIC=@Staff_MalasianOLDIC, Staff_MalasianPassportNo=@Staff_MalasianPassportNo, Staff_MalasianPassportExpire=@Staff_MalasianPassportExpire, Staff_MalasianWorkPermit=@Staff_MalasianWorkPermit, Staff_MalasianWorkPermitExpire=@Staff_MalasianWorkPermitExpire, Staff_MalasianEducationLevel=@Staff_MalasianEducationLevel, Staff_Religion=@Staff_Religion, Staff_Sex=@Staff_Sex, Staff_DriverLicense=@Staff_DriverLicense, Staff_EmergencyName=@Staff_EmergencyName, Staff_EmergencyAdd=@Staff_EmergencyAdd, Staff_EmergencyTelphone=@Staff_EmergencyTelphone, Role=@Role, UserID=@UserID, UserPassword=@UserPassword, Staff_ComfirmPassword=@Staff_ComfirmPassword, Squrity_Question=@Squrity_Question where Staff_ID=@Staff_ID", cn);
                _cmd.Parameters.AddWithValue("@Staff_PreName",DropDownList1.SelectedValue.Trim());
                _cmd.Parameters.AddWithValue("@FirstName",txtFname.Text.Trim());
                _cmd.Parameters.AddWithValue("@MiddleName",txtMname.Text.Trim());
                _cmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_Address", txtHomeAdress.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MaritalStatus",DropDownList4.SelectedValue.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MarriedSpousName", txtSpousename.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_NoOfChile", txtnoOfChildern.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Telphone", txtPhone.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_HPno", txtHP.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_DOB", txtDOB.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_POB", txtPOB.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Race", txtrace.Text.Trim());
                 _cmd.Parameters.AddWithValue("@NRICno", txtnric.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Citizenship",DropDownList2.SelectedValue.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Age", txtage.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianIC", txtMalaysianICno.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianOLDIC", txtMalaysianOldIC.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianPassportNo", txtMalasianPassport.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianPassportExpire", txtMalasianPassportExpdate.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianWorkPermit", txtMalasianWorkPermitNo.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianWorkPermitExpire", txtMalasianWorkPermitExp.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_MalasianEducationLevel",DropDownList7.SelectedValue.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Religion", txtreligion.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_Sex",DropDownList3.SelectedValue.Trim());

                 _cmd.Parameters.AddWithValue("@Staff_DriverLicense", txtDlicense.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_EmergencyName", txtEmergencyName.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_EmergencyAdd", txtEmergenAddress.Text.Trim());
                 _cmd.Parameters.AddWithValue("@Staff_EmergencyTelphone", txtEmergencContNo.Text.Trim());
                _cmd.Parameters.AddWithValue("@Role",Staff_SubRole);
                _cmd.Parameters.AddWithValue("@UserID", txtStaffUserid.Text.Trim());
                _cmd.Parameters.AddWithValue("@UserPassword", txtStaffUserPassword.Text.Trim());
                _cmd.Parameters.AddWithValue("@Staff_ComfirmPassword", txtStaffuserConfigPassword.Text.Trim());
                  _cmd.Parameters.AddWithValue("@Squrity_Question", SecurityQuestion);
                  //_cmd.Parameters.AddWithValue("@", SecurityQuestion);
                  _cmd.Parameters.AddWithValue("Staff_ID", Staff_ID);
                int result=_cmd.ExecuteNonQuery();
                if(result>0)
                {
                    cn.Close();
                    lblerror1.Text = "Update Successfully ...!";
                }
               
                //HttpContext.Current.Items.Add("COMPLETE", "UPDATE");
                //Server.Transfer("CompleteForm.aspx");

            }
            catch (Exception ex)
            {
                cn.Close();
                logger.Info(ex.Message);
            }
            if (txtFname.Text.Trim() == "")
            {
                errFname.Visible = true;
                lblerror1.Visible = true;
                lblerror1.Text = "Please Fill First Name...!";
                throw new Exception();
            }
            if (txtnric.Text.Trim() == "")
            {
                errnri.Visible = true;
                lblerror1.Visible = true;
                lblerror1.Text = "Please Fill NRIC No...!";
                throw new Exception();
            }
            if (txtStaffUserid.Text.Trim() == "")
            {
                errUserid.Visible = true;
                lblerror1.Visible = true;
                lblerror1.Text = "Please Fill User ID...!";
                throw new Exception();
            }
            if (txtStaffUserPassword.Text.Trim() == "")
            {
                errUserPassword.Visible = true;
                lblerror1.Visible = true;
                lblerror1.Text = "Please Fill User Password...!";
                throw new Exception();
            }
            if (txtStaffuserConfigPassword.Text.Trim() != txtStaffUserPassword.Text.Trim())
            {
                lblerror1.Visible = true;
                lblerror1.Text = "Re-Confirm Password...!";
                throw new Exception();
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


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    Panel2.Visible = true;
                }
                else
                {
                    Panel2.Visible = false;
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

        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {

        }

        protected void cmdViewIssueItem_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=1','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
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

        protected void btnNRICWorkpermit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string NRICWorkpermitPath = hypNRICWorkPermit.NavigateUrl.ToString();
                string path = Server.MapPath(NRICWorkpermitPath);
                dal.executesql("Update Userinformation set Staff_NRICWorkPermitCertificate='' where Staff_ID = '" + Session["Staff_ID"].ToString() + "'");
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
            string UserID = Session["Local_User_Id1"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Local_User_Id1"].ToString() != "")
                {


                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_PrimarySchoolName=@Staff_PrimarySchoolName,Staff_PrimaryAddress=@Staff_PrimaryAddress,Staff_PrimaryLevel=@Staff_PrimaryLevel,Staff_PrimaryFrom=@Staff_PrimaryFrom,Staff_PrimaryTo=@Staff_PrimaryTo,Staff_PrimaryQualification=@Staff_PrimaryQualification,Staff_SecondarySchoolName=@Staff_SecondarySchoolName,Staff_SecondaryAddress=@Staff_SecondaryAddress,Staff_SecondaryLevel=@Staff_SecondaryLevel,Staff_SecondaryFrom=@Staff_SecondaryFrom,Staff_SecondaryTo=@Staff_SecondaryTo,Staff_SecondaryQualification=@Staff_SecondaryQualification,Staff_VocationSchoolName=@Staff_VocationSchoolName,Staff_VocationAddress=@Staff_VocationAddress,Staff_VocationLevel=@Staff_VocationLevel,Staff_VocationFrom=@Staff_VocationFrom,Staff_VocationTo=@Staff_VocationTo,Staff_VocationQualification=@Staff_VocationQualification,Staff_OtherSchoolName=@Staff_OtherSchoolName,Staff_OtherAddress=@Staff_OtherAddress,Staff_OtherLevel=@Staff_OtherLevel,Staff_OtherFrom=@Staff_OtherFrom,Staff_OtherTo=@Staff_OtherTo,Staff_OtherQualification=@Staff_OtherQualification,Staff_OtherTraining=@Staff_OtherTraining where Staff_ID=@UserID", cn);
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
                        lblerror1.Text = "Update Successfully ...!";
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

        protected void cmdbuttonSave3_Click(object sender, EventArgs e)
        {
            string UserID = Session["Local_User_Id1"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Local_User_Id1"].ToString() != "")
                {

                    //cmdbuttonNext3.Enabled = true;
                    //cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_NSFrom=@Staff_NSFrom,Staff_NSTo=@Staff_NSTo,Staff_NSTypeOfDischarge=@Staff_NSTypeOfDischarge,Staff_NSVocation=@Staff_NSVocation,Staff_NSNextInCamp=@Staff_NSNextInCamp,Staff_NSLastRank=@Staff_NSLastRank,Staff_NSExempted=@Staff_NSExempted,Staff_NSReason=@Staff_NSReason,Staff_NSDateOFRegistration=@Staff_NSDateOFRegistration  where Staff_ID=@UserID", cn);
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
                        lblerror1.Text = "Update Successfully ...!";
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

        protected void cmdbuttonSave4_Click(object sender, EventArgs e)
        {
            string UserID = Session["Local_User_Id1"].ToString();

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Local_User_Id1"].ToString() != "")
                {
                    string Nricworkpermit = string.Empty;
                    string NSRSWSQModules = string.Empty;
                    string OtherRecognisedCertificate = string.Empty;

                    string ExemptionCertificate = string.Empty;
                    string SecurityOfficerLicense = string.Empty;
                    string SIRDScreen = string.Empty;
                    if (txtNricworkpermit.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNricworkpermit.PostedFile.SaveAs(path + txtNricworkpermit.FileName);
                        if (txtNricworkpermit.FileName.EndsWith(".exe"))
                        {
                        }
                        else
                        {
                            Nricworkpermit = "~/FileUpload/" + txtNricworkpermit.FileName;
                        }


                    }
                    else
                    {
                        Nricworkpermit = lnkLabel1.Text;
                    }
                    if (txtNSRSWQ.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNSRSWQ.PostedFile.SaveAs(path + txtNSRSWQ.FileName);
                        if (txtNSRSWQ.FileName.EndsWith(".exe"))
                        {

                        }
                        else
                        {
                            NSRSWSQModules = "~/FileUpload/" + txtNSRSWQ.FileName;
                        }

                    }
                    else
                    {
                        NSRSWSQModules = lnkLabel2.Text;
                    }
                    if (txtotherRecognised.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtotherRecognised.PostedFile.SaveAs(path + txtotherRecognised.FileName);
                        if (txtotherRecognised.FileName.EndsWith(".exe"))
                        {
                        }
                        else
                        {
                            OtherRecognisedCertificate = "~/FileUpload/" + txtotherRecognised.FileName;
                        }

                    }
                    else
                    {
                        OtherRecognisedCertificate= lnkLabel3.Text;
                    }
                    if (txtExemptionCertificate.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtExemptionCertificate.PostedFile.SaveAs(path + txtExemptionCertificate.FileName);
                        if (txtExemptionCertificate.FileName.EndsWith(".exe")) { }
                        else { ExemptionCertificate = "~/FileUpload/" + txtExemptionCertificate.FileName; }

                    }
                    else
                    {
                        ExemptionCertificate= lnkLabel4.Text;
                    }
                    if (txtSecurityOfficerLicense.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSecurityOfficerLicense.PostedFile.SaveAs(path + txtSecurityOfficerLicense.FileName);
                        if (txtSecurityOfficerLicense.FileName.EndsWith(".exe")) { }
                        else { SecurityOfficerLicense = "~/FileUpload/" + txtSecurityOfficerLicense.FileName; }

                    }
                    else
                    {
                        SecurityOfficerLicense=lnkLabel5.Text;
                    }
                    if (txtSIRDscreen.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSIRDscreen.PostedFile.SaveAs(path + txtSIRDscreen.FileName);
                        if (txtSIRDscreen.FileName.EndsWith(".exe")) { }
                        else { SIRDScreen = "~/FileUpload/" + txtSIRDscreen.FileName; }

                    }
                    else
                    {
                        SIRDScreen=lnkLabel6.Text;
                    }
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_EmpExCompName1=@Staff_EmpExCompName1,Staff_EmpExFrom1=@Staff_EmpExFrom1,Staff_EmpExTo1=@Staff_EmpExTo1,Staff_EmpExReasonLeaving1=@Staff_EmpExReasonLeaving1, Staff_EmpExLastDrawnSalary1=@Staff_EmpExLastDrawnSalary1, Staff_EmpExCompName2=@Staff_EmpExCompName2,Staff_EmpExFrom2=@Staff_EmpExFrom2,Staff_EmpExTo2=@Staff_EmpExTo2,Staff_EmpExReasonLeaving2=@Staff_EmpExReasonLeaving2,Staff_EmpExLastDrawnSalary2=@Staff_EmpExLastDrawnSalary2,Staff_EmpExCompName3=@Staff_EmpExCompName3,Staff_EmpExFrom3=@Staff_EmpExFrom3,Staff_EmpExTo3=@Staff_EmpExTo3,Staff_EmpExReasonLeaving3=@Staff_EmpExReasonLeaving3,Staff_EmpExLastDrawnSalary3=@Staff_EmpExLastDrawnSalary3,Staff_EmpExCompName4=@Staff_EmpExCompName4,Staff_EmpExFrom4=@Staff_EmpExFrom4,Staff_EmpExTo4=@Staff_EmpExTo4,Staff_EmpExReasonLeaving4=@Staff_EmpExReasonLeaving4,Staff_EmpExLastDrawnSalary4=@Staff_EmpExLastDrawnSalary4,Staff_ExpectedSalary=@Staff_ExpectedSalary,Staff_CommenceWork=@Staff_CommenceWork,Staff_LAW=@Staff_LAW,Staff_LAWResion=@Staff_LAWResion,Staff_Injury=@Staff_Injury,Staff_InjuryResion=@Staff_InjuryResion,Staff_NRICWorkPermitCertificate=@Staff_NRICWorkPermitCertificate,Staff_NSRSWSQModulesCertificate=@Staff_NSRSWSQModulesCertificate,Staff_OtherRecognisedCertificate=@Staff_OtherRecognisedCertificate,Staff_ExemptionCertificate=@Staff_ExemptionCertificate,Staff_SecurityOfficerLicenseCertificate=@Staff_SecurityOfficerLicenseCertificate,Staff_SIRDScreenCertificate=@Staff_SIRDScreenCertificate where Staff_ID=@UserID", cn);
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
                        lblerror1.Text = "Update Successfully ...!";
                        cn.Close();

                    }
                }
                else
                {
                    lblerror1.Visible = true;
                    //lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }


        }

        protected void cmdbuttonSave5_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();

            string path = "";
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                if (Session["Local_User_Id1"].ToString() != "")
                {

                    if (Session["CaptureImagePath"] == null)
                    {
                        if (FileUpload1.HasFile)
                        {
                            para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                            string file = FileUpload1.PostedFile.FileName;
                            string thubpath = ("~/ADMIN" + "/" + file);
                            FileUpload1.PostedFile.SaveAs(Server.MapPath(file));
                            para[0].Value = thubpath;
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                            cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1.Visible = true;
                                lblerror1.Text = "Update Successfully ...!";
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
                            cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1.Visible = true;
                                lblerror1.Text = "Update Successfully ...!";
                                cn.Close();
                                // Response.Redirect("CompleteForm.aspx");
                            }
                        }

                    }
                    else
                    {
                        if (Session["CaptureImage"] != null)
                        {
                            if (FileUpload1.HasFile)
                            {
                                para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                                string file = FileUpload1.PostedFile.FileName;
                                string thubpath = ("~/ADMIN" + "/" + file);
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(file));
                                //para[0].Value = "~/ADMIN/" + Session["CaptureImage"].ToString();
                                para[0].Value = thubpath;
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                                cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    lblerror1.Visible = true;
                                    lblerror1.Text = "Update Successfully ...!";
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
                                cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    lblerror1.Visible = true;
                                    lblerror1.Text = "Update Successfully ...!";
                                    cn.Close();
                                    //Response.Redirect("CompleteForm.aspx");
                                }
                            }

                            //Session["CaptureImage"] = null;
                        }
                        else
                        {
                            if (FileUpload1.HasFile)
                            {
                                para[0] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                                string file = FileUpload1.PostedFile.FileName;
                                string thubpath = ("~/ADMIN" + "/" + file);
                                FileUpload1.PostedFile.SaveAs(Server.MapPath(file));
                                para[0].Value = thubpath;
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                                //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                                cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    lblerror1.Visible = true;
                                    lblerror1.Text = "Update Successfully ...!";
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
                        if (hdnFP.Value.Length > 15)
                        {
                            para[1] = new SqlParameter("@ThumbPrint", SqlDbType.VarBinary);
                            para[1].Value = HexsToArray(hdnFP.Value);
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ThumbImage=@ThumbImage where Staff_ID=@UserID", cn);
                            //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@ThumbImage", para[1].Value);
                            cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                lblerror1.Visible = true;
                                lblerror1.Text = "Update Successfully ...!";
                                cn.Close();
                                // Response.Redirect("CompleteForm.aspx");
                            }
                        }
                        else
                        {
                            para[1] = new SqlParameter("@ThumbPrint", SqlDbType.VarBinary);
                            para[1].Value = HexsToArray(hdnFP.Value);
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("update UserInformation set ThumbImage=@ThumbImage where Staff_ID=@UserID", cn);
                            //cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                            cmd.Parameters.AddWithValue("@ThumbImage", para[1].Value);
                            cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                            //if (cmd.ExecuteNonQuery() > 0)
                            //{
                            //    lblerror1.Visible = true;
                            //    lblerror1.Text = "Update Successfully ...!";
                            //    cn.Close();
                            //    Response.Redirect("CompleteForm.aspx");
                            //}
                            lblerror1.Visible = true;
                            lblerror1.Text = "Update successfully.!";
                            //Response.Redirect("CompleteForm.aspx");
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName where Staff_ID=@UserID", cn);
                        cmd.Parameters.AddWithValue("@ImagePathName", para[0].Value);
                        cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id1"].ToString());
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            lblerror1.Visible = true;
                            lblerror1.Text = "Update Successfully ...!";
                            cn.Close();
                            //Response.Redirect("CompleteForm.aspx");
                        }
                    }
                }
               // Response.Redirect("CompleteForm.aspx", false);
            }
            catch (Exception ex)
            {
                cn.Close();
                logger.Info(ex.Message);
            }
         }
    }
}
