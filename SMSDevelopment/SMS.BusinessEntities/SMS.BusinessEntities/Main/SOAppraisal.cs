using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class SOAppraisal
    {
        public string strName { get; set; }
        public DateTime dtmDate { get; set; }
        public string strCategory { get; set; }
    }
}
