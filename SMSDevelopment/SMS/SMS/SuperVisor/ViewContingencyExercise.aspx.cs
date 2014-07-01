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

//using Microsoft.SqlServer.Management.Trace;
using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System;

namespace SMS.SuperVisor
{
    public partial class ViewContingencyExercise : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;

            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select Location_id,Exercise_Type,Mgt_Statff,Attendess,Emergency_Type,Date,Review,Objective,Contigency_Tigger,Methodology,Roles,Status_Reporting,Comm_Strategy,Resource_Available,Finding,Frequency,Severity,RiskFreqSeverity,RiskPriority,RecommendedControl,RevisedRiskPriority from ContigencyExercise where ContExericise_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {

                string names = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtlocation.Text = GetLocationNameByID(names);
                txtExerciseType.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtManagement.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtAttendees.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

                txtEmergencyType.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                txtDate.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();

                txtReviewDate.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtObjective.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();
                txtContigencyTigger.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();
                txtMethodology.Text = dspan.Tables[0].Rows[0][9].ToString().Trim();
                txtRoles.Text = dspan.Tables[0].Rows[0][10].ToString().Trim();
                txtStatusReporting.Text = dspan.Tables[0].Rows[0][11].ToString().Trim();

                txtCommunication.Text = dspan.Tables[0].Rows[0][12].ToString().Trim();
                txtResource.Text = dspan.Tables[0].Rows[0][13].ToString().Trim();
                txtFinding.Text = dspan.Tables[0].Rows[0][14].ToString().Trim();
                txtFrequency.Text = dspan.Tables[0].Rows[0][15].ToString().Trim();
                txtSeverity.Text = dspan.Tables[0].Rows[0][16].ToString().Trim();
                txtRiskFrequency.Text = dspan.Tables[0].Rows[0][17].ToString().Trim();

                txtRiskPriority.Text = dspan.Tables[0].Rows[0][18].ToString().Trim();
                txtRecommended.Text = dspan.Tables[0].Rows[0][19].ToString().Trim();
                txtRevisedRisk.Text = dspan.Tables[0].Rows[0][20].ToString().Trim();
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


    }
}
