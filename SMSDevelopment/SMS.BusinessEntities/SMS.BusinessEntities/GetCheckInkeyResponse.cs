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
    public class GetCheckInkeyResponse
    {
        private List<CheckInKeyData> _CheckIn_id = null;
        public List<CheckInKeyData> CheckIn_id
        {
            get { return _CheckIn_id; }
            set { _CheckIn_id = value; }
        }
    }
}
