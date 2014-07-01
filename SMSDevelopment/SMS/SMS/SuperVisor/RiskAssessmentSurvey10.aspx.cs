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
    public partial class RiskAssessmentSurvey10 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[27];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@P14", ddlP14.Text.Trim());
                para[3] = new SqlParameter("@P15", ddlP15.Text.Trim());
                para[4] = new SqlParameter("@P16", ddlP16.Text.Trim());
                para[5] = new SqlParameter("@P17", ddlP17.Text.Trim());
                para[6] = new SqlParameter("@P18", ddlP18.Text.Trim());
                para[7] = new SqlParameter("@P19", ddlP19.Text.Trim());

                para[8] = new SqlParameter("@P20", ddlP20.Text.Trim());
                para[9] = new SqlParameter("@P21", ddlP21.Text.Trim());
                para[10] = new SqlParameter("@P22", ddlP22.Text.Trim());
                para[11] = new SqlParameter("@P23", ddlP23.Text.Trim());
                para[12] = new SqlParameter("@P24", ddlP24.Text.Trim());
                para[13] = new SqlParameter("@P25", ddlP25.Text.Trim());
                para[14] = new SqlParameter("@P26", ddlP26.Text.Trim());
                para[15] = new SqlParameter("@P27", ddlP27.Text.Trim());
                para[16] = new SqlParameter("@P28", ddlP28.Text.Trim());
                para[17] = new SqlParameter("@P29", ddlP29.Text.Trim());
                para[18] = new SqlParameter("@P30", ddlP30.Text.Trim());

                para[19] = new SqlParameter("@Q1", ddlQ1.Text.Trim());
                para[20] = new SqlParameter("@Q2", ddlQ2.Text.Trim());
                para[21] = new SqlParameter("@Q3", ddlQ3.Text.Trim());
                para[22] = new SqlParameter("@Q4", ddlQ4.Text.Trim());
                para[23] = new SqlParameter("@Q5", ddlQ5.Text.Trim());
                para[24] = new SqlParameter("@Q6", ddlQ6.Text.Trim());
                para[25] = new SqlParameter("@Q7", ddlQ7.Text.Trim());
                para[26] = new SqlParameter("@Q8", ddlQ8.Text.Trim());               

                dal.executeprocedure("SP_RiskSurvey10", para);
                Response.Redirect("RiskAssessmentSurvey11.aspx");
                //Server.Transfer("RiskAssessmentSurvey11.aspx");
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
