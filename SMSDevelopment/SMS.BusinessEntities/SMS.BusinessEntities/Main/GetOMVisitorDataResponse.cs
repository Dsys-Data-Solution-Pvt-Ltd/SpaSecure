using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    public class GetOMVisitorDataResponse
    {
        private List<Visitor> _checkinid = null;

        public List<Visitor> OMVisitor
        {
            get { return _checkinid; }
            set { _checkinid = value; }
        }

    }
}