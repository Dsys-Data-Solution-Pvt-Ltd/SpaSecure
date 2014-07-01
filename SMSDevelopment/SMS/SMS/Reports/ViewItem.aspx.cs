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
    public partial class ViewItem : System.Web.UI.Page
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
                DataSet dsget = dal.getdataset("Select Item_Name,Model_No,Item_Description,Item_quantity,IssuedBy_Nric,IssuedBy_Name,IssuedBy_Position,IssuedTo_Nric,IssuedTo_Name,IssuedTo_Position,Remark,Status From AddNewItem  Where AddItem_ID='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtItemName.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtModelNo.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtItemdescription.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtItemQty.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();

                    txtIssuedByNRIC.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtIssuedByName.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtIssuedByPosition.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();

                    txtIssuedNRIC.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();
                    txtIssuedToName.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();
                    txtIssuedToPosition.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                    txtComments.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();
                    txtStatus.Text = dsget.Tables[0].Rows[0][11].ToString().Trim();
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
