using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.IO;
using SMS.Services.DataService;
using log4net;
using log4net.Config;
using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities;
using SMS.Services.DALUtilities;
using SMS.Services.BusinessServices;
using SMS.Services;
using Telerik.Web.UI;
namespace SMS.master
{
    public partial class login : System.Web.UI.MasterPage
    {
        RadMenu rd;
        RadMenu rd1;
        private SMSAppUtilities.SMSAppEnums.ContentType _contType = SMSAppUtilities.SMSAppEnums.ContentType.None;
        private string _strBtnId = "";
        private Boolean _bAdd = false;
        private Boolean _bUpd = false;
        private Boolean _bDel = false;

        protected void Page_Init(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!(Request.Url.AbsolutePath.Contains("login3.aspx")))
                {
                    if (Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID] == null)
                    {
                        Response.Redirect("~/master/login3.aspx");
                        //lnkHome.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rd = (RadMenu)rdDBMenu;
            rd1 = (RadMenu)rdDBMenu;
            if (Request.QueryString["t"] == null)
            {

                if (Session["SubRole"] != null)
                {
                    //nameLabel.Text = Session["SubRole"].ToString();
                    //int User_Role = Convert.ToInt32(User_Role_Id(Session["SubRole"]));
                    Session["x"] = Session["SubRole"].ToString();
                    //string x = Session["SubRole"].ToString();
                    if (Convert.ToInt32(Session["count"]) == 1)
                    {

                        MenuBind(User_Role_Id(Session["x"].ToString()));

                    }
                    if (Convert.ToInt32(Session["count1"]) == 1)
                    {
                        MenuBind(User_Role_Id(Session["x"].ToString()));
                    }
                    if (Convert.ToInt32(Session["count2"]) == 1)
                    {
                        MenuBind(User_Role_Id(Session["x"].ToString()));
                    }
                    if (Convert.ToInt32(Session["count3"]) == 1)
                    {
                        MenuBind(User_Role_Id(Session["x"].ToString()));
                    }
                }
            }


            //-------------------------------------------------------------

            //-----------change by rakesh jaiswal----------------------- 
            try
            {
                Session["User_Id"] = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID].ToString();
                string x = (string)Session["User_id"];
                //string User_Id = Session[SMSAppUtilities.SessionKeys.SESSION_LOGIN_USER_ID].ToString();
                Database db = DBConnectionHandler.GetDBConnection().DBConnection;
                DbCommand dbCommand = db.GetStoredProcCommand(DALConstants.SPNames.USER_FIRSTNAME);
                db.AddInParameter(dbCommand, "@UserID", DbType.String, Session["User_Id"].ToString());
                IDataReader dr = db.ExecuteReader(dbCommand);
                if (dr.Read())
                {
                    
                    if (dr.GetString(0).ToString()!="")
                    {
                        image1.ImageUrl = dr.GetString(0);
                        nameLabel.Text = dr.GetString(1);
                        Session["role"] = Session["user_role"] = dr.GetString(2);
                    }
                    else
                    {
                        nameLabel.Text = dr.GetString(1);
                        image1.ImageUrl = "~/Images/avatar.png";
                        //string x1 = dr.GetString(2);
                        Session["role"] = dr.GetString(2);
                        Session["role"] = Session["user_role"] = dr.GetString(2);
                    }

                }
                //=============================//
                dr.Close();
                dr.Dispose();
                //=========================//


            }
            catch (Exception exc)
            {
                image1.ImageUrl = "~/Images/avatar.png";
            }
            //-----------end of change-----------------------------------------------------


            //--------------------------------------------------------------------------
            if (Session["SubRole"] == null)
            {
                if (Session["user_role"].ToString().ToLower() == "superuser")
                {


                }
                else
                {
                    Session["x2"] = Session["user_role"].ToString();
                    MenuBind(User_Role_Id(Session["x2"].ToString()));
                }
            }


        }
        protected void rdDBMenu_ItemClick(object sender, RadMenuEventArgs e)
        { }
        public int User_Role_Id(string User_Role)
        {
            Session["user_role2"] = User_Role;
            //string x = User_Role;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
            cn.Open();
            int result = 0;
            SqlCommand cmd1 = new SqlCommand("select ID from UserRoleMaster where UserRole=@userrole", cn);
            cmd1.Parameters.AddWithValue("@userrole", Session["user_role2"].ToString());
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                result = dr1.GetInt32(0);
                dr1.Close();
                dr1.Dispose();
                cn.Close();
            }
            return result;
        }
        public void MenuBind(int User_Role)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (User_Role == 1)
                {
                    //SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where ID != 119", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where ID != 119 and ID != 30 and ID != 65 and ID != 66 and ID != 31 and ID != 67 and ID != 68 and ID != 39 and ID != 46 and ID != 52 and ID != 48 and ID != 44 and ID != 112 and ID != 113 and ID != 125 and ID != 122 and ID != 123 and ID != 124 and ID != 24 and ID != 32 and ID != 69 and ID != 70 and ID != 71 and ID != 72 and ID != 73 and ID != 74 and ID != 75 and ID != 76 and ID != 42 and ID != 106 and ID != 107 and ID != 135 and ID != 36 and ID != 86 and ID != 87 and ID != 84 and ID != 131 and ID != 132 and ID != 140 and ID != 141 and ID != 115 and ID != 117 and ID != 118", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    DataSet links = new DataSet();
                    adapter.Fill(links);
                    rd.DataTextField = "DisplayText";
                    rd.DataNavigateUrlField = "NavigateUrl";
                    rd.DataFieldID = "ID";
                    rd.DataFieldParentID = "ParentId";
                    rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
                    rd.DataSource = links;
                    rd.DataBind();

                    foreach (RadMenuItem rmi in rd.Items)
                    {
                        rmi.Attributes.Add("style", "cursor:pointer");
                        foreach (RadMenuItem ci in rmi.Items)
                        {
                            ci.Attributes.Add("style", "cursor:pointer");
                        }
                    }

                }
                /*else if (User_Role == 21)
                {
                    //-------------static permission has been given-------------------------------------------------------------------------------
                    //SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where  ID=32 or ParentID = 32 or ParentID=69 or ParentID=70 or ID=33 or ID=35 or ParentID=35 or ParentID=84 or ID=36 or ParentID=36 or ID=42 or ParentID=42 union select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,MenuMasterMap where MenuMaster.ID=MenuMasterMap.MenuId and MenuMasterMap.RoleId=" + User_Role + " and writepermission=" + 1 + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //=======================Changes:Sandeep Date:25/6========================================//
                    SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where  ID=32 or ParentID = 32 or ParentID=69 or ParentID=70 or ID=33 or ID=35 or ParentID=35 or ParentID=84 or ID=36 or ParentID=36 or ID=42 or ParentID=42 union select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //=============================================================//
                    DataSet links = new DataSet();
                    adapter.Fill(links);
                    rd.DataTextField = "DisplayText";
                    rd.DataNavigateUrlField = "NavigateUrl";
                    rd.DataFieldID = "ID";
                    rd.DataFieldParentID = "ParentId";
                    rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
                    rd.DataSource = links;
                    rd.DataBind();

                    foreach (RadMenuItem rmi in rd.Items)
                    {
                        rmi.Attributes.Add("style", "cursor:pointer");
                        foreach (RadMenuItem ci in rmi.Items)
                        {
                            ci.Attributes.Add("style", "cursor:pointer");
                        }
                    }
                    //adapter.Dispose();
                    //----------------------------------------------------------------------------------------------------------------
                    //------------dynamic permission set by superuser------------------------------------------------------------------------------
                    /*SqlDataAdapter adapter2 = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,MenuMasterMap where MenuMaster.ID=MenuMasterMap.MenuId and MenuMasterMap.RoleId=" + User_Role + " and writepermission=" + 1 + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    DataSet links2 = new DataSet();
                    adapter2.Fill(links2);
                    rd1.DataTextField = "DisplayText";
                    rd1.DataNavigateUrlField = "NavigateUrl";
                    rd1.DataFieldID = "ID";
                    rd1.DataFieldParentID = "ParentId";
                    rd1.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
                    rd1.DataSource = links2;
                    rd1.DataBind();

                    foreach (RadMenuItem rmi in rd1.Items)
                    {
                        rmi.Attributes.Add("style", "cursor:pointer");
                        foreach (RadMenuItem ci in rmi.Items)
                        {
                            ci.Attributes.Add("style", "cursor:pointer");
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------
                 }
            
                //==============Changes By Sandeep Date:27/6/2012======//
                /*
                else if ((User_Role == 8) || (User_Role == 16) || (User_Role == 6) || (User_Role == 17) || (User_Role == 19))
                {
                    rd = (RadMenu)rdDBMenu;
                    //=============================Changes:Sandeep Date:25/6=======================================================//
                    SqlDataAdapter adapter = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //SqlDataAdapter adapter = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where ID=32 or ParentID = 32 or ParentID=69 or ParentID=70 and MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where  ID=32 or ParentID = 32 or ParentID=69 or ParentID=70  union select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //===================================================================================//
                    DataSet links = new DataSet();
                    adapter.Fill(links);
                    rd.DataTextField = "DisplayText";
                    rd.DataNavigateUrlField = "NavigateUrl";
                    rd.DataFieldID = "ID";
                    rd.DataFieldParentID = "ParentId";
                    rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
                    rd.DataSource = links;
                    rd.DataBind();

                    foreach (RadMenuItem rmi in rd.Items)
                    {
                        rmi.Attributes.Add("style", "cursor:pointer");
                        foreach (RadMenuItem ci in rmi.Items)
                        {
                            ci.Attributes.Add("style", "cursor:pointer");
                        }
                    }
                }*/
                //======End Changes=====================//
                else
                {

                    rd = (RadMenu)rdDBMenu;
                    //=============================Changes:Sandeep Date:25/6/2012=======================================================//
                    //SqlDataAdapter adapter = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,MenuMasterMap where MenuMaster.ID=MenuMasterMap.MenuId and MenuMasterMap.RoleId=" + User_Role + " and writepermission=" + 1 + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //SqlDataAdapter adapter = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where ID=32 or ParentID = 32 or ParentID=69 or ParentID=70 and MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //SqlDataAdapter adapter = new SqlDataAdapter("select ID,DisplayText,NavigateUrl,ParentId from MenuMaster where  ID=32 or ParentID = 32 or ParentID=69 or ParentID=70  union select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //=============================Changes:Sandeep Date:28/6/2012===========================//
                    SqlDataAdapter adapter = new SqlDataAdapter("select MenuMaster.ID,DisplayText,NavigateUrl,MenuMaster.ParentId from MenuMaster,RoleMenuMap where MenuMaster.ID=RoleMenuMap.MenuId and RoleMenuMap.RoleId=" + User_Role + " Order By MenuMaster.ID ASC", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                    //===================================================================================//
                    DataSet links = new DataSet();
                    adapter.Fill(links);
                    rd.DataTextField = "DisplayText";
                    rd.DataNavigateUrlField = "NavigateUrl";
                    rd.DataFieldID = "ID";
                    rd.DataFieldParentID = "ParentId";
                    rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
                    rd.DataSource = links;
                    rd.DataBind();

                    foreach (RadMenuItem rmi in rd.Items)
                    {
                        rmi.Attributes.Add("style", "cursor:pointer");
                        foreach (RadMenuItem ci in rmi.Items)
                        {
                            ci.Attributes.Add("style", "cursor:pointer");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                logger.Info(exc.Message);
            }
        }
        #region Filter Content Properties
        public SMSAppUtilities.SMSAppEnums.ContentType contType
        {
            get
            {
                return _contType;
            }
            set
            {
                _contType = value;
            }
        }
        public string strBtnId
        {
            get
            {
                return _strBtnId;
            }
            set
            {
                _strBtnId = value;
            }
        }
        public Boolean bAdd
        {
            get
            {
                return _bAdd;
            }
            set
            {
                _bAdd = value;
            }
        }
        public Boolean bUpd
        {
            get
            {
                return _bUpd;
            }
            set
            {
                _bUpd = value;
            }
        }
        public Boolean bDel
        {
            get
            {
                return _bDel;
            }
            set
            {
                _bDel = value;
            }
        }
        #endregion

        public void FilterContent(string strURL, string argBtnId, SMSAppUtilities.SMSAppEnums.ContentType argType)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (strURL.IndexOf('?') > 0)
                {
                    string strQuery = strURL.Substring(strURL.IndexOf('?') + 1);
                    string[] arr = strQuery.Split('&');

                    contType = argType;
                    strBtnId = argBtnId;
                    bAdd = Convert.ToBoolean(arr[0].Substring(4));
                    bUpd = Convert.ToBoolean(arr[1].Substring(4));
                    bDel = Convert.ToBoolean(arr[2].Substring(4));
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        protected void lnkBack1_Click(object sender, EventArgs e)
        {
            //string name = "Home";
            Session["LCID"] = null;
            Response.Redirect("~/master/login.aspx?t=#");
        }


    }
}
