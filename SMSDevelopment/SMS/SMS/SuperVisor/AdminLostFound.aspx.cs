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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
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
    public partial class AdminLostFound : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
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
            string where = "Select Lost_ID, Date,Name,LostStatus from LostFoundItem where 1=1";
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                //Add by Ruchi
                if (txtName.Text.Length != 0)
                {
                    where += " and Name='" + txtName.Text + "'";
                }
                if (txtNRIC.Text.Length != 0)
                {
                    where += " and NRICno='" + txtNRIC.Text + "'";
                }
                if (txtdatefrom.Text.Length != 0 && txtdateto.Text.Length != 0)
                {
                    where += " and Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                }

                DataSet dsitem = dal.getdataset(where);
                ////int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = 20;
                gvKeySearch.DataSource = dsitem.Tables[0];
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void gvNewKey_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvKeySearch.Columns[0].FooterText = "Total Records: 20";
                }


            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewKey_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("LostAndFoundReport.aspx");
                }


                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("UpdateLostFound.aspx");
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
                dal.executesql("Delete from LostFoundItem Where Lost_ID ='" + argKeyID + "' ");

                //if (!string.IsNullOrEmpty(argKeyID))
                //{
                //    AdminBLL ws = new AdminBLL();
                //    DeleteKeyRequest _req = new DeleteKeyRequest();

                //    _req.KeyNo = argKeyID.ToString();

                //    ws.DeleteKey(_req);
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                //    Server.Transfer("AlertUpdateComplete.aspx");
                //}
                Server.Transfer("CompleteForm.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvNewKey_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        //protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void btnNew_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/AddLostFound.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        /*  private void BindGridWithFilter()
          {
              log4net.ILog logger = log4net.LogManager.GetLogger("File");
              try
              {
                  AdminBLL ws = new AdminBLL();
                  GetAdminLostFound objReq = new GetAdminLostFound();
                 // getLocationIDByName(ddllocation.Text.Trim());
                  string WhereClause = ReturnWhere();

                  if (!string.IsNullOrEmpty(txtdateto.Text))
                  {
                      if (!string.IsNullOrEmpty(txtdatefrom.Text))
                      {
                          objReq.dateFrom = txtdatefrom.Text;
                          objReq.dateFrom = txtdatefrom.Text;
                      }
                  }
                  if (!string.IsNullOrEmpty(txtdatefrom.Text))
                  {
                      if (string.IsNullOrEmpty(txtdateto.Text))
                      {
                          objReq.dateFrom= txtdatefrom.Text;
                      }
                  }
                  if (!string.IsNullOrEmpty(txtNRIC.Text))
                  {
                      objReq.nric = txtNRIC.Text;
                  }
                  if (!string.IsNullOrEmpty(txtName.Text))
                  {
                      objReq.Name = txtName.Text;
                  }
                
                  if (!string.IsNullOrEmpty(WhereClause))
                  {
                      objReq.WhereClause = WhereClause;
                  }
                  GetAdminLostFoundReprt ret = ws.GetAdminLostFound(objReq);

                  int pageSize = ContextKeys.GRID_PAGE_SIZE;
                  gvKeySearch.PageSize = pageSize;
                  gvKeySearch.DataSource = ret.LostFound;
                  if (ret.LostFound.Count == 0)
                  {
                      // incident2.Visible = false;
                  }
                  gvKeySearch.DataBind();
                  //incident2.Text = ret.Incident.Count.ToString();
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
                  /*if (txtdateto.Text != "" && txtdatefrom.Text != "")
                  {
                      if (arr.Count == 1)
                      {
                          str += " where Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                          arr.Add("1");
                      }
                      else
                      {
                          str += " and Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                      }

                  }*/
        /*if (txtdatefrom.Text != "" && txtdateto.Text == "")
        {
            if (arr.Count == 1)
            {
                makeWhereClause = " where ";
                str += " where Date='" + txtdatefrom.Text + "'";
                arr.Add("2");
            }
            else
            {
                str += " and Date='" + txtdatefrom.Text + "'";
            }
        }
        if (txtName.Text != "")
        {
            if (arr.Count == 1)
            {
                str += " where Name='" + txtName.Text + "'";
                arr.Add("3");
            }
            else
            {
                str += " and Name='" + txtName.Text + "'";
            }
        }
        if (txtNRIC.Text != "")
        {
            if (arr.Count == 1)
            {
                str += " where NRICno='" + txtNRIC.Text + "'";
                arr.Add("4");

            }
            else
            {
                str += " and NRICno='" + txtNRIC.Text + "'";
            }
        }
                               
    }
    catch (Exception ex)
    {
        logger.Info(ex.Message);
    }

    return (str);
}*/

        protected void btnSearchKeyAdd_Click(object sender, EventArgs e)
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

        protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        {
            //add by ruchi
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            txtNRIC.Text = "";
            txtName.Text = "";
        }

        protected void gvKeySearch_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }






    }
}
