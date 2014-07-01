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
    public partial class UserReport : System.Web.UI.Page
    {        
        AdminDAL a = new AdminDAL();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
         log4net.ILog logger = log4net.LogManager.GetLogger("File");
         try
         {
             txtuserid.Focus();

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
                    Server.Transfer("../smsadmin/UserUpdate.aspx");
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
                    AdminDAL w = new AdminDAL();

                    SqlConnection conn = new SqlConnection();
                    conn = w.getconnection();
                    DeleteUserRequest _req = new DeleteUserRequest();

                    _req.UserNo = argEmbossId.ToString();
                    string id = argEmbossId.ToString();
                    string query = "select top 1 ImagePathName from Userinformation name where userid='" + id + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader rd = cmd.ExecuteReader();
                    string s = string.Empty;                 

                    ws.DeleteUser(_req);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                    //===================================//
                    rd.Close();
                    //===================================//
                    Server.Transfer("../smsadmin/AlertUpdateComplete.aspx");
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
                    BindGridWithFilter();
                    AdminBLL ws = new AdminBLL();
                    GetUserData _req = new GetUserData();
                    GetUserDataResponse _resp = ws.GetUserInfoData(_req);


                    int pageSize = ContextKeys.GRID_PAGE_SIZE;
                    gvItemTable.PageSize = pageSize;
                    gvItemTable.DataSource = _resp.UserID;

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
                GetUserData objReq = new GetUserData();
               
                string WhereClause = ReturnWhere();
                if (!string.IsNullOrEmpty(txtuserid.Text))
                {
                    objReq.UserID = txtuserid.Text;
                }
                     
                if (!string.IsNullOrEmpty(txtfirstname.Text))
                {
                    objReq.FirstName = txtfirstname.Text;
                }
                if (!string.IsNullOrEmpty(txtrole.Text))
                {
                    objReq.Role = txtrole.Text;
                }
                if (!string.IsNullOrEmpty(txtnricno.Text))
                {
                    objReq.NRICno = txtnricno.Text;
                }

                if (!string.IsNullOrEmpty(WhereClause))
                {
                    objReq.WhereClause = WhereClause;
                }
                
                if (!string.IsNullOrEmpty(txtdateto.Text))
                {
                    if (!string.IsNullOrEmpty(txtdatefrom.Text))
                    {
                        objReq.LastLoginTime = txtdatefrom.Text;
                        objReq.LastLoginTime = txtdatefrom.Text;
                    }
                }

                if (!string.IsNullOrEmpty(txtdatefrom.Text))
                {
                    if (string.IsNullOrEmpty(txtdateto.Text))
                    {
                        objReq.LastLoginTime = txtdatefrom.Text;
                    }
                }
                
                GetUserDataResponse ret = ws.GetUserInfoData(objReq);
               
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = ret.UserID;
                if (ret.UserID.Count == 0)
                {
                   // userid.Visible = false;
                }
                gvItemTable.DataBind();
                userid.Text = ret.UserID.Count.ToString();

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

                if (txtuserid.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        makeWhereClause = " where ";
                        str += " where UserID ='" + txtuserid.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and UserID ='" + txtuserid.Text + "'";
                    }
                }
              
                if (txtfirstname.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where FirstName ='" + txtfirstname.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and FirstName ='" + txtfirstname.Text + "'";
                    }
                }
                if (txtrole.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Role ='" + txtrole.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and Role ='" + txtrole.Text + "'";
                    }
                }
                if (txtnricno.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where NRICno ='" + txtnricno.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and NRICno ='" + txtnricno.Text + "'";
                    }
                }

                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where LastLoginTime BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and LastLoginTime BETWEEN'" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }

                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where LastLoginTime='" + txtdatefrom.Text + "'";
                        arr.Add("7");
                    }
                    else
                    {
                        str += " and LastLoginTime='" + txtdatefrom.Text + "'";
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
                GetUserData _req = new GetUserData();
                GetUserDataResponse _resp = ws.GetUserInfoData(_req);
               

                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvItemTable.PageSize = pageSize;
                gvItemTable.DataSource = _resp.UserID;
                if (_resp.UserID.Count == 0)
                {
                    userid.Visible = false;
                }
                gvItemTable.DataBind();
            }
            catch (Exception ex)
              {
                logger.Info(ex.Message);
              }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void gvItemTable_SelectedIndexChanged(object sender, EventArgs e)
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

                if (txtuserid.Text != "")
                    str = ("   User ID : " + txtuserid.Text);
                if (txtfirstname.Text != "")
                    str = ("    First Name : " + txtfirstname.Text);
                if (txtrole.Text != "")
                    str = ("    Role : " + txtrole.Text);
                if (txtnricno.Text != "")
                    str = ("    NRIC/FIN No. : " + txtnricno.Text);
               
                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From : " + txtdatefrom.Text + "      To :" + txtdateto.Text);



                Phrase headerPhrase = new Phrase("User Report                                                       ", FontFactory.GetFont("Garamond", 14));

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

                if (txtuserid.Text != "")
                    str = ("   User ID : " + txtuserid.Text);
                if (txtfirstname.Text != "")
                    str = ("    First Name : " + txtfirstname.Text);
                if (txtrole.Text != "")
                    str = ("    Role : " + txtrole.Text);
                if (txtnricno.Text != "")
                    str = ("    NRIC/FIN No. : " + txtnricno.Text);

                if (txtdatefrom.Text != "" && txtdateto.Text != "")
                    str = ("   Date  From : " + txtdatefrom.Text + "      To :" + txtdateto.Text);




                Response.AddHeader("content-disposition", string.Format("attachment;filename=testhtml.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>User Report</b></CAPTION>");

                sw.Write("Generated On : ");
                sw.Write(datetime);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("Searching Parameter : ");
                sw.Write(str);



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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtfirstname.Text = "";
            txtrole.Text = "";
            txtnricno.Text = "";
           
            txtdatefrom.Text = "";
            txtdateto.Text = "";
        }
    }
}
