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

namespace SMS.SuperVisor
{
    public partial class LostAndFoundReport : System.Web.UI.Page
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
                DataSet dsget = dal.getdataset("Select Name,NRICno,ContNo,Date,Time,Description,Action,AckClaimant,AckNRICno,AckTelephone,AckAddress,Location From LostFoundItem where Lost_ID = '" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtpersonName.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtpersonNric.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtpersonTel.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtdate.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txttime.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtpropertyDescription.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtAction.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                    txtAckClaimant.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();

                    txtAckNric.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();
                    txtAckTel.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                    txtAckAddress.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();

                    txtI.Text = txtpersonName.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtNRIC.Text  = dsget.Tables[0].Rows[0][1].ToString().Trim();

                    txtlocation.Text = dsget.Tables[0].Rows[0][11].ToString().Trim();

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
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=730px,width=830px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




    }
}
