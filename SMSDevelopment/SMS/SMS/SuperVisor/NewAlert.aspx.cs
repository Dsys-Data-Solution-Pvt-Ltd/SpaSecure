using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using SMS.Services.DataService;

namespace SMS.SuperVisor
{
    public partial class NewAlert : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        #region [Grid Operation]

        protected void btnOpenWindow_Click(object sender, EventArgs e)
        {
            ViewState["Send"] = "All";
            this.ModalPopupUserList.Show();
        }
      
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            SqlParameter[] para1 = new SqlParameter[4];
            if (ViewState["Send"].ToString() == "Single")
            {
                if (ViewState["Staff_ID"] != null)
                {

                    //QA.Date = System.DateTime.Now.ToShortDateString();
                    //QA.Message = txtmessage.Text;
                    //QA.Status = "Unread";
                    //QA.UserID = ViewState["Staff_ID"].ToString();
                    //CDC.QualityAlerts.InsertOnSubmit(QA);
                    //CDC.SubmitChanges();


                    para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
                    para1[0].Value = ViewState["Staff_ID"].ToString();
                   
                    para1[1] = new SqlParameter("@Message", SqlDbType.VarChar);
                    para1[1].Value = txtmessage.Text;

                    para1[2] = new SqlParameter("@Date", SqlDbType.VarChar);
                    para1[2].Value = System.DateTime.Now.ToShortDateString();

                    para1[3] = new SqlParameter("@Status", SqlDbType.VarChar);
                    para1[3].Value = "Unread";


                    dal.exeprocedure("SP_InsertAlertMessage", para1);           
      
      




                }
            }
            else
            {
                foreach (GridItem item in RadGridActiveUser.Items)
                {
                   
                    GridDataItem h = item as GridDataItem;
                    



                    para1[0] = new SqlParameter("@Staff_ID", SqlDbType.VarChar);
                    para1[0].Value = h["Staff_ID"].Text;

                    para1[1] = new SqlParameter("@Message", SqlDbType.VarChar);
                    para1[1].Value = txtmessage.Text;

                    para1[2] = new SqlParameter("@Date", SqlDbType.VarChar);
                    para1[2].Value = System.DateTime.Now.ToShortDateString();

                    para1[3] = new SqlParameter("@Status", SqlDbType.VarChar);
                    para1[3].Value = "Unread";


                    dal.exeprocedure("SP_InsertAlertMessage", para1);  


                }
            }
            txtmessage.Text = "";
            this.ModalPopupUserList.Hide();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            ModalPopupUserList.Hide();
        }

        protected void RadGridActiveUser_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            ViewState["Staff_ID"] = username;
            if (e.CommandName == "Send")
            {
                this.ModalPopupUserList.Show();
                ViewState["Send"] = "Single";
            }

        }

        #endregion

        protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpLocation.SelectedValue != "0")
            {
                string sql = "select * from dbo.UserInformation where ActiveStatus='1' and Role!='Superuser' and Staff_ID in(select StaffID from dbo.StaffLocationMap where LocationID ='" + DrpLocation.SelectedValue + "') and Staff_Status='Present'";
                DataSet ds = GetDataTable(sql);
                RadGridActiveUser.DataSource = GetDataTable(sql);
                RadGridActiveUser.DataBind();
            }
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