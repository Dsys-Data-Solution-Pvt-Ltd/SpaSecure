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
using SMS.Services.DataService;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities.Authorization;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace SMS.SuperVisor
{
    public partial class AssignmentVisitReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            String iBTID = string.Empty;

            if (!IsPostBack)
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
                        cn.Close();
                        dr.Close();
                    }
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                {
                    string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                    //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                }
                if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                {
                    iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                }

                PopulatePageCntrls(iBTID);
            }
        }

        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsgetvalue = dal.getdataset("Select strTo,strSubmittedBy,strNameOfAssignment,strInCharge,strDressing,strAppearance,strHaircut,strAlertness,strDeployment,strGeneralPerformance,strOtherMatters,strConclussion,strRecommendation,strGuards1,strGuards2,strGuards3,strGuards4,strGuards5,strGuards6,strGuards7,strGuards8,strGuards9,strGuards10,dtmDateVisit from tblAssignmentVisit where intID='" + argsBGID.ToString() + "'");
                if (dsgetvalue.Tables[0].Rows.Count > 0)
                {

                    txtTo.Text = dsgetvalue.Tables[0].Rows[0][0].ToString().Trim();
                    txtTo.Visible = false;
                    txtsubmittedby.Text = dsgetvalue.Tables[0].Rows[0][1].ToString().Trim();
                    txtNameofAssignment.Text = dsgetvalue.Tables[0].Rows[0][2].ToString().Trim();
                    txtIC.Text = dsgetvalue.Tables[0].Rows[0][3].ToString().Trim();
                    txtdressing.Text = dsgetvalue.Tables[0].Rows[0][4].ToString().Trim();
                    txtappearance.Text = dsgetvalue.Tables[0].Rows[0][5].ToString().Trim();
                    txthaircut.Text = dsgetvalue.Tables[0].Rows[0][6].ToString().Trim();
                    txtAlertness.Text = dsgetvalue.Tables[0].Rows[0][7].ToString().Trim();

                    txtDeployment.Text = dsgetvalue.Tables[0].Rows[0][8].ToString().Trim();
                    txtgeneralPerformance.Text = dsgetvalue.Tables[0].Rows[0][9].ToString().Trim();
                    txtotherMatters.Text = dsgetvalue.Tables[0].Rows[0][10].ToString().Trim();
                    txtconclustion.Text = dsgetvalue.Tables[0].Rows[0][11].ToString().Trim();
                    txtrecommendation.Text = dsgetvalue.Tables[0].Rows[0][12].ToString().Trim();

                    txtGuard1.Text = dsgetvalue.Tables[0].Rows[0][13].ToString().Trim();
                    txtGuard2.Text = dsgetvalue.Tables[0].Rows[0][14].ToString().Trim();
                    txtGuard3.Text = dsgetvalue.Tables[0].Rows[0][15].ToString().Trim();
                    txtGuard4.Text = dsgetvalue.Tables[0].Rows[0][16].ToString().Trim();
                    txtGuard5.Text = dsgetvalue.Tables[0].Rows[0][17].ToString().Trim();

                    txtGuard6.Text = dsgetvalue.Tables[0].Rows[0][18].ToString().Trim();
                    txtGuard7.Text = dsgetvalue.Tables[0].Rows[0][19].ToString().Trim();
                    txtGuard8.Text = dsgetvalue.Tables[0].Rows[0][20].ToString().Trim();
                    txtGuard9.Text = dsgetvalue.Tables[0].Rows[0][21].ToString().Trim();
                    txtGuard10.Text = dsgetvalue.Tables[0].Rows[0][22].ToString().Trim();

                    txtdateofvisit.Text = dsgetvalue.Tables[0].Rows[0][23].ToString().Trim();

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
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=800px,width=900px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnpdfprint_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //DownloadPDFFormat();
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

                //Create Heading
                Phrase headerPhrase = new Phrase("Assignment Visit Report", FontFactory.GetFont("TIMES_ROMAN", 16));
                HeaderFooter header = new HeaderFooter(headerPhrase, false);
                header.Border = Rectangle.NO_BORDER;
                header.Alignment = Element.ALIGN_CENTER;
                header.Alignment = Element.ALIGN_BOTTOM;
                pdfReport.Header = header;
                pdfReport.Add(headerPhrase);

                

                // Creates the Table
                PdfPTable ptData = new PdfPTable(2);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[2]; // percentage


                headerwidths[0] = 3.2F;
                headerwidths[1] = 3.2F;
                //headerwidths[2] = 3.2F;
                //headerwidths[3] = 3.2F;
                //headerwidths[4] = 3.2F;
                //headerwidths[5] = 3.2F;
                //headerwidths[6] = 3.2F;
                //headerwidths[7] = 3.2F;
                //headerwidths[8] = 3.2F;
                //headerwidths[9] = 3.2F;
                //headerwidths[10] = 3.2F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                //for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                //{
                //    PdfPCell cell = new PdfPCell();
                //    cell.BorderWidth = 0.001f;
                //    cell.BackgroundColor = new Color(200, 200, 200);
                //    cell.BorderColor = new Color(100, 100, 100);
                //    cell.Phrase = new Phrase(gvItemTable.Columns[intK].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                //    ptData.AddCell(cell);
                //}
                PdfPCell cell = new PdfPCell();
                cell.BorderWidth = 0.001f;
                cell.BackgroundColor = new Color(200, 200, 200);
                cell.BorderColor = new Color(100, 100, 100);
                cell.Phrase = new Phrase("TO :", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                ptData.AddCell(cell);
                
                PdfPCell cell1 = new PdfPCell();
                cell1.BorderWidth = 0.001f;
                cell1.BorderColor = new Color(100, 100, 100);
                cell1.BackgroundColor = new Color(250, 250, 250);
                if (txtTo.Text.ToString() != "&nbsp;")
                {
                    cell1.Phrase = new Phrase(txtTo.Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                }
                else
                {
                    cell1.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                }
                ptData.AddCell(cell1);

                PdfPCell cell12 = new PdfPCell();
                cell12.BorderWidth = 0.001f;
                cell12.BorderColor = new Color(100, 100, 100);
                cell12.BackgroundColor = new Color(250, 250, 250);

                if (txtsubmittedby.Text.ToString() != "&nbsp;")
                {
                    cell12.Phrase = new Phrase(txtsubmittedby.Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                }
                else
                {
                    cell12.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                }
                ptData.AddCell(cell12);   


                PdfPCell cell11 = new PdfPCell();
                cell11.BorderWidth = 0.001f;
                cell11.BackgroundColor = new Color(200, 200, 200);
                cell11.BorderColor = new Color(100, 100, 100);
                cell11.Phrase = new Phrase("Report Submitted By :", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                ptData.AddCell(cell11);



                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                //for (int intJ = 0; intJ < gvItemTable.Rows.Count; intJ++)
                //{
                //    for (int intK = 0; intK < gvItemTable.Columns.Count; intK++)
                //    {
                //        PdfPCell cell = new PdfPCell();
                //        cell.BorderWidth = 0.001f;
                //        cell.BorderColor = new Color(100, 100, 100);
                //        cell.BackgroundColor = new Color(250, 250, 250);
                //        if (gvItemTable.Rows[intJ].Cells[intK].Text.ToString() != "&nbsp;")
                //        {
                //            cell.Phrase = new Phrase(gvItemTable.Rows[intJ].Cells[intK].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                //        }
                //        else
                //        {
                //            cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                //        }
                //        ptData.AddCell(cell);
                //    }
                //}

                //Insert the Table

                
                
                pdfReport.Add(ptData);

                //Closes the Report and writes to Memory Stream

               // pdfReport.Add("ggggg");

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

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
