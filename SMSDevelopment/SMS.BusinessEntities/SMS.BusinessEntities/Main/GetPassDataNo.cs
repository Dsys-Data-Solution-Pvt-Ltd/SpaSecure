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

namespace SMS.BusinessEntities.Main
{
    public class GetPassDataNo
    {
        String _Pass_No = string.Empty;


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




    }
}