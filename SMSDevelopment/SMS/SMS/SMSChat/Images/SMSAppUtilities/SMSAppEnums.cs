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

namespace SMS.SMSAppUtilities
{
    public class SMSAppEnums
    {
        public enum Flags
        {
            YES = 0,
            NO = 1
        }

        public enum ContentType
        {
            None = 0,
            Add = 1,
            Update = 2,
            Delete = 3
        }
    }
}
