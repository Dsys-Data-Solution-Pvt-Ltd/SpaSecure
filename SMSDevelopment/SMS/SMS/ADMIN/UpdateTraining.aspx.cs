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
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.ADMIN
{
    public partial class UpdateTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = String.Empty;
            lblerr.Visible = false;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
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
                        iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
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
            Int32 iCount = 0;
            GetTrainingResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetTrainingData objGetTrainingData = new GetTrainingData();
                objGetTrainingData.Trainingid = argsBGID.ToString();
                objGetTrainingData.WhereClause = " where training_id='" + argsBGID + "' ";
                ret = objAdminBLL.GetTrainingData(objGetTrainingData);

                hdnBTID.Value = ret.Trainingid[iCount].training_id.ToString();
                hdnBTID.Value = ret.Trainingid[iCount].training_type.ToString();

                txttrainingid.Text = ret.Trainingid[iCount].training_id.ToString();
                txttraingType.Text = ret.Trainingid[iCount].training_type.ToString();
                txtdatefrom.Text = ret.Trainingid[iCount].T_startdate.ToString();
                txtdateto.Text = ret.Trainingid[iCount].T_enddate.ToString();
                txtVenue.Text = ret.Trainingid[iCount].Venue.ToString();
                txtfacilitation.Text = ret.Trainingid[iCount].Facilitation.ToString();
                txtTrainees.Text = ret.Trainingid[iCount].Trainee.ToString();
                txtTraineeDetail.Text = ret.Trainingid[iCount].TraineeDetail.ToString(); 
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }      

        protected void btnClearTraining_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("AdminTraining.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddTraining objTraining = new AddTraining();
                AdminBLL ws = new AdminBLL();

                if (txttraingType.Text.Trim() != "")
                {
                    objTraining.training_id = txttrainingid.Text.Trim();
                    objTraining.training_type = txttraingType.Text.Trim();
                    objTraining.Venue = txtVenue.Text.Trim();

                    objTraining.T_startdate = Convert.ToDateTime(txtdatefrom.Text.Trim());
                    objTraining.T_enddate = Convert.ToDateTime(txtdateto.Text.Trim());

                    objTraining.Facilitation = txtfacilitation.Text.Trim();
                    objTraining.Trainee = txtTrainees.Text.Trim();
                    objTraining.TraineeDetail = txtTraineeDetail.Text.Trim();
                    ws.UpdateTrainingData(objTraining);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    Server.Transfer("CompleteForm.aspx");
                }
                else
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Invalid Site Name ..!";
                    lblerr.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
