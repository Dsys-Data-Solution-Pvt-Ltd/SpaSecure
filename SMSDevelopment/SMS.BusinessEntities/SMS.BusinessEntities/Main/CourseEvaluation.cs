using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class CourseEvaluation
    {
        public enum Rate
        {
            Poor, Fair, Average, Good, Excellent
        };
        public string strNameOfTrainee;
        public DateTime dtmDateOfEvaluation;
        public string strNric;
        public string strComments;
        public bool ysnHandouts;
        public bool ysnDuration;
        public bool ysnSupportServices;
        public bool ysnQuestion;
        public bool ysnCapabilities;
        public bool ysnReliability;
        
    }
}
