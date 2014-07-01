using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class SOBriefing
    {
        public string strLocation { get; set; }
        public DateTime dtmDate { get; set; }
        public DateTime dtmTime { get; set; }
        public string strDetails { get; set; }
        public string strAttendees { get; set; }
    }
}
