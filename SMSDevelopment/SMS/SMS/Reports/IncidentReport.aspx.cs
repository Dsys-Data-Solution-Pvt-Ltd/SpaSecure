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

namespace SMS.Reports
{
    public partial class IncidentReport : System.Web.UI.Page
    {       
        AdminDAL a = new AdminDAL();     
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
            }
            
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        # region Grid Selected Row Function

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


                        ViewState["Incident_id"] = item.OwnerTableView.DataKeyValues[ro]["Incident_id"];

                       
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
            if (ViewState["Incident_id"] != null)
            {
                PopulatePageCntrlsIncident(Convert.ToInt32(ViewState["Incident_id"]));
                this.ModalPopupIncidentView.Show();
                Session["ctrl"] = printview;
            }
         
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["Incident_id"] != null)
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
                int Incident_id =Convert.ToInt32(ViewState["Incident_id"].ToString());

                DeleteItem(Incident_id);
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

        #region View Incident

         private void PopulatePageCntrlsIncident(int argsBGID)
        {
            Int32 iCount = 0;
            GetIncidentDataResponse ret = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DateTime dt;
                AdminBLL objAdminBLL = new AdminBLL();
                GetIncidentData objGetBillingTableRequest = new GetIncidentData();
                objGetBillingTableRequest.Report_No = argsBGID.ToString();

                objGetBillingTableRequest.WhereClause = "and Incident_id='" + argsBGID.ToString() + "'";

                ret = objAdminBLL.GetIncidentData(objGetBillingTableRequest);

                dt = Convert.ToDateTime(ret.Incident[iCount].Date_of_Incident);

                txtdate.Text = dt.ToShortDateString().ToString();
                txttime.Text = ret.Incident[iCount].Time_of_Incident.ToString();
                txtReportno.Text = ret.Incident[iCount].Report_No.ToString();
                txtreportedby.Text = ret.Incident[iCount].Received_By.ToString();               
                txtsite.Text = ret.Incident[iCount].Place_of_Incident.ToString();               
                txtstatement.Text = ret.Incident[iCount].ReportDetail.ToString();
                txtfollownric.Text = ret.Incident[iCount].follownric.ToString();
                txtfollowinvestigate.Text = ret.Incident[iCount].followinvesti.ToString();
                txtfollowverify.Text = ret.Incident[iCount].followverify.ToString();
                txtfollowreport.Text = ret.Incident[iCount].followsremark.ToString();
                txtfollowstatus.Text = ret.Incident[iCount].followstatus.ToString();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

         protected void btnIncidentprint_Click(object sender, EventArgs e)
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

         protected void btnIncidentCancel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupIncidentView.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

     #endregion


        private void DeleteItem(int argincidentId)
        {
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {

            AdminBLL ws = new AdminBLL();
            DeleteIncidentRequest _req = new DeleteIncidentRequest();

            _req.IncidentNo = argincidentId.ToString();

            ws.DeleteIncident(_req);
            BindGridWithFilter();

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
                GetIncidentData objReq = new GetIncidentData();
     
                GetIncidentDataResponse ret = ws.GetIncidentData(objReq);

                gvItemTable.DataSource = ret.Incident;               
                gvItemTable.DataBind();               

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

                GetIncidentData _req = new GetIncidentData();
                GetIncidentDataResponse _resp = ws.GetIncidentData(_req);
               
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Incident;                
                gvItemTable.DataBind();
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
                //getLocationIDByName(ddllocation.Text.Trim());
                BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }     

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click1(object sender, EventArgs e)
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
            //if (str == "Excel")
            //    DownloadCsvFormat();
            if (str == "Pdf")
                DownloadPDFFormat();
            //if (str == "Html")
            //    DownloadHtmlFormat();
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

            string str = string.Empty;

            Phrase headerPhrase = new Phrase("                                     Incident Report                                                       ", FontFactory.GetFont("Garamond", 14));

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
            PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count-1);
            ptData.SpacingBefore = 8;
            ptData.DefaultCell.Padding = 1;

            float[] headerwidths = new float[gvItemTable.Columns.Count-1]; // percentage


            headerwidths[0] = 3.2F;
            headerwidths[1] = 3.2F;
            headerwidths[2] = 3.2F;
            headerwidths[3] = 3.2F;
            headerwidths[4] = 3.2F;
            headerwidths[5] = 3.2F;
           // headerwidths[6] = 3.2F;
            //headerwidths[6] = 3.2F;

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
                cell.Phrase = new Phrase(gvItemTable.Columns[intK+1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                ptData.AddCell(cell);
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

                    if (gvItemTable.Items[intJ].Cells[intK+3].Text.ToString() != "&nbsp;" && gvItemTable.Items[intJ].Cells[intK+3].Text.ToString() != " ")
                    {
                        cell.Phrase = new Phrase(gvItemTable.Items[intJ].Cells[intK+3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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

            Response.AddHeader("content-disposition", string.Format("attachment;filename=IncidentReport.pdf"));
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
                Int32 intcellCount = gvItemTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();



                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                Response.AddHeader("content-disposition", string.Format("attachment;filename=IncidentReport.doc"));
                Response.Charset = "";
                Response.ContentType = "text/doc";
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
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(@filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");
                sw.Write("<CAPTION><b><font size='+2'>Incident Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On :</font> ");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>"+str+"</font>");
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
                    { strContent = grvRow.Cells[i + 2].Text.ToString();
                    if (strContent != "")
                    {
                        strContent = grvRow.Cells[i +2].Text.ToString();
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

        //public void DownloadCsvFormat()
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //    Response.ClearHeaders();
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", string.Format("attachment;filename=testcsv.csv"));
        //    Response.Charset = "";
        //    Response.ContentType = "application/Text";
        //    TextWriter sw = new StringWriter();
        //    int iColCount = gvItemTable.Columns.Count;

        //    for (int i = 0; i < iColCount; i++)
        //    {
        //        sw.Write(gvItemTable.Columns[i]);
        //        if (i < iColCount - 1)
        //        {
        //            sw.Write(",");

        //        }
        //    }

        //    sw.Write(sw.NewLine);
        //    // Write all the rows.
        //    foreach (GridViewRow grv in gvItemTable.Rows)
        //    {
        //        for (int i = 0; i < iColCount; i++)
        //        {
        //            if (!Convert.IsDBNull(grv.Cells[i]))
        //            {
        //                if (grv.Cells[i].Text.ToString() != "&nbsp;")
        //                {
        //                    sw.Write(grv.Cells[i].Text.ToString());
        //                }
        //                else
        //                {
        //                    sw.Write("");
        //                }
        //            }
        //            if (i < iColCount - 1)
        //            {
        //                sw.Write(",");
        //            }

        //        }
        //        sw.Write(sw.NewLine);
        //    }
        //    System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //    Response.Write(sw.ToString());
        //    Response.End();
        //    sw.Close();
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
        //    Int32 intcellCount = gvItemTable.Columns.Count;
        //    string strContent = "";
        //    string strHeaderText = "";
        //    //string strHtmlFile = "TxnHtmlFile";
        //    Response.ClearHeaders();
        //    Response.ClearContent();



        //    string datetime = string.Empty;
        //    datetime = Convert.ToString(System.DateTime.Now);

        //    string str = string.Empty;

        //    Response.AddHeader("content-disposition", string.Format("attachment;filename=testhtml.html"));
        //    Response.Charset = "";
        //    Response.ContentType = "text/html";
        //    StringWriter sw = new StringWriter();
        //    string filePath = Server.MapPath("../../Images/Untitled.png");
        //    System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(filePath);
        //    string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
        //    Response.Write("<Center><table></Center>");
        //    Response.Write("<tr><td>" + imagepath + "</td></tr>");
        //    Response.Write("</table>");
        //    imgPhoto.Dispose();
        //    Response.Flush();
        //    sw.Write("<b><hr></hr></b>");
        //    sw.Write("<table border =1>");
        //    sw.Write("<CAPTION><b><font size='+2'>Incident Report</font></b></CAPTION>");
        //    sw.Write("<CAPTION><br/></CAPTION>");
        //    sw.Write("<font size='+1'>Generated On :</font> ");
        //    sw.Write("<font size='+1'>" + datetime + "</font>");
        //    sw.Write("<CAPTION><br/></CAPTION>");
        //    //sw.Write("<font size='+2'>Searching Parameter :</font> ");
        //    //sw.Write("<font size='+2'>" + str + "</font>");



        //    sw.Write("<tr>");
        //    for (int i = 0; i < intcellCount-1; i++)
        //    {
        //        strHeaderText = gvItemTable.Columns[i].HeaderText.ToString();
        //        sw.Write("<th>");
        //        sw.Write(strHeaderText);
        //        sw.Write("</th>");
        //        sw.Write("<td>");
        //        sw.Write("&nbsp");
        //        sw.Write("</td>");

        //    }
        //    sw.Write("</tr>");

        //    foreach (GridViewRow grvRow in gvItemTable.Rows)
        //    {
        //        sw.Write("<tr>");
        //        for (Int32 i = 0; i < intcellCount-1; i++)
        //        {
        //            strContent = grvRow.Cells[i].Text.ToString();
        //            sw.Write("<td>");
        //            sw.Write(strContent);
        //            sw.Write("</td>");
        //            sw.Write("<td>");
        //            sw.Write("&nbsp");
        //            sw.Write("</td>");
        //        }
        //        sw.Write("</tr>");
        //    }
        //    sw.Write("</table>");

        //    Response.Write(sw.ToString());
        //    Response.End();
        //   }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

    }
}
