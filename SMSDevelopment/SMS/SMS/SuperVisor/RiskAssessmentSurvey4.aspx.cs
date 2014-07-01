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
    public partial class RiskAssessmentSurvey4 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[42];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@G13",G13.Text.Trim());
                para[3] = new SqlParameter("@G14", G14.Text.Trim());
              //  para[4] = new SqlParameter("@G14", D3.Text.Trim());
                para[5] = new SqlParameter("@G15", G15.Text.Trim());
                para[6] = new SqlParameter("@G16", G16.Text.Trim());
                para[7] = new SqlParameter("@G17", G17.Text.Trim());
                para[8] = new SqlParameter("@G18", G18.Text.Trim());
                para[9] = new SqlParameter("@G19", G19.Text.Trim());
                para[10] = new SqlParameter("@G20", G20.Text.Trim());
                para[11] = new SqlParameter("@G21", G21.Text.Trim());
                para[12] = new SqlParameter("@G22", G22.Text.Trim());

                para[13] = new SqlParameter("@H1", H1.Text.Trim());
                para[14] = new SqlParameter("@H2", H2.Text.Trim());
                para[15] = new SqlParameter("@H3", H3.Text.Trim());
                para[16] = new SqlParameter("@H4", H4.Text.Trim());
                para[17] = new SqlParameter("@H5", H5.Text.Trim());
                para[18] = new SqlParameter("@H6", H6.Text.Trim());
                para[19] = new SqlParameter("@H7", H7.Text.Trim());
                para[20] = new SqlParameter("@H8", H8.Text.Trim());
                para[21] = new SqlParameter("@H9", H9.Text.Trim());
                para[22] = new SqlParameter("@H10", H10.Text.Trim());
                para[23] = new SqlParameter("@H11", H11.Text.Trim());
                para[24] = new SqlParameter("@H12", H12.Text.Trim());
                para[25] = new SqlParameter("@H13", H13.Text.Trim());
                para[26] = new SqlParameter("@H14", H14.Text.Trim());
                para[27] = new SqlParameter("@H15", H15.Text.Trim());

                para[28] = new SqlParameter("@I1", I1.Text.Trim());
                para[29] = new SqlParameter("@I2", I2.Text.Trim());
                para[30] = new SqlParameter("@I3", I3.Text.Trim());
                para[31] = new SqlParameter("@I4", I4.Text.Trim());
                para[32] = new SqlParameter("@I5", I5.Text.Trim());
                para[33] = new SqlParameter("@I6", I6.Text.Trim());
                para[34] = new SqlParameter("@I7", I7.Text.Trim());
                para[35] = new SqlParameter("@I8", I8.Text.Trim());
                para[36] = new SqlParameter("@I9", I9.Text.Trim());
                para[37] = new SqlParameter("@I10", I10.Text.Trim());

                para[38] = new SqlParameter("@I11", I11.Text.Trim());
                para[39] = new SqlParameter("@I12", I12.Text.Trim());
                para[40] = new SqlParameter("@I13", I13.Text.Trim());
                para[41] = new SqlParameter("@I14", I14.Text.Trim());
                para[4] = new SqlParameter("@I15", I15.Text.Trim());


                dal.executeprocedure("SP_RiskSurvey4", para);

                Response.Redirect("RiskAssessmentSurvey5.aspx");
                //Server.Transfer("RiskAssessmentSurvey5.aspx");
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
