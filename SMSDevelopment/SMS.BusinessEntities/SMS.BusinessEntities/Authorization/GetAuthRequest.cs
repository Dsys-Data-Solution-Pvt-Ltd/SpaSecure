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

namespace SMS.BusinessEntities.Authorization
{
    [Serializable]
    public class GetAuthRequest
    {
       
        private UserInformation _UserInfo;

        public UserInformation UserInfo
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
