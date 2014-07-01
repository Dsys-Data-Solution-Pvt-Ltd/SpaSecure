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
    public class checkin
    {

        public String checkin_id { get; set; }
        public String UserID { get; set; }
        public String user_name { get; set; }
        public String user_address { get; set; }
        public String company_from { get; set; }
        public String telephone { get; set; }
        public String remarks { get; set; }
        public String Vehicle_No { get; set; }
        public String Key_no { get; set; }
        public String user_image { get; set; }
        public String Pass_No { get; set; }
        public String pass_type { get; set; }
        public String to_visit { get; set; }
        public String purpose { get; set; }
        public String Item_Declear { get; set; }
        public DateTime? Checkin_DateTime { get; set; }
        public String Department { get; set; }
        public String Status { get; set; }
        public String ImagePath { get; set; }
        public String Role { get; set; }
        public byte[] ThumbImage { get; set; }
        public int LocationID { get; set; }
        public String NRICno { get; set; }

    }
}
