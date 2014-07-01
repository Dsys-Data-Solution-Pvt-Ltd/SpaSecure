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
    public class AddNewShiftRequest
    {
        private Shift _Shift_Request = null;

        public Shift Shift_Request
        {
            get { return _Shift_Request; }
            set { _Shift_Request = value; }
        }
    }
}
