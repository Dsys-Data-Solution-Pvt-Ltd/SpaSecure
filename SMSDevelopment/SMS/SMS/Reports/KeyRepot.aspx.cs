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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
namespace SMS.Reports
{
    public partial class KeyRepot : System.Web.UI.Page
    {
        SqlConnection cn;
        AdminDAL a = new AdminDAL();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                 txtkeyno1.Focus();
               
                    if (!IsPostBack)
                    {
                        BindGridWithFilter();
                    }
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
              
              if (e.Row.Cells[2].Text == "Free")
                {
                   // e.Row.Cells[2].ForeColor = Color.RED;
                
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

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);                  
                    Server.Transfer("../SMSAdmin/KeyDataUpdate.aspx");

                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }
            }

            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        private void DeleteItem(string argkeyId)
        { 
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
             if (!string.IsNullOrEmpty(argkeyId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteKeyRequest _req = new DeleteKeyRequest();

                    _req.KeyNo = argkeyId.ToString();

                    ws.DeleteKey(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("../smsadmin/AlertUpdateComplete.aspx");
                }
           
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
                    gvKeySearch.PageIndex = e.NewPageIndex;
                    AdminBLL ws = new AdminBLL();
                    GetNewKey _req = new GetNewKey();
                    GetNewKeyRequest _resp = ws.GetNewKey(_req);

                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvKeySearch.PageSize = pageSize;
                    gvKeySearch.DataSource = _resp.Key;

                    gvKeySearch.DataBind();
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
                GetNewKey objReq = new GetNewKey();
              
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(txtkeyno1.Text))
                {
                    objReq.key_no = txtkeyno1.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyName.Text))
                {
                    objReq.name = txtKeyName.Text;
                }
                if (!string.IsNullOrEmpty(ddlstatus.Text))
                {
                    objReq.status = ddlstatus.Text;
                }
                if (!string.IsNullOrEmpty(txtKeyName.Text))
                {
                    objReq.name = txtKeyName.Text;
                }
               
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }

                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }


                GetNewKeyRequest ret = ws.GetNewKey(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = ret.Key;
                if (ret.Key.Count == 0)
                {                  
                    key2.Visible = false;
                }
                gvKeySearch.DataBind();
                key2.Text = ret.Key.Count.ToString();

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

                if (txtkeyno1.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where Key_no='" + txtkeyno1.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Key_no='" + txtkeyno1.Text + "'";
                    }
                }
                if (txtKeyName.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where name='" + txtKeyName.Text + "'";
                        arr.Add("3");

                    }
                    else
                    {
                        str += " and name='" + txtKeyName.Text + "'";
                    }
                }
                if (ddlstatus.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where status='" + ddlstatus.Text + "'";
                        arr.Add("3");

                    }
                    else
                    {
                        str += " and status='" + ddlstatus.Text + "'";
                    }
                }

               


                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and Date_From BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }

                }

                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From='" + txtdatefrom.Text + "'";
                        arr.Add("7");
                    }
                    else
                    {
                        str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                }

               
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetNewKey _req = new GetNewKey();
                GetNewKeyRequest _resp = ws.GetNewKey(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvKeySearch.PageSize = pageSize;
                gvKeySearch.DataSource = _resp.Key;
                if (_resp.Key.Count == 0)
                {
                    key1.Visible = false;
                    key2.Visible = false;
                }
                gvKeySearch.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvNewKey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                BindGridWithFilter();
            }
            catch (System.Threading.ThreadAbortException)
            {
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

                if (txtkeyno1.Text != "")
                    str = ("   Key No. : " + txtkeyno1.Text);
                if (txtKeyName.Text != "")
                    str = ("    Name : " + txtKeyName.Text);
               

                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From : " + txtdatefrom.Text + "      To :" + txtdateto.Text);



                Phrase headerPhrase = new Phrase("Key Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("                                                     Generated On : ");
                headerPhrase.Add(datetime);
                headerPhrase.Add("                                                                           Searching Parameter  : ");
                headerPhrase.Add(str);


                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);


                // Creates the Table
                PdfPTable ptData = new PdfPTable(gvKeySearch.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvKeySearch.Columns.Count]; // percentage


                headerwidths[0] = 3.2F;
                headerwidths[1] = 3.2F;
                headerwidths[2] = 3.2F;
                headerwidths[3] = 3.2F;
                headerwidths[4] = 3.2F;
                headerwidths[5] = 3.2F;
                headerwidths[6] = 3.2F;
                headerwidths[7] = 3.2F;
                headerwidths[8] = 4.5F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvKeySearch.Columns.Count; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase(gvKeySearch.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvKeySearch.Rows.Count; intJ++)
                {
                    for (int intK = 0; intK < gvKeySearch.Columns.Count; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvKeySearch.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvKeySearch.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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
             
                Response.AddHeader("content-disposition", string.Format("attachment;filename=testpfd.pdf"));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=testcsv.csv"));
                Response.Charset = "";
                Response.ContentType = "application/Text";
                TextWriter sw = new StringWriter();
                int iColCount = gvKeySearch.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(gvKeySearch.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");

                    }
                }

                sw.Write(sw.NewLine);
                // Write all the rows.
                foreach (GridViewRow grv in gvKeySearch.Rows)
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
                Int32 intcellCount = gvKeySearch.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();


                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (txtkeyno1.Text != "")
                    str = ("   Key No. : " + txtkeyno1.Text);
                if (txtKeyName.Text != "")
                    str = ("    Name : " + txtKeyName.Text);


                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From : " + txtdatefrom.Text + "      To :" + txtdateto.Text);



          
                Response.AddHeader("content-disposition", string.Format("attachment;filename=testhtml.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>Key Report</b></CAPTION>");

                sw.Write("Generated On : ");
                sw.Write(datetime);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("Searching Parameter : ");
                sw.Write(str);



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvKeySearch.Columns[i].HeaderText.ToString();
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    sw.Write("<td>");
                    sw.Write("&nbsp");
                    sw.Write("</td>");

                }
                sw.Write("</tr>");

                foreach (GridViewRow grvRow in gvKeySearch.Rows)
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

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtkeyno1.Text = "";
            txtKeyName.Text = "";
            ddlstatus.Text = "";
          
            txtdatefrom.Text = "";
            txtdateto.Text = "";
        }

    }
}
