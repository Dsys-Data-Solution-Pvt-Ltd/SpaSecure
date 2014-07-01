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
using System.Data.SqlClient;
using System.Collections.Generic;

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class RiskAssessmentSurvey14 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblid.Text = GlobalVar.Risk_ID.ToString();

                SqlParameter[] para = new SqlParameter[33];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@UVisitorControl", ddlUVisitorControl.Text.Trim());
                para[3] = new SqlParameter("@UEmployee", ddlUEmpAccessControl.Text.Trim());
                para[4] = new SqlParameter("@UVechileGate", ddlUVehicleGate.Text.Trim());
                para[5] = new SqlParameter("@ULoadingDock", ddlULoadingDock.Text.Trim());

                para[6] = new SqlParameter("@UPropertyCont", ddlUPropertyControl.Text.Trim());
                para[7] = new SqlParameter("@UInspection", ddlUInspection.Text.Trim());
                para[8] = new SqlParameter("@UKeyControl", ddlUKeyContorl.Text.Trim());
                para[9] = new SqlParameter("@UBuilding", ddlUBuildingTour.Text.Trim());
                para[10] = new SqlParameter("@UOperatePetrol", ddlUOperatePatrol.Text.Trim());
                para[11] = new SqlParameter("@UCashHandling", ddlUCashHandling.Text.Trim());
                para[12] = new SqlParameter("@UConcierge", ddlUConcierge.Text.Trim());
                para[13] = new SqlParameter("@UEnvironment", ddlUMonitoring.Text.Trim());
                para[14] = new SqlParameter("@UAlarmSystem", ddlUMonitoringAlarm.Text.Trim());
                para[15] = new SqlParameter("@UAccessControl", ddlUMonitoringAccess.Text.Trim());
                para[16] = new SqlParameter("@UCCTVControl", ddlUMonitoringCCTV.Text.Trim());

                para[17] = new SqlParameter("@UIDBadge", ddlUIssuingIDBadges.Text.Trim());
                para[18] = new SqlParameter("@UMaintainSystem", ddlUMaintaningSystem.Text.Trim());
                para[19] = new SqlParameter("@UAlarmEvent", ddlUResponding.Text.Trim());
                para[20] = new SqlParameter("@UFireFighting", ddlUFireFighting.Text.Trim());
                para[21] = new SqlParameter("@UEmergencyMedical", ddlUEmergencyMedical.Text.Trim());
                para[22] = new SqlParameter("@UBomb", ddlUBombScares.Text.Trim());

                para[23] = new SqlParameter("@VDetailPost", ddlVDetailedPostOrders.Text.Trim());
                para[24] = new SqlParameter("@VOnsite", ddlVOnSiteSuperVisor.Text.Trim());
                para[25] = new SqlParameter("@VExtraInspection", ddlVExtraInspection.Text.Trim());
                para[26] = new SqlParameter("@VTourSystem", ddlVTourSystem.Text.Trim());
                para[27] = new SqlParameter("@VDualControl", ddlVDualControl.Text.Trim());
                para[28] = new SqlParameter("@VSpecialBackGround", ddlVSpecialBackground.Text.Trim());
                para[29] = new SqlParameter("@VKeyHold", ddlVKeyHold.Text.Trim());
                para[30] = new SqlParameter("@VSafeDriving", ddlVSafeDrivingVideo.Text.Trim());

                para[31] = new SqlParameter("@VAfterUse", ddlVAfterUseVehicle.Text.Trim());
                para[32] = new SqlParameter("@VVehicleMaintenance", ddlVVehicleMaintenance.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey14", para);
                Response.Redirect("RiskAssessmentSurvey15.aspx");

                //Server.Transfer("RiskAssessmentSurvey15.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private String RiskSurveyid()
        {
            String id = string.Empty;

            SqlDataReader drid = dal.getDataReader("Select Code from Log where ID='RiskSurvey'");
            if (drid.Read())
            {
                id = drid.GetValue(0).ToString().Trim();
                drid.Close();
                return id;
            }
            drid.Close();
            return id;
        }



    }
}
