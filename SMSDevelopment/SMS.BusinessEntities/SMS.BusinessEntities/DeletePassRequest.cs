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
    public class DeletePassRequest
    {
        String _Pass_No = string.Empty;
        String _Pass_Id = string.Empty;

        public String Pass_No
        {
            get
            {
                return _Pass_No;
            }
            set
            {
                _Pass_No = value;
            }
        }
        public String Pass_Id
        {
            get
            {
                return _Pass_Id;
            }
            set
            {
                _Pass_Id = value;
            }
        }
    }
}
