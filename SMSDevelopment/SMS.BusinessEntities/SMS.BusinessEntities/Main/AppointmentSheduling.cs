﻿using System;
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
    [Serializable]
    public class AppointmentSheduling
    {
        public DateTime? Date { get; set; }
        public DateTime? Timein { get; set; }
        public DateTime? Timeout { get; set; }
        public String Department { get; set; }
        public String Username { get; set; }
        public String UserID { get; set; }
       
    }
}
