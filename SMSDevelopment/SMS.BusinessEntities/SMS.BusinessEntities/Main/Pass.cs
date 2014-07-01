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
    public class Pass
    {
        public String Pass_id { get; set; }
        public String pass_Type { get; set; }
        public String Pass_No { get; set; }
        public String Pass_Desciption { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }
        public String Pass_Status { get; set; }

        public String Staff_ID { get; set; }

        public String Generatedfin { get; set; }
        public String Generatedname { get; set; }
        public String GeneratedPosition { get; set; }
        public String Location_id { get; set; }
        public String Location_name { get; set; }

    }
}
