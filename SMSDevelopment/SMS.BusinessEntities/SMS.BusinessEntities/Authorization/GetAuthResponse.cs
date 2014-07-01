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
using SMS.BusinessEntities.Main;
using System.Collections.Generic;


namespace SMS.BusinessEntities.Authorization
{
    [Serializable]
    public class GetAuthResponse
    {
        List<UserInformation> _UserInfo = null;

        public List<UserInformation> UserInfo
        {
            get
            {
                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }
    }
}
