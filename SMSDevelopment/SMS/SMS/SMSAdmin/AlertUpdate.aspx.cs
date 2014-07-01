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
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
namespace SMS.SMSAdmin
{
    public partial class AlertUpdate : System.Web.UI.Page
    {

        SqlConnection cn;
        AdminDAL a = new AdminDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAddItemDesc.Focus();
                String iBTID = string.Empty;
               
                cn = a.getconnection();
                String q;
                q = "select Description from log where ID='alerttype'";
                SqlCommand cmd = new SqlCommand(q, cn);
                SqlDataReader rec = cmd.ExecuteReader();
                while (rec.Read())
                {
                    if (!IsPostBack)
                    ddlRole.Items.Add(rec.GetValue(0).ToString());
                }
                rec.Close();


                if (ddlRole0.Text == "")
                {
                    String q1;
                    q1 = "select Description from log where ID='departmentname'";
                    SqlCommand cmd1 = new SqlCommand(q1, cn);
                    SqlDataReader rec1 = cmd1.ExecuteReader();
                    while (rec1.Read())
                    {
                        if (!IsPostBack)
                        ddlRole0.Items.Add(rec1.GetValue(0).ToString());
                    }
                    rec1.Close();
                }




                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        ((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }

                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AlertHandlingUser objalert = new AlertHandlingUser();
              
                AdminBLL ws = new AdminBLL();
                objalert.Alert_Type = ddlRole.Text;
                objalert.Name = txtAddItemDesc.Text;
                objalert.NRIC_no = txtAddNRIC.Text;
                objalert.Company = txtAddCompany.Text;
                objalert.Vehicle_no = txtAddVehicle.Text;
                objalert.Message = txtmessage.Text;

                objalert.Bynricno = txtbynric.Text;
                objalert.Name1 = txtname.Text;
                objalert.Designation = txtdesignation.Text;
                objalert.Department = ddlRole0.Text;
                objalert.phone = txtphone.Text;
             
                ws.Updatalert(objalert);
               

                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
            }
          
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../Reports/AlertReport.aspx");
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
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



                objGetBillingTableRequest.NRIC_no = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where NRIC_no='" + argsBGID.ToString() + "'";

                ret = objAdminBLL.GetAlertData(objGetBillingTableRequest);

                hdnBTID.Value = ret.Alert[iCount].NRIC_no.ToString();


                ddlRole.Text = ret.Alert[iCount].Alert_Type.ToString();
                txtAddItemDesc.Text = ret.Alert[iCount].Name.ToString();
                txtAddNRIC.Text = ret.Alert[iCount].NRIC_no.ToString();
                txtAddCompany.Text = ret.Alert[iCount].Company.ToString();
                txtAddVehicle.Text = ret.Alert[iCount].Vehicle_no.ToString();
                txtmessage.Text = ret.Alert[iCount].Message.ToString();
                txtname.Text = ret.Alert[iCount].Name1.ToString();
                txtdesignation.Text = ret.Alert[iCount].Designation.ToString();
                ddlRole0.Text = ret.Alert[iCount].Department.ToString();
                txtphone.Text = ret.Alert[iCount].phone.ToString();
                txtbynric.Text = ret.Alert[iCount].Bynricno.ToString();



            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

    }
}
