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
    public partial class checkOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MultiView1.ActiveViewIndex = 0;
            //MultiView1.ActiveViewIndex = 1;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            txtID1.Focus();

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

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            txtSalesmanID4.Focus();
        }

        protected void btnCheckOut1_Click(object sender, EventArgs e)
        {

        }

        protected void AddCheckOutGuard(object sender, EventArgs e)
        {
            AddNewCheckOutRequest objAddCheckOutRequest = new AddNewCheckOutRequest();    
           checkout objchickout = new checkout();

            objchickout.checkin_id = "12345";
            objchickout.checkout_id = "345";
            objchickout.user_id = txtID1.Text;
            objchickout.user_name = txtName1.Text;
            objchickout.telephone = txtTeleNo1.Text;
            objchickout.user_address = txtAddress1.Text;
            objchickout.company_from = txtCompanyFrom1.Text;
            objchickout.vehicle_no = txtVehicle1.Text;
            objchickout.key_no = txtKeyNo1.Text;
            objchickout.user_image = "hdgsd";
            objchickout.remarks = txtRemarks1.Text;
            objchickout.pass_no = txtPassNo1.Text;


            AdminBLL ws = new AdminBLL();
            ws.AddCheckOutGaurd(objchickout);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }
        protected void AddCheckOutVisitor(object sender, EventArgs e)
        {
            AddNewCheckOutRequest objAddCheckOutRequest = new AddNewCheckOutRequest();
            checkout objchickout = new checkout();

            objchickout.checkin_id = "12345";
            objchickout.checkout_id = "345";
            objchickout.user_id = txtNricID2.Text;
            objchickout.user_name = txtName2.Text;
            objchickout.telephone = txtTeleNo2.Text;
            objchickout.user_address = txtAddress2.Text;
            objchickout.company_from = txtCompanyFrom2.Text;
            objchickout.vehicle_no = txtVehicleNo2.Text;
            objchickout.key_no = txtKeyNo2.Text;
            objchickout.user_image = "hdgsd";
            objchickout.remarks = txtRemarks2.Text;
            objchickout.pass_no = txtPassNo2.Text;
            objchickout.to_visit = txtToVisit2.Text;
            objchickout.purpose = txtVisitorPurpose2.Text;



            AdminBLL ws = new AdminBLL();
            ws.AddCheckOutVisiter(objchickout);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }
        protected void AddCheckOutSaleman(object sender, EventArgs e)
        {
            AddNewCheckOutRequest objAddCheckOutRequest = new AddNewCheckOutRequest();
            checkout objchickout = new checkout();

            objchickout.checkin_id = "12345";
            objchickout.checkout_id = "345";
            objchickout.user_id = txtSalesmanID4.Text;
            objchickout.user_name = txtName4.Text;
            objchickout.telephone = txtTeleNo4.Text;
            objchickout.user_address = txtAddress4.Text;
            objchickout.company_from = txtCompanyfrom4.Text;
            objchickout.vehicle_no = txtVehicleNo4.Text;
            objchickout.key_no = txtKeyNo4.Text;
            objchickout.user_image = "hdgsd";
            objchickout.remarks = txtRemarks4.Text;
            objchickout.pass_no = txtPassType4.Text;
            objchickout.to_visit = txtToVisit4.Text;
          
            AdminBLL ws = new AdminBLL();
            ws.AddCheckOutSaleman(objchickout);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }
        protected void AddCheckOutContractor(object sender, EventArgs e)
        {
            AddNewCheckOutRequest objAddCheckOutRequest = new AddNewCheckOutRequest();
            checkout objchickout = new checkout();

            objchickout.checkin_id = "12345";
            objchickout.checkout_id = "345";
            objchickout.user_id = txtNricID3.Text;
            objchickout.user_name = txtName3.Text;
            objchickout.telephone = txtTeleNo3.Text;
            objchickout.user_address = txtAddress3.Text;
            objchickout.company_from = txtCompanyfrom3.Text;
            objchickout.vehicle_no = txtVehicleNo3.Text;
            objchickout.key_no = txtKeyNo3.Text;
            objchickout.user_image = "hdgsd";
            objchickout.remarks = txtRemarks3.Text;
            objchickout.pass_no = txtPassType3.Text;
            objchickout.to_visit = txtServingAt1.Text;

            AdminBLL ws = new AdminBLL();
            ws.AddCheckOutContractor(objchickout);
            HttpContext.Current.Items.Add("COMPLETE", "INSERT");
            Server.Transfer("..//SMSADMIN//AddNewUserComplete.aspx");

        }

        protected void btnCheckOut2_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            txtAddress1.Text = "";
            txtCompanyFrom1.Text = "";
            txtID1.Text = "";
            txtKeyNo1.Text = "";
            txtName1.Text = "";
            txtPassNo1.Text = "";
            txtRemarks1.Text = "";
            txtTeleNo1.Text = "";
            txtToVisit1.Text = "";
            txtVehicle1.Text = "";
        }
        protected void btnClear2_Click(object sender, EventArgs e)
        {
            txtAddress2.Text = "";
            txtCompanyFrom2.Text = "";
            txtKeyNo2.Text = "";
            txtName2.Text = "";
            txtNricID2.Text = "";
            txtPassNo2.Text = "";
            txtRemarks2.Text = "";
            txtTeleNo2.Text = "";
            txtToVisit2.Text = "";
            txtVehicleNo2.Text = "";
            txtVisitorPurpose2.Text = "";
        }
        protected void btnClear3_Click(object sender, EventArgs e)
        {
            txtAddress3.Text = "";
            txtCompanyfrom3.Text = "";
            txtKeyNo3.Text = "";
            txtName3.Text = "";
            txtNricID3.Text = "";
            txtPassType3.Text = "";
            txtRemarks3.Text = "";
            txtTeleNo3.Text = "";
            txtServingAt1.Text = "";
            txtVehicleNo3.Text = "";
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
    }
}