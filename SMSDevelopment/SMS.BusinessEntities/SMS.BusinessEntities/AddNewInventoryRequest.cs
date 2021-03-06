﻿using System;
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
    [Serializable]
    public class AddNewInventoryRequest
    {
        private AddNewInventory _Inventory_Request = null;

        public AddNewInventory Inventory_Request
        {
            get { return _Inventory_Request; }
            set { _Inventory_Request = value; }
        }
    }
}