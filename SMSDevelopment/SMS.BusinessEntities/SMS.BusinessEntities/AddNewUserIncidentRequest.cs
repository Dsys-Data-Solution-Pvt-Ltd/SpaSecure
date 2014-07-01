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
    public class AddNewUserIncidentRequest
    {
        private UserIncident _Incident_Request = null;

        public UserIncident Incident_Request
        {
            get { return _Incident_Request; }
            set { _Incident_Request = value; }
        }
    }
}
