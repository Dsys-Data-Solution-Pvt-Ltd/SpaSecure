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

namespace SMS.BusinessEntities
{
    [Serializable]
    public class DeleteIncidentRequest
    {
        String _ReportNo = string.Empty;
        String _Incident_id = string.Empty;
        public String ReportNo
        {
            get
            {
                return _ReportNo;
            }
            set
            {
                _ReportNo = value;
            }
        }
        public String IncidentNo
        {
            get
            {
                return _Incident_id;
            }
            set
            {
                _Incident_id = value;
            }
        }
    }
}
