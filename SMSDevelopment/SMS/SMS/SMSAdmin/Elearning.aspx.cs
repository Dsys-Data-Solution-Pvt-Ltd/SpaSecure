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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.Web.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSAdmin
{
    public partial class Elearning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SelelctCategory_Click(object sender, EventArgs e)
        {

        }
    
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            AddNewElearnReuest objElearnRequest = new AddNewElearnReuest();
            Elearn objElearn = new Elearn();
            objElearn.Tutorial_ID = "12";
            objElearn.Tutorial_Name = TextBox1.Text;
 
            AdminBLL ws = new AdminBLL();
            ws.AddElearn(objElearn);

            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");
 
        }

        protected void Assign_click(object sender, EventArgs e)
        {

        }

        protected void Unassign_click(object sender, EventArgs e)
        {

        }

       
    }
}
