using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class GetCourseEvaluationResponse
    {
        private List<CourseEvaluation> _evalid = null;

        public List<CourseEvaluation> Evaluation
        {
            get { return _evalid; }
            set { _evalid = value; }
        }
    }
}
