using System;
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
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Collections;


namespace SMS.ADMIN
{
    public partial class AdminInventoryOut : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {               
                if (!IsPostBack)
                {
                    FillItemType();
                    BindGridWithFilter();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void FillItemType()
        {           
            string ID = "Item_Type";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dsInventory = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
            if (dsInventory.Rows.Count > 0)
            {
                ddItemType.DataSource = dsInventory;
                ddItemType.DataTextField = "Description";
                ddItemType.DataValueField = "Description";
                ddItemType.DataBind();
                ddItemType.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" ", " ", true));
            }
        }

        private void BindGridWithFilter()
        {
            string where = ReturnWhere();

            DataSet dsfillgrid = dal.getdataset("Select * from vwInventoryOut "+where+" ");
            if (dsfillgrid.Tables[0].Rows.Count > 0)
            {
                gvLoctionTable.PageIndex = dal.gridpageindex;
                int pageSize = 20;
                gvLoctionTable.PageSize = pageSize;
                gvLoctionTable.DataSource = dsfillgrid.Tables[0];
                gvLoctionTable.DataBind();             
            }
            else
            {
                gvLoctionTable.DataSource = null;
                gvLoctionTable.DataBind();
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
                if (ddItemType.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where Item_Type ='" + ddItemType.Text + "'";
                        arr.Add("1");
                    }
                    else
                    {
                        str += " and Item_Type ='" + ddItemType.Text + "'";
                    }
                }
                if (txtserialNo.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where SerialNo ='" + txtserialNo.Text + "'";
                        arr.Add("2");
                    }
                    else
                    {
                        str += " and SerialNo ='" + txtserialNo.Text + "'";
                    }
                }

                if (txtdateto.Text != "" && txtdatefrom.Text != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                        arr.Add("3");
                    }
                    else
                    {
                        str += " and DateFrom BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
                    }
                }
                if (txtdatefrom.Text != "" && txtdateto.Text == "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where DateFrom ='" + txtdatefrom.Text + "'";
                        arr.Add("4");
                    }
                    else
                    {
                        str += " and DateFrom ='" + txtdatefrom.Text + "'";
                    }
                }
                if (txtnric.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where NRICno ='" + txtnric.Text + "'";
                        arr.Add("5");
                    }
                    else
                    {
                        str += " and NRICno ='" + txtnric.Text + "'";
                    }
                }
                if (txtName.Text.Trim() != "")
                {
                    if (arr.Count == 1)
                    {
                        str += " where FirstName ='" + txtName.Text + "'";
                        arr.Add("6");
                    }
                    else
                    {
                        str += " and FirstName ='" + txtName.Text + "'";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return (str);
        }

        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
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

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtdatefrom.Text = "";
                txtdateto.Text = "";
                txtserialNo.Text = "";
                txtName.Text = "";
                txtnric.Text = "";
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnNewInventoryOut_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddNewInventoryOut.aspx");
            }
            catch (Exception ex)
            {
            }
        }       

        protected void gvLoctionTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {             
                string WhereClause = string.Empty;
                if (e.NewPageIndex >= 0)
                {
                    dal.gridpageindex = e.NewPageIndex;
                    BindGridWithFilter();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsData = dal.getdataset("Select * from vwInventoryOut");

                string HTMLData = GenerateReportHTML(dsData.Tables[0]);
                string path = CreateNewPDF(HTMLData);              
                Session["ReportType"] = "DOCTORPAYREPORT";
                path = "ReportViewer01.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "pop", "javascript:window.open('" + path + "')", true);
              
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected string GenerateReportHTML(DataTable dtData)
        {
            string HTMLData = string.Empty;

           // objDoctorMasterDAL = new DoctorMasterDAL();
           // DataTable dtData = objDoctorMasterDAL.GetTemPayment().Tables[0];

            HTMLData = "<h2>Inventory Out Report </h2><br/><br/>";
            HTMLData += "<h3>Date : " + DateTime.Now + " </h3><br/>";
            HTMLData += "<table border = \"1\" cellspacing = \"2\" cellpadding = \"2\">";
            HTMLData += @"<tr> 
                            <th>Issued Date</th>
                            <th>Item Type</th>
                            <th>Item Details</th>
                            <th>Balance quantity</th>
                            <th>Issue quantity</th>
                            <th>Issue To</th>
                            <th>NRICno.</th>
                            <th>Role</th>                            
                            <th>Serial No.</th>
                            <th>Model No.</th>
                            
                            ";

            if (dtData != null && dtData.Rows.Count > 0)
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    HTMLData += "<tr>";

                    HTMLData += "<td style=\"Width:100px\">" + dtData.Rows[i]["FromDate"].ToString() + "</td>";
                    HTMLData += "<td style=\"Width:70px\">" + dtData.Rows[i]["Item_Type"].ToString() + "</td>";
                    HTMLData += "<td>" + dtData.Rows[i]["Item_Name"].ToString() + "</td>";
                    HTMLData += "<td  style=\"Width:70px\">" + dtData.Rows[i]["Balaceqty"].ToString() + "</td>";
                    HTMLData += "<td>" + dtData.Rows[i]["Item_Qty"].ToString() + "</td>";
                    HTMLData += "<td style=\"Width:110px\">" + dtData.Rows[i]["FirstName"].ToString() + "</td>";
                    HTMLData += "<td>" + dtData.Rows[i]["NRICno"].ToString() + "</td>";
                    HTMLData += "<td style=\"Width:100px\">" + dtData.Rows[i]["Role"].ToString() + "</td>";
                    HTMLData += "<td>" + dtData.Rows[i]["SerialNo"].ToString() + "</td>";
                    HTMLData += "<td>" + dtData.Rows[i]["ModelNo"].ToString() + "</td>";


                    HTMLData += "</tr>";
                }
                HTMLData += "</table>";
            }
            else
            {
                HTMLData = string.Empty;
            }
            return HTMLData;
        }
        private string CreateNewPDF(string HTMLData)
        {
            string SavePath = "Reports/PDFReports/";
            string FileName = "InventoryOut.pdf";
            Document doc = new Document(PageSize.LETTER, 75, 75, 75, 75);
            PdfWriter.GetInstance(doc, (new FileStream(Server.MapPath(SavePath + FileName), FileMode.Create)));
            doc.Open();
           // List<IElement> htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(HTMLData), null);
            ArrayList htmlaarrylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(HTMLData), null);
            for (int k = 0; k < htmlaarrylist.Count; k++)
            {
                doc.Add((IElement)htmlaarrylist[k]);
            }
            doc.Close();
            return Server.MapPath(SavePath + FileName);
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsData = dal.getdataset("Select * from vwInventoryOut");

                string HTMLData = GenerateReportHTML(dsData.Tables[0]);
                string path = CreateNewPDF(HTMLData);
           
                Session["ReportType"] = "DOCTORPAYREPORT";
                path = "ExcelReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "pop", "javascript:window.open('" + path + "')", true);
                
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
    }
}
