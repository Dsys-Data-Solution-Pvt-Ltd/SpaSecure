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
    public class Shift
    {
        public String Shift_ID { get; set; }
        public String shiftdep { get; set; }
        public DateTime? ShiftDateFrom { get; set; }
        public DateTime? ShiftDateTo { get; set; }
        public String ShiftTimeFrom { get; set; }
        public String ShiftTimeTo { get; set; }
        public String Location { get; set; }

        public String superid { get; set; }
        public String supername { get; set; }
        public String supercontno { get; set; }


    }
}
