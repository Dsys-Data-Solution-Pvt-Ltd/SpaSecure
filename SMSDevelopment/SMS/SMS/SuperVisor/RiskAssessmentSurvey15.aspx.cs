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
    public partial class RiskAssessmentSurvey15 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[20];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@W1", ddlW1.Text.Trim());
                para[3] = new SqlParameter("@W2", ddlW2.Text.Trim());
                para[4] = new SqlParameter("@W3", ddlW3.Text.Trim());
                para[5] = new SqlParameter("@W4", ddlW4.Text.Trim());

                para[6] = new SqlParameter("@W5", ddlW5.Text.Trim());
                para[7] = new SqlParameter("@W6", ddlW6.Text.Trim());
                para[8] = new SqlParameter("@W7", ddlW7.Text.Trim());
                para[9] = new SqlParameter("@W8", ddlW8.Text.Trim());
                para[10] = new SqlParameter("@W9", ddlW9.Text.Trim());
                para[11] = new SqlParameter("@W10", ddlW10.Text.Trim());
                para[12] = new SqlParameter("@W11", ddlW11.Text.Trim());
                para[13] = new SqlParameter("@W12", ddlW12.Text.Trim());
                para[14] = new SqlParameter("@W13", ddlW13.Text.Trim());
                para[15] = new SqlParameter("@W14", ddlW14.Text.Trim());
                para[16] = new SqlParameter("@W15", ddlW15.Text.Trim());

                para[17] = new SqlParameter("@W16", ddlW16.Text.Trim());
                para[18] = new SqlParameter("@W17", ddlW17.Text.Trim());
                para[19] = new SqlParameter("@W17Comment", txtWComments.Text.Trim());
                

                dal.executeprocedure("SP_RiskSurvey15", para);
                Response.Redirect("RiskAssessmentSurvey16.aspx");
                ////Server.Transfer("RiskAssessmentSurvey16.aspx");
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
