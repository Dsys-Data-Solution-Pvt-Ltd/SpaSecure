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
    public partial class RiskAssessmentSurvey2 : System.Web.UI.Page
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
                    dl.DeleteRecord("RiskSurvey2");
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
                SqlParameter[] para = new SqlParameter[37];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@B21", B21.Text.Trim());
                para[3] = new SqlParameter("@B22", B22.Text.Trim());
                para[4] = new SqlParameter("@B23", B23.Text.Trim());
                para[5] = new SqlParameter("@B24", B24.Text.Trim());                
                para[6] = new SqlParameter("@B25", B25.Text.Trim());
                para[7] = new SqlParameter("@B26", B26.Text.Trim());
                para[8] = new SqlParameter("@B27", B27.Text.Trim());
                para[9] = new SqlParameter("@B28", B28.Text.Trim());
                para[10] = new SqlParameter("@B29", B29.Text.Trim());
                para[11] = new SqlParameter("@B30", B30.Text.Trim());
                para[12] = new SqlParameter("@B31", B31.Text.Trim());
                para[13] = new SqlParameter("@B32", B32.Text.Trim());
                para[14] = new SqlParameter("@B33", B33.Text.Trim());
                para[15] = new SqlParameter("@B34", B34.Text.Trim());
                para[16] = new SqlParameter("@B35", B35.Text.Trim());
                para[17] = new SqlParameter("@B36", B36.Text.Trim());
                para[18] = new SqlParameter("@B37", B37.Text.Trim());
                para[19] = new SqlParameter("@B38", B38.Text.Trim());
                para[20] = new SqlParameter("@B39", B39.Text.Trim());
                para[21] = new SqlParameter("@B40", B40.Text.Trim());

                para[22] = new SqlParameter("@B41", B41.Text.Trim());
                para[23] = new SqlParameter("@B42", B42.Text.Trim());
                para[24] = new SqlParameter("@B43", B43.Text.Trim());
                para[25] = new SqlParameter("@B44", B44.Text.Trim());
                para[26] = new SqlParameter("@B45", B45.Text.Trim());
                para[27] = new SqlParameter("@B46", B46.Text.Trim());
                para[28] = new SqlParameter("@B47", B47.Text.Trim());

                para[29] = new SqlParameter("@C1", C1.Text.Trim());
                para[30] = new SqlParameter("@C2", C2.Text.Trim());
                para[31] = new SqlParameter("@C3", C3.Text.Trim());
                para[32] = new SqlParameter("@C4", C4.Text.Trim());
                para[33] = new SqlParameter("@C5", C5.Text.Trim());
                para[34] = new SqlParameter("@C6", C6.Text.Trim());
                para[35] = new SqlParameter("@C7", C7.Text.Trim());
                para[36] = new SqlParameter("@C8", C8.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey2", para);

                //Server.Transfer("RiskAssessmentSurvey3.aspx");
                Response.Redirect("RiskAssessmentSurvey3.aspx");
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
