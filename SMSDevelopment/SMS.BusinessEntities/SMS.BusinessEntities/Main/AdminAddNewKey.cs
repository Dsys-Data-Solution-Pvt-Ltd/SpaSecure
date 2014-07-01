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
    public class AdminAddNewKey
    {
        public String key_no { get; set; }
        public String key_ID { get; set; }
        public String Description { get; set; }
        public String status { get; set; }
        public String name { get; set; }
        public String position { get; set; }
        public String count { get; set; }
        public String nricno { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }
        public String BunchNo {get; set;}
        public String NoOfKey {get; set;}
        public String Staff_ID {get; set;}
        public String  Location_ID {get; set;}
        public int Location_name { get; set; }
    }
}
