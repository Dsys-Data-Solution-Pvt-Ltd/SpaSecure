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
    public partial class RiskAssessmentSurvey12 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[53];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@R6", ddlR6.Text.Trim());
                para[3] = new SqlParameter("@R7", ddlR7.Text.Trim());
                para[4] = new SqlParameter("@R8", ddlR8.Text.Trim());
                para[5] = new SqlParameter("@R9", ddlR9.Text.Trim());
                para[6] = new SqlParameter("@R10", ddlR10.Text.Trim());
                para[7] = new SqlParameter("@R11", ddlR11.Text.Trim());
                para[8] = new SqlParameter("@R12", ddlR12.Text.Trim());
                para[9] = new SqlParameter("@R13", ddlR13.Text.Trim());
                para[10] = new SqlParameter("@R14", ddlR14.Text.Trim());

                para[11] = new SqlParameter("@S1", ddlS1.Text.Trim());
                para[12] = new SqlParameter("@S2", ddlS2.Text.Trim());
                para[13] = new SqlParameter("@S3", ddlS3.Text.Trim());
                para[14] = new SqlParameter("@S3Comment", txtS3.Text.Trim());

                para[15] = new SqlParameter("@T1", ddlT1.Text.Trim());
                para[16] = new SqlParameter("@T1txt", txtT1.Text.Trim());
                para[17] = new SqlParameter("@T2", ddlT2.Text.Trim());
                para[18] = new SqlParameter("@T2txt", txtT2.Text.Trim());
                para[19] = new SqlParameter("@T3", ddlT3.Text.Trim());
                para[20] = new SqlParameter("@T3txt", txtT3.Text.Trim());
                para[21] = new SqlParameter("@T4", ddlT4.Text.Trim());
                para[22] = new SqlParameter("@T4txt", txtT4.Text.Trim());
                para[23] = new SqlParameter("@T5", ddlT5.Text.Trim());
                para[24] = new SqlParameter("@T5txt", txtT5.Text.Trim());
                para[25] = new SqlParameter("@T6", ddlT6.Text.Trim());
                para[26] = new SqlParameter("@T6txt", txtT6.Text.Trim());
                para[27] = new SqlParameter("@T7", ddlT7.Text.Trim());
                para[28] = new SqlParameter("@T7txt", txtT7.Text.Trim());
                para[29] = new SqlParameter("@T8", ddlT8.Text.Trim());
                para[30] = new SqlParameter("@T8txt", txtT8.Text.Trim());

                para[31] = new SqlParameter("@T9", ddlT9.Text.Trim());
                para[32] = new SqlParameter("@T10", ddlT10.Text.Trim());
                para[33] = new SqlParameter("@T11", ddlT11.Text.Trim());
                para[34] = new SqlParameter("@T12", ddlT12.Text.Trim());

                para[35] = new SqlParameter("@T13", ddlT13.Text.Trim());
                para[36] = new SqlParameter("@T13Name1", txtT13Name1.Text.Trim());
                para[37] = new SqlParameter("@T13Auth1", txtT13Aut1.Text.Trim());
                para[38] = new SqlParameter("@T13Name2", txtT13Name2.Text.Trim());
                para[40] = new SqlParameter("@T13Auth2", txtT13Aut2.Text.Trim());
                para[41] = new SqlParameter("@T13Name3", txtT13Name3.Text.Trim());
                para[42] = new SqlParameter("@T13Auth3", txtT13Aut3.Text.Trim());
                para[43] = new SqlParameter("@T13Name4", txtT13Name4.Text.Trim());
                para[44] = new SqlParameter("@T13Auth4", txtT13Aut4.Text.Trim());

                para[45] = new SqlParameter("@T14", ddlT14.Text.Trim());
                para[46] = new SqlParameter("@T15", ddlT15.Text.Trim());
                para[47] = new SqlParameter("@T16", ddlT16.Text.Trim());
                para[48] = new SqlParameter("@T17", ddlT17.Text.Trim());
                para[49] = new SqlParameter("@T18", ddlT18.Text.Trim());
                para[50] = new SqlParameter("@T19", ddlT19.Text.Trim());

                para[51] = new SqlParameter("@T20", ddlT20.Text.Trim());
                para[52] = new SqlParameter("@T21", ddlT21.Text.Trim());
                para[39] = new SqlParameter("@T22", ddlT22.Text.Trim());


                dal.executeprocedure("SP_RiskSurvey12", para);
                Response.Redirect("RiskAssessmentSurvey13.aspx");


                //Server.Transfer("RiskAssessmentSurvey13.aspx");
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
