using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    public class GetPenaltyClauseResponse
    {
        private List<PenaltyClause> _penaltyid = null;

        public List<PenaltyClause> Penalty
        {
            get { return _penaltyid; }
            set { _penaltyid = value; }
        }
    }
}
