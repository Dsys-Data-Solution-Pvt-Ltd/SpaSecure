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
using System.Collections.Generic;
using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities.Main
{
    public class CheckInKeyData
    {
        public String Chkinkey_id { get; set; }
        public String Key_ID { get; set; }
        public String Name { get; set; }
        public String Designation { get; set; }
        public String Nricno { get; set; }
        public String ContNo { get; set; }
        public DateTime? Fromdate { get; set; }

        public String BunchNo { get; set; }
        public String NoOfKey { get; set; }

      
    }
}
