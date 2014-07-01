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
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
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
using SMS.master;
namespace SMS.Reports
{
    public partial class DigitalDairyReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        string where = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               // fillgrid();
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
                    lblerror.Visible = false;
                   
                   
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgEdit") && !controlname.Contains("imgDelete") && !controlname.Contains("imglock256") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvItemTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    fillgrid();


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
                    fillgrid();

                }

            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
            }
        }
        private void getLocationIDByName(string Name)
        {

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
               // Searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
           // ddllocation.Items.Clear();
           /// ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                  //  ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        protected void BtnCancelView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
               // ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        private void fillgrid()
        {
            DataSet ds = dal.getdataset("Select convert(varchar,Dairy_date,101) as AddedTime,DDID,Dairy_date,time,Staff_id,Description,Color from Digital_Dairy where 1 = 1" + " and time between " + "'00:00:00'" + " and " + "'23:59:59'" + " Order by time Asc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                
               gvItemTable.DataSource = ds;
               gvItemTable.DataBind();
            }
            else
            {              
                gvItemTable.DataSource = null;
                gvItemTable.DataBind();
            }
        }

        public System.Drawing.Color GetColor(string Clr)
        {
            System.Drawing.Color cl = System.Drawing.ColorTranslator.FromHtml(Clr);
            return cl;
        }

        public string GetDescription(string Description)
        {
            return Description.Replace("\r\n", "<br />");
        }

       

        private void norecordgrid()
        {
            //if (txtdatefrom.Text.Trim() != "" || ddllocation.Text.Trim() != "")
            //{
            //    getLocationIDByName(ddllocation.Text.Trim());
            //    if (txtdatefrom.Text.Trim() != "")
            //    {
            //        where = " and Dairy_date = convert(datetime,'" + txtdatefrom.Text.Trim() + "',101) ";
            //    }
            //    if (Searchid.Text.Trim() != "")
            //    {
            //        where += " and LocationID= " + Searchid.Text + " ";
            //    }
            //    fillgrid(where);
            //}
            //else
            //{
            //    //gvItemTable.DataSource = null;
            //    //gvItemTable.DataBind();
            //    fillgrid(where);
            //}
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationName();
               // txtdatefrom.Text = "";
                //txtdatefrom0.Text = "";
                lblerror.Visible = false;
                gvItemTable.DataSource = null;
                gvItemTable.DataBind();
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
                //if (txtdatefrom.Text != "")
                //{
                //    str = ("Date" + txtdatefrom.Text + "");
                //}
                //if (ddllocation.Text.Trim() != "")
                //{
                //    str = (" Location" + ddllocation.Text + "");
                //}
                //Create Heading
                Phrase headerPhrase = new Phrase("                                     Digital Diary Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("      Generated On : ");
                headerPhrase.Add(datetime);
                //headerPhrase.Add("                                                                         Searching Parameter  : ");
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


                headerwidths[0] = 2.4F;
                headerwidths[1] = 2.4F;
                headerwidths[2] = 3.5F;
                headerwidths[3] = 4.7F;

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
                        if (gvItemTable.Items[intJ].Cells[intK + 3].Text.ToString() != "" && gvItemTable.Items[intJ].Cells[intK + 3].Text.ToString() != "&nbsp;")
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

                Response.AddHeader("content-disposition", string.Format("attachment;filename=DigitalOccurrence.pdf"));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=DigitalOccurrence.csv"));
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
                foreach (GridItem  grv in gvItemTable.Items)
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


                Response.AddHeader("content-disposition", string.Format("attachment;filename=DigitalOccurrence.doc"));
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

                sw.Write("<CAPTION><b>Digital Diary Report</b></CAPTION>");
                sw.Write("<CAPTION><font='+2'><br/></font></CAPTION>");
                sw.Write("<font='+1'>Generated On :</font> ");
                sw.Write("<font='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font='+2'>Searching Parameter :</font> ");
                //sw.Write("<font='+2'>" + str + "</font>");
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");


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
                    //sw.Write("<td>");
                    //sw.Write("&nbsp");
                    //sw.Write("</td>");

                }
                sw.Write("</tr>");

                foreach (GridItem  grvRow in gvItemTable.Items )
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


                Response.AddHeader("content-disposition", string.Format("attachment;filename=DigitalOccurrence.html"));
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
                sw.Write("<font size='+1'>Generated On : </font>");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<font size='+2'><CAPTION><b>Digital Diary Report</b></CAPTION></font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("Searching Parameter : ");
                //sw.Write(str);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<tr>");
                for (int i = 0; i < intcellCount-2; i++)
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

                foreach (GridItem grvRow in gvItemTable.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount-2; i++)
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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
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

        private void DeleteItem()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string argId1 = ViewState["DDID"].ToString().Trim();
                dal.executesql("Delete From Digital_Dairy Where DDID='" + argId1 + "' ");
               //HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                MyMasterPage.ShowErrorMessage("Record Deleted sucessfully ..!");  
                fillgrid();
                ModalPopupDelete.Hide();

               // Response.Redirect("~/ADMIN/CompleteForm.aspx");

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
       

        #region Edit Delete report

        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["DDID"] != null)
            {
                ModalPopupAdd.Show();
                PopulatePageCntrls();
                Session["ctrl"] = printview;
            }
        }
        private void PopulatePageCntrls()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string argsBGID = ViewState["DDID"].ToString().Trim();
                DataSet dsdate = dal.getdataset("Select Dairy_date from Digital_Dairy Where DDID='" + argsBGID + "' ");
                if (dsdate.Tables[0].Rows.Count > 0)
                {
                    txtdate.Text = dsdate.Tables[0].Rows[0]["Dairy_date"].ToString().Trim();
                    int cout = 0;
                    DataSet dsget = dal.getdataset("Select * From Digital_Dairy Where Dairy_date='" + txtdate.Text + "' Order by time Asc ");
                    if (dsget.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = dsget.Tables[0].Rows[0]["Staff_id"].ToString().Trim();
                        txtheading.Text = dsget.Tables[0].Rows[0]["Heading"].ToString().Trim();
                        txttime.Text = dsget.Tables[0].Rows[0]["time"].ToString().Trim();
                        txtDescription.Text = dsget.Tables[0].Rows[0]["Description"].ToString().Trim();
                        cout++;
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label4.Text = dsget.Tables[0].Rows[1]["Staff_id"].ToString().Trim();
                            Label6.Text = dsget.Tables[0].Rows[1]["Heading"].ToString().Trim();
                            Label2.Text = dsget.Tables[0].Rows[1]["time"].ToString().Trim();
                            Label8.Text = dsget.Tables[0].Rows[1]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label12.Text = dsget.Tables[0].Rows[2]["Staff_id"].ToString().Trim();
                            Label14.Text = dsget.Tables[0].Rows[2]["Heading"].ToString().Trim();
                            Label10.Text = dsget.Tables[0].Rows[2]["time"].ToString().Trim();
                            Label16.Text = dsget.Tables[0].Rows[2]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label20.Text = dsget.Tables[0].Rows[3]["Staff_id"].ToString().Trim();
                            Label22.Text = dsget.Tables[0].Rows[3]["Heading"].ToString().Trim();
                            Label18.Text = dsget.Tables[0].Rows[3]["time"].ToString().Trim();
                            Label24.Text = dsget.Tables[0].Rows[3]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label28.Text = dsget.Tables[0].Rows[4]["Staff_id"].ToString().Trim();
                            Label30.Text = dsget.Tables[0].Rows[4]["Heading"].ToString().Trim();
                            Label26.Text = dsget.Tables[0].Rows[4]["time"].ToString().Trim();
                            Label32.Text = dsget.Tables[0].Rows[4]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label36.Text = dsget.Tables[0].Rows[5]["Staff_id"].ToString().Trim();
                            Label38.Text = dsget.Tables[0].Rows[5]["Heading"].ToString().Trim();
                            Label34.Text = dsget.Tables[0].Rows[5]["time"].ToString().Trim();
                            Label40.Text = dsget.Tables[0].Rows[5]["Description"].ToString().Trim();
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label44.Text = dsget.Tables[0].Rows[6]["Staff_id"].ToString().Trim();
                            Label46.Text = dsget.Tables[0].Rows[6]["Heading"].ToString().Trim();
                            Label42.Text = dsget.Tables[0].Rows[6]["time"].ToString().Trim();
                            Label48.Text = dsget.Tables[0].Rows[6]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label52.Text = dsget.Tables[0].Rows[7]["Staff_id"].ToString().Trim();
                            Label54.Text = dsget.Tables[0].Rows[7]["Heading"].ToString().Trim();
                            Label50.Text = dsget.Tables[0].Rows[7]["time"].ToString().Trim();
                            Label56.Text = dsget.Tables[0].Rows[7]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label60.Text = dsget.Tables[0].Rows[8]["Staff_id"].ToString().Trim();
                            Label62.Text = dsget.Tables[0].Rows[8]["Heading"].ToString().Trim();
                            Label58.Text = dsget.Tables[0].Rows[8]["time"].ToString().Trim();
                            Label64.Text = dsget.Tables[0].Rows[8]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label68.Text = dsget.Tables[0].Rows[9]["Staff_id"].ToString().Trim();
                            Label70.Text = dsget.Tables[0].Rows[9]["Heading"].ToString().Trim();
                            Label66.Text = dsget.Tables[0].Rows[9]["time"].ToString().Trim();
                            Label72.Text = dsget.Tables[0].Rows[9]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label76.Text = dsget.Tables[0].Rows[10]["Staff_id"].ToString().Trim();
                            Label78.Text = dsget.Tables[0].Rows[10]["Heading"].ToString().Trim();
                            Label74.Text = dsget.Tables[0].Rows[10]["time"].ToString().Trim();
                            Label80.Text = dsget.Tables[0].Rows[10]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label84.Text = dsget.Tables[0].Rows[11]["Staff_id"].ToString().Trim();
                            Label86.Text = dsget.Tables[0].Rows[11]["Heading"].ToString().Trim();
                            Label82.Text = dsget.Tables[0].Rows[11]["time"].ToString().Trim();
                            Label88.Text = dsget.Tables[0].Rows[11]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label92.Text = dsget.Tables[0].Rows[12]["Staff_id"].ToString().Trim();
                            Label94.Text = dsget.Tables[0].Rows[12]["Heading"].ToString().Trim();
                            Label90.Text = dsget.Tables[0].Rows[12]["time"].ToString().Trim();
                            Label96.Text = dsget.Tables[0].Rows[12]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label100.Text = dsget.Tables[0].Rows[13]["Staff_id"].ToString().Trim();
                            Label102.Text = dsget.Tables[0].Rows[13]["Heading"].ToString().Trim();
                            Label98.Text = dsget.Tables[0].Rows[13]["time"].ToString().Trim();
                            Label104.Text = dsget.Tables[0].Rows[13]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label108.Text = dsget.Tables[0].Rows[14]["Staff_id"].ToString().Trim();
                            Label110.Text = dsget.Tables[0].Rows[14]["Heading"].ToString().Trim();
                            Label106.Text = dsget.Tables[0].Rows[14]["time"].ToString().Trim();
                            Label112.Text = dsget.Tables[0].Rows[14]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label116.Text = dsget.Tables[0].Rows[15]["Staff_id"].ToString().Trim();
                            Label118.Text = dsget.Tables[0].Rows[15]["Heading"].ToString().Trim();
                            Label114.Text = dsget.Tables[0].Rows[15]["time"].ToString().Trim();
                            Label120.Text = dsget.Tables[0].Rows[15]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label124.Text = dsget.Tables[0].Rows[16]["Staff_id"].ToString().Trim();
                            Label126.Text = dsget.Tables[0].Rows[16]["Heading"].ToString().Trim();
                            Label122.Text = dsget.Tables[0].Rows[16]["time"].ToString().Trim();
                            Label128.Text = dsget.Tables[0].Rows[16]["Description"].ToString().Trim();
                            cout++;
                        }

                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label132.Text = dsget.Tables[0].Rows[17]["Staff_id"].ToString().Trim();
                            Label134.Text = dsget.Tables[0].Rows[17]["Heading"].ToString().Trim();
                            Label130.Text = dsget.Tables[0].Rows[17]["time"].ToString().Trim();
                            Label136.Text = dsget.Tables[0].Rows[17]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label140.Text = dsget.Tables[0].Rows[18]["Staff_id"].ToString().Trim();
                            Label142.Text = dsget.Tables[0].Rows[18]["Heading"].ToString().Trim();
                            Label138.Text = dsget.Tables[0].Rows[18]["time"].ToString().Trim();
                            Label144.Text = dsget.Tables[0].Rows[18]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label148.Text = dsget.Tables[0].Rows[19]["Staff_id"].ToString().Trim();
                            Label150.Text = dsget.Tables[0].Rows[19]["Heading"].ToString().Trim();
                            Label146.Text = dsget.Tables[0].Rows[19]["time"].ToString().Trim();
                            Label152.Text = dsget.Tables[0].Rows[19]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label156.Text = dsget.Tables[0].Rows[20]["Staff_id"].ToString().Trim();
                            Label158.Text = dsget.Tables[0].Rows[20]["Heading"].ToString().Trim();
                            Label154.Text = dsget.Tables[0].Rows[20]["time"].ToString().Trim();
                            Label160.Text = dsget.Tables[0].Rows[20]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label164.Text = dsget.Tables[0].Rows[21]["Staff_id"].ToString().Trim();
                            Label166.Text = dsget.Tables[0].Rows[21]["Heading"].ToString().Trim();
                            Label162.Text = dsget.Tables[0].Rows[21]["time"].ToString().Trim();
                            Label168.Text = dsget.Tables[0].Rows[21]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label172.Text = dsget.Tables[0].Rows[22]["Staff_id"].ToString().Trim();
                            Label174.Text = dsget.Tables[0].Rows[22]["Heading"].ToString().Trim();
                            Label170.Text = dsget.Tables[0].Rows[22]["time"].ToString().Trim();
                            Label176.Text = dsget.Tables[0].Rows[22]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label180.Text = dsget.Tables[0].Rows[23]["Staff_id"].ToString().Trim();
                            Label182.Text = dsget.Tables[0].Rows[23]["Heading"].ToString().Trim();
                            Label178.Text = dsget.Tables[0].Rows[23]["time"].ToString().Trim();
                            Label184.Text = dsget.Tables[0].Rows[23]["Description"].ToString().Trim();
                            cout++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        //protected void btnprint_Click(object sender, EventArgs e)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        Session["ctrl"] = printview;
        //        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}


        protected void ToggleRowSelection(object sender, EventArgs e)
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


                        ViewState["DDID"] = item.OwnerTableView.DataKeyValues[ro]["DDID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["DDID"] !=null)
            {
                ModalPopupDelete.Show();
            }
           

        }
        protected void btnCancel_Click(object sender,EventArgs e)
        {
            ModalPopupDelete.Hide();
            
        }
        protected void btnDeleCancel_Click(object sender,EventArgs e)
        {
            DeleteItem();
           // fillgrid();
        }
        
            
        #endregion

    }
}
