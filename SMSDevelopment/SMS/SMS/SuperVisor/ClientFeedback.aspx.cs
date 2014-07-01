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
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using System.Drawing;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace SMS.SuperVisor
{
    public partial class ClientFeedback : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }                   
                    getLocationIDByName(ddllocation.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }
        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtClientName.Text.Trim() != "")
                {
                    getLocationIDByName(ddllocation.Text.Trim());
                    SqlParameter[] para = new SqlParameter[38];
                    para[0] = new SqlParameter("@OM_Available", ddlOMAvailable.Text.Trim());
                    para[1] = new SqlParameter("@OM_ReturnPhone", ddlOMReturnPhone.Text.Trim());
                    para[2] = new SqlParameter("@OM_MeetConcrete", ddlOMMeetConrete.Text.Trim());
                    para[3] = new SqlParameter("@OM_Identifies ", ddlIdentifies.Text.Trim());
                    para[4] = new SqlParameter("@OM_Respond", ddlResponds.Text.Trim());
                    para[5] = new SqlParameter("@OM_Anticipate", ddlAnticipate.Text.Trim());

                    para[6] = new SqlParameter("@SP_Attendence", ddlSMAttendence.Text.Trim());
                    para[7] = new SqlParameter("@SP_Provides", ddlSMProvides.Text.Trim());
                    para[8] = new SqlParameter("@SP_Quickly", ddlSMQuickly.Text.Trim());
                    para[9] = new SqlParameter("@SP_Tactful", ddlSMTactful.Text.Trim());
                    para[10] = new SqlParameter("@SP_UsesSecurity", ddlSMUses.Text.Trim());
                    para[11] = new SqlParameter("@SP_Acts", ddlSMActs.Text.Trim());
                    para[12] = new SqlParameter("@SP_Solicits", ddlSMSolicits.Text.Trim());

                    para[13] = new SqlParameter("@TM_Charges", ddlTMCharge.Text.Trim());
                    para[14] = new SqlParameter("@TM_Works", ddlTMWorks.Text.Trim());
                    para[15] = new SqlParameter("@TM_Appreciates ", ddlTMAppreciate.Text.Trim());
                    para[16] = new SqlParameter("@TM_Respond", ddlTMRespondtoMyBilling.Text.Trim());
                    para[17] = new SqlParameter("@TM_Bills", ddlTMBills.Text.Trim());

                    para[18] = new SqlParameter("@TM_Available", ddlTMAvailable.Text.Trim());
                    para[19] = new SqlParameter("@TM_ReturnPhone", ddlTMReturnPhone.Text.Trim());
                    para[20] = new SqlParameter("@TM_Identifies ", ddlTMIdentifies.Text.Trim());
                    para[21] = new SqlParameter("@TM_RespondWithSense", ddlTMRespondWithSense.Text.Trim());

                    para[22] = new SqlParameter("@TM_Anticiates", ddlTMAnticipate.Text.Trim());
                    para[23] = new SqlParameter("@TM_Makes", ddlTMMake.Text.Trim());

                    para[24] = new SqlParameter("@TM_Constructive", ddlTMIsConstructive.Text.Trim());
                    para[25] = new SqlParameter("@TM_Listen", ddlTMListen.Text.Trim());
                    para[26] = new SqlParameter("@TM_Demonstrate ", ddlTMDemonstrate.Text.Trim());
                    para[27] = new SqlParameter("@TM_Willing", ddlTMWilling.Text.Trim());
                    para[28] = new SqlParameter("@TM_AddValue", ddlTMAdds.Text.Trim());
                    para[29] = new SqlParameter("@TM_KeepMe", ddlTMKeeps.Text.Trim());

                    para[30] = new SqlParameter("@TM_PerticularCompliment", txtTMParticular.Text.Trim());
                    para[31] = new SqlParameter("@DateFrom", DateTime.Now);
                    para[32] = new SqlParameter("@SP_Consistent", ddlSMConsistent.Text.Trim());
                    para[33] = new SqlParameter("@TM_MeetConcrete", ddlTMMeetConcrete.Text.Trim());
                    
                    para[34] = new SqlParameter("@ClientName", txtClientName.Text.Trim());
                    para[35] = new SqlParameter("@Location_id",Convert.ToInt32(searchid.Text));
                    para[36] = new SqlParameter("@Position",txtposition.Text.Trim());
                    para[37] = new SqlParameter("@CompanyName",txtcompany.Text.Trim());

                    dal.executeprocedure("SP_AddClientFeedback", para);
                    Response.Redirect("ClientAck.aspx?name=" + txtClientName.Text);
                    //HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    //Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill The Name.....!";
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}
