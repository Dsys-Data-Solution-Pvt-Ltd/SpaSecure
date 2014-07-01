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
using GaurdPatroSystem.Services.DataService;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GaurdPatroSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsitem = dal.getdataset("Select * from GaurdTourSystem ");
                gvLoctionTable.DataSource = dsitem.Tables[0];
                gvLoctionTable.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvLoctionTable.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("btnView");
                if (cb != null && cb.Checked)
                {
                }               
            }
        }
        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "View")
                {
                    Response.Redirect("EditPatroSystem.aspx?id=" + _BTId);
                }
               
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvLoctionTable.PageIndex = e.NewPageIndex;
                 
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
