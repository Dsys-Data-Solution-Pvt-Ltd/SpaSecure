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
    public class SOP
    {
        public String SOP_ID { get; set; }
        public String SOP_Title { get; set; }
        public String SOP_Subject { get; set; }

        public String ImagePathName { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }
        public String Created_By { get; set; }

        public String Location { get; set; }

    }
}
