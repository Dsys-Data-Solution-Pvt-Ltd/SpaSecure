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

//using Microsoft.SqlServer.Management.Trace;
using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System;

namespace SMS.SuperVisor
{
    public partial class ViewPreRegisterVisitorReport : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    PopulatePageCntrls(id);
                }
            }
        }

        private void PopulatePageCntrls(int argsBGID)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsget = dal.getdataset("Select convert(varchar, FromDate, 101) as FromDate1,convert(varchar, ToDate, 101) as ToDate1,ExpectedTime,Name,Invited_By,Company,Position,LocationID,VechicleNo,Purpose,Telephoe from PreRegisteredVisits Where PRVID='" + argsBGID + "' ");
                if (dsget.Tables[0].Rows.Count > 0)
                {
                    txtInTime.Text = dsget.Tables[0].Rows[0][0].ToString().Trim();
                    txtOutTime.Text = dsget.Tables[0].Rows[0][1].ToString().Trim();
                    txtTime.Text = dsget.Tables[0].Rows[0][2].ToString().Trim();
                    txtname.Text = dsget.Tables[0].Rows[0][3].ToString().Trim();
                    txtinviteby.Text = dsget.Tables[0].Rows[0][4].ToString().Trim();
                    txtcompany.Text = dsget.Tables[0].Rows[0][5].ToString().Trim();
                    txtposition.Text = dsget.Tables[0].Rows[0][6].ToString().Trim();
                    string  locid = dsget.Tables[0].Rows[0][7].ToString().Trim();
                    getLocationNameById(locid);

                   txtvechicle.Text = dsget.Tables[0].Rows[0][8].ToString().Trim();
                   txtpurpose.Text = dsget.Tables[0].Rows[0][9].ToString().Trim();
                   txttelephone.Text = dsget.Tables[0].Rows[0][10].ToString().Trim();

                }
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
               txtlocation.Text = dsLocationName.Rows[0][0].ToString().Trim();
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
