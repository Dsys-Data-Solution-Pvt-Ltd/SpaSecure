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
    public partial class ViewEvent : System.Web.UI.Page
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
                DataSet dsget = dal.getdataset("Select Date_From,Date_to,Location_id,Event_Type,Start_time,End_time,Special_Requirment,Guard_Requirment,Special_Duty,Incharg_Name,Incharg_NricNo,Incharg_position,Incharg_ContactNo,Superior_Name From event Where Event_ID='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                   txtFromDate.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                   txtTodate.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                   txtlocation.Text = GetLocationNameById(dsget.Tables[0].Rows[0][2].ToString().Trim());
                   txtEventType.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                   txtStartTime.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                   txtEndTime.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                   txtSpecialReg.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                   txtNoOfGuard.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();
                   txtSpecialDuty.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();

                   txtPersonName.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                   txtPersonNRIC.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();
                   txtPersonContNo.Text = dsget.Tables[0].Rows[0][11].ToString().Trim();
                   txtPersonPosition.Text = dsget.Tables[0].Rows[0][12].ToString().Trim();

                   txtSuperior.Text = dsget.Tables[0].Rows[0][13].ToString().Trim();
                   

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
