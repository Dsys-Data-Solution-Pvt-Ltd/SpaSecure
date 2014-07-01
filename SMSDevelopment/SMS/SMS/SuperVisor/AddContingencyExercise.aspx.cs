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
using System.Text.RegularExpressions;

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace SMS.SuperVisor
{
    public partial class AddContingencyExercise : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
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
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }


        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SqlParameter[] para = new SqlParameter[22];
                para[0] = new SqlParameter("@Location_id", searchid.Text);
                para[1] = new SqlParameter("@Exercise_Type",txtExerciseType.Text.Trim());
                para[2] = new SqlParameter("@Mgt_Statff",txtManagementStaff.Text.Trim());
                para[3] = new SqlParameter("@Attendess",txtAttendees.Text.Trim());
                para[4] = new SqlParameter("@Emergency_Type",txtEmergencyType.Text.Trim());
                para[5] = new SqlParameter("@Date", calDate.Text.Trim());
                para[7] = new SqlParameter("@Review",txtReviewDate.Text.Trim());


                para[8] = new SqlParameter("@Objective",txtObjective.Text.Trim());
                para[9] = new SqlParameter("@Contigency_Tigger",txtConigencyTigger.Text.Trim());
                para[10] = new SqlParameter("@Methodology",txtMethodology.Text.Trim());
                para[11] = new SqlParameter("@Roles",txtRoles.Text.Trim());
                para[12] = new SqlParameter("@Status_Reporting",txtStatusReporting.Text.Trim());
                para[13] = new SqlParameter("@Comm_Strategy",txtCommunication.Text.Trim());
                para[14] = new SqlParameter("@Resource_Available",txtResource.Text.Trim());
                para[15] = new SqlParameter("@Finding",txtFinding.Text.Trim());

                para[16] = new SqlParameter("@Frequency",ddlFrequency.Text.Trim());
                para[17] = new SqlParameter("@Severity",ddlServerity.Text.Trim());
                para[18] = new SqlParameter("@RiskFreqSeverity",txtRiskFrequecy.Text.Trim());
                para[19] = new SqlParameter("@RiskPriority",ddlRiskPriority.Text.Trim());
                para[20] = new SqlParameter("@RecommendedControl",txtRecommended.Text.Trim());
                para[21] = new SqlParameter("@RevisedRiskPriority",ddlRevisedRisk.Text.Trim());
                para[6] = new SqlParameter("@FromDate",DateTime.Now);


                dal.executeprocedure("SP_AddContigencyExercise", para);

                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                Server.Transfer("CompleteForm.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }       

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnClearItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {  
                ddllocation.Text = "";
                txtEmergencyType.Text = "";
                txtManagementStaff.Text = "";
                txtAttendees.Text = "";
                txtEmergencyType.Text = "";
                calDate.Text = "";
                txtReviewDate.Text = "";

                txtObjective.Text = "";
                txtConigencyTigger.Text = "";
                txtMethodology.Text = "";
                txtRoles.Text = "";
                txtStatusReporting.Text = "";
                txtCommunication.Text = "";
                txtResource.Text = "";
                txtFinding.Text = "";

                ddlFrequency.Text = "";
                ddlServerity.Text = "";
                txtRiskFrequecy.Text = "";
                ddlRiskPriority.Text = "";
                txtRecommended.Text = "";
                ddlRevisedRisk.Text = "";
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}