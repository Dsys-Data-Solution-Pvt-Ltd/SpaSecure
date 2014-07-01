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

namespace SMS.ADMIN
{
    public partial class AdminFacilityBooking : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                lblerror.Visible = false;               
                if (!IsPostBack)
                {
                    fillFacilityType();                  
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillFacilityType()
        {
            ddlfacility.Items.Clear();
            string ID = "FacilityType";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);           
            if (dt.Rows.Count > 0)
            {
                ddlfacility.DataSource = dt;
                ddlfacility.DataTextField = "Description";
                ddlfacility.DataValueField = "Description";
                ddlfacility.DataBind();
                ddlfacility.Items.Insert(0, new ListItem("", "", true));
            }
        }
        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string where = ReturnWhere();
                DataSet dsitem = dal.getdataset("Select Fbook,FacilityType,Name,CONVERT(CHAR(10),bookingdateFrom,103) As bookingdateFrom , CONVERT(CHAR(10),bookingdateto,103) As bookingdateTo, bookingtimeFrom,bookingtimeTo, l.Location_name from FacilityBooking, location as l where FacilityBooking.Location_id=l.Location_id " + where + " ");
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    gvPassTable.PageIndex = dal.gridpageindex;
                    gvPassTable.PageSize = 20;
                    gvPassTable.DataSource = dsitem.Tables[0];
                    gvPassTable.DataBind();
                }
                else
                {
                    gvPassTable.DataSource = null;
                    gvPassTable.DataBind();
                }
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

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Datefrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Datefrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Datefrom ='" + txtdatefrom.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Datefrom ='" + txtdatefrom.Text + "'";
                    }
                }
                if (txtname.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and Name ='" + txtname.Text.Trim() + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Name ='" + txtname.Text.Trim() + "'";
                    }
                }
                if (txtunitno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and UnitNumber ='" + txtunitno.Text.Trim() + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and UnitNumber ='" + txtunitno.Text.Trim() + "'";
                    }
                }
                if (ddlfacility.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " and FacilityType ='" + ddlfacility.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and FacilityType ='" + ddlfacility.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }
        protected void gvPass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ViewFacilityBooking.aspx");
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
                SqlParameter[] para1 = new SqlParameter[1];
                para1[0] = new SqlParameter("@Fbook", argKeyID);
                dal.executeprocedure("SP_DeleteFacilityBook", para1);

               // dal.executesql("Delete from FacilityBooking Where Fbook ='" + argKeyID + "' ");
                Server.Transfer("AdminFacilityBooking.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string WhereClause = string.Empty;
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
        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtunitno.Text = "";
                txtname.Text = "";
                txtdateto.Text = "";
                txtdatefrom.Text = "";
                ddlfacility.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
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
        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../ADMIN/FacilityBooking.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
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
