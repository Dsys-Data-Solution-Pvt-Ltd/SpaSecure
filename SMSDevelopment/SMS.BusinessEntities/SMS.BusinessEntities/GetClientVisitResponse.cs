using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetClientVisitResponse
    {
        private List<ClientVisitMinutes> _visitid = null;

        public List<ClientVisitMinutes> Visit
        {
            get { return _visitid; }
            set { _visitid = value; }
        }
    }
}
