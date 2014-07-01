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
    public partial class AdminRiskSurvey : System.Web.UI.Page
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
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string where = ReturnWhere();
                /*DataSet dsitem = dal.getdataset("select R1.Risk_id,R1.ClientName,R1.CompletedBy,R1.DateFrom"
                                                 + " from RiskSurvey1 as R1, RiskSurvey16 as R16"
                                                + " where R1.Risk_id = R16.Risk_id" + where + " ");*/
                DataSet dsitem = dal.getdataset(" select R1.Risk_id,R1.ClientName,R1.CompletedBy,R1.DateFrom from RiskSurvey1 as R1 ,RiskSurvey16 as R16 where R1.Risk_id=R16.Risk_id "+where+"");

                //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvPassTable.PageSize = 20;
                gvPassTable.DataSource = dsitem.Tables[0];
                gvPassTable.DataBind();
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
                    Server.Transfer("ViewRiskAssessmentSurvey.aspx");
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
                dal.executesql("Delete from RiskSurvey1 Where table1_id ='" + argKeyID + "' ");
                Server.Transfer("AdminRiskSurvey.aspx");
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
        protected void gvPass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/RiskAssessmentSurvey.aspx");
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
                txtclientname.Text = "";
                txtcompletedby.Text = "";
                txtdatefrom.Text = "";
                txtdateto.Text = "";
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

                if (txtclientname.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    makeWhereClause = " where ";
                    //    str += " where ClientName='" + txtclientname.Text.Trim() + "'";
                    //    arr.Add("1");
                    //}
                    //else
                    //{
                    str += " and R1.ClientName='" + txtclientname.Text.Trim() + "'";
                    //}
                }
                if (txtcompletedby.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where CompletedBy = '" + txtcompletedby.Text + "'";
                    //    arr.Add("2");
                    //}
                    //else
                    //{
                    str += " and R1.CompletedBy = '" + txtcompletedby.Text + "'";
                    //}
                }


                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    //    arr.Add("3");
                    //}
                    //else
                    //{
                    str += " and R1.DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    //}
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where DateFrom ='" + txtdatefrom.Text + "'";
                    //    arr.Add("4");
                    //}
                    //else
                    //{
                    str += " and R1.DateFrom ='" + txtdatefrom.Text + "'";
                    //}
                }


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
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
