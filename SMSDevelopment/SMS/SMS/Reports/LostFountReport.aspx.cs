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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using System.Globalization;
namespace SMS.SMSUsers.Reports
{
    public partial class LostFountReport : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        int i = 0;
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //txtitemno.Focus();
                if (!IsPostBack)
                {
                   
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvItemTable1".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    if (Request.QueryString["curr"] != null)
                                    {
                                        txtdatefrom.Visible = false;
                                        txtdateto.Visible = false;
                                        lbldatefrom.Visible = false;
                                        imgBtnFromDate2.Visible = false;
                                        lbldateto.Visible = false;
                                        imgBtnFromDate3.Visible = false;

                                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                                        {
                                            getLocationName();
                                        }
                                        else
                                        {
                                            getLocationNameById(Session["LCID"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                                        {
                                            getLocationName();
                                        }
                                        else
                                        {
                                            getLocationNameById(Session["LCID"].ToString());
                                        }
                                    }
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
                    if (Request.QueryString["curr"] != null)
                    {
                        txtdatefrom.Visible = false;
                        txtdateto.Visible = false;
                        lbldatefrom.Visible = false;
                        imgBtnFromDate2.Visible = false;
                        lbldateto.Visible = false;
                        imgBtnFromDate3.Visible = false;

                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                        {
                            getLocationName();
                        }
                        else
                        {
                            getLocationNameById(Session["LCID"].ToString());
                        }
                    }
                    else
                    {
                        if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                        {
                            getLocationName();
                        }
                        else
                        {
                            getLocationNameById(Session["LCID"].ToString());
                        }
                    }
                    BindGridWithFilter();
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




        private void DeleteItem(string argKeyID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Delete from LostFoundItem Where Lost_ID ='" + argKeyID + "' ");

               // Server.Transfer("~/ADMIN/CompleteForm.aspx");
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
                if (str == "Word")
                    Downloadwordformat();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnEmail1_Click(object sender, EventArgs e)
        {

        }

        protected void btnprint1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = panel1;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchLocID.Text = ddllocation.Text;
        }

        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetLostFoundData objReq = new GetLostFoundData();
                //getLocationIDByName(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(ddllocation.Text.Trim()))
                {
                    objReq.Location = ddllocation.Text;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    objReq.Date = txtdatefrom.Text;
                }

                if (!string.IsNullOrEmpty(ddlStatus.Text))
                {
                    objReq.LostStatus = ddlStatus.Text;
                }

                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }
                LostFoundData ret = ws.GetLostFoundData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //gvItemTable.PageSize = pageSize;
                //gvItemTable.DataSource = ret.LostId;
                //gvItemTable.DataBind();
                gvItemTable1.PageSize = pageSize;
                gvItemTable1.DataSource = ret.LostId;
                gvItemTable1.DataBind();

            }//try End 
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }//method end


        private string ReturnWhere()
        {
            string str = string.Empty;
            string makeWhereClause = string.Empty;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                List<String> arr = new List<String>();
                arr.Add("test");


                if (ddllocation.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Location ='" + SearchLocID.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Location ='" + SearchLocID.Text + "'";
                    }
                }
                if (ddlStatus.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where LostStatus ='" + ddlStatus.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and LostStatus ='" + ddlStatus.Text + "'";
                    }
                }

                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Date BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date='" + txtdatefrom.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and Date='" + txtdatefrom.Text + "'";
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
                GetItemData _req = new GetItemData();
                GetItemDataResponse _resp = ws.GetItemData(_req);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Item;
                //if (_resp.Item.Count == 0)
                //{
                //    item1.Visible = false;
                //    item2.Visible = false;
                //}
                gvItemTable.DataBind();
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
                BindGridWithFilter();
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

                if (ddlStatus.Text != "")
                    str = ("   LostStatus : " + ddlStatus.Text);
                if (ddllocation.Text != "")
                    str = ("    Location : " + ddllocation.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                Phrase headerPhrase = new Phrase("                                     LostFound Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("      Generated On : ");
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
                PdfPTable ptData = new PdfPTable(gvItemTable1.Columns.Count - 1);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;
                float[] headerwidths = new float[gvItemTable1.Columns.Count - 1]; // percentage

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
                for (int intK = 0; intK < gvItemTable1.Columns.Count - 1; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    if (gvItemTable1.Columns[intK + 1].HeaderText.ToString() != "")
                    {
                        cell.Phrase = new Phrase(gvItemTable1.Columns[intK + 1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                        ptData.AddCell(cell);
                    }
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvItemTable1.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvItemTable1.Columns.Count - 1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvItemTable1.Items[intJ].Cells[intK + 3].Text.ToString() != "" && gvItemTable1.Items[intJ].Cells[intK + 3].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvItemTable1.Items[intJ].Cells[intK + 3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=LostfoundReport.pdf"));
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
        public void Downloadwordformat()
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvItemTable1.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();



                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (ddlStatus.Text != "")
                    str = ("   LostStatus : " + ddlStatus.Text);
                if (ddllocation.Text != "")
                    str = ("    Location : " + ddllocation.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


                Response.AddHeader("content-disposition", string.Format("attachment;filename=LostFound.doc"));
                Response.Charset = "";
                Response.ContentType = "text/doc";
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
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(@filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{1}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");

                sw.Write("<CAPTION><b><font size='+2'>LostFound Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On :</font> ");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>" + str + "</font>");
                //Phrase headerPhrase = new Phrase("Incident Report                                                       ", FontFactory.GetFont("Garamond", 14));

                //headerPhrase.Add("                                                     Generated On : ");
                //headerPhrase.Add(datetime);
                //headerPhrase.Add("                                                                           Searching Parameter  : ");
                //headerPhrase.Add(str);
                sw.Write("<CAPTION><br/><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<table border =1>");




                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvItemTable1.Columns[i].HeaderText.ToString();
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

                foreach (GridDataItem grvRow in gvItemTable1.Items)
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


                if (ddlStatus.Text != "")
                    str = ("   LostStatus  : " + ddlStatus.Text);
                if (ddllocation.Text != "")
                    str = ("    Location : " + ddllocation.Text);
                //if (txtfoundby.Text != "")
                //    str = ("   LostStatus : " + txtfoundby.Text);


                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                Response.AddHeader("content-disposition", string.Format("attachment;filename=testhtml.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                string filePath = Server.MapPath("../../Images/Untitled.png");
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");

                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b><font size='+2'>LostFound Report</font></b></CAPTION>");


                sw.Write("<font size='+1'>Generated On :</font> ");
                sw.Write("<font size='+1'>"+datetime+"</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                ////sw.Write("Searching Parameter : ");
                ////sw.Write(str);





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
                if (e.NewPageIndex >= 0)
                {
                    gvItemTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilter();
                    AdminBLL ws = new AdminBLL();
                    GetItemData _req = new GetItemData();
                    GetItemDataResponse _resp = ws.GetItemData(_req);
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp.Item;
                    gvItemTable.DataBind();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvItemTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("View LostFound.aspx");
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvItemTable_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            getLocationName();

        }

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #region View
        protected void ImgView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Lost_ID"] != null)
                {
                    //view
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
                            dr.Close();
                            cn.Close();
                        }
                    }
                    //---------------------------=---------------------------
                    String iBTID = string.Empty;
                    if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                    {
                        iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                    }
                    PopulatePageCntrls(ViewState["Lost_ID"].ToString());
                    // Fill();
                    this.ModalPopupUpdate.Show();
                    Session["ctrl"] = printview;
                }
            }
            catch (Exception ex)
            {
                logger.Info("LostFoundReport(ImgView_Click):" + ex.Message);
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select Name,Location,Description,ContNo,NRICno,Date,Time,NameOfReporting,LostStatus From LostFoundItem  Where Lost_ID='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {

                    txtName1.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtLocation.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtIdescription.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtConNo.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();

                    txtNRIC.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtDate.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtTime.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();

                    txtNameOfReporting.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();
                    txtStatus.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
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
        protected void BtnCancelPrint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupUpdate.Hide();
                // ClearUpdate();
            }
            catch (Exception ex)
            {
                logger.Info("LostFoundReport(BtnCancelPrint_Click):" + ex.Message);
            }
        }

        #endregion
        #region delete
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Lost_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("LostFoundReport(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Lost_ID"] != null)
                {
                    DeleteItem(ViewState["Lost_ID"].ToString());
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Delete SuccessFully');", true);
                    BindGridWithFilter();
                    ViewState["Lost_ID"] = null;
                    ModalPopupDelete.Hide();
                    
                }
            }
            catch (Exception ex)
            {
                logger.Info("LostFoundReport(Deletepopup_Yes_Click):" + ex.Message);
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
                logger.Info("LostFoundReport(btnCancelDelete_Click):" + ex.Message);
            }
        }


        #endregion
        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvItemTable1.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvItemTable1.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        gvItemTable1.Items[ro].Selected = true;
                        ViewState["Lost_ID"] = item.OwnerTableView.DataKeyValues[ro]["Lost_ID"];
                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }
            }
        }

        
    }
}