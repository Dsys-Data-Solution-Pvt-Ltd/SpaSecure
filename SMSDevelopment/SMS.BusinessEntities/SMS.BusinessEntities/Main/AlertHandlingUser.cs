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

namespace SMS.BusinessEntities.Main
{
    public class AlertHandlingUser
    {
        public String Location_id { get; set; }
        public String Alert_ID { get; set; }
        public String P_Name { get; set; }
        public String P_NRIC_no { get; set; }
        public String P_Passport { get; set; }
        public String Reason { get; set; }
        public String P_Nationality { get; set; }
        public String V_Type { get; set; }
        public String V_Color { get; set; }
        public String V_ResgistNo { get; set; }
        public String V_OwnerName { get; set; }
        public String V_OwnerNricNo { get; set; }

        public String Comment { get; set; }
        public String Alert_Type { get; set; }
        public String AlertBy_NRICNo { get; set; }
        public String AlertBy_Name { get; set; }
        public String AlertDepartment { get; set; }
        public String AlertDesignation { get; set; }
        public String AlertContNo { get; set; }
        public String Status { get; set; }

        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }
    }
}
