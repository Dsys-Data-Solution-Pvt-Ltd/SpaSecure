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
    public partial class RiskAssessmentSurvey13 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[43];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@T23", ddlT23.Text.Trim());
                para[3] = new SqlParameter("@T24", ddlT24.Text.Trim());
                para[4] = new SqlParameter("@T25", ddlT25.Text.Trim());
                para[5] = new SqlParameter("@T26", ddlT26.Text.Trim());

                para[6] = new SqlParameter("@T27", ddlT27A.Text.Trim());
                para[7] = new SqlParameter("@T27A", ddlT27A.Text.Trim());
                para[8] = new SqlParameter("@T27B", ddlT27B.Text.Trim());
                para[9] = new SqlParameter("@T27C", ddlT27C.Text.Trim());
                para[10] = new SqlParameter("@T27D", ddlT27D.Text.Trim());
                para[11] = new SqlParameter("@T27E", ddlT27E.Text.Trim());
                para[12] = new SqlParameter("@T27F", ddlT27F.Text.Trim());
                para[13] = new SqlParameter("@T27G", ddlT27G.Text.Trim());
                para[14] = new SqlParameter("@T27H", ddlT27H.Text.Trim());
                para[15] = new SqlParameter("@T27I", ddlT27I.Text.Trim());
                para[16] = new SqlParameter("@T27J", ddlT27J.Text.Trim());

                para[17] = new SqlParameter("@T27K", ddlT27K.Text.Trim());
                para[18] = new SqlParameter("@T27L", ddlT27L.Text.Trim());
                para[19] = new SqlParameter("@T27M", ddlT27M.Text.Trim());
                para[20] = new SqlParameter("@T27N", ddlT27N.Text.Trim());
                para[21] = new SqlParameter("@T27O", ddlT27O.Text.Trim());
                para[22] = new SqlParameter("@T27P", ddlT27P.Text.Trim());
                para[23] = new SqlParameter("@T27Q", ddlT27Q.Text.Trim());
                para[24] = new SqlParameter("@T27R", ddlT27R.Text.Trim());

                para[25] = new SqlParameter("@T28", ddlT28.Text.Trim());
                para[26] = new SqlParameter("@T29", ddlT29.Text.Trim());
                para[27] = new SqlParameter("@T30", ddlT30.Text.Trim());
                para[28] = new SqlParameter("@T31", ddlT31.Text.Trim());
                para[29] = new SqlParameter("@T32", ddlT32.Text.Trim());
                para[30] = new SqlParameter("@T33", ddlT33.Text.Trim());

                para[31] = new SqlParameter("@T34A", ddlT34A.Text.Trim());
                para[32] = new SqlParameter("@T34B", ddlT34B.Text.Trim());
                para[33] = new SqlParameter("@T35", ddlT35.Text.Trim());
                para[34] = new SqlParameter("@T36", ddlT36.Text.Trim());

                para[35] = new SqlParameter("@T37", ddlT37.Text.Trim());
                para[36] = new SqlParameter("@T38", ddlT38.Text.Trim());
                para[37] = new SqlParameter("@T39", ddlT39A.Text.Trim());
                para[38] = new SqlParameter("@T39A", ddlT39A.Text.Trim());
                para[39] = new SqlParameter("@T39B", ddlT39B.Text.Trim());
                para[40] = new SqlParameter("@T39C", ddlT39C.Text.Trim());
                para[41] = new SqlParameter("@T39D", ddlT39D.Text.Trim());
                para[42] = new SqlParameter("@T40", ddlT40.Text.Trim());
                          


                dal.executeprocedure("SP_RiskSurvey13", para);
                Response.Redirect("RiskAssessmentSurvey14.aspx");
                //Server.Transfer("RiskAssessmentSurvey14.aspx");
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
