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
using GaurdPatroSystem.Services.DataService;
using System.Collections.Generic;

namespace GaurdPatroSystem
{
    public partial class LoginHome : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtusername.Focus();
                LinkButton hy5 = (LinkButton)Master.FindControl("lnknewclient");
                hy5.Visible = false;

            }
            catch (Exception ex)
            {
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsuserinfo = dal.getdataset("Select Staff_ID,Role from userinformation where UserID='" + txtusername.Text.Trim() + "' and UserPassword ='" + txtpassword.Text.Trim() + "'");
                if (dsuserinfo.Tables[0].Rows.Count > 0)
                {
                  Session["staff_id"] = dsuserinfo.Tables[0].Rows[0]["Staff_ID"].ToString();
                  Session["RoleInfo"] = dsuserinfo.Tables[0].Rows[0]["Role"].ToString();
               
                    string role = dsuserinfo.Tables[0].Rows[0]["Role"].ToString();
                    if (role == "superuser" || role == "Superuser")
                    {
                        Response.Redirect("~/GPS_locSearch.aspx");
                    }
                    if (role == "Client" || role == "client")
                    {
                        Response.Redirect("~/VerifyLogin.aspx");                        
                    }                    
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Invalid UserID & Password";
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   }
}
