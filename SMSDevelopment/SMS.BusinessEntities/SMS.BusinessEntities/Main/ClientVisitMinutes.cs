using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main
{
    [Serializable]
    public class ClientVisitMinutes
    {
    public string strAssignment  { get; set; }
    public DateTime dtmDateMet  { get; set; }
    public string strMetWith  { get; set; }
    public string strCompletedBy  { get; set; }
    public string strComplaints  { get; set; }
    public string strPositiveComments  { get; set; }
    public string strDeployment  { get; set; }
    public string strEvents  { get; set; }
    public string strRemarks  { get; set; }
    public string strClientVisitID  { get; set; }
    }
}
