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
using System.Collections.Generic;
using log4net;
using log4net.Config;
using System.Drawing;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using SMS.master;
namespace SMS.ADMIN
{
    public partial class LogSetting : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {                    
                  
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvPassTable".ToUpper()))
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
        private void BindGrid()
        {            
            SqlParameter[] para1 = new SqlParameter[0];
            DataTable dslog = dal.executeprocedure("SP_GetLogdata", para1, true);   
            if (dslog.Rows.Count > 0)
            { 
                gvPassTable.DataSource = dslog;
                gvPassTable.DataBind();
               
            }
        }
        private void clearall()
        {
            txtdesc.Text = "";
            txtID.Text = "";
            txttype.Text = "";
        }
        protected void gvPass_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvPassTable.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);  
                if (e.CommandName == "EditRow")
                {                   
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = new SqlParameter("@Logid", _BTId);
                    DataTable dsdes = dal.executeprocedure("SP_GetLogdatabylogid", para, true);                      
                    if (dsdes.Rows.Count > 0)
                    {
                        txtID.Text = dsdes.Rows[0]["Description"].ToString();                       
                    }
                }
                if (e.CommandName == "AddRow")
                {                   
                    SqlParameter[] para2 = new SqlParameter[1];
                    para2[0] = new SqlParameter("@Logid", _BTId);
                    DataTable dsid = dal.executeprocedure("SP_GetLogdatabylogid", para2, true);
                    if (dsid.Rows.Count > 0)
                    {
                       
                        txttype.Text = dsid.Rows[0]["ID"].ToString();                       
                    }
                }
                if (e.CommandName == "DeleteRow")
                {
                    SqlParameter[] para2 = new SqlParameter[1];
                    para2[0] = new SqlParameter("@Logid", _BTId);
                    dal.exeprocedure("SP_deleteLogdatabylogid", para2);
                    BindGrid();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }      

        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

      

      

        protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPassTable_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        protected void gvPassTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    dal.gridpageindex = e.NewPageIndex;
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        # region Icon menu

        #region Add
        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupAdd.Show();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void btnCancelCStaff_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAdd();
                this.ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtdesc.Text.Trim() != "")
                {
                    SqlParameter[] para4 = new SqlParameter[2];
                    para4[0] = new SqlParameter("@Description", txtdesc.Text);
                    para4[1] = new SqlParameter("@ID", txttype.Text);
                    dal.exeprocedure("SP_Insert_Logdata", para4);
                    BindGrid();
                    ClearAdd();
                    MyMasterPage.ShowErrorMessage("Log Add Successfully");  
                }
                else
                {
                    BindGrid();
                }
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
            }
        }
        public void ClearAdd()
        {
            txtdesc.Text = "";
            txttype.Text = "";
        }
       

        
        #endregion


        #region Update

        public void Fill(string _BTId)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Logid", _BTId);
            DataTable dsdes = dal.executeprocedure("SP_GetLogdatabylogid", para, true);
            if (dsdes.Rows.Count > 0)
            {
                txtID.Text = dsdes.Rows[0]["Description"].ToString();
            }
        }
        protected void ImgUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
                if (ViewState["Logid"] != null)
                {
                    Fill(ViewState["Logid"].ToString());
                    this.ModalPopupUpdate.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupUpdate.Hide();
                ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        
        public void ClearUpdate()
        {
            txtID.Text = "";
            this.ModalPopupUpdate.Hide();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtID.Text.Trim() != "")
                {
                    SqlParameter[] para3 = new SqlParameter[2];
                    para3[0] = new SqlParameter("@Description", txtID.Text);
                    para3[1] = new SqlParameter("@Logid", ViewState["Logid"].ToString());
                    dal.exeprocedure("SP_UpdateLogdata", para3);
                    this.ModalPopupUpdate.Hide();
                    MyMasterPage.ShowErrorMessage("Log Updated Successfully");
                    BindGrid();
                    ClearUpdate();
                }
                else
                {
                    BindGrid();
                }
              
            }
            catch (Exception ex)
            {
            }
        }

        #endregion update

        # region Delete
        private void DeleteItem(string _BTId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(_BTId))
                {
                    SqlParameter[] para2 = new SqlParameter[1];
                    para2[0] = new SqlParameter("@Logid", _BTId);
                    dal.exeprocedure("SP_deleteLogdatabylogid", para2);
                    this.ModalPopupDelete.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Logid"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (ViewState["Logid"] != null)
                {
                    DeleteItem(ViewState["Logid"].ToString());
                   
                    BindGrid();
                    this.ModalPopupDelete.Hide();
                    MyMasterPage.ShowErrorMessage("Log Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
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
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        #endregion

    


        #endregion

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvPassTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvPassTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvPassTable.Items[ro].Selected = true;


                        ViewState["Logid"] = item.OwnerTableView.DataKeyValues[ro]["Logid"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }
    }
}
