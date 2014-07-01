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
    public class checkout
    {
        public String checkin_id { get; set; }
        public String checkout_id { get; set; }
        public String user_id { get; set; }
        public String user_name { get; set; }
        public String user_address { get; set; }
        public String company_from { get; set; }
        public String telephone { get; set; }
        public String remarks { get; set; }
        public String vehicle_no { get; set; }
        public String key_no { get; set; }
        public String user_image { get; set; }
        public String pass_no { get; set; }        
        public String to_visit { get; set; }
        public String purpose { get; set; }
        public DateTime? Checkout_DateTime { get; set; }
        public DateTime? Checkin_DateTime { get; set; }
        public String PassType { get; set; }
        public String Item_Declear { get; set; }
        public String Role { get; set; }
        public String Department { get; set; }
        public String Location_id { get; set; }
        public String NRICno { get; set; }

    }
}
