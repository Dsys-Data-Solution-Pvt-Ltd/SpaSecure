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
    public class GetElearnAssignToDataResponse
    {
        private List<elearnAssignTo> _tutid = null;

        public List<elearnAssignTo> tut
        {
            get { return _tutid; }
            set { _tutid = value; }
        }
    }
}
