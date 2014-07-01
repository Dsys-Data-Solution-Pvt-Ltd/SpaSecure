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


using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.SMSUsers
{
    public partial class checkIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            //txtID1.Focus();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            txtNricID2.Focus();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            txtNricID3.Focus();
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
        protected void btnCheckIn_Click(object sender, EventArgs e)
        {

        }
        protected void btnCheckIn2_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            txtSalesmanID4.Focus();
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }
        protected void btnCheckOut1_Click(object sender, EventArgs e)
        {

        }
        protected void btnCheckIn3_Click(object sender, EventArgs e)
        {

        }
        protected void submit(object sender, EventArgs e)
        {

        }

        //protected void AddCheckInGuard(object sender, EventArgs e)
        //{
        //    AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
        //    checkin objchickin = new checkin();

        //    objchickin.checkin_id = "1645";
        //    objchickin.UserID = txtID1.Text;
        //    objchickin.user_name = txtName1.Text;
        //    objchickin.telephone = txtTeleNo1.Text;
        //    objchickin.user_address = txtAddress1.Text;
        //    objchickin.company_from = txtCompanyFrom1.Text;
        //    objchickin.Vehicle_No = txtVehicleNo1.Text;
        //    objchickin.key_no =Convert.ToInt32(txtKeyNo1.Text);
        //    objchickin.user_image = "hdgfhsd";
        //    objchickin.remarks = txtRemarks1.Text;
        //    objchickin.Pass_No = "36757";
        //    objchickin.pass_type = txtPassNo1.Text;
          
        //    AdminBLL ws = new AdminBLL();
        //    ws.AddCheckinGaurd(objchickin);
        //    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
        //    Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        //}
        protected void AddCheckInVisitor(object sender, EventArgs e)
        {
            AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
            checkin objchickin = new checkin();

            objchickin.checkin_id = "23462";
            objchickin.UserID = txtNricID2.Text;
            objchickin.user_name = txtName2.Text;
            objchickin.telephone = txtTeleNo2.Text;
            objchickin.user_address = txtAddress2.Text;
            objchickin.company_from = txtCompanyFrom2.Text;
            objchickin.Vehicle_No = txtVehicleNo2.Text;
            objchickin.key_no = Convert.ToInt32(txtKeyNo2.Text);
            objchickin.user_image = "hdgfhsd";
            objchickin.remarks = txtRemarks2.Text;
            objchickin.Pass_No= "36757";
            objchickin.pass_type = txtPassNo2.Text;
            //objchickin.to_visit = txtToVisit1.Text;
            objchickin.purpose = txtVisitorPurpose2.Text;


            AdminBLL ws = new AdminBLL();
            ws.AddCheckinVisitor(objchickin);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }
        protected void AddCheckInContractor(object sender, EventArgs e)
        {
            AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
            checkin objchickin = new checkin();

            objchickin.checkin_id = "4545";
            objchickin.UserID = txtNricID3.Text;
            objchickin.user_name = txtName3.Text;
            objchickin.telephone = txtTeleNo3.Text;
            objchickin.user_address = txtAddress3.Text;
            objchickin.company_from = txtCompanyfrom3.Text;
            objchickin.Vehicle_No = txtVehicleNo3.Text;
            objchickin.key_no = Convert.ToInt32(txtKeyNo3.Text);
            objchickin.user_image = "hdgfhsd";
            objchickin.remarks = txtRemarks3.Text;
            objchickin.Pass_No = "36757";
            objchickin.pass_type = txtPassType3.Text;
            objchickin.to_visit = txtServingAt1.Text;

            AdminBLL ws = new AdminBLL();
            ws.AddCheckinContractor(objchickin);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }
        protected void AddCheckInSalesman(object sender, EventArgs e)
        {
            AddNewCheckInRequest objAddCheckinRequest = new AddNewCheckInRequest();
            checkin objchickin = new checkin();

            objchickin.checkin_id = "4654656";
            objchickin.UserID = txtSalesmanID4.Text;
            objchickin.user_name = txtName4.Text;
            objchickin.telephone = txtTeleNo4.Text;
            objchickin.user_address = txtAddress4.Text;
            objchickin.company_from = txtCompanyfrom4.Text;
            objchickin.Vehicle_No = txtVehicleNo4.Text;
            objchickin.key_no = Convert.ToInt32(txtKeyNo4.Text);
            objchickin.user_image = "hdgfhsd";
            objchickin.remarks = txtRemarks4.Text;
            objchickin.Pass_No = "36757";
            objchickin.pass_type = txtPassType4.Text;
            objchickin.to_visit = txtToVisit4.Text;

            AdminBLL ws = new AdminBLL();
            ws.AddCheckinsalesman(objchickin);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");


        }

        //protected void btnClear1_Click(object sender, EventArgs e)
        //{
        //    txtID1.Text = "";
        //    txtName1.Text = "";
        //    txtAddress1.Text = "";
        //    txtCompanyFrom1.Text = "";
        //    txtToVisit1.Text = "";
        //    txtTeleNo1.Text = "";
        //    txtRemarks1.Text = "";
        //    txtVehicleNo1.Text = "";
        //    txtKeyNo1.Text = "";
        //    txtPassNo1.Text = "";

        //}

        protected void btnClear2_Click(object sender, EventArgs e)
        {
            txtNricID2.Text = "";
            txtName2.Text = "";
            txtAddress2.Text = "";
            txtCompanyFrom2.Text = "";
            txtToVisit2.Text = "";
            txtVisitorPurpose2.Text = "";
            txtVehicleNo2.Text = "";
            txtRemarks2.Text = "";
            txtPassNo2.Text = "";
            txtKeyNo2.Text = "";
            txtTeleNo2.Text = "";

        }

        protected void btnClear3_Click(object sender, EventArgs e)
        {
            txtNricID3.Text = "";
            txtName3.Text = "";
            txtKeyNo3.Text = "";
            txtCompanyfrom3.Text = "";
            txtTeleNo3.Text = "";
            txtServingAt1.Text = "";
            txtVehicleNo3.Text = "";
            txtRemarks3.Text = "";
            txtPassType3.Text = "";
            txtAddress3.Text = "";
           
        }

        protected void btnClear4_Click(object sender, EventArgs e)
        {
            txtAddress4.Text = "";
            txtCompanyfrom4.Text = "";
            txtKeyNo4.Text = "";
            txtName4.Text = "";
            txtPassType4.Text = "";
            txtRemarks4.Text = "";
            txtSalesmanID4.Text = "";
            txtTeleNo4.Text = "";
            txtToVisit4.Text = "";
            txtVehicleNo4.Text = "";
        }

        protected void btnscan_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckInScan.aspx");
        }
    }
}
