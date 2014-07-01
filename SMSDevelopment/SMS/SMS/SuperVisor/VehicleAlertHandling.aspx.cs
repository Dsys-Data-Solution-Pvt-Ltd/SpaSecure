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
using SMS.master;
using Telerik.Web.UI;


namespace SMS.SuperVisor
{
    public partial class VehicleAlertHandling : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        AdminDAL a = new AdminDAL();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                ddlV_Type.Focus();
                lblerror.Visible = false;
                lblerr.Visible = false;
                lblerr1.Visible = false;

                if (!IsPostBack)
                {
                    ColorTab();

                    lnkVehicle_Alert.BackColor = System.Drawing.Color.Maroon;
                    lnkVehicle_Alert.ForeColor = System.Drawing.Color.White;
 
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser" || Session["ManagementRole"].ToString().ToLower() == "super security officer")
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
                    if (!controlname.Contains("imdAdd") && !controlname.Contains("imgDelete") && !controlname.Contains("CheckBox1"))
                    {
                        if (controlname.ToUpper().Contains("gvLoctionTable".ToUpper()))
                        {
                            if (ctrlname1 != null)
                            {
                                if (ctrlname1.Contains("RowClick"))
                                { }
                                else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                {
                                    BindGridWithFilter();    

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
                    BindGridWithFilter();                      
                }
                           
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void DeleteItem(string argalertid)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                if (!string.IsNullOrEmpty(argalertid))
                {
                    AdminBLL ws = new AdminBLL();
                    DeleteAlertRequest _req = new DeleteAlertRequest();

                    _req.Alert_ID = argalertid.ToString();

                    ws.DeleteAlert(_req);

                    MyMasterPage.ShowErrorMessage("Record Deleted Successfully..!");
                    ModalPopupDelete.Hide();

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
                GetAlertData objReq = new GetAlertData();

                GetAlertDataResponse ret = ws.GetAlertData(objReq);

                gvLoctionTable.DataSource = ret.Alert_ID;
                gvLoctionTable.DataBind();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void ColorTab()
        {
            lnkPerson_Alert.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            lnkVehicle_Alert.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }

        #region Main Tab

        protected void lnkPerson_Alert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Response.Redirect("AdminAlert.aspx", false);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void lnkVehicle_Alert_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {


                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtPastSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "59");


                if (dtPastSite.Rows.Count > 0)
                {
                    Response.Redirect("VehicleAlertHandling.aspx", false);

                }
                else
                {

                    MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");


                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion

        # region Grid Selected Row Function


        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            List<string> lstreportsession = new List<string>();
            int ro = ((sender as CheckBox).NamingContainer as GridItem).ItemIndex;
            GridDataItem item = gvLoctionTable.MasterTableView.Items[ro];

            foreach (GridDataItem item1 in gvLoctionTable.MasterTableView.Items)
            {

                if (item == item1)
                {
                    if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        gvLoctionTable.Items[ro].Selected = true;


                        ViewState["Alert_ID"] = item.OwnerTableView.DataKeyValues[ro]["Alert_ID"];


                    }
                }
                else
                {
                    (item1.FindControl("CheckBox1") as CheckBox).Checked = false;
                }


            }

        }

        #endregion

        #region Delete Button Code

        protected void Deletepopup_Yes_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string alert_id = ViewState["Alert_ID"].ToString();

                DeleteItem(alert_id);
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                BindGridWithFilter();
                MyMasterPage.ShowErrorMessage("Record Deleted SuccessFully..!");


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
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
                logger.Info(ex.Message);
            }
        }

        #endregion

        #region Icon button

        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                DataTable dtAddSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "58");

                if (dtAddSite.Rows.Count > 0)
                {

                    this.ModalPopupAdd.Show();
                }
                else
                {
                    MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void ImgDelete_Click(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            DataTable dtPresentSite = AdminDAL.Checkmenu(Session["RoleID"].ToString(), "57");

            if (dtPresentSite.Rows.Count > 0)
            {
                if (ViewState["Alert_ID"] != null)
                {
                    this.ModalPopupDelete.Show();
                }
            }
            else
            {
                MyMasterPage.ShowErrorMessage("You Do Not Have Permission..!");
            }
        }

        #endregion Icon button

        #region PrivateMethod

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
      
     
        #endregion

        #region Vehicle Alert

        protected void btnNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtV_ONricNo.Text != "" && txtbynric.Text != "")
                {
                    lblerror.Visible = false;
                    AddAlertHandling objAddAlertHandling = new AddAlertHandling();
                    AlertHandlingUser objAH = new AlertHandlingUser();
                    SpaMaster MyMasterPage = (SpaMaster)Page.Master;

                    getLocationIDByName(ddllocation.Text.Trim());
                    objAH.Location_id = searchid.Text;
                    objAH.P_NRIC_no = "";
                    objAH.P_Name = txtVOwerName.Text;
                    objAH.P_Nationality = "";
                    objAH.P_Passport = "";

                    objAH.Reason = ddlAlertreason.Text.Trim();
                    objAH.Comment = txtmessage.Text;
                    objAH.Alert_Type = "Vehicle Alert";

                    objAH.AlertBy_Name = txtname.Text;
                    objAH.AlertBy_NRICNo = txtbynric.Text;
                    objAH.AlertDepartment = ddlRole0.Text;
                    objAH.AlertDesignation = txtdesignation.Text;
                    objAH.AlertContNo = txtphone.Text;

                    objAH.V_Color = ddlV_Type.Text;
                    objAH.V_OwnerName = txtVOwerName.Text;
                    objAH.V_OwnerNricNo = txtV_ONricNo.Text;
                    objAH.V_ResgistNo = txtVehicleReg.Text;
                    objAH.V_Type = ddlV_Type.Text;
                    objAH.Date_From = Convert.ToDateTime(DateTime.Now);

                    AdminBLL ws = new AdminBLL();
                    ws.AddAlertHandling(objAH);
                    AllClear();
                    BindGridWithFilter();
                    MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully..!");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "please fill all the fields!!!";
                    lblerr.Visible = true;
                    lblerr1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearNewItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AllClear();
                ModalPopupAdd.Hide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void AllClear()
        {
            ddlV_Type.Text = "";
            txtVOwerName.Text = "";
            txtV_ONricNo.Text = "";
            txtVehicleReg.Text = "";
            ddlAlertreason.Text = "";
            txtmessage.Text = "";
            txtdesignation.Text = "";
            txtname.Text = "";
            txtphone.Text = "";
            ddlRole0.Text = "";
            txtbynric.Text = "";
        }

        //protected void btnaddnewVehicle_Click(object sender, EventArgs e)
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger("File");
        //    try
        //    {
        //        txtaddType.Visible = true;
        //        lbladdnewtype.Visible = true;
        //        string g = txtaddType.Text.Trim();
        //        DataSet dsVehicletype = dal.getdataset("select Description from log where ID='vehicletype'");

        //        int count = dsVehicletype.Tables[0].Rows.Count;
        //        for (i = 0; i < count; i++)
        //        {
        //            string f = dsVehicletype.Tables[0].Rows[i].ItemArray[0].ToString();

        //            if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
        //            {
        //                break;
        //            }
        //        }
        //        i++;
        //        count++;
        //        if (i == count)
        //        {
        //            if (txtaddType.Text.Trim() != "")
        //            {
        //                dal.executesql("insert into log values('vehicletype'," + count + ",'" + txtaddType.Text.Trim() + "')");
        //                //fillVehicle();
        //                txtaddType.Text = "";
        //            }
        //        }

        //        else
        //        {
        //            //txtaddType.Text = "";
        //            lblerror.Visible = true;
        //            lblerror.Text = "This Type Already Exists ..!";
        //            //lblerr1.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info(ex.Message);
        //    }
        //}

        protected void txtbynric_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtbynric.Text.Trim() != "")
                {
                    DataSet ds = dal.getdataset("Select FirstName,Role,Staff_Telphone from UserInformation where NRICno='" + txtbynric.Text.Trim() + "' ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtname.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
                        txtdesignation.Text = ds.Tables[0].Rows[0][1].ToString().Trim();
                        txtphone.Text = ds.Tables[0].Rows[0][2].ToString().Trim();
                    }

                }
                else
                {
                    txtname.Text = "";
                    txtphone.Text = "";
                    txtdesignation.Text = "";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion


    }
}
