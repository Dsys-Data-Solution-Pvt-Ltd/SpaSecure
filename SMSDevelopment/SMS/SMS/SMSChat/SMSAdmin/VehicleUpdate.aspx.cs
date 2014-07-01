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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;


namespace SMS.SMSAdmin
{
    public partial class VehicleUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
            Int32 iBTID = 0;
            SqlConnection cn;
            AdminDAL a = new AdminDAL();
            cn = a.getconnection();
            String q;
            q = "select Description from log where ID='vehicletype'";
            SqlCommand cmd = new SqlCommand(q, cn);
            SqlDataReader rec = cmd.ExecuteReader();
            while (rec.Read())
            {
                drpvehicletype.Items.Add(rec.GetValue(0).ToString());
            }
            rec.Close();

            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = Convert.ToInt32(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                }

                PopulatePageCntrls(iBTID);
            }
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
                 try
                 {
                     Response.Redirect("../Reports/VehicleReport.aspx");
                    
                 }
                 catch (System.Threading.ThreadAbortException)
                 {
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
             catch (Exception ex)
             {
                 logger.Info(ex.Message);
             }


        }

        protected void btnClearVehicleAdd_Click(object sender, EventArgs e)
        { log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
            try
            {
                Vehicle objvehicle = new Vehicle();

                AdminBLL ws = new AdminBLL();
                objvehicle.Vehicle_No = txtEnterVehicleNo.Text;
                //objvehicle.Vehicle_Type = txtAddVechicleType.Text;
                objvehicle.Vehicle_Color = txtVehicleColor.Text;
                objvehicle.Vehicle_Model = txtVehicleModel.Text;
                objvehicle.Vehicle_Remark = txtEnterVehicleRemark.Text;
                objvehicle.Vehicle_Type = drpvehicletype.Text;



                ws.Updatevehicle(objvehicle);

                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx");
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }


        }

        private void PopulatePageCntrls(int argsBGID)
        {
            Int32 iCount = 0;
            GetVehicleDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                try
                {
                    AdminBLL objAdminBLL = new AdminBLL();
                    GetVehicleData objGetBillingTableRequest = new GetVehicleData();


                    objGetBillingTableRequest.Vehicle_No = argsBGID.ToString();


                    objGetBillingTableRequest.WhereClause = " where Vehicle_No=" + argsBGID.ToString();

                    ret = objAdminBLL.GetVehicleData(objGetBillingTableRequest);

                    hdnBTID.Value = ret.Vehicle[iCount].Vehicle_No.ToString();



                    txtEnterVehicleNo.Text = ret.Vehicle[iCount].Vehicle_No.ToString();
                    //txtAddVechicleType.Text = ret.Vehicle[iCount].Vehicle_Type.ToString();
                    txtVehicleColor.Text = ret.Vehicle[iCount].Vehicle_Color.ToString();
                    txtVehicleModel.Text = ret.Vehicle[iCount].Vehicle_Model.ToString();
                    txtEnterVehicleRemark.Text = ret.Vehicle[iCount].Vehicle_Remark.ToString();
                    drpvehicletype.Text = ret.Vehicle[iCount].Vehicle_Type.ToString();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }


        }


    }
}
