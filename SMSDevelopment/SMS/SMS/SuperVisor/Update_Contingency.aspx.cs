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
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class Update_Contingency : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String iBTID = string.Empty;
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    fillLocation();
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Location_id,Exercise_Type,Mgt_Statff,Attendess,Emergency_Type,Date,Review,Objective,Contigency_Tigger,Methodology,Roles,Status_Reporting,Comm_Strategy,Resource_Available,Finding,Frequency,Severity,RiskFreqSeverity,RiskPriority,RecommendedControl,RevisedRiskPriority from ContigencyExercise where ContExericise_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                hdnBTID.Value = argsBGID;
                string names = dspan.Tables[0].Rows[0][0].ToString().Trim();
                ddllocation.Text = GetLocationNameByID(names);
                txtExerciseType.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtManagementStaff.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtAttendees.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();
                
                txtEmergencyType.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                calDate.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();

                txtReviewDate.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtObjective.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();
                txtConigencyTigger.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();
                txtMethodology.Text = dspan.Tables[0].Rows[0][9].ToString().Trim();
                txtRoles.Text = dspan.Tables[0].Rows[0][10].ToString().Trim();
                txtStatusReporting.Text = dspan.Tables[0].Rows[0][11].ToString().Trim();

                txtCommunication.Text = dspan.Tables[0].Rows[0][12].ToString().Trim();
                txtResource.Text = dspan.Tables[0].Rows[0][13].ToString().Trim();
                txtFinding.Text = dspan.Tables[0].Rows[0][14].ToString().Trim();
                ddlFrequency.Text = dspan.Tables[0].Rows[0][15].ToString().Trim();
                ddlServerity.Text = dspan.Tables[0].Rows[0][16].ToString().Trim();
                txtRiskFrequecy.Text = dspan.Tables[0].Rows[0][17].ToString().Trim();

                ddlRiskPriority.Text = dspan.Tables[0].Rows[0][18].ToString().Trim();
                txtRecommended.Text = dspan.Tables[0].Rows[0][19].ToString().Trim();
                ddlRevisedRisk.Text = dspan.Tables[0].Rows[0][20].ToString().Trim();

            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[22];
                para[0] = new SqlParameter("@Location_id", GetLocationIDbyName(ddllocation.Text.Trim()));
                para[1] = new SqlParameter("@Exercise_Type", txtExerciseType.Text.Trim());
                para[2] = new SqlParameter("@Mgt_Statff", txtManagementStaff.Text.Trim());
                para[3] = new SqlParameter("@Attendess", txtAttendees.Text.Trim());
                para[4] = new SqlParameter("@Emergency_Type", txtEmergencyType.Text.Trim());
                para[5] = new SqlParameter("@Date", calDate.Text.Trim());
                para[7] = new SqlParameter("@Review", txtReviewDate.Text.Trim());


                para[8] = new SqlParameter("@Objective", txtObjective.Text.Trim());
                para[9] = new SqlParameter("@Contigency_Tigger", txtConigencyTigger.Text.Trim());
                para[10] = new SqlParameter("@Methodology", txtMethodology.Text.Trim());
                para[11] = new SqlParameter("@Roles", txtRoles.Text.Trim());
                para[12] = new SqlParameter("@Status_Reporting", txtStatusReporting.Text.Trim());
                para[13] = new SqlParameter("@Comm_Strategy", txtCommunication.Text.Trim());
                para[14] = new SqlParameter("@Resource_Available", txtResource.Text.Trim());
                para[15] = new SqlParameter("@Finding", txtFinding.Text.Trim());

                para[16] = new SqlParameter("@Frequency", ddlFrequency.Text.Trim());
                para[17] = new SqlParameter("@Severity", ddlServerity.Text.Trim());
                para[18] = new SqlParameter("@RiskFreqSeverity", txtRiskFrequecy.Text.Trim());
                para[19] = new SqlParameter("@RiskPriority", ddlRiskPriority.Text.Trim());
                para[20] = new SqlParameter("@RecommendedControl", txtRecommended.Text.Trim());
                para[21] = new SqlParameter("@RevisedRiskPriority", ddlRevisedRisk.Text.Trim());
                para[6] = new SqlParameter("@ContExericise_id",hdnBTID.Value);


                dal.executeprocedure("SP_UpdateContigencyExercise", para);

                HttpContext.Current.Items.Add("UPDATE","Update");
                Server.Transfer("AdminContingencyExercise.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
                }
            }
        }


        private int GetLocationIDbyName(string Name)
        {
            int id = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                id = Convert.ToInt32(dsLocationid.Rows[0][0].ToString().Trim());
                return id;
            }
            return id;
        }


        private string GetLocationNameByID(string id)
        {
            string name = string.Empty;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocation = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                name = dsLocation.Rows[0][0].ToString().Trim();
                return name;
            }
            return name;
        }


        protected void btnviewAll_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("AdminContingencyExercise.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }






    }
}
