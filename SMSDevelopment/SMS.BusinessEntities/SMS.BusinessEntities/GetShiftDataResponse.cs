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
    public class GetShiftDataResponse
    {
        private List<Shift> _Shift_ID = null;

        public List<Shift> Shift_ID
        {
            get { return _Shift_ID; }
            set { _Shift_ID = value; }
        }
    }
}
