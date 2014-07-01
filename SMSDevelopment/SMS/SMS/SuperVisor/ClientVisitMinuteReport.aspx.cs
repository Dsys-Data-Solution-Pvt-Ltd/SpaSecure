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
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;

namespace SMS.SuperVisor
{
    public partial class ClientVisitMinuteReport : System.Web.UI.Page
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

            DataSet dspan = dal.getdataset("Select Location,CompletedBy,Date,ClientName,Complaints,PositiveComment,Deployment,UpcomingEvent,Remarks from tblClientVisitMinutes where strCVID = '" + argsBGID + "' ");
            if (dspan.Tables[0].Rows.Count > 0)
            {

                ddlocation.Text = dspan.Tables[0].Rows[0][0].ToString().Trim();
                txtcompletedby.Text = dspan.Tables[0].Rows[0][1].ToString().Trim();
                txtdatefrom.Text = dspan.Tables[0].Rows[0][2].ToString().Trim();
                txtClientName.Text = dspan.Tables[0].Rows[0][3].ToString().Trim();

                txtcomplaints.Text = dspan.Tables[0].Rows[0][4].ToString().Trim();
                txtpositivecomments.Text = dspan.Tables[0].Rows[0][5].ToString().Trim();
                txtdeployment.Text = dspan.Tables[0].Rows[0][6].ToString().Trim();
                txtupcomingevent.Text = dspan.Tables[0].Rows[0][7].ToString().Trim();

                txtremarks.Text = dspan.Tables[0].Rows[0][8].ToString().Trim();
                
            }

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




    











    }
}
