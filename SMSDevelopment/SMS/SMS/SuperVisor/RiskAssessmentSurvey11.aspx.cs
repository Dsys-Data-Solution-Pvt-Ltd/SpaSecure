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
    public partial class RiskAssessmentSurvey11 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[34];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@Q9", ddlQ9.Text.Trim());
                para[3] = new SqlParameter("@Q10A", ddlQ10A.Text.Trim());
                para[4] = new SqlParameter("@Q10B", ddlQ10B.Text.Trim());
                para[5] = new SqlParameter("@Q10C", ddlQ10C.Text.Trim());
                para[6] = new SqlParameter("@Q10D", ddlQ10D.Text.Trim());

                para[7] = new SqlParameter("@Q11", ddlQ11.Text.Trim());
                para[8] = new SqlParameter("@Q12", ddlQ12.Text.Trim());
                para[9] = new SqlParameter("@Q13", ddlQ13.Text.Trim());
                para[10] = new SqlParameter("@Q14", ddlQ14.Text.Trim());
                para[11] = new SqlParameter("@Q15", ddlQ15.Text.Trim());
                para[12] = new SqlParameter("@Q16", ddlQ16.Text.Trim());
                para[13] = new SqlParameter("@Q17", ddlQ17.Text.Trim());
                para[14] = new SqlParameter("@Q18", ddlQ18.Text.Trim());

                para[15] = new SqlParameter("@Q19", ddlQ19.Text.Trim());
                para[16] = new SqlParameter("@Q20", ddlQ20.Text.Trim());
                para[17] = new SqlParameter("@Q21", ddlQ21.Text.Trim());
                para[18] = new SqlParameter("@Q22", ddlQ22.Text.Trim());
                para[19] = new SqlParameter("@Q23", ddlQ23.Text.Trim());
                para[20] = new SqlParameter("@Q24", ddlQ24.Text.Trim());
                para[21] = new SqlParameter("@Q25", ddlQ25.Text.Trim());
                para[22] = new SqlParameter("@Q26", ddlQ26.Text.Trim());
                para[23] = new SqlParameter("@Q27", ddlQ27.Text.Trim());
                para[24] = new SqlParameter("@Q28", ddlQ28.Text.Trim());
                para[25] = new SqlParameter("@Q29", ddlQ29.Text.Trim());
                para[26] = new SqlParameter("@Q30", ddlQ30.Text.Trim());
                para[27] = new SqlParameter("@Q31", ddlQ31.Text.Trim());
                para[28] = new SqlParameter("@Q32", ddlQ32.Text.Trim());

                para[29] = new SqlParameter("@R1", ddlR1.Text.Trim());
                para[30] = new SqlParameter("@R2", ddlR2.Text.Trim());
                para[31] = new SqlParameter("@R3", ddlR3.Text.Trim());
                para[32] = new SqlParameter("@R4", ddlR4.Text.Trim());
                para[33] = new SqlParameter("@R5", ddlR5.Text.Trim());               

                dal.executeprocedure("SP_RiskSurvey11", para);
                Response.Redirect("RiskAssessmentSurvey12.aspx");

                //Server.Transfer("RiskAssessmentSurvey12.aspx");
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
