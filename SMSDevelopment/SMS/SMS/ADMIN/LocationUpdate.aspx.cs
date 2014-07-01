using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.ADMIN
{
    public partial class LocationUpdate : System.Web.UI.Page
    {
        String status = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


            String iBTID = String.Empty;
            lblerr.Visible = false;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (!IsPostBack)
                {
                    //Session["path"] = Request.Url.AbsolutePath;            
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL,btnSave.ID,SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                        string path = Request["path"];
                        Session["path"] = path;
                    }

                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["path"].ToString() == "PresentSite.aspx")
                {
                    Response.Redirect("PresentSite.aspx");
                }
                if (Session["path"].ToString() == "PastSite.aspx")
                {
                    Response.Redirect("PastSite.aspx");
                }
                // Response.Redirect("../SMS/Admin/AdminLocation.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                LocationData objLocation_Data = new LocationData();
                AdminBLL ws = new AdminBLL();

                if (txtAddLocation.Text.Trim() != "")
                {

                    objLocation_Data.Location_id = txtUpdateLocationName.Text.Trim();
                    Session["location_id"] = txtUpdateLocationName.Text.Trim();
                    objLocation_Data.Location_name = txtAddLocation.Text.Trim();
                    objLocation_Data.Loc_Address = txtsiteaddres.Text.Trim();

                    objLocation_Data.Finance_Name = txtFinaceName.Text.Trim();
                    objLocation_Data.F_cont = txtFinanceContactTel.Text.Trim();
                    objLocation_Data.F_Mob = txtFinanceContactMob.Text.Trim();
                    objLocation_Data.F_Email = txtFinanceContactEmail.Text.Trim();
                    objLocation_Data.F_Fax = txtFinanceContactFax.Text.Trim();

                    objLocation_Data.Operation_Name = txtOperationName.Text.Trim();
                    objLocation_Data.O_cont = txtOperationsContactTelephone.Text.Trim();
                    objLocation_Data.O_Mob = txtOperationsContactMobile.Text.Trim();
                    objLocation_Data.O_Email = txtOperationsContactEmail.Text.Trim();
                    objLocation_Data.O_Fax = txtOperationsContactFax.Text.Trim();

                    objLocation_Data.Management_Name = txtManagementName.Text.Trim();
                    objLocation_Data.M_cont = txtlblManagementContactTelephone.Text.Trim();
                    objLocation_Data.M_Mob = txtManagementContactMobile.Text.Trim();
                    objLocation_Data.M_Email = txtManagementContactEmail.Text.Trim();
                    objLocation_Data.M_Fax = txtManagementContactFax.Text.Trim();

                    objLocation_Data.Emergency_email = txtEmergencyContactEmail.Text.Trim();

                    objLocation_Data.Chift_Security_day = txtChiefSecurityRequiredDay.Text.Trim();
                    objLocation_Data.Chift_Security_nig = txtChiefSecurityRequiredEvening.Text.Trim();

                    objLocation_Data.Security_Off_day = txtSODay.Text.Trim();
                    objLocation_Data.Security_Off_nig = txtSONight.Text.Trim();

                    objLocation_Data.Senior_Secu_Off_day = TxtSSODay.Text.Trim();
                    objLocation_Data.Senior_Secu_Off_nig = txtSSONight.Text.Trim();

                    objLocation_Data.Supervisor_day = txtsupervisorrequiredDay.Text.Trim();
                    objLocation_Data.Supervisor_nig = txtSupervisorRequireNight.Text.Trim();

                    objLocation_Data.Contract_value = txtContractValue.Text.Trim();
                    if (txtdatefrom.Text.Trim() != "")
                    {
                        objLocation_Data.Contract_start_date = Convert.ToDateTime(txtdatefrom.Text);
                    }
                    if (txtdateto.Text.Trim() != "")
                    {
                        objLocation_Data.Contract_expire_date = Convert.ToDateTime(txtdateto.Text);
                    }
                    objLocation_Data.Date_From = Convert.ToDateTime(DateTime.Now);

                    objLocation_Data.Finance_Name = txtFinaceName.Text.Trim();
                    objLocation_Data.Operation_Name = txtOperationName.Text.Trim();
                    objLocation_Data.Management_Name = txtManagementName.Text.Trim();

                    objLocation_Data.OtherPerson1 = txtOther1.Text.Trim();
                    objLocation_Data.OtherPerson1_day = txtOther1_day.Text.Trim();
                    objLocation_Data.OtherPerson1_nig = txtOther1_nig.Text.Trim();

                    objLocation_Data.OtherPerson2 = txtOther2.Text.Trim();
                    objLocation_Data.OtherPerson2_day = txtOther2_day.Text.Trim();
                    objLocation_Data.OtherPerson2_nig = txtOther2_nig.Text.Trim();

                    objLocation_Data.OtherPerson3 = txtOther3.Text.Trim();
                    objLocation_Data.OtherPerson3_day = txtOther3_day.Text.Trim();
                    objLocation_Data.OtherPerson3_nig = txtOther3_nig.Text.Trim();

                    objLocation_Data.ClientUserID = txtClientUserID.Text.Trim();

                    ws.UpdateLocationData(objLocation_Data);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                }
                else
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Invalid Site Name ..!";
                    lblerr.Visible = true;

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
            GetLocationDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetLocationData objGetBillingTableRequest = new GetLocationData();
                objGetBillingTableRequest.locid = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Location_id= '" + argsBGID + "'";
                ret = objAdminBLL.GetLocationData(objGetBillingTableRequest);

                hdnBTID.Value = ret.Location[iCount].Location_id.ToString();
                hdnBTID.Value = ret.Location[iCount].Location_name.ToString();

                txtUpdateLocationName.Text = ret.Location[iCount].Location_id.ToString();
                txtAddLocation.Text = ret.Location[iCount].Location_name.ToString();
                txtsiteaddres.Text = ret.Location[iCount].Loc_Address.ToString();

                txtFinanceContactTel.Text = ret.Location[iCount].F_cont.ToString();
                txtFinanceContactMob.Text = ret.Location[iCount].F_Mob.ToString();
                txtFinanceContactEmail.Text = ret.Location[iCount].F_Email.ToString();
                txtFinanceContactFax.Text = ret.Location[iCount].F_Fax.ToString();

                txtOperationsContactTelephone.Text = ret.Location[iCount].O_cont.ToString();
                txtOperationsContactMobile.Text = ret.Location[iCount].O_Mob.ToString();
                txtOperationsContactEmail.Text = ret.Location[iCount].O_Email.ToString();
                txtOperationsContactFax.Text = ret.Location[iCount].O_Fax.ToString();

                txtlblManagementContactTelephone.Text = ret.Location[iCount].M_cont.ToString();
                txtManagementContactMobile.Text = ret.Location[iCount].M_Mob.ToString();
                txtManagementContactEmail.Text = ret.Location[iCount].O_Email.ToString();
                txtManagementContactFax.Text = ret.Location[iCount].O_Fax.ToString();

                txtEmergencyContactEmail.Text = ret.Location[iCount].Emergency_email.ToString();

                txtChiefSecurityRequiredDay.Text = ret.Location[iCount].Chift_Security_day.ToString();
                txtChiefSecurityRequiredEvening.Text = ret.Location[iCount].Chift_Security_nig.ToString();

                txtSODay.Text = ret.Location[iCount].Security_Off_day.ToString();
                txtSONight.Text = ret.Location[iCount].Security_Off_nig.ToString();

                TxtSSODay.Text = ret.Location[iCount].Senior_Secu_Off_day.ToString();
                txtSSONight.Text = ret.Location[iCount].Senior_Secu_Off_nig.ToString();

                txtsupervisorrequiredDay.Text = ret.Location[iCount].Supervisor_day.ToString();
                txtSupervisorRequireNight.Text = ret.Location[iCount].Supervisor_nig.ToString();

                txtContractValue.Text = ret.Location[iCount].Contract_value.ToString();
                txtdatefrom.Text = ret.Location[iCount].Contract_start_date.ToString();
                txtdateto.Text = ret.Location[iCount].Contract_expire_date.ToString();

                txtFinaceName.Text = ret.Location[iCount].Finance_Name.ToString();
                txtOperationName.Text = ret.Location[iCount].Operation_Name.ToString();
                txtManagementName.Text = ret.Location[iCount].Management_Name.ToString();

                txtOther1.Text = ret.Location[iCount].OtherPerson1.ToString();
                txtOther1_day.Text = ret.Location[iCount].OtherPerson1_day.ToString();
                txtOther1_nig.Text = ret.Location[iCount].OtherPerson1_nig.ToString();

                txtOther2.Text = ret.Location[iCount].OtherPerson2.ToString();
                txtOther2_day.Text = ret.Location[iCount].OtherPerson2_day.ToString();
                txtOther2_nig.Text = ret.Location[iCount].OtherPerson2_nig.ToString();

                txtOther3.Text = ret.Location[iCount].OtherPerson3.ToString();
                txtOther3_day.Text = ret.Location[iCount].OtherPerson3_day.ToString();
                txtOther3_nig.Text = ret.Location[iCount].OtherPerson3_nig.ToString();

                txtClientUserID.Text = ret.Location[iCount].ClientUserID.ToString();



            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void btnSave1_Click(object sender, EventArgs e)
        {

            string location_name = Session["location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["location_id"].ToString() != "")
                {
                   
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Finance_Name=@Finance_Name,F_cont=@F_cont,F_Mob=@F_Mob,F_Email=@F_Email,F_Fax=@F_Fax where Location_name=@Location_name", cn);
                    cmd.Parameters.AddWithValue("@Finance_Name", txtFinaceName.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_cont", txtFinanceContactTel.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Mob", txtFinanceContactMob.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Email", txtFinanceContactEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Fax", txtFinanceContactFax.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_name", txtAddLocation.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnSave2_Click(object sender, EventArgs e)
        {

            string location_name = Session["location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["location_id"].ToString() != "")
                {
                    
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Operation_Name=@Operation_Name,O_cont=@O_cont,O_Mob=@O_Mob,O_Email=@O_Email,O_Fax=@O_Fax where Location_name=@Location_name", cn);
                    cmd.Parameters.AddWithValue("@Operation_Name", txtOperationName.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_cont", txtOperationsContactTelephone.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Mob", txtOperationsContactMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Email", txtOperationsContactEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Fax", txtOperationsContactFax.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_name", txtAddLocation.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnSave3_Click(object sender, EventArgs e)
        {
            string location_name = Session["location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["location_id"].ToString() != "")
                {
                    
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Management_Name=@Management_Name,M_cont=@M_cont,M_Mob=@M_Mob,M_Email=@M_Email,M_Fax=@M_Fax,Emergency_email=@Emergency_email where Location_name=@Location_name", cn);
                    cmd.Parameters.AddWithValue("@Management_Name", txtManagementName.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_cont", txtlblManagementContactTelephone.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Mob", txtManagementContactMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Email", txtManagementContactEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Fax", txtManagementContactFax.Text.Trim());
                    cmd.Parameters.AddWithValue("@Emergency_email", txtEmergencyContactEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_name", txtAddLocation.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
