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
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;

namespace SMS.SuperVisor
{
    public partial class AlertViewVehicle : System.Web.UI.Page
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

                if (Request.QueryString["id"] != null)
                {
                    String id = Request.QueryString["id"].ToString();
                    PopulatePageCntrls(id);
                }

                //if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                //{
                //    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                //    // ((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                //}
                //if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                //{
                //    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                //}

                //PopulatePageCntrls(iBTID);
            }
        }

         private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetAlertDataResponse ret = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetAlertData objGetBillingTableRequest = new GetAlertData();

                objGetBillingTableRequest.Alert_ID = argsBGID.ToString();
                objGetBillingTableRequest.WhereClause = " where Alert_ID='" + argsBGID.ToString() + "'";

                ret = objAdminBLL.GetAlertData(objGetBillingTableRequest);
                
                txtlocation.Text = getlocnamebyid(ret.Alert_ID[iCount].Location_id.ToString());

                txtVehicleType.Text = ret.Alert_ID[iCount].V_Type.ToString();

                txtVehicleRegNo.Text = ret.Alert_ID[iCount].V_ResgistNo.ToString();
                txtVehicleReason.Text = ret.Alert_ID[iCount].Alert_Type.ToString();
                txtVehicleownerNric.Text = ret.Alert_ID[iCount].V_OwnerNricNo.ToString();
                txtVehicleownerName.Text = ret.Alert_ID[iCount].V_OwnerName.ToString();

               // txtReason.Text = ret.Alert_ID[iCount].Alert_Type.ToString();
                txtRaisedName.Text = ret.Alert_ID[iCount].AlertBy_Name.ToString();
                txtRaisedNric.Text = ret.Alert_ID[iCount].AlertBy_NRICNo.ToString();
                txtPhone.Text = ret.Alert_ID[iCount].AlertContNo.ToString();
               // txtNationality.Text = ret.Alert_ID[iCount].P_Nationality.ToString();
                txtdesignation.Text = ret.Alert_ID[iCount].AlertDesignation.ToString();
                txtcomment.Text = ret.Alert_ID[iCount].Comment.ToString();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }


         private string getlocnamebyid(string id)
        {
            string L = string.Empty;
            DataSet dsLname = dal.getdataset("select Location_name from location where Location_id ='" + id + "'");
            if (dsLname.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsLname.Tables[0].Rows.Count; k++)
                {
                    L = dsLname.Tables[0].Rows[k][0].ToString();
                    return L;
                }
            }
            return L;
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
