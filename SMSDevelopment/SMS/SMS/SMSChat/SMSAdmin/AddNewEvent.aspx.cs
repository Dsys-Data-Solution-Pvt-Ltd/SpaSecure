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
    public partial class AddNewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnAdd1_Click(object sender, EventArgs e)
        {
            AddNewEventmanRequest objAddEventmanRequest = new AddNewEventmanRequest();
            eventAdmin objeventman = new eventAdmin();
            DateTime datetime;

            objeventman.date = DateTime.TryParse(txtFromDate.Text, out datetime) ? (DateTime?)datetime : null; ;
            objeventman.time = DateTime.TryParse(txtFromDate1.Text, out datetime) ? (DateTime?)datetime : null; ;
            objeventman.location = txtLocation1.Text;
            objeventman.eventbreaf = txtEventBreaf1.Text;

            AdminBLL ws = new AdminBLL();
            ws.AddEvent(objeventman);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewEventComplete.aspx");

        }

      
    }
}
