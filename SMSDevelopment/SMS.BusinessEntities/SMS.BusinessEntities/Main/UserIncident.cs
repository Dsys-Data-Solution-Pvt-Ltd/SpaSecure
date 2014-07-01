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

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;

namespace SMS.BusinessEntities.Main
{
    public class UserIncident
    {
        public DateTime? Date_of_Incident { get; set; }
        public String Time_of_Incident { get; set; }
        public String Assignment { get; set; }
        public String Place_of_Incident { get; set; }
        public String Type_of_Incident { get; set; }
        public String Report_No { get; set; }
        public String ReportDetail { get; set; }
        public String Reported_By { get; set; }
        public String Name { get; set; }
        public String Verified_By { get; set; }

        public String Incident_id { get; set; }
        public String Location_id { get; set; }

        public String Received_By { get; set; }
        public String ReceivedVerified_By { get; set; }
        public String follownric { get; set; }
        public String followinvesti { get; set; }
        public String followverify { get; set; }
        public String followstatus { get; set; }
        public String followtime { get; set; }
        public DateTime? followdate { get; set; }
        public String followsremark { get; set; }
        public String AlertStatus { get; set; }
        
    }
}
