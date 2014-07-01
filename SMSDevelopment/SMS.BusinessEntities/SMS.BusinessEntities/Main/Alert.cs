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
    public class Alert
    {
        public String Alert_ID { get; set; }
        public String Alert_Maessage { get; set; }
        public String SendTo { get; set; }
        public String CcSendTo { get; set; }
        public DateTime? DateOfSending { get; set; }
        public String status { get; set; }
    }
}
