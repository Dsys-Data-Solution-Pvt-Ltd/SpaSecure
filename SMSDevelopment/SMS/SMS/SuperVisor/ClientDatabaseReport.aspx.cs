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
    public partial class ClientDatabaseReport : System.Web.UI.Page
    {
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
                    //((master.login)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                //if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                //{
                //    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                //}
                if (Request.QueryString["id"] != null)
                {
                    iBTID = Request.QueryString["id"];
                }

                PopulatePageCntrls(iBTID);
            }
        }


            private void PopulatePageCntrls(String argsBGID)
            {
               
                    Int32 iCount = 0;
                    GetLocationDataResponse ret = null;
               

                    AdminBLL objAdminBLL = new AdminBLL();
                    GetLocationData objGetBillingTableRequest = new GetLocationData();
                    objGetBillingTableRequest.locid = argsBGID.ToString();
                    objGetBillingTableRequest.WhereClause = " where Location_id= '" + argsBGID + "'";
                    ret = objAdminBLL.GetLocationData(objGetBillingTableRequest);

                    txtOperationName.Text = ret.Location[iCount].Operation_Name.ToString();
                    txtOperationsContactTele.Text = ret.Location[iCount].O_cont.ToString();
                    txtOperationsContactMobile.Text = ret.Location[iCount].O_Mob.ToString();
                    txtOperationsContactEmail.Text = ret.Location[iCount].O_Email.ToString();
                    txtOperationsContactFax.Text = ret.Location[iCount].O_Fax.ToString();


                    txtManageName.Text = ret.Location[iCount].Management_Name.ToString();
                    txtManageTele.Text = ret.Location[iCount].M_cont.ToString();
                    txtManageMobile.Text = ret.Location[iCount].M_Mob.ToString();
                    txtManageEmail.Text = ret.Location[iCount].M_Email.ToString();
                    txtManageFax.Text = ret.Location[iCount].M_Fax.ToString();

                    // txtEmergencyContactEmail.Text = ret.Location[iCount].Emergency_email.ToString();

                
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
