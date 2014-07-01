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
    public partial class RiskAssessmentSurvey8 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[41];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@N6", ddlN6.Text.Trim());
                para[3] = new SqlParameter("@N7", ddlN7.Text.Trim());
                para[4] = new SqlParameter("@N7Why", txtNWhynot.Text.Trim());
                para[5] = new SqlParameter("@N8", ddN8.Text.Trim());
                para[6] = new SqlParameter("@N8Why", txtN8whynot.Text.Trim());
                para[7] = new SqlParameter("@N9", txtN9.Text.Trim());

                para[8] = new SqlParameter("@O1", ddlO1.Text.Trim());
                para[9] = new SqlParameter("@O2", ddlO2.Text.Trim());
                para[10] = new SqlParameter("@O3", ddlO3.Text.Trim());
                para[11] = new SqlParameter("@O4", txtO4.Text.Trim());
                para[12] = new SqlParameter("@O5", ddlO5.Text.Trim());
                para[13] = new SqlParameter("@O5Issued", txtO5Key.Text.Trim());
                para[14] = new SqlParameter("@O5Master", txtO5Master.Text.Trim());

                para[15] = new SqlParameter("@O6", ddlO6.Text.Trim());
                para[16] = new SqlParameter("@O7", ddlO7.Text.Trim());
                para[17] = new SqlParameter("@O7Auth", txtO7.Text.Trim());
                para[18] = new SqlParameter("@O8", ddlO8.Text.Trim());
                para[19] = new SqlParameter("@O9", ddlO9.Text.Trim());
                para[20] = new SqlParameter("@O10", ddlO10.Text.Trim());
                para[21] = new SqlParameter("@O11", ddlO11.Text.Trim());
                para[22] = new SqlParameter("@O12", ddlO12.Text.Trim());
                para[23] = new SqlParameter("@O13", ddlO13.Text.Trim());
                para[24] = new SqlParameter("@O14", ddlO14.Text.Trim());
                para[25] = new SqlParameter("@O15", ddlO15.Text.Trim());
                para[26] = new SqlParameter("@O16", ddlO16.Text.Trim());
                para[27] = new SqlParameter("@O17", ddlO17.Text.Trim());

                para[28] = new SqlParameter("@O19", ddlO19.Text.Trim());
                para[29] = new SqlParameter("@O19Issued", ddlO19Option.Text.Trim());
                para[30] = new SqlParameter("@O20", ddlO20.Text.Trim());
                para[31] = new SqlParameter("@O21a", ddlO21A.Text.Trim());
                para[32] = new SqlParameter("@O21b", ddlO21B.Text.Trim());
                para[33] = new SqlParameter("@O21c", ddlO21C.Text.Trim());
                para[34] = new SqlParameter("@O21d", ddlO21D.Text.Trim());
                para[35] = new SqlParameter("@O21e", ddlO21E.Text.Trim());
                para[36] = new SqlParameter("@O21f", ddlO21F.Text.Trim());
                para[37] = new SqlParameter("@O21g", ddlO21G.Text.Trim());

                para[38] = new SqlParameter("@O22", ddlO22.Text.Trim());
                para[39] = new SqlParameter("@O23", txtO23.Text.Trim());
                para[40] = new SqlParameter("@O18", txtO18.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey8", para);
                Response.Redirect("RiskAssessmentSurvey9.aspx");
                //Server.Transfer("RiskAssessmentSurvey9.aspx");


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
