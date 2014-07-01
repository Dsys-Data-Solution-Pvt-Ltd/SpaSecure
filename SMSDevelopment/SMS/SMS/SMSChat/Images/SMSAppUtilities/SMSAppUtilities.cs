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

using SMS.BusinessEntities;
using SMS.Services;

namespace SMS.SMSAppUtilities
{
    public class SMSAppUtilities
    {
        public static string RetrieveMainURL(string strPage)
        {
            DataSet ds = (DataSet)HttpContext.Current.Session[SessionKeys.SESSION_MENU_ITEMS];

            string strURL = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["NavigateURL"].ToString().Contains(strPage))
                {
                    strURL = ds.Tables[0].Rows[i]["NavigateURL"].ToString();
                    if (!strPage.Contains("/"))
                        strURL = strURL.Substring(strURL.IndexOf('/') + 1);
                }
            }

            return strURL;
        }

        /// <summary>
        /// Fill the drop down.
        /// </summary>
        /// <param name="argLUTId"></param>
        /// <param name="argDDL"></param>
        //public static void PopulateDDL(string argLUTId, DropDownList argDDL)
        //{
        //    try
        //    {
        //        GetCardLookUpRequest objRequest = new GetCardLookUpRequest();
        //        objRequest.LUTID = argLUTId;

        //        AdminBLL ws = new AdminBLL();
        //        GetsCardLookUpResponse ret = ws.GetCardLookUp(objRequest);

        //        argDDL.DataSource = ret.CardLookUp;
        //        argDDL.DataValueField = "LUTCode";
        //        argDDL.DataTextField = "LUTDescription";
        //        argDDL.DataBind();
        //        argDDL.Items.Insert(0, new ListItem("None", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
