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
    [Serializable]
    public class elearnAssignTo
    {

        public String Tutorial_ID { get; set; }
        public String Tutorial_Name { get; set; }
        public String UserID { get; set; }
        public String user_name { get; set; }
        public String Department { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? AssignTime { get; set; }

    }
}
