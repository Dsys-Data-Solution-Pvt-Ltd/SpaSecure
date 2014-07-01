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
    public class DeleteKeyRequest
    {
        String _KeyNo = string.Empty;

        public String KeyNo
        {
            get
            {
                return _KeyNo;
            }
            set
            {
                _KeyNo = value;
            }
        }
    }
}
