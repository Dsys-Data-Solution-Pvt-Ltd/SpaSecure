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
     [Serializable]
    public class AddNewContractorRequest
    {
        private Contractor _Contractor_Request = null;

        public Contractor Contractor_Request
        {
            get { return _Contractor_Request; }
            set { _Contractor_Request = value; }
        }
    }
}

