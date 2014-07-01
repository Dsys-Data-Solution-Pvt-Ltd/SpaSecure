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



using SMS.BusinessEntities;
using SMS.BusinessEntities.Authorization;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Main;

namespace SMS.SMSCommons
{
    public partial class AdminSuperHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            ClientName.Text = HttpContext.Current.Session["SESSION_LOGIN_USER"].ToString();
            initgrid();
            initgrid2();

        }
        void initgrid()
        {
            SqlConnection conn = new SqlConnection();
            AdminDAL c = new AdminDAL();
            conn = c.getconnection();

            string sa;
            sa = "Select * from AdminHead_Site";

            SqlCommand cmd = new SqlCommand(sa, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds);
            SiteTable.DataSource = ds;
            SiteTable.DataBind();
        }
        void initgrid2()
        {
            SqlConnection conn = new SqlConnection();
            AdminDAL c = new AdminDAL();
            conn = c.getconnection();

            string sa;
            sa = "Select * from Alert_Handling";

            SqlCommand cmd = new SqlCommand(sa, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds);
            Site_Table1.DataSource = ds;
            Site_Table1.DataBind();
        }
        protected void SiteTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    SiteTable.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }
        protected void SiteTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ItemUpdate.aspx");
                }
            }

            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }
        protected void SiteTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    SiteTable.PageIndex = e.NewPageIndex;
                    // BindGridWithFilter();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }


        protected void SiteTable1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    SiteTable.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }
        protected void SiteTable1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ItemUpdate.aspx");
                }
            }

            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }
        protected void SiteTable1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    SiteTable.PageIndex = e.NewPageIndex;
                    // BindGridWithFilter();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {

            }
        }

    }
}