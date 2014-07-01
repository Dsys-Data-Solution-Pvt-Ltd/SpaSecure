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
using SMS.Services.DataService;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using System.Drawing;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using SMS.master;

namespace SMS.ADMIN
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               txtuserid.Focus();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtpassword.Text.Trim() != "" && txtrepassword.Text.Trim() != "")
                {
                    if (txtpassword.Text.Trim() == txtrepassword.Text.Trim())
                    {
                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                        {
                            string staffid = txtuserid.Text;
                            dal.executesql("Update UserInformation Set UserPassword='" + txtpassword.Text.Trim() + "' where UserId = '" + staffid + "'");
                           // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Password Successfully Set...!');", true);
                          //  lblerror.Text = "Password Successfully Set...!";
                            MyMasterPage.ShowErrorMessage("Password Successfully Set...!");
                            clear();
                        }
                        else
                        {
                            string staffid = Session["StaffID"].ToString();
                            dal.executesql("Update UserInformation Set UserPassword='" + txtpassword.Text.Trim() + "' where Staff_ID = '" + staffid + "'");
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Password Successfully Set...!');", true);
                           // lblerror.Text = "Password Successfully Set...!";
                            MyMasterPage.ShowErrorMessage("Password Successfully Set...!");
                            clear();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Re-Confirm Password..!');", true);
                        //lblerror.Text = "Re-Confirm Password..!";
                        MyMasterPage.ShowErrorMessage("Re-Confirm Password..!");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Fill All Entries .....!');", true);
                   // lblerror.Text = "Please Fill All Entries .....!";
                    MyMasterPage.ShowErrorMessage("Please Fill All Entries .....!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void clear()
        {
      txtpassword.Text="";
    txtrepassword.Text="";
    txtuserid.Text = "";
        }
    }
}
