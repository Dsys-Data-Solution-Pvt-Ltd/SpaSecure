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
    public partial class RiskAssessmentSurvey6 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[50];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@K24", K24.Text.Trim());
                para[3] = new SqlParameter("@K25", K25.Text.Trim());
                para[4] = new SqlParameter("@K26", K26.Text.Trim());
                para[5] = new SqlParameter("@K27", K27.Text.Trim());
                para[6] = new SqlParameter("@K28", K28.Text.Trim());
                para[7] = new SqlParameter("@K29", K29.Text.Trim());
                para[8] = new SqlParameter("@K30", K30.Text.Trim());
                para[9] = new SqlParameter("@K31", K31.Text.Trim());
                para[10] = new SqlParameter("@K31A", K31A.Text.Trim());
                para[11] = new SqlParameter("@K31B", K31B.Text.Trim());
                para[12] = new SqlParameter("@K31C", K31C.Text.Trim());

                para[13] = new SqlParameter("@K32", K32.Text.Trim());
                para[14] = new SqlParameter("@K32A", K32A.Text.Trim());
                para[15] = new SqlParameter("@K32B", K32B.Text.Trim());
                para[16] = new SqlParameter("@K32C", K32C.Text.Trim());
                para[17] = new SqlParameter("@K32D", K32D.Text.Trim());

                para[18] = new SqlParameter("@K33", K33.Text.Trim());
                para[19] = new SqlParameter("@K34", K34.Text.Trim());
                para[20] = new SqlParameter("@K35", K35.Text.Trim());
                para[21] = new SqlParameter("@K36", K36.Text.Trim());               

                para[22] = new SqlParameter("@L1Key", (ChkKeys.Checked == true ? ChkKeys.Text.Trim() : " "));
                para[23] = new SqlParameter("@L1AccessCard", (ChkAccessCard.Checked == true ? ChkAccessCard.Text.Trim() : " "));
                para[24] = new SqlParameter("@L1IPBadge", (ChkIDBadges.Checked == true ? ChkIDBadges.Text.Trim() : " "));
                para[25] = new SqlParameter("@L1Security", (ChkSecurityOfficer.Checked == true ? ChkSecurityOfficer.Text.Trim() : " "));
                para[26] = new SqlParameter("@L1OpenEntry", (ChkOpenEntry.Checked == true ? ChkOpenEntry.Text.Trim() : " "));

                para[27] = new SqlParameter("@L2Key", (ChkAfterKeys.Checked == true ? ChkAfterKeys.Text.Trim() : " "));
                para[28] = new SqlParameter("@L2AccessCard", (ChkAfterAccessCard.Checked == true ? ChkAfterAccessCard.Text.Trim() : " "));
                para[29] = new SqlParameter("@L2IPBadge", (ChkAfterIDBadges.Checked == true ? ChkAfterIDBadges.Text.Trim() : " "));
                para[30] = new SqlParameter("@L2Security", (ChkAfterSecurityOfficer.Checked == true ? ChkAfterSecurityOfficer.Text.Trim() : " "));
                para[31] = new SqlParameter("@L2OpenEntry", (ChkAfterOpenEntry.Checked == true ? ChkAfterOpenEntry.Text.Trim() : " "));

                para[32] = new SqlParameter("@L3", L3.Text.Trim());
                para[33] = new SqlParameter("@L4", L4.Text.Trim());
                para[34] = new SqlParameter("@L5", L5.Text.Trim());
                para[35] = new SqlParameter("@L6", L6.Text.Trim());
                para[36] = new SqlParameter("@L7", L7.Text.Trim());
                para[37] = new SqlParameter("@L8", L8.Text.Trim());

                para[38] = new SqlParameter("@L9", L9.Text.Trim());
                para[39] = new SqlParameter("@L10", L10.Text.Trim());
                para[40] = new SqlParameter("@L11", L11.Text.Trim());
                para[41] = new SqlParameter("@L12", L12.Text.Trim());
                para[42] = new SqlParameter("@L13", L13.Text.Trim());
                para[43] = new SqlParameter("@L14", L14.Text.Trim());

                para[44] = new SqlParameter("@L15", L15.Text.Trim());
                para[45] = new SqlParameter("@L16", L16.Text.Trim());
                para[46] = new SqlParameter("@L17", L17.Text.Trim());
                para[47] = new SqlParameter("@L18", L18.Text.Trim());
                para[48] = new SqlParameter("@L19", L19.Text.Trim());
                para[49] = new SqlParameter("@L20", L20.Text.Trim());


                dal.executeprocedure("SP_RiskSurvey6", para);

                Response.Redirect("RiskAssessmentSurvey7.aspx");
                //Server.Transfer("RiskAssessmentSurvey7.aspx");
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
