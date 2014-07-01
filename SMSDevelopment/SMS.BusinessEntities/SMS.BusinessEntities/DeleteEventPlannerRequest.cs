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
    public class DeleteEventPlannerRequest
    {
        String _EventID = string.Empty;

        public String EventID
        {
            get
            {
                return _EventID;
            }
            set
            {
                _EventID = value;
            }
        }
    }
}
