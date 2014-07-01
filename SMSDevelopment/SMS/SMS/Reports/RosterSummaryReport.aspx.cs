using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Services.DALUtilities;
using System.Data.SqlClient;
using System.Data;
using SMS.Services.DataService;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Telerik.Web.UI;

namespace SMS.Reports
{
    public partial class RosterSummaryReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string ctrlname2 = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname3 = Page.Request.Params.Get("__eventargument");
                if (ctrlname2 != null)
                {
                    string controlname = ctrlname2;
                    if (controlname.ToUpper().Contains("gvRoster".ToUpper()))
                    {
                        if (ctrlname3 != null)
                        {
                            if (ctrlname3.Contains("RowClick"))
                            { }
                            else if (ctrlname3.ToUpper().Contains("FIRECOMMAND") || ctrlname3 == "")
                            {
                                BindGridWithFilter();


                            }
                            else
                            {

                            }

                        }
                    }

                }
                else
                {
                    BindGridWithFilter();

                }
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
                string str = string.Empty;
                string makeWhereClause = string.Empty;
                try
                {
                    List<String> arr = new List<String>();
                    arr.Add("test");


                    if (ddlLocation.Text.Trim() != "")
                    {
                        if (arr.Count == 1)
                        {
                            str += " where Location ='" + ddlLocation.Text + "'";
                            arr.Add("5");
                        }
                        else
                        {
                            str += " and Location ='" + ddlLocation.Text + "'";
                        }
                    }
                    if (ddlStaffiD.Text.Trim() != "")
                    {
                        if (arr.Count == 1)
                        {
                            str += " where StaffID ='" + ddlStaffiD.Text + "'";
                            arr.Add("5");
                        }
                        else
                        {
                            str += " and StaffID ='" + ddlStaffiD.Text + "'";
                        }
                    }
                    if (ddlMonth.Text.Trim() != "")
                    {
                        if (arr.Count == 1)
                        {
                            str += " where MonthID like'" + ddlMonth.SelectedValue + "%'";
                            arr.Add("5");
                        }
                        else
                        {
                            str += " and MonthID like'" + ddlMonth.SelectedValue + "%'";
                        }
                    }
                    if (ddlYear.Text.Trim() != "")
                    {
                        if (arr.Count == 1)
                        {
                            str += " where MonthID like'%" + ddlYear.Text + "'";
                            arr.Add("5");
                        }
                        else
                        {
                            str += " and MonthID like'%" + ddlYear.Text + "'";
                        }
                    }

                    DataTable dt = dal.getdata("select * from vwMonthlyRosterSummary " + str);
                    gvRoster.DataSource = dt;
                    gvRoster.DataBind();

                }
                catch (Exception ex)
                {
                    logger.Info(ex.Message);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string str = string.Empty;
                str = DropDownList1.Text;

                if (str == "Pdf")
                    DownloadPDFFormat();

                if (str == "Word")
                    DownloadWordFormat();
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
                Document pdfReport = new Document(PageSize.A4, 100, 91, 100, 93);
                System.IO.MemoryStream msReport = new System.IO.MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfReport, msReport);
                pdfReport.Open();
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(1).ToString() != "")
                    {
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(@dr.GetString(1).ToString().Trim());
                        image1.SetAbsolutePosition(70, 100);
                        PdfContentByte by = writer.DirectContent;
                        PdfTemplate tp = by.CreateTemplate(170, 190);
                        tp.AddImage(image1);
                        by.AddTemplate(tp, 175, 660);
                        cn.Close();
                        dr.Close();

                    }
                }
                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);



                //Phrase headerPhrase = new Phrase("Visitor Report                                                       ", FontFactory.GetFont("Garamond", 14));

                //headerPhrase.Add("                                                     Generated On : ");
                Phrase headerPhrase = new Phrase("                                       Roster Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("         Generated On : ");
                headerPhrase.Add(datetime);
                //headerPhrase.Add("                                                                           Searching Parameter  : ");
                //headerPhrase.Add(str);

                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);


                // Creates the Table
                PdfPTable ptData = new PdfPTable(gvRoster.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvRoster.Columns.Count]; // percentage


                headerwidths[0] = 3.6F;
                headerwidths[1] = 3.6F;
                headerwidths[2] = 4.2F;
                headerwidths[3] = 4.5F;
                // headerwidths[4] = 3.2F;
                // headerwidths[5] = 3.2F;
                //headerwidths[6] = 3.2F;
                //headerwidths[7] = 4.2F;




                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvRoster.Columns.Count; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    if (gvRoster.Columns[intK].HeaderText.ToString() != "")
                    {
                        cell.Phrase = new Phrase(gvRoster.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                        ptData.AddCell(cell);
                    }
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvRoster.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvRoster.Columns.Count - 1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvRoster.Items[intJ].Cells[intK + 2].Text.ToString() != "" && gvRoster.Items[intJ].Cells[intK + 2].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvRoster.Items[intJ].Cells[intK + 2].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                            ptData.AddCell(cell);
                        }
                        else
                        {
                            cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                            ptData.AddCell(cell);
                        }

                    }
                }

                //Insert the Table

                pdfReport.Add(ptData);

                //Closes the Report and writes to Memory Stream

                pdfReport.Close();

                //Writes the Memory Stream Data to Response Object
                Response.Clear();

                Response.AddHeader("content-disposition", string.Format("attachment;filename=RosterReport.pdf"));
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

        public void DownloadWordFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvRoster.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();


                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);



                Response.AddHeader("content-disposition", string.Format("attachment;filename=RosterReport.doc"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                string filePath = "";
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(1).ToString() != "")
                    {
                        filePath = dr.GetString(1).ToString().Trim();
                        cn.Close();
                        dr.Close();

                    }
                }
                //string filePath = Server.MapPath("../../Images/Untitled.png");
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{1}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");
                sw.Write("<CAPTION><b><font size='+2'>Roster Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+2'>Generated On : </font>");
                sw.Write("<font size='+2'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter : </font>");
                //sw.Write("<font size='+2'>"+str+"</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<table border =1>");



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvRoster.Columns[i].HeaderText.ToString();
                    if (strHeaderText != "")
                    {
                        sw.Write("<th>");
                        sw.Write(strHeaderText);
                        sw.Write("</th>");
                        //sw.Write("<td>");
                        //sw.Write("&nbsp");
                        //sw.Write("</td>");
                    }

                }
                sw.Write("</tr>");

                foreach (GridDataItem grvRow in gvRoster.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        strContent = grvRow.Cells[i + 2].Text.ToString();
                        if (strContent != "")
                        {
                            sw.Write("<td>");
                            sw.Write(strContent);
                            sw.Write("</td>");
                            //sw.Write("<td>");
                            //sw.Write("&nbsp");
                            //sw.Write("</td>");
                        }
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
    }
}