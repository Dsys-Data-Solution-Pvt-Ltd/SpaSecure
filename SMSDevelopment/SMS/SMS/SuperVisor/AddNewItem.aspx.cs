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
using System.Text.RegularExpressions;

using log4net;
using log4net.Config;
using System.Drawing;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace SMS.SuperVisor
{
    public partial class AddNewItem : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
                    lblerror.Visible = false;                    
                    lblerr1.Visible = false;
                    errorIssuedByNRIC.Visible = false;
                    txtItemName.Focus();

                    if (!IsPostBack)
                    {
                    }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string Status = "Issued";

                SqlParameter[] para = new SqlParameter[14];

                para[0] = new SqlParameter("@Model_No",txtModelNo.Text.Trim());
                para[1] = new SqlParameter("@Item_Name",txtItemName.Text.Trim());
                para[2] = new SqlParameter("@Item_Description",txtItemdescription.Text.Trim());
                para[3] = new SqlParameter("@Item_quantity",txtItemquantity.Text.Trim());

                para[4] = new SqlParameter("@IssuedBy_Nric",txtIssuedByNRIC.Text.Trim());
                para[5] = new SqlParameter("@IssuedBy_Name",txtIssuedByName.Text.Trim());
                para[6] = new SqlParameter("@IssuedBy_Position",txtIssuedByPosition.Text.Trim());
                para[7] = new SqlParameter("@IssuedBy_Time", DateTime.Now);

                para[8] = new SqlParameter("@IssuedTo_Nric",txtIssuedToNRIC.Text.Trim());
                para[9] = new SqlParameter("@IssuedTo_Name",txtIssuedToName.Text.Trim());
                para[10] = new SqlParameter("@IssuedTo_Position",txtIssuedByPosition.Text.Trim());
                para[11] = new SqlParameter("@Status", Status);
                para[12] = new SqlParameter("@Remark",txtComment.Text.Trim());
                para[13] = new SqlParameter("@Location_id", Session["LCID"].ToString());


                dal.executeprocedure("SP_AddItem", para);

               HttpContext.Current.Items.Add("COMPLETE", "INSERT");
               Server.Transfer("CompleteForm.aspx");


            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void GetStaffInfo(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtIssuedToName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtIssuedToPosition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtIssuedToName.Text = "";
                txtIssuedToPosition.Text = "";
            }
        }

        private void GetStaffInfoByNRIC(string ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@NRICno", ID);

            DataTable dtStaffInfo = dal.executeprocedure("sp_FillNameByStaffId", para, false);
            if (dtStaffInfo.Rows.Count > 0)
            {
                txtIssuedByName.Text = dtStaffInfo.Rows[0][0].ToString().Trim();
                txtIssuedByPosition.Text = dtStaffInfo.Rows[0][1].ToString().Trim();
            }
            else
            {
                txtIssuedByName.Text = "";
                txtIssuedByPosition.Text = "";
            }
        }



        protected void txtIssuedToNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {  
                GetStaffInfo(txtIssuedToNRIC.Text.Trim());             
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void txtIssuedByNRIC_TextChanged(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {   
               GetStaffInfoByNRIC(txtIssuedByNRIC.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
