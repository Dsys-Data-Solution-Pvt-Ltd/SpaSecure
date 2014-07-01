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
using SMS.BusinessEntities;
using SMS.BusinessEntities.Authorization;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Main;

namespace SMS.SMSChat
{
    public partial class Register1 : System.Web.UI.Page
    {
        SqlConnection conn;
        //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chatConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public RegNewUserResult DoRegNewUser(String UserID, String UserPassword, String fname, String mnam, String lname, String country, String mobile, String email, String role, String question, String answer)
        {
            if (this.IsUsernameExists(UserID))
            {
                return RegNewUserResult.UsernameAlreadyExists;
            }

            SqlCommand cmd = new SqlCommand("insert into UserInformation (UserID, UserPassword, FirstName, MiddleName, LastName, Country, Mobile, EmailId, Role, UserSecretQues, UserSecretAns, LastActivityTime) values (@UserID, @UserPassword, @FirstName, @MiddleName, @LastName, @Country, @Mobile, @EmailId, @Role, @UserSecretQues, @UserSecretAns, @LastActivity)", conn);

            SqlParameter paraUserID = cmd.Parameters.Add("@UserID", SqlDbType.NVarChar);
            paraUserID.Value = UserID;

            SqlParameter paraUserPassword = cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar);
            paraUserPassword.Value = UserPassword;

            SqlParameter paraFirstName = cmd.Parameters.Add("@FirstName", SqlDbType.VarChar);
            paraFirstName.Value = fname;

            SqlParameter paraMiddleName = cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar);
            paraMiddleName.Value = mnam;

            SqlParameter paraLastName = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            paraLastName.Value = lname;

            SqlParameter paraCountry = cmd.Parameters.Add("@Country", SqlDbType.VarChar);
            paraCountry.Value = country;

            SqlParameter paraMobile = cmd.Parameters.Add("@Mobile", SqlDbType.VarChar);
            paraMobile.Value = mobile;

            SqlParameter paraEmailId = cmd.Parameters.Add("@EmailId", SqlDbType.VarChar);
            paraEmailId.Value = email;

            SqlParameter paraRole = cmd.Parameters.Add("@Role", SqlDbType.VarChar);
            paraRole.Value = role;

            SqlParameter paraUserSecretQues = cmd.Parameters.Add("@UserSecretQues", SqlDbType.VarChar);
            paraUserSecretQues.Value = question;

            SqlParameter paraUserSecretAns = cmd.Parameters.Add("@UserSecretAns", SqlDbType.VarChar);
            paraUserSecretAns.Value = answer;

            SqlParameter paraLastActivity = cmd.Parameters.Add("@LastActivity", SqlDbType.DateTime);
            paraLastActivity.Value = DateTime.Now;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                return RegNewUserResult.DatabaseFail;
            }

            finally
            {
                conn.Close();
            }

            // Add new user to "Members" role
            //Global.AddUserToRole("Members", username);

            return RegNewUserResult.Success;
        }

        public Boolean IsUsernameExists(String UserID)
        {
            SqlCommand cmd = new SqlCommand("select UserID from UserInformation where UserID=@UserID", conn);

            SqlParameter paraUserID = cmd.Parameters.Add("@UserID", SqlDbType.NVarChar);
            paraUserID.Value = UserID;

            try
            {
                conn.Open();
                Object result = cmd.ExecuteScalar();
                return result != null;
            }
            finally
            {
               conn.Close();
            }
        }

        public void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        public void btnReg_Click(object sender, System.EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

            string sUsername = txtUsername.Text;
            string sPassword = txtPassword.Text;
            string sFirstName = txtFirstName.Text;
            string sMiddleName = txtMiddleName.Text;
            string sLastName = txtLastName.Text;
            string sCountry = txtCountry.Text;
            string sMobile = txtMobile.Text;
            string sEmail = txtEmail.Text;
            string sRole = ddlRole.SelectedItem.Text;
            string sQuestion = txtQuestion.Text;
            string sAnswer = txtAnswer.Text;
            bool male = true;

            RegNewUserResult result = this.DoRegNewUser(sUsername, sPassword, sFirstName, sMiddleName, sLastName, sCountry, sMobile, sEmail, sRole, sQuestion, sAnswer);

            if (result == RegNewUserResult.UsernameAlreadyExists)
            {
                //JSHelper.MsgBox("Username [" + sUsername + "] is already exists. !");
            }
            else if (result == RegNewUserResult.DatabaseFail)
            {
                //JSHelper.MsgBox("Database error, please try later.");
            }
            else if (result == RegNewUserResult.Success)
            {
                //FormsAuthentication.SetAuthCookie(sUsername, false);
                this.Response.Redirect("Default.aspx");
            }
        }

        public enum RegNewUserResult
        {
            Success,
            UsernameAlreadyExists,
            DatabaseFail
        }
    }
}
