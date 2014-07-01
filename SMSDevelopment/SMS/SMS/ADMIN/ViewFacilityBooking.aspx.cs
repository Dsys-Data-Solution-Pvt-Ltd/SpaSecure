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

namespace SMS.ADMIN
{
    public partial class ViewFacilityBooking : System.Web.UI.Page
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
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Fbook", argsBGID);
                DataTable dtfacility = dal.executeprocedure("SP_GetFacilitydata", para, false);
                if (dtfacility.Rows.Count > 0)
                {
                   txttypeoffacility.Text = dtfacility.Rows[0]["FacilityType"].ToString().Trim();
                   txtname.Text = dtfacility.Rows[0]["Name"].ToString().Trim();
                   txtposition.Text = dtfacility.Rows[0]["Position"].ToString().Trim();
                   txtunitno.Text = dtfacility.Rows[0]["UnitNumber"].ToString().Trim();
                   txtfromdate.Text = dtfacility.Rows[0]["bookingdateFrom"].ToString().Trim();
                   txttodate.Text = dtfacility.Rows[0]["bookingdateTo"].ToString().Trim();
                   txtfromtime.Text = dtfacility.Rows[0]["bookingtimeFrom"].ToString().Trim();

                   txttotime.Text = dtfacility.Rows[0]["bookingtimeTo"].ToString().Trim();
                   txtcomments.Text = dtfacility.Rows[0]["Comment"].ToString().Trim();
                   string locid = dtfacility.Rows[0]["Location_id"].ToString().Trim();

                   SqlParameter[] para2 = new SqlParameter[1];
                   para2[0] = new SqlParameter("@Location_id", locid);
                   DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para2, false);
                   txtlocation.Text = dsLocationName.Rows[0]["Location_name"].ToString();
           
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
