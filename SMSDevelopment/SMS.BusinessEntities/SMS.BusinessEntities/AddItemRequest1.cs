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
using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    public class AddItemRequest1
    {
        private ItemData _Item_Request = null;

        public ItemData Item_Request
        {
            get { return _Item_Request; }
            set { _Item_Request = value; }
        }
    }
}
