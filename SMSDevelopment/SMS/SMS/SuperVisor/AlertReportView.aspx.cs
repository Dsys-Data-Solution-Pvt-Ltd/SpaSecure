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

//using Microsoft.SqlServer.Management.Trace;
using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class AlertReportView : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAlertID.Focus();
                if (!IsPostBack)
                {
                    BindGridWithFilter();
                    //fillAlertType();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void fillAlertType()
        {
            //ddlAlertType.Items.Clear();
            //ddlAlertType.Items.Add(" ");
            //string ID = "alerttype";
            //SqlParameter[] para1 = new SqlParameter[1];
            //para1[0] = new SqlParameter("@ID", ID);
            //DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           
            //if (dt.Rows.Count > 0)
            //{
            //    for (int k = 0; k < dt.Rows.Count; k++)
            //    {
            //        ddlAlertType.Items.Add(dt.Rows[k][0].ToString());
            //    }
            //}
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
                    DataSet ds = dal.getdataset("Select V_ResgistNo from Alert_Handling where Alert_id = '" + _BTId + "' ");
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString().Trim() != string.Empty)
                    {
                        Response.Redirect("~/SuperVisor/AlertViewVehicle.aspx?id=" + _BTId);

                        //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        //Server.Transfer("AlertViewVehicle.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/SuperVisor/AlertView.aspx?id=" + _BTId);

                        //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        //Server.Transfer("AlertView.aspx");
                    }
                   
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
        private void DeleteItem(string argalertid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                if (!string.IsNullOrEmpty(argalertid))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteAlertRequest _req = new DeleteAlertRequest();

                    _req.Alert_ID = argalertid.ToString();

                    ws.DeleteAlert(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("..//SMSAdmin//AlertUpdateComplete.aspx");
                }

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
                    //gvLoctionTable.PageIndex = e.NewPageIndex;
                    //BindGridWithFilter();
                    //AdminBLL ws = new AdminBLL();
                    //GetLocationData _req = new GetLocationData();
                    //GetLocationDataResponse _resp = ws.GetLocationData(_req);

                    //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    //gvLoctionTable.PageSize = pageSize;
                    //gvLoctionTable.DataSource = _resp.Location;
                    //gvLoctionTable.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
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
                GetAlertData objReq = new GetAlertData();
                string WhereClause = ReturnWhere();

                if (!string.IsNullOrEmpty(txtAlertID.Text))
                {
                    objReq.Alert_ID = txtAlertID.Text;
                }
                if (!string.IsNullOrEmpty(ddlAlertType.Text))
                {
                    objReq.Alert_Type = ddlAlertType.Text;
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


                GetAlertDataResponse ret = ws.GetAlertData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = ret.Alert_ID;
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

                if (txtAlertID.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Alert_ID='" + txtAlertID.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Alert_ID='" + txtAlertID.Text + "'";
                    }
                }
                if (ddlAlertType.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Alert_Type='" + ddlAlertType.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Alert_Type ='" + ddlAlertType.Text + "'";
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
                GetLocationData _req = new GetLocationData();
                GetLocationDataResponse _resp = ws.GetLocationData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = _resp.Location;
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnSearchAdminAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilter();
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
                ddlAlertType.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnNewPersonAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/PersonAlertHandling.aspx");
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void bntNewVehicleAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/VehicleAlertHandling.aspx");
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }









    }
}
