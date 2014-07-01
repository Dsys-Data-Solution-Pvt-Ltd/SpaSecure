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

namespace SMS.SMSAdmin
{
    public partial class EventPlanView : System.Web.UI.Page
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
                    //========================//
                    dr.Close();
                    dr.Dispose();
                    //========================//
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
                    // ((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
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
            Int32 iCount = 0;
            GetDataEventResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DateTime dt;
                AdminBLL objAdminBLL = new AdminBLL();
                GetDataEvent objGetBillingTableRequest = new GetDataEvent();
                objGetBillingTableRequest.Event_ID = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Event_ID ='" + argsBGID.ToString() + "'";
                ret = objAdminBLL.GetEventData(objGetBillingTableRequest);

                // hdnBTID.Value = ret.Eventid[iCount].Event_ID.ToString();

                txtEventID.Text = ret.Eventid[iCount].Event_ID.ToString();
                txtEventdate.Text = ret.Eventid[iCount].Date_From.ToString();
                txtEventDateTo.Text = ret.Eventid[iCount].Date_to.ToString();

                txtLocation.Text = getLocationNameById(ret.Eventid[iCount].Location_id.ToString());
                txteventtype.Text = ret.Eventid[iCount].Event_Type.ToString();

                txtpersonNRIC.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();
                txtEnterName.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                txtContactNo.Text = ret.Eventid[iCount].Incharg_ContactNo.ToString();
                txtCreatedBy.Text = ret.Eventid[iCount].Superior_Name.ToString();

                txtdutygaurd.Text = ret.Eventid[iCount].Special_Requirment.ToString();
                txtEnterName.Text = ret.Eventid[iCount].Incharg_Name.ToString();
                txtpersonNRIC.Text = ret.Eventid[iCount].Incharg_NricNo.ToString();

                txtEventstartTime.Text = ret.Eventid[iCount].Start_time.ToString();
                txtEventEndTime.Text = ret.Eventid[iCount].End_time.ToString();
                txtPosition.Text = ret.Eventid[iCount].Incharg_position.ToString();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private string getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                return dsLocationName.Rows[0][0].ToString().Trim();
            }
            return null;
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('NewPrintpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}
