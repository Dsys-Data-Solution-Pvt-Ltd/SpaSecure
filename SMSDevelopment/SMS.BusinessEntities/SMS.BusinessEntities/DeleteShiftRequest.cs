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
    public class DeleteShiftRequest
    {
        String _ShiftNo = string.Empty;
        
        public String ShiftNo
        {
            get
            {
                return _ShiftNo;
            }
            set
            {
                _ShiftNo = value;
            }
        }
       

    }
}
