using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class CustomerComplaint
    {
        public string strLogNo { get; set; }
        public DateTime dtmDate { get; set; }
        public string strDocument { get; set; }
        public string strAuditNo { get; set; }
        public string strDescription { get; set; }
        public string strRaisedBy { get; set; }
        public string strCause { get; set; }
        public string strActionFix { get; set; }
        public string strActionPrevent { get; set; }
        public DateTime dtmExpectedCompletion { get; set; }
        public DateTime dtmActionApproved { get; set; }
    }
}
