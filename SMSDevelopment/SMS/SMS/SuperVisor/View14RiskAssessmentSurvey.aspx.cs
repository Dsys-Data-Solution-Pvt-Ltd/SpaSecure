using System;
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

using Microsoft.SqlServer.Management;
using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class View14RiskAssessmentSurvey : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    DBConnectionHandler1 bd = new DBConnectionHandler1();
                    SqlConnection cn = bd.getconnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(0) != "")
                        {
                            image1.ImageUrl = dr.GetString(0);
                            cn.Close();
                            dr.Close();
                        }
                    }
                    if (Request.QueryString["id"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                        PopulateFuntion(id);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulateFuntion(int argsBGID)
        {
            lblid.Text = Convert.ToString(argsBGID);

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Risk_id", argsBGID);
            DataTable dt = dal.executeprocedure("SP_GetRiskSurvey14", para, false);

            if (dt.Rows.Count > 0)
            {
               UVisitorControl.Text = dt.Rows[0][0].ToString().Trim();
               UEmpAccessControl.Text = dt.Rows[0][1].ToString().Trim();
               UVehicleGate.Text = dt.Rows[0][2].ToString().Trim();
               ULoadingDock.Text = dt.Rows[0][3].ToString().Trim();
               UPropertyControl.Text = dt.Rows[0][4].ToString().Trim();
               UInspectionVehicle.Text = dt.Rows[0][5].ToString().Trim();
               UKeyControl.Text = dt.Rows[0][6].ToString().Trim();
               UBuildingTours.Text = dt.Rows[0][7].ToString().Trim();
               UOperatePatrol.Text = dt.Rows[0][8].ToString().Trim();

               UCashHandling.Text = dt.Rows[0][9].ToString().Trim();
               UConciergeServices.Text = dt.Rows[0][10].ToString().Trim();
               UMonitoringEnvironment.Text = dt.Rows[0][11].ToString().Trim();
               UMonitoringAlarm.Text = dt.Rows[0][12].ToString().Trim();

               UMonitoringAccessControl.Text = dt.Rows[0][13].ToString().Trim();
               UMonitoringCCTVSystem.Text = dt.Rows[0][14].ToString().Trim();
               UIssuingIDBadges.Text = dt.Rows[0][15].ToString().Trim();
               UMaintaining.Text = dt.Rows[0][16].ToString().Trim();
               URespondingAlarmEvents.Text = dt.Rows[0][17].ToString().Trim();
               UFireFighting.Text = dt.Rows[0][18].ToString().Trim();
               UEmergencyMedical.Text = dt.Rows[0][19].ToString().Trim();
               UBombScares.Text = dt.Rows[0][20].ToString().Trim();

               VDetailedPost.Text = dt.Rows[0][21].ToString().Trim();
               VOnSiteSupervisor.Text = dt.Rows[0][22].ToString().Trim();
               VExtraInspection.Text = dt.Rows[0][23].ToString().Trim();
               VTourSystem.Text = dt.Rows[0][24].ToString().Trim();
               VDualControlKey.Text = dt.Rows[0][25].ToString().Trim();
               VSpecialBackground.Text = dt.Rows[0][26].ToString().Trim();

               VKeyHoldHarmless.Text = dt.Rows[0][27].ToString().Trim();
               VSafeDriving.Text = dt.Rows[0][28].ToString().Trim();
               VAfterUseVehicle.Text = dt.Rows[0][29].ToString().Trim();
               VVehicleMaintenanceLog.Text = dt.Rows[0][30].ToString().Trim();
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void bntnext_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("View15RiskAssessmentSurvey.aspx?id=" + lblid.Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
