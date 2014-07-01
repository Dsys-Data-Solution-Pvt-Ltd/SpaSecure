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

namespace SMS.SMSUsers
{
    public partial class ViewDigitalDairy : System.Web.UI.Page
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
                    cn.Close();
                    dr.Close();
                }
            }
            //---------------------------=---------------------------
            String iBTID = string.Empty;

            if (!IsPostBack)
            {
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
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DataSet dsdate = dal.getdataset("Select Dairy_date from Digital_Dairy Where DDID='" + argsBGID + "' ");
                if (dsdate.Tables[0].Rows.Count > 0)
                {
                    txtdate.Text = dsdate.Tables[0].Rows[0]["Dairy_date"].ToString().Trim();
                    int cout = 0;
                    DataSet dsget = dal.getdataset("Select * From Digital_Dairy Where Dairy_date='" + txtdate.Text + "' Order by time Asc ");
                    if (dsget.Tables[0].Rows.Count > 0)
                    {                       
                        txtName.Text = dsget.Tables[0].Rows[0]["Staff_id"].ToString().Trim();
                        txtheading.Text = dsget.Tables[0].Rows[0]["Heading"].ToString().Trim();
                        txttime.Text = dsget.Tables[0].Rows[0]["time"].ToString().Trim();
                        txtDescription.Text = dsget.Tables[0].Rows[0]["Description"].ToString().Trim();
                        cout++;
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label4.Text = dsget.Tables[0].Rows[1]["Staff_id"].ToString().Trim();
                            Label6.Text = dsget.Tables[0].Rows[1]["Heading"].ToString().Trim();
                            Label2.Text = dsget.Tables[0].Rows[1]["time"].ToString().Trim();
                            Label8.Text = dsget.Tables[0].Rows[1]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label12.Text = dsget.Tables[0].Rows[2]["Staff_id"].ToString().Trim();
                            Label14.Text = dsget.Tables[0].Rows[2]["Heading"].ToString().Trim();
                            Label10.Text = dsget.Tables[0].Rows[2]["time"].ToString().Trim();
                            Label16.Text = dsget.Tables[0].Rows[2]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label20.Text = dsget.Tables[0].Rows[3]["Staff_id"].ToString().Trim();
                            Label22.Text = dsget.Tables[0].Rows[3]["Heading"].ToString().Trim();
                            Label18.Text = dsget.Tables[0].Rows[3]["time"].ToString().Trim();
                            Label24.Text = dsget.Tables[0].Rows[3]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label28.Text = dsget.Tables[0].Rows[4]["Staff_id"].ToString().Trim();
                            Label30.Text = dsget.Tables[0].Rows[4]["Heading"].ToString().Trim();
                            Label26.Text = dsget.Tables[0].Rows[4]["time"].ToString().Trim();
                            Label32.Text = dsget.Tables[0].Rows[4]["Description"].ToString().Trim();
                            cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                            Label36.Text = dsget.Tables[0].Rows[5]["Staff_id"].ToString().Trim();
                            Label38.Text = dsget.Tables[0].Rows[5]["Heading"].ToString().Trim();
                            Label34.Text = dsget.Tables[0].Rows[5]["time"].ToString().Trim();
                            Label40.Text = dsget.Tables[0].Rows[5]["Description"].ToString().Trim();
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label44.Text = dsget.Tables[0].Rows[6]["Staff_id"].ToString().Trim();
                        Label46.Text = dsget.Tables[0].Rows[6]["Heading"].ToString().Trim();
                        Label42.Text = dsget.Tables[0].Rows[6]["time"].ToString().Trim();
                        Label48.Text = dsget.Tables[0].Rows[6]["Description"].ToString().Trim();
                             cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label52.Text = dsget.Tables[0].Rows[7]["Staff_id"].ToString().Trim();
                        Label54.Text = dsget.Tables[0].Rows[7]["Heading"].ToString().Trim();
                        Label50.Text = dsget.Tables[0].Rows[7]["time"].ToString().Trim();
                        Label56.Text = dsget.Tables[0].Rows[7]["Description"].ToString().Trim();
                         cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label60.Text = dsget.Tables[0].Rows[8]["Staff_id"].ToString().Trim();
                        Label62.Text = dsget.Tables[0].Rows[8]["Heading"].ToString().Trim();
                        Label58.Text = dsget.Tables[0].Rows[8]["time"].ToString().Trim();
                        Label64.Text = dsget.Tables[0].Rows[8]["Description"].ToString().Trim();
                        cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label68.Text = dsget.Tables[0].Rows[9]["Staff_id"].ToString().Trim();
                        Label70.Text = dsget.Tables[0].Rows[9]["Heading"].ToString().Trim();
                        Label66.Text = dsget.Tables[0].Rows[9]["time"].ToString().Trim();
                        Label72.Text = dsget.Tables[0].Rows[9]["Description"].ToString().Trim();
                             cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label76.Text = dsget.Tables[0].Rows[10]["Staff_id"].ToString().Trim();
                        Label78.Text = dsget.Tables[0].Rows[10]["Heading"].ToString().Trim();
                        Label74.Text = dsget.Tables[0].Rows[10]["time"].ToString().Trim();
                        Label80.Text = dsget.Tables[0].Rows[10]["Description"].ToString().Trim();
                              cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label84.Text = dsget.Tables[0].Rows[11]["Staff_id"].ToString().Trim();
                        Label86.Text = dsget.Tables[0].Rows[11]["Heading"].ToString().Trim();
                        Label82.Text = dsget.Tables[0].Rows[11]["time"].ToString().Trim();
                        Label88.Text = dsget.Tables[0].Rows[11]["Description"].ToString().Trim();
                          cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label92.Text = dsget.Tables[0].Rows[12]["Staff_id"].ToString().Trim();
                        Label94.Text = dsget.Tables[0].Rows[12]["Heading"].ToString().Trim();
                        Label90.Text = dsget.Tables[0].Rows[12]["time"].ToString().Trim();
                        Label96.Text = dsget.Tables[0].Rows[12]["Description"].ToString().Trim();
                          cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label100.Text = dsget.Tables[0].Rows[13]["Staff_id"].ToString().Trim();
                        Label102.Text = dsget.Tables[0].Rows[13]["Heading"].ToString().Trim();
                        Label98.Text = dsget.Tables[0].Rows[13]["time"].ToString().Trim();
                        Label104.Text = dsget.Tables[0].Rows[13]["Description"].ToString().Trim();
                               cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label108.Text = dsget.Tables[0].Rows[14]["Staff_id"].ToString().Trim();
                        Label110.Text = dsget.Tables[0].Rows[14]["Heading"].ToString().Trim();
                        Label106.Text = dsget.Tables[0].Rows[14]["time"].ToString().Trim();
                        Label112.Text = dsget.Tables[0].Rows[14]["Description"].ToString().Trim();
                          cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label116.Text = dsget.Tables[0].Rows[15]["Staff_id"].ToString().Trim();
                        Label118.Text = dsget.Tables[0].Rows[15]["Heading"].ToString().Trim();
                        Label114.Text = dsget.Tables[0].Rows[15]["time"].ToString().Trim();
                        Label120.Text = dsget.Tables[0].Rows[15]["Description"].ToString().Trim();
                               cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label124.Text = dsget.Tables[0].Rows[16]["Staff_id"].ToString().Trim();
                        Label126.Text = dsget.Tables[0].Rows[16]["Heading"].ToString().Trim();
                        Label122.Text = dsget.Tables[0].Rows[16]["time"].ToString().Trim();
                        Label128.Text = dsget.Tables[0].Rows[16]["Description"].ToString().Trim();
                               cout++;
                        }

                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label132.Text = dsget.Tables[0].Rows[17]["Staff_id"].ToString().Trim();
                        Label134.Text = dsget.Tables[0].Rows[17]["Heading"].ToString().Trim();
                        Label130.Text = dsget.Tables[0].Rows[17]["time"].ToString().Trim();
                        Label136.Text = dsget.Tables[0].Rows[17]["Description"].ToString().Trim();
                               cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label140.Text = dsget.Tables[0].Rows[18]["Staff_id"].ToString().Trim();
                        Label142.Text = dsget.Tables[0].Rows[18]["Heading"].ToString().Trim();
                        Label138.Text = dsget.Tables[0].Rows[18]["time"].ToString().Trim();
                        Label144.Text = dsget.Tables[0].Rows[18]["Description"].ToString().Trim();
                          cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label148.Text = dsget.Tables[0].Rows[19]["Staff_id"].ToString().Trim();
                        Label150.Text = dsget.Tables[0].Rows[19]["Heading"].ToString().Trim();
                        Label146.Text = dsget.Tables[0].Rows[19]["time"].ToString().Trim();
                        Label152.Text = dsget.Tables[0].Rows[19]["Description"].ToString().Trim();
                              cout++;
                        }
                         if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label156.Text = dsget.Tables[0].Rows[20]["Staff_id"].ToString().Trim();
                        Label158.Text = dsget.Tables[0].Rows[20]["Heading"].ToString().Trim();
                        Label154.Text = dsget.Tables[0].Rows[20]["time"].ToString().Trim();
                        Label160.Text = dsget.Tables[0].Rows[20]["Description"].ToString().Trim();
                               cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label164.Text = dsget.Tables[0].Rows[21]["Staff_id"].ToString().Trim();
                        Label166.Text = dsget.Tables[0].Rows[21]["Heading"].ToString().Trim();
                        Label162.Text = dsget.Tables[0].Rows[21]["time"].ToString().Trim();
                        Label168.Text = dsget.Tables[0].Rows[21]["Description"].ToString().Trim();
                              cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label172.Text = dsget.Tables[0].Rows[22]["Staff_id"].ToString().Trim();
                        Label174.Text = dsget.Tables[0].Rows[22]["Heading"].ToString().Trim();
                        Label170.Text = dsget.Tables[0].Rows[22]["time"].ToString().Trim();
                        Label176.Text = dsget.Tables[0].Rows[22]["Description"].ToString().Trim();
                              cout++;
                        }
                        if (dsget.Tables[0].Rows.Count > cout)
                        {
                        Label180.Text = dsget.Tables[0].Rows[23]["Staff_id"].ToString().Trim();
                        Label182.Text = dsget.Tables[0].Rows[23]["Heading"].ToString().Trim();
                        Label178.Text = dsget.Tables[0].Rows[23]["time"].ToString().Trim();
                        Label184.Text = dsget.Tables[0].Rows[23]["Description"].ToString().Trim();
                        cout++;
                        }    
                    }
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
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=700px,width=800px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}
