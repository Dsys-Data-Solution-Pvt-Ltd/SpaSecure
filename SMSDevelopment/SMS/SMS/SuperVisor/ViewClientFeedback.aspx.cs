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

using Microsoft.SqlServer.Management;
using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System;

namespace SMS.SuperVisor
{
    public partial class ViewClientFeedback : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;

            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }
        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                txtlocation.Text =  dsLocationName.Rows[0][0].ToString().Trim();
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select OM_Available,OM_ReturnPhone,OM_MeetConcrete,OM_Identifies,OM_Respond,OM_Anticipate,SP_Attendence,SP_Consistent,SP_Provides,SP_Quickly,SP_Tactful,SP_UsesSecurity,SP_Acts,SP_Solicits,TM_Charges,TM_Works,TM_Appreciates,TM_Respond,TM_Bills,TM_Available,TM_ReturnPhone,TM_MeetConcrete,TM_Identifies,TM_RespondWithSense,TM_Anticiates,TM_Makes,TM_Constructive,TM_Listen,TM_Demonstrate,TM_Willing,TM_AddValue,TM_KeepMe,TM_PerticularCompliment,ClientName,Location_id,Position,CompanyName from ClientFeedback where CF_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {

                txtOMAvailable.Text = dspan.Tables[0].Rows[0]["OM_Available"].ToString().Trim();
                txtOMReturnPhone.Text = dspan.Tables[0].Rows[0]["OM_ReturnPhone"].ToString().Trim();
                txtOMMeetConcrete.Text = dspan.Tables[0].Rows[0]["OM_MeetConcrete"].ToString().Trim();
                txtOMIdentifies.Text = dspan.Tables[0].Rows[0]["OM_Identifies"].ToString().Trim();
                txtOMResponds.Text = dspan.Tables[0].Rows[0]["OM_Respond"].ToString().Trim();
                txtAnticipates.Text = dspan.Tables[0].Rows[0]["OM_Anticipate"].ToString().Trim();

                txtSMAttendence.Text = dspan.Tables[0].Rows[0]["SP_Attendence"].ToString().Trim();
                txtSMConsistent.Text = dspan.Tables[0].Rows[0]["SP_Consistent"].ToString().Trim();
                txtSMProvides.Text = dspan.Tables[0].Rows[0]["SP_Provides"].ToString().Trim();
                txtSMQuickly.Text = dspan.Tables[0].Rows[0]["SP_Quickly"].ToString().Trim();

                txtSMTactful.Text = dspan.Tables[0].Rows[0]["SP_Tactful"].ToString().Trim();
                txtSMUses.Text = dspan.Tables[0].Rows[0]["SP_UsesSecurity"].ToString().Trim();
                txtSMActs.Text = dspan.Tables[0].Rows[0]["SP_Acts"].ToString().Trim();
                txtSMSolicits.Text = dspan.Tables[0].Rows[0]["SP_Solicits"].ToString().Trim();
                txtTMCharge.Text = dspan.Tables[0].Rows[0]["TM_Charges"].ToString().Trim();
                txtTMWorks.Text = dspan.Tables[0].Rows[0]["TM_Works"].ToString().Trim();

                txtTMAppreciate.Text = dspan.Tables[0].Rows[0]["TM_Appreciates"].ToString().Trim();
                txtTMRespondstoMyBilling.Text = dspan.Tables[0].Rows[0]["TM_Respond"].ToString().Trim();
                txtTMBills.Text = dspan.Tables[0].Rows[0]["TM_Bills"].ToString().Trim();

                txtTMAvailable.Text = dspan.Tables[0].Rows[0]["TM_Available"].ToString().Trim();
                txtTMReturnPhone.Text = dspan.Tables[0].Rows[0]["TM_ReturnPhone"].ToString().Trim();
                txtTMMeetsConcrete.Text = dspan.Tables[0].Rows[0]["TM_MeetConcrete"].ToString().Trim();
                txtTMIdentifies.Text = dspan.Tables[0].Rows[0]["TM_Identifies"].ToString().Trim();
                txtTMRespondsWithSense.Text = dspan.Tables[0].Rows[0]["TM_RespondWithSense"].ToString().Trim();
                txtTMAnticipate.Text = dspan.Tables[0].Rows[0]["TM_Anticiates"].ToString().Trim();

                txtTMMake.Text = dspan.Tables[0].Rows[0]["TM_Makes"].ToString().Trim();
                txtTMIsConstructive.Text = dspan.Tables[0].Rows[0]["TM_Constructive"].ToString().Trim();
                txtTMListen.Text = dspan.Tables[0].Rows[0]["TM_Listen"].ToString().Trim();
                txtTMDemonstrate.Text = dspan.Tables[0].Rows[0]["TM_Demonstrate"].ToString().Trim();
                txtTMWilling.Text = dspan.Tables[0].Rows[0]["TM_Willing"].ToString().Trim();
                txtTMAdds.Text = dspan.Tables[0].Rows[0]["TM_AddValue"].ToString().Trim();
                txtTMkeeps.Text = dspan.Tables[0].Rows[0]["TM_KeepMe"].ToString().Trim();
                txtParticular.Text = dspan.Tables[0].Rows[0]["TM_PerticularCompliment"].ToString().Trim();

                txtname.Text = dspan.Tables[0].Rows[0]["ClientName"].ToString().Trim();
                getLocationNameById(dspan.Tables[0].Rows[0]["Location_id"].ToString().Trim());

                //int locid = Convert.ToInt32(dspan.Tables[0].Rows[0]["Location_id"].ToString().Trim());

                txtposition.Text = dspan.Tables[0].Rows[0]["Position"].ToString().Trim();
                txtcompany.Text = dspan.Tables[0].Rows[0]["CompanyName"].ToString().Trim();

            }

        }




        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=800px,width=1000px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
