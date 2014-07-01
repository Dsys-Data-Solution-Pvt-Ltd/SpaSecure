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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using log4net;
using log4net.Config;
using SMS.Services.DataService;
using System.Data.SqlClient;
using SMS.Services.DALUtilities;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.ADMIN
{
    public partial class AddNewSite : System.Web.UI.Page
    {
        DataAccessLayer Dal = new DataAccessLayer();
        AdminDAL adal = new AdminDAL();
        AdminBLL bll = new AdminBLL();

        String ZipRegexboth = "^[a-z A-Z 0-9]+$";
        string Staff_ID = string.Empty;
        string Location_ID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                disable();
                txtAddLocation.Focus();
                PnlOther.Visible = false;
                lblerror.Visible = false;
                lblerr.Visible = false;
                if (!IsPostBack)
                {
                    //  PnlOther.Visible = false;
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public void disable()
        {
            btnNextLocationAdd.Enabled=false;
            btnClearLocationAdd.Enabled=false;
            //btnSearch1LocationAdd.Enabled = false;
            btnNext1LocationAdd.Enabled = false;
            btnClear1LocationAdd.Enabled = false;
            //btnSearch2LocationAdd.Enabled = false;
            btnNext2LocationAdd.Enabled = false;
            btnClear2LocationAdd.Enabled = false;
            //btnSearch3LocationAdd.Enabled = false;
            btnClear3LocationAdd.Enabled = false;
            

        }
        private void getStaffID()
        {
            DataSet dsStaff = Dal.getdataset("SELECT part from SplitString(convert(varchar(100),newid()),'-') where id = (select max(id) from SplitString(convert(varchar(100),newid()),'-'))");
            if (dsStaff.Tables[0].Rows.Count > 0)
            {
                Staff_ID = dsStaff.Tables[0].Rows[0][0].ToString().Trim();
            }
        }
        private void getLocationID()
        {
            DataSet dslocation = Dal.getdataset(" SELECT Top(1) Location_id From location order by Location_id desc");
            if (dslocation.Tables[0].Rows.Count > 0)
            {
                Location_ID = dslocation.Tables[0].Rows[0][0].ToString().Trim();
            }
        }

        private int chkloc(string locname, string locadd)
        {
            int k = 0;
            SqlDataReader rd = Dal.getDataReader("Select Location_id from Location where Location_name= '" + locname + "' and Loc_Address = '" + locadd + "' ");
            if (rd.HasRows)
            {
                k = 1;
                rd.Close();
                rd.Dispose();
                return k;
            }
            else
            {
                rd.Close();
                rd.Dispose();
                return k;
            }
        }

        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
                {
                    AddNewLocationRequest objAddLocationRequest = new AddNewLocationRequest();
                    LocationData objlocation = new LocationData();
                    //-------------------------------------------------------------------------------
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    if (cn.State == ConnectionState.Open) { }
                    else { cn.Open(); }
                    SqlCommand cmd = new SqlCommand("select max(Location_id) from location", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int maxid = dr.GetInt32(0);
                        int maxid1 = maxid + 1;
                        if (maxid1.ToString().Length == 1)
                        {

                            Session["Assigncode"] = "ASS1000" + maxid1.ToString();
                        }
                        else if (maxid1.ToString().Length == 2)
                        {
                            Session["Assigncode"] = "ASS100" + maxid1.ToString();
                        }
                        else if (maxid1.ToString().Length == 3)
                        {
                            Session["Assigncode"] = "ASS10" + maxid1.ToString();
                        }
                        else { }
                    }
                    cmd.Dispose();
                    dr.Close(); cn.Close();

                    //--------------------------------------------------------------------------------


                    if (txtAddLocation.Text.Trim() != "")
                    {
                        if (txtClientUserID.Text != "" && txtClientPassword.Text != "")
                        {
                            if (Regex.IsMatch(txtAddLocation.Text, ZipRegexboth))
                            {
                                int k = chkloc(txtAddLocation.Text.Trim().ToString(), txtsiteaddres.Text.Trim().ToString());
                                if (k > 0)
                                {
                                    lblerror.Visible = true;
                                    lblerror.Text = "Site Name Already Exist ..!";
                                    throw new Exception();
                                }
                            }


                            objlocation.Location_name = txtAddLocation.Text.Trim();
                            objlocation.code = Session["Assigncode"].ToString();
                            Session["Location_name"] = txtAddLocation.Text.Trim();
                            objlocation.Loc_Address = txtsiteaddres.Text.Trim();

                            objlocation.F_cont = txtFinanceContactTel.Text.Trim();
                            objlocation.F_Mob = txtFinanceContactMob.Text.Trim();
                            objlocation.F_Email = txtFinanceContactEmail.Text.Trim();
                            objlocation.F_Fax = txtFinanceContactFax.Text.Trim();

                            objlocation.O_cont = txtOperationsContactTelephone.Text.Trim();
                            objlocation.O_Mob = txtOperationsContactMobile.Text.Trim();
                            objlocation.O_Email = txtOperationsContactEmail.Text.Trim();
                            objlocation.O_Fax = txtOperationsContactFax.Text.Trim();

                            objlocation.M_cont = txtlblManagementContactTelephone.Text.Trim();
                            objlocation.F_Mob = txtManagementContactMobile.Text.Trim();
                            objlocation.F_Email = txtManagementContactEmail.Text.Trim();
                            objlocation.F_Fax = txtManagementContactFax.Text.Trim();

                            objlocation.Emergency_email = txtEmergencyContactEmail.Text.Trim();
                            objlocation.Chift_Security_day = txtChiefSecurityRequiredDay1.Text.Trim();
                            objlocation.Chift_Security_nig = txtChiefSecurityRequiredEvening.Text.Trim();

                            objlocation.Security_Off_day = txtSODay.Text.Trim();
                            objlocation.Security_Off_nig = txtSONight.Text.Trim();

                            objlocation.Senior_Secu_Off_day = TxtSSODay.Text.Trim();
                            objlocation.Senior_Secu_Off_nig = txtSSONight.Text.Trim();

                            objlocation.Supervisor_day = txtsupervisorrequiredDay.Text.Trim();
                            objlocation.Supervisor_nig = txtSupervisorRequireNight.Text.Trim();

                            objlocation.Contract_value = txtContractValue.Text.Trim();
                            //  string sdate = txtdatefrom.Text.Trim() != "" ? txtdatefrom.Text : "NULL";
                            if (txtdatefrom.Text.Trim() != "")
                            {
                                objlocation.Contract_start_date = Convert.ToDateTime(txtdatefrom.Text);
                            }

                            if (txtdateto.Text.Trim() != "")
                            {
                                objlocation.Contract_expire_date = Convert.ToDateTime(txtdateto.Text);
                            }

                            objlocation.Date_From = Convert.ToDateTime(DateTime.Now);

                            objlocation.Finance_Name = txtFinaceName.Text.Trim();
                            objlocation.Operation_Name = txtOperationName.Text.Trim();
                            objlocation.Management_Name = txtManagementName.Text.Trim();

                            objlocation.OtherPerson1 = txtOther1.Text.Trim();
                            objlocation.OtherPerson1_day = txtOther1_day.Text.Trim();
                            objlocation.OtherPerson1_nig = txtOther1_nig.Text.Trim();

                            objlocation.OtherPerson2 = txtOther2.Text.Trim();
                            objlocation.OtherPerson2_day = txtOther2_day.Text.Trim();
                            objlocation.OtherPerson2_nig = txtOther2_nig.Text.Trim();

                            objlocation.OtherPerson3 = txtOther3.Text.Trim();
                            objlocation.OtherPerson3_day = txtOther3_day.Text.Trim();
                            objlocation.OtherPerson3_nig = txtOther3_nig.Text.Trim();

                            objlocation.ClientUserID = txtClientUserID.Text;
                            objlocation.ClientPassword = txtClientPassword.Text;

                            objlocation.Current_Status = "Present";

                            AdminBLL ws = new AdminBLL();
                            ws.AddLocation(objlocation);
                            
                            getStaffID();
                            getLocationID();
                            Dal.executesql("Insert into UserInformation(UserID,UserPassword,NRICno,Role,Staff_ID) values('"+txtClientUserID.Text+"','"+txtClientPassword.Text+"','1111','Client','"+Staff_ID+"')");
                            Dal.executesql("Insert into StaffLocationMap(StaffID,LocationID) values('" + Staff_ID + "','" + Location_ID + "')");
                            btnNextLocationAdd.Enabled = true;
                            btnClearLocationAdd.Enabled = true;
                            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                            lblerror.Visible = true;
                            lblerror.Text = "Add Record Successfully";
                            //Response.Redirect("CompleteForm.aspx");
                           // Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                        }                         
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Please Fill UserID & Password ..!";                            
                        }
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Fill Site Name ..!";
                        lblerr.Visible = true;                        
                    }
                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }
            
            

            //TabContainer1.ActiveTabIndex = 1;

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
        protected void btnNextLocationAdd_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 1;
           // btnSearch1LocationAdd.Enabled = true;
           // btnClear1LocationAdd.Enabled = true;
            
        }
        protected void btnNext1LocationAdd_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 2;
            //btnSearch2LocationAdd.Enabled = true;
            //btnClear2LocationAdd.Enabled = true;
            
            
        }
        protected void btnNext2LocationAdd_Click(object sender, EventArgs e)
        {

            //btnSearch3LocationAdd.Enabled = true;
            //btnClear3LocationAdd.Enabled = true;
            TabContainer1.ActiveTabIndex = 3;
        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //try
            //{
                /*txtAddLocation.Text = "";
                txtsiteaddres.Text = "";
                txtFinanceContactTel.Text = "";
                txtFinanceContactMob.Text = "";
                txtFinanceContactEmail.Text = "";
                txtFinanceContactFax.Text = "";

                txtOperationsContactTelephone.Text = "";
                txtOperationsContactMobile.Text = "";
                txtOperationsContactEmail.Text = "";
                txtOperationsContactFax.Text = "";

                txtlblManagementContactTelephone.Text = "";
                txtManagementContactMobile.Text = "";
                txtManagementContactEmail.Text = "";
                txtManagementContactFax.Text = "";

                txtEmergencyContactEmail.Text = "";
                txtChiefSecurityRequiredDay1.Text = "";
                txtChiefSecurityRequiredEvening.Text = "";
                txtSODay.Text = "";
                txtSONight.Text = "";
                TxtSSODay.Text = "";
                txtSSONight.Text = "";
                txtsupervisorrequiredDay.Text = "";
                txtSupervisorRequireNight.Text = "";
                txtContractValue.Text = "";

                txtFinaceName.Text = "";
                txtOperationName.Text = "";
                txtManagementName.Text = "";

                txtdatefrom.Text = "";
                txtdateto.Text = "";
                txtClientPassword.Text = "";
                txtClientUserID.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }*/
                Response.Redirect("CompleteForm.aspx");
        }

        protected void chkoter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkoter.Checked == true)
            {
                PnlOther.Visible = true;


            }
            else
            {
                PnlOther.Visible = false;
            }
        }
        protected void btnClear1LocationAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompleteForm.aspx");
        }
        protected void btnClear2LocationAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompleteForm.aspx");
        }
        protected void btnClear3LocationAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompleteForm.aspx");
        }
        protected void btnSearch1LocationAdd_Click(object sender, EventArgs e)
        {

            string location_name = Session["Location_name"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Location_name"].ToString() != "")
                {
                    btnNext1LocationAdd.Enabled = true;
                    btnClear1LocationAdd.Enabled = true;
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
                        lblerror.Visible = true;
                        lblerror.Text = "please Fill First Information";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
        }
            //btnClear1LocationAdd.Enabled = true;
            //SqlConnection cn = new SqlConnection();
            //cn.Open();
        
        protected void btnSearch2LocationAdd_Click(object sender, EventArgs e)
        {
            

            string location_name = Session["Location_name"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Location_name"].ToString() != "")
                {
                    btnNext2LocationAdd.Enabled = true;
                    btnClear2LocationAdd.Enabled = true;
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Operation_Name=@Operation_Name,O_cont=@O_cont,O_Mob=@O_Mob,O_Email=@O_Email,O_Fax=@O_Fax where Location_name=@Location_name", cn);
                    cmd.Parameters.AddWithValue("@Operation_Name", txtOperationName.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_cont",txtOperationsContactTelephone.Text.Trim());
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
                        lblerror.Visible = true;
                        lblerror.Text = "please Fill First Information";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnSearch3LocationAdd_Click(object sender, EventArgs e)
        {
            string location_name = Session["Location_name"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["Location_name"].ToString() != "")
                {
                    btnNext2LocationAdd.Enabled = true;
                    btnClear3LocationAdd.Enabled = true;
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
                        lblerror.Visible = true;
                        lblerror.Text = "please Fill First Information";
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
