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
using SMS.Services.DataService;
using System.Collections.Generic;

namespace SMS.SuperVisor
{
    public partial class TrainingEvaluation_Master : System.Web.UI.Page
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
                    //DataSet ds = dal.getdataset("Select * from tblCourseEvaluation");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    gvPassTable.DataSource = ds;
                    //    gvPassTable.DataBind();
                    //}
                    fillgrid();
                }
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
                string state = string.Empty;

                if (e.CommandName == "EditRow")
                {
                   Server.Transfer("TrainingEvaluation.aspx?id=" + _BTId);
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

        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argPassID))
                {

                    dal.executesql("Delete from tblCourseEvaluation where intID = '" + argPassID + "' ");
                    //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //Server.Transfer("AlertUpdateComplete.aspx");
                   
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void fillgrid()
        {
            string where = ReturnWhere();
            DataSet ds = dal.getdataset("Select * from tblCourseEvaluation " + where + " ");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
                gvPassTable.DataSource = ds;
                gvPassTable.DataBind();
            //}
            //else
            //{
                //gvPassTable.DataSource = null;
                //gvPassTable.DataBind();
            //}
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
                        str += " where dtmDateOfEvaluation BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and dtmDateOfEvaluation BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where dtmDateOfEvaluation ='" + txtdatefrom.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and dtmDateOfEvaluation ='" + txtdatefrom.Text + "'";
                    }
                }
                if (txtTraineeName.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where strNameOfTrainee ='" + txtTraineeName.Text.Trim() + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and strNameOfTrainee ='" + txtTraineeName.Text.Trim() + "'";
                    }
                }
                if (txtNricNumber.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where strNric ='" + txtNricNumber.Text.Trim() + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and strNric ='" + txtNricNumber.Text.Trim() + "'";
                    }
                }
                if (txtvenue.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where strVenue ='" + txtvenue.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and strVenue ='" + txtvenue.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }
        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                fillgrid();

                //if (e.NewPageIndex >= 0)
                //{
                //    gvPassTable.PageIndex = e.NewPageIndex;

                //    AdminBLL ws = new AdminBLL();
                //    GetPassData _req = new GetPassData();
                //    GetPassDataResponse _resp = ws.GetPassData(_req);

                //    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //    gvPassTable.PageSize = pageSize;
                //    gvPassTable.DataSource = _resp.Pass;
                //    gvPassTable.DataBind();
                //}
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
                Response.Redirect("NewTrainingEvaluation.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearTraining_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                txtNricNumber.Text = "";
                txtTraineeName.Text = "";
                txtvenue.Text = "";
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
                fillgrid();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
