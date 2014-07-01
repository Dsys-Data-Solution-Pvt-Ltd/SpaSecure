using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetPenaltyClauseData
    {
        String _penaltyid = string.Empty;
        String _heading = string.Empty;
        String _Date_From = string.Empty;
        String _Date_to = string.Empty;
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

        public String heading
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
            }
        }
        public String penaltyid
        {
            get
            {
                return _penaltyid;
            }
            set
            {
                _penaltyid = value;
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
