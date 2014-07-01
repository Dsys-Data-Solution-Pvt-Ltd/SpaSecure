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
    public class GetInventoryResponce
    {

        private List<AddNewInventory> _Itemid = null;

        public List<AddNewInventory> Itemid
        {
            get { return _Itemid; }
            set { _Itemid = value; }
        }

    }
}
