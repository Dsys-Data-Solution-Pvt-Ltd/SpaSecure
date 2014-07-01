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
    public partial class NewLocationAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void btnSearchLocationAdd_Click(object sender, EventArgs e)
        //{
        //    AddNewLocationRequest objAddLocationRequest = new AddNewLocationRequest();
        //    location objlocation = new location();
        //    objlocation.loc = txtAddLocationName.Text;

        //        AdminBLL ws=new AdminBLL();
        //        ws.AddLocation(objlocation);
        //        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
        //        Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        //}

        protected void Add_AdminLocation(object sender, EventArgs e)
        {
            AddNewLocationRequest objAddLocationRequest = new AddNewLocationRequest();
            LocationData objlocation = new LocationData();

            objlocation.locid = "12";
            objlocation.loc = txtAddLocationName.Text;

            AdminBLL ws = new AdminBLL();
            ws.AddLocation(objlocation);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            txtAddLocationName.Text = "";
        }
    }
}
