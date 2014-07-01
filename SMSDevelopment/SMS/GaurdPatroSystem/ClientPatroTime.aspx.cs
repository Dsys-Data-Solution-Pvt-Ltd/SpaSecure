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
using System.Data.SqlClient;
using System.Collections.Generic;


namespace GaurdPatroSystem
{
    public partial class ClientPatroTime : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
            hy7.Visible = false;
            HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
            hy.Visible = true;
            HyperLink hy1 = (HyperLink)Master.FindControl("Home1");
            hy1.Visible = false;
            //hy1.NavigateUrl = "VerifyLogin.aspx";
            HyperLink hy2 = (HyperLink)Master.FindControl("Home2");
            hy2.Visible = false;
            HyperLink hy3 = (HyperLink)Master.FindControl("fileby");
            hy3.Visible = false;
            HyperLink hy4 = (HyperLink)Master.FindControl("recordby");
            hy4.Visible = false;
            LinkButton hy5 = (LinkButton)Master.FindControl("lnknewclient");
            hy5.Visible = false;
            LinkButton hy6 = (LinkButton)Master.FindControl("LinkButton1");
            hy6.Visible = false;
            try
            {
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvLoctionTable.Columns[0].FooterText = "Total Records: 20";
                }
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
                //string _BTId = Convert.ToString(e.CommandArgument);
                //if (e.CommandName == "View")
                //{
                //    //DataSet ds = dal.getdataset("Select V_ResgistNo from Alert_Handling where Alert_id = '" + _BTId + "' ");
                //    //if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString().Trim() != string.Empty)
                //    //{
                //    //    Response.Redirect("~/SuperVisor/AlertViewVehicle.aspx?id=" + _BTId);
                //    //}
                //    //else
                //    //{
                //    Response.Redirect("~/AlertView.aspx?id=" + _BTId);
                //    //}
                //}
                //if (e.CommandName == "DeleteRow")
                //{
                //    dal.executesql("Delete from GaurdTourSystem where GTid=" + _BTId);
                //}
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }
        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                lblsearch.Text = dsLocationName.Rows[0][0].ToString().Trim();
            }
        }
        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvLoctionTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilter();
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilter()
        {
            try
            {
                string where = ReturnWhere();
                string quer = "select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + Session["LCID"].ToString() + ")" + where + "order by PatrolTime desc";
                DataSet dsitem = dal.getdataset(quer);
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    gvLoctionTable.PageSize = 20;
                    gvLoctionTable.DataSource = dsitem.Tables[0];
                    gvLoctionTable.DataBind();
                }
                else
                {
                    gvLoctionTable.DataSource = null;
                    gvLoctionTable.DataBind();
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            try
            {
                getLocationNameById(Session["LCID"].ToString());
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtchkpoint.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    makeWhereClause = " where ";
                    //    str += " where Check_Point='" + txtchkpoint.Text.Trim() + "'";
                    //    arr.Add("4");
                    //}
                    //else
                    //{
                        str += " and Check_Point='" + txtchkpoint.Text.Trim() + "'";
                    //}
                }
                if (txtpersonnel.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    makeWhereClause = " where ";
                    //    str += " where Check_Point='" + txtchkpoint.Text.Trim() + "'";
                    //    arr.Add("4");
                    //}
                    //else
                    //{
                    str += " and Personnel='" + txtpersonnel.Text.Trim() + "'";
                    //}
                }
                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where PatrolTime BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    //    arr.Add("2");
                    //}
                    //else
                    //{
                       str += " and PatrolTime BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                       
                    //}
                }

                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    str += " where PatrolTime='" + txtdatefrom.Text + "'";
                    //    arr.Add("3");
                    //}
                    //else
                    //{
                        str += " and PatrolTime='" + txtdatefrom.Text + "'";
                    //}
                }
                //if (lblsearch.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Personnel ='" + lblsearch.Text + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and Personnel ='" + lblsearch.Text + "'";
                //    }
                //}

                if (txtdatefrom.Text == "" || txtdateto.Text == "")
                {
                    
                        string timeFrom = txtdatefrom.Text + " " + 12+ ":" + 0 + ":" + 0+"AM";
                        string timeTo = txtdateto.Text + " " + 12 + ":" +0 + ":" + 0+"PM";
                        if (arr.Count == 1)
                        {
                            str += " And Convert(time,PatrolTime) Between  CONVERT(time,'" + timeFrom + "') and CONVERT(time,'" + timeTo + "')";
                        }
                   
                    
                }
                else
                {
                    if (TimeSelector1.SelectedTimeFormat.ToString() != "" && TimeSelector2.SelectedTimeFormat.ToString() != "")
                    {
                        string timeFrom = txtdatefrom.Text + " " + TimeSelector1.Hour + ":" + TimeSelector1.Minute + ":" + TimeSelector1.Second;
                        string timeTo = txtdateto.Text + " " + TimeSelector2.Hour + ":" + TimeSelector2.Minute + ":" + TimeSelector2.Second;
                        if (arr.Count == 1)
                        {
                            str += " And Convert(time,PatrolTime) Between  CONVERT(time,'" + timeFrom + "') and CONVERT(time,'" + timeTo + "')";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
            return (str);
        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
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
                // logger.Info(ex.Message);
            }
        }
        public void DownloadPDFFormat()
        {
            try
            {
                Document pdfReport = new Document(PageSize.A4, 25, 25, 40, 25);
                System.IO.MemoryStream msReport = new System.IO.MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfReport, msReport);
                pdfReport.Open();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);
                string str = string.Empty;

                if (txtpersonnel.Text != "")
                    str = ("   Personnel : " + txtpersonnel.Text);
                if (txtchkpoint.Text != "")
                    str = ("   Check Point : " + txtchkpoint.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


                //Create Heading
                Phrase headerPhrase = new Phrase("Guard Patro System Report                                                       ", FontFactory.GetFont("Garamond", 14));

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
                PdfPTable ptData = new PdfPTable(gvLoctionTable.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvLoctionTable.Columns.Count]; // percentage

                headerwidths[0] = 4.2F;
                headerwidths[1] = 3.5F;
                headerwidths[2] = 4.2F;
                headerwidths[3] = 4.2F;
                headerwidths[4] = 3.2F;
                headerwidths[5] = 4.2F;  

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvLoctionTable.Columns.Count; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase(gvLoctionTable.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvLoctionTable.Rows.Count; intJ++)
                {
                    for (int intK = 0; intK < gvLoctionTable.Columns.Count; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvLoctionTable.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvLoctionTable.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=GuardPatrosystempfd.pdf"));
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(msReport.ToArray());
                Response.End();
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }

        }
        public void DownloadCsvFormat()
        {
            try
            {
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment;filename=GuardPatroSystem.csv"));
                Response.Charset = "";
                Response.ContentType = "application/Text";
                TextWriter sw = new StringWriter();
                int iColCount = gvLoctionTable.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(gvLoctionTable.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                // Write all the rows.
                foreach (GridViewRow grv in gvLoctionTable.Rows)
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
                //logger.Info(ex.Message);
            }
        }
        public void DownloadHtmlFormat()
        {
            try
            {
                Int32 intcellCount = gvLoctionTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);
                string str = string.Empty;

                if (txtpersonnel.Text != "")
                    str = ("   Personnel : " + txtpersonnel.Text);
                if (txtchkpoint.Text != "")
                    str = ("   Check Point : " + txtchkpoint.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);

                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=GuardPatroSystem.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>GuardPatroSystem Report</b></CAPTION>");
                sw.Write("Generated On : ");
                sw.Write(datetime);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("Searching Parameter : ");
                sw.Write(str);

                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvLoctionTable.Columns[i].HeaderText.ToString();
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    sw.Write("<td>");
                    sw.Write("&nbsp");
                    sw.Write("</td>");
                }
                sw.Write("</tr>");

                foreach (GridViewRow grvRow in gvLoctionTable.Rows)
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
                // logger.Info(ex.Message);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtpersonnel.Text = "";
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            txtchkpoint.Text = "";
        }

       
    }
}
