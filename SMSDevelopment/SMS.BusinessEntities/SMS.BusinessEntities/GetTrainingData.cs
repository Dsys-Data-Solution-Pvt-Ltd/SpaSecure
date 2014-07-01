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

namespace SMS.BusinessEntities
{
    public class GetTrainingData
    {

        String _Trainingid = string.Empty;
        String _TrainingType = string.Empty;
        String _Venue = string.Empty;
        String _TStartDate = string.Empty;
        String _TEndDate = string.Empty;

        String _Trainee = string.Empty;
        String _Facilitation = string.Empty;
        String _TraineeDetail = string.Empty;
       
        
        String _whereClause = string.Empty;

        public String WhereClause
        {
            get
            {
                return _whereClause;
            }
            set
            {
                _whereClause = value;
            }
        }
        public String Trainingid
        {
            get
            {
                return _Trainingid;
            }
            set
            {
                _Trainingid = value;
            }
        }
        public String TrainingType
        {
            get
            {
                return _TrainingType;
            }
            set
            {
                _TrainingType = value;
            }
        }
        public String Venue
        {
            get
            {
                return _Venue;
            }
            set
            {
                _Venue = value;
            }
        }
        public String TStartDate
        {
            get
            {
                return _TStartDate;
            }
            set
            {
                _TStartDate = value;
            }
        }
        public String TEndDate
        {
            get
            {
                return _TEndDate;
            }
            set
            {
                _TEndDate = value;
            }
        }

        public String Trainee
        {
            get
            {
                return _Trainee;
            }
            set
            {
                _Trainee = value;
            }
        }

        public String Facilitation
        {
            get
            {
                return _Facilitation;
            }
            set
            {
                _Facilitation = value;
            }
        }

        public String TraineeDetail
        {
            get
            {
                return _TraineeDetail;
            }
            set
            {
                _TraineeDetail = value;
            }
        }



    }
}
