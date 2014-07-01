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

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class AdminSecurityOfficerBriefing : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (HttpContext.Current.Session["SESSION_LOGIN_USER"] == null)
                {
                    Response.Redirect("~/master/login3.aspx");
                }
                if (!IsPostBack)
                {
                    fillEventType();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }                
                    
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       
        private void fillEventType()
        {
            txtAlertID.Items.Clear();
            txtAlertID.Items.Add(" ");
            string ID = "BrieorType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
          
            if (dt1.Rows.Count > 0)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    txtAlertID.Items.Add(dt1.Rows[j][0].ToString().Trim());
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
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
                }
            }
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationIDByName(ddllocation.Text.Trim());
                string where = ReturnWhere();
                DataSet dsitem = dal.getdataset("Select * from tblSOBriefing " + where + " ");

                ////int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvLoctionTable.PageSize = 20;
                gvLoctionTable.DataSource = dsitem.Tables[0];
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
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

                if (ddllocation.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Location ='" + ddllocation.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Location ='" + ddllocation.Text.Trim() + "'";
                    }
                }
                if (txtAlertID.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where TypeofBriefing = '" + txtAlertID.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and TypeofBriefing = '" + txtAlertID.Text + "'";
                    }
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where BreiActionDate BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and BreiActionDate BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where BreiActionDate ='" + txtdatefrom.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and BreiActionDate ='" + txtdatefrom.Text + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvLoctionTable.Columns[0].FooterText = "Total Records: 20";
                }

            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ViewSOBriefing.aspx");
                }


                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("UpdateSOBriefing.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }

            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void DeleteItem(string argKeyID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Delete from tblSOBriefing Where SOBrief_id ='" + argKeyID + "' ");
                Response.Redirect("../SuperVisor/AdminSecurityOfficerBriefing.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    //gvKeySearch.PageIndex = e.NewPageIndex;
                    //AdminBLL ws = new AdminBLL();
                    //GetNewKey _req = new GetNewKey();
                    //GetNewKeyRequest _resp = ws.GetNewKey(_req);

                    //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    //gvKeySearch.PageSize = pageSize;
                    //gvKeySearch.DataSource = _resp.Key;
                    //gvKeySearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


        protected void btnAddNewBriefing_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/SecurityOfficerBriefing.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearAdminAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAlertID.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchAdminAlert_Click(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }






    }
}
