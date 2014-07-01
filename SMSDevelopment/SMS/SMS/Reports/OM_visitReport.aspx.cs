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


namespace SMS.SMSUsers.Reports
{
    public partial class OM_visitReport1 : System.Web.UI.Page
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
                    dr.Close();
                    cn.Close();
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
                DataSet dsget = dal.getdataset("Select checkin_time,checkout_time,NRICno,user_name,user_address,telephone,pass_no,PassType,key_no,vehicle_no,company_from,location.Location_name as LocationID,remarks  From checkout_manager,location  Where checkout_id='" + argsBGID + "'"+" and location.Location_id=checkout_manager.LocationID");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtInTime.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtOutTime.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtNRIC.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtname.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txtAddress.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtPhone.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    //txtPass.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();

                    //txtPassType.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();
                    //txtKeyNo.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();
                    //txtVehicle.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                    txtCompanyFrom.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();
                    txtToVisit.Text = dsget.Tables[0].Rows[0][11].ToString().Trim();
                    txtRemark.Text = dsget.Tables[0].Rows[0][12].ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, System.EventArgs e)
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