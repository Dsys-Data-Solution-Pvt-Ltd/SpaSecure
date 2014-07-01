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
    public class AddNewCheckOutRequest
    {
        private List<checkout> _CheckOut_Request = null;
     
        public List<checkout> CheckOut_Request
        {
            get { return _CheckOut_Request; }
            set { _CheckOut_Request = value; }
        }
      
    }
}
