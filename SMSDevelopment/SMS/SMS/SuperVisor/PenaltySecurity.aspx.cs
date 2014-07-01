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

using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;

namespace SMS.SuperVisor
{
    public partial class PenaltySecurity : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // BindGrid();
            }
            string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
            string ctrlname1 = Page.Request.Params.Get("__eventargument");
            if (ctrlname != null)
            {
                string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                {
                    if (controlname.ToUpper().Contains("gvItemTable".ToUpper()))
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
                                       
                   //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                   //HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                   //Server.Transfer("PassUpDate.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {                   
                   //DeleteItem(_BTId);
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
                    AdminBLL ws = new AdminBLL();
                    DeletePassRequest _req = new DeletePassRequest();

                    _req.Pass_No = argPassID.ToString();

                    ws.DeletePass(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("AlertUpdateComplete.aspx");
                }
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
                   
                    DataSet dspenalty = dal.getdataset("Select * from PenalitySecurityPersonnel");
                    if (dspenalty.Tables[0].Rows.Count > 0)
                    {
                        gvPassTable.DataSource = dspenalty.Tables[0];
                        gvPassTable.DataBind();
                    }
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dspenalty = dal.getdataset("Select * from PenalitySecurityPersonnel");
                if (dspenalty.Tables[0].Rows.Count > 0)
                {
                    gvPassTable.DataSource = dspenalty.Tables[0];
                    gvPassTable.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }







    }
}
