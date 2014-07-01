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

namespace SMS.BusinessEntities
{
     [Serializable]
        public class CISMenu
        {
            public Int32 MenuID { get; set; }
            public String DisplayText { get; set; }
            public Int32 ParentID { get; set; }
            public String Description { get; set; }
            public String NavigateURL { get; set; }
        }
  
}
