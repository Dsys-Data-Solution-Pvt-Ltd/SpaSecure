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
using Telerik.Web.UI;

namespace SMS.SMSUsers.Reports
{
    public partial class AttendanceReportPast : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        int i = 0;
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //--------------image display---------------------------
                DBConnectionHandler1 bd = new DBConnectionHandler1();
                SqlConnection cn = bd.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        image1.ImageUrl = dr.GetString(0);
                        cn.Close();
                        dr.Close();
                    }
                }

                DBConnectionHandler1 bd1 = new DBConnectionHandler1();
                SqlConnection cn1 = bd.getconnection();
                cn1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from UploadLogo", cn1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    if (dr1.GetString(0) != "")
                    {
                        image2.ImageUrl = dr1.GetString(0);
                        cn1.Close();
                        dr1.Close();
                    }
                }

                //---------------------------=---------------------------
                String iBTID = string.Empty;

                //txtnricno.Focus();
                if (!IsPostBack)
                {
                   // BindGridWithFilter();
                   
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imgView") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvItemTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilter();


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
                    BindGridWithFilter();

                }
                string ctrlname2 = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname3 = Page.Request.Params.Get("__eventargument");
                if (ctrlname2 != null)
                {
                    string controlname = ctrlname2;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imgView")&& !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvCheckin".ToUpper()))
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
      


        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetContractorData _req = new GetContractorData();
                GetContractorDataResponse _resp = ws.GetStaffData(_req);


                gvItemTable.DataSource = _resp.Contractor;               
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void DeleteItem(string argContractorId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argContractorId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteContractorRequest _req = new DeleteContractorRequest();
                    _req.ContratorNo = argContractorId.ToString();
                    ws.DeleteContractor(_req);
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
                AdminBLL ws = new AdminBLL();
                GetContractorData objReq = new GetContractorData();
                
                string WhereClause = ReturnWhere();
                
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetContractorDataResponse ret = new GetContractorDataResponse();
                if (Request.QueryString["action"] != null)
                {
                    if (Request.QueryString["action"].ToLower() == "checkin" && Request.QueryString["curr"] != null)
                  
                    {
                        DataTable dt = ws.GetCheckInData(objReq);                        
                       
                        gvCheckin.DataSource = dt;
                        gvCheckin.DataBind();
                        gvItemTable.Visible = false;
                        imgDelete.Visible = false;
                        
                    }
                    else
                    {
                        DataTable dt = ws.GetContractorData(objReq);

                        gvItemTable.DataSource = dt;
                        //ret = ws.GetContractorData(objReq);
                      
                        //gvItemTable.DataSource = ret.Contractor;
                        gvItemTable.DataBind();
                        gvCheckin.Visible = false;
                    }
                }
                else
                {
                    DataTable dt = ws.GetContractorData(objReq);

                    gvItemTable.DataSource = dt;
                    //ret = ws.GetContractorData(objReq);
                    
                    //gvItemTable.DataSource = ret.Contractor;
                    gvItemTable.DataBind();
                    gvCheckin.Visible = false;
                }
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
                string useridcol = "NRICno";
                string datecolumn = "checkin_time";
                if (Request.QueryString["curr"] != null)                    
                {
                    if (Request["action"].ToLower() == "checkin")
                    {
                        useridcol = "NRICno";
                        datecolumn = "Checkin_DateTime";
                    }
                }
               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
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
                str = DropDownList1.SelectedItem.Text;
                //if (str == "Excel")
                //    if (gvCheckin.Visible == true)
                //    {
                //        DownloadCsvFormat2();
                //    }
                //    else
                //    {
                //        DownloadCsvFormat();
                //    }

                if (str == "Pdf")
                    if (gvCheckin.Visible == true)
                    {
                       // gvCheckin.MasterTableView.ExportToPdf();
                        DownloadPDFFormat2();
                    }
                    else
                    {
                        DownloadPDFFormat();
                    }

                //if (str == "Html")
                //    if (gvCheckin.Visible == true)
                //    {
                //        DownloadHtmlFormat2();
                //    }
                //    else
                //    {
                //        DownloadHtmlFormat();
                //    }

                if (str == "Word")
                    if (gvCheckin.Visible == true)
                    {
                        DownloadWordFormat2();
                    }
                    else
                    {
                        DownloadWordFormat();
                    }
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

                string str = string.Empty;



                Phrase headerPhrase = new Phrase("                                    Attendance Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("      Generated On : ");
                headerPhrase.Add(datetime);
           
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);

                // Creates the Table
                PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count-1);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;
                float[] headerwidths = new float[gvItemTable.Columns.Count-1]; // percentage

                headerwidths[0] = 4.2F;
                headerwidths[1] = 4.5F;
                headerwidths[2] = 4.5F;
                headerwidths[3] = 4.5F;
                headerwidths[4] = 4.5F;
                headerwidths[5] = 3.2F;
              


                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvItemTable.Columns.Count-1; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    if (gvItemTable.Columns[intK + 1].HeaderText.ToString() != "")
                    {
                        cell.Phrase = new Phrase(gvItemTable.Columns[intK + 1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                        ptData.AddCell(cell);
                    }
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvItemTable.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvItemTable.Columns.Count-1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvItemTable.Items[intJ].Cells[intK + 3].Text.ToString() != "&nbsp;" && gvItemTable.Items[intJ].Cells[intK + 3].Text.ToString() != "")
                        {
                            cell.Phrase = new Phrase(gvItemTable.Items[intJ].Cells[intK+3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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
                // Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoPdfFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.pdf"));
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

        public void DownloadPDFFormat2()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //gvCheckin.MasterTableView.ExportToPdf();
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
                        PdfTemplate tp = by.CreateTemplate(200, 220);
                        tp.AddImage(image1);
                        by.AddTemplate(tp, 175, 660);
                        cn.Close();
                        dr.Close();

                    }

                    string datetime = string.Empty;
                    datetime = Convert.ToString(System.DateTime.Now);

                    //Create Heading
                    Phrase headerPhrase = new Phrase("                                     Attendance Report                                                       ", FontFactory.GetFont("Garamond", 14));

                    headerPhrase.Add("      Generated On : ");
                    headerPhrase.Add(datetime);
                   
                    HeaderFooter header = new HeaderFooter(headerPhrase, false);
                    header.Border = Rectangle.NO_BORDER;
                    header.Alignment = Element.ALIGN_CENTER;
                    header.Alignment = Element.ALIGN_BOTTOM;
                    pdfReport.Header = header;
                    pdfReport.Add(headerPhrase);


                    // Creates the Table
                    PdfPTable ptData = new PdfPTable(gvCheckin.Columns.Count-1);
                    ptData.SpacingBefore = 8;
                    ptData.DefaultCell.Padding = 1;

                    float[] headerwidths = new float[gvCheckin.Columns.Count-1]; // percentage

                    headerwidths[0] = 4.2F;
                    headerwidths[1] = 4.2F;
                    headerwidths[2] = 4.5F;
                    headerwidths[3] = 4.5F;
                    headerwidths[4] = 3.2F;
                    //headerwidths[5] = 3.2F;

                    ptData.SetWidths(headerwidths);
                    ptData.WidthPercentage = 100;
                    ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    //Insert the Table Headers
                    for (int intK = 0; intK < gvCheckin.Columns.Count-1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BackgroundColor = new Color(200, 200, 200);
                        cell.BorderColor = new Color(100, 100, 100);

                        if (gvCheckin.Columns[intK + 1].HeaderText.ToString() != "")
                        {
                            cell.Phrase = new Phrase(gvCheckin.Columns[intK + 1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                            ptData.AddCell(cell);
                        }
                    }

                    ptData.HeaderRows = 1;  // this is the end of the table header

                    //Insert the Table Data

                    for (int intJ = 0; intJ < gvCheckin.Items.Count; intJ++)
                    {
                        for (int intK = 0; intK < gvCheckin.Columns.Count - 1; intK++)
                        {
                            PdfPCell cell = new PdfPCell();
                            cell.BorderWidth = 0.001f;
                            cell.BorderColor = new Color(100, 100, 100);
                            cell.BackgroundColor = new Color(250, 250, 250);

                            string celllvalue = gvCheckin.Items[intJ].Cells[intK+3].Text.ToString();

                            if (gvCheckin.Items[intJ].Cells[intK + 3].Text.ToString() != "" && gvCheckin.Items[intJ].Cells[intK + 3].Text.ToString() != "&nbsp;")
                            {
                                cell.Phrase = new Phrase(gvCheckin.Items[intJ].Cells[intK + 3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                ptData.AddCell(cell);
                            }
                            else
                            {
                                cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                                ptData.AddCell(cell);
                            }

                        }
                    }
                    //foreach(GridDataItem item in gvCheckin.Items)
                    //{
                    //    string value1 = item["checkin_time"].Text.Trim();
                       
                    //    string value2 = item["NRICno"].Text.Trim();
                    //    string value3 = item["user_name"].Text.Trim();
                    //    string value4 = item["pass_no"].Text.Trim();
                    //    string value5 = item["key_no"].Text.Trim();
                    //    PdfPCell cell = new PdfPCell();
                    //    cell.BorderWidth = 0.001f;
                    //    cell.BorderColor = new Color(100, 100, 100);
                    //    cell.BackgroundColor = new Color(250, 250, 250);
                    //    cell.Phrase = new Phrase(value1.Replace("&nbsp;","_").Replace(" ","_").Replace(" ","_"), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                    //    ptData.AddCell(cell);
                    //    cell = new PdfPCell();
                    //    cell.Phrase = new Phrase(value2.Replace("&nbsp;","_").Replace(" ","_").Replace(" ","_"), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                    //    ptData.AddCell(cell);
                    //    cell = new PdfPCell();
                    //    cell.Phrase = new Phrase(value3.Replace("&nbsp;","_").Replace(" ","_").Replace(" ","_"), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                    //    ptData.AddCell(cell);
                    //    cell = new PdfPCell();
                    //    cell.Phrase = new Phrase(value4.Replace("&nbsp;","_").Replace(" ","_").Replace(" ","_"), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                    //    ptData.AddCell(cell);
                    //    cell = new PdfPCell();
                    //    cell.Phrase = new Phrase(value5.Replace("&nbsp;","_").Replace(" ","_").Replace(" ","_"), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                    //    ptData.AddCell(cell);
                    //}
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
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            //try
            //{
            //    Document pdfReport = new Document(PageSize.A4, 100, 91, 100, 93);
            //    System.IO.MemoryStream msReport = new System.IO.MemoryStream();
            //    PdfWriter writer = PdfWriter.GetInstance(pdfReport, msReport);
            //    pdfReport.Open();
            //    DBConnectionHandler1 db = new DBConnectionHandler1();
            //    SqlConnection cn = db.getconnection();
            //    cn.Open();
            //    SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        if (dr.GetString(1).ToString() != "")
            //        {
            //            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(@dr.GetString(1).ToString().Trim());
            //            image1.SetAbsolutePosition(70, 100);
            //            PdfContentByte by = writer.DirectContent;
            //            PdfTemplate tp = by.CreateTemplate(170, 190);
            //            tp.AddImage(image1);
            //            by.AddTemplate(tp, 175, 660);
            //            cn.Close();
            //            dr.Close();

            //        }
            //    }

            //    string datetime = string.Empty;
            //    datetime = Convert.ToString(System.DateTime.Now);

            //    string str = string.Empty;

            //    if (txtnricno.Text != "")
            //        str = ("   NRIC/FIN No. : " + txtnricno.Text);
            //    if (txtname.Text != "")
            //        str = ("   Name : " + txtname.Text);
            //    if (txtpasstype.Text != "")
            //        str = ("   Pass No. : " + txtpasstype.Text);
            //    if (txtkeyno.Text != "")
            //        str = ("   Key No. : " + txtkeyno.Text);
            //    if (txtdatefrom.Text != "" && txtdateto.Text != "")
            //        str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


            //    //Create Heading
            //    //Phrase headerPhrase = new Phrase("Attendance Report                                                       ", FontFactory.GetFont("Garamond", 14));

            //    //headerPhrase.Add("                                                     Generated On : ");
            //    Phrase headerPhrase = new Phrase("                                     Attendance Report                                                       ", FontFactory.GetFont("Garamond", 14));

            //    headerPhrase.Add("        Generated On : ");
            //    headerPhrase.Add(datetime);
            //    //headerPhrase.Add("                                                                           Searching Parameter  : ");
            //    headerPhrase.Add(str);

            //    //Create Heading
            //    // Phrase headerPhrase = new Phrase("Contractor Report", FontFactory.GetFont("TIMES_ROMAN", 16));
            //    HeaderFooter header = new HeaderFooter(headerPhrase, false);
            //    header.Border = Rectangle.NO_BORDER;
            //    header.Alignment = Element.ALIGN_CENTER;
            //    header.Alignment = Element.ALIGN_BOTTOM;
            //    pdfReport.Header = header;
            //    pdfReport.Add(headerPhrase);

            //    // Creates the Table
            //    PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count);
            //    ptData.SpacingBefore = 8;
            //    ptData.DefaultCell.Padding = 1;
            //    float[] headerwidths = new float[gvItemTable.Columns.Count]; // percentage

            //    headerwidths[0] = 4.2F;
            //    headerwidths[1] = 4.5F;
            //    headerwidths[2] = 4.5F;
            //    headerwidths[3] = 3.2F;
            //    headerwidths[4] = 3.2F;

            //    ptData.SetWidths(headerwidths);
            //    ptData.WidthPercentage = 100;
            //    ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            //    ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            //    //Insert the Table Headers
            //    for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
            //    {
            //        PdfPCell cell = new PdfPCell();
            //        cell.BorderWidth = 0.001f;
            //        cell.BackgroundColor = new Color(200, 200, 200);
            //        cell.BorderColor = new Color(100, 100, 100);
            //        cell.Phrase = new Phrase(gvItemTable.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
            //        ptData.AddCell(cell);
            //    }

            //    ptData.HeaderRows = 1;  // this is the end of the table header

            //    //Insert the Table Data

            //    for (int intJ = 0; intJ < gvItemTable.Rows.Count; intJ++)
            //    {
            //        for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
            //        {
            //            PdfPCell cell = new PdfPCell();
            //            cell.BorderWidth = 0.001f;
            //            cell.BorderColor = new Color(100, 100, 100);
            //            cell.BackgroundColor = new Color(250, 250, 250);
            //            if (gvItemTable.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
            //            {
            //                cell.Phrase = new Phrase(gvItemTable.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
            //            }
            //            else
            //            {
            //                cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
            //            }
            //            ptData.AddCell(cell);
            //        }
            //    }

            //    //Insert the Table
            //    pdfReport.Add(ptData);

            //    //Closes the Report and writes to Memory Stream
            //    pdfReport.Close();

            //    //Writes the Memory Stream Data to Response Object
            //    Response.Clear();
            //    // Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoPdfFile"]));
            //    Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.pdf"));
            //    Response.Charset = "";
            //    Response.ContentType = "application/pdf";
            //    Response.BinaryWrite(msReport.ToArray());
            //    Response.End();
            //}
            //catch (Exception ex)
            //{
            //    logger.Info(ex.Message);
            //}
        }

        public void DownloadWordFormat()
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


                Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.doc"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string filePath = "";
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

                sw.Write("<CAPTION><b><font size='+2'>Attendance Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On : </font>");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>"+str+"</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<table border =1>");


                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvItemTable.Columns[i].HeaderText.ToString();

                    if (strHeaderText != "")
                    {
                        sw.Write("<th>");
                        sw.Write(strHeaderText);
                        sw.Write("</th>");
                    }
                
                }
                sw.Write("</tr>");

                foreach (GridDataItem grvRow in gvItemTable.MasterTableView.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        strContent = grvRow.Cells[i+2].Text.ToString();
                        if (strContent != "")
                        {
                            sw.Write("<td>");
                            sw.Write(strContent);
                            sw.Write("</td>");
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

        public void DownloadWordFormat2()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvCheckin.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                 string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.doc"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                DBConnectionHandler1 db = new DBConnectionHandler1();
                SqlConnection cn = db.getconnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from UploadLogo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string filePath = "";
                if (dr.Read())
                {
                    if (dr.GetString(1).ToString() != "")
                    {
                        filePath = dr.GetString(1).ToString().Trim();
                        cn.Close();
                        dr.Close();

                    }
                }
               // string filePath1 = Server.MapPath(@dr.GetString(1).ToString().Trim());
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(@filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
               
                sw.Write("<b><hr></hr></b>");

                sw.Write("<CAPTION><b><font size='+2'>Attendance Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On : </font>");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>"+str+"</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<table border =1>");



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    

                        strHeaderText = gvCheckin.Columns[i].HeaderText.ToString();
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

             

                foreach (GridDataItem grvRow in gvCheckin.MasterTableView.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        
                            strContent = grvRow.Cells[i+2].Text.ToString();
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

        //public void DownloadCsvFormat()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Response.ClearHeaders();
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", string.Format("attachment;filename=testcsv.csv"));
        //        Response.Charset = "";
        //        Response.ContentType = "application/Text";
        //        TextWriter sw = new StringWriter();
        //        int iColCount = gvItemTable.Columns.Count;

        //        for (int i = 0; i < iColCount - 1; i++)
        //        {
        //            sw.Write(gvItemTable.Columns[i]);
        //            if (i < iColCount - 1)
        //            {
        //                sw.Write(",");
        //            }
        //        }

        //        sw.Write(sw.NewLine);
        //        // Write all the rows.
        //        foreach (GridViewRow grv in gvItemTable.Rows)
        //        {
        //            for (int i = 0; i < iColCount - 1; i++)
        //            {
        //                if (!Convert.IsDBNull(grv.Cells[i]))
        //                {
        //                    if (grv.Cells[i].Text.ToString() != "&nbsp;")
        //                    {
        //                        sw.Write(grv.Cells[i].Text.ToString());
        //                    }
        //                    else
        //                    {
        //                        sw.Write("");
        //                    }
        //                }
        //                if (i < iColCount - 1)
        //                {
        //                    sw.Write(",");
        //                }

        //            }
        //            sw.Write(sw.NewLine);
        //        }
        //        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //        Response.Write(sw.ToString());
        //        Response.End();
        //        sw.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        //public void DownloadHtmlFormat()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {

        //        Int32 intcellCount = gvItemTable.Columns.Count;
        //        string strContent = "";
        //        string strHeaderText = "";
        //        string strHtmlFile = "TxnHtmlFile";
        //        Response.ClearHeaders();
        //        Response.ClearContent();
        //        //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
        //        Response.AddHeader("content-disposition", string.Format("attachment;filename=Attendance.html"));
        //        Response.Charset = "";
        //        Response.ContentType = "text/html";
        //        StringWriter sw = new StringWriter();
        //        sw.Write("<table border =1>");
        //        sw.Write("<CAPTION><b><font size='+2'>Attendance Report</font></b></CAPTION>");
        //        sw.Write("<CAPTION><br/></CAPTION>");
        //        sw.Write("<CAPTION><br/></CAPTION>");
        //        sw.Write("<CAPTION><br/></CAPTION>");
        //        sw.Write("<tr>");
        //        for (int i = 0; i < intcellCount - 1; i++)
        //        {
        //            strHeaderText = gvItemTable.Columns[i].HeaderText.ToString();
        //            sw.Write("<th>");
        //            sw.Write(strHeaderText);
        //            sw.Write("</th>");
        //            sw.Write("<td>");
        //            sw.Write("&nbsp");
        //            sw.Write("</td>");

        //        }
        //        sw.Write("</tr>");

        //        foreach (GridViewRow grvRow in gvItemTable.Rows)
        //        {
        //            sw.Write("<tr>");
        //            for (Int32 i = 0; i < intcellCount - 1; i++)
        //            {
        //                strContent = grvRow.Cells[i].Text.ToString();
        //                sw.Write("<td>");
        //                sw.Write(strContent);
        //                sw.Write("</td>");
        //                sw.Write("<td>");
        //                sw.Write("&nbsp");
        //                sw.Write("</td>");
        //            }
        //            sw.Write("</tr>");
        //        }
        //        sw.Write("</table>");

        //        Response.Write(sw.ToString());
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}





        //public void DownloadCsvFormat2()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Response.ClearHeaders();
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.csv"));
        //        Response.Charset = "";
        //        Response.ContentType = "application/Text";
        //        TextWriter sw = new StringWriter();
        //        int iColCount = gvCheckin.Columns.Count;

        //        for (int i = 0; i < iColCount; i++)
        //        {
        //            sw.Write(gvCheckin.Columns[i]);
        //            if (i < iColCount - 1)
        //            {
        //                sw.Write(",");
        //            }
        //        }

        //        sw.Write(sw.NewLine);
        //        // Write all the rows.
        //        foreach (GridViewRow grv in gvCheckin.Rows)
        //        {
        //            for (int i = 0; i < iColCount - 1; i++)
        //            {
        //                if (!Convert.IsDBNull(grv.Cells[i]))
        //                {
        //                    if (grv.Cells[i].Text.ToString() != "&nbsp;")
        //                    {
        //                        sw.Write(grv.Cells[i].Text.ToString());
        //                    }
        //                    else
        //                    {
        //                        sw.Write("");
        //                    }
        //                }
        //                if (i < iColCount - 1)
        //                {
        //                    sw.Write(",");
        //                }

        //            }
        //            sw.Write(sw.NewLine);
        //        }
        //        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //        Response.Write(sw.ToString());
        //        Response.End();
        //        sw.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        //public void DownloadHtmlFormat2()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Int32 intcellCount = gvCheckin.Columns.Count;
        //        string strContent = "";
        //        string strHeaderText = "";
        //        string strHtmlFile = "TxnHtmlFile";
        //        Response.ClearHeaders();
        //        Response.ClearContent();
        //        //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
        //        Response.AddHeader("content-disposition", string.Format("attachment;filename=AttendanceReport.html"));
        //        Response.Charset = "";
        //        Response.ContentType = "text/html";
        //        StringWriter sw = new StringWriter();
        //        sw.Write("<table border =1>");
        //        sw.Write("<CAPTION><b><font size='+2'>Attendance Report</font></b></CAPTION>");
        //        sw.Write("<tr>");
        //        for (int i = 0; i < intcellCount - 1; i++)
        //        {
        //            strHeaderText = gvCheckin.Columns[i].HeaderText.ToString();
        //            sw.Write("<th>");
        //            sw.Write(strHeaderText);
        //            sw.Write("</th>");
        //            sw.Write("<td>");
        //            sw.Write("&nbsp");
        //            sw.Write("</td>");

        //        }
        //        sw.Write("</tr>");

        //        foreach (GridViewRow grvRow in gvCheckin.Rows)
        //        {
        //            sw.Write("<tr>");
        //            for (Int32 i = 0; i < intcellCount - 1; i++)
        //            {
        //                strContent = grvRow.Cells[i].Text.ToString();
        //                sw.Write("<td>");
        //                sw.Write(strContent);
        //                sw.Write("</td>");
        //                sw.Write("<td>");
        //                sw.Write("&nbsp");
        //                sw.Write("</td>");
        //            }
        //            sw.Write("</tr>");
        //        }
        //        sw.Write("</table>");

        //        Response.Write(sw.ToString());
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {
        }

        #region View Checkin

        private void PopulatePageCntrlsCheckin(Int64 argsBGID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select Checkin_DateTime,Locationid,Pass_No,key_no,NRICno,user_name From checkin_manager Where checkin_id='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtChkIn.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtlocation.Text = GetLocationNameById(dsget.Tables[0].Rows[0][1].ToString().Trim());
                    txtPassNo.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtKeyNo.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txtNRIC.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtName.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private String GetLocationNameById(string id)
        {
            string name = string.Empty;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", id);
            DataTable dsLocationid = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationid.Rows.Count > 0)
            {
                name = dsLocationid.Rows[0][0].ToString().Trim();
                return name;
            }
            return name;
        }

        protected void btnCheckinprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCheckinCancel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupCheckinView.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #endregion

        #region View CheckOut

        private void PopulatePageCntrls(Int64 argsBGID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select DATEDIFF(hh,checkin_time,checkout_time) as TotalHours, checkin_time,checkout_time,Locationid,pass_no,key_no,user_id,user_name,NRICno From checkout_manager Where checkout_id='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    chkoutlblTime.Text = dsget.Tables[0].Rows[0]["checkin_time"].ToString().Trim();
                    txtChkOut.Text = dsget.Tables[0].Rows[0]["checkout_time"].ToString().Trim();
                    lblTotalHours.Text = dsget.Tables[0].Rows[0]["TotalHours"].ToString().Trim();
                    chkoutlblNRIC.Text = dsget.Tables[0].Rows[0]["NRICno"].ToString().Trim();
                    chkoutlblName.Text = dsget.Tables[0].Rows[0]["user_name"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCheckOutPrint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview1;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
            
        protected void btnCheckOutCancel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupCheckOutView.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        

        #endregion

        # region Grid Selected Row Function

        protected void ToggleRowSelectionCheckin(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvCheckin.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvCheckin.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvCheckin.Items[ro].Selected = true;


                        ViewState["checkin_id"] = item.OwnerTableView.DataKeyValues[ro]["checkin_id"];
                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        protected void ToggleRowSelectionCheckOut(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvItemTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvItemTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvItemTable.Items[ro].Selected = true;


                        ViewState["checkout_id"] = item.OwnerTableView.DataKeyValues[ro]["checkout_id"];

                       
                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        #endregion

        #region Icon button

        protected void ImgView_Click(object sender, EventArgs e)
        {
            if (ViewState["checkin_id"] != null)
            {
                PopulatePageCntrlsCheckin(Convert.ToInt64(ViewState["checkin_id"]));
                this.ModalPopupCheckinView.Show();
                Session["ctrl"] = printview;
            }
            else if (ViewState["checkout_id"] != null)
            {
                Int64 xx = Convert.ToInt64(ViewState["checkout_id"]);

                PopulatePageCntrls(xx);
                ModalPopupCheckOutView.Show();
                Session["ctrl"] = printview1;
            }
            else
            {
            }
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["checkout_id"] != null)
            {
                this.ModalPopupDelete.Show();
            }
        }

        #endregion Icon button

        #region Delete Button Code

        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string CheckOut_ID = ViewState["checkout_id"].ToString();

                DeleteItem(CheckOut_ID);
                ModalPopupDelete.Hide();


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupDelete.Hide();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        }
    
}