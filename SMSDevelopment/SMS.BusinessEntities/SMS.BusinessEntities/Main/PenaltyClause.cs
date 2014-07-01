using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class PenaltyClause
    {
        public string strPenaltyID { get; set; }
        public DateTime dtmDateCreated { get; set; }
        public string strHeading { get; set; }
        public decimal dblFine { get; set; }
        public string strClause { get; set; }
    }
}
