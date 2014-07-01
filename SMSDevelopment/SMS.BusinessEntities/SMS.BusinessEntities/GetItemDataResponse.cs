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

namespace SMS.BusinessEntities
{  
    [Serializable]
    public class GetItemDataResponse
    {
        private List<ItemData> _ItemNo = null;

        public List<ItemData> Item
        {
            get { return _ItemNo; }
            set { _ItemNo = value; }
        }
    }
}
