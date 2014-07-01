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
    public partial class RiskAssessmentSurvey9 : System.Web.UI.Page
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

                para[2] = new SqlParameter("@O24", ddlO24.Text.Trim());
                para[3] = new SqlParameter("@O25", ddlO25.Text.Trim());
                para[4] = new SqlParameter("@O25How", txtO25.Text.Trim());
                para[5] = new SqlParameter("@O26", txtO26.Text.Trim());
                para[6] = new SqlParameter("@O27", txtO27.Text.Trim());
                para[7] = new SqlParameter("@O28", ddlO28.Text.Trim());

                para[8] = new SqlParameter("@O29", ddlO29.Text.Trim());
                para[9] = new SqlParameter("@O30", ddlO30.Text.Trim());
                para[10] = new SqlParameter("@O31", ddlO31.Text.Trim());
                para[11] = new SqlParameter("@O32", ddlO32.Text.Trim());
                para[12] = new SqlParameter("@O33", txtO33.Text.Trim());
                para[13] = new SqlParameter("@O34", ddlO34.Text.Trim());
                para[14] = new SqlParameter("@O35", ddlO35.Text.Trim());

                para[15] = new SqlParameter("@O36", ddlO36.Text.Trim());
                para[16] = new SqlParameter("@O37", ddlO37.Text.Trim());
                para[17] = new SqlParameter("@O38", ddlO38.Text.Trim());
                para[18] = new SqlParameter("@O39", ddlO39.Text.Trim());
                para[19] = new SqlParameter("@O40", ddlO40.Text.Trim());
                para[20] = new SqlParameter("@O40What", txtO40.Text.Trim());
                para[21] = new SqlParameter("@O41", ddlO41.Text.Trim());
                para[22] = new SqlParameter("@O42", ddlO42.Text.Trim());
                para[23] = new SqlParameter("@O43", ddlO43.Text.Trim());
                para[24] = new SqlParameter("@O44", ddlO44.Text.Trim());
                para[25] = new SqlParameter("@O45", ddlO45.Text.Trim());

                para[26] = new SqlParameter("@P1", ddlP1.Text.Trim());
                para[27] = new SqlParameter("@P2", ddlP2.Text.Trim());

                para[28] = new SqlParameter("@P3", ddlP3.Text.Trim());
                para[29] = new SqlParameter("@P4", ddlP4.Text.Trim());
                para[30] = new SqlParameter("@P4Why", txtP4.Text.Trim());
                para[31] = new SqlParameter("@P5", ddlP5.Text.Trim());
                para[32] = new SqlParameter("@P6", ddlP6.Text.Trim());
                para[33] = new SqlParameter("@P7", ddlP7.Text.Trim());
                para[34] = new SqlParameter("@P8", ddlP8.Text.Trim());
                para[35] = new SqlParameter("@P9", ddlP9.Text.Trim());
                para[36] = new SqlParameter("@P10", ddlP10.Text.Trim());
                para[37] = new SqlParameter("@P10People", txtP10.Text.Trim());

                para[38] = new SqlParameter("@P11", ddlP11.Text.Trim());
                para[39] = new SqlParameter("@P12", ddlP12.Text.Trim());
                para[40] = new SqlParameter("@P13", ddlP13.Text.Trim());

                dal.executeprocedure("SP_RiskSurvey9", para);

                Response.Redirect("RiskAssessmentSurvey10.aspx");
                //Server.Transfer("RiskAssessmentSurvey10.aspx");
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
