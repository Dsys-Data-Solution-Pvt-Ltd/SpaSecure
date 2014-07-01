using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.Services.BusinessServices;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities.Authorization;
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

namespace SMS
{
    public partial class loginhome : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();
        string username = String.Empty;
        string password = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SubRole"] = null;
            Session["LCID"] = null;
            Session["StaffID"] = null;
            if (!IsPostBack)
            {
                Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_PASSWORD] = null;
                Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID] = null;
                //TextBox1.Focus();
            }
            if (Request.Form["textfield"] != null && Request.Form["textfield2"] != null)
            {
                username = Request.Form["textfield"].ToString();
                password = Request.Form["textfield2"].ToString();
            }            
            if (username == null || password == null || username == "" || password == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Alert", "alert('Invalid User Name or Password');", true);
                Response.Redirect("index.html");
                //error = true;
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Referer", "location.href('index.html');", true);
            }
            else
            {
                LoginCheck(username, password);
            }        
        }     
        protected void LoginCheck(string username,string password)
        {
            /*string getuserRole = string.Empty;
            try
            {
                if (!AuthenticateUser())
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Alert", "alert('Invalid User Name or Password');",true);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Referer", "location.href('index.html');", true);
                }
                else
                {
                    DataTable dt = dal.getdata("select Role from UserInformation Where UserID='" + username.Trim() + "'");
                    Session["user_role"]=Session["role"] = dt.Rows[0][0].ToString();
                    Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER] = username;
                    getuserRole = GetAuthenticateUserRoleAndID();

                    Session["ManagementRole"] = getuserRole.Split(new string[] { "||" }, StringSplitOptions.None)[0];
                    Session["StaffID"] = getuserRole.Split(new string[] { "||" }, StringSplitOptions.None)[1];
                   // Session["LCID"] = "-select-";//int.Parse(ddlLocation.SelectedValue);
                    try
                    {

                        switch (Session["role"].ToString())
                        {   
                            case "Security Officer":
                                Response.Redirect("SMSCommons/VerifyLogin.aspx");
                                break;
                            case "Supervisor":
                                Response.Redirect("SMSCommons/VerifyLogin.aspx");
                                break;
                            default:
                                Response.Redirect("SMSCommons/Default.aspx");
                                break;
                        }
                        switch (Session["user_role"].ToString())
                        {

                            case "Security Officer":
                                Session["ManagementRole"] = Session["user_role"];
                                Response.Redirect("VerifyLogin.aspx");
                                break;
                            case "Supervisor":
                                Session["ManagementRole"] = Session["user_role"];
                                Response.Redirect("VerifyLogin.aspx");
                                break;
                            default:
                                Session["ManagementRole"] = Session["user_role"];
                                Response.Redirect("login.aspx");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }*/
            try
            {
                if (!AuthenticateUser())
                {
                    //errorLabel.Text = "Please Enter Valid UserID And Password";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Alert", "alert('Invalid User Name or Password');", true);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Referer", "location.href('index.html');", true);
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

                    }
                    string xx = Session["user_role"].ToString();
                    switch (Session["user_role"].ToString())
                    {

                        case "Security Officer":
                            Session["ManagementRole"] = Session["user_role"];
                            Response.Redirect("master/VerifyLogin.aspx");
                            break;
                        case "Supervisor":
                            Session["ManagementRole"] = Session["user_role"];
                            Response.Redirect("master/VerifyLogin.aspx");
                            break;
                        default:
                            Session["ManagementRole"] = Session["user_role"];
                            Response.Redirect("master/login.aspx");
                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        private bool AuthenticateUser()
        {
            AdminBLL ws = new AdminBLL();
            UserInformation _oUserInfo = new UserInformation();
            GetAuthRequest _req = new GetAuthRequest();
            try
            {
                /*_oUserInfo.UserID = username;
                _oUserInfo.UserPassword = password;
                _req.UserInfo = _oUserInfo;*/
                Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER] = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID] = _oUserInfo.UserID = username;
                _oUserInfo.UserPassword = password;
                _req.UserInfo = _oUserInfo;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return ws.AuthenticateUser(_req);
        }

        private string GetAuthenticateUserRoleAndID()
        {
            AdminBLL ws = new AdminBLL();
            UserInformation _oUserInfo = new UserInformation();
            GetAuthRequest _req = new GetAuthRequest();
            try
            {

                _oUserInfo.UserID = username;
                _oUserInfo.UserPassword = password;


                _req.UserInfo = _oUserInfo;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return ws.GetAuthenticateUserRoleAndID(_req);
        }
    }
}
