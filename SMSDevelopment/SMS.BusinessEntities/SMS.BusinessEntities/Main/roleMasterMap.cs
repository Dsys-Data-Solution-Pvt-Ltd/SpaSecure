using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    public class roleMasterMap
    {
        public int rMastMp_Id { get; set; }
        public int rMastMp_RoleId { get; set; }
        public int rMastMp_MenuId { get; set; }
        public string rMastMp_Addright { get; set; }
        public int rMastMp_readonly { get; set; }
        public int rMastMp_writeonly { get; set; }
        public int rmastMp_ParentId { get; set; }
        //public string rmastMP_ParentId1 { get; set; }
 
    }
}