using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSAdmin
{
    public partial class SOPUpdate : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        DBConnectionHandler1 db = new DBConnectionHandler1();
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 iBTID = 0;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtUpdateSOPTitle.Focus();
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
                        int ID= iBTID = Convert.ToInt32(HttpContext.Current.Items[ContextKeys.CTX_BT_ID]);
                        SOP_ID.Text = Convert.ToString(ID);
                    }
                    //fillLocation();
                    PopulatePageCntrls(iBTID);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            DataSet dslocation = dal.getdataset("Select Location_name from location order by Location_name asc");
            if (dslocation.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dslocation.Tables[0].Rows.Count; k++)
                {
                    ddllocation.Items.Add(dslocation.Tables[0].Rows[k][0].ToString());
                }
            }
        }
       


        protected void btnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
            
                AddNewSOPRequest objAddSOP = new AddNewSOPRequest();
                SOP objSOP_Data = new SOP();
                string imagepathname = hdnBTID.Value;
                AdminBLL ws = new AdminBLL();
                if (txtImagePath.FileName != null)
                {
                    if (txtImagePath.HasFile)
                    {
                        string path = Server.MapPath("../FileUpload/");
                        txtImagePath.PostedFile.SaveAs(path + txtImagePath.FileName);
                        //HttpContext.Current.Session["ImagePath"] = Convert.ToString(path + txtImagePath.FileName);
                        HttpContext.Current.Session["ImagePath"] = Convert.ToString(txtImagePath.FileName);
                    }
                }

                objSOP_Data.ImagePathName = HttpContext.Current.Session["ImagePath"].ToString();

                objSOP_Data.SOP_ID = txtUpdateSOPNo.Text;
                objSOP_Data.SOP_Title = txtUpdateSOPTitle.Text;
                objSOP_Data.SOP_Subject = txtUpdateSOPSubject.Text;
                string location_name = ddllocation.SelectedValue.ToString();
                objSOP_Data.Location = getLocationById(location_name);

                    
                   
                

                //objSOP_Data.ImagePathName = HttpContext.Current.Session["ImagePath"].ToString();
                ws.UpdateSOPData(objSOP_Data);
                HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                Server.Transfer("AlertUpdateComplete.aspx");
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               Server.Transfer("../SMSAdmin/SOPAdmin.aspx");
            }
           
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void PopulatePageCntrls(int argsBGID)
        {
            Int32 iCount = 0;
            GetSOPDataResponse ret = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetSOPData objGetBillingTableRequest = new GetSOPData();
                objGetBillingTableRequest.SOP_ID = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = " where SOP_ID =" + argsBGID.ToString();

                ret = objAdminBLL.GetSOPData(objGetBillingTableRequest);

                hdnBTID.Value = ret.SOPNo[iCount].SOP_ID.ToString();
                hdnBTID.Value = ret.SOPNo[iCount].SOP_Title.ToString();
                hdnBTID.Value = ret.SOPNo[iCount].SOP_Subject.ToString();
                //hdnBTID.Value = ret.SOPNo[iCount].ImagePathName.ToString();
                hdnBTID.Value = ret.SOPNo[iCount].Location.ToString();
                cn = db.getconnection();
                cn.Open();
                SqlCommand _cmd = new SqlCommand("select Location_name from location where Location_id=@id",cn);
                _cmd.Parameters.AddWithValue("@id", hdnBTID.Value);
                SqlDataReader dr = _cmd.ExecuteReader();
                if (dr.Read()) 
                {
                    ddllocation.Items.Insert(0,dr.GetString(0));
                    //========================//
                    dr.Close();
                    dr.Dispose();
                    //========================//
                    cn.Close();
                }
                
                txtUpdateSOPNo.Text     = ret.SOPNo[iCount].SOP_ID.ToString();
                txtUpdateSOPTitle.Text  = ret.SOPNo[iCount].SOP_Title.ToString();
                txtUpdateSOPSubject.Text = ret.SOPNo[iCount].SOP_Subject.ToString();
                Session.Add("ImagePath", ret.SOPNo[iCount].ImagePathName.ToString());

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        public string getLocationById(string name)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            string date = System.DateTime.Now.ToShortDateString();
            SqlCommand cmd = new SqlCommand("select Location_id from location where Location_name=@location_name", cn);
            cmd.Parameters.AddWithValue("@location_name",name);
            SqlDataReader dr = cmd.ExecuteReader();
            string result = "";
            if (dr.Read())
            {
                if (dr.GetInt32(0) != 0)
                {
                    int x = dr.GetInt32(0);
                    result = Convert.ToString(x);
                    //========================//
                    dr.Close();
                    dr.Dispose();
                    //========================//
                    cn.Close();
                }
                
            }
            return result;
        }
    }
}
