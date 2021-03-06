﻿using System;
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
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Collections.Generic;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using Telerik.Web.UI;
using System.Globalization;
namespace SMS.Reports
{
    public partial class EventReport : System.Web.UI.Page
    {        
        AdminDAL a = new AdminDAL();     
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {              
                if (!IsPostBack)
                {
                    fillEventAlert();              
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
            ddllocation.Items.Add(" ");
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

        private void fillEventAlert()
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(" ");
            string ID = "eventtype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);          
            
            if (dt.Rows.Count > 0)
            {
                for (int K = 0; K < dt.Rows.Count; K++)
                {
                    DropDownList2.Items.Add(dt.Rows[K][0].ToString().Trim());
                }
            }
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //JS for delete btn
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
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "View")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("ViewEvent.aspx");
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
        private void DeleteItem(string argEventId)
        {
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        try
        {
            if (!string.IsNullOrEmpty(argEventId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteEventPlannerRequest _req = new DeleteEventPlannerRequest();
                    _req.EventID = argEventId.ToString();
                    ws.DeleteEvent(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                   // Server.Transfer("~/SMSAdmin/AlertUpdateComplete.aspx");
                }           
        }
        catch (Exception ex)
        {
            logger.Info(ex.Message);
        }
    }
      protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvItemTable.PageIndex = e.NewPageIndex;                    
                    AdminBLL ws = new AdminBLL();
                    GetDataEvent _req = new GetDataEvent();
                    GetDataEventResponse _resp = ws.GetEventData(_req);
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp.Eventid;
                    gvItemTable.DataBind();
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
                GetDataEvent objReq = new GetDataEvent();               
                //getLocationIDByName(ddllocation.SelectedValue.Trim());
                getLocationIDByName1(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();
         
                if (!string.IsNullOrEmpty(DropDownList2.Text))
                {
                    objReq.Event_Type = DropDownList2.Text;
                }
                if (!string.IsNullOrEmpty(txtpersonincharg.Text))
                {
                    objReq.Incharg_Name = txtpersonincharg.Text;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.Date_From = txtdatefrom.Text;
                        objReq.Date_From = txtdateto.Text;
                    }
                }

                //WhereClause by jitendra
                //if (Request.QueryString["Past"] != null)
                //{
                //    WhereClause = WhereClause + " where Date_From  <='" + DateTime.Now.ToShortDateString() + "'";
                //}
                //else
                //{
                //    WhereClause = WhereClause + " where Date_From  >='" + DateTime.Now.ToShortDateString() + "'";
                //}
                //

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }
                GetDataEventResponse ret = ws.GetEventData(objReq);

                
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                //gvItemTable.PageSize = pageSize;
                //gvItemTable.DataSource = ret.Eventid;
                //if (ret.Eventid.Count == 0)
                //{
                //  // event2.Visible = false;                   
                //}
                //gvItemTable.DataBind();

                //gvItemTable.PageSize = pageSize;
                gvItemTable1.DataSource = ret.Eventid;                
                gvItemTable1.DataBind();

               // event2.Text = ret.Eventid.Count.ToString();


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
                if (DropDownList2.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Event_Type='" + DropDownList2.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Event_Type='" + DropDownList2.Text + "'";
                    }
                }

                if (txtpersonincharg.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Incharg_Name='" + txtpersonincharg.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and Incharg_Name='" + txtpersonincharg.Text + "'";
                    }
                }              

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Date_From BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Date_From='" + txtdatefrom.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and Date_From='" + txtdatefrom.Text + "'";
                    }
                }
                if (ddllocation.SelectedValue.Trim() != "")
                {
                    string result = getLocationIDByName1(ddllocation.SelectedValue.Trim());
                    if (arr.Count == 1)
                    {
                        str += " where Location_id='" + result + "' ";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and Location_id='" + result + "' ";
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

                GetDataEvent _req = new GetDataEvent();
                GetDataEventResponse _resp = ws.GetEventData(_req);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Eventid;
                if (_resp.Eventid.Count == 0)
                {                  
                   // event2.Visible = false;                   
                }
                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {

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

               // if (txteventid.Text != "")
                //    str = ("   NRIC/FIN No. : " + txteventid.Text);
                if (DropDownList2.Text != "")
                    str = ("   Event Type : " + DropDownList2.Text);
                if (ddllocation.Text.Trim() != "")
                    str = ("   Location : " + ddllocation.Text);
                if (txtpersonincharg.Text != "")
                    str = ("   Person In Charge : " + txtpersonincharg.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                Phrase headerPhrase = new Phrase("                                     Event Report                                                       ", FontFactory.GetFont("Garamond", 14));

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
                PdfPTable ptData = new PdfPTable(gvItemTable1.Columns.Count - 1);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;
                float[] headerwidths = new float[gvItemTable1.Columns.Count - 1]; // percentage

                headerwidths[0] = 3.2F;
                headerwidths[1] = 3.2F;
                headerwidths[2] = 3.2F;
                headerwidths[3] = 3.2F;
                headerwidths[4] = 3.2F;
                headerwidths[5] = 3.2F;
               // headerwidths[6] = 3.2F;
               // headerwidths[7] = 3.2F;
               // headerwidths[8] = 3.2F;


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
              
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Event.pdf"));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Event.csv"));
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

                //if (txteventid.Text != "")
                 //   str = ("   NRIC/FIN No. : " + txteventid.Text);
                if (DropDownList2.Text != "")
                    str = ("   Event Type : " + DropDownList2.Text);
                if (ddllocation.Text != "")
                    str = ("   Location : " + ddllocation.Text);
                if (txtpersonincharg.Text != "")
                    str = ("   Person In Charge : " + txtpersonincharg.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);




              
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Event.html"));
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
                sw.Write("<CAPTION><b><font size='+2'>Event Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On : </font>");
                sw.Write("<font size='+1'>" + datetime + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>" + str + "</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");


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
        public void DownloadWordFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvItemTable1.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
               // string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                //if (txteventid.Text != "")
                //   str = ("   NRIC/FIN No. : " + txteventid.Text);
                if (DropDownList2.Text != "")
                    str = ("   Event Type : " + DropDownList2.Text);
                if (ddllocation.Text != "")
                    str = ("   Location : " + ddllocation.Text);
                if (txtpersonincharg.Text != "")
                    str = ("   Person In Charge : " + txtpersonincharg.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                Response.AddHeader("content-disposition", string.Format("attachment;filename=Event.doc"));
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
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(@filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");

                sw.Write("<CAPTION><b><font size='+2'>Event Report</font></b></CAPTION>");
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("<font size='+1'>Generated On : </font>");
                sw.Write("<font size='+1'>"+datetime+"</font>");
                sw.Write("<CAPTION><br/></CAPTION>");
                //sw.Write("<font size='+2'>Searching Parameter :</font> ");
                //sw.Write("<font size='+2'>"+str+"</font>");
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

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void txteventid_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnclear_Click(object sender, EventArgs e)
        {           
            //DropDownList2.Text = "";
            getLocationName();
            txtpersonincharg.Text = "";
            txtdatefrom.Text = "";
            txtdateto.Text = "";
        }
        protected void btnPrint_Click(object sender, EventArgs e)
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

        protected void txtpersonincharg_TextChanged(object sender, EventArgs e)
        {

        }

        public string getLocationIDByName1(string loc)
        {
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select Location_id from location where Location_name=@location", cn);
            cmd.Parameters.AddWithValue("@location", loc.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            int result1 = 0;
            string result = "";
            if (dr.Read())
            {
                result1 = dr.GetInt32(0);
                cn.Close();
                result = Convert.ToString(result1);
            }
            return result;
        }

        #region View
        protected void ImgView_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
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
                    PopulatePageCntrls(ViewState["Event_ID"].ToString());
                    // Fill();
                    this.ModalPopupUpdate.Show();
                    Session["ctrl"] = printview;
                }
            }
            catch (Exception ex)
            {
                logger.Info("EventReport(ImgView_Click):" + ex.Message);
            }
        }
        private void PopulatePageCntrls(String argsBGID)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select Date_From,Date_to,Location_id,Event_Type,Start_time,End_time,Special_Requirment,Guard_Requirment,Special_Duty,Incharg_Name,Incharg_NricNo,Incharg_position,Incharg_ContactNo,Superior_Name From event Where Event_ID='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtFromDate.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtTodate.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtlocation.Text = GetLocationNameById(dsget.Tables[0].Rows[0][2].ToString().Trim());
                    txtEventType.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txtStartTime.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtEndTime.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtSpecialReg.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                    txtNoOfGuard.Text = dsget.Tables[0].Rows[0][7].ToString().Trim();
                    txtSpecialDuty.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();

                    txtPersonName.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                    txtPersonNRIC.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();
                    txtPersonContNo.Text = dsget.Tables[0].Rows[0][11].ToString().Trim();
                    txtPersonPosition.Text = dsget.Tables[0].Rows[0][12].ToString().Trim();

                    txtSuperior.Text = dsget.Tables[0].Rows[0][13].ToString().Trim();


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
                logger.Info("EventReport(BtnCancelPrint_Click):" + ex.Message);
            }
        }

        #endregion
        #region delete
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("EventReport(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["Event_ID"] != null)
                {
                    DeleteItem(ViewState["Event_ID"].ToString());
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Delete SuccessFully');", true);
                    BindGridWithFilter();
                    ViewState["Event_ID"] = null;
                    ModalPopupDelete.Hide();

                }
            }
            catch (Exception ex)
            {
                logger.Info("EventReport(Deletepopup_Yes_Click):" + ex.Message);
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
                logger.Info("EventReport(btnCancelDelete_Click):" + ex.Message);
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
                        ViewState["Event_ID"] = item.OwnerTableView.DataKeyValues[ro]["Event_ID"];
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
