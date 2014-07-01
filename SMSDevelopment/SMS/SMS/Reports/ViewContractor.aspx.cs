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

namespace SMS.SMSUsers.Reports
{
    public partial class ViewContractor : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------image display---------------------------
            DBConnectionHandler1 bd = new DBConnectionHandler1();
            SqlConnection cn = bd.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetString(0) != "")
                {
                    image1.ImageUrl = dr.GetString(0);
                    cn.Close();
                    dr.Close();
                }
            }
            //---------------------------=---------------------------
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
                DataSet dsget = dal.getdataset("Select Checkin_DateTime,NRICno,user_name,user_address,telephone,pass_no,pass_type,key_no,vehicle_no,company_from,to_visit,remarks From checkin_manager  Where checkin_id='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtInTime.Text = dsget.Tables[0].Rows[0]["Checkin_DateTime"].ToString().Trim();

                    txtNRIC.Text = dsget.Tables[0].Rows[0]["NRICno"].ToString().Trim();
                    txtname.Text = dsget.Tables[0].Rows[0]["user_name"].ToString().Trim();
                    txtAddress.Text = dsget.Tables[0].Rows[0]["user_address"].ToString().Trim();
                    txtPhone.Text = dsget.Tables[0].Rows[0]["telephone"].ToString().Trim();
                    txtPass.Text = dsget.Tables[0].Rows[0]["pass_no"].ToString().Trim();

                    txtPassType.Text = dsget.Tables[0].Rows[0]["Pass_Type"].ToString().Trim();
                    txtKeyNo.Text = dsget.Tables[0].Rows[0]["key_no"].ToString().Trim();
                    txtVehicle.Text = dsget.Tables[0].Rows[0]["vehicle_no"].ToString().Trim();
                    txtCompanyFrom.Text = dsget.Tables[0].Rows[0]["company_from"].ToString().Trim();
                    txtToVisit.Text = dsget.Tables[0].Rows[0]["to_visit"].ToString().Trim();
                    txtRemark.Text = dsget.Tables[0].Rows[0]["remarks"].ToString().Trim();

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
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

    }
}
