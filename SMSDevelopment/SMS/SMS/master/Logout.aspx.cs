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
    public partial class Logout : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffID"] != null)
            {
                SqlParameter[] para1 = new SqlParameter[2];
                para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
                para1[0].Value = Session["StaffID"].ToString();



                para1[1] = new SqlParameter("@ActiveStatus", SqlDbType.VarChar);
                para1[1].Value = "0";


                dal.exeprocedure("SP_UpdateuserinformationActiveStatus", para1);
            }
            Session.Abandon();
            Session.RemoveAll();


            Response.Redirect("~/master/login3.aspx");

        }
    }
}