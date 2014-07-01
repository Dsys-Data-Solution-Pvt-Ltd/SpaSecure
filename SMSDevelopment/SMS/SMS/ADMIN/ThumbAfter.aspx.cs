using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Collections.Generic;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System.Text.RegularExpressions;
using DPFP;
using DPFP.Verification;
using System.Globalization;

namespace SMS.ADMIN
{
    public partial class ThumbAfter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["SESSION_LOGIN_USER"] == null)
            {
                Response.Redirect("~/master/login3.aspx");
            }
        }

        protected void btnclientvisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperVisor/AdminClientVisitMinutes.aspx");
        }

        protected void btnSiteVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperVisor/AdminAssignment_Vist.aspx");
        }

        //protected void btnSobriefy_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/SuperVisor/AdminSecurityOfficerBriefing.aspx");
        //}

        protected void btnSecurityRisk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperVisor/AdminRiskSurvey.aspx");
        }

        //protected void btnTrainingEvaluation_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/SuperVisor/TrainingEvaluation_Master.aspx");
        //}

        protected void btnStaffFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperVisor/AdminAppraisal.aspx");
        }

        protected void btnChangeNotification_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperVisor/ChangeNotification_Master.aspx");
        }
    }
}
