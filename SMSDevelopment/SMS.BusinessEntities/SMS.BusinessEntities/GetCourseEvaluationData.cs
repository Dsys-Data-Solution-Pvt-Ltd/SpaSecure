using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetCourseEvaluationData
    {
        String _EvaluationID = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
        String _whereClause = string.Empty;

        public String evalid
        {
            get
            {
                return _EvaluationID;
            }
            set
            {
                _EvaluationID = value;
            }
        }

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

        public String Date_From
        {
            get
            {
                return _Date_From;
            }
            set
            {
                _Date_From = value;
            }
        }

        public String Date_to
        {
            get
            {
                return _Date_to;
            }
            set
            {
                _Date_to = value;
            }
        }
    }
}
