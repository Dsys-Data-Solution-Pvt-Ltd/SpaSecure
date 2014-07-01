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
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using SMS.master;


namespace SMS.SMSAdmin
{
    public partial class SOPAdmin : System.Web.UI.Page
    {
           
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();
        DBConnectionHandler1 db = new DBConnectionHandler1();
        SqlConnection cn;
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;
                lblerr1.Visible = false;
                lblerr2.Visible = false;
               // txtSOPID.Focus();
                //txtUpdateSOPTitle.Focus();

                if (!IsPostBack)
                {
                  
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security")
                    {
                        if (Session["LCID"] != null)
                        {
                            getLocationNameById(Session["LCID"].ToString());
                        }
                        else
                        {
                            getLocationName();
                        }
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }

                   
                 //   BindGrid();

                   // BindGridWithFilter();

                }

                 string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvSOPTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGrid();


                                }
                                else
                                {

                                }

                            }
                        }
                    }
                }
                else
                {
                    BindGrid();

                }
            
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void DeleteSOP(string argSOPId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argSOPId))
                {
                    AdminBLL ws = new AdminBLL();
                    AdminDAL w = new AdminDAL();
                    SqlConnection conn = new SqlConnection();
                    conn = w.getconnection();

                    DeleteSOPRequest _req = new DeleteSOPRequest();

                    _req.SOP_ID = argSOPId.ToString();
                    string id = argSOPId.ToString();

                    string query = "select top 1 ImagePathName from SOP_Master name where SOP_ID='" + id + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader rd = cmd.ExecuteReader();
                    string s = string.Empty;
                    while (rd.Read())
                    {
                        s = rd.GetValue(0).ToString();
                    }
                    FileInfo TheFile = new FileInfo(MapPath("../Images/") + "\\" + s);
                    if (TheFile.Exists)
                    {
                        File.Delete(MapPath("../Images/") + "\\" + s);
                    }

                    ws.DeleteSOP(_req);
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Deleted SuccessFully');", true);

                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    BindGrid();
                    ModalPopupDelete.Hide();
                    //========================//
                    rd.Close();
                    rd.Dispose();
                    //========================//
                    //Server.Transfer("AlertUpdateComplete.aspx");
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetSOPData objReq = new GetSOPData();

               // string WhereClause = ReturnWhere();

                GetSOPDataResponse ret = ws.GetSOPData(objReq);
             
                gvSOPTable.DataSource = ret.SOPNo;
                gvSOPTable.DataBind();

                ShowHide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void ShowHide()
        {
            if (Session["ManagementRole"].ToString() == "Security Officer")
            {
                gvSOPTable.Columns[gvSOPTable.Columns.Count - 1].Visible = false;
                gvSOPTable.Columns[gvSOPTable.Columns.Count - 2].Visible = false;
                //btnNewItem.Visible = false;
                //ddllocation.Visible = false;
                //lbllocation.Visible = false;
            }
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetSOPData _req = new GetSOPData();
                GetSOPDataResponse _resp = ws.GetSOPData(_req);

                
                gvSOPTable.DataSource = _resp.SOPNo;
                gvSOPTable.DataBind();
                ShowHide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("AddFile.aspx");//
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gvSOPTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Icon button


        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                                            DataTable dtAddSOP = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "104");

                                            if (dtAddSOP.Rows.Count > 0)
                                            {
                                                this.ModalPopupAdd.Show();
                                            }
                                            else
                                            {
                                               
                                                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");   
          

                                            }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ImgEdit_Click(object sender, EventArgs e)
        {

            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            DataTable dtViewSOP = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "105");
          
            if (dtViewSOP.Rows.Count > 0)
            {
                if (ViewState["SOP_ID"] != null)
                {
                    this.ModalPopupEdit.Show();
                    PopulatePageCntrls(Convert.ToInt32(ViewState["SOP_ID"]));
                }
            }
            else
            {

                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


            }



           
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {


            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            DataTable dtViewSOP = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "105");

            if (dtViewSOP.Rows.Count > 0)
            {
                if (ViewState["SOP_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            else
            {

                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


            }



           
        }

        #endregion Icon button

        #region Add Button

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchid.Text = ddllocation.Text;
        }

        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private string getLocationIDByName1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
            return searchid.Text;
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        protected void btnAddSOP_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            AddNewSOPRequest objAddSOP = new AddNewSOPRequest();
            SOP ObjSOP = new SOP();
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            UploadedFile f = null;
            try
            {
                if (txtSOPtitle.Text != "")
                {
                    ObjSOP.SOP_Title = txtSOPtitle.Text;
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please fill the Tittle ..!");
                    return;
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please fill the Tittle ..!";
                }


                ObjSOP.Date_From = DateTime.Now;
                ObjSOP.Location = getLocationIDByName1(searchid.Text);
                ObjSOP.SOP_Subject = txtSOPsubject.Text.Trim();
                if (txtImagePathAdd.UploadedFiles.Count > 0)
                {
                    f = txtImagePathAdd.UploadedFiles[0];

                }

                if (f != null)
                {
                    if (f.FileName.Length > 0)
                    {
                        string path = Server.MapPath("~/Images/");
                        //  txtImagePathAdd.PostedFile.SaveAs(path + f.FileName);
                        f.SaveAs(path + f.FileName);

                        ObjSOP.ImagePathName = f.FileName;
                    }
                }
                else
                {
                    ObjSOP.ImagePathName = "";
                }
                AdminBLL ws = new AdminBLL();
                ws.AddUserSOP(ObjSOP);

                MyMasterPage.ShowErrorMessage("Record Inserted Successfully..!");     
          
                //lblerror.Visible = true;
                //lblerror.Text = "Insert Successfully ..!";
                clearall();
                BindGrid();
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearSOPAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupAdd.Hide();
                BindGrid();
                clearall();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void clearall()
        {
            txtSOPID.Text = "";
            txtSOPtitle.Text = "";
            txtSOPsubject.Text = "";
          //  ddllocation.SelectedItem.Text = "";
            // txtgenerate.Text = "";
        }

        #endregion

        # region Google viewer

        protected void ButtonCancelViewer_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupViewer.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ImagePathName_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                LinkButton lnk = (LinkButton)sender;

                string path = lnk.Text;

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/Images/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();
    
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void lblUploadimage_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {


                string path = lblUploadimage.Text;

                var domainname = Request.ServerVariables["HTTP_HOST"];



                string s = " https://docs.google.com/viewer?url=http://" + domainname + "/Images/" + path + "&embedded=true";
                ViewerDoc.Attributes.Add("src", s);
                ModalPopupViewer.Show();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion

        #region Edit Button

        private void fillLocation()
        {
            ddllocationUpdate.Items.Clear();
            ddllocationUpdate.Items.Add(" ");
            DataSet dslocation = dal.getdataset("Select Location_name from location order by Location_name asc");
            if (dslocation.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dslocation.Tables[0].Rows.Count; k++)
                {
                    ddllocationUpdate.Items.Add(dslocation.Tables[0].Rows[k][0].ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                AddNewSOPRequest objAddSOP = new AddNewSOPRequest();
                SOP objSOP_Data = new SOP();
                string imagepathname = hdnBTID.Value;
                AdminBLL ws = new AdminBLL();
                UploadedFile upload = null;


                if (txtImagePathUpdate.UploadedFiles.Count > 0)
                {
                    upload = txtImagePathUpdate.UploadedFiles[0];

                }

                if (upload != null)
                {
                    if (upload.FileName.Length > 0)
                    {
                        string path = Server.MapPath("~/Images/");
                        //  txtImagePathAdd.PostedFile.SaveAs(path + f.FileName);
                        upload.SaveAs(path + upload.FileName);

                        objSOP_Data.ImagePathName = upload.FileName;
                       
                    }
                }
                else
                {
                    objSOP_Data.ImagePathName = lblUploadimage.Text;
                }

                objSOP_Data.SOP_ID = txtUpdateSOPNo.Text;
                objSOP_Data.SOP_Title = txtUpdateSOPTitle.Text;
                objSOP_Data.SOP_Subject = txtUpdateSOPSubject.Text;
                string location_name = ddllocationUpdate.SelectedValue.ToString();
                objSOP_Data.Location = getLocationById(location_name);

                //objSOP_Data.ImagePathName = HttpContext.Current.Session["ImagePath"].ToString();
                ws.UpdateSOPData(objSOP_Data);
                  clearUpdate();
                  ModalPopupEdit.Hide();
                  BindGrid();
                  MyMasterPage.ShowErrorMessage("Record Updated Successfully..!");     
          
               // HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        public void clearUpdate()
        {
            txtUpdateSOPNo.Text="";
            txtUpdateSOPTitle.Text="";
            txtUpdateSOPSubject.Text="";
           // ddllocationUpdate.SelectedItem.Text = "";
            lblUploadimage.Text = "";

        }
        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupEdit.Hide();
                BindGrid();
                clearUpdate();

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
                hdnBTID.Value = ret.SOPNo[iCount].ImagePathName.ToString();
                hdnBTID.Value = ret.SOPNo[iCount].Location.ToString();
                cn = db.getconnection();
                cn.Open();
                SqlCommand _cmd = new SqlCommand("select Location_name from location where Location_id=@id", cn);
                _cmd.Parameters.AddWithValue("@id", hdnBTID.Value);
                SqlDataReader dr = _cmd.ExecuteReader();
                if (dr.Read())
                {
                    ddllocationUpdate.Items.Insert(0, dr.GetString(0));
                    ddllocationUpdate.SelectedIndex = 0;
                    //========================//
                    dr.Close();
                    dr.Dispose();
                    //========================//
                    cn.Close();
                }

                txtUpdateSOPNo.Text = ret.SOPNo[iCount].SOP_ID.ToString();
                txtUpdateSOPTitle.Text = ret.SOPNo[iCount].SOP_Title.ToString();
                txtUpdateSOPSubject.Text = ret.SOPNo[iCount].SOP_Subject.ToString();
                lblUploadimage.Text = ret.SOPNo[iCount].ImagePathName.ToString();
               // lblUploadimage.NavigateUrl ="javascript:w= window.open('../Images/"+ret.SOPNo[iCount].ImagePathName.ToString()+"','MessageCompose','height=400,width=300,top=50,left=50,toolbar=no,  menubar=no,location=no,resizable=no,scrollbars=yes,status=no'); return false";
                    // ret.SOPNo[iCount].ImagePathName.ToString();
                
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
            cmd.Parameters.AddWithValue("@location_name", name);
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

        #endregion

        #region Delete Button Code

        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
          
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string SOP_ID = ViewState["SOP_ID"].ToString();

                DeleteSOP(SOP_ID);

                MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");     
          
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupDelete.Hide();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        # region Grid Selected Row Function



        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvSOPTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvSOPTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvSOPTable.Items[ro].Selected = true;


                        ViewState["SOP_ID"] = item.OwnerTableView.DataKeyValues[ro]["SOP_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        #endregion

    }
}
