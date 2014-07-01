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
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using SMS.SMSAppUtilities;
using SMS.BusinessEntities;
using System.Drawing;
using SMS.master;


namespace SMS.SMSUsers
{
    public partial class DigitalDairy : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
             try
             {
                 if (!IsPostBack)
                 {
                     fillheading();
                                       
                 }

                 string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
                 string ctrlname1 = Page.Request.Params.Get("__eventargument");
                 if (ctrlname != null)
                 {
                     string controlname = ctrlname;//.Split('$')[ctrlname.Split('$').Length - 1].ToString();
                     if (!controlname.Contains("imdAdd") && !controlname.Contains("imgUpdate") && !controlname.Contains("imgDelete") && !controlname.Contains("imgCopy") && !controlname.Contains("CheckBox1"))
                     {
                         if (controlname.ToUpper().Contains("gvDiary".ToUpper()))
                         {
                             if (ctrlname1 != null)
                             {
                                 if (ctrlname1.Contains("RowClick"))
                                 { }
                                 else if (ctrlname1.ToUpper().Contains("FIRECOMMAND") || ctrlname1 == "")
                                 {
                                     BindDiary();
                                 }
                                 else
                                 {

                                 }

                             }
                         }
                     }
                 }
                 else
                 {
                     BindDiary();
                 }
             
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnIncidentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (txtDescription.Text.Trim() != "")
                {
                    if (gvDiary.Items.Count == 0)
                    {
                        if (txtStaffName.Text.Trim() != "")
                        {
                            Saveitem();
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please fill the name');", true);
                            MyMasterPage.ShowErrorMessage("Please fill the name..!"); 
                        }
                    }
                    else
                    {
                        Saveitem();
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please enter description');", true);
                    MyMasterPage.ShowErrorMessage("Please enter description..!"); 
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public System.Drawing.Color GetColor(string Clr)
        {
            Color cl = System.Drawing.ColorTranslator.FromHtml(Clr);
            return cl;
        }

        public string GetDescription(string Description)
        {
            return Description.Replace("\r\n", "<br />");
        }

      

        private void BindDiary()
        {
            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@LocationID", int.Parse(Session["LCID"].ToString()));
            para1[1] = new SqlParameter("@Date", DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null));
            DataTable dt = dal.executeprocedure("usp_GetDailyDiary", para1, false);
            gvDiary.DataSource = dt;
            gvDiary.DataBind();
        }

        private void fillheading()
        {
            drpHeading.Items.Clear();
            drpHeading.Items.Add(" ");
            string ID = "DigitalHeading";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);

            
            if (dt1.Rows.Count > 0)
            {
                for(int h=0;h<dt1.Rows.Count;h++)
                {
                   drpHeading.Items.Add(dt1.Rows[h][0].ToString());
                }
            }
        }

       

        protected void btnaddnewHeading_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                int i = 0;
                String f = txtnewHeading.Text;
                string ID = "DigitalHeading";
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@ID", ID);
                DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para, true);
                int count = dt.Rows.Count;
                for (i = 0; i < count; i++)
                {
                    String g = dt.Rows[i].ItemArray[0].ToString();
                    if (string.Equals(f, g, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
                i++;
                count++;
                if (i == count)
                {
                    if (txtnewHeading.Text.Trim() != "")
                    {
                        dal.executesql("insert into log(ID,code,Description) values('DigitalHeading'," + count + ",'" + txtnewHeading.Text + "')");
                        txtnewHeading.Text = "";
                        fillheading();
                    }
                }

                else
                {

                    MyMasterPage.ShowErrorMessage("This Heading Already Exists..!");   
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('This Heading Already Exists..!');", true);
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        # region Icon menu

        #region Add
        protected void ImgAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                this.ModalPopupAdd.Show();
            }
            catch (Exception ex)
            {
                logger.Info("AdminCappAsset(AssertImgUpdate_Click):" + ex.Message);
            }
        }
        private void Saveitem()
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (Session["LCID"] != null)
                {
                    SqlParameter[] para = new SqlParameter[9];
                    para[0] = new SqlParameter("@LocationID", int.Parse(Session["LCID"].ToString()));
                    para[1] = new SqlParameter("@StaffID", txtStaffName.Text);
                    para[2] = new SqlParameter("@OpenedBy", "");
                    para[3] = new SqlParameter("@Color", (txtColor.Text == "" ? "#000000" : "#" + txtColor.Text));
                    para[4] = new SqlParameter("@Time", tsFromTime.Hour + ":" + tsFromTime.Minute + ":" + tsFromTime.Second);
                    para[5] = new SqlParameter("@Description", txtDescription.Text);
                    para[6] = new SqlParameter("@Heading", drpHeading.Text);
                    // para[7] = new SqlParameter("@Date", DateTime.ParseExact(DateTime.Now.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null));
                    para[7] = new SqlParameter("@Date", DateTime.Now.ToShortDateString());
                    para[8] = new SqlParameter("@ClosedBy", "");
                    int re= dal.executeprocedure("usp_AddDigitalDiaryEntry", para);
                    if (re > 0)
                    {

                        //dal.executesql("Update PreRegisteredVisits set FromDate='" + txtFromDate.Text.Trim() + "',ToDate='" + txtToDate.Text.Trim() + "',ExpectedTime='" + newtime + "',Name='" + txtName.Text.Trim() + "',Company='" + txtCompany.Text.Trim() + "',Position='" + txtPosition.Text.Trim() + "',Invited_By='" + txtInvitedBy.Text.Trim() + "',LocationID='" + Searchid.Text + "',VechicleNo='" + txtVechicle.Text + "',Purpose='" + txtpurpose.Text + "',Telephoe='"+txttelephone.Text+"' where PRVID ='" + hdnCSID.Value + "' ");
                      //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Record Insert SuccessFully');", true);


                        MyMasterPage.ShowErrorMessage("Record Inserted SuccessFully..!");   
          
                        
                        BindDiary();   
                        ClearAdd();
                        this.ModalPopupAdd.Hide();
                    }
                    else
                    {
                       // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Failed To Insert Record');", true);
                        MyMasterPage.ShowErrorMessage("Failed To Insert Record..!");   
          
                    }
                    BindDiary();
                    txtColor.Text = "";
                    txtDescription.Text = "";
                    txtStaffName.Text = "";
                }
                else
                {
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AlertMessage", " alert('Please Select the Location..!');", true);
                    MyMasterPage.ShowErrorMessage("Please Select the Location..!");   
          
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAdd();

        }

        public void ClearAdd()
        {
            txtColor.Text = "";
            txtdatefrom.Text = "";
            txtDescription.Text = "";
            txtnewHeading.Text = "";
            txtStaffName.Text = "";
            fillheading();
            this.ModalPopupAdd.Hide();
        }

     
        #endregion



        #endregion
    }
}
