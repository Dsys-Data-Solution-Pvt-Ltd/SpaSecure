using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.ADMIN
{
    public partial class ExcelReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["ReportType"]) == "DOCTORPAYREPORT")
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=InventoryOut.pdf");

                Response.TransmitFile(Server.MapPath("~/ADMIN/Reports/PDFReports/InventoryOut.pdf"));
            }
        }
    }
}
