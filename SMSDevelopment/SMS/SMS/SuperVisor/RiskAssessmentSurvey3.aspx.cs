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
    public partial class RiskAssessmentSurvey3 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    DALConstants dl = new DALConstants();
                    dl.DeleteRecord("RiskSurvey3");
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
                SqlParameter[] para = new SqlParameter[38];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@D1",D1.Text.Trim());
                para[3] = new SqlParameter("@D2", D2.Text.Trim());
                para[4] = new SqlParameter("@D3", D3.Text.Trim());
                para[5] = new SqlParameter("@D4", D4.Text.Trim());

                para[6] = new SqlParameter("@D5", D5.Text.Trim());
                para[7] = new SqlParameter("@D6", D6.Text.Trim());
                para[8] = new SqlParameter("@D7", D7.Text.Trim());
                para[9] = new SqlParameter("@D7Comment",Dcomment.Text.Trim());
                para[10] = new SqlParameter("@E1",E1.Text.Trim());
                para[11] = new SqlParameter("@E2", E2.Text.Trim());
                para[12] = new SqlParameter("@E3", E3.Text.Trim());
                para[13] = new SqlParameter("@E4", E4.Text.Trim());
                para[14] = new SqlParameter("@E5", E5.Text.Trim());
                para[15] = new SqlParameter("@E6", E6.Text.Trim());
                para[16] = new SqlParameter("@E7", E7.Text.Trim());

                para[17] = new SqlParameter("@E8", E8.Text.Trim());
                para[18] = new SqlParameter("@E9", E9.Text.Trim());
                para[19] = new SqlParameter("@E10", E10.Text.Trim());
                para[20] = new SqlParameter("@E11", E11.Text.Trim());
                para[21] = new SqlParameter("@E12", E12.Text.Trim());

                para[22] = new SqlParameter("@F1", F1.Text.Trim());
                para[23] = new SqlParameter("@F2", F2.Text.Trim());
                para[24] = new SqlParameter("@F3", F3.Text.Trim());
                para[25] = new SqlParameter("@F4", F4.Text.Trim());

                para[26] = new SqlParameter("@G1", G1.Text.Trim());
                para[27] = new SqlParameter("@G2", G2.Text.Trim());
                para[28] = new SqlParameter("@G3", G3.Text.Trim());
                para[29] = new SqlParameter("@G4", G4.Text.Trim());
                para[30] = new SqlParameter("@G5", G5.Text.Trim());
                para[31] = new SqlParameter("@G6", G6.Text.Trim());
                para[32] = new SqlParameter("@G7", G7.Text.Trim());
                para[33] = new SqlParameter("@G8", G8.Text.Trim());
                para[34] = new SqlParameter("@G9", G9.Text.Trim());
                para[35] = new SqlParameter("@G10", G10.Text.Trim());
                para[36] = new SqlParameter("@G11", G11.Text.Trim());
                para[37] = new SqlParameter("@G12", G12.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey3", para);
                //Server.Transfer("RiskAssessmentSurvey4.aspx");
                Response.Redirect("RiskAssessmentSurvey4.aspx");
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
