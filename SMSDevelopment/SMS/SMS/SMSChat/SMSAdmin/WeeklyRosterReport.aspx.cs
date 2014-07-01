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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SMSAdmin
{
    public partial class WeeklyRosterReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {                   
                    fillWeek();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
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
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
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

        private void fillWeek()
        {
            ddlWeekname.Items.Clear();

            DataSet dsleave = dal.getdataset("Select WeekName,WeekID from WeekMaster Order by WeekID Asc");
            if (dsleave.Tables[0].Rows.Count > 0)
            {
                ddlWeekname.DataSource = dsleave.Tables[0];
                ddlWeekname.DataTextField = "WeekName";
                ddlWeekname.DataValueField = "WeekID";
                ddlWeekname.DataBind();
                ddlWeekname.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" ", " ", true));
            }
        }

        private void BindGrid()
        {
            getLocationIDByName(ddllocation.Text.Trim());
            string where = ReturnWhere();
            if (where != "")
            {
                DataSet ds = dal.getdataset("Select MDate,StaffName,Shift from vwWeeklyDeployment " + where + " ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvItemTable.DataSource = ds;
                    gvItemTable.DataBind();
                }
            }
            else
            {
                gvItemTable.DataSource = null;
                gvItemTable.DataBind();
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
                        str += " where LocationID='" + SearchLocID.Text.Trim() + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and LocationID='" + SearchLocID.Text.Trim() + "'";
                    }
                }
                if (ddlWeekname.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where WeekID = '" + ddlWeekname.SelectedValue.Trim() + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and WeekID = '" + ddlWeekname.SelectedValue.Trim() + "'";
                    }
                }
                if (txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where MDate ='" + txtdatefrom.Text + "' ";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and MDate ='" + txtdatefrom.Text + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }
        protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //string _BTId = Convert.ToString(e.CommandArgument);
                //string state = string.Empty;

                //if (e.CommandName == "View")
                //{
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                //    Server.Transfer("ClientVisitMinuteReport.aspx");
                //}
                //if (e.CommandName == "DeleteRow")
                //{
                //    DeleteItem(_BTId);
                //}
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
                //if (!string.IsNullOrEmpty(argPassID))
                //{

                //    dal.executesql("Delete from tblClientVisitMinutes where strCVID = '" + argPassID + "' ");
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                //    //Server.Transfer("CompleteForm.aspx");
                //    BindGrid();
                //}
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvItemTable.Columns[0].FooterText = "Total Records: 20";
                }

            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
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
      
        protected void btnclear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                ddlWeekname.Text = "";
                ddllocation.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string str = string.Empty;
                str = DropDownList1.Text;
                if (str == "Excel")
                    DownloadCsvFormat();
                if (str == "Pdf")
                    DownloadPDFFormat();
                if (str == "Html")
                    DownloadHtmlFormat();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public void DownloadPDFFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Document pdfReport = new Document(PageSize.A4, 25, 25, 40, 25);
                System.IO.MemoryStream msReport = new System.IO.MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfReport, msReport);
                pdfReport.Open();



                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (ddllocation.Text != "")
                    str = ("   Location : " + ddllocation.SelectedItem);
                if (ddlWeekname.Text != "")
                    str += ("   Week Name : " + ddlWeekname.SelectedItem);

                if (txtdatefrom.Text != "")
                    str += ("   Date :" + txtdatefrom.Text);



                //Create Heading
                Phrase headerPhrase = new Phrase("Weekly Roster Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("                                                     Generated On : ");
                headerPhrase.Add(datetime);
                headerPhrase.Add("                                                                           Searching Parameter  : ");
                headerPhrase.Add(str);



                //Create Heading
                // Phrase headerPhrase = new Phrase("Contractor Report", FontFactory.GetFont("TIMES_ROMAN", 16));
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);




                // Creates the Table
                PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvItemTable.Columns.Count]; // percentage


                headerwidths[0] = 4.2F;
                headerwidths[1] = 4.2F;
                headerwidths[2] = 4.2F;
                //headerwidths[3] = 4.2F;
                //headerwidths[4] = 4.2F;
                //headerwidths[5] = 4.2F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase(gvItemTable.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvItemTable.Rows.Count; intJ++)
                {
                    for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvItemTable.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvItemTable.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                        }
                        else
                        {
                            cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                        }
                        ptData.AddCell(cell);
                    }
                }

                //Insert the Table

                pdfReport.Add(ptData);

                //Closes the Report and writes to Memory Stream

                pdfReport.Close();

                //Writes the Memory Stream Data to Response Object
                Response.Clear();
                // Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoPdfFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=WeeklyRosterReport.pdf"));
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(msReport.ToArray());
                Response.End();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        public void DownloadCsvFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment;filename=WeeklyRosterReporter.csv"));
                Response.Charset = "";
                Response.ContentType = "application/Text";
                TextWriter sw = new StringWriter();
                int iColCount = gvItemTable.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(gvItemTable.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");

                    }
                }

                sw.Write(sw.NewLine);
                // Write all the rows.
                foreach (GridViewRow grv in gvItemTable.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(grv.Cells[i]))
                        {
                            if (grv.Cells[i].Text.ToString() != "&nbsp;")
                            {
                                sw.Write(grv.Cells[i].Text.ToString());
                            }
                            else
                            {
                                sw.Write("");
                            }
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }

                    }
                    sw.Write(sw.NewLine);
                }
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
                Response.Write(sw.ToString());
                Response.End();
                sw.Close();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public void DownloadHtmlFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvItemTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (ddllocation.Text != "")
                    str = ("   Location : " + ddllocation.Text);




                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=WeeklyRoster.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>Weekly Roster Report</b></CAPTION>");
                sw.Write("Generated On : ");
                sw.Write(datetime);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("Searching Parameter : ");
                sw.Write(str);



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvItemTable.Columns[i].HeaderText.ToString();
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    sw.Write("<td>");
                    sw.Write("&nbsp");
                    sw.Write("</td>");

                }
                sw.Write("</tr>");

                foreach (GridViewRow grvRow in gvItemTable.Rows)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        strContent = grvRow.Cells[i].Text.ToString();
                        sw.Write("<td>");
                        sw.Write(strContent);
                        sw.Write("</td>");
                        sw.Write("<td>");
                        sw.Write("&nbsp");
                        sw.Write("</td>");
                    }
                    sw.Write("</tr>");
                }
                sw.Write("</table>");

                Response.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvItemTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string WhereClause = string.Empty;
                if (e.NewPageIndex >= 0)
                {
                    gvItemTable.PageIndex = e.NewPageIndex;
                    //dal.gridpageindex = e.NewPageIndex;
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvItemTable_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

       

    }
}
