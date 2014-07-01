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
using SMS.master;


namespace SMS.SMSUsers.Reports
{
    public partial class AlertReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
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
                        if (controlname.ToUpper().Contains("gvLoctionTable".ToUpper()))
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
               // BindGrid();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void getLocationIDByName(string Name)
        {
            
            //SqlParameter[] para = new SqlParameter[1];
            //para[0] = new SqlParameter("@Location_name", Name);
            //DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            //if (dsLocationID.Rows.Count > 0)
            //{
            //    SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            //}
        }

        private void getLocationName()
        {
            ////ddllocation.Items.Clear();
            ////ddllocation.Items.Add(" ");           
            //SqlParameter[] para = new SqlParameter[0];
            
            //DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            //if (dsLocation.Rows.Count > 0)
            //{
            //    for (int k = 0; k < dsLocation.Rows.Count; k++)
            //    {
            //        ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
            //    }
            //}
        }

        private string getLocationNameById(int  Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
            string  name=dsLocationName.Rows[0][0].ToString().Trim();
            return name;
            }
            return null;
        }


        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
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
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "View")
                {
                    DataSet ds = dal.getdataset("Select V_ResgistNo from Alert_Handling where Alert_id = '" + _BTId + "' ");
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString().Trim() != string.Empty)
                    {
                        Response.Redirect("~/SuperVisor/AlertViewVehicle.aspx?id=" + _BTId);

                        //HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                       // HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                       // Server.Transfer("../SuperVisor/AlertViewVehicle.aspx");
                       // Server.Transfer("../smsadmin/KeyDataUpdate.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/SuperVisor/AlertView.aspx?id=" + _BTId);                       
                    }
                }
                if (e.CommandName == "DeleteRow")
                {
                   //DeleteItem(_BTId);
                }
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
                if (!string.IsNullOrEmpty(ViewState["Alert_ID"].ToString().Trim()))

                {
                    //AdminBLL ws = new AdminBLL();
                    //DeleteAlertRequest _req = new DeleteAlertRequest();

                    //_req.Alert_ID = ViewState["Alert_ID"].ToString().Trim();

                    //ws.DeleteAlert(_req);

                    string argId1 = ViewState["Alert_ID"].ToString().Trim(); 
                    dal.executesql("Delete From Alert_Handling Where Alert_ID='" + argId1 + "' ");
                    // HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    MyMasterPage.ShowErrorMessage("Record Delete sucessfully ..!");  
                    ModalPopupDelete.Hide();
                    ModalPopupDelete.Hide();
                    BindGridWithFilter();
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    //gvLoctionTable.PageIndex = e.NewPageIndex;
                    //BindGridWithFilter();

                    //AdminBLL ws = new AdminBLL();
                    //GetLocationData _req = new GetLocationData();
                    //GetLocationDataResponse _resp = ws.GetLocationData(_req);

                    //int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    //gvLoctionTable.PageSize = pageSize;
                    //gvLoctionTable.DataSource = _resp.Location;
                    //gvLoctionTable.DataBind();
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
                GetAlertData objReq = new GetAlertData();
                //getLocationIDByName(ddllocation.Text.Trim());
                //string WhereClause = ReturnWhere();

                //if (!string.IsNullOrEmpty(ddlAlertType.Text))
                //{
                //    objReq.Alert_Type = ddlAlertType.Text;
                //}
                //if (!string.IsNullOrEmpty(WhereClause))
                //{
                //    objReq.WhereClause = WhereClause;
                //}
                //if (!string.IsNullOrEmpty(txtdatefrom.Text))
                //{
                //    if (string.IsNullOrEmpty(txtdateto.Text))
                //    {
                //        objReq.Date_From = txtdatefrom.Text;
                //    }
                //}
                //if (!string.IsNullOrEmpty(txtdateto.Text))
                //{
                //    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                //    {
                //        objReq.Date_From = txtdatefrom.Text;
                //        objReq.Date_From = txtdateto.Text;
                //    }
                //}

                GetAlertDataResponse ret = ws.GetAlertData(objReq);
                //int pageSize = ContextKeys.GRID_PAGE_SIZE;
               
                gvLoctionTable.DataSource = ret.Alert_ID;
                gvLoctionTable.DataBind();
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

                //if (ddlAlertType.Text.Trim() != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Alert_Type='" + ddlAlertType.Text.Trim() + "'";
                //        arr.Add("1");
                //    }
                //    else
                //    {
                //        str += " and Alert_Type ='" + ddlAlertType.Text.Trim() + "'";
                //    }
                //}

                //if (ddllocation.Text.Trim() != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Location_id ='" + SearchLocID.Text + "'";
                //        arr.Add("2");
                //    }
                //    else
                //    {
                //        str += " and Location_id ='" + SearchLocID.Text + "'";
                //    }
                //}
                //if (txtdateto.Text != "" && txtdatefrom.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //        arr.Add("3");
                //    }
                //    else
                //    {
                //        str += " and Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //    }
                //}
                //if (txtdatefrom.Text != "" && txtdateto.Text == "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Date_From='" + txtdatefrom.Text + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and Date_From='" + txtdatefrom.Text + "'";
                //    }
                //}
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
                GetLocationData _req = new GetLocationData();
                GetLocationDataResponse _resp = ws.GetLocationData(_req);

              
               
                gvLoctionTable.DataSource = _resp.Location;
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnSearchAdminAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
               // getLocationIDByName(ddllocation.Text.Trim());
                //BindGridWithFilter();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearAdminAlert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void ClearAll()
        {
            getLocationName();
           // txtdatefrom.Text = "";
           // txtdateto.Text = "";
           // ddllocation.Text = "";
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

                //if (ddlAlertType.Text != "")
                //    str = ("   Alert_Type : " + ddlAlertType.Text);
                //if (ddllocation.Text!= "")
                //    str = ("    Location_id : " + ddllocation.Text);
                

                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                Phrase headerPhrase = new Phrase("                                       Alert Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("        Generated On : ");
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
                PdfPTable ptData = new PdfPTable(gvLoctionTable.Columns.Count-1);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvLoctionTable.Columns.Count-1]; // percentage


                headerwidths[0] = 3.2F;
                headerwidths[1] = 3.2F;
                headerwidths[2] = 3.2F;
                headerwidths[3] = 3.2F;
                //headerwidths[4] = 3.2F;
                //headerwidths[5] = 3.2F;
                //headerwidths[6] = 3.2F;
                //headerwidths[6] = 3.2F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvLoctionTable.Columns.Count-1; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    if (gvLoctionTable.Columns[intK + 1].HeaderText.ToString()!="")
                    cell.Phrase = new Phrase(gvLoctionTable.Columns[intK+1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvLoctionTable.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvLoctionTable.Columns.Count-1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvLoctionTable.Items[intJ].Cells[intK + 3].Text.ToString() != "" && gvLoctionTable.Items[intJ].Cells[intK + 3].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvLoctionTable.Items[intJ].Cells[intK+3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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

                Response.AddHeader("content-disposition", string.Format("attachment;filename=AlertReport.pdf"));
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
                foreach (GridDataItem grv in gvLoctionTable.Items)
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
                Int32 intcellCount = gvLoctionTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();



                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                //if (ddlAlertType.Text != "")
                //    str = ("   Alert_Type : " + ddlAlertType.Text);
                //if (ddllocation.Text != "")
                //    str = ("    Location_id : " + ddllocation.Text);


                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


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
                sw.Write("<CAPTION><b><font size='+2'>Alert Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On :</font> ");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>" + str + "</font>");



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount - 1; i++)
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

                foreach (GridDataItem grvRow in gvLoctionTable.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount - 1; i++)
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
        public void DownloadWordFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvLoctionTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();



                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                //if (ddlAlertType.Text != "")
                //    str = ("   Alert_Type : " + ddlAlertType.Text);
                //if (ddllocation.Text != "")
                //    str = ("    Location_id : " + ddllocation.Text);


                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


                Response.AddHeader("content-disposition", string.Format("attachment;filename=AlertReport.doc"));
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
                sw.Write("<CAPTION><b><font size='+2'>Alert Report</font></b></CAPTION>");
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
                    strHeaderText = gvLoctionTable.Columns[i].HeaderText.ToString();
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

                foreach (GridDataItem grvRow in gvLoctionTable.Items)
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
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //Session["ctrl"] = panel1;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=700px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddlAlertType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        #region alert view reports


        protected void imgUpdate_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Show();
            PopulatePageCntrls();
            Session["ctrl"] = printview;
        }
        protected void imgDelete_Click(object sender,EventArgs e)
        {
            ModalPopupDelete.Show();
           
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvLoctionTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvLoctionTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvLoctionTable.Items[ro].Selected = true;


                        ViewState["Alert_ID"] = item.OwnerTableView.DataKeyValues[ro]["Alert_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }


        private void PopulatePageCntrls()
        {
            Int32 iCount = 0;
            GetAlertDataResponse ret = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetAlertData objGetBillingTableRequest = new GetAlertData();
                string argsBGID = ViewState["Alert_ID"].ToString().Trim();
                objGetBillingTableRequest.Alert_ID = argsBGID.ToString();
                objGetBillingTableRequest.WhereClause = " where Alert_ID='" + argsBGID.ToString() + "'";

                ret = objAdminBLL.GetAlertData(objGetBillingTableRequest);
                int locid =Convert.ToInt32(ret.Alert_ID[iCount].Location_id);
                txtlocation.Text =getLocationNameById(locid );

                txtVehicleType.Text = ret.Alert_ID[iCount].V_Type.ToString();

                txtVehicleRegNo.Text = ret.Alert_ID[iCount].V_ResgistNo.ToString();
                txtVehicleReason.Text = ret.Alert_ID[iCount].Alert_Type.ToString();
                txtVehicleownerNric.Text = ret.Alert_ID[iCount].V_OwnerNricNo.ToString();
                txtVehicleownerName.Text = ret.Alert_ID[iCount].V_OwnerName.ToString();

                // txtReason.Text = ret.Alert_ID[iCount].Alert_Type.ToString();
                txtRaisedName.Text = ret.Alert_ID[iCount].AlertBy_Name.ToString();
                txtRaisedNric.Text = ret.Alert_ID[iCount].AlertBy_NRICNo.ToString();
                txtPhone.Text = ret.Alert_ID[iCount].AlertContNo.ToString();
                // txtNationality.Text = ret.Alert_ID[iCount].P_Nationality.ToString();
                txtdesignation.Text = ret.Alert_ID[iCount].AlertDesignation.ToString();
                txtcomment.Text = ret.Alert_ID[iCount].Comment.ToString();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void Delete_Alert_Click(object sender, EventArgs e)
        {

            DeleteItem();

        }


        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupAdd.Hide();
            ModalPopupDelete.Hide();
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
        #endregion 

    }
}
