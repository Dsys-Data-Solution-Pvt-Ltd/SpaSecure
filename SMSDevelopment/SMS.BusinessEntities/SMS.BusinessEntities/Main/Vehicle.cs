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
    public class Vehicle
    {
        public String Vehicle_No { get; set; }
        public String Vehicle_Type { get; set; }
        public String Vehicle_Remark { get; set; }
        public String Vehicle_Color { get; set; }
        public String Vehicle_Model { get; set; }

        public String Ownew_By { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }
    }
}
