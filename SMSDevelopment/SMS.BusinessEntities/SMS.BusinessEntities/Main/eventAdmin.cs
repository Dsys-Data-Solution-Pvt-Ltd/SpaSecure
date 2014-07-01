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
    [Serializable]
    public class eventAdmin
    {
        public String Event_ID { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }

        public String Location_id { get; set; }
        public String Event_Type { get; set; }
        public String Start_time { get; set; }
        public String End_time { get; set; }
        
        public String Special_Requirment { get; set; }
        public String Guard_Requirment { get; set; }
        public String Special_Duty { get; set; }
        public String Incharg_Name { get; set; }
        public String Incharg_NricNo { get; set; }
        public String Incharg_position { get; set; }
        public String Incharg_ContactNo { get; set; }
        public String Superior_Name { get; set; }
    }
}
