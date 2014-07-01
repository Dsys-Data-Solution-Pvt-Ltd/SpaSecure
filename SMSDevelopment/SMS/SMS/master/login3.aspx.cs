using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Authorization;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Main;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;


namespace SMS.master
{
    public partial class login3 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["RoleID"] = "0";
                Session["SubRole"] = null;
                Session["LCID"] = null;
                Session["StaffID"] = null;
                if (!IsPostBack)
                {
                    Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_PASSWORD] = null;
                    Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID] = null;
                    txtUsername.Focus();
                }

                #region Dynamically Displaying Logo
                DBConnectionHandler1 bd = new DBConnectionHandler1();
                SqlConnection cn = bd.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select ImagePath,fullpathname from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        imgHeaderLogo.ImageUrl = dr.GetString(0).ToString();
                        dr.Close();
                        cn.Close();
                    }
                }
                else { imgHeaderLogo.ImageUrl = "../img/dsys_header_logo_new.png"; }
                #endregion
            }
            catch (Exception ex) { logger.Info("Error:" + ex.Message); Response.Write(ex.Message); }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //------change by rakesh------------------
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!AuthenticateUser())
                {
                    Labelerror.Text = "Please Enter Valid UserID And Password";
                }
                else
                {
                    string User_Id = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID].ToString();
                    Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                    DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.USER_FIRSTNAME);
                    db.AddInParameter(dbCommand, "@UserID", DbType.String, User_Id);
                    IDataReader dr = db.ExecuteReader(dbCommand);
                    if (dr.Read())
                    {
                        Session["user_role"] = dr.GetString(2);
                        Session["StaffID"] = dr.GetString(3);
                        Session["StaffID1"] = dr.GetString(3);
                        Session["NricNoOfStaff"] = dr.GetString(4);

                    }
                    dr.Close();
                    dr.Dispose();

                    //-----Alert Code start-----//
                    SqlParameter[] para1 = new SqlParameter[2];
                    para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
                    para1[0].Value = Session["StaffID"].ToString();
                    para1[1] = new SqlParameter("@ActiveStatus", SqlDbType.VarChar);
                    para1[1].Value = "1";


                    dal.exeprocedure("SP_UpdateuserinformationActiveStatus", para1);
                    //-----Alert Code End-----//

                    string xx = Session["user_role"].ToString();
                    switch (Session["user_role"].ToString())
                    {

                        case "Security Officer":
                            Session["ManagementRole"] = Session["user_role"];
                            int roleid = User_Role_Id("Security Officer");
                            Session["RoleID"] = roleid;
                            // Response.Redirect("VerifyLogin.aspx");
                            ModalPopupVerify.Show();
                            populatecontrol();
                            break;
                        case "Supervisor":
                            Session["ManagementRole"] = Session["user_role"];
                            int roleid2 = User_Role_Id("Supervisor");
                            Session["RoleID"] = roleid2;
                            //Response.Redirect("VerifyLogin.aspx");
                            ModalPopupVerify.Show();
                            populatecontrol();
                            break;
                        default:
                            Session["ManagementRole"] = Session["user_role"];
                            Response.Redirect("login.aspx");
                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                logger.Info("Error:" + ex.Message);
                Response.Write(ex.Message);
            }
            //-----end of change----------------------
        }
        private bool AuthenticateUser()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            AdminBLL ws = new AdminBLL();
            UserInformation _oUserInfo = new UserInformation();
            GetAuthRequest _req = new GetAuthRequest();
            try
            {
                try
                {
                    //Session["userid"] = TextBox1.Text;
                    Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER] = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID] = _oUserInfo.UserID = txtUsername.Text;
                    _oUserInfo.UserPassword = txtPassword.Text;
                    _req.UserInfo = _oUserInfo;
                }
                catch (Exception ex)
                {
                    logger.Info("Error:"+ex.Message);
                }
            }
            catch (Exception ex) { logger.Info("Error:" + ex.Message); Response.Write(ex.Message); }
            return ws.AuthenticateUser(_req);
        }
        public int User_Role_Id(string User_Role)
        {
            int result = 0;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["user_role2"] = User_Role;
                //string x = User_Role;
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("select ID from UserRoleMaster where UserRole=@userrole", cn);
                cmd1.Parameters.AddWithValue("@userrole", Session["user_role2"].ToString());
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    result = dr1.GetInt32(0);
                    dr1.Close();
                    dr1.Dispose();
                    cn.Close();
                }
            }
            catch (Exception ex) { logger.Info("Error:" + ex.Message); Response.Write(ex.Message); }
            return result;
        }

        # region Delete
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupDeleteimage.Hide();
            }
            catch (Exception ex) { }
        }
        #endregion

        # region verify Login
        public void populatecontrol()
        {
            lblerror1.Visible = false;
            try
            {

                {
                    DataSet userAssignLocation = dal.getdataset("Select Distinct LocationID from StaffLocationMap Where StaffID = '" + Session["StaffID"].ToString() + "' ");
                    if (userAssignLocation.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataTable Temp = new DataTable();
                        dal.executesql("delete from templocation");

                        for (int k = 0; k < userAssignLocation.Tables[0].Rows.Count; k++)
                        {
                            int locid = Convert.ToInt32(userAssignLocation.Tables[0].Rows[k][0].ToString());
                            dt = dal.getdata("Select Location_name,Location_id from location Where Location_id = '" + locid + "' ");
                            dal.executesql("Insert into templocation(Location_name,Location_id) values('" + dt.Rows[0][0].ToString() + "','" + dt.Rows[0][1].ToString() + "')");
                            Temp.Merge(dt);
                        }
                        // Temp.DefaultView.Sort = "Location_name";
                        DataSet dsnew = dal.getdataset("Select Distinct Location_name,Location_id from templocation order by Location_name Asc");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            grdLocations.DataSource = dsnew;
                            grdLocations.DataBind();
                        }

                    }
                    else
                    {
                        lblerror1.Visible = true;
                        lblerror1.Text = "No Location Assign Please Contact your Operation Manager !!!";
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private void fillLocation()
        {
            //-----------previous code------------------------
            //    ddllocation.Items.Clear();

            //    DataSet dsleave = dal.getdataset("Select Location_name,Location_id from location Order by Location_name Asc");
            //    if (dsleave.Tables[0].Rows.Count > 0)
            //    {
            //        ddllocation.DataSource = dsleave.Tables[0];
            //        ddllocation.DataTextField = "Location_name";
            //        ddllocation.DataValueField = "Location_id";
            //        ddllocation.DataBind();
            //        ddllocation.Items.Insert(0, new ListItem(" ", " ", true));
            //    }
        }
        protected void grdLocations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _BTId = Convert.ToString(e.CommandArgument);
            Session["LCID"] = _BTId;
            Response.Redirect("login.aspx");
            //if (e.CommandName.ToLower() == "select")
            //{
            //    Session["LCID"] = e.CommandArgument;
            //    //Response.Redirect("Default.aspx");
            //    Response.Redirect("login.aspx");
            //}
        }
        # endregion

        # region Alert

        #endregion

    }
}