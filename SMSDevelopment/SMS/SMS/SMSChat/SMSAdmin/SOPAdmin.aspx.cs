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


namespace SMS.SMSAdmin
{
    public partial class SOPAdmin : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtSOPID.Focus();

                if (!IsPostBack)
                {
                    getSOPTitleName();
                    getSOPSubjectName();
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
                    getLocationIDByName(ddllocation.Text.Trim());
                    BindGridWithFilter();

                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void getSOPTitleName()
        {
            txtSOPtitle.Items.Clear();
            txtSOPtitle.Items.Add("");

            DataSet dstitle = dal.getdataset("Select SOP_Title from SOP_Master");
            if (dstitle.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dstitle.Tables[0].Rows.Count; k++)
                {
                    txtSOPtitle.Items.Add(dstitle.Tables[0].Rows[k][0].ToString().Trim());
                }
            }
        }
        private void getSOPSubjectName()
        {
            txtSOPSubjectSearch.Items.Clear();
            txtSOPSubjectSearch.Items.Add(" ");

            DataSet dsSubject = dal.getdataset("Select SOP_Title from SOP_Master");
            if (dsSubject.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsSubject.Tables[0].Rows.Count; k++)
                {
                    txtSOPSubjectSearch.Items.Add(dsSubject.Tables[0].Rows[k][0].ToString().Trim());
                }
            }
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
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                Searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }


        protected void btnNewSOP_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("NewSOPAdd.aspx");
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
                txtSOPID.Text = "";
                txtSOPSubjectSearch.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                txtSOPtitle.Text = "";

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvSOP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //JS for delete btn
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvSOPTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvSOP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("SOPUpdate.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteSOP(_BTId);
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
                    FileInfo TheFile = new FileInfo(MapPath("../FileUpload/") + "\\" + s);
                    if (TheFile.Exists)
                    {
                        File.Delete(MapPath("../FileUpload/") + "\\" + s);
                    }

                    ws.DeleteSOP(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void gvSOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvSOPTable.PageIndex = e.NewPageIndex;

                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnsearchSOP_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ddllocation.Text != "")
                {
                    getLocationIDByName(ddllocation.Text);
                }
                BindGridWithFilter();
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

                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtSOPID.Text))
                {
                    objReq.SOP_ID = txtSOPID.Text;
                }
                if (!string.IsNullOrEmpty(txtSOPSubjectSearch.Text))
                {
                    objReq.SOP_Subject = txtSOPSubjectSearch.Text;
                }
                if (!string.IsNullOrEmpty(txtSOPtitle.Text))
                {
                    objReq.SOP_Title = txtSOPtitle.Text;
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }


                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdateto.Text;
                    }
                }



                GetSOPDataResponse ret = ws.GetSOPData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvSOPTable.PageSize = pageSize;
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
                btnNewItem.Visible = false;
                ddllocation.Visible = false;
                lbllocation.Visible = false;
            }
        }

        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtSOPtitle.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Sop_Title='" + txtSOPtitle.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Sop_Title='" + txtSOPtitle.Text + "'";
                    }
                }
                if (txtSOPID.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Sop_ID='" + txtSOPID.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Sop_ID='" + txtSOPID.Text + "'";
                    }
                }
                if (txtSOPSubjectSearch.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Sop_Subject='" + txtSOPSubjectSearch.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Sop_Subject='" + txtSOPSubjectSearch.Text + "'";
                    }
                }

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From='" + txtdatefrom.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                }
                if (arr.Count == 1)
                {
                    if (txtdatefrom.Text.ToString() == "" && txtdateto.Text.ToString() == "" && ddllocation.Text.ToString() == "" && txtSOPtitle.Text.ToString() == "")
                    {

                    }
                    else
                    {
                        str += " where Location='" + Searchid.Text + "'";
                        arr.Add("7");
                    }
                    // makeWhereClause = " where ";

                }
                else
                {
                    str += " and Location='" + Searchid.Text + "'";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetSOPData _req = new GetSOPData();
                GetSOPDataResponse _resp = ws.GetSOPData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvSOPTable.PageSize = pageSize;
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

    }
}
