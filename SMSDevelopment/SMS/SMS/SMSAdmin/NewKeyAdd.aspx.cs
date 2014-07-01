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

using log4net;
using log4net.Config;
using System.Text.RegularExpressions;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DataService;


namespace SMS.SMSAdmin
{
    public partial class NewKeyAdd : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        int i = 0;
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtbunchNo.Focus();
                lblerror.Visible = false;
                lblerr1.Visible = false;
                lblerr2.Visible = false;

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


        private void AllClear()
        {
            txtbunchNo.Text = "";
            txtKeyDesc.Text = "";
            txtKeyName.Text = "";
            txtKeyNo.Text = "";
            txtKeyPosition.Text = "";
            ddllocation.Text = "";
            txtStaffiD.Text = "";

        }



        protected void btnClearKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AllClear();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnSearchKeyAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String ZipRegex = "^[0-9]+$";
                AddNewKeyRequest objAddNewKeyRequest = new AddNewKeyRequest();
                AdminAddNewKey objaddkey = new AdminAddNewKey();
                getLocationIDByName(ddllocation.SelectedValue.ToString());
                String q = txtbunchNo.Text;
                DataSet ds = dal.getdataset("select BunchNo from addnewkey where Location_ID='" + SearchLocID.Text + "' and BunchNo='" + txtbunchNo .Text+ "'");

                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (i = 0; i < count; i++)
                    {
                        String z = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (string.Equals(q, z, StringComparison.CurrentCultureIgnoreCase))
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Bunch No. already exist ..!";
                            lblerr1.Visible = true;
                            throw new Exception();
                        }
                    }
                }
                else
                {


                    String q1 = txtStaffiD.Text;
                    DataSet ds1 = dal.getdataset("select NRICno from UserInformation");
                    for (i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        String z = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (string.Equals(q1, z, StringComparison.CurrentCultureIgnoreCase))
                        {
                            getLocationIDByName(ddllocation.Text.Trim());
                            objaddkey.BunchNo = txtbunchNo.Text;
                            objaddkey.Description = txtKeyDesc.Text;
                            objaddkey.status = txtKeyStatus.Text;
                            objaddkey.name = txtKeyName.Text;
                            objaddkey.position = txtKeyPosition.Text;
                            objaddkey.NoOfKey = txtKeyNo.Text;
                            objaddkey.Staff_ID = txtStaffiD.Text;
                           // objaddkey.Location_ID = Convert.ToInt32(SearchLocID.Text);
                            objaddkey.Location_ID = SearchLocID.Text;
                            objaddkey.Date_From = Convert.ToDateTime(DateTime.Now);

                            AdminBLL ws = new AdminBLL();
                            ws.Add_NewKey(objaddkey);

                            lblerror.Visible = true;
                            lblerror.Text = "Insert Succesfully ..!";

                            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                            Server.Transfer("AlertUpdateComplete.aspx");

                        }
                    }

                    lblerror.Visible = true;
                    lblerror.Text = "Invalid NRICno ID ....!";
                    lblerr2.Visible = true;

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void filluserinfo()
        {
            DataSet ds = dal.getdataset("Select FirstName,Role from UserInformation where NRICno = '" + txtStaffiD.Text.Trim() + "' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtKeyName.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
                txtKeyPosition.Text = ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                txtKeyName.Text = "";
                txtKeyPosition.Text = "";
            }
        }

        protected void txtStaffiD_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                filluserinfo();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }






    }
}
