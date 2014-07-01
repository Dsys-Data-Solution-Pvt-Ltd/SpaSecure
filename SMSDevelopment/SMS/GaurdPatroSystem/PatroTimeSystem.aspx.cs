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
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace GaurdPatroSystem
{
    public partial class PatroTimeSystem : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                    hy7.Visible = true;
                    HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
                    hy.Visible = true;
                    HyperLink hy1 = (HyperLink)Master.FindControl("Home1");
                    hy1.Visible = false;
                    HyperLink hy2 = (HyperLink)Master.FindControl("Home2");
                    hy2.Visible = true;
                    HyperLink hy3 = (HyperLink)Master.FindControl("fileby");
                    hy3.Visible = true;
                    HyperLink hy4 = (HyperLink)Master.FindControl("recordby");
                    hy4.Visible = true;
                    LinkButton hy6 = (LinkButton)Master.FindControl("LinkButton1");
                    hy6.Visible = true;
                    string BTID=Request.QueryString["BTID"];
                    if (BTID !=null)
                    {
                        
                            lbllocation.Visible = false;
                            ddllocation.Visible = false;
                            getLocationIDByName(BTID);
                            PopulatePageCntrls(SearchLocID.Text);
                            ddllocation.Items.Add(BTID);
                    }
                    else
                    {
                        BindGridWithFilter();
                        getLocationName();
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

           
            try
            {
                string where = ReturnWhere();
                DataSet dsitem = new DataSet();
                dsitem = dal.getdataset("select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + SearchLocID.Text + ")" + where + "order by PatrolTime desc");
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    gvLoctionTable.PageSize = 50;
                    gvLoctionTable.DataSource = dsitem.Tables[0];
                    gvLoctionTable.DataBind();
                }
                else
                {
                    gvLoctionTable.DataSource = null;
                    gvLoctionTable.DataBind();
                }
            }
            catch(Exception exc)
            {

            }
        }
        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            // para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
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
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "View")
                {
                    string qer=Request.QueryString["BTID"];
                    if (qer !=null)
                    {
                        Server.Transfer("EditPatroSystem.aspx?id=" + _BTId + "&id1=" + ddllocation.SelectedValue.ToString());
                    }
                    else
                    {
                        Server.Transfer("EditPatroSystem.aspx?id=" + _BTId);
                    }
                }               
                if (e.CommandName == "DeleteRow")
                {
                    dal.executesql("Delete from GaurdTourSystem where GTid="+_BTId);
                    //DBConnectionHandler1 db = new DBConnectionHandler1();
                    //SqlConnection cn = db.getconnection();
                    //cn.Open();
                    //SqlCommand cmd = new SqlCommand("delete from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID="+SearchLocID.Text+")",cn);
                    //SqlCommand cmd1 = new SqlCommand("delete from GaurdTourSystem2 where LocationID="+SearchLocID.Text, cn);
                    //int result1 = cmd.ExecuteNonQuery();
                    //int result2 = cmd1.ExecuteNonQuery();
                    BindGridWithFilter();
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
                DataSet dsitem = new DataSet();
                if (where.ToString() == "" && ddllocation.SelectedValue.ToString() == "")
                {
                    dsitem = dal.getdataset("Select * from GaurdTourSystem " + where + " order by PatrolTime desc");
                }
                else
                {
                    dsitem = dal.getdataset("select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + SearchLocID.Text + ")" + where + "order by PatrolTime desc");
                }
                //DataSet dsitem = dal.getdataset("Select * from GaurdTourSystem " + where + " order by PatrolTime desc");
                //DataSet dsitem = dal.getdataset("select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + SearchLocID.Text + ")"+ where +"order by PatrolTime desc");
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    gvLoctionTable.PageSize = 50;
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
                List<String> arr = new List<String>();
                arr.Add("test");

                if (txtpersonnel.Text.Trim() != "")
                {
                    //if (arr.Count == 1)
                    //{
                    //    makeWhereClause = " where ";
                    //    str += " where Personnel='" + txtpersonnel.Text.Trim() + "'";
                    //    arr.Add("1");
                    //}
                    //else
                    //{
                       str += " and Personnel='" + txtpersonnel.Text.Trim() + "'";
                    //}
                }
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
                if (ddllocation.SelectedValue.ToString() != "")
                {
                    getLocationIDByName(ddllocation.SelectedValue.ToString());
                    //if (arr.Count == 1)
                    //{
                    //    str += " where PatrolTime='" + txtdatefrom.Text + "'";
                    //    arr.Add("3");
                    //}
                    //else
                    //{
                    //str += " and PatrolTime='" + txtdatefrom.Text + "'";
                    //}
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
                if (str == "word")
                    DownloadwordFormat();
                if (str == "Pdf")
                    DownloadPDFFormat();
                
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
                /*Document pdfReport = new Document(PageSize.A4, 100, 91, 100, 93);
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

                string str = string.Empty;

                if (txtpersonnel.Text != "")
                    str = ("   Personnel : " + txtpersonnel.Text);
                if (txtchkpoint.Text != "")
                    str = ("   Check Point : " + txtchkpoint.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);



                //Create Heading
                //Phrase headerPhrase = new Phrase("Attendance Report                                                       ", FontFactory.GetFont("Garamond", 14));

                //headerPhrase.Add("                                                     Generated On : ");
                Phrase headerPhrase = new Phrase("                                     Guard Patro System Report                                                      ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("        Generated On : ");
                headerPhrase.Add(datetime);
                //headerPhrase.Add("                                                                           Searching Parameter  : ");
                //headerPhrase.Add(str);

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
                headerwidths[1] = 4.5F;
                headerwidths[2] = 4.5F;
                headerwidths[3] = 3.2F;
                headerwidths[4] = 3.2F;

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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.pdf"));
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(msReport.ToArray());
                Response.End();*/
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
                Phrase headerPhrase = new Phrase("                                            Guard Patro System Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("                                          Generated On : ");
                headerPhrase.Add(datetime);
                //headerPhrase.Add("                                                                           Searching Parameter  : ");
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
        public void DownloadwordFormat()
        {           
            /*try
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
            }*/
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvLoctionTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                // string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;
                Response.AddHeader("content-disposition", string.Format("attachment;filename=PatroTimeSystem.doc"));
                Response.Charset = "";
                Response.ContentType = "text/doc";
                StringWriter sw = new StringWriter();
                Response.Write("<Center><table></Center>");
                sw.Write("<b><hr></hr></b>");
                sw.Write("<CAPTION><b><font size='+2'>PatroTimeSystem Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><b><font size='+1'>Generated On : " + datetime + "</font></b></CAPTION>");
                //sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<table border =1>");
                sw.Write("<tr>");
                for (int i = 0; i < intcellCount-2; i++)
                {
                    strHeaderText = gvLoctionTable.Columns[i].HeaderText.ToString();
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    //sw.Write("<td>");
                    //sw.Write("&nbsp");
                    //sw.Write("</td>");

                }
                sw.Write("</tr>");
               
                foreach (GridViewRow grvRow in gvLoctionTable.Rows)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount-2; i++)
                    {
                        strContent = grvRow.Cells[i].Text.ToString();
                        sw.Write("<td>");
                        sw.Write(strContent);
                        sw.Write("</td>");
                        //sw.Write("<td>");
                        //sw.Write("&nbsp");
                        //sw.Write("</td>");
                    }
                    sw.Write("</tr>");
                }
                
                sw.Write("</table>");

                Response.Write(sw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Contractor.html"));
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
            try
            {
                txtpersonnel.Text = "";
                txtdateto.Text = "";
                txtdatefrom.Text = "";
                txtchkpoint.Text = "";
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("EditPatroSystem.aspx");
                if (Request.QueryString["BTID"] != null)
                {
                    Server.Transfer("EditPatroSystem.aspx?id1=" + Request.QueryString["BTID"].ToString());
                }
                else
                {
                    Server.Transfer("EditPatroSystem.aspx?qer=add");
                }
            }
            catch (Exception ex)
            {
            }
        }       

  }
}
