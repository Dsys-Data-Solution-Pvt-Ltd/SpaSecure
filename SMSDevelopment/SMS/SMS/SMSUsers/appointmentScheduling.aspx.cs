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


namespace SMS.SMSUsers
{
    public partial class appointmentScheduling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Appointment(object sender, EventArgs e)
        {
            AddNewAppointmentrequest objAddAppointment = new AddNewAppointmentrequest();
            AppointmentSheduling objAppointment = new AppointmentSheduling();
            DateTime datetime;

            objAppointment.Date = DateTime.TryParse(txtFromDate.Text, out datetime) ? (DateTime?)datetime : null; ;
            objAppointment.Timein = DateTime.TryParse(txtFromDate1.Text, out datetime) ? (DateTime?)datetime : null; ;
            objAppointment.Timeout = DateTime.TryParse(txtFromDate2.Text, out datetime) ? (DateTime?)datetime : null; ;
            objAppointment.Department = txtDepartment.Text;
            objAppointment.Username = txtName.Text;
            objAppointment.UserID = txtID.Text;


            AdminBLL ws = new AdminBLL();
            ws.AddAppointment(objAppointment);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");
        }

    }
}
