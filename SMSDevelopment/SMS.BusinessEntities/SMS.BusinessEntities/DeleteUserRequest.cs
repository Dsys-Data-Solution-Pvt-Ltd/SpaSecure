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
    public class DeleteUserRequest
    {
        String _UserNo = string.Empty;
        string _imagepath = string.Empty;

        public String UserNo
        {
            get
            {
                return _UserNo;
            }
            set
            {
                _UserNo = value;
            }
        }
        public String imagepath
        {
            get
            {
                return _imagepath;
            }
            set
            {
                _imagepath = value;
            }
        }

    }
}
