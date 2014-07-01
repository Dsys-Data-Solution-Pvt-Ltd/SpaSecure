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
    public class AddNewElearnReuest
    {
        private Elearn _Elearn_Request = null;

        public Elearn Elearn_Request
        {
            get { return _Elearn_Request; }
            set { _Elearn_Request = value; }
        }
    }
}
