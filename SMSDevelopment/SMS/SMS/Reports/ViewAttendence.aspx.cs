using System;
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


namespace SMS.SMSUsers.Reports
{
    public partial class ViewAttendence : System.Web.UI.Page
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
                DataSet dsget = dal.getdataset("Select checkin_time,checkout_time,Locationid,pass_no,key_no,user_id,user_name From checkout_manager Where checkout_id='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtChkIn.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtChkOut.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    //txtlocation.Text = GetLocationNameById(dsget.Tables[0].Rows[0][2].ToString().Trim());
                    //txtPassNo.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    //txtKeyNo.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtNRIC.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtName.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();                   
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private String GetLocationNameById(string id)
        {
            string name = string.Empty;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocationid = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                name = dsLocationid.Rows[0][0].ToString().Trim();
                return name;
            }
            return name;
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
