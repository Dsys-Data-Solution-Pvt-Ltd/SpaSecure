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
    public class AddTraining
    {
        public String training_id { get; set; }
        public String training_type { get; set; }
        public DateTime? T_startdate { get; set; }
        public DateTime? T_enddate { get; set; }
        public String Venue { get; set; }
        public String Trainee { get; set; }
        public String Facilitation { get; set; }
        public String TraineeDetail { get; set; }

    }
}
