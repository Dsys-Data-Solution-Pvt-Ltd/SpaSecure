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
    [Serializable]
    public class GetStaffShift
    {
        String _ShiftID = string.Empty;
        String _StaffID = string.Empty;

        public String ShiftID
        {
            get
            {
                return _ShiftID;
            }
            set
            {
                _ShiftID = value;
            }
        }

        public String StaffID
        {
            get
            {
                return _StaffID;
            }
            set
            {
                _StaffID = value;
            }
        }
    }
}
