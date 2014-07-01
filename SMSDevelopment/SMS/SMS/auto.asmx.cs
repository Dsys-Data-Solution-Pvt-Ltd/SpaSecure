using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using SMS.Services.DataService;

namespace ProDetailsApp
{
    /// <summary>
    /// Summary description for auto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class auto : System.Web.Services.WebService
    {
        DataAccessLayer dal = new DataAccessLayer();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string send(string name)
        {
            string msg = "";
            int i = 0;
            if (name != null)
            {
                string sql = "select Message from dbo.AlertMessage where Status!='Read' and Staff_ID ='" + name + "' ";
                DataSet ds = GetDataTable(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //msg += "<Table width='100%'>";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        i++;
                        //msg += "<tr><td>";
                        //msg += "Message" + i + ":" + " " + r.Message;
                        //msg += "</td></tr>";
                        msg += "<div class='smsbox'>" + r["Message"].ToString() + "</div>";
                    }

                    // msg += "</Table>";
                }
                else
                {

                }
            }
            return msg;
        }
        [WebMethod]
        public string Close(string name)
        {

            //name = "";
            //dataDetailDataContext linq = new dataDetailDataContext();
            //var id = (from a in linq.sms where a.isread==0 select a).SingleOrDefault();
            //if (id != null)
            //    name = id.mess;
            //else
            //    name = "";
            //return name;


            string msg = "";


            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
            para1[0].Value = name;



            para1[1] = new SqlParameter("@Status", SqlDbType.VarChar);
            para1[1].Value = "Read";


            dal.exeprocedure("SP_UpdateAlertMessage", para1);

            return msg;


        }

        public DataSet GetDataTable(string query)
        {

            String ConnString = ConfigurationManager.ConnectionStrings["SpaSecureConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, conn);

            DataSet myDataTable = new DataSet();
            //string x = RadGrid1.Columns[1].Display.ToString();
            conn.Open();
            try
            {
                adapter.Fill(myDataTable);
            }
            finally
            {
                conn.Close();
            }

            return myDataTable;
        }

    }
}
