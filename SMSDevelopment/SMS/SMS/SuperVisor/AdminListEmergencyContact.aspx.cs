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
using SMS.master;
namespace SMS.SuperVisor
{
    public partial class AdminListEmergencyContact : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        fillLocation();
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                }
                string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                string ctrlname1 = Page.Request.Params.Get("__eventargument");
                if (ctrlname != null)
                {
                    string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                    if (!controlname.Contains("imdAdd")  && !controlname.Contains("imgDelete") &&!controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvPassTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGrid();
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
                    BindGrid();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #region Location
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
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
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
        #endregion

        #region Grid
        private void BindGrid()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string where = ReturnWhere();
                DataSet ds = dal.getdataset("select  location.Location_name as ln,EmergencyContact.Emg_id,EmergencyContact.name,EmergencyContact.Position,EmergencyContact.Mobile_No,EmergencyContact.Office_No,EmergencyContact.Home_No,EmergencyContact.Extension,EmergencyContact.DateFrom from EmergencyContact inner join location  on EmergencyContact.Location_id=location.Location_id " + where + " ");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
               // int pageSize = ContextKeys.GRID_PAGE_SIZE;
               // gvPassTable.PageSize = 25;
                gvPassTable.DataSource = ds.Tables[0];
                gvPassTable.DataBind();
                //}
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

                //if (txtdateto.Text != "" && txtdatefrom.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //        arr.Add("3");
                //    }
                //    else
                //    {
                //        str += " and DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                //    }
                //}
                //if (txtdatefrom.Text != "" && txtdateto.Text == "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where DateFrom ='" + txtdatefrom.Text + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and DateFrom ='" + txtdatefrom.Text + "'";
                //    }
                //}
                //if (txtname1.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Name ='" + txtname1.Text.Trim() + "'";
                //        arr.Add("3");
                //    }
                //    else
                //    {
                //        str += " and Name ='" + txtname1.Text.Trim() + "'";
                //    }
                //}
                //if (txtposition1.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Position ='" + txtposition1.Text.Trim() + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and Position ='" + txtposition1.Text.Trim() + "'";
                //    }
                //}
                //if (txtmobile.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Mobile_No ='" + txtmobile.Text.Trim() + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and Mobile_No ='" + txtmobile.Text.Trim() + "'";
                //    }
                //}

                //if (txtoffice.Text != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Office_No ='" + txtoffice.Text.Trim() + "'";
                //        arr.Add("4");
                //    }
                //    else
                //    {
                //        str += " and Office_No ='" + txtoffice.Text.Trim() + "'";
                //    }
                //}

                //if (ddllocation.Text.Trim() != "")
                //{
                //    if (arr.Count == 1)
                //    {
                //        str += " where Location_id ='" + searchid.Text + "'";
                //        arr.Add("5");
                //    }
                //    else
                //    {
                //        str += " and Location_id ='" + searchid.Text + "'";
                //    }
                //}

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvPassTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvPassTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvPassTable.Items[ro].Selected = true;


                        ViewState["PRVID"] = item.OwnerTableView.DataKeyValues[ro]["Emg_id"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }
        #endregion

        # region Icon menu

        #region Add
        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupAdd.Show();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
     
        public void ClearAdd()
        {
            txtGrade.Text = "";
            txthomeno.Text = "";
            txtName.Text = "";
            txtmobileno.Text = "";
            txtPosition.Text = "";
            txtofficeno.Text = "";
        }

     

        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtmobileno.Text.Trim() != "")
                {
                    if (txtName.Text.Trim() != "")
                    {
                        getLocationIDByName(ddllocation.Text.Trim());
                        SqlParameter[] para = new SqlParameter[8];
                        para[0] = new SqlParameter("@name", txtName.Text.Trim());
                        para[1] = new SqlParameter("@Position", txtPosition.Text.Trim());
                        para[2] = new SqlParameter("@Mobile_No", txtmobileno.Text.Trim());
                        para[3] = new SqlParameter("@Office_No", txtofficeno.Text.Trim());
                        para[4] = new SqlParameter("@Home_No", txthomeno.Text.Trim());
                        para[5] = new SqlParameter("@Extension", txtGrade.Text.Trim());
                        para[6] = new SqlParameter("@DateFrom", DateTime.Now);
                        para[7] = new SqlParameter("@Location_id", searchid.Text);

                        int re= dal.executeprocedure("SP_AddEmergencyContact", para);
                        if (re > 0)
                        {

                            //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                            SpaMaster mymaster =(SpaMaster)Page.Master;
                            mymaster.ShowErrorMessage("Record Inserted SuccessFully..!");
                           
                            BindGrid();
                            ClearAdd();
                            //this.ModalPopupAdd.Hide();
                        }
                        else
                        {
                             SpaMaster mymaster =(SpaMaster)Page.Master;
                            mymaster.ShowErrorMessage("Failed To Insert Record..!");// "AlertMessage", " alert('Failed To Insert Record');", true);
                        }
                       // HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        //Server.Transfer("CompleteForm.aspx");
                    }
                    else
                    {
                        //lblerror.Visible = true;
                        //lblerror.Text = "Please Fill Name...!";
                         SpaMaster mymaster =(SpaMaster)Page.Master;
                            mymaster.ShowErrorMessage("Please Fill Name..!");// "AlertMessage", " alert('Please Fill Name...!');", true);
                    }
                }
                else
                {
                    //lblerror.Visible = true;
                    //lblerror.Text = "Please Fill Contact Name...!";
                     SpaMaster mymaster =(SpaMaster)Page.Master;
                            mymaster.ShowErrorMessage("Please Fill Contact Name..!");// "AlertMessage", " alert('Please Fill Contact Name...!');", true);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ClearAdd();
                this.ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ddllocation_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Searchid1.Text = ddllocation.Text;
        }
        #endregion


        # region Delete
        private void DeleteItem(string argPassID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("Delete from EmergencyContact where Emg_id = '" + argPassID + "'");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["PRVID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (ViewState["PRVID"] != null)
                {
                    DeleteItem(ViewState["PRVID"].ToString());
                    BindGrid();
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully ..!");   
                    this.ModalPopupDelete.Hide();
                
                }
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
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
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }

        #endregion


        #endregion

        #region Download
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

                //if (txtnricno.Text != "")
                //    str = ("   NRIC/FIN No. : " + txtnricno.Text);
                //if (txtvehicleno.Text != "")
                //    str = ("   Vehicle No. : " + txtvehicleno.Text);
                //if (txtpasstype.Text != "")
                //    str = ("   Pass No. : " + txtpasstype.Text);
                //if (txtkeyno.Text != "")
                //    str = ("   Key No. : " + txtkeyno.Text);
                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);


                ////Create Heading

                Phrase headerPhrase = new Phrase("                             Emergency Contact Report                                                       ", FontFactory.GetFont("Garamond", 14));

                headerPhrase.Add(" Generated On : ");
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
                PdfPTable ptData = new PdfPTable(gvPassTable.Columns.Count-1);
                ptData.SpacingBefore = 8;
                ptData.DefaultCell.Padding = 1;

                float[] headerwidths = new float[gvPassTable.Columns.Count-1]; // percentage


                headerwidths[0] = 4.2F;
                headerwidths[1] = 4.2F;
                headerwidths[2] = 4.2F;
                headerwidths[3] = 4.2F;
                headerwidths[4] = 4.2F;
                headerwidths[5] = 4.2F;
                headerwidths[6] = 4.2F;
              //  headerwidths[7] = 4.2F;
                //headerwidths[8] = 3.2F;
                //headerwidths[9] = 3.2F;

                ptData.SetWidths(headerwidths);
                ptData.WidthPercentage = 100;
                ptData.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                ptData.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Insert the Table Headers
                for (int intK = 0; intK < gvPassTable.Columns.Count-1; intK++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BorderWidth = 0.001f;
                    cell.BackgroundColor = new Color(200, 200, 200);
                    cell.BorderColor = new Color(100, 100, 100);
                    if (gvPassTable.Columns[intK+1].HeaderText.ToString() != "")
                    {
                        cell.Phrase = new Phrase(gvPassTable.Columns[intK+1].HeaderText.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 7, Font.BOLD));
                        ptData.AddCell(cell);
                    }
                    else { ptData.AddCell(cell); }
                   
                }

                ptData.HeaderRows = 1;  // this is the end of the table header

                //Insert the Table Data

                for (int intJ = 0; intJ < gvPassTable.Items.Count; intJ++)
                {
                    for (int intK = 0; intK < gvPassTable.Columns.Count-1; intK++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BorderWidth = 0.001f;
                        cell.BorderColor = new Color(100, 100, 100);
                        cell.BackgroundColor = new Color(250, 250, 250);
                        if (gvPassTable.Items[intJ].Cells[intK+3].Text.ToString() != "")
                        {
                            cell.Phrase = new Phrase(gvPassTable.Items[intJ].Cells[intK+3].Text.ToString(), FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                            ptData.AddCell(cell);
                        }
                        //else
                        //{
                        //    cell.Phrase = new Phrase("", FontFactory.GetFont("TIMES_ROMAN", BaseFont.WINANSI, 6));
                        //    ptData.AddCell(cell);
                        //}
                       
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
        public void DownloadWordFormat()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Int32 intcellCount = gvPassTable.Columns.Count;
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
                        cn.Close();
                        dr.Close();

                    }
                }
                //string filePath = Server.MapPath("../../Images/Untitled.png");
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(filePath);
                string width = "100px";
                string height = "100px";
                string imagepath = string.Format("<img src='{0}' width='{1}' height='{2}'/>", filePath, width, height);
                Response.Write("<Center><table border='0'></Center>");
                Response.Write("<tr><td>" + imagepath + "</td></tr>");
                Response.Write("</table>");
                imgPhoto.Dispose();
                Response.Flush();
                sw.Write("<b><hr></hr></b>");

                sw.Write("<CAPTION><b><font size='+2'>Emergency Contact Report</font></b></CAPTION>");
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
                    strHeaderText = gvPassTable.Columns[i].HeaderText.ToString();
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

                foreach (GridDataItem grvRow in gvPassTable.Items)
                {
                    sw.Write("<tr>");
                    for (Int32 i = 0; i < intcellCount; i++)
                    {
                        strContent = grvRow.Cells[i+2].Text.ToString();
                        if (strContent!="")
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
                int iColCount = gvPassTable.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(gvPassTable.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");

                    }
                }

                sw.Write(sw.NewLine);
                // Write all the rows.
                foreach (GridViewRow grv in gvPassTable.Items)
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
                Int32 intcellCount = gvPassTable.Columns.Count;
                string strContent = "";
                string strHeaderText = "";
                string strHtmlFile = "TxnHtmlFile";
                Response.ClearHeaders();
                Response.ClearContent();

                string datetime = string.Empty;
                datetime = Convert.ToString(System.DateTime.Now);

                string str = string.Empty;

                //if (txtnricno.Text != "")
                //    str = ("   NRIC/FIN No. : " + txtnricno.Text);
                //if (txtvehicleno.Text != "")
                //    str = ("   Vehicle No. : " + txtvehicleno.Text);
                //if (txtpasstype.Text != "")
                //    str = ("   Pass No. : " + txtpasstype.Text);
                //if (txtkeyno.Text != "")
                //    str = ("   Key No. : " + txtkeyno.Text);
                //if (txtdatefrom.Text != "" && txtdateto.Text != "")
                //    str = ("   Date  From :" + txtdatefrom.Text + "      To :" + txtdateto.Text);





                //Response.AddHeader("content-disposition", string.Format("attachment;filename=" + ConfigurationManager.AppSettings["TxnInfoHtmlFile"]));
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Contractor.html"));
                Response.Charset = "";
                Response.ContentType = "text/html";
                StringWriter sw = new StringWriter();
                sw.Write("<table border =1>");
                sw.Write("<CAPTION><b>Emergency Contact Report</b></CAPTION>");
                sw.Write("Generated On : ");
                sw.Write(datetime);
                sw.Write("<CAPTION><br/></CAPTION>");
                sw.Write("Searching Parameter : ");
                sw.Write(str);



                sw.Write("<tr>");
                for (int i = 0; i < intcellCount; i++)
                {
                    strHeaderText = gvPassTable.Columns[i].HeaderText.ToString();
                    sw.Write("<th>");
                    sw.Write(strHeaderText);
                    sw.Write("</th>");
                    sw.Write("<td>");
                    sw.Write("&nbsp");
                    sw.Write("</td>");

                }
                sw.Write("</tr>");

                foreach (GridViewRow grvRow in gvPassTable.Items)
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
        #endregion

        #region Unused code
        protected void gvPass_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    gvPassTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                if (e.CommandName == "EditRow")
                {
                    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                    Server.Transfer("UpdateEmergencyContact.aspx");
                }
                //if (e.CommandName == "View")
                //{
                //    if (ddllocation.Text.Trim() != "")
                //    {
                //        getLocationIDByName(ddllocation.Text.Trim());

                //        Server.Transfer("ListEmergencyNo.aspx?id" + searchid);
                //    }
                //    else
                //    {
                //        lblerror.Visible = true;
                //        lblerror.Text = "Please Select The Location";
                //    }
                //}
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

       

        protected void gvPass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                   
                    DataSet dspenalty = dal.getdataset("Select * from EmergencyContact");
                    if (dspenalty.Tables[0].Rows.Count > 0)
                    {
                        int pageSize = ContextKeys.GRID_PAGE_SIZE;
                        gvPassTable.PageSize = 25;
                        gvPassTable.DataSource = dspenalty.Tables[0];
                        gvPassTable.DataBind();
                    }
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void gvPassTable_SelectedIndexChanged(object sender, EventArgs e)
        {
        }




        protected void btnAddnewIncident_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("../SuperVisor/AddNewEmergencyContact.aspx");
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
                getLocationIDByName(ddllocation.Text.Trim());
                BindGrid();
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                txtmobile.Text = "";
                txtname1.Text = "";
                txtoffice.Text = "";
                txtposition1.Text = "";
                getLocationName();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        #endregion

    }
}
