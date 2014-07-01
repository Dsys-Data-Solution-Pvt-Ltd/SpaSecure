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
using Telerik.Web.UI;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using SMS.master;
using System.Globalization;


namespace SMS.ADMIN
{
    public partial class PresentSite : System.Web.UI.Page
    {

        DataAccessLayer Dal = new DataAccessLayer();
        AdminDAL adal = new AdminDAL();
        AdminBLL bll = new AdminBLL();

        String ZipRegexboth = "^[a-z A-Z 0-9]+$";
        string Staff_ID = string.Empty;
        string Location_ID = string.Empty;


        DataAccessLayer dal = new DataAccessLayer();

        
            String iBTID = String.Empty;
            //lblerr.Visible = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["path"] = "";
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
                    ColorTab();
                    lnkPresent.BackColor = System.Drawing.Color.Maroon;
                    lnkPresent.ForeColor = System.Drawing.Color.White;

                 //   BindGrid();

                   // BindGridWithFilter();
                }
                
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvLoctionTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGrid();  

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
                    BindGrid();                    
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
 
        private void DeleteItem(string arglocationid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update location set Current_Status='Past' Where Location_id = '" + arglocationid + "' ");
                dal.executesql("Delete from StaffLocationMap where LocationID = '" + arglocationid + "' ");

                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deleted SuccessFully');", true);
                //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully..!");   
          
                BindGrid();
                ModalPopupDelete.Hide();
                //Server.Transfer("CompleteForm.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");

            try
            {
                AdminBLL ws = new AdminBLL();
                GetLocationData _req = new GetLocationData();

                string WhereClause = " where Current_Status = 'Present'";

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    _req.WhereClause = WhereClause;
                }

                GetLocationDataResponse _resp = ws.GetLocationData(_req);

              
                //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = _resp.Location;
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void imgBtnFromDate2Edit_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3Edit_Click(object sender, ImageClickEventArgs e)
        {

        }

        public void ColorTab()
        {
            lnkPresent.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            lnkPast.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }
        #region Icon button


        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                DataTable dtAddSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "58");
                if (dtAddSite.Rows.Count > 0)
                {
                   TabContainerEdit.ActiveTabIndex = 0;
                   this.ModalPopupAdd.Show();                                                   
                }
                else
                {                                                   
                   MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");         
                }                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            DataTable dtPresentSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "57");
            if (dtPresentSite.Rows.Count > 0)
            {
                if (ViewState["Location_id"] != null)
                {
                    PopulatePageCntrls(ViewState["Location_id"].ToString());
                    TabContainerEdit.ActiveTabIndex = 0;
                    this.ModalPopupEdit.Show();
                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");
            }          
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            DataTable dtPresentSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "57");
            if (dtPresentSite.Rows.Count > 0)
            {
                if (ViewState["Location_id"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");
            }            
        }

        #endregion Icon button

        #region Add button Code


        public void disable()
        {
            btnNextLocationAdd.Enabled = false;
            btnClearLocationAdd.Enabled = true;
            //btnSearch1LocationAdd.Enabled = false;
            btnNext1LocationAdd.Enabled = false;
            btnClear1LocationAdd.Enabled = true;
            //btnSearch2LocationAdd.Enabled = false;
            btnNext2LocationAdd.Enabled = false;
            btnClear2LocationAdd.Enabled = true;
            //btnSearch3LocationAdd.Enabled = false;
            btnClear3LocationAdd.Enabled = true;


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

        protected void btnSearchLocationSave_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;


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
                SqlDataAdapter da = new SqlDataAdapter("select max(Location_id)as id from location", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "NULL")
                    {
                        Session["Assigncode"] = "ASS10001";
                    }
                    else
                    {
                        int maxid = Convert.ToInt32(dt.Rows[0][0].ToString());// dr.GetInt32(0);
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
                }
                else
                {
                    Session["Assigncode"] = "ASS10001";
                }
                cn.Close();

                //--------------------------------------------------------------------------------

                if (txtAddLocation.Text.Trim() != "")
                {
                    if (txtClientUserID.Text != "" && txtClientPassword.Text != "")
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtAddLocation.Text, ZipRegexboth))
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
                        ViewState["Location_name"] = txtAddLocation.Text.Trim();
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
                            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                            dtfi.ShortDatePattern = "MM/dd/yyyy";
                            dtfi.DateSeparator = "/";
                            DateTime objDate = Convert.ToDateTime(txtdatefrom.Text, dtfi);

                            objlocation.Contract_start_date = objDate;// Convert.ToDateTime(txtdatefrom.Text);
                        }

                        if (txtdateto.Text.Trim() != "")
                        {
                            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                            dtfi.ShortDatePattern = "MM/dd/yyyy";
                            dtfi.DateSeparator = "/";
                            DateTime objDate = Convert.ToDateTime(txtdateto.Text, dtfi);

                            objlocation.Contract_expire_date = objDate;// Convert.ToDateTime(txtdateto.Text);
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

                        DataTable dtC = dal.getdata("Select * from UserInformation where UserID= '" + txtClientUserID.Text + "'");
                        if (dtC.Rows.Count > 0)
                        {
                            MyMasterPage.ShowErrorMessage("This User ID Already Exist.");
                        }
                        else
                        {
                            AdminBLL ws = new AdminBLL();
                            ws.AddLocation(objlocation);

                            getStaffID();
                            getLocationID();
                            Dal.executesql("Insert into UserInformation(UserID,UserPassword,NRICno,Role,Staff_ID) values('" + txtClientUserID.Text + "','" + txtClientPassword.Text + "','1111','Client','" + Staff_ID + "')");
                            Dal.executesql("Insert into StaffLocationMap(StaffID,LocationID) values('" + Staff_ID + "','" + Location_ID + "')");
                            btnNextLocationAdd.Enabled = true;
                            btnClearLocationAdd.Enabled = true;
                            //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                            //lblerror.Visible = true;
                            //lblerror.Text = "Add Record Successfully";
                            BindGrid();

                            TabContainer1.ActiveTabIndex = 1;

                           // MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully..!");
                        }

                        //Response.Redirect("CompleteForm.aspx");
                        // Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("Please Fill UserID & Password..!");

                        //lblerror.Visible = true;
                        //lblerror.Text = "Please Fill UserID & Password ..!";
                    }
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Fill Site Name ..!");
                    //lblerror.Visible = true;
                    //lblerror.Text = "Fill Site Name ..!";
                    //lblerr.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }



            //TabContainer1.ActiveTabIndex = 1;

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


        public void clearAdd()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAddLocation.Text = "";
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
            }
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
            clearAdd();
            ModalPopupAdd.Hide();
        }

        protected void btnClear2LocationAdd_Click(object sender, EventArgs e)
        {
            clearAdd();
            ModalPopupAdd.Hide();
        }

        protected void btnClear3LocationAdd_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Hide();
            BindGrid();
            clearAdd();
        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            clearAdd();
            ModalPopupAdd.Hide();
        }

        protected void btnSearch1LocationAdd_Click(object sender, EventArgs e)
        {            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Location_name"] != null && ViewState["Location_name"].ToString() != "")
                {
                    string location_name = ViewState["Location_name"].ToString();
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

                        TabContainer1.ActiveTabIndex = 2;

                        //MyMasterPage.ShowErrorMessage("Record Inserted Successfully...");
                    }
                    else
                    {
                        

                        MyMasterPage.ShowErrorMessage("please Fill First Information..!");

                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
                else
                {
                   
                    MyMasterPage.ShowErrorMessage("please Fill First Information..!");
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
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Location_name"] != null && ViewState["Location_name"].ToString() != "")
                {
                    string location_name = ViewState["Location_name"].ToString();
                    btnNext2LocationAdd.Enabled = true;
                    btnClear2LocationAdd.Enabled = true;
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

                        TabContainer1.ActiveTabIndex = 3;
                        //MyMasterPage.ShowErrorMessage("Record Inserted Successfully...");
                    }
                    else
                    {
                       
                        MyMasterPage.ShowErrorMessage("please Fill First Information..!");

                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
                else
                {
                   
                    MyMasterPage.ShowErrorMessage("please Fill First Information..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearch3LocationAdd_Click(object sender, EventArgs e)
        {            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Location_name"] != null && ViewState["Location_name"].ToString() != "")
                {
                    string location_name = ViewState["Location_name"].ToString();
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
                        MyMasterPage.ShowErrorMessage("Location Has Been Created Successfully...");
                        ModalPopupAdd.Hide();
                    }
                    else
                    {
                      
                        MyMasterPage.ShowErrorMessage("please Fill First Information..!");

                        //lblerror.Visible = true;
                        //lblerror.Text = "please Fill First Information";
                    }
                }
                else
                {
                   
                    MyMasterPage.ShowErrorMessage("please Fill First Information..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        #region Edit Button Code

        protected void btnBack_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupEdit.Hide();
                clearUpdate();
                BindGrid();

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

                if (txtAddLocationEdit.Text.Trim() != "")
                {

                    objLocation_Data.Location_id = txtUpdateLocationNameEdit.Text.Trim();

                    


                    objLocation_Data.Location_name = txtAddLocationEdit.Text.Trim();
                    objLocation_Data.Loc_Address = txtsiteaddresEdit.Text.Trim();

                    objLocation_Data.Finance_Name = txtFinaceNameEdit.Text.Trim();
                    objLocation_Data.F_cont = txtFinanceContactTelEdit.Text.Trim();
                    objLocation_Data.F_Mob = txtFinanceContactMobEdit.Text.Trim();
                    objLocation_Data.F_Email = txtFinanceContactEmailEdit.Text.Trim();
                    objLocation_Data.F_Fax = txtFinanceContactFaxEdit.Text.Trim();

                    objLocation_Data.Operation_Name = txtOperationNameEdit.Text.Trim();
                    objLocation_Data.O_cont = txtOperationsContactTelephoneEdit.Text.Trim();
                    objLocation_Data.O_Mob = txtOperationsContactMobileEdit.Text.Trim();
                    objLocation_Data.O_Email = txtOperationsContactEmailEdit.Text.Trim();
                    objLocation_Data.O_Fax = txtOperationsContactFaxEdit.Text.Trim();

                    objLocation_Data.Management_Name = txtManagementNameEdit.Text.Trim();
                    objLocation_Data.M_cont = txtlblManagementContactTelephoneEdit.Text.Trim();
                    objLocation_Data.M_Mob = txtManagementContactMobileEdit.Text.Trim();
                    objLocation_Data.M_Email = txtManagementContactEmailEdit.Text.Trim();
                    objLocation_Data.M_Fax = txtManagementContactFaxEdit.Text.Trim();

                    objLocation_Data.Emergency_email = txtEmergencyContactEmailEdit.Text.Trim();

                    objLocation_Data.Chift_Security_day = txtChiefSecurityRequiredDayEdit.Text.Trim();
                    objLocation_Data.Chift_Security_nig = txtChiefSecurityRequiredEveningEdit.Text.Trim();

                    objLocation_Data.Security_Off_day = txtSODayEdit.Text.Trim();
                    objLocation_Data.Security_Off_nig = txtSONightEdit.Text.Trim();

                    objLocation_Data.Senior_Secu_Off_day = TxtSSODayEdit.Text.Trim();
                    objLocation_Data.Senior_Secu_Off_nig = txtSSONightEdit.Text.Trim();

                    objLocation_Data.Supervisor_day = txtsupervisorrequiredDayEdit.Text.Trim();
                    objLocation_Data.Supervisor_nig = txtSupervisorRequireNightEdit.Text.Trim();

                    objLocation_Data.Contract_value = txtContractValueEdit.Text.Trim();
                    if (txtdatefromEdit.Text.Trim() != "")
                    {
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "MM/dd/yyyy";
                        dtfi.DateSeparator = "/";
                        DateTime objDate = Convert.ToDateTime(txtdatefromEdit.Text, dtfi);
                        objLocation_Data.Contract_start_date = objDate;// Convert.ToDateTime(txtdatefromEdit.Text);
                    }
                    if (txtdatetoEdit.Text.Trim() != "")
                    {
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "MM/dd/yyyy";
                        dtfi.DateSeparator = "/";
                        DateTime objDate = Convert.ToDateTime(txtdatetoEdit.Text, dtfi);
                        objLocation_Data.Contract_expire_date = objDate;// Convert.ToDateTime(txtdatetoEdit.Text);
                    }
                    objLocation_Data.Date_From = Convert.ToDateTime(DateTime.Now);

                    objLocation_Data.Finance_Name = txtFinaceNameEdit.Text.Trim();
                    objLocation_Data.Operation_Name = txtOperationNameEdit.Text.Trim();
                    objLocation_Data.Management_Name = txtManagementNameEdit.Text.Trim();

                    objLocation_Data.OtherPerson1 = txtOther1Edit.Text.Trim();
                    objLocation_Data.OtherPerson1_day = txtOther1_dayEdit.Text.Trim();
                    objLocation_Data.OtherPerson1_nig = txtOther1_nigEdit.Text.Trim();

                    objLocation_Data.OtherPerson2 = txtOther2Edit.Text.Trim();
                    objLocation_Data.OtherPerson2_day = txtOther2_dayEdit.Text.Trim();
                    objLocation_Data.OtherPerson2_nig = txtOther2_nigEdit.Text.Trim();

                    objLocation_Data.OtherPerson3 = txtOther3Edit.Text.Trim();
                    objLocation_Data.OtherPerson3_day = txtOther3_dayEdit.Text.Trim();
                    objLocation_Data.OtherPerson3_nig = txtOther3_nigEdit.Text.Trim();

                    objLocation_Data.ClientUserID = txtClientUserIDEdit.Text.Trim();

                    ws.UpdateLocationData(objLocation_Data);

                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    ViewState["Location_id"] = txtUpdateLocationNameEdit.Text.Trim();
                    MyMasterPage.ShowErrorMessage("Record Updated SuccessFully..!");   
    
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated SuccessFully');", true);
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    //Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                }
                else
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Invalid Site Name..!");   
    
                    //lblErrMsg.Visible = true;
                    //lblErrMsg.Text = "Invalid Site Name ..!";
                    //lblerr.Visible = true;

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

                txtUpdateLocationNameEdit.Text = ret.Location[iCount].Location_id.ToString();
                txtAddLocationEdit.Text = ret.Location[iCount].Location_name.ToString();
                txtsiteaddresEdit.Text = ret.Location[iCount].Loc_Address.ToString();

                txtFinanceContactTelEdit.Text = ret.Location[iCount].F_cont.ToString();
                txtFinanceContactMobEdit.Text = ret.Location[iCount].F_Mob.ToString();
                txtFinanceContactEmailEdit.Text = ret.Location[iCount].F_Email.ToString();
                txtFinanceContactFaxEdit.Text = ret.Location[iCount].F_Fax.ToString();

                txtOperationsContactTelephoneEdit.Text = ret.Location[iCount].O_cont.ToString();
                txtOperationsContactMobileEdit.Text = ret.Location[iCount].O_Mob.ToString();
                txtOperationsContactEmailEdit.Text = ret.Location[iCount].O_Email.ToString();
                txtOperationsContactFaxEdit.Text = ret.Location[iCount].O_Fax.ToString();

                txtlblManagementContactTelephoneEdit.Text = ret.Location[iCount].M_cont.ToString();
                txtManagementContactMobileEdit.Text = ret.Location[iCount].M_Mob.ToString();
                txtManagementContactEmailEdit.Text = ret.Location[iCount].M_Email.ToString();
                txtManagementContactFaxEdit.Text = ret.Location[iCount].M_Fax.ToString();

                txtEmergencyContactEmailEdit.Text = ret.Location[iCount].Emergency_email.ToString();

                txtChiefSecurityRequiredDayEdit.Text = ret.Location[iCount].Chift_Security_day.ToString();
                txtChiefSecurityRequiredEveningEdit.Text = ret.Location[iCount].Chift_Security_nig.ToString();

                txtSODayEdit.Text = ret.Location[iCount].Security_Off_day.ToString();
                txtSONightEdit.Text = ret.Location[iCount].Security_Off_nig.ToString();

                TxtSSODayEdit.Text = ret.Location[iCount].Senior_Secu_Off_day.ToString();
                txtSSONightEdit.Text = ret.Location[iCount].Senior_Secu_Off_nig.ToString();

                txtsupervisorrequiredDayEdit.Text = ret.Location[iCount].Supervisor_day.ToString();
                txtSupervisorRequireNightEdit.Text = ret.Location[iCount].Supervisor_nig.ToString();

                txtContractValueEdit.Text = ret.Location[iCount].Contract_value.ToString();

                if (ret.Location[iCount].Contract_start_date != null)
                {
                    txtdatefromEdit.Text = ret.Location[iCount].Contract_start_date.Value.ToString("MM/dd/yyyy").Replace("-", "/");//"ToString().ToString(dtfi);
                }

                if (ret.Location[iCount].Contract_expire_date != null)
                {
                    txtdatetoEdit.Text = ret.Location[iCount].Contract_expire_date.Value.ToString("MM/dd/yyyy").Replace("-", "/");
                }  
                
                //txtdatefromEdit.Text = ret.Location[iCount].Contract_start_date.ToString();
                //txtdatetoEdit.Text = ret.Location[iCount].Contract_expire_date.ToString();

                
                
                
                
                
                
                txtFinaceNameEdit.Text = ret.Location[iCount].Finance_Name.ToString();
                txtOperationNameEdit.Text = ret.Location[iCount].Operation_Name.ToString();
                txtManagementNameEdit.Text = ret.Location[iCount].Management_Name.ToString();

                txtOther1Edit.Text = ret.Location[iCount].OtherPerson1.ToString();
                txtOther1_dayEdit.Text = ret.Location[iCount].OtherPerson1_day.ToString();
                txtOther1_nigEdit.Text = ret.Location[iCount].OtherPerson1_nig.ToString();

                txtOther2Edit.Text = ret.Location[iCount].OtherPerson2.ToString();
                txtOther2_dayEdit.Text = ret.Location[iCount].OtherPerson2_day.ToString();
                txtOther2_nigEdit.Text = ret.Location[iCount].OtherPerson2_nig.ToString();

                txtOther3Edit.Text = ret.Location[iCount].OtherPerson3.ToString();
                txtOther3_dayEdit.Text = ret.Location[iCount].OtherPerson3_day.ToString();
                txtOther3_nigEdit.Text = ret.Location[iCount].OtherPerson3_nig.ToString();

                txtClientUserIDEdit.Text = ret.Location[iCount].ClientUserID.ToString();



            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

     
        protected void btnSave1_Click(object sender, EventArgs e)
        {

            string location_id = ViewState["Location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Location_id"].ToString() != "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Finance_Name=@Finance_Name,F_cont=@F_cont,F_Mob=@F_Mob,F_Email=@F_Email,F_Fax=@F_Fax where Location_id=@Location_id", cn);
                    cmd.Parameters.AddWithValue("@Finance_Name", txtFinaceNameEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_cont", txtFinanceContactTelEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Mob", txtFinanceContactMobEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Email", txtFinanceContactEmailEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@F_Fax", txtFinanceContactFaxEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_id", txtUpdateLocationNameEdit.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated SuccessFully');", true);

                      

                        MyMasterPage.ShowErrorMessage("Record Updated SuccessFully..!");   
    
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("please Fill First Information");
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

            string location_id = ViewState["Location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Location_id"].ToString() != "")
                {
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Operation_Name=@Operation_Name,O_cont=@O_cont,O_Mob=@O_Mob,O_Email=@O_Email,O_Fax=@O_Fax where Location_id=@Location_id", cn);
                    cmd.Parameters.AddWithValue("@Operation_Name", txtOperationNameEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_cont", txtOperationsContactTelephoneEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Mob", txtOperationsContactMobileEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Email", txtOperationsContactEmailEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@O_Fax", txtOperationsContactFaxEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_id", txtUpdateLocationNameEdit.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated SuccessFully');", true);
                       

                        MyMasterPage.ShowErrorMessage("Record Updated SuccessFully..!");   
    
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("please Fill First Information"); 
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
            string location_id = ViewState["Location_id"].ToString();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Location_id"].ToString() != "")
                {

                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update location set Management_Name=@Management_Name,M_cont=@M_cont,M_Mob=@M_Mob,M_Email=@M_Email,M_Fax=@M_Fax,Emergency_email=@Emergency_email where Location_id=@Location_id", cn);
                    cmd.Parameters.AddWithValue("@Management_Name", txtManagementNameEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_cont", txtlblManagementContactTelephoneEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Mob", txtManagementContactMobileEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Email", txtManagementContactEmailEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@M_Fax", txtManagementContactFaxEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Emergency_email", txtEmergencyContactEmailEdit.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location_id", txtUpdateLocationNameEdit.Text.Trim());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cn.Close();
                       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Updated SuccessFully');", true);
                      

                        MyMasterPage.ShowErrorMessage("Record Updated SuccessFully..!");

                        Response.Redirect(Request.RawUrl.ToString());
                    }
                    else
                    {
                        MyMasterPage.ShowErrorMessage("please Fill First Information");   
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

        public void clearUpdate()
        { 
            txtsiteaddresEdit.Text="";
            txtClientUserIDEdit.Text="";
            txtdatefromEdit.Text="";
            txtdatetoEdit.Text="";
            txtContractValueEdit.Text="";

            txtFinaceNameEdit.Text="";
            txtFinanceContactTelEdit.Text="";
            txtFinanceContactMobEdit.Text="";
            txtFinanceContactEmailEdit.Text="";
            txtFinanceContactFaxEdit.Text="";


            txtOperationNameEdit.Text="";
            txtOperationsContactTelephoneEdit.Text="";
            txtOperationsContactMobileEdit.Text="";
            txtOperationsContactEmailEdit.Text="";
            txtOperationsContactFaxEdit.Text="";

            txtManagementNameEdit.Text="";
            txtlblManagementContactTelephoneEdit.Text="";
            txtManagementContactMobileEdit.Text="";
            txtManagementContactEmailEdit.Text="";
            txtManagementContactFaxEdit.Text="";
            txtEmergencyContactEmailEdit.Text = "";
        }

        #endregion

        #region Delete Button Code

        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string loc_id = ViewState["Location_id"].ToString();

                DeleteItem(loc_id);
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully..!");   
    

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupDelete.Hide();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        # region Grid Selected Row Function


        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvLoctionTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvLoctionTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvLoctionTable.Items[ro].Selected = true;


                        ViewState["Location_id"] = item.OwnerTableView.DataKeyValues[ro]["Location_id"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }
        

     

        #endregion

        #region Main Tab


        protected void lnkPresent_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("PresentSite.aspx", false);
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

                DataTable dtPastSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "59");


                if (dtPastSite.Rows.Count > 0)
                {
                    Response.Redirect("PastSite.aspx", false);

                }
                else
                {

                    MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                }

               




            }
            catch (Exception ex)
            {
                logger.Info("PresentSite(lnkShowInfo_Click):" + ex.Message);
            }
        }

        #endregion
    }
}
