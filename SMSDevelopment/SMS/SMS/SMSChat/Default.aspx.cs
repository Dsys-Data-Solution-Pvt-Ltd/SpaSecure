using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SMS.SMSChat
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SESSION_LOGIN_USER"] != null)
            {
                string qry = string.Empty;
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
                cn.Open();
                qry = "Update UserInformation set LastLoginTime = convert(datetime,'"+DateTime.Now.ToString()+"') where UserID='"+Session["SESSION_LOGIN_USER"].ToString()+"'";
                SqlCommand cmd = new SqlCommand(qry, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                Session["LastMsg"] = DateTime.Now;

                qry = "select Role from UserInformation where UserID='" + Session["SESSION_LOGIN_USER"].ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(qry, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Session["role"] = dt.Rows[0]["Role"].ToString();
                Response.Redirect("ChatPage.aspx");
            }
        }
    }
}