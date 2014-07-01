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

namespace SMS.SMSUsers.Reports
{
    public partial class ContractorReportForPast : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        int i = 0;
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtnricno.Focus();

                if (!IsPostBack)
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
                        BindGridWithFilterForCurrentContractor();
                        //BindGridWithFilter();
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
                        BindGridWithFilter();
                    }
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
            catch (System.Threading.ThreadAbortException)
            {
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
                    if (Request.QueryString["curr"] != null)
                    {
                        HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        Server.Transfer("ViewContractor.aspx");
                    }
                    else
                    {
                        HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                        HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                        Server.Transfer("ContractorView.aspx");
                    }
                }
                if (e.CommandName == "DeleteRow")
                {
                    DeleteItem(_BTId);
                }
            }

            //catch (System.Threading.ThreadAbortException)
            //{
            //}
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
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    Response.Redirect("~/SMSUsers/Reports/ContractorReport.aspx");
                }
            }
            //catch (System.Threading.ThreadAbortException)
            //{
            //}
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
                    GetContractorData _req = new GetContractorData();
                    gvItemTable.PageIndex = e.NewPageIndex;

                    string WhereClause = ReturnWhere();

                    if (!string.IsNullOrEmpty(WhereClause))
                    {
                        _req.WhereClause = WhereClause;
                    }
                   // GetContractorDataResponse _resp = ws.GetContractorData(_req);
                    DataTable _resp = ws.GetContractorData(_req);
                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp;
                    gvItemTable.DataBind();
                }
            }
            //catch (System.Threading.ThreadAbortException)
            //{
            //}
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilterForCurrentContractor()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL ws = new AdminBLL();
                GetContractorData objReq = new GetContractorData();
                getLocationIDByName(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();


                if (!string.IsNullOrEmpty(txtnricno.Text))
                {
                    objReq.NRICno = txtnricno.Text;
                }
                if (!string.IsNullOrEmpty(txtvehicleno.Text))
                {
                    objReq.vehicle_no = txtvehicleno.Text;
                }
                if (!string.IsNullOrEmpty(txtkeyno.Text))
                {
                    objReq.key_no = txtkeyno.Text;
                }
                if (!string.IsNullOrEmpty(txtpasstype.Text))
                {
                    objReq.pass_no = txtpasstype.Text;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.checkin_time = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.checkin_time = txtdatefrom.Text;
                        objReq.checkin_time = txtdateto.Text;
                    }
                }


                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

                GetContractorDataResponse ret = ws.GetContractorDataForCurrentTime(objReq);

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = ret.Contractor;
                if (ret.Contractor.Count == 0)
                {
                    // contracter1.Visible = false;
                    // contractor2.Visible = false;

                }
                gvItemTable.DataBind();
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
                getLocationIDByName(ddllocation.Text.Trim());
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(ddllocation.SelectedValue.Trim()))
                {
                    objReq.Location_id = ddllocation.SelectedValue.Trim();
                }

                if (!string.IsNullOrEmpty(txtnricno.Text))
                {
                    objReq.NRICno = txtnricno.Text;
                }

                if (!string.IsNullOrEmpty(txtvehicleno.Text))
                {
                    objReq.vehicle_no = txtvehicleno.Text;
                }
                if (!string.IsNullOrEmpty(txtkeyno.Text))
                {
                    objReq.key_no = txtkeyno.Text;
                }
                if (!string.IsNullOrEmpty(txtpasstype.Text))
                {
                    objReq.pass_no = txtpasstype.Text;
                }
                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.checkin_time = txtdatefrom.Text;
                    }
                }
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.checkin_time = txtdatefrom.Text;
                        objReq.checkin_time = txtdateto.Text;
                    }
                }
                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }

               // GetContractorDataResponse ret = ws.GetContractorData(objReq);
                DataTable ret = ws.GetContractorData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
               // gvItemTable.DataSource = ret.Contractor;
                gvItemTable.DataSource = ret;
                if (ret.Rows.Count == 0)
                {
                    // contracter1.Visible = false;
                    // contractor2.Visible = false;

                }
                gvItemTable.DataBind();
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

                if (txtnricno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where NRICno='" + txtnricno.Text + "' ";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and NRICno='" + txtnricno.Text + "' ";
                    }
                }
                if (txtrole.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where  Role='" + txtrole.Text + "' ";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and  Role='" + txtrole.Text + "'";
                    }
                }
                if (txtvehicleno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where vehicle_no='" + txtvehicleno.Text + "' ";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and vehicle_no='" + txtvehicleno.Text + "'";
                    }
                }
                if (txtkeyno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where key_no='" + txtkeyno.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and key_no='" + txtkeyno.Text + "'";
                    }
                }
                if (txtpasstype.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where pass_no='" + txtpasstype.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and pass_no='" + txtpasstype.Text + "'";
                    }
                }
                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where checkin_time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and checkin_time BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where checkin_time='" + txtdatefrom.Text + "'";
                        arr.Add("7");
                    }
                    else
                    {
                        str += " and checkin_time='" + txtdatefrom.Text + "'";
                    }
                }
                if (ddllocation.SelectedValue.Trim() != "")
                {
                    string result = getLocationIDByName1(ddllocation.SelectedValue.Trim());
                    if (arr.Count == 1)
                    {
                        str += " where Locationid ='" + result + "' ";
                        arr.Add("8");
                    }
                    else
                    {
                        str += " and Locationid ='" + result + "' ";
                    }
                }

                if (txtname.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where user_name='" + txtname.Text + "'";
                        arr.Add("9");
                    }
                    else
                    {
                        str += " and user_name='" + txtname.Text + "'";
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
                GetContractorData _req = new GetContractorData();
               // GetContractorDataResponse _resp = ws.GetContractorData(_req);

                DataTable _resp = ws.GetContractorData(_req);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
               // gvItemTable.DataSource = _resp.Contractor;
                gvItemTable.DataSource = _resp;
                if (_resp.Rows.Count == 0)
                {
                    // contracter1.Visible = false;
                    // contractor2.Visible = false;                   
                }
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
                if (Request.QueryString["curr"] != null)
                {
                    getLocationIDByName(ddllocation.Text.Trim());
                    BindGridWithFilterForCurrentContractor();
                }
                else
                {
                    getLocationIDByName(ddllocation.Text.Trim());
                    BindGridWithFilter();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
                        cn.Close();
                        dr.Close();

                    }
                }
                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (txtnricno.Text != "")
                    str = ("   NRIC/FIN No. : " + txtnricno.Text);
                if (txtvehicleno.Text != "")
                    str = ("   Vehicle No. : " + txtvehicleno.Text);
                if (txtpasstype.Text != "")
                    str = ("   Pass No. : " + txtpasstype.Text);
                if (txtkeyno.Text != "")
                    str = ("   Key No. : " + txtkeyno.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


                //Create Heading
                Phrase headerPhrase = new Phrase("                                     Contractor Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add("      Generated On : ");
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
                PdfPTable ptData = new PdfPTable(gvItemTable.Columns.Count);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvItemTable.Columns.Count]; // percentage


                headerwidths[0] = 4.2F;
                headerwidths[1] = 4.2F;
                headerwidths[2] = 4.2F;
                headerwidths[3] = 4.2F;
                headerwidths[4] = 4.2F;
                headerwidths[5] = 4.2F;
                headerwidths[6] = 4.2F;
                headerwidths[7] = 4.2F;
                //headerwidths[8] = 3.2F;
                //headerwidths[9] = 3.2F;

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

                for (int intJ = 0; intJ < gvItemTable.Rows.Count; intJ++)
                {
                    for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvItemTable.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
                        {
                            cell.Phrase = new Phrase(gvItemTable.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
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

                if (txtnricno.Text != "")
                    str = ("   NRIC/FIN No. : " + txtnricno.Text);
                if (txtvehicleno.Text != "")
                    str = ("   Vehicle No. : " + txtvehicleno.Text);
                if (txtpasstype.Text != "")
                    str = ("   Pass No. : " + txtpasstype.Text);
                if (txtkeyno.Text != "")
                    str = ("   Key No. : " + txtkeyno.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Contractor.html"));
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
                sw.Write("<CAPTION><b><font size='+2'>Contractor Report</font></b></CAPTION>");
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
                Int32 intcellCount = gvItemTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                //string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                if (txtnricno.Text != "")
                    str = ("   NRIC/FIN No. : " + txtnricno.Text);
                if (txtvehicleno.Text != "")
                    str = ("   Vehicle No. : " + txtvehicleno.Text);
                if (txtpasstype.Text != "")
                    str = ("   Pass No. : " + txtpasstype.Text);
                if (txtkeyno.Text != "")
                    str = ("   Key No. : " + txtkeyno.Text);
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Contractor.doc"));
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
                sw.Write("<CAPTION><b><font size='+2'>Contractor Report</font></b></CAPTION>");
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

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgBtnFromDate3_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = panel11;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            //Outlook.Application objOutlk = new Outlook.Application();
            ////Outlook
            //const int olMailItem = 0;
            //object objMail = new object();
            //objMail = objOutlk.CreateItem(olMailItem);
            ////Email item
            //objMail.To = emaila.Text;
            //objMail.cc = "";
            ////Enter an address here To include a carbon copy; bcc is For blind carbon copy's
            ////Set up Subject Line
            //objMail.subject = "Quality Assurance Letter";
            ////To add an attachment, use:
            ////objMail.attachments.add("C:\MyAttachmentFile.txt")
            //string msg;
            //msg = "body test msg";
            //objMail.body = msg;
            ////Use this To display before sending, otherwise call objMail.Send to send without reviewing
            //objMail.display();
            ////Use this To display before sending, otherwise call objMail.Send to send without reviewing
            ////Clean up
            //objMail = null;
            //objOutlk = null;
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            getLocationName();
            txtname.Text = "";
            txtnricno.Text = "";
            txtvehicleno.Text = "";
            txtpasstype.Text = "";
            txtkeyno.Text = "";
            txtdatefrom.Text = "";
            txtdateto.Text = "";
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //getLocationIDByName(ddllocation.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
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
    }
}