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
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class UpdateSOBriefing : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String iBTID = string.Empty;
                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        ((master.login)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);

                        //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }

                    PopulatePageCntrls(iBTID);

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

            DataSet dspan = dal.getdataset("Select TypeofBriefing,DateofBrief,Location,Attendees,BreifDetail,Conducted_By,BreiActionDate,Comments,ReportedTo,Position  from tblSOBriefing where SOBrief_id = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {
                txtID.Text = argsBGID;
                txttypeofBriefing.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtdatefrom.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtlocation.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtAttendees.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

                txtDetail.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                txtConductedBy.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();
                txtActionDate.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtActionComment.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();

                txtReportedName.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();
                txtposition.Text = dspan.Tables[0].Rows[0][9].ToString().Trim();

            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Update tblSOBriefing Set TypeofBriefing ='" + txttypeofBriefing.Text.Trim() + "',DateofBrief='" + txtdatefrom.Text.Trim() + "',Location='" + txtlocation.Text.Trim() + "',Attendees='" + txtAttendees.Text.Trim() + "',BreifDetail='" + txtDetail.Text.Trim() + "',Conducted_By='" + txtConductedBy.Text.Trim() + "',BreiActionDate='" + txtActionDate.Text.Trim() + "',Comments='" + txtActionComment.Text.Trim() + "' ,ReportedTo='" + txtReportedName.Text.Trim() + "',Position='" + txtposition.Text.Trim() + "' where SOBrief_id = '" + txtID.Text.Trim() + "' ");
                Server.Transfer("AdminSecurityOfficerBriefing.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Server.Transfer("AdminSecurityOfficerBriefing.aspx");
        }




    }
}
