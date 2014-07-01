using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class CustomerFeedback
    {
        public string strNameOfTrainee { get; set; }
        public DateTime dtmDateOfEvaluation { get; set; }
        public string strNric { get; set; }
        public string strResponseTime { get; set; }
        public string strSupportServices { get; set; }
        public string strPerformance { get; set; }
        public string strResponsiveness { get; set; }
        public string strTakingInstructions { get; set; }
        public string strResponseToComplaints { get; set; }
        public string strComments { get; set; }
        public string strFeedbackID { get; set; }
    }
}
