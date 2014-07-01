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
//using Microsoft.SqlServer.Management.Trace;
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

namespace SMS.ADMIN
{
    public partial class ViewTraining : System.Web.UI.Page
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
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select * From TrainingMgt Where training_id='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtTrainingTopic.Text = dsget.Tables[0].Rows[0]["training_type"].ToString().Trim();
                    txtStartDate.Text = dsget.Tables[0].Rows[0]["T_startdate"].ToString().Trim();
                    txtEndDate.Text = dsget.Tables[0].Rows[0]["T_enddate"].ToString().Trim();
                    txtVenue.Text = dsget.Tables[0].Rows[0]["Venue"].ToString().Trim();
                    txtTrainee.Text = dsget.Tables[0].Rows[0]["Trainee"].ToString().Trim();
                    txtfacilities.Text = dsget.Tables[0].Rows[0]["Facilitation"].ToString().Trim();
                    txtTraineeDetail.Text = dsget.Tables[0].Rows[0]["TraineeDetail"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintViewPage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}