using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class LostFoundItem
    {

        public String Lost_ID { get; set; }

        public String Name { get; set; }
        public String NRICno { get; set; }
        public String Location { get; set; }
        public String ContNo { get; set; }
        //public DateTime Date { get; set; }
        public string  Date { get; set; }
        public String Time { get; set; }
        //public DateTime Description { get; set; }
        public string  Description { get; set; }

        public String LostStatus { get; set; }
        public string NameOfReporting { get; set; }
        

    }
}