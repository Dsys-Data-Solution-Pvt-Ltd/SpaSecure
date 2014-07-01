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
    public class DeleteInventoryRequest
    {

        String _InventoryItemId = string.Empty;

        public String InventoryItemId
        {
            get
            {
                return _InventoryItemId;
            }
            set
            {
                _InventoryItemId = value;
            }
        }

    }
}
