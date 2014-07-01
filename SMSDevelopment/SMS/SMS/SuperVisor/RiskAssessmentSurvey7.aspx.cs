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
    public partial class RiskAssessmentSurvey7 : System.Web.UI.Page
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

                SqlParameter[] para = new SqlParameter[57];
                para[0] = new SqlParameter("@Risk_id", lblid.Text.Trim());
                para[1] = new SqlParameter("@DateFrom", DateTime.Now);

                para[2] = new SqlParameter("@M1", ddlSectionMFacility.Text.Trim());
                para[3] = new SqlParameter("@M1Type", txtSectionMType.Text.Trim());
                para[4] = new SqlParameter("@M1Manufacture", txtSectionMManufacturer.Text.Trim());

                para[5] = new SqlParameter("@M2DoorContact", (ChkDoorContact.Checked == true ? ChkDoorContact.Text.Trim() : " "));
                para[6] = new SqlParameter("@M2WindowContact", (ChkWindowContact.Checked == true ? ChkWindowContact.Text.Trim() : " "));
                para[7] = new SqlParameter("@M2GlassBreak", (ChkGlassbreak.Checked == true ? ChkGlassbreak.Text.Trim() : " "));
                para[8] = new SqlParameter("@M2Motion", (ChkMotionSensors.Checked == true ? ChkMotionSensors.Text.Trim() : " "));

                para[9] = new SqlParameter("@M3Proprietary", (ChkProprietary.Checked == true ? ChkProprietary.Text.Trim() : " "));
                para[10] = new SqlParameter("@M3CentralStation", (ChkCentralStation.Checked == true ? ChkCentralStation.Text.Trim() : " "));
                para[11] = new SqlParameter("@M3Police", (ChkPolice.Checked == true ? ChkPolice.Text.Trim() : " "));
                para[12] = new SqlParameter("@M3Other", M3Other.Text.Trim());

                para[13] = new SqlParameter("@M4", M4.Text.Trim());
                para[14] = new SqlParameter("@M5", M5.Text.Trim());

                para[15] = new SqlParameter("@M6", M6.Text.Trim());
                para[16] = new SqlParameter("@M7", M7.Text.Trim());
                para[17] = new SqlParameter("@M8", M8.Text.Trim());
                para[18] = new SqlParameter("@M9", M9.Text.Trim());
                para[19] = new SqlParameter("@M10", M10.Text.Trim());
                para[20] = new SqlParameter("@M10List", txtSectionMPleaseList.Text.Trim());
                para[21] = new SqlParameter("@M11", M11.Text.Trim());
                para[22] = new SqlParameter("@M12", txtSectionMmonitoredContinuously.Text.Trim());
                para[23] = new SqlParameter("@M13", M13.Text.Trim());
                para[24] = new SqlParameter("@M14", M14.Text.Trim());
                para[25] = new SqlParameter("@M15", M15.Text.Trim());
                para[26] = new SqlParameter("@M16", M16.Text.Trim());

                para[27] = new SqlParameter("@M17VHS", (ChkVHSTape.Checked == true ? ChkVHSTape.Text.Trim() : " "));
                para[28] = new SqlParameter("@M17DVR", (ChkDVR.Checked == true ? ChkDVR.Text.Trim() : " "));
                para[29] = new SqlParameter("@M17HardDisc", (ChkHardDisc.Checked == true ? ChkHardDisc.Text.Trim() : " "));
                para[30] = new SqlParameter("@M17Other", (ChkOtherHarddisc.Checked == true ? txtSectionMOtherHarddisc.Text.Trim() : " "));

                para[31] = new SqlParameter("@M18", ddlSectionMCameraType.Text.Trim());

                para[32] = new SqlParameter("@M19BW", (ChBW.Checked == true ? ChBW.Text.Trim() : " "));
                para[33] = new SqlParameter("@M19Color", (Chkcolor.Checked == true ? Chkcolor.Text.Trim() : " "));
                para[34] = new SqlParameter("@M19Infrared", (ChkInfrared.Checked == true ? ChkInfrared.Text.Trim() : " "));
                para[35] = new SqlParameter("@M19PTZ", (ChkPTZ.Checked == true ? ChkPTZ.Text.Trim() : " "));
                para[36] = new SqlParameter("@M19Wirless", (ChkWirlessRF.Checked == true ? ChkWirlessRF.Text.Trim() : " "));
                para[37] = new SqlParameter("@M19IP", (ChkIP.Checked == true ? ChkIP.Text.Trim() : " "));

                para[38] = new SqlParameter("@M20", M20.Text.Trim());
                para[39] = new SqlParameter("@M21", M21.Text.Trim());
                para[40] = new SqlParameter("@M22", M22.Text.Trim());
                para[41] = new SqlParameter("@M23", M23.Text.Trim());
                para[42] = new SqlParameter("@M24", M24.Text.Trim());
                para[43] = new SqlParameter("@M25", M25.Text.Trim());
                para[44] = new SqlParameter("@M26", M26.Text.Trim());
                para[45] = new SqlParameter("@M27", M27.Text.Trim());
                para[46] = new SqlParameter("@M28", M28.Text.Trim());
                para[47] = new SqlParameter("@M29", M29.Text.Trim());
                para[48] = new SqlParameter("@M30", M30.Text.Trim());
                para[49] = new SqlParameter("@M31", M31.Text.Trim());
                para[50] = new SqlParameter("@M32", M32.Text.Trim());

                para[51] = new SqlParameter("@N1", N1.Text.Trim());
                para[52] = new SqlParameter("@N2", N2.Text.Trim());
                para[53] = new SqlParameter("@N2Why",txtN2.Text.Trim());
                para[54] = new SqlParameter("@N3", N3.Text.Trim());
                para[55] = new SqlParameter("@N4", N4.Text.Trim());
                para[56] = new SqlParameter("@N5", N5.Text.Trim());


                dal.executeprocedure("SP_RiskSurvey7", para);
                Response.Redirect("RiskAssessmentSurvey8.aspx");
                //Server.Transfer("RiskAssessmentSurvey8.aspx");
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
