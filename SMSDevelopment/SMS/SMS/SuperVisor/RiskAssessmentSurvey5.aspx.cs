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
    public partial class RiskAssessmentSurvey5 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[38];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@J1", J1.Text.Trim());
                para[3] = new SqlParameter("@J2", J2.Text.Trim());
                para[4] = new SqlParameter("@J3", J3.Text.Trim());
                para[5] = new SqlParameter("@J4", J4.Text.Trim());
                para[6] = new SqlParameter("@J5", J5.Text.Trim());
                para[7] = new SqlParameter("@J6", J6.Text.Trim());
                para[8] = new SqlParameter("@J7", J7.Text.Trim());
                para[9] = new SqlParameter("@J8", J8.Text.Trim());
                para[10] = new SqlParameter("@J9", J9.Text.Trim());
                para[11] = new SqlParameter("@J10", J10.Text.Trim());
                para[12] = new SqlParameter("@J11", J11.Text.Trim());
                para[13] = new SqlParameter("@J12", J12.Text.Trim());
                para[14] = new SqlParameter("@J13", J13.Text.Trim());

                para[15] = new SqlParameter("@k1",K1.Text.Trim());
                para[16] = new SqlParameter("@k2", K2.Text.Trim());
                para[17] = new SqlParameter("@k3", K3.Text.Trim());
                para[18] = new SqlParameter("@k4", K4.Text.Trim());
                para[19] = new SqlParameter("@k5", K5.Text.Trim());
                para[20] = new SqlParameter("@k6", K6.Text.Trim());
                para[21] = new SqlParameter("@k7", K7.Text.Trim());
                para[22] = new SqlParameter("@k8", K8.Text.Trim());
                para[23] = new SqlParameter("@k9", K9.Text.Trim());
                para[24] = new SqlParameter("@k10", K10.Text.Trim());
                para[25] = new SqlParameter("@k11", K11.Text.Trim());
                para[26] = new SqlParameter("@k12", K12.Text.Trim());
                para[27] = new SqlParameter("@k13", K13.Text.Trim());

                para[28] = new SqlParameter("@k14", K14.Text.Trim());
                para[29] = new SqlParameter("@k15", K15.Text.Trim());
                para[30] = new SqlParameter("@k16", K16.Text.Trim());
                para[31] = new SqlParameter("@k17", K17.Text.Trim());
                para[32] = new SqlParameter("@k18", K18.Text.Trim());
                para[33] = new SqlParameter("@k19", K19.Text.Trim());
                para[34] = new SqlParameter("@K20", K20.Text.Trim());
                para[35] = new SqlParameter("@K21", K21.Text.Trim());
                para[36] = new SqlParameter("@K22", K22.Text.Trim());
                para[37] = new SqlParameter("@K23", K23.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey5", para);

                Response.Redirect("RiskAssessmentSurvey6.aspx");
                //Server.Transfer("RiskAssessmentSurvey6.aspx");
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
