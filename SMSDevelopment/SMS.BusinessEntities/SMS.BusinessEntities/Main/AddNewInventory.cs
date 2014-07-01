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
    public class AddNewInventory
    {
        public String Item_Type { get; set; }

        public String Item_id { get; set; }
        public String Item_Name { get; set; }
        public String Item_qty { get; set; }
        public String CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public String EditBy { get; set; }
        public DateTime? EditTime { get; set; }

        public String SerialNo { get; set; }
        public String ModelNo { get; set; }

    }
}
