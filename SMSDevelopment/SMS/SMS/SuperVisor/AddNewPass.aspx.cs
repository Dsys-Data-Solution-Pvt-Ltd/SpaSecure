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

namespace SMS.SuperVisor
{
    public partial class PassMgt : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txtAddNoType.Focus();
                lblerror.Visible = false;
                lblerr1.Visible = false;
                lblerr2.Visible = false;
                lblerr3.Visible = false;
                lblerr5.Visible = false;

                if (!IsPostBack)
                {
                    getPassType("passtype");

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

        private void getPassType(string ID)
        {
            ddlAddPassType.Items.Clear();
            ddlAddPassType.Items.Add(" ");
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@pass_Type", ID);
            DataTable dtpasstype = dal.executeprocedure("sp_FillValueBylog", para, false);

            if (dtpasstype.Rows.Count > 0)
            {
                for (int k = 0; k < dtpasstype.Rows.Count; k++)
                {
                    ddlAddPassType.Items.Add(dtpasstype.Rows[k][0].ToString());
                }
            }
        }
        private void GetStaffInfo(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtKeyName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtposition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtKeyName.Text = "";
                txtposition.Text = "";
            }

        }

        private int GetLocationIdbyName(string name)
        {
            int locid = 0;
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", name);

            DataTable dtLocationid = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dtLocationid.Rows.Count > 0)
            {
                locid = Convert.ToInt32(dtLocationid.Rows[0][0].ToString().Trim());
                return locid;
            }
            return locid;
        }





        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewPassRequest objAddPass = new AddNewPassRequest();
                Pass ObjPass = new Pass();

                if (ddlAddPassType.Text.Trim() != "" && txtAddNoType.Text.Trim() != "")
                {
                    String q1 = txtKeyNRIC.Text.Trim();
                    DataSet ds1 = dal.getdataset("select NRICno from UserInformation");

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        String z = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (string.Equals(q1, z, StringComparison.CurrentCultureIgnoreCase))
                        {
                            getLocationIDByName(ddllocation.Text.Trim());
                            ObjPass.pass_Type = ddlAddPassType.Text;
                            ObjPass.Pass_No = txtAddNoType.Text;
                            ObjPass.Pass_Desciption = txtPassDecription.Text;
                            ObjPass.Date_From = Convert.ToDateTime(DateTime.Now);
                            ObjPass.Pass_Status = txtstatus.Text;
                            ObjPass.Staff_ID = txtKeyNRIC.Text;

                            ObjPass.Location_id = SearchLocID.Text;

                            AdminBLL ws = new AdminBLL();
                            ws.AddUserPass(ObjPass);
                            lblerror.Visible = true;
                            lblerror.Text = "Add Successfully....!";
                            break;

                            // HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                            // Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");

                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Invalid NRICNo....!";
                            lblerr2.Visible = true;
                        }
                    }


                    //throw new Exception();

                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Select Pass Detail ..!";
                    lblerr5.Visible = true;

                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }




        protected void txtKeyNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                GetStaffInfo(txtKeyNRIC.Text.Trim());
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
                ClearAll();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void ClearAll()
        {
            ddlAddPassType.Text = "";
            txtAddPassType.Text = "";
            txtPassDecription.Text = "";
            txtAddNoType.Text = "";
            txtKeyNRIC.Text = "";
            txtposition.Text = "";
            txtKeyName.Text = "";
        }

        protected void btnAdd1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                String ZipRegex = "^[0-9 a-z A-Z]+$";
                if (txtAddPassType.Text.Trim() != "")
                {
                    if (Regex.IsMatch(txtAddPassType.Text.Trim(), ZipRegex))
                    {
                        DataSet ds = dal.getdataset("select Description from log where ID='passtype' and Description='" + txtAddPassType.Text.Trim() + "'");
                        int count = ds.Tables[0].Rows.Count;
                        if (count == 0)
                        {
                            if (txtAddPassType.Text.Trim() != "")
                            {
                                dal.executesql("insert into log values('passtype'," + count + ",'" + txtAddPassType.Text.Trim() + "')");
                                getPassType("passtype");
                                txtAddPassType.Text = "";
                            }
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "This Value Already Exist ..!";
                            lblerr3.Visible = true;
                        }
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Please Fill Only String Values ..!";
                        lblerr3.Visible = true;

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }





    }
}
