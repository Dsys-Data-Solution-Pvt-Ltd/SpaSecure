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

using SMS.BusinessEntities;
using SMS.BusinessEntities.Authorization;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Main;

namespace SMS.SMSCommons
{
    public partial class login : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
               // FilldefaultValues();
                Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER] = null;
                Session[SMSAppUtilities.SessionKeys.SESSION_MENU_ITEMS] = null;
                txtUserName.Focus();
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                
            }
            if ((Request.Url.Host.Contains("spasecure")))
            {
                if (HttpContext.Current.Session[SessionKeys.SESSION_LOGIN_USER] == null)
                {
                    //Session Expired.
                    //Response.Redirect("../index.html");

                    // lnkHome.Visible = false;
                }
            }
        }
        private void FilldefaultValues()
        {
            
            DataSet dsfill = dal.getdataset("Select * from Setting");
            if (dsfill.Tables[0].Rows.Count > 0)
            {  
                //HttpContext.Current.Items.Add(ContextKeys.imagelogo, dsfill.Tables[0].Rows[0]["Image_Logo"].ToString());
                // HttpContext.Current.Items.Add(ContextKeys.title, dsfill.Tables[0].Rows[0]["Title"].ToString());
                HttpContext.Current.Items.Add(ContextKeys.Welcome_heading, dsfill.Tables[0].Rows[0]["Welcome_heading"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Welcome_title,dsfill.Tables[0].Rows[0]["Welcome_title"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Welcome_title2,dsfill.Tables[0].Rows[0]["Welcome_title2"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.Title_header,dsfill.Tables[0].Rows[0]["Title_header"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Online,dsfill.Tables[0].Rows[0]["ClientFeedback_Online"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Help,dsfill.Tables[0].Rows[0]["ClientFeedback_Help"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_Analysis,dsfill.Tables[0].Rows[0]["ClientFeedback_Analysis"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_pvt,dsfill.Tables[0].Rows[0]["ClientFeedback_pvt"].ToString());
                //HttpContext.Current.Items.Add(ContextKeys.ClientFeedback_MDirtector,dsfill.Tables[0].Rows[0]["ClientFeedback_ManagingDirtector"].ToString());

            }
        }
   
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string getuserRole = string.Empty;
            try
            {
                if (!AuthenticateUser())
                {
                    divMsg.Visible = true;
                    lblMsg.Text = "Please Enter a valid User Name and Password.";
                }
                else
                {
                    DataTable dt = dal.getdata("select Role from UserInformation Where UserID='" + txtUserName.Text.Trim() + "'");
                    Session["role"] = dt.Rows[0][0].ToString();
                    Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER] = txtUserName.Text;
                    getuserRole = GetAuthenticateUserRoleAndID();

                    Session["ManagementRole"] = getuserRole.Split(new string[] { "||" }, StringSplitOptions.None)[0];
                    Session["StaffID"] = getuserRole.Split(new string[] { "||" }, StringSplitOptions.None)[1];
                   // Session["LCID"] = int.Parse(ddlLocation.SelectedValue);
                    try
                    {
                        switch (Session["role"].ToString())
                        {
                          
                            case "Security Officer":
                                Response.Redirect("VerifyLogin.aspx");
                                break;
                            case "Supervisor":
                                Response.Redirect("VerifyLogin.aspx");
                                break;
                            default:
                                Response.Redirect("Default.aspx");
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
            }
        }

        private bool AuthenticateUser()
        {
            AdminBLL ws = new AdminBLL();
            UserInformation _oUserInfo = new UserInformation();
            GetAuthRequest _req = new GetAuthRequest();
            try
            {

                _oUserInfo.UserID = txtUserName.Text;
                _oUserInfo.UserPassword = txtPassword.Text;
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

                _oUserInfo.UserID = txtUserName.Text;
                _oUserInfo.UserPassword = txtPassword.Text;


                _req.UserInfo = _oUserInfo;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return ws.GetAuthenticateUserRoleAndID(_req);
        }

        protected void lnkBtnForgetPswd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ForgotPassword.aspx");
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception cex)
            {
                //LogHandler.LogMessages(cex);

            }
        }
    }
}
