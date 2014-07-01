using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.BusinessEntities.Main;
using System.Data.SqlClient;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using System.Configuration;
using Telerik.Web.UI;

namespace Web
{
    public partial class permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------------
            menufunction();
            //----------------------------------------------------------
            RadMenu rd = (RadMenu)rdDBMenu;
            SqlDataAdapter adapter = new SqlDataAdapter("select * from UserRoleMaster", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
            DataSet links = new DataSet();
            adapter.Fill(links);
            rd.DataTextField = "UserRole";
            //rd.DataNavigateUrlField = "NavigateUrl";
            rd.DataFieldID = "ID";
            rd.DataFieldParentID = "ParentId";
            rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
            rd.DataSource = links;
            rd.DataBind();

            foreach (RadMenuItem rmi in rd.Items)
            {
                rmi.Attributes.Add("style", "cursor:pointer");
                foreach (RadMenuItem ci in rmi.Items)
                {
                    ci.Attributes.Add("style", "cursor:pointer");
                }
            }


        }
        protected void CheckBox20_CheckedChanged(object sender, EventArgs e)
        { }
        //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        //{
        //    Label1.Text = TreeView1.SelectedNode.Text;
        //    showcheck_in_status(Label1.Text);
        //}
        //protected void check_in_report_CheckedChanged(object sender, EventArgs e)
        //{ }
        protected void cur_checkin_Button_Click(object sender, EventArgs e)
        {
            insertupdatefun(check_in_report, inReadOnly, CheckBox4, Label4);
        }
        public int alertReadOnly_status(CheckBox redchk)
        {
            if (redchk.Checked == true) { return 1; }
            else { return 0; }
        }
        public int alertWriteOnly_status(CheckBox writechk)
        {
            if (writechk.Checked == true) { return 1; }
            else { return 0; }
        }
        public void showcheck_in_status(string x)
        {
            DataRow rw = null;
            AdminDAL ad = new AdminDAL();
            DataTable dt = new DataTable();
            dt = ad.userrole(ad.searchtreevalue(Label1.Text));
            if (dt.Rows.Count == 0)
            { checkboxfalsefun(); }
            else
            {
                checkboxfalsefun();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rw = dt.Rows[i];
                    if (Convert.ToInt32(rw[4]) == 1)
                    {
                        if (Convert.ToInt32(rw[5]) == 1)
                        { switchcase1(Convert.ToString(rw[2])); }
                        else
                        { switchcase2(Convert.ToString(rw[2])); }
                    }
                    else
                    {
                        if (Convert.ToInt32(rw[5]) == 1)
                        {
                            switchcase3(Convert.ToString(rw[2]));
                        }
                        else
                        { switchcase4(Convert.ToString(rw[2])); }
                    }
                }
            }
        }
        public void functionmenuname()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.menuname();
            DataRow row = dt.Rows[0];
            report1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            eventmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            shiftdep.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            locationmanagement.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            staffmanagement.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            inventrymgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            //tranningmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[7];
            //previsitormgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[8];
            chkinoutmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[9];
            dtCheckBox1.Text = ldigitaldiary.Text = Convert.ToString(row[0]);
            row = dt.Rows[10];
            viewreportmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[11];
            alertreport.Text = Convert.ToString(row[0]);
            row = dt.Rows[12];
            followupmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[13];
            maintenancemgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[14];
            dashbordCheckBox1.Text = dashboard.Text = Convert.ToString(row[0]);
            row = dt.Rows[15];
            //tspCB1.Text = assmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[16];
            emergencyCB1.Text = emergencymgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[17];
            sopmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[18];
            createreport.Text = Convert.ToString(row[0]);
            row = dt.Rows[19];
            shift.Text = Convert.ToString(row[0]);
            row = dt.Rows[23];
            asslocCheckBox1.Text = asslocationmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[20];
            //feedbackmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[21];
            permissionCB1.Text = permissionmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[22];
            //cameraCB1.Text = camera.Text = Convert.ToString(row[0]);
            //row = dt.Rows[46];
            //asslocCheckBox1.Text = asslocationmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[24];
            //pddCB1.Text = pddCB1.Text = pddiary.Text = Convert.ToString(row[0]);
            row = dt.Rows[25];
            mpddiary.Text = Convert.ToString(row[0]);
            row = dt.Rows[26];
            logsettingCB1.Text = logmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[27];
            accsettingCB1.Text = accountsetting.Text = Convert.ToString(row[0]);
            row = dt.Rows[28];
            //gpsystemCB1.Text = guardpsystem.Text = Convert.ToString(row[0]);
            row = dt.Rows[29];
            logoutCB1.Text = logoutmgmt.Text = Convert.ToString(row[0]);
            //row = dt.Rows[99];
            //feedmgmt.Text = Convert.ToString(row[0]);
            row = dt.Rows[30];
            facilityCB1.Text = facilitymgmt.Text = Convert.ToString(row[0]);

        }
        public void functionmenuchildname()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.menuhildname();
            DataRow row = dt.Rows[0];
            Label4.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            Label5.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            activereview1.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            activereview2.Text = Convert.ToString(row[0]);

        }
        public void functionmenuchil2dname()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.menuhild2name();
            DataRow row = dt.Rows[0];
            check_in_report.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            Check_out_report.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            Incident_Report.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            Alert_Report.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            Occurence.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            CheckBox18.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            Contractor.Text = Convert.ToString(row[0]);
            row = dt.Rows[7];
            Event.Text = Convert.ToString(row[0]);
            row = dt.Rows[8];
            Lost_Found.Text = Convert.ToString(row[0]);
        }
        public void functionmenuchil3dname()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.menuhild3name();
            DataRow row = dt.Rows[0];
            pCheck_in_report.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            pCheck_out_report.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            p_incident.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            p_alert.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            p_occurence.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            p_visit.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            p_contract.Text = Convert.ToString(row[0]);
            row = dt.Rows[7];
            p_event.Text = Convert.ToString(row[0]);
            row = dt.Rows[8];
            p_lost.Text = Convert.ToString(row[0]);
        }
        public void shiftdeployment()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.shiftdeployment();
            DataRow row = dt.Rows[0];
            shiftdepCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            shiftdepCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            shiftdepCheckBox3.Text = Convert.ToString(row[0]);
        }
        public void shiftmgmt()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.shiftmgmt();
            DataRow row = dt.Rows[0];
            shiftCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            shiftCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            shiftCheckBox3.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            shiftCheckBox4.Text = Convert.ToString(row[0]);
        }
        public void dynamicchild4menu()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.dynamicchild4menu();
            DataRow row = dt.Rows[0];
            eveviewCheckBox.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            eveaddCheckBox.Text = Convert.ToString(row[0]);
        }
        public void locationyment()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.locationyment();
            DataRow row = dt.Rows[0];
            locCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            locCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            locCheckBox3.Text = Convert.ToString(row[0]);
        }
        public void inventry()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.inventry();
            DataRow row = dt.Rows[0];
            invetCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            invetCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            invetCheckBox3.Text = Convert.ToString(row[0]);
        }
        public void tranning()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.tranning();
            DataRow row = dt.Rows[0];
            //tranCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            //tranCheckBox2.Text = Convert.ToString(row[0]);
        }
        public void previsitors()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.previsitors();
            DataRow row = dt.Rows[0];
            //preCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            //preCheckBox2.Text = Convert.ToString(row[0]);
        }
        public void checkinout()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.checkinout();
            DataRow row = dt.Rows[0];
            chkoutLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            chkinLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            chkoutCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            chkoutCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            chkoutCheckBox3.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            chkinCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            chkinCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[7];
            chkinCheckBox3.Text = Convert.ToString(row[0]);
        }
        public void feedbackform()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.feedbackform();
            DataRow row = dt.Rows[0];
            //feedCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            //feedCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            //feedCheckBox3.Text = Convert.ToString(row[0]);
        }
        public void viewreports()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.viewreports();
            DataRow row = dt.Rows[0];
            viewCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            viewCheckBox2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            viewCheckBox3.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            viewCheckBox4.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            viewCheckBox5.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            viewCheckBox6.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            viewCheckBox7.Text = Convert.ToString(row[0]);
        }
        public void alertmgmt()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.alertmgmt();
            DataRow row = dt.Rows[0];
            addalertLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            viewaltCheckBox1.Text = viewaltLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            addaltCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            addaltCheckBox2.Text = Convert.ToString(row[0]);
        }
        public void followup()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.followup();
            DataRow row = dt.Rows[0];
            followCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            followCheckBox2.Text = Convert.ToString(row[0]);
        }
        public void Maintenance()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.Maintenance();
            DataRow row = dt.Rows[0];
            keymanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            keymanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            keymanagerCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            keymanagerCB3.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            passmanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[5];
            passmanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[6];
            passmanagerCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[7];
            itemanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[8];
            itemanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[9];
            itemanagerCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[10];
            sopmanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[11];
            sopmanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[12];
            sopmanagerCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[13];
            alertmanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[14];
            addalertmanagerLabel.Text = Convert.ToString(row[0]);
            row = dt.Rows[15];
            viewalertmanagerLabel.Text = viewalertmanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[16];
            addalertmanagerCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[17];
            addalertmanagerCB2.Text = Convert.ToString(row[0]);
        }
        public void sopmanagement()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.sopmanagement();
            DataRow row = dt.Rows[0];
            sopCheckBox1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            sopCheckBox2.Text = Convert.ToString(row[0]);
        }
        public void staffmgmt()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.staffmgmt();
            DataRow row = dt.Rows[0];
            staffmgmtCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            staffmgmtCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            staffmgmtCB3.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            staffmgmtCB4.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            staffmgmtCB5.Text = Convert.ToString(row[0]);
        }
        public void creportsmgmt()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.creportsmgmt();
            DataRow row = dt.Rows[0];
            creportCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            creportCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            creportCB3.Text = Convert.ToString(row[0]);
            //row = dt.Rows[3];
            //creportCB4.Text = viewaltLabel.Text = Convert.ToString(row[0]);
        }
        public void reportmgmt()
        {
            //DataTable dt = new DataTable();
            //AdminDAL ad = new AdminDAL();
            //dt = ad.reportmgmt();
            //DataRow row = dt.Rows[0];
            //feedCB1.Text = Convert.ToString(row[0]);
            //row = dt.Rows[1];
            //feedCB2.Text = Convert.ToString(row[0]);
        }
        public void masterppd()
        {
            DataTable dt = new DataTable();
            AdminDAL ad = new AdminDAL();
            dt = ad.masterppd();
            DataRow row = dt.Rows[0];
            mpddCB1.Text = Convert.ToString(row[0]);
            row = dt.Rows[1];
            mpddCB2.Text = Convert.ToString(row[0]);
            row = dt.Rows[2];
            mpddCB3.Text = Convert.ToString(row[0]);
            row = dt.Rows[3];
            mpddCB4.Text = Convert.ToString(row[0]);
            row = dt.Rows[4];
            mpddCB5.Text = Convert.ToString(row[0]);
        }
        public void menufunction()
        {
            functionmenuname();
            functionmenuchildname();
            functionmenuchil2dname();
            functionmenuchil3dname();
            shiftdeployment();
            shiftmgmt();
            dynamicchild4menu();
            locationyment();
            inventry();
            tranning();
            previsitors();
            checkinout();
            feedbackform();
            viewreports();
            alertmgmt();
            followup();
            Maintenance();
            sopmanagement();
            staffmgmt();
            creportsmgmt();
            reportmgmt();
            masterppd();
        }
        protected void cur_checkout_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Check_out_report, outReadOnly, CheckBox14, Label4); }
        protected void cur_ince_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Incident_Report, incidentReadOnly, incidWriteOnly, Label4); }
        protected void cur_alert_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Alert_Report, alertReadOnly, alertWriteOnly, Label4); }
        public void insertupdatefun(CheckBox menuname, CheckBox redchk, CheckBox writechk, Label lb)
        {
            AdminDAL ad = new AdminDAL();
            roleMasterMap rmp = new roleMasterMap();
            add_user_info adus = new add_user_info();
            rmp.rMastMp_RoleId = ad.searchtreevalue(Label1.Text);
            if (rmp.rMastMp_RoleId == 0)
            { }
            else
            {
                if (menuname.Checked == true)
                {
                    rmp.rmastMp_ParentId = ad.searchparentid(lb.Text);
                    rmp.rMastMp_MenuId = ad.searchmenuid(menuname.Text, rmp.rmastMp_ParentId);
                    rmp.rMastMp_readonly = alertReadOnly_status(redchk);
                    rmp.rMastMp_writeonly = alertWriteOnly_status(writechk);
                    rmp.rMastMp_Addright = "Y";
                    int count = adus.countmenumastmap(rmp, "countmenumastmap");
                    if (count == 0)
                    {
                        int op = adus.insertmenu(rmp, "menu_master_map");
                        int parent = ad.serachParent(rmp.rMastMp_MenuId);
                        int count1 = functioncount(rmp.rMastMp_RoleId, parent);
                        if (count1 == 0)
                        {
                            while (parent != 0)
                            {
                                rmp.rMastMp_MenuId = parent;
                                rmp.rmastMp_ParentId = ad.searchparentid2(rmp.rMastMp_MenuId);
                                int op1 = adus.insertmenu(rmp, "menu_master_map");
                                parent = ad.serachParent(rmp.rMastMp_MenuId);
                                count1 = functioncount(rmp.rMastMp_RoleId, parent);
                                if (count1 == 0)
                                {

                                }
                                else { break; }
                            }
                        }
                        else
                        {

                        }
                    }
                    else if (count >= 1)
                    {
                        rmp.rmastMp_ParentId = ad.searchparentid(lb.Text);
                        rmp.rMastMp_RoleId = ad.searchtreevalue(Label1.Text);
                        rmp.rMastMp_MenuId = ad.searchmenuid(menuname.Text, rmp.rmastMp_ParentId);
                        rmp.rMastMp_readonly = alertReadOnly_status(redchk);
                        rmp.rMastMp_writeonly = alertWriteOnly_status(writechk);
                        rmp.rMastMp_Addright = "Y";
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select ID from MenuMasterMap where RoleId=@roleid and MenuId=@menuid and ParentId=@parentid", cn);
                        cmd.Parameters.AddWithValue("@roleid", rmp.rMastMp_RoleId);
                        cmd.Parameters.AddWithValue("@menuid", rmp.rMastMp_MenuId);
                        cmd.Parameters.AddWithValue("@parentid", rmp.rmastMp_ParentId);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        { rmp.rMastMp_Id = dr.GetInt32(0); }
                        //==================================================//
                        dr.Close();
                        dr.Dispose();
                        //======================================================//
                        //-------------update query----------------------------
                        int op = adus.editmenumastmap(rmp, "editmenumastermap");
                        //--------------end of update query------------------------------------
                        cn.Close();
                    }
                }
                else
                { }
            }
        }
        public void checkboxfalsefun()
        {
            check_in_report.Checked = false; inReadOnly.Checked = false; CheckBox4.Checked = false;
            Check_out_report.Checked = false; outReadOnly.Checked = false; CheckBox14.Checked = false;
            Alert_Report.Checked = false; alertReadOnly.Checked = false; alertWriteOnly.Checked = false;
            Incident_Report.Checked = false; incidWriteOnly.Checked = false; incidentReadOnly.Checked = false;
            Occurence.Checked = false; occureReadOnly.Checked = false; occurWriteOnly.Checked = false;
            CheckBox18.Checked = false; visitReadOnly.Checked = false; vivitWriteOnly.Checked = false;
            Contractor.Checked = false; contractReadOnly.Checked = false; contractWriteOnly.Checked = false;
            Event.Checked = false; eventReadOnly.Checked = false; eventWriteOnly.Checked = false;
            Lost_Found.Checked = false; lostReadOnly.Checked = false; lostWriteOnly.Checked = false;
            pCheck_in_report.Checked = false; p_in_ReadOnly.Checked = false; p_in_WriteOnly.Checked = false;
            pCheck_out_report.Checked = false; p_out_ReadOnly.Checked = false;
            p_inc_WriteOnly.Checked = false; p_incident.Checked = false; p_inc_ReadOnly.Checked = false;
            p_alert_WriteOnly.Checked = false; p_alert.Checked = false; p_alert_ReadOnly.Checked = false;
            pocr_WriteOnly.Checked = false; p_occurence.Checked = false; p_occure_ReadOnly.Checked = false;
            p_visit_WriteOnly.Checked = false; p_visit.Checked = false; p_visit_ReadOnly.Checked = false;
            p_cont_WriteOnly.Checked = false; p_contract.Checked = false; p_contract_ReadOnly.Checked = false;
            p_event_WriteOnly.Checked = false; p_event.Checked = false; p_event_ReadOnly.Checked = false;
            p_lost_WriteOnly.Checked = false;
            p_lost.Checked = false; p_lost_ReadOnly.Checked = false; p_out_WriteOnly.Checked = false;
            activereview1.Checked = false; activerev1.Checked = false; activerev3.Checked = false;
            activereview2.Checked = false; activerev2.Checked = false; activerev4.Checked = false;
            eveviewCheckBox.Checked = false; eveviewReadOnly.Checked = false; eveviewWriteOnly.Checked = false;
            eveaddCheckBox.Checked = false; eveaddReadOnly.Checked = false; eveaddWriteOnly.Checked = false;
            dtCheckBox1.Checked = false; dtredCheckBox1.Checked = false; CheckBox1.Checked = false;
            dashbordCheckBox1.Checked = false; dashredCB1.Checked = false; dashwrCB1.Checked = false; ;
            //tspCB1.Checked = false; tspredCB1.Checked = false; tspwrCB1.Checked = false;
            emergencyCB1.Checked = false; emergencyredCB1.Checked = false; emergencywrCB1.Checked = false;
            permissionCB1.Checked = false; permissionredCB1.Checked = false; permissionwrCB1.Checked = false;
            //cameraCB1.Checked = false; cameraredCB1.Checked = false; camerawrCB1.Checked = false;
            asslocCheckBox1.Checked = false; asslocredchkbox1.Checked = false; asslocwrchkbox.Checked = false;
            //pddCB1.Checked = false; pddredCB1.Checked = false; pddwrCB1.Checked = false;
            logsettingCB1.Checked = false; logsettingredCB1.Checked = false; logsettingwrCB1.Checked = false;
            accsettingCB1.Checked = false; accsettingredCB1.Checked = false; accsettingwrCB1.Checked = false;
            //gpsystemCB1.Checked = false; gpsystemredCB1.Checked = false; gpsystemwrCB1.Checked = false;
            logoutCB1.Checked = false; logoutredCB1.Checked = false; logoutwrCB1.Checked = false;
            shiftdepCheckBox1.Checked = false; shiftdepredCheckBox1.Checked = false; shiftdepwrCheckBox1.Checked = false;
            shiftdepCheckBox2.Checked = false; shiftdepredCheckBox2.Checked = false; shiftdepwrCheckBox2.Checked = false;
            shiftdepCheckBox3.Checked = false; shiftdepredCheckBox3.Checked = false; shiftdepwrCheckBox3.Checked = false;
            locCheckBox1.Checked = false; locredCheckBox1.Checked = false; locwrCheckBox1.Checked = false;
            locCheckBox2.Checked = false; locredCheckBox2.Checked = false; locwrCheckBox2.Checked = false;
            locCheckBox3.Checked = false; locredCheckBox3.Checked = false; locwrCheckBox3.Checked = false;
            staffmgmtCB1.Checked = false; staffmgmtredCB1.Checked = false; staffmgmtwrCB1.Checked = false;
            staffmgmtCB2.Checked = false; staffmgmtredCB2.Checked = false; staffmgmtwrCB2.Checked = false;
            staffmgmtCB3.Checked = false; staffmgmtredCB3.Checked = false; staffmgmtwrCB3.Checked = false;
            staffmgmtCB4.Checked = false; staffmgmtredCB4.Checked = false; staffmgmtwrCB4.Checked = false;
            staffmgmtCB5.Checked = false; staffmgmtredCB5.Checked = false; staffmgmtwrCB5.Checked = false;
            invetCheckBox1.Checked = false; invetredchkbox1.Checked = false; invetwrchkbox1.Checked = false;
            invetCheckBox2.Checked = false; invetredchkbox12.Checked = false; invetwrchkbox2.Checked = false;
            //tranCheckBox1.Checked = false; tranredchkbox1.Checked = false; tranwrchkbox1.Checked = false;
            //tranCheckBox2.Checked = false; tranredchkbox2.Checked = false; tranwrchkbox2.Checked = false;
            //preCheckBox1.Checked = false; preredCheckBox1.Checked = false; prewrCheckBox1.Checked = false;
            //preCheckBox2.Checked = false; preredCheckBox2.Checked = false; prewrCheckBox2.Checked = false;
            chkoutCheckBox1.Checked = false; chkoutredCB1.Checked = false; chkoutwrCB1.Checked = false;
            chkoutCheckBox2.Checked = false; chkoutredCB2.Checked = false; chkoutwrCB2.Checked = false;
            chkoutCheckBox3.Checked = false; chkoutredCB3.Checked = false; chkoutwrCB3.Checked = false;
            chkinCheckBox1.Checked = false; chkinredCB1.Checked = false; chkinwrCB1.Checked = false;
            chkinCheckBox2.Checked = false; chkinredCB2.Checked = false; chkinwrCB2.Checked = false;
            chkinCheckBox3.Checked = false; chkinredCB3.Checked = false; chkinwrCB3.Checked = false;
            viewCheckBox1.Checked = false; viewredCB1.Checked = false; viewwrCB1.Checked = false;
            viewCheckBox2.Checked = false; viewredCB2.Checked = false; viewwrCB2.Checked = false;
            viewCheckBox3.Checked = false; chkinredCB3.Checked = false; viewwrCB3.Checked = false;
            viewCheckBox4.Checked = false; viewredCB4.Checked = false; viewwrCB4.Checked = false;
            viewCheckBox5.Checked = false; viewredCB5.Checked = false; viewwrCB5.Checked = false;
            viewCheckBox6.Checked = false; viewredCB6.Checked = false; viewwrCB6.Checked = false;
            viewaltCheckBox1.Checked = false; viewaltredCB1.Checked = false; viewaltwrCB1.Checked = false;
            followCheckBox1.Checked = false; folllowredCB1.Checked = false; folllowwrCB1.Checked = false;
            followCheckBox2.Checked = false; folllowredCB2.Checked = false; folllowwrCB2.Checked = false;
            keymanagerCB1.Checked = false; keymanagerredCB1.Checked = false; keymanagerwrCB1.Checked = false;
            keymanagerCB2.Checked = false; keymanagerredCB2.Checked = false; keymanagerwrCB2.Checked = false;
            keymanagerCB3.Checked = false; keymanagerredCB3.Checked = false; keymanagerwrCB3.Checked = false;
            passmanagerCB1.Checked = false; passmanagerredCB1.Checked = false; passmanagerwrCB1.Checked = false;
            passmanagerCB2.Checked = false; passmanagerredCB2.Checked = false; passmanagerwrCB2.Checked = false;
            itemanagerCB1.Checked = false; itemanageredCB1.Checked = false; itemanagerwrCB1.Checked = false;
            itemanagerCB2.Checked = false; itemanageredCB2.Checked = false; itemanagerwrCB2.Checked = false;
            sopmanagerCB1.Checked = false; sopmanageredCB1.Checked = false; sopmanagerwrCB1.Checked = false;
            sopmanagerCB2.Checked = false; sopmanageredCB2.Checked = false; sopmanagerwrCB1.Checked = false; ;
            sopCheckBox1.Checked = false; sopredCB1.Checked = false; sopwrCB1.Checked = false;
            sopCheckBox2.Checked = false; sopredCB2.Checked = false; sopwrCB2.Checked = false;
            creportCB1.Checked = false; creportredCB1.Checked = false; creportwrCB1.Checked = false;
            creportCB2.Checked = false; creportredCB2.Checked = false; creportwrCB2.Checked = false;
            creportCB3.Checked = false; creportredCB3.Checked = false; creportwrCB3.Checked = false;
            shiftCheckBox1.Checked = false; shiftreadCheckBox1.Checked = false; shiftwriteCheckBox1.Checked = false;
            shiftCheckBox2.Checked = false; shiftreadCheckBox2.Checked = false; shiftwriteCheckBox2.Checked = false;
            shiftCheckBox3.Checked = false; shiftreadCheckBox3.Checked = false; shiftwriteCheckBox3.Checked = false;
            shiftCheckBox4.Checked = false; shiftreadCheckBox4.Checked = false; shiftwriteCheckBox4.Checked = false;
            //feedCheckBox1.Checked = false; feedredCB1.Checked = false; feedwrCB1.Checked = false;
            //feedCheckBox2.Checked = false; feedredCB2.Checked = false; feedwrCB2.Checked = false;
            viewalertmanagerCB1.Checked = false; viewalertmanagerredCB1.Checked = false; viewalertmanagerwrCB1.Checked = false;
            addalertmanagerCB1.Checked = false; addalertmanageredCB1.Checked = false; addalertmanagerwrCB1.Checked = false;
            addalertmanagerCB2.Checked = false; addalertmanageredCB2.Checked = false; addalertmanagerwrCB2.Checked = false;
            facilityCB1.Checked = false; facilityredCB1.Checked = false; facilitywrCB1.Checked = false;
            mpddCB1.Checked = false; mpddredCB1.Checked = false; mpddwrCB1.Checked = false;
            mpddCB2.Checked = false; mpddredCB2.Checked = false; mpddwrCB2.Checked = false;
            mpddCB3.Checked = false; mpddredCB3.Checked = false; mpddwrCB3.Checked = false;
            mpddCB4.Checked = false; mpddredCB4.Checked = false; mpddwrCB4.Checked = false;
            mpddCB5.Checked = false; mpddredCB5.Checked = false; mpddwrCB5.Checked = false;
            //feedCheckBox3.Checked = false; feedredCB3.Checked = false; feedwrCB3.Checked = false;
            activereview1.Checked = false; activerev1.Checked = false; activerev3.Checked = false;
            activereview2.Checked = false; activerev2.Checked = false; activerev4.Checked = false;
            invetCheckBox3.Checked = false; invetredchkbox13.Checked = false; invetwrchkbox3.Checked = false;
            addaltCheckBox1.Checked = false; altredCB1.Checked = false; altwrCB1.Checked = false;
            addaltCheckBox2.Checked = false; altredCB2.Checked = false; altwrCB2.Checked = false;
            //feedCB1.Checked = false; feedmgmtredCB1.Checked = false; feedmgmtwrCB1.Checked = false;
            //feedCB2.Checked = false; feedmgmtredCB2.Checked = false; feedmgmtwrCB2.Checked = false;

        }
        protected void cur_occur_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Occurence, occureReadOnly, occurWriteOnly, Label4); }
        protected void cur_visit_Button_Click(object sender, EventArgs e)
        { insertupdatefun(CheckBox18, visitReadOnly, vivitWriteOnly, Label4); }
        protected void cur_conctract_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Contractor, contractReadOnly, contractWriteOnly, Label4); }
        protected void cur_event_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Event, eventReadOnly, eventWriteOnly, Label4); }
        protected void cur_lost_Button_Click(object sender, EventArgs e)
        { insertupdatefun(Lost_Found, lostReadOnly, lostWriteOnly, Label4); }
        protected void past_in_Button_Click(object sender, EventArgs e)
        { insertupdatefun(pCheck_in_report, p_in_ReadOnly, p_in_WriteOnly, Label5); }
        protected void past_out_Button_Click(object sender, EventArgs e)
        { insertupdatefun(pCheck_out_report, p_out_ReadOnly, p_inc_WriteOnly, Label5); }
        protected void past_inced_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_incident, p_inc_ReadOnly, p_alert_WriteOnly, Label5); }
        protected void past_alert_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_alert, p_alert_ReadOnly, pocr_WriteOnly, Label5); }
        protected void past_occure_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_occurence, p_occure_ReadOnly, p_visit_WriteOnly, Label5); }
        protected void past_visit_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_visit, p_visit_ReadOnly, p_cont_WriteOnly, Label5); }
        protected void past_contract_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_contract, p_contract_ReadOnly, p_event_WriteOnly, Label5); }
        protected void past_event_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_event, p_event_ReadOnly, p_lost_WriteOnly, Label5); }
        protected void past_lost_Button_Click(object sender, EventArgs e)
        { insertupdatefun(p_lost, p_lost_ReadOnly, p_out_WriteOnly, Label5); }
        protected void activerev5_Click(object sender, EventArgs e)
        { insertupdatefun(activereview1, activerev1, activerev3, report1); }
        protected void activerev6_Click(object sender, EventArgs e)
        { insertupdatefun(activereview2, activerev2, activerev4, report1); }
        public void switchcase1(string var)
        {
            switch (var)
            {
                case "4": check_in_report.Checked = true; inReadOnly.Checked = true; CheckBox4.Checked = true; break;
                case "5": Check_out_report.Checked = true; outReadOnly.Checked = true; CheckBox14.Checked = true; break;
                case "6": Incident_Report.Checked = true; incidentReadOnly.Checked = true; incidWriteOnly.Checked = true; break;
                case "7": Alert_Report.Checked = true; alertReadOnly.Checked = true; alertWriteOnly.Checked = true; break;
                case "8": Occurence.Checked = true; occureReadOnly.Checked = true; occurWriteOnly.Checked = true; break;
                case "9": CheckBox18.Checked = true; visitReadOnly.Checked = true; vivitWriteOnly.Checked = true; break;
                case "10": Contractor.Checked = true; contractReadOnly.Checked = true; contractWriteOnly.Checked = true; break;
                case "11": Event.Checked = true; eventReadOnly.Checked = true; eventWriteOnly.Checked = true; break;
                case "12": Lost_Found.Checked = true; lostReadOnly.Checked = true; lostWriteOnly.Checked = true; break;
                case "13": pCheck_in_report.Checked = true; p_in_ReadOnly.Checked = true; p_in_WriteOnly.Checked = true; break;
                case "14": pCheck_out_report.Checked = true; p_out_ReadOnly.Checked = true; p_inc_WriteOnly.Checked = true; break;
                case "15": p_incident.Checked = true; p_inc_ReadOnly.Checked = true; p_alert_WriteOnly.Checked = true; break;
                case "16": p_alert.Checked = true; p_alert_ReadOnly.Checked = true; pocr_WriteOnly.Checked = true; break;
                case "17": p_occurence.Checked = true; p_occure_ReadOnly.Checked = true; p_visit_WriteOnly.Checked = true; break;
                case "18": p_visit.Checked = true; p_visit_ReadOnly.Checked = true; p_cont_WriteOnly.Checked = true; break;
                case "19": p_contract.Checked = true; p_contract_ReadOnly.Checked = true; p_event_WriteOnly.Checked = true; break;
                case "20": p_event.Checked = true; p_event_ReadOnly.Checked = true; p_lost_WriteOnly.Checked = true; break;
                case "21": p_lost.Checked = true; p_lost_ReadOnly.Checked = true; p_out_WriteOnly.Checked = true; break;
                case "23": eveviewCheckBox.Checked = true; eveviewReadOnly.Checked = true; eveviewWriteOnly.Checked = true; break;
                case "24": eveaddCheckBox.Checked = true; eveaddReadOnly.Checked = true; eveaddWriteOnly.Checked = true; break;
                case "33": dtCheckBox1.Checked = true; dtredCheckBox1.Checked = true; CheckBox1.Checked = true; break;
                case "38": dashbordCheckBox1.Checked = true; dashredCB1.Checked = true; dashwrCB1.Checked = true; break;
                case "39": //tspCB1.Checked = true; tspredCB1.Checked = true; tspwrCB1.Checked = true; break;
                case "40": emergencyCB1.Checked = true; emergencyredCB1.Checked = true; emergencywrCB1.Checked = true; break;
                case "45": permissionCB1.Checked = true; permissionredCB1.Checked = true; permissionwrCB1.Checked = true; break;
                case "46": //cameraCB1.Checked = true; cameraredCB1.Checked = true; camerawrCB1.Checked = true; break;
                case "47": asslocCheckBox1.Checked = true; asslocredchkbox1.Checked = true; asslocwrchkbox.Checked = true; break;
                case "48": //pddCB1.Checked = true; pddredCB1.Checked = true; pddwrCB1.Checked = true; break;
                case "50": logsettingCB1.Checked = true; logsettingredCB1.Checked = true; logsettingwrCB1.Checked = true; break;
                case "51": accsettingCB1.Checked = true; accsettingredCB1.Checked = true; accsettingwrCB1.Checked = true; break;
                case "52": //gpsystemCB1.Checked = true; gpsystemredCB1.Checked = true; gpsystemwrCB1.Checked = true; break;
                case "53": logoutCB1.Checked = true; logoutredCB1.Checked = true; logoutwrCB1.Checked = true; break;
                case "54": shiftdepCheckBox1.Checked = true; shiftdepredCheckBox1.Checked = true; shiftdepwrCheckBox1.Checked = true; break;
                case "55": shiftdepCheckBox2.Checked = true; shiftdepredCheckBox2.Checked = true; shiftdepwrCheckBox2.Checked = true; break;
                case "56": shiftdepCheckBox3.Checked = true; shiftdepredCheckBox3.Checked = true; shiftdepwrCheckBox3.Checked = true; break;
                case "57": locCheckBox1.Checked = true; locredCheckBox1.Checked = true; locwrCheckBox1.Checked = true; break;
                case "58": locCheckBox2.Checked = true; locredCheckBox2.Checked = true; locwrCheckBox2.Checked = true; break;
                case "59": locCheckBox3.Checked = true; locredCheckBox3.Checked = true; locwrCheckBox3.Checked = true; break;
                case "60": staffmgmtCB1.Checked = true; staffmgmtredCB1.Checked = true; staffmgmtwrCB1.Checked = true; break;
                case "61": staffmgmtCB2.Checked = true; staffmgmtredCB2.Checked = true; staffmgmtwrCB2.Checked = true; break;
                case "62": staffmgmtCB3.Checked = true; staffmgmtredCB3.Checked = true; staffmgmtwrCB3.Checked = true; break;
                case "128": staffmgmtCB4.Checked = true; staffmgmtredCB4.Checked = true; staffmgmtwrCB4.Checked = true; break;
                case "129": staffmgmtCB5.Checked = true; staffmgmtredCB5.Checked = true; staffmgmtwrCB5.Checked = true; break;
                case "63": invetCheckBox1.Checked = true; invetredchkbox1.Checked = true; invetwrchkbox1.Checked = true; break;
                case "64": invetCheckBox2.Checked = true; invetredchkbox12.Checked = true; invetwrchkbox2.Checked = true; break;
                case "65": //tranCheckBox1.Checked = true; //tranredchkbox1.Checked = true; tranwrchkbox1.Checked = true; break;
                case "66": //tranCheckBox2.Checked = true; //tranredchkbox2.Checked = true; tranwrchkbox2.Checked = true; break;
                case "67":// preCheckBox1.Checked = true; preredCheckBox1.Checked = true; prewrCheckBox1.Checked = true; break;
                case "68": //preCheckBox2.Checked = true; preredCheckBox2.Checked = true; prewrCheckBox2.Checked = true; break;
                case "71": chkoutCheckBox1.Checked = true; chkoutredCB1.Checked = true; chkoutwrCB1.Checked = true; break;
                case "72": chkoutCheckBox2.Checked = true; chkoutredCB2.Checked = true; chkoutwrCB2.Checked = true; break;
                case "73": chkoutCheckBox3.Checked = true; chkoutredCB3.Checked = true; chkoutwrCB3.Checked = true; break;
                case "74": chkinCheckBox1.Checked = true; chkinredCB1.Checked = true; chkinwrCB1.Checked = true; break;
                case "75": chkinCheckBox2.Checked = true; chkinredCB2.Checked = true; chkinwrCB2.Checked = true; break;
                case "76": chkinCheckBox3.Checked = true; chkinredCB3.Checked = true; chkinwrCB3.Checked = true; break;
                case "77": viewCheckBox1.Checked = true; viewredCB1.Checked = true; viewwrCB1.Checked = true; break;
                case "78": viewCheckBox2.Checked = true; viewredCB2.Checked = true; viewwrCB2.Checked = true; break;
                case "79": viewCheckBox3.Checked = true; chkinredCB3.Checked = true; viewwrCB3.Checked = true; break;
                case "80": viewCheckBox4.Checked = true; viewredCB4.Checked = true; viewwrCB4.Checked = true; break;
                case "81": viewCheckBox5.Checked = true; viewredCB5.Checked = true; viewwrCB5.Checked = true; break;
                case "82": viewCheckBox6.Checked = true; viewredCB6.Checked = true; viewwrCB6.Checked = true; break;
                case "83": viewCheckBox7.Checked = true; viewredCB7.Checked = true; viewwrCB7.Checked = true; break;
                case "85": viewaltCheckBox1.Checked = true; viewaltredCB1.Checked = true; viewaltwrCB1.Checked = true; break;
                case "86": followCheckBox1.Checked = true; folllowredCB1.Checked = true; folllowwrCB1.Checked = true; break;
                case "87": followCheckBox2.Checked = true; folllowredCB2.Checked = true; folllowwrCB2.Checked = true; break;
                case "89": keymanagerCB1.Checked = true; keymanagerredCB1.Checked = true; keymanagerwrCB1.Checked = true; break;
                case "90": keymanagerCB2.Checked = true; keymanagerredCB2.Checked = true; keymanagerwrCB2.Checked = true; break;
                case "91": keymanagerCB3.Checked = true; keymanagerredCB3.Checked = true; keymanagerwrCB3.Checked = true; break;
                case "93": passmanagerCB1.Checked = true; passmanagerredCB1.Checked = true; passmanagerwrCB1.Checked = true; break;
                case "94": passmanagerCB2.Checked = true; passmanagerredCB2.Checked = true; passmanagerwrCB2.Checked = true; break;
                case "96": itemanagerCB1.Checked = true; itemanageredCB1.Checked = true; itemanagerwrCB1.Checked = true; break;
                case "97": itemanagerCB2.Checked = true; itemanageredCB2.Checked = true; itemanagerwrCB2.Checked = true; break;
                case "99": sopmanagerCB1.Checked = true; sopmanageredCB1.Checked = true; sopmanagerwrCB1.Checked = true; break;
                case "100": sopmanagerCB2.Checked = true; sopmanageredCB2.Checked = true; sopmanagerwrCB1.Checked = true; break;
                //case "102": feedCB1.Checked = true; feedmgmtredCB1.Checked = true; feedmgmtwrCB1.Checked = true; break;
                //case "103": feedCB2.Checked = true; feedmgmtredCB2.Checked = true; feedmgmtwrCB2.Checked = true; break;
                case "104": sopCheckBox1.Checked = true; sopredCB1.Checked = true; sopwrCB1.Checked = true; break;
                case "105": sopCheckBox2.Checked = true; sopredCB2.Checked = true; sopwrCB2.Checked = true; break;
                case "106": creportCB1.Checked = true; creportredCB1.Checked = true; creportwrCB1.Checked = true; break;
                case "107": creportCB2.Checked = true; creportredCB2.Checked = true; creportwrCB2.Checked = true; break;
                case "135": creportCB3.Checked = true; creportredCB3.Checked = true; creportwrCB3.Checked = true; break;
                case "108": shiftCheckBox1.Checked = true; shiftreadCheckBox1.Checked = true; shiftwriteCheckBox1.Checked = true; break;
                case "109": shiftCheckBox2.Checked = true; shiftreadCheckBox2.Checked = true; shiftwriteCheckBox2.Checked = true; break;
                case "110": shiftCheckBox3.Checked = true; shiftreadCheckBox3.Checked = true; shiftwriteCheckBox3.Checked = true; break;
                case "111": shiftCheckBox4.Checked = true; shiftreadCheckBox4.Checked = true; shiftwriteCheckBox4.Checked = true; break;
                case "112": //feedCheckBox1.Checked = true; feedredCB1.Checked = true; feedwrCB1.Checked = true; break;
                case "113": //feedCheckBox2.Checked = true; feedredCB2.Checked = true; feedwrCB2.Checked = true; break;
                case "116": viewalertmanagerCB1.Checked = true; viewalertmanagerredCB1.Checked = true; viewalertmanagerwrCB1.Checked = true; break;
                case "117": addalertmanagerCB1.Checked = true; addalertmanageredCB1.Checked = true; addalertmanagerwrCB1.Checked = true; break;
                case "118": addalertmanagerCB2.Checked = true; addalertmanageredCB2.Checked = true; addalertmanagerwrCB2.Checked = true; break;
                case "119": facilityCB1.Checked = true; facilityredCB1.Checked = true; facilitywrCB1.Checked = true; break;
                case "120": mpddCB1.Checked = true; mpddredCB1.Checked = true; mpddwrCB1.Checked = true; break;
                case "121": mpddCB2.Checked = true; mpddredCB2.Checked = true; mpddwrCB2.Checked = true; break;
                case "122": mpddCB3.Checked = true; mpddredCB3.Checked = true; mpddwrCB3.Checked = true; break;
                case "123": mpddCB4.Checked = true; mpddredCB4.Checked = true; mpddwrCB4.Checked = true; break;
                case "124": mpddCB5.Checked = true; mpddredCB5.Checked = true; mpddwrCB5.Checked = true; break;
                case "125": //feedCheckBox3.Checked = true; feedredCB3.Checked = true; feedwrCB3.Checked = true; break;
                case "126": activereview1.Checked = true; activerev1.Checked = true; activerev3.Checked = true; break;
                case "127": activereview2.Checked = true; activerev2.Checked = true; activerev4.Checked = true; break;
                case "130": invetCheckBox3.Checked = true; invetredchkbox13.Checked = true; invetwrchkbox3.Checked = true; break;
                case "131": addaltCheckBox1.Checked = true; altredCB1.Checked = true; altwrCB1.Checked = true; break;
                case "132": addaltCheckBox2.Checked = true; altredCB2.Checked = true; altwrCB2.Checked = true; break;
                //case "133": feedCB1.Checked = true; feedmgmtredCB1.Checked = true; feedmgmtwrCB1.Checked = true; break;
                //case "134": feedCB2.Checked = true; feedmgmtredCB2.Checked = true; feedmgmtwrCB2.Checked = true; break;
                default: break;
            }
        }
        public void switchcase2(string var)
        {
            switch (var)
            {
                case "4": check_in_report.Checked = true; inReadOnly.Checked = true; break;
                case "5": Check_out_report.Checked = true; outReadOnly.Checked = true; break;
                case "6": Incident_Report.Checked = true; incidentReadOnly.Checked = true; break;
                case "7": Alert_Report.Checked = true; alertReadOnly.Checked = true; break;
                case "8": Occurence.Checked = true; occureReadOnly.Checked = true; break;
                case "9": CheckBox18.Checked = true; visitReadOnly.Checked = true; break;
                case "10": Contractor.Checked = true; contractReadOnly.Checked = true; break;
                case "11": Event.Checked = true; eventReadOnly.Checked = true; break;
                case "12": Lost_Found.Checked = true; lostReadOnly.Checked = true; break;
                case "13": pCheck_in_report.Checked = true; p_in_ReadOnly.Checked = true; break;
                case "14": pCheck_out_report.Checked = true; p_out_ReadOnly.Checked = true; break;
                case "15": p_incident.Checked = true; p_inc_ReadOnly.Checked = true; break;
                case "16": p_alert.Checked = true; p_alert_ReadOnly.Checked = true; break;
                case "17": p_occurence.Checked = true; p_occure_ReadOnly.Checked = true; break;
                case "18": p_visit.Checked = true; p_visit_ReadOnly.Checked = true; break;
                case "19": p_contract.Checked = true; p_contract_ReadOnly.Checked = true; break;
                case "20": p_event.Checked = true; p_event_ReadOnly.Checked = true; break;
                case "21": p_lost.Checked = true; p_lost_ReadOnly.Checked = true; break;
                case "23": eveviewCheckBox.Checked = true; eveviewReadOnly.Checked = true; break;
                case "24": eveaddCheckBox.Checked = true; eveaddReadOnly.Checked = true; break;
                case "33": dtCheckBox1.Checked = true; dtredCheckBox1.Checked = true; break;
                case "38": dashbordCheckBox1.Checked = true; dashredCB1.Checked = true; break;
                case "39": //tspCB1.Checked = true; tspredCB1.Checked = true; break;
                case "40": emergencyCB1.Checked = true; emergencyredCB1.Checked = true; break;
                case "45": permissionCB1.Checked = true; permissionredCB1.Checked = true; break;
                case "46": //cameraCB1.Checked = true; cameraredCB1.Checked = true; break;
                case "47": asslocCheckBox1.Checked = true; asslocredchkbox1.Checked = true; break;
                case "48": //pddCB1.Checked = true; pddredCB1.Checked = true; pddwrCB1.Checked = true; break;
                case "50": logsettingCB1.Checked = true; logsettingredCB1.Checked = true; break;
                case "51": accsettingCB1.Checked = true; accsettingredCB1.Checked = true; break;
                case "52": //gpsystemCB1.Checked = true; gpsystemredCB1.Checked = true; break;
                case "53": logoutCB1.Checked = true; logoutredCB1.Checked = true; break;
                case "54": shiftdepCheckBox1.Checked = true; shiftdepredCheckBox1.Checked = true; break;
                case "55": shiftdepCheckBox2.Checked = true; shiftdepredCheckBox2.Checked = true; break;
                case "56": shiftdepCheckBox3.Checked = true; shiftdepredCheckBox3.Checked = true; break;
                case "57": locCheckBox1.Checked = true; locredCheckBox1.Checked = true; break;
                case "58": locCheckBox2.Checked = true; locredCheckBox2.Checked = true; break;
                case "59": locCheckBox3.Checked = true; locredCheckBox3.Checked = true; break;
                case "60": staffmgmtCB1.Checked = true; staffmgmtredCB1.Checked = true; break;
                case "61": staffmgmtCB2.Checked = true; staffmgmtredCB2.Checked = true; break;
                case "62": staffmgmtCB3.Checked = true; staffmgmtredCB3.Checked = true; break;
                case "128": staffmgmtCB4.Checked = true; staffmgmtredCB4.Checked = true; break;
                case "129": staffmgmtCB5.Checked = true; staffmgmtredCB5.Checked = true; break;
                case "63": invetCheckBox1.Checked = true; invetredchkbox1.Checked = true; break;
                case "64": invetCheckBox2.Checked = true; invetredchkbox12.Checked = true; break;
                case "65": //tranCheckBox1.Checked = true; //tranredchkbox1.Checked = true; break;
                case "66": //tranCheckBox2.Checked = true; //tranredchkbox2.Checked = true; break;
                case "67": //preCheckBox1.Checked = true; preredCheckBox1.Checked = true; break;
                case "68": //preCheckBox2.Checked = true; preredCheckBox2.Checked = true; break;
                case "71": chkoutCheckBox1.Checked = true; chkoutredCB1.Checked = true; break;
                case "72": chkoutCheckBox2.Checked = true; chkoutredCB2.Checked = true; break;
                case "73": chkoutCheckBox3.Checked = true; chkoutredCB3.Checked = true; break;
                case "74": chkinCheckBox1.Checked = true; chkinredCB1.Checked = true; break;
                case "75": chkinCheckBox2.Checked = true; chkinredCB2.Checked = true; break;
                case "76": chkinCheckBox3.Checked = true; chkinredCB3.Checked = true; break;
                case "77": viewCheckBox1.Checked = true; viewredCB1.Checked = true; break;
                case "78": viewCheckBox2.Checked = true; viewredCB2.Checked = true; break;
                case "79": viewCheckBox3.Checked = true; chkinredCB3.Checked = true; break;
                case "80": viewCheckBox4.Checked = true; viewredCB4.Checked = true; break;
                case "81": viewCheckBox5.Checked = true; viewredCB5.Checked = true; break;
                case "82": viewCheckBox6.Checked = true; viewredCB6.Checked = true; break;
                case "83": viewCheckBox7.Checked = true; viewredCB7.Checked = true; break;
                case "85": viewaltCheckBox1.Checked = true; viewaltredCB1.Checked = true; break;
                case "86": followCheckBox1.Checked = true; folllowredCB1.Checked = true; break;
                case "87": followCheckBox2.Checked = true; folllowredCB2.Checked = true; break;
                case "89": keymanagerCB1.Checked = true; keymanagerredCB1.Checked = true; break;
                case "90": keymanagerCB2.Checked = true; keymanagerredCB2.Checked = true; break;
                case "91": keymanagerCB3.Checked = true; keymanagerredCB3.Checked = true; break;
                case "93": passmanagerCB1.Checked = true; passmanagerredCB1.Checked = true; break;
                case "94": passmanagerCB2.Checked = true; passmanagerredCB2.Checked = true; break;
                case "96": itemanagerCB1.Checked = true; itemanageredCB1.Checked = true; break;
                case "97": itemanagerCB2.Checked = true; itemanageredCB2.Checked = true; break;
                case "99": sopmanagerCB1.Checked = true; sopmanageredCB1.Checked = true; break;
                case "100": sopmanagerCB2.Checked = true; sopmanageredCB2.Checked = true; break;
                case "104": sopCheckBox1.Checked = true; sopredCB1.Checked = true; break;
                case "105": sopCheckBox2.Checked = true; sopredCB2.Checked = true; break;
                case "106": creportCB1.Checked = true; creportredCB1.Checked = true; break;
                case "107": creportCB2.Checked = true; creportredCB2.Checked = true; break;
                case "135": creportCB3.Checked = true; creportredCB3.Checked = true; break;
                case "108": shiftCheckBox1.Checked = true; shiftreadCheckBox1.Checked = true; break;
                case "109": shiftCheckBox2.Checked = true; shiftreadCheckBox2.Checked = true; break;
                case "110": shiftCheckBox3.Checked = true; shiftreadCheckBox3.Checked = true; break;
                case "111": shiftCheckBox4.Checked = true; shiftreadCheckBox4.Checked = true; break;
                case "112": //feedCheckBox1.Checked = true; feedredCB1.Checked = true; break;
                case "113": //feedCheckBox2.Checked = true; feedredCB2.Checked = true; break;
                case "116": viewalertmanagerCB1.Checked = true; viewalertmanagerredCB1.Checked = true; break;
                case "117": addalertmanagerCB1.Checked = true; addalertmanageredCB1.Checked = true; break;
                case "118": addalertmanagerCB2.Checked = true; addalertmanageredCB2.Checked = true; break;
                case "119": facilityCB1.Checked = true; facilityredCB1.Checked = true; break;
                case "120": mpddCB1.Checked = true; mpddredCB1.Checked = true; break;
                case "121": mpddCB2.Checked = true; mpddredCB2.Checked = true; break;
                case "122": mpddCB3.Checked = true; mpddredCB3.Checked = true; break;
                case "123": mpddCB4.Checked = true; mpddredCB4.Checked = true; break;
                case "124": mpddCB5.Checked = true; mpddredCB5.Checked = true; break;
                case "125": //feedCheckBox3.Checked = true; feedredCB3.Checked = true; break;
                case "130": invetCheckBox3.Checked = true; invetredchkbox13.Checked = true; break;
                case "131": addaltCheckBox1.Checked = true; altredCB1.Checked = true; break;
                case "132": addaltCheckBox2.Checked = true; altredCB2.Checked = true; break;
                //case "133": feedCB1.Checked = true; feedmgmtredCB1.Checked = true; break;
                //case "134": feedCB2.Checked = true; feedmgmtredCB2.Checked = true; break;
                case "126": activereview1.Checked = true; activerev1.Checked = true; break;
                case "127": activereview2.Checked = true; activerev2.Checked = true; break;
                //case "102": feedCB1.Checked = true; feedmgmtredCB1.Checked = true;break;
                //case "103": feedCB2.Checked = true; feedmgmtredCB2.Checked = true;break;
                default: break;
            }
        }
        public void switchcase3(string var)
        {
            switch (var)
            {
                case "4": check_in_report.Checked = true; CheckBox4.Checked = true; break;
                case "5": Check_out_report.Checked = true; CheckBox14.Checked = true; break;
                case "6": Incident_Report.Checked = true; incidWriteOnly.Checked = true; break;
                case "7": Alert_Report.Checked = true; alertWriteOnly.Checked = true; break;
                case "8": Occurence.Checked = true; occurWriteOnly.Checked = true; break;
                case "9": CheckBox18.Checked = true; vivitWriteOnly.Checked = true; break;
                case "10": Contractor.Checked = true; contractWriteOnly.Checked = true; break;
                case "11": Event.Checked = true; eventWriteOnly.Checked = true; break;
                case "12": Lost_Found.Checked = true; lostWriteOnly.Checked = true; break;
                case "13": pCheck_in_report.Checked = true; p_in_WriteOnly.Checked = true; break;
                case "14": pCheck_out_report.Checked = true; p_inc_WriteOnly.Checked = true; break;
                case "15": p_incident.Checked = true; p_alert_WriteOnly.Checked = true; break;
                case "16": p_alert.Checked = true; pocr_WriteOnly.Checked = true; break;
                case "17": p_occurence.Checked = true; p_visit_WriteOnly.Checked = true; break;
                case "18": p_visit.Checked = true; p_cont_WriteOnly.Checked = true; break;
                case "19": p_contract.Checked = true; p_event_WriteOnly.Checked = true; break;
                case "20": p_event.Checked = true; p_lost_WriteOnly.Checked = true; break;
                case "21": p_lost.Checked = true; p_out_WriteOnly.Checked = true; break;
                case "23": eveviewCheckBox.Checked = true; eveviewWriteOnly.Checked = true; break;
                case "24": eveaddCheckBox.Checked = true; eveaddWriteOnly.Checked = true; break;
                case "33": dtCheckBox1.Checked = true; CheckBox1.Checked = true; break;
                case "38": dashbordCheckBox1.Checked = true; dashwrCB1.Checked = true; break;
                case "39": //tspCB1.Checked = true; tspwrCB1.Checked = true; break;
                case "40": emergencyCB1.Checked = true; emergencywrCB1.Checked = true; break;
                case "45": permissionCB1.Checked = true; permissionwrCB1.Checked = true; break;
                case "46": //cameraCB1.Checked = true; camerawrCB1.Checked = true; break;
                case "47": asslocCheckBox1.Checked = true; asslocwrchkbox.Checked = true; break;
                case "48": //pddCB1.Checked = true; pddwrCB1.Checked = true; break;
                case "50": logsettingCB1.Checked = true; logsettingwrCB1.Checked = true; break;
                case "51": accsettingCB1.Checked = true; accsettingwrCB1.Checked = true; break;
                case "52": //gpsystemCB1.Checked = true; gpsystemwrCB1.Checked = true; break;
                case "53": logoutCB1.Checked = true; logoutwrCB1.Checked = true; break;
                case "54": shiftdepCheckBox1.Checked = true; shiftdepwrCheckBox1.Checked = true; break;
                case "55": shiftdepCheckBox2.Checked = true; shiftdepwrCheckBox2.Checked = true; break;
                case "56": shiftdepCheckBox3.Checked = true; shiftdepwrCheckBox3.Checked = true; break;
                case "57": locCheckBox1.Checked = true; locwrCheckBox1.Checked = true; break;
                case "58": locCheckBox2.Checked = true; locwrCheckBox2.Checked = true; break;
                case "59": locCheckBox3.Checked = true; locwrCheckBox3.Checked = true; break;
                case "60": staffmgmtCB1.Checked = true; staffmgmtwrCB1.Checked = true; break;
                case "61": staffmgmtCB2.Checked = true; staffmgmtwrCB2.Checked = true; break;
                case "62": staffmgmtCB3.Checked = true; staffmgmtwrCB3.Checked = true; break;
                case "128": staffmgmtCB4.Checked = true; staffmgmtwrCB4.Checked = true; break;
                case "129": staffmgmtCB5.Checked = true; staffmgmtwrCB5.Checked = true; break;
                case "63": invetCheckBox1.Checked = true; invetwrchkbox1.Checked = true; break;
                case "64": invetCheckBox2.Checked = true; invetwrchkbox2.Checked = true; break;
                case "65": //tranCheckBox1.Checked = true; //tranwrchkbox1.Checked = true; break;
                case "66": //tranCheckBox2.Checked = true; //tranwrchkbox2.Checked = true; break;
                case "67": //preCheckBox1.Checked = true; prewrCheckBox1.Checked = true; break;
                case "68": //preCheckBox2.Checked = true; prewrCheckBox2.Checked = true; break;
                case "71": chkoutCheckBox1.Checked = true; chkoutwrCB1.Checked = true; break;
                case "72": chkoutCheckBox2.Checked = true; chkoutwrCB2.Checked = true; break;
                case "73": chkoutCheckBox3.Checked = true; chkoutwrCB3.Checked = true; break;
                case "74": chkinCheckBox1.Checked = true; chkinwrCB1.Checked = true; break;
                case "75": chkinCheckBox2.Checked = true; chkinwrCB2.Checked = true; break;
                case "76": chkinCheckBox3.Checked = true; chkinwrCB3.Checked = true; break;
                case "77": viewCheckBox1.Checked = true; viewwrCB1.Checked = true; break;
                case "78": viewCheckBox2.Checked = true; viewwrCB2.Checked = true; break;
                case "79": viewCheckBox3.Checked = true; viewwrCB3.Checked = true; break;
                case "80": viewCheckBox4.Checked = true; viewwrCB4.Checked = true; break;
                case "81": viewCheckBox5.Checked = true; viewwrCB5.Checked = true; break;
                case "82": viewCheckBox6.Checked = true; viewwrCB6.Checked = true; break;
                case "83": viewCheckBox7.Checked = true; viewwrCB7.Checked = true; break;
                case "85": viewaltCheckBox1.Checked = true; viewaltwrCB1.Checked = true; break;
                case "86": followCheckBox1.Checked = true; folllowwrCB1.Checked = true; break;
                case "87": followCheckBox2.Checked = true; folllowwrCB2.Checked = true; break;
                case "89": keymanagerCB1.Checked = true; keymanagerwrCB1.Checked = true; break;
                case "90": keymanagerCB2.Checked = true; keymanagerwrCB2.Checked = true; break;
                case "91": keymanagerCB3.Checked = true; keymanagerwrCB3.Checked = true; break;
                case "93": passmanagerCB1.Checked = true; passmanagerwrCB1.Checked = true; break;
                case "94": passmanagerCB2.Checked = true; passmanagerwrCB2.Checked = true; break;
                case "96": itemanagerCB1.Checked = true; itemanagerwrCB1.Checked = true; break;
                case "97": itemanagerCB2.Checked = true; itemanagerwrCB2.Checked = true; break;
                case "99": sopmanagerCB1.Checked = true; sopmanagerwrCB1.Checked = true; break;
                case "100": sopmanagerCB2.Checked = true; sopmanagerwrCB1.Checked = true; break;
                case "104": sopCheckBox1.Checked = true; sopwrCB1.Checked = true; break;
                case "105": sopCheckBox2.Checked = true; sopwrCB2.Checked = true; break;
                case "106": creportCB1.Checked = true; creportwrCB1.Checked = true; break;
                case "107": creportCB2.Checked = true; creportwrCB2.Checked = true; break;
                case "135": creportCB3.Checked = true; creportwrCB3.Checked = true; break;
                case "108": shiftCheckBox1.Checked = true; shiftwriteCheckBox1.Checked = true; break;
                case "109": shiftCheckBox2.Checked = true; shiftwriteCheckBox2.Checked = true; break;
                case "110": shiftCheckBox3.Checked = true; shiftwriteCheckBox2.Checked = true; break;
                case "111": shiftCheckBox4.Checked = true; shiftwriteCheckBox2.Checked = true; break;
                case "112": //feedCheckBox1.Checked = true; feedwrCB1.Checked = true; break;
                case "113": //feedCheckBox2.Checked = true; feedwrCB2.Checked = true; break;
                case "116": viewalertmanagerCB1.Checked = true; viewalertmanagerwrCB1.Checked = true; break;
                case "117": addalertmanagerCB1.Checked = true; addalertmanagerwrCB1.Checked = true; break;
                case "118": addalertmanagerCB2.Checked = true; addalertmanagerwrCB2.Checked = true; break;
                case "119": facilityCB1.Checked = true; facilitywrCB1.Checked = true; break;
                case "120": mpddCB1.Checked = true; mpddwrCB1.Checked = true; break;
                case "121": mpddCB2.Checked = true; mpddwrCB2.Checked = true; break;
                case "122": mpddCB3.Checked = true; mpddwrCB3.Checked = true; break;
                case "123": mpddCB4.Checked = true; mpddwrCB4.Checked = true; break;
                case "124": mpddCB5.Checked = true; mpddwrCB5.Checked = true; break;
                case "125": //feedCheckBox3.Checked = true; feedwrCB3.Checked = true; break;
                case "130": invetCheckBox3.Checked = true; invetwrchkbox3.Checked = true; break;
                case "131": addaltCheckBox1.Checked = true; altwrCB1.Checked = true; break;
                case "132": addaltCheckBox2.Checked = true; altwrCB2.Checked = true; break;
                //case "133": feedCB1.Checked = true; feedmgmtwrCB1.Checked = true; break;
                //case "134": feedCB2.Checked = true; feedmgmtwrCB2.Checked = true; break;
                case "126": activereview1.Checked = true; activerev3.Checked = true; break;
                case "127": activereview2.Checked = true; activerev4.Checked = true; break;
                //case "102": feedCB1.Checked = true;feedmgmtwrCB1.Checked = true; break;
                //case "103": feedCB2.Checked = true;feedmgmtwrCB2.Checked = true; break;
                default: break;
            }
        }
        public void switchcase4(string var)
        {
            switch (var)
            {
                case "4": check_in_report.Checked = true; break;
                case "5": Check_out_report.Checked = true; break;
                case "6": Incident_Report.Checked = true; break;
                case "7": Alert_Report.Checked = true; break;
                case "8": Occurence.Checked = true; break;
                case "9": CheckBox18.Checked = true; break;
                case "10": Contractor.Checked = true; break;
                case "11": Event.Checked = true; break;
                case "12": Lost_Found.Checked = true; break;
                case "13": pCheck_in_report.Checked = true; break;
                case "14": pCheck_out_report.Checked = true; break;
                case "15": p_incident.Checked = true; break;
                case "16": p_alert.Checked = true; break;
                case "17": p_occurence.Checked = true; break;
                case "18": p_visit.Checked = true; break;
                case "19": p_contract.Checked = true; break;
                case "20": p_event.Checked = true; break;
                case "21": p_lost.Checked = true; break;
                case "23": eveviewCheckBox.Checked = true; break;
                case "24": eveaddCheckBox.Checked = true; break;
                case "33": dtCheckBox1.Checked = true; break;
                case "38": dashbordCheckBox1.Checked = true; break;
                case "39": //tspCB1.Checked = true; break;
                case "40": emergencyCB1.Checked = true; break;
                case "45": permissionCB1.Checked = true; break;
                case "46": //cameraCB1.Checked = true; break;
                case "47": asslocCheckBox1.Checked = true; break;
                case "48": //pddCB1.Checked = true; break;
                case "50": logsettingCB1.Checked = true; break;
                case "51": accsettingCB1.Checked = true; break;
                case "52": //gpsystemCB1.Checked = true; break;
                case "53": logoutCB1.Checked = true; break;
                case "54": shiftdepCheckBox1.Checked = true; break;
                case "55": shiftdepCheckBox2.Checked = true; break;
                case "56": shiftdepCheckBox3.Checked = true; break;
                case "57": locCheckBox1.Checked = true; break;
                case "58": locCheckBox2.Checked = true; break;
                case "59": locCheckBox3.Checked = true; break;
                case "60": staffmgmtCB1.Checked = true; break;
                case "61": staffmgmtCB2.Checked = true; break;
                case "62": staffmgmtCB3.Checked = true; break;
                case "128": staffmgmtCB4.Checked = true; break;
                case "129": staffmgmtCB5.Checked = true; break;
                case "63": invetCheckBox1.Checked = true; break;
                case "64": invetCheckBox2.Checked = true; break;
                case "65": //tranCheckBox1.Checked = true; break;
                case "66": //tranCheckBox2.Checked = true; break;
                case "67": //preCheckBox1.Checked = true; break;
                case "68": //preCheckBox2.Checked = true; break;
                case "71": chkoutCheckBox1.Checked = true; break;
                case "72": chkoutCheckBox2.Checked = true; break;
                case "73": chkoutCheckBox3.Checked = true; break;
                case "74": chkinCheckBox1.Checked = true; break;
                case "75": chkinCheckBox2.Checked = true; break;
                case "76": chkinCheckBox3.Checked = true; break;
                case "77": viewCheckBox1.Checked = true; break;
                case "78": viewCheckBox2.Checked = true; break;
                case "79": viewCheckBox3.Checked = true; break;
                case "80": viewCheckBox4.Checked = true; break;
                case "81": viewCheckBox5.Checked = true; break;
                case "82": viewCheckBox6.Checked = true; break;
                case "83": viewCheckBox7.Checked = true; break;
                case "85": viewaltCheckBox1.Checked = true; break;
                case "86": followCheckBox1.Checked = true; break;
                case "87": followCheckBox2.Checked = true; break;
                case "89": keymanagerCB1.Checked = true; break;
                case "90": keymanagerCB2.Checked = true; break;
                case "91": keymanagerCB3.Checked = true; break;
                case "93": passmanagerCB1.Checked = true; break;
                case "94": passmanagerCB2.Checked = true; break;
                case "96": itemanagerCB1.Checked = true; break;
                case "97": itemanagerCB2.Checked = true; break;
                case "99": sopmanagerCB1.Checked = true; break;
                case "100": sopmanagerCB2.Checked = true; break;
                case "104": sopCheckBox1.Checked = true; break;
                case "105": sopCheckBox2.Checked = true; break;
                case "106": creportCB1.Checked = true; break;
                case "107": creportCB2.Checked = true; break;
                case "135": creportCB3.Checked = true; break;
                case "108": shiftCheckBox1.Checked = true; break;
                case "109": shiftCheckBox2.Checked = true; break;
                case "110": shiftCheckBox3.Checked = true; break;
                case "111": shiftCheckBox4.Checked = true; break;
                case "112": //feedCheckBox1.Checked = true; break;
                case "113": //feedCheckBox2.Checked = true; break;
                case "116": viewalertmanagerCB1.Checked = true; break;
                case "117": addalertmanagerCB1.Checked = true; break;
                case "118": addalertmanagerCB2.Checked = true; break;
                case "119": facilityCB1.Checked = true; break;
                case "120": mpddCB1.Checked = true; break;
                case "121": mpddCB2.Checked = true; break;
                case "122": mpddCB3.Checked = true; break;
                case "123": mpddCB4.Checked = true; break;
                case "124": mpddCB5.Checked = true; break;
                case "125": //feedCheckBox3.Checked = true; break;
                case "130": invetCheckBox3.Checked = true; break;
                case "131": addaltCheckBox1.Checked = true; break;
                case "132": addaltCheckBox2.Checked = true; break;
                //case "133": feedCB1.Checked = true; break;
                //case "134": feedCB2.Checked = true; break;
                case "126": activereview1.Checked = true; break;
                case "127": activereview2.Checked = true; break;
                //case "102": feedCB1.Checked = true;break;
                //case "103": feedCB2.Checked = true;break;
                default:
                    break;
            }
        }
        protected void shiftdepButton1_Click(object sender, EventArgs e)
        { insertupdatefun(shiftdepCheckBox1, shiftdepredCheckBox1, shiftdepwrCheckBox1, shiftdep); }
        protected void shiftdepButton2_Click(object sender, EventArgs e)
        { insertupdatefun(shiftdepCheckBox2, shiftdepredCheckBox2, shiftdepwrCheckBox2, shiftdep); }
        protected void shiftdepButton3_Click(object sender, EventArgs e)
        { insertupdatefun(shiftdepCheckBox3, shiftdepredCheckBox3, shiftdepwrCheckBox3, shiftdep); }
        protected void shiftButton1_Click(object sender, EventArgs e)
        { insertupdatefun(shiftCheckBox1, shiftreadCheckBox1, shiftwriteCheckBox1, shift); }
        protected void shiftButton2_Click(object sender, EventArgs e)
        { insertupdatefun(shiftCheckBox2, shiftreadCheckBox2, shiftwriteCheckBox2, shift); }
        protected void shiftButton3_Click(object sender, EventArgs e)
        { insertupdatefun(shiftCheckBox3, shiftreadCheckBox3, shiftwriteCheckBox3, shift); }
        protected void shiftButton4_Click(object sender, EventArgs e)
        { insertupdatefun(shiftCheckBox4, shiftreadCheckBox4, shiftwriteCheckBox4, shift); }
        protected void asslocButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(asslocCheckBox1, asslocredchkbox1, asslocwrchkbox, asslocationmgmt); }
        protected void locButton1_Click(object sender, EventArgs e)
        { insertupdatefun(locCheckBox1, locredCheckBox1, locwrCheckBox1, locationmanagement); }
        protected void locButton2_Click(object sender, EventArgs e)
        { insertupdatefun(locCheckBox2, locredCheckBox2, locwrCheckBox2, locationmanagement); }
        protected void locButton3_Click(object sender, EventArgs e)
        { insertupdatefun(locCheckBox3, locredCheckBox3, locwrCheckBox3, locationmanagement); }
        protected void invetButton1_Click(object sender, EventArgs e)
        { insertupdatefun(invetCheckBox1, invetredchkbox1, invetwrchkbox1, inventrymgmt); }
        protected void invetButton2_Click(object sender, EventArgs e)
        { insertupdatefun(invetCheckBox2, invetredchkbox12, invetwrchkbox2, inventrymgmt); }
        protected void invetButton3_Click(object sender, EventArgs e)
        { insertupdatefun(invetCheckBox3, invetredchkbox13, invetwrchkbox3, inventrymgmt); }
        protected void preButton2_Click(object sender, EventArgs e)
        { //insertupdatefun(preCheckBox2, preredCheckBox2, prewrCheckBox2, previsitormgmt);
        }
        protected void preButton1_Click(object sender, EventArgs e)
        { //insertupdatefun(preCheckBox1, preredCheckBox1, prewrCheckBox1, previsitormgmt); 
        }
        protected void tranButton1_Click(object sender, EventArgs e)
        { //insertupdatefun(tranCheckBox1, tranredchkbox1, tranwrchkbox1, tranningmgmt); 
        }
        protected void tranButton2_Click(object sender, EventArgs e)
        { //insertupdatefun(tranCheckBox2, tranredchkbox2, tranwrchkbox2, tranningmgmt);
        }
        protected void chkinButton1_Click(object sender, EventArgs e)
        { insertupdatefun(chkinCheckBox1, chkinredCB1, chkinwrCB1, chkinLabel); }
        protected void chkinButton2_Click(object sender, EventArgs e)
        { insertupdatefun(chkinCheckBox2, chkinredCB2, chkinwrCB2, chkinLabel); }
        protected void chkinButton3_Click(object sender, EventArgs e)
        { insertupdatefun(chkinCheckBox3, chkinredCB3, chkinwrCB3, chkinLabel); }
        protected void chkoutButton1_Click(object sender, EventArgs e)
        { insertupdatefun(chkoutCheckBox1, chkoutredCB1, chkoutwrCB1, chkoutLabel); }
        protected void chkoutButton2_Click(object sender, EventArgs e)
        { insertupdatefun(chkoutCheckBox2, chkoutredCB2, chkoutwrCB2, chkoutLabel); }
        protected void chkoutButton3_Click(object sender, EventArgs e)
        { insertupdatefun(chkoutCheckBox3, chkoutredCB3, chkoutwrCB3, chkoutLabel); }
        protected void feedButton1_Click(object sender, EventArgs e)
        { //insertupdatefun(feedCheckBox1, feedredCB1, feedwrCB1, feedbackmgmt); 
        }
        protected void feedButton2_Click(object sender, EventArgs e)
        { //insertupdatefun(feedCheckBox2, feedredCB2, feedwrCB2, feedbackmgmt); 
        }
        protected void feedButton3_Click(object sender, EventArgs e)
        { //insertupdatefun(feedCheckBox3, feedredCB3, feedwrCB3, feedbackmgmt);
        }
        protected void dtButton1_Click(object sender, EventArgs e)
        {
            //insertupdatefun(dtCheckBox1, dtredCheckBox1, CheckBox1, ldigitaldiary);
            insertupdatefunzero(dtCheckBox1, dtredCheckBox1, CheckBox1, ldigitaldiary);
        }
        protected void viewButton1_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox1, viewredCB1, viewwrCB1, viewreportmgmt); }
        protected void viewButton2_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox2, viewredCB2, viewwrCB2, viewreportmgmt); }
        protected void viewButton3_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox3, chkinredCB3, viewwrCB3, viewreportmgmt); }
        protected void viewButton4_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox4, viewredCB4, viewwrCB4, viewreportmgmt); }
        protected void viewButton5_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox5, viewredCB5, viewwrCB5, viewreportmgmt); }
        protected void viewButton6_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox6, viewredCB6, viewwrCB6, viewreportmgmt); }
        protected void viewButton7_Click(object sender, EventArgs e)
        { insertupdatefun(viewCheckBox7, viewredCB7, viewwrCB7, viewreportmgmt); }
        protected void addaltButton1_Click(object sender, EventArgs e)
        { insertupdatefun(addaltCheckBox1, altredCB1, altwrCB1, addalertLabel); }
        protected void addaltButton2_Click(object sender, EventArgs e)
        { insertupdatefun(addaltCheckBox2, altredCB2, altwrCB2, addalertLabel); }
        protected void viewaltButton1_Click(object sender, EventArgs e)
        { insertupdatefun(viewaltCheckBox1, viewaltredCB1, viewaltwrCB1, alertreport); }
        protected void followButton1_Click(object sender, EventArgs e)
        { insertupdatefun(followCheckBox1, folllowredCB1, folllowwrCB1, followupmgmt); }
        protected void followButton2_Click(object sender, EventArgs e)
        { insertupdatefun(followCheckBox2, folllowredCB2, folllowwrCB2, followupmgmt); }
        protected void dashButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(dashbordCheckBox1, dashredCB1, dashwrCB1, dashboard); }
        protected void keymanagerButton1_Click(object sender, EventArgs e)
        { insertupdatefun(keymanagerCB1, keymanagerredCB1, keymanagerwrCB1, keymanagerLabel); }
        protected void keymanagerButton2_Click(object sender, EventArgs e)
        { insertupdatefun(keymanagerCB2, keymanagerredCB2, keymanagerwrCB2, keymanagerLabel); }
        protected void keymanagerButton3_Click(object sender, EventArgs e)
        { insertupdatefun(keymanagerCB3, keymanagerredCB3, keymanagerwrCB3, keymanagerLabel); }
        protected void passmanagerButton1_Click(object sender, EventArgs e)
        { insertupdatefun(passmanagerCB1, passmanagerredCB1, passmanagerwrCB1, passmanagerLabel); }
        protected void passmanagerButton2_Click(object sender, EventArgs e)
        { insertupdatefun(passmanagerCB2, passmanagerredCB2, passmanagerwrCB2, passmanagerLabel); }
        protected void itemanagerButton1_Click(object sender, EventArgs e)
        { insertupdatefun(itemanagerCB1, itemanageredCB1, itemanagerwrCB1, itemanagerLabel); }
        protected void itemanagerButton2_Click(object sender, EventArgs e)
        { insertupdatefun(itemanagerCB2, itemanageredCB2, itemanagerwrCB2, itemanagerLabel); }
        protected void sopmanagerButton1_Click(object sender, EventArgs e)
        { insertupdatefun(sopmanagerCB1, sopmanageredCB1, sopmanagerwrCB1, sopmanagerLabel); }
        protected void sopmanagerButton2_Click(object sender, EventArgs e)
        { insertupdatefun(sopmanagerCB2, sopmanageredCB2, sopmanagerwrCB1, sopmanagerLabel); }
        protected void viewalertmanagerButton1_Click(object sender, EventArgs e)
        { insertupdatefun(viewalertmanagerCB1, viewalertmanagerredCB1, viewalertmanagerwrCB1, alertmanagerLabel); }
        protected void addalertmanagerButton1_Click(object sender, EventArgs e)
        {

            insertupdatefun(addalertmanagerCB1, addalertmanageredCB1, addalertmanagerwrCB1, addalertmanagerLabel);
        }
        protected void addalertmanagerButton2_Click(object sender, EventArgs e)
        { insertupdatefun(addalertmanagerCB2, addalertmanageredCB2, addalertmanagerwrCB2, addalertmanagerLabel); }
        protected void emergencyButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(emergencyCB1, emergencyredCB1, emergencywrCB1, emergencymgmt); }
        protected void staffmgmtButton1_Click(object sender, EventArgs e)
        { insertupdatefun(staffmgmtCB1, staffmgmtredCB1, staffmgmtwrCB1, staffmanagement); }
        protected void staffmgmtButton2_Click(object sender, EventArgs e)
        { insertupdatefun(staffmgmtCB2, staffmgmtredCB2, staffmgmtwrCB2, staffmanagement); }
        protected void staffmgmtButton3_Click(object sender, EventArgs e)
        { insertupdatefun(staffmgmtCB3, staffmgmtredCB3, staffmgmtwrCB3, staffmanagement); }
        protected void staffmgmtButton4_Click(object sender, EventArgs e)
        { insertupdatefun(staffmgmtCB4, staffmgmtredCB4, staffmgmtwrCB4, staffmanagement); }
        protected void staffmgmtButton5_Click(object sender, EventArgs e)
        { insertupdatefun(staffmgmtCB5, staffmgmtredCB5, staffmgmtwrCB5, staffmanagement); }
        protected void creportButton1_Click(object sender, EventArgs e)
        { insertupdatefun(creportCB1, creportredCB1, creportwrCB1, createreport); }
        protected void creportButton2_Click(object sender, EventArgs e)
        { insertupdatefun(creportCB2, creportredCB2, creportwrCB2, createreport); }
        protected void creportButton3_Click(object sender, EventArgs e)
        { insertupdatefun(creportCB3, creportredCB3, creportwrCB3, createreport); }
        protected void cameraButton1_Click(object sender, EventArgs e)
        { //insertupdatefunzero(cameraCB1, cameraredCB1, camerawrCB1, camera); 
        }
        protected void permissionButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(permissionCB1, permissionredCB1, permissionwrCB1, permissionmgmt); }
        protected void tspButton1_Click(object sender, EventArgs e)
        { //insertupdatefunzero(tspCB1, tspredCB1, tspwrCB1, assmgmt); 
        }
        protected void mpddButton1_Click(object sender, EventArgs e)
        { insertupdatefun(mpddCB1, mpddredCB1, mpddwrCB1, mpddiary); }
        protected void mpddButton2_Click(object sender, EventArgs e)
        { insertupdatefun(mpddCB2, mpddredCB2, mpddwrCB2, mpddiary); }
        protected void mpddButton3_Click(object sender, EventArgs e)
        { insertupdatefun(mpddCB3, mpddredCB3, mpddwrCB3, mpddiary); }
        protected void mpddButton4_Click(object sender, EventArgs e)
        { insertupdatefun(mpddCB4, mpddredCB4, mpddwrCB4, mpddiary); }
        protected void mpddButton5_Click(object sender, EventArgs e)
        { insertupdatefun(mpddCB5, mpddredCB5, mpddwrCB5, mpddiary); }
        protected void pddButton1_Click(object sender, EventArgs e)
        { //insertupdatefunzero(pddCB1, pddredCB1, pddwrCB1, pddiary); 
        }
        protected void logsettingButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(logsettingCB1, logsettingredCB1, logsettingwrCB1, logmgmt); }
        protected void accsettingButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(accsettingCB1, accsettingredCB1, accsettingwrCB1, accountsetting); }
        protected void gpsystemButton1_Click(object sender, EventArgs e)
        { //insertupdatefunzero(gpsystemCB1, gpsystemredCB1, gpsystemwrCB1, guardpsystem); 
        }
        protected void logoutButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(logoutCB1, logoutredCB1, logoutwrCB1, logoutmgmt); }
        //protected void feedmgmtButton2_Click(object sender, EventArgs e)
        //{ insertupdatefun(feedCB2, feedmgmtredCB2, feedmgmtwrCB2, feedmgmt);}
        //protected void feedmgmtButton1_Click(object sender, EventArgs e)
        //{ insertupdatefun(feedCB1, feedmgmtredCB1, feedmgmtwrCB1, feedmgmt); }
        protected void facilityButton1_Click(object sender, EventArgs e)
        { insertupdatefunzero(facilityCB1, facilityredCB1, facilitywrCB1, facilitymgmt); }
        protected void eveviewButton_Click(object sender, EventArgs e)
        { insertupdatefun(eveviewCheckBox, eveviewReadOnly, eveviewWriteOnly, eventmgmt); }
        protected void eveaddButton_Click(object sender, EventArgs e)
        { insertupdatefun(eveaddCheckBox, eveaddReadOnly, eveaddWriteOnly, eventmgmt); }
        public void insertupdatefunzero(CheckBox menuname, CheckBox redchk, CheckBox writechk, Label lb)
        {
            AdminDAL ad = new AdminDAL();
            roleMasterMap rmp = new roleMasterMap();
            add_user_info adus = new add_user_info();
            rmp.rMastMp_RoleId = ad.searchtreevalue(Label1.Text);
            if (rmp.rMastMp_RoleId == 0)
            { }
            else
            {
                if (menuname.Checked == true)
                {
                    rmp.rmastMp_ParentId = ad.searchzeroparentid(lb.Text);
                    if (rmp.rmastMp_ParentId == 0)
                    { rmp.rMastMp_MenuId = ad.searchstatusmenuid(menuname.Text, rmp.rmastMp_ParentId); }
                    else
                    { rmp.rMastMp_MenuId = ad.searchmenuid(menuname.Text, rmp.rmastMp_ParentId); }
                    rmp.rMastMp_readonly = alertReadOnly_status(redchk);
                    rmp.rMastMp_writeonly = alertWriteOnly_status(writechk);
                    rmp.rMastMp_Addright = "Y";
                    int count = adus.countmenumastmap(rmp, "countmenumastmap");
                    if (count == 0)
                    { int op = adus.insertmenu(rmp, "menu_master_map"); }
                    else if (count >= 1)
                    {
                        rmp.rmastMp_ParentId = ad.searchzeroparentid(lb.Text);
                        if (rmp.rmastMp_ParentId == 0)
                        { rmp.rMastMp_MenuId = ad.searchstatusmenuid(lb.Text, rmp.rmastMp_ParentId); }
                        else
                        { rmp.rMastMp_MenuId = ad.searchmenuid(menuname.Text, rmp.rmastMp_ParentId); }
                        rmp.rMastMp_RoleId = ad.searchtreevalue(Label1.Text);
                        rmp.rMastMp_readonly = alertReadOnly_status(redchk);
                        rmp.rMastMp_writeonly = alertWriteOnly_status(writechk);
                        rmp.rMastMp_Addright = "Y";
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString;
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select ID from MenuMasterMap where RoleId=@roleid and MenuId=@menuid and ParentId=@parentid", cn);
                        cmd.Parameters.AddWithValue("@roleid", rmp.rMastMp_RoleId);
                        cmd.Parameters.AddWithValue("@menuid", rmp.rMastMp_MenuId);
                        cmd.Parameters.AddWithValue("@parentid", rmp.rmastMp_ParentId);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        { rmp.rMastMp_Id = dr.GetInt32(0); }
                        //====================Date:15/6/2012=============================//
                        dr.Close();
                        dr.Dispose();
                        
                        //===================================================//
                        //-------------update query----------------------------
                        int op = adus.editmenumastmap(rmp, "editmenumastermap");
                        //--------------end of update query------------------------------------
                        cn.Close();
                    }
                }
                else
                { }
            }
        }
        protected void sopButton1_Click(object sender, EventArgs e)
        {
            insertupdatefun(sopCheckBox1, sopredCB1, sopwrCB1, sopmgmt);
        }
        protected void sopButton2_Click(object sender, EventArgs e)
        {
            insertupdatefun(sopCheckBox2, sopredCB2, sopwrCB2, sopmgmt);
        }
        public int functioncount(int roleid, int parent)
        {
            DBConnectionHandler1 d = new DBConnectionHandler1();
            SqlConnection cn = d.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from MenuMasterMap where RoleId=@roleid and MenuId=@menuid", cn);
            cmd.Parameters.AddWithValue("@roleid", roleid);
            cmd.Parameters.AddWithValue("@menuid", parent);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count;
        }
        protected void rdDBMenu_ItemClick(object sender, RadMenuEventArgs e)
        {

            Label1.Text = e.Item.Text;
            showcheck_in_status(Label1.Text);
        }
        protected void check_in_report_CheckedChanged(object sender, EventArgs e)
        {
            //Image1.Visible = true;
            //System.Threading.Thread.Sleep(5000);
            
            checkedcheckbox(check_in_report, inReadOnly, CheckBox4);
        }
        public void checkedcheckbox(CheckBox box1, CheckBox box2, CheckBox box3)
        {
            if (box1.Checked == true)
            {
                box2.Checked = true; box3.Checked = true;
            }
            else
            {
                box2.Checked = false; box3.Checked = false;
            }
        }
        protected void Check_out_report_CheckedChanged(object sender, EventArgs e)
        {
           // System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Check_out_report, outReadOnly, CheckBox14);
        }

        protected void Incident_Report_CheckedChanged(object sender, EventArgs e)
        {
           // System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Incident_Report, incidentReadOnly, incidWriteOnly);
        }

        protected void Alert_Report_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Alert_Report, alertReadOnly, alertWriteOnly);
        }

        protected void Occurence_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Occurence, occureReadOnly, occurWriteOnly);
        }

        protected void CheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(CheckBox18, visitReadOnly, vivitWriteOnly);
        }

        protected void Contractor_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Contractor, contractReadOnly, contractWriteOnly);
        }

        protected void Event_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Event, eventReadOnly, eventWriteOnly);
        }

        protected void Lost_Found_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(Lost_Found, lostReadOnly, lostWriteOnly);
        }

        protected void pCheck_in_report_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(pCheck_in_report, p_in_ReadOnly, p_in_WriteOnly);
        }

        protected void pCheck_out_report_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(pCheck_out_report, p_out_ReadOnly, p_inc_WriteOnly);
        }

        protected void p_incident_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_incident, p_inc_ReadOnly, p_alert_WriteOnly);
        }

        protected void p_alert_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_alert, p_alert_ReadOnly, pocr_WriteOnly);
        }

        protected void p_occurence_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_occurence, p_occure_ReadOnly, p_visit_WriteOnly);
        }

        protected void p_visit_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_visit, p_visit_ReadOnly, p_cont_WriteOnly);
        }

        protected void p_contract_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_contract, p_contract_ReadOnly, p_event_WriteOnly);
        }

        protected void p_event_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_event, p_event_ReadOnly, p_lost_WriteOnly);
        }

        protected void p_lost_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(p_lost, p_lost_ReadOnly, p_out_WriteOnly);
        }

        protected void activereview1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(activereview1, activerev1, activerev3);
        }

        protected void activereview2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(activereview2, activerev2, activerev4);
        }

        protected void eveviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(eveviewCheckBox, eveviewReadOnly, eveviewWriteOnly);
        }

        protected void eveaddCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(eveaddCheckBox, eveaddReadOnly, eveaddWriteOnly);
        }

        protected void shiftCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftCheckBox2, shiftreadCheckBox2, shiftwriteCheckBox2);

        }

        protected void shiftCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftCheckBox1, shiftreadCheckBox1, shiftwriteCheckBox1);

        }

        protected void shiftCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftCheckBox3, shiftreadCheckBox3, shiftwriteCheckBox3);
        }

        protected void shiftCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftCheckBox4, shiftreadCheckBox4, shiftwriteCheckBox4);
        }

        protected void shiftdepCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftdepCheckBox1, shiftdepredCheckBox1, shiftdepwrCheckBox1);
        }

        protected void shiftdepCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftdepCheckBox2, shiftdepredCheckBox2, shiftdepwrCheckBox2);
        }

        protected void shiftdepCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(shiftdepCheckBox3, shiftdepredCheckBox3, shiftdepwrCheckBox3);
        }

        protected void asslocCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(asslocCheckBox1, asslocredchkbox1, asslocwrchkbox);
        }

        protected void locCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(locCheckBox1, locredCheckBox1, locwrCheckBox1);
        }

        protected void locCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(locCheckBox2, locredCheckBox2, locwrCheckBox2);
        }

        protected void locCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(locCheckBox3, locredCheckBox3, locwrCheckBox3);
        }

        protected void invetCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(invetCheckBox1, invetredchkbox1, invetwrchkbox1);
        }

        protected void invetCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(invetCheckBox2, invetredchkbox12, invetwrchkbox2);
        }

        protected void invetCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(invetCheckBox3, invetredchkbox13, invetwrchkbox3);
        }

        protected void chkinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkinCheckBox1, chkinredCB1, chkinwrCB1);

        }

        protected void chkinCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkinCheckBox2, chkinredCB2, chkinwrCB2);
        }

        protected void chkinCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkinCheckBox3, chkinredCB3, chkinwrCB3);
        }

        protected void chkoutCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkoutCheckBox1, chkoutredCB1, chkoutwrCB1);
        }

        protected void chkoutCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkoutCheckBox2, chkoutredCB2, chkoutwrCB2);
        }

        protected void chkoutCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(chkoutCheckBox3, chkoutredCB3, chkoutwrCB3);
        }

        protected void dtCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(dtCheckBox1, dtredCheckBox1, CheckBox1);
        }

        protected void viewCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox1, viewredCB1, viewwrCB1);
        }

        protected void viewCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox2, viewredCB2, viewwrCB2);
        }

        protected void viewCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox3, viewredCB3, viewwrCB3);
        }

        protected void viewCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox4, viewredCB4, viewwrCB4);

        }

        protected void viewCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox5, viewredCB5, viewwrCB5);
        }

        protected void viewCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox6, viewredCB6, viewwrCB6);
        }

        protected void viewCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewCheckBox7, viewredCB7, viewwrCB7);
        }

        protected void addaltCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(addaltCheckBox1, altredCB1, altwrCB1);
        }

        protected void addaltCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(addaltCheckBox2, altredCB2, altwrCB2);
        }

        protected void viewaltCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewaltCheckBox1, viewaltredCB1, viewaltwrCB1);
        }

        protected void followCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(followCheckBox1, folllowredCB1, folllowwrCB1);
        }

        protected void followCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(followCheckBox2, folllowredCB2, folllowwrCB2);
        }

        protected void dashbordCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(dashbordCheckBox1, dashredCB1, dashwrCB1);
        }

        protected void keymanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(keymanagerCB1, keymanagerredCB1, keymanagerwrCB1);
        }

        protected void keymanagerCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(keymanagerCB2, keymanagerredCB2, keymanagerwrCB2);
        }

        protected void keymanagerCB3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(keymanagerCB3, keymanagerredCB3, keymanagerwrCB3);
        }

        protected void passmanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(passmanagerCB1, passmanagerredCB1, passmanagerwrCB1);
        }

        protected void passmanagerCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(passmanagerCB2, passmanagerredCB2, passmanagerwrCB2);
        }

        protected void itemanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(itemanagerCB1, itemanageredCB1, itemanagerwrCB1);
        }

        protected void itemanagerCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(itemanagerCB2, itemanageredCB2, itemanagerwrCB2);
        }

        protected void sopmanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(sopmanagerCB1, sopmanageredCB1, sopmanagerwrCB1);
        }

        protected void sopmanagerCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(sopmanagerCB2, sopmanageredCB2, sopmanagerwrCB2);
        }

        protected void viewalertmanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(viewalertmanagerCB1, viewalertmanagerredCB1, viewalertmanagerwrCB1);
        }

        protected void addalertmanagerCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(addalertmanagerCB1, addalertmanageredCB1, addalertmanagerwrCB1);
        }

        protected void addalertmanagerCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(addalertmanagerCB2, addalertmanageredCB2, addalertmanagerwrCB2);
        }

        protected void emergencyCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(emergencyCB1, emergencyredCB1, emergencywrCB1);
        }

        protected void sopCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(sopCheckBox1, sopredCB1, sopwrCB1);
        }

        protected void sopCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(sopCheckBox1, sopredCB2, sopwrCB2);
        }

        protected void creportCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(creportCB1, creportredCB1, creportwrCB1);
        }

        protected void creportCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(creportCB2, creportredCB2, creportwrCB2);
        }

        protected void creportCB3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(creportCB3, creportredCB3, creportwrCB3);
        }

        protected void staffmgmtCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(staffmgmtCB1, staffmgmtredCB1, staffmgmtwrCB1);
        }

        protected void staffmgmtCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(staffmgmtCB2, staffmgmtredCB2, staffmgmtwrCB2);
        }

        protected void staffmgmtCB3_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(staffmgmtCB3, staffmgmtredCB3, staffmgmtwrCB3);
        }

        protected void staffmgmtCB4_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(staffmgmtCB4, staffmgmtredCB4, staffmgmtwrCB4);
        }

        protected void staffmgmtCB5_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(staffmgmtCB5, staffmgmtredCB5, staffmgmtwrCB5);
        }

        protected void permissionCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(permissionCB1, permissionredCB1, permissionwrCB1);
        }

        protected void mpddCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(mpddCB1, mpddredCB1, mpddwrCB1);
        }

        protected void mpddCB2_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(mpddCB2, mpddredCB2, mpddwrCB2);
        }

        protected void logsettingCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(logsettingCB1, logsettingredCB1, logsettingwrCB1);
        }

        protected void accsettingCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(accsettingCB1, accsettingredCB1, accsettingwrCB1);
        }

        protected void logoutCB1_CheckedChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            checkedcheckbox(logoutCB1, logoutredCB1, logoutwrCB1);
        }



    }
}
