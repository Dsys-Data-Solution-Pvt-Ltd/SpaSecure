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
    public class AddNewStaffShiftRequest
    {
        private Staff_Shift _Staffshift_Request = null;

        public Staff_Shift Staffshift
        {
            get { return _Staffshift_Request; }
            set { _Staffshift_Request = value; }
        }
    }
}
