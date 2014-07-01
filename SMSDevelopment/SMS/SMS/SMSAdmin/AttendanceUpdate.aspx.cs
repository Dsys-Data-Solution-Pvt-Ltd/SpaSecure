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
using MKB.TimePicker;
using MKB.Exceptions;

namespace SMS.SMSAdmin
{
    public partial class AttendanceUpdate : System.Web.UI.Page
    {        
        AdminDAL a = new AdminDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;
            //cn = a.getconnection();

            //String q;
            //q = "select Description from log where ID='passtype'";
            //SqlCommand cmd = new SqlCommand(q, cn);
            //SqlDataReader rec = cmd.ExecuteReader();
            //while (rec.Read())
            //{
            //    cmbContractorPass.Items.Add(rec.GetValue(0).ToString());
            //}
            //rec.Close();


            if (!IsPostBack)
            {
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
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
            GetContractorDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                DateTime dt;
                GetContractorData objGetBillingTableRequest = new GetContractorData();
                objGetBillingTableRequest.checkout_id = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where checkout_id=" + argsBGID.ToString();


                ret = objAdminBLL.GetContractorData1(objGetBillingTableRequest);
                hdnBTID.Value = ret.Contractor[iCount].checkout_id.ToString();

                out_no.Text = ret.Contractor[iCount].checkout_id.ToString();
                txtnric.Text = ret.Contractor[iCount].user_id.ToString();

                txtname.Text = ret.Contractor[iCount].user_name.ToString();
                txtPassNo.Text = ret.Contractor[iCount].user_address.ToString();
                cmbContractorPass.Text = ret.Contractor[iCount].company_from.ToString();
                txtKeyNo.Text = ret.Contractor[iCount].to_visit.ToString();
              
                //role.Text = ret.Contractor[iCount].Role.ToString();

                dt = Convert.ToDateTime(ret.Contractor[iCount].checkin_time);
                calDateOfIncident.Text = Convert.ToString(dt);

                dt = Convert.ToDateTime(ret.Contractor[iCount].checkout_time);
                calDateOfIncident1.Text = Convert.ToString(dt);

                string remark = ret.Contractor[iCount].remarks.ToString();


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
                Contractor objcontractor = new Contractor();
                DateTime datetime;

                AdminBLL ws = new AdminBLL();
                objcontractor.checkout_id = out_no.Text;
                objcontractor.user_id = txtnric.Text;
                objcontractor.user_name = txtname.Text;

                objcontractor.user_address = txtPassNo.Text;
                objcontractor.company_from = cmbContractorPass.Text;
                objcontractor.to_visit = txtKeyNo.Text;

                objcontractor.checkin_time = DateTime.TryParse(calDateOfIncident.Text, out datetime) ? (DateTime?)datetime : null; ; ; ;
                objcontractor.checkout_time = DateTime.TryParse(calDateOfIncident1.Text, out datetime) ? (DateTime?)datetime : null; ; ; ;

                ws.Updatecontractor(objcontractor);
                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx");


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
                Server.Transfer("../Reports/AttendanceReport.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void cmbContractorPass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void hdnBTName_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void hdnBTID_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void calDateOfIncident1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmbContractorPass_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void calDateOfIncident_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
