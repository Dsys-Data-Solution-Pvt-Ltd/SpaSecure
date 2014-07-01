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

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class LocationData
    {
        public String Location_id { get; set; }
        public String Location_name { get; set; }
        public String code { get; set; }
        public String Loc_Address { get; set; }

        public String F_cont { get; set; }
        public String F_Mob { get; set; }
        public String F_Email { get; set; }
        public String F_Fax { get; set; }

        public String O_cont { get; set; }
        public String O_Mob { get; set; }
        public String O_Email { get; set; }
        public String O_Fax { get; set; }

        public String M_cont { get; set; }
        public String M_Mob { get; set; }
        public String M_Email { get; set; }
        public String M_Fax { get; set; }

        public String Emergency_email { get; set; }

        public String Chift_Security_day { get; set; }
        public String Supervisor_day { get; set; }
        public String Senior_Secu_Off_day { get; set; }
        public String Security_Off_day { get; set; }

        public String Chift_Security_nig { get; set; }
        public String Supervisor_nig { get; set; }
        public String Senior_Secu_Off_nig { get; set; }
        public String Security_Off_nig { get; set; }

        public String Contract_value { get; set; }
        public String Current_Status { get; set; }

        public DateTime? Contract_start_date { get; set; }
        public DateTime? Contract_expire_date { get; set; }
        public DateTime? Date_From { get; set; }
        public DateTime? Date_to { get; set; }

        public String Finance_Name { get; set; }
        public String Operation_Name { get; set; }
        public String Management_Name { get; set; }

        public String OtherPerson1 { get; set; }
        public String OtherPerson1_day { get; set; }
        public String OtherPerson1_nig { get; set; }

        public String OtherPerson2 { get; set; }
        public String OtherPerson2_day { get; set; }
        public String OtherPerson2_nig { get; set; }

        public String OtherPerson3 { get; set; }
        public String OtherPerson3_day { get; set; }
        public String OtherPerson3_nig { get; set; }

        public String ClientUserID { get; set; }
        public String ClientPassword { get; set; }


    }
}
