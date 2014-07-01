using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    public class AddNewAppointmentrequest
    {
        private AppointmentSheduling _Appointment_Request = null;

        public AppointmentSheduling Appointment_Request
        {
            get { return _Appointment_Request; }
            set { _Appointment_Request = value; }
        }
    }
}
