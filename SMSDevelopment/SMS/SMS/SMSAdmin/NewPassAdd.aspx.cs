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
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.SMSAdmin
{
    public partial class NewPassAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Pass(object sender, EventArgs e)
        {
                AddNewPassRequest objAddPass = new AddNewPassRequest();
                Pass ObjPass = new Pass();

                  ObjPass.pass_Type = txtAddPassType.Text;
                  ObjPass.Pass_No = txtEnterPassNumber.Text;
                  ObjPass.Pass_Desciption = txtPassDecription.Text;

                 AdminBLL ws = new AdminBLL();
                 ws.AddUserPass(ObjPass);
                 HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                 Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            txtAddPassType.Text = "";
            txtEnterPassNumber.Text = "";
            txtPassDecription.Text = "";
        }

        //protected void Add_Pass(object sender, EventArgs e)
        //{
        //    AddNewPassRequest objAddPass = new AddNewPassRequest();
        //    Pass ObjPass = new Pass();

        //    ObjPass.pass_Type = txtAddPassType.Text;
        //    ObjPass.Pass_No = txtEnterPassNumber.Text;
        //    ObjPass.Pass_Desciption = txtPassDecription.Text;

        //    AdminBLL ws = new AdminBLL();
        //    ws.AddUserPass(ObjPass);
        //    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
        //    Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");
        //}
    }
}
