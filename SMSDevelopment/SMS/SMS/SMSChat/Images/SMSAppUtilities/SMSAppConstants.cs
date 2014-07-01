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

namespace SMS.SMSAppUtilities
{
    public class SMSAppConstants
    {

    }
    /// <summary>
    /// Constants for Context keys. 
    /// </summary>
    public class ContextKeys
    {

        public const string EXCEPTION = "Exception";
        public const int GRID_PAGE_SIZE = 10;
        public const int GRID_PAGE_Index = 0;
        public const string CTX_OBJ_CLOOKUP = "CTX_OBJ_CLOOKUP";
        public const string staff_ID = "staff_ID";
        public const string CTX_OBJ_INST = "CTX_OBJ_INST";
        public const string CTX_OBJ_PARENT_INST = "CTX_OBJ_PARENT_INST";
        public const string CTX_COMPLETE = "COMPLETE";
        public const string CTX_OBJ_EMBOSS = "CTX_OBJ_EMBOSS";
        public const string CTX_INST_ID = "CTX_INST_ID";
        public const string CTX_STMNT_MSG_ID = "CTX_STMNT_MSG_ID";
        public const string CTX_STMNT_MSG_GRP_ID = "CTX_STMNT_MSG_GRP_ID";
        public const string CTX_EMBOSS_ID = "CTX_EMBOSS_ID";
        public const string CTX_BSEG_ID = "CTX_BSEG_ID";
        public const string CTX_BT_ID = "CTX_BT_ID";
        public const string CTX_BG_ID = "CTX_BG_ID";
        public const string CTX_IMG_ID = "CTX_IMG_ID";
        public const string CTX_BASE_PROD = "CTX_BASE_PROD";
        public const string CTX_GROUP_ID = "CTX_GROUP_ID";
        public const string CTX_TXN_ID = "CTX_TXN_ID";
        public const string CTX_PARTNER_ID = "CTX_PARTNER_ID";
        public const string CTX_STORE_ID = "CTX_STORE_ID";
        public const string CTX_ADD_ACCOUNT = "CTX_ADD_ACCOUNT";
        public const string CTX_PARENT_ATID = "CTX_PARENT_ATID";
        public const string CTX_OBJ_SCRG = "CTX_OBJ_SCRG";
        public const string CTX_SERVICECHARGE_ID = "CTX_SERVICECHARGE_ID";
        public const string CTX_OBJ_PROD = "CTX_OBJ_PROD";
        public const string CTX_OBJ_PARENT_PROD = "CTX_OBJ_PARENT_PROD";
        public const string CTX_PRODUCT_ID = "CTX_PRODUCT_ID";
        public const string CTX_USER_ID = "CTX_USER_ID";
        public const string CTX_USERGROUP_ID = "CTX_USERGROUP_ID";
        public const string CTX_OBJ_POPULATE_NEW_EMBOSS = "CTX_OBJ_POPULATE_NEW_EMBOSS";
        public const string CTX_FEEACCTID = "CTX_FEEACCT_ID";
        public const string CTX_UPDATE_URL = "CTX_UPDATE_URL";
        //ajmal
        public const string CTX_OBJ_PROD_REPORT = "CTX_OBJ_PROD_REPORT";
        //ajmal


        public const string imagelogo = "imagelogo";
        public const string title = "title";
        public const string Welcome_heading = "Welcome_heading";
        public const string Welcome_title = "Welcome_title";
        public const string Welcome_title2 = "Welcome_title2";
        public const string Title_header = "Title_header";
        public const string ClientFeedback_Online = "ClientFeedback_Online";
        public const string ClientFeedback_Help = "ClientFeedback_Help";
        public const string ClientFeedback_Analysis = "ClientFeedback_Analysis";

        public const string ClientFeedback_pvt = "ClientFeedback_pvt";
        public const string ClientFeedback_MDirtector = "ClientFeedback_MDirtector";

    }

    public class SessionKeys
    {
        public const string SESSION_LOGIN_USER = "SESSION_LOGIN_USER";
        public const string SESSION_MENU_ITEMS = "SESSION_MENU_ITEMS";
        //--------change by rakesh-----------------------------------
        public const string SESSION_LOGIN_USER_PASSWORD = "SESSION_LOGIN_USER_PASSWORD";
        public const string SESSION_LOGIN_USER_ID = "SESSION_LOGIN_USER_ID";
        public const string SESSION_LOGIN_USER_Role_ID = "SESSION_LOGIN_USER_Role_ID";
        //----------------end of change-------------------------------------
    }

}
