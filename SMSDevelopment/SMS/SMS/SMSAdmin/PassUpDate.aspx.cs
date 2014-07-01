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


using log4net;
using log4net.Config;


using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;


namespace SMS.SMSAdmin
{
    public partial class PassUpDate : System.Web.UI.Page
    {

        SqlConnection cn;
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = String.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                 txtUpdatePassNo.Focus();
                 fillpasstype();

                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, btnSave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);

                    }
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = Convert.ToString(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                    }

                    PopulatePageCntrls(iBTID);
                }




            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void fillpasstype()
        {
            if (IsPostBack == false)
            {
                DataSet ds1 = dal.getdataset("select Description from log where ID='passtype' order by Description Asc");
                for (int t = 0; t < ds1.Tables[0].Rows.Count; t++)
                {
                    ddlAddPassType.Items.Add(ds1.Tables[0].Rows[t][0].ToString().Trim());
                }
            }
        }




 
        protected void btnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
                Pass objPass_Data = new Pass();
                AdminBLL ws = new AdminBLL();

                objPass_Data.Pass_id = txtpass_id.Text;
                objPass_Data.Pass_No =txtUpdatePassNo.Text;
                objPass_Data.pass_Type = ddlAddPassType.Text;
                objPass_Data.Pass_Desciption = txtUpdatePassDescription.Text;

                ws.UpdatePassData(objPass_Data);
                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx");
            }
          
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetPassDataResponse ret = null;
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //DBConnectionHandler1 db = new DBConnectionHandler1();
                //SqlConnection cn = db.getconnection();
                //cn.Open();
                //SqlCommand cmd = new SqlCommand("select Pass_No,pass_Type,Pass_Desciption from Pass_Master where Pass_id=@passid", cn);
                //cmd.Parameters.AddWithValue("@passid", argsBGID);
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                    
                //    txtUpdatePassNo.Text = dr.GetString(0);
                //    ddlAddPassType.Text = dr.GetString(1);
                //    txtUpdatePassDescription.Text = dr.GetString(2);
                //    cn.Close();
                //}
                //hdnBTID.Value = txtUpdatePassNo.Text;
                AdminBLL objAdminBLL = new AdminBLL();
                GetPassData objGetBillingTableRequest = new GetPassData();
                objGetBillingTableRequest.Pass_No = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where Pass_id= '" + argsBGID + "' ";

                ret = objAdminBLL.GetPassData2(objGetBillingTableRequest);

                //hdnBTID.Value = ret.Pass[iCount].Pass_No.ToString();

                txtpass_id.Text = ret.Pass[iCount].Pass_id.ToString();
                txtUpdatePassNo.Text = ret.Pass[iCount].Pass_No.ToString();
                ddlAddPassType.Text = ret.Pass[iCount].pass_Type.ToString();
                txtUpdatePassDescription.Text = ret.Pass[iCount].Pass_Desciption.ToString();
           }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnBackPassAdmin_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {    
               // Response.Redirect("../SMSAdmin/AdminPass.aspx");
                Server.Transfer("../SuperVisor/AdminPass.aspx"); 
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
