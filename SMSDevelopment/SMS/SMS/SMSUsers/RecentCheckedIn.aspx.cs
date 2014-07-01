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

namespace SMS.SMSUsers
{
    public partial class RecentChecedIn : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
         {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtnricno.Focus();
                if (!IsPostBack)
                {

                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        getLocationName();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                       
                    }
                  
                    getLocationIDByName(ddllocation.Text.Trim());
                    

                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvItemTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilterCkeckedIn();
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
                    BindGridWithFilterCkeckedIn();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");

            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int j = 0; j < dsLocation.Rows.Count; j++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[j][0].ToString().Trim());
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

        private void getLocationName()
        {
            SqlParameter[] para = new SqlParameter[0];           
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
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("../SMSAdmin/VisitorUpdate.aspx");

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

        private void DeleteItem(string argEmbossId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argEmbossId))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteContractorRequest _req = new DeleteContractorRequest();

                    _req.ContratorNo = argEmbossId.ToString();

                    ws.DeleteContractor(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
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
                    AdminBLL ws = new AdminBLL();

                    GetVisitorData _req = new GetVisitorData();
                    GetVisitorDataResponse _resp = ws.GetVisitorData(_req);
                    gvItemTable.DataSource = _resp.Visitor;
                    gvItemTable.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilterCkeckedIn()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetCheckinData objReq = new GetCheckinData();
                //string WhereClause = ReturnWhere();

                //if (!string.IsNullOrEmpty(txtnricno.Text))
                //{
                //    objReq.NRICno = txtnricno.Text;
                //}
                //if (!string.IsNullOrEmpty(txtvehicleno.Text))
                //{
                //    objReq.user_name = txtvehicleno.Text;
                //}
                //if (!string.IsNullOrEmpty(txtrole.Text))
                //{
                //    objReq.Role = txtrole.Text;
                //}
                //if (!string.IsNullOrEmpty(WhereClause))
                //{
                //    objReq.WhereClause = WhereClause;
                //}


                GetChiekinDataResponse ret = ws.Getcheckin(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = ret.checkinid;
                if (ret.checkinid.Count == 0)
                {
                    visitor2.Visible = false;
                }
                gvItemTable.DataBind();
                visitor2.Text = ret.checkinid.Count.ToString();
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

                //if (txtnricno.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        makeWhereClause = " where ";
                //        str += " where NRICno='" + txtnricno.Text + "'";
                //        arr.Add("1");
                //    }
                //    else
                //    {
                //        str += " and NRICno='" + txtnricno.Text + "'";
                //    }
                //}


                //if (txtrole.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        makeWhereClause = " where ";
                //        str += " where Role='" + txtrole.Text + "' ";
                //        arr.Add("6");
                //    }
                //    else
                //    {
                //        str += " and Role='" + txtrole.Text + "'";
                //    }
                //}


                //if (txtvehicleno.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where vehicle_no='" + txtvehicleno.Text + "'";
                //        arr.Add("2");
                //    }
                //    else
                //    {
                //        str += " and vehicle_no='" + txtvehicleno.Text + "'";
                //    }
                //}
                //if (txtkeyno.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where key_no='" + txtkeyno.Text + "'";
                //        arr.Add("3");
                //    }
                //    else
                //    {
                //        str += " and key_no='" + txtkeyno.Text + "'";
                //    }
                //}
                //if (txtpasstype.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Pass_No='" + txtpasstype.Text + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and pass_no='" + txtpasstype.Text + "'";
                //    }
                //}
                //if (txtdateto.Text != "" && txtdatefrom.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where checkin_time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //        arr.Add("5");
                //    }
                //    else
                //    {
                //        str += " and checkin_time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //    }
                //}

                //if (txtdatefrom.Text != "" && txtdateto.Text == "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where checkin_time='" + txtdatefrom.Text + "'";
                //        arr.Add("5");
                //    }
                //    else
                //    {
                //        str += " and checkin_time='" + txtdatefrom.Text + "'";
                //    }
                //}
                //if (ddllocation.Text.Trim() != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where LocationID='" + SearchLocID.Text + "'";
                //        arr.Add("5");
                //    }
                //    else
                //    {
                //        str += " and LocationID='" + SearchLocID.Text + "'";
                //    }
                //}

                //if (txtvehicleno.Text.Trim() != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where user_name='" + txtvehicleno.Text + "'";
                //        arr.Add("5");
                //    }
                //    else
                //    {
                //        str += " and user_name='" + txtvehicleno.Text + "'";
                //    }
                //}
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return (str);
        }

        protected void txtrole_SelectedIndexChanged(object sender, EventArgs e)
        {

           // BindGridWithFilterCkeckedIn();
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
          // BindGridWithFilterCkeckedIn();
        }


        private string getLocationIdByName(string Lname)
        {
            string id = string.Empty;
            DataSet dsid = dal.getdataset("Select Location_id from location where Location_name = '"+ddllocation.Text.Trim()+"' ");
            if(dsid.Tables[0].Rows.Count>0)
            {
                id = dsid.Tables[0].Rows[0][0].ToString().Trim();
                return id;
            }

            return id;
        }

        




        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();

                GetVisitorData _req = new GetVisitorData();
                GetVisitorDataResponse _resp = ws.GetVisitorData(_req);


                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.Visitor;
                if (_resp.Visitor.Count == 0)
                {
                    visitor2.Visible = false;
                }

                gvItemTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationIDByName(ddllocation.Text.Trim());
              //getLocationNameById(Session["LCID"].ToString());
              BindGridWithFilterCkeckedIn();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            //txtdatefrom.Text = "";
            //txtdateto.Text = "";
            //txtkeyno.Text = "";
            txtnricno.Text = "";
            txtvehicleno.Text = "";
            //txtpasstype.Text = "";
            //txtrole.Text = "";
            
        }

       

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        dr.Close();
                        cn.Close();


                    }
                }
                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);
                //Create Heading
                Phrase headerPhrase = new Phrase("                                     Recent Check-In Report                                                      ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("        Generated On : ");
                headerPhrase.Add(datetime);
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);


                // Creates the Table
                PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvItemTable.Columns.Count]; // percentage


                headerwidths[0] = 3.2F;
                headerwidths[1] = 3.2F;
                headerwidths[2] = 3.2F;
                headerwidths[3] = 3.2F;
                headerwidths[4] = 3.2F;
                headerwidths[5] = 3.2F;
                // headerwidths[6] = 3.2F;
                //headerwidths[7] = 3.2F;
                //headerwidths[8] = 3.2F;
                //headerwidths[9] = 3.2F;
                //headerwidths[10] = 3.2F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    cell.Phrase = new Phrase(gvItemTable.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                    ptData.AddCell(cell);
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvItemTable.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvItemTable.Items[intJ].Cells[intK+2].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvItemTable.Items[intJ].Cells[intK+2].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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
                Response.AddHeader("content-disposition", string.Format("attachment;filename=RecentCheckedIn.pdf"));
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
                foreach (GridViewRow grv in gvItemTable.Items)
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
                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=testhtml.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>Recent Check In Report</b></CAPTION>");
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

                foreach (GridViewRow grvRow in gvItemTable.Items)
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
                Int32 intcellCount = gvItemTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                // string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                ////if (txteventid.Text != "")
                ////   str = ("   NRIC/FIN No. : " + txteventid.Text);
                //if (DropDownList2.Text != "")
                //    str = ("   Event Type : " + DropDownList2.Text);
                //if (ddllocation.Text != "")
                //    str = ("   Location : " + ddllocation.Text);
                //if (txtpersonincharg.Text != "")
                //    str = ("   Person In Charge : " + txtpersonincharg.Text);
                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





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
                        dr.Close();
                        cn.Close();
                        

                    }
                }
                //string filePath = Server.MapPath("../../Images/Untitled.png");
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(filePath);
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, imgPhoto.Width, imgPhoto.Height);
                Response.Write("<Center><table></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");

                sw.Write("<CAPTION><b><font size='+2'>Recent Check-In Report</font></b></CAPTION>");
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
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    //sw.Write("<td>");
                    //sw.Write("&nbsp");
                    //sw.Write("</td>");

                }
                sw.Write("</tr>");

                foreach (GridDataItem grvRow in gvItemTable.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        strContent = grvRow.Cells[i+2].Text.ToString();
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
                logger.Info(ex.Message);
            }
        }





        protected void btnEmail_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

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

       

       



    }
}
