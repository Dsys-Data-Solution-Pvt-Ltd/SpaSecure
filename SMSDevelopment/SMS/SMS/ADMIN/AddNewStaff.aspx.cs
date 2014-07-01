using System;
using DPFP;
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
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using System.Globalization;
using SMS.SMSAppUtilities;
using SMS.Services.DALUtilities;
namespace SMS.ADMIN
{
    public partial class AddNewStaff : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string Staff_ID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Disable();
                lblerror1.Visible = false;
                lblnri5.Visible = false;
                errUserPassword.Visible = false;
                errnri.Visible = false;
                errFname.Visible = false;
                errUserid.Visible = false;

                if (!IsPostBack)
                {
                    fillrole();
                    fillSecurityqust();

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
        public void Disable()
        {
            cmdbuttonFinish.Enabled = false;
            //cmdbuttonFinish1.Enabled = false;
            cmdbuttonFinish3.Enabled = false;
            cmdbuttonFinish4.Enabled = false;
            cmdbuttonFinish5.Enabled = false;
            cmdbuttonFinish6.Enabled = false;
            cmdbuttonNext.Enabled = false;
            //cmdbuttonNext1.Enabled = false;
            cmdbuttonNext3.Enabled = false;
            cmdbuttonNext4.Enabled = false;
            cmdbuttonNext5.Enabled = false;
        }

        protected void cmdbuttonSave_Click(object sender, EventArgs e)
        {
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
                    lblerror1.Text = "Re-Confirm Password..!";
                    throw new Exception();
                }
                if (ddlRole.SelectedValue.Trim() == "")
                {
                    errddlRole.Visible = true;
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill User SubRole...!";
                    throw new Exception();
                }
                if (txtStaffUserid.Text.Trim() != "")
                {
                    DataTable dtverifyUserid = dal.getdata("Select NRICno from UserInformation where UserID='" + txtStaffUserid.Text.Trim() + "' ");
                    if (dtverifyUserid.Rows.Count > 0)
                    {
                        lblerror1.Visible = true;
                        lblerror1.Text = "UserID Already Exists..!";
                        throw new Exception();
                    }
                }

                #region AddStaff

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
                string Staff_Mobile = string.Empty;
                string SecurityQus = ddlStaffSecQues.Text.Trim();


                if (txtNricworkpermit.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtNricworkpermit.PostedFile.SaveAs(path + txtNricworkpermit.FileName);
                    Nricworkpermit = "~/FileUpload/" + txtNricworkpermit.FileName;

                }
                if (txtNSRSWQ.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtNSRSWQ.PostedFile.SaveAs(path + txtNSRSWQ.FileName);
                    NSRSWSQModules = "~/FileUpload/" + txtNSRSWQ.FileName;
                }
                if (txtotherRecognised.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtotherRecognised.PostedFile.SaveAs(path + txtotherRecognised.FileName);
                    OtherRecognisedCertificate = "~/FileUpload/" + txtotherRecognised.FileName;
                }
                if (txtExemptionCertificate.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtExemptionCertificate.PostedFile.SaveAs(path + txtExemptionCertificate.FileName);
                    ExemptionCertificate = "~/FileUpload/" + txtExemptionCertificate.FileName;
                }
                if (txtSecurityOfficerLicense.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtSecurityOfficerLicense.PostedFile.SaveAs(path + txtSecurityOfficerLicense.FileName);
                    SecurityOfficerLicense = "~/FileUpload/" + txtSecurityOfficerLicense.FileName;
                }
                if (txtSIRDscreen.HasFile)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    txtSIRDscreen.PostedFile.SaveAs(path + txtSIRDscreen.FileName);
                    SIRDScreen = "~/FileUpload/" + txtSIRDscreen.FileName;
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
                para[106] = new SqlParameter("@LastActivityTime", SqlDbType.DateTime,50);
                string date = DateTime.Now.ToString();
                para[106].Value = date;

                dal.executeprocedure("usp_EnrollStaff", para);
                lblerror1.Visible = true;
                lblerror1.Text = "Insert Successfully....!";
                // AllClear();
                if (Staff_SubRole == "Security Officers" || Staff_SubRole == "Supervisor")
                {
                    AssignAllLocation(Session["Staff_ID_LOCAL"].ToString());
                }
                UpdateStock();
                cmdbuttonNext.Enabled = true;
                cmdbuttonFinish.Enabled = true;

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Session["Staff_ID"] = Session["Staff_ID_LOCAL"].ToString();
                Session["Staff_ID_LOCAL"] = null;
                // Server.Transfer("..//ADMIN//ItemIssued.aspx");

                #endregion


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            cmdbuttonNext.Enabled = true;
            cmdbuttonFinish.Enabled = true;
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

        private void UpdateStockCommit(string type, string name, int qty)
        {
            string UpdateQuery = "update AddNEwINvetory set Item_qty = Item_qty -" + qty + " where item_name='" + name + "' and Item_Type='" + type + "'";
            dal.executesql(UpdateQuery);
        }

        private void AllClear()
        {
            //DropDownList1.Text = "";
            txtFname.Text = "";
            txtMname.Text = "";
            txtLname.Text = "";
            txtHomeAdress.Text = "";
            txtPhone.Text = "";
            txtMobNo.Text = "";
            txtHP.Text = "";
            txtDOB.Text = "";
            txtPOB.Text = "";
            txtrace.Text = "";
            //DropDownList2.Text = "";
            txtage.Text = "";
            txtreligion.Text = "";
            //DropDownList3.Text = "";
            txtDlicense.Text = "";
            txtincometax.Text = "";

            //DropDownList4.Text = "";
            txtnoOfChildern.Text = "";
            txtSpousename.Text = "";
            txtEmergencyName.Text = "";
            txtEmergenAddress.Text = "";
            txtEmergencContNo.Text = "";

            txtEDnameofSchool1.Text = "";
            txtEDaddres1.Text = "";
            txtEDLeve1.Text = "";
            txtEDFrom1.Text = "";
            txtEDTo1.Text = "";
            txtEDqualification1.Text = "";

            txtEDnameofSchool2.Text = "";
            txtEDaddres2.Text = "";
            txtEDLeve2.Text = "";
            txtEDFrom2.Text = "";
            txtEDTo2.Text = "";
            txtEDqualification2.Text = "";

            txtEDnameofSchool3.Text = "";
            txtEDaddres3.Text = "";
            txtEDLeve3.Text = "";
            txtEDFrom3.Text = "";
            txtEDTo3.Text = "";
            txtEDqualification3.Text = "";

            txtEDnameofSchool4.Text = "";
            txtEDaddres4.Text = "";
            txtEDLeve4.Text = "";
            txtEDFrom4.Text = "";
            txtEDTo4.Text = "";
            txtEDqualification4.Text = "";

            txtotherSkills.Text = "";
            txthobbies.Text = "";
            txtNSTime.Text = "";
            txtNSTo.Text = "";
            txtNSTypeofDischarge.Text = "";
            txtNSVocation.Text = "";
            txtNSNextInCamp.Text = "";
            txtNSLastRank.Text = "";
            txtNSExempted.Text = "";
            txtNSReason.Text = "";
            txtNSPeriod.Text = "";

            txtEnameofCompany1.Text = "";
            txtEFrom1.Text = "";
            txtETo1.Text = "";
            txtEReasonleave1.Text = "";
            txtELastDraw1.Text = "";

            txtEnameofCompany2.Text = "";
            txtEFrom2.Text = "";
            txtETo2.Text = "";
            txtEReasonleave2.Text = "";
            txtELastDraw2.Text = "";

            txtEnameofCompany3.Text = "";
            txtEFrom3.Text = "";
            txtETo3.Text = "";
            txtEReasonleave3.Text = "";
            txtELastDraw3.Text = "";

            txtEnameofCompany4.Text = "";
            txtEFrom4.Text = "";
            txtETo4.Text = "";
            txtEReasonleave4.Text = "";
            txtELastDraw4.Text = "";


            txtexpectedSalary.Text = "";
            txtcommencework.Text = "";
            // DropDownList5.Text = "";
            txtLAWyes.Text = "";
            // DropDownList6.Text = "";
            txtInjuryyes.Text = "";

            txtStaffUserPassword.Text = "";
            txtStaffuserConfigPassword.Text = "";
            //ddlRole.Text = "";
            txtStaffSeurityqty.Text = "";
            txtStaffUserid.Text = "";
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

        protected void cmdbuttonadd_Click(object sender, EventArgs e)
        {

        }



        protected void cmdIssueItem_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=0','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
        }

        protected void cmdViewIssueItem_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('InventoryOut.aspx?id=1','InventoryOut','height=250px,width=700px,scrollbars=1');</script>");
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

        protected void chkAgree_CheckedChanged(object sender, EventArgs e)
        {

        }



        protected void cmdbuttonNext_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 2;

        }

        protected void cmdbuttonFinish_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }
        protected void cmdbuttonSave1_Click(object sender, EventArgs e)
        {
            //cmdbuttonNext1.Enabled = true;
            //cmdbuttonFinish1.Enabled = true;
        }

        protected void cmdbuttonNext1_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 3;

        }

        protected void cmdbuttonFinish1_Click(object sender, EventArgs e)
        {
            Server.Transfer("..//ADMIN//ItemIssued.aspx");
        }

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
                    }
                }
                else
                {
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill First Information....!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            //-------------------------------------------------------------
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
                    }
                }
                else
                {
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill First Information....!";
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
                    if (txtNricworkpermit.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNricworkpermit.PostedFile.SaveAs(path + txtNricworkpermit.FileName);
                        Nricworkpermit = "~/FileUpload/" + txtNricworkpermit.FileName;

                    }
                    if (txtNSRSWQ.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNSRSWQ.PostedFile.SaveAs(path + txtNSRSWQ.FileName);
                        NSRSWSQModules = "~/FileUpload/" + txtNSRSWQ.FileName;
                    }
                    if (txtotherRecognised.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtotherRecognised.PostedFile.SaveAs(path + txtotherRecognised.FileName);
                        OtherRecognisedCertificate = "~/FileUpload/" + txtotherRecognised.FileName;
                    }
                    if (txtExemptionCertificate.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtExemptionCertificate.PostedFile.SaveAs(path + txtExemptionCertificate.FileName);
                        ExemptionCertificate = "~/FileUpload/" + txtExemptionCertificate.FileName;
                    }
                    if (txtSecurityOfficerLicense.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSecurityOfficerLicense.PostedFile.SaveAs(path + txtSecurityOfficerLicense.FileName);
                        SecurityOfficerLicense = "~/FileUpload/" + txtSecurityOfficerLicense.FileName;
                    }
                    if (txtSIRDscreen.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSIRDscreen.PostedFile.SaveAs(path + txtSIRDscreen.FileName);
                        SIRDScreen = "~/FileUpload/" + txtSIRDscreen.FileName;
                    }
                    cmdbuttonNext3.Enabled = true;
                    cmdbuttonFinish3.Enabled = true;
                    //-------------------update staff------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update UserInformation set Staff_EmpExCompName1=@Staff_EmpExCompName1,  where UserID=@UserID", cn);
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
                    }
                }
                else
                {
                    lblerror1.Visible = true;
                    lblerror1.Text = "Please Fill First Information....!";
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
            cn.Open();           
            if (Session["Local_User_Id"] != null)
            {
                try
                {
                    SqlParameter[] para = new SqlParameter[2];
                    para[0] = new SqlParameter("@ThumbImage", SqlDbType.VarBinary);
                    //para[0].Value = HexsToArray(TextBox1.Text);
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

                        if (FileUpload1.HasFile)
                        {
                            para[1] = new SqlParameter("@ImagePathName", SqlDbType.VarChar, 500);
                            string file = FileUpload1.PostedFile.FileName;
                            string thubpath = ("~/ADMIN" + "/" + file);
                            FileUpload1.PostedFile.SaveAs(Server.MapPath(file));
                            para[1].Value = thubpath;

                        }
                        else
                        {
                            lblerror1.Visible = true;
                            lblerror1.Text = "Please choose file !!!";
                        }
                    }
                    SqlCommand cmd = new SqlCommand("update UserInformation set ImagePathName=@ImagePathName,ThumbImage=@ThumbImage where UserID=@UserID", cn);
                    cmd.Parameters.AddWithValue("@ImagePathName", para[1].Value);
                    cmd.Parameters.AddWithValue("@ThumbImage", para[0].Value);
                    cmd.Parameters.AddWithValue("@UserID", Session["Local_User_Id"].ToString());
                    //int x=cmd.e
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        lblerror1.Visible = true;
                        lblerror1.Text = "Add Successfully ...!";
                        cn.Close();
                        Session["CaptureImagePath2"] = "";
                    }

                }
                catch (Exception exc)
                {
                    logger.Info(exc.Message);
                }
            }
            cmdbuttonFinish6.Enabled = true;
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
                    if (txtnric.Text.Trim() != "")
                    {
                        DataTable dtverifyUserid = dal.getdata("Select UserID from UserInformation where NRICno='" + txtnric.Text.Trim() + "' ");
                        if (dtverifyUserid.Rows.Count > 0)
                        {
                            lblerror1.Visible = true;
                            lblerror1.Text = "NRINo Already Exists..!";
                            throw new Exception();
                        }
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
                        lblerror1.Text = "Re-Confirm Password..!";
                        throw new Exception();
                    }
                    if (ddlRole.SelectedValue.Trim() == "")
                    {
                        errddlRole.Visible = true;
                        lblerror1.Visible = true;
                        lblerror1.Text = "Please Fill User SubRole...!";
                        throw new Exception();
                    }
                    if (txtStaffUserid.Text.Trim() != "")
                    {
                        DataTable dtverifyUserid = dal.getdata("Select NRICno from UserInformation where UserID='" + txtStaffUserid.Text.Trim() + "' ");
                        if (dtverifyUserid.Rows.Count > 0)
                        {
                            lblerror1.Visible = true;
                            lblerror1.Text = "UserID Already Exists..!";
                            throw new Exception();
                        }
                    }

                    #region AddStaff

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
                    string Staff_Mobile = string.Empty;
                    string SecurityQus = ddlStaffSecQues.Text.Trim();


                    if (txtNricworkpermit.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNricworkpermit.PostedFile.SaveAs(path + txtNricworkpermit.FileName);
                        Nricworkpermit = "~/FileUpload/" + txtNricworkpermit.FileName;

                    }
                    if (txtNSRSWQ.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtNSRSWQ.PostedFile.SaveAs(path + txtNSRSWQ.FileName);
                        NSRSWSQModules = "~/FileUpload/" + txtNSRSWQ.FileName;
                    }
                    if (txtotherRecognised.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtotherRecognised.PostedFile.SaveAs(path + txtotherRecognised.FileName);
                        OtherRecognisedCertificate = "~/FileUpload/" + txtotherRecognised.FileName;
                    }
                    if (txtExemptionCertificate.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtExemptionCertificate.PostedFile.SaveAs(path + txtExemptionCertificate.FileName);
                        ExemptionCertificate = "~/FileUpload/" + txtExemptionCertificate.FileName;
                    }
                    if (txtSecurityOfficerLicense.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSecurityOfficerLicense.PostedFile.SaveAs(path + txtSecurityOfficerLicense.FileName);
                        SecurityOfficerLicense = "~/FileUpload/" + txtSecurityOfficerLicense.FileName;
                    }
                    if (txtSIRDscreen.HasFile)
                    {
                        string path = Server.MapPath("~/FileUpload/");
                        txtSIRDscreen.PostedFile.SaveAs(path + txtSIRDscreen.FileName);
                        SIRDScreen = "~/FileUpload/" + txtSIRDscreen.FileName;
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

                    dal.executeprocedure("usp_EnrollStaff", para);
                    lblerror1.Visible = true;
                    lblerror1.Text = "Insert Successfully....!";
                    // AllClear();
                    if (Staff_SubRole == "Security Officers" || Staff_SubRole == "Supervisor")
                    {
                        AssignAllLocation(Session["Staff_ID_LOCAL"].ToString());
                    }
                    UpdateStock();
                    cmdbuttonNext.Enabled = true;
                    cmdbuttonFinish.Enabled = true;

                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Session["Staff_ID"] = Session["Staff_ID_LOCAL"].ToString();
                    Session["Staff_ID_LOCAL"] = null;
                    // Server.Transfer("..//ADMIN//ItemIssued.aspx");

                    #endregion


                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
                cmdbuttonNext.Enabled = true;
                cmdbuttonFinish.Enabled = true;

           
        }


    }
}
