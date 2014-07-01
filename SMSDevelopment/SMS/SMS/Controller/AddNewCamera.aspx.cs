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

namespace SMS.Controller
{
    public partial class AddNewCamera : System.Web.UI.Page
    {
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillLocation();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void fillLocation()
        {           
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {           
                ddllocation.DataSource = dsLocation;
                ddllocation.DataTextField = "Location_name";
                ddllocation.DataValueField = "Location_id";
                ddllocation.DataBind();
                ddllocation.Items.Insert(0, " ");
            }
        }

        protected void btnSearchPassAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string IPCamera_IP = txtAddURL.Text.ToString().Trim(); ;
                string Description = txtCameraDescription.Text.ToString().Trim();
                int location_ID = Convert.ToInt32(ddllocation.SelectedValue.ToString());

                SqlParameter[] para1 = new SqlParameter[3];
                para1[0] = new SqlParameter("@IPCamera_IP", IPCamera_IP);
                para1[1] = new SqlParameter("@Description", Description);
                para1[2] = new SqlParameter("@Location_ID", location_ID);
                dal.executeprocedure("SP_InsertIPCameraMap", para1);
               
                lblerror.Visible = true;
                lblerror.Text = "Inserted Successfully";
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("IPCameraMaster.aspx");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
