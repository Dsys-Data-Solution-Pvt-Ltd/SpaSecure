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
using SMS.Services.DataService;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.SMSChat
{
    public partial class Registration : System.Web.UI.Page
    {

        SqlConnection cn;
        AdminDAL a = new AdminDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            String q;
            cn = a.getconnection();
            q = "select Description from log where ID='role'";
            SqlCommand cmd = new SqlCommand(q, cn);
            SqlDataReader rec = cmd.ExecuteReader();
            while (rec.Read())
            {

                if (!IsPostBack)
                    ddlRole.Items.Add(rec.GetValue(0).ToString());
            }
            rec.Close();
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
