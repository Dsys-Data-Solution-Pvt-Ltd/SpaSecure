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
    
    public class GetPassDataResponse
    {
        private List<Pass> _PassNo = null;
        private List<PassNo> _Passcount = null;

        public List<Pass> Pass
        {
            get { return _PassNo; }
            set { _PassNo = value; }
        }

        public List<PassNo> Passcount
        {
            get { return _Passcount; }
            set { _Passcount = value; }
        }



    }
}
