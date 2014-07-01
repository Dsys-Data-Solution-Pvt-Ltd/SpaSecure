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
    public class GetDataEventResponse
    {
        private List<eventAdmin> _EventNo = null;

        public List<eventAdmin> Eventid
        {
            get { return _EventNo; }
            set { _EventNo = value; }
        }
    }
}
