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
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;


namespace SMS.SMSAdmin
{
    public partial class VisitorUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 iBTID = 0;
                SqlConnection cn;
                AdminDAL a = new AdminDAL();
                cn = a.getconnection();
                String q;
                q = "select Description from log where ID='passtype'";
                SqlCommand cmd = new SqlCommand(q, cn);
                SqlDataReader rec = cmd.ExecuteReader();
                while (rec.Read())
                {
                    //cmbvisitorPass.Items.Add(rec.GetValue(0).ToString());
                }
                rec.Close();
                rec.Dispose();


                if (!IsPostBack)
                {
                    if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                    {
                        string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                        //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        ((master.login)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);

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
                Response.Redirect("../Reports/VisitorReport.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void AddCheckInVisitor(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Visitor objvisitor = new Visitor();

                AdminBLL ws = new AdminBLL();
                DateTime datetime;

                objvisitor.checkout_id = out_no.Text;
                objvisitor.user_id = txtNricID2.Text;
                objvisitor.purpose = txtVisitorPurpose2.Text;
                objvisitor.user_name = txtName2.Text;
                objvisitor.user_address = txtAddress2.Text;
                objvisitor.company_from = txtCompanyFrom2.Text;
                objvisitor.telephone = txtTeleNo2.Text;
                objvisitor.remarks = txtRemarks2.Text;
                objvisitor.vehicle_no = txtVehicleNo2.Text;
                objvisitor.key_no = txtKeyNo2.Text;
                objvisitor.pass_no = txtPassNo2.Text;
                objvisitor.PassType = cmbvisitorPass.Text;
                objvisitor.to_visit = txtToVisit2.Text;

                // objvisitor.Role = txtrole.Text;

                objvisitor.checkin_time = DateTime.TryParse(calDateOfIncident.Text, out datetime) ? (DateTime?)datetime : null; ; ; ;
                objvisitor.checkout_time = DateTime.TryParse(calDateOfIncident1.Text, out datetime) ? (DateTime?)datetime : null; ; ; ;

                Boolean ok = false;
                if (FileUpload1.FileName != null)
                {


                    if (FileUpload1.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        string[] ar = { ".jpg", ".gif", ".jpeg", ".png" };
                        for (int i = 0; i < ar.Length; i++)
                        {
                            if (ext == ar[i])
                            {
                                ok = true;
                                break;
                            }
                        }
                    }

                    if (ok)
                    {
                        try
                        {
                            string path = Server.MapPath("~/ImageUpload/");
                            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);

                            HttpContext.Current.Session["ImagePath"] = Convert.ToString(path + FileUpload1.FileName);

                        }
                        catch (Exception ex)
                        {
                            logger.Info(ex.Message);
                        }
                    }

                    objvisitor.user_image = HttpContext.Current.Session["ImagePath"].ToString();


                    ws.Updatvisotor(objvisitor);

                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    Server.Transfer("AlertUpdateComplete.aspx");
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
            GetVisitorDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                AdminBLL objAdminBLL = new AdminBLL();
                GetVisitorData objGetBillingTableRequest = new GetVisitorData();
                DateTime dt;

                objGetBillingTableRequest.checkout_id = argsBGID.ToString();


                objGetBillingTableRequest.WhereClause = " where checkout_id=" + argsBGID.ToString();


                ret = objAdminBLL.GetVisitorData1(objGetBillingTableRequest);
                hdnBTID.Value = ret.Visitor[iCount].checkout_id.ToString();

                out_no.Text = ret.Visitor[iCount].checkout_id.ToString();



                txtNricID2.Text = ret.Visitor[iCount].user_id.ToString();
                txtName2.Text = ret.Visitor[iCount].user_name.ToString();
                txtAddress2.Text = ret.Visitor[iCount].user_address.ToString();
                txtCompanyFrom2.Text = ret.Visitor[iCount].company_from.ToString();
                txtTeleNo2.Text = ret.Visitor[iCount].telephone.ToString();
                txtRemarks2.Text = ret.Visitor[iCount].remarks.ToString();

                txtVisitorPurpose2.Text = ret.Visitor[iCount].purpose.ToString();
                txtKeyNo2.Text = ret.Visitor[iCount].key_no.ToString();
                txtToVisit2.Text = ret.Visitor[iCount].to_visit.ToString();

                txtVehicleNo2.Text = ret.Visitor[iCount].vehicle_no.ToString();

                txtPassNo2.Text = ret.Visitor[iCount].pass_no.ToString();
                cmbvisitorPass.Text = ret.Visitor[iCount].PassType.ToString();
                txtItemDeclear2.Text = ret.Visitor[iCount].Item_Declear.ToString();

                txtrole.Text = ret.Visitor[iCount].Role.ToString();

                dt = Convert.ToDateTime(ret.Visitor[iCount].checkin_time);
                calDateOfIncident.Text = Convert.ToString(dt);

                dt = Convert.ToDateTime(ret.Visitor[iCount].checkout_time);
                calDateOfIncident1.Text = Convert.ToString(dt);

                Session.Add("ImagePath", ret.Visitor[iCount].user_image.ToString());
                Image3.ImageUrl = ret.Visitor[iCount].user_image.ToString();


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void VisitorDisplay_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload2_Click(object sender, EventArgs e)
        {

        }

        protected void cmbvisitorPass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbvisitorPass2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void hdnBTID_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void hdnBTName_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void calDateOfIncident_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
