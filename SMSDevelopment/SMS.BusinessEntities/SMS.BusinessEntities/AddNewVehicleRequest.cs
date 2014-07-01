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
    public class AddNewVehicleRequest
    {
        private Vehicle _vehicle_Request = null;

        public Vehicle vehicle_Request
        {
            get { return _vehicle_Request; }
            set { _vehicle_Request = value; }
        }
    }
}
