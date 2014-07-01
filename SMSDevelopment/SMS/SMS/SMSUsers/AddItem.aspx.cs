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

namespace SMS.SMSUsers
{
    public partial class AddItem : System.Web.UI.Page
    {
        SqlConnection cn;
        AdminDAL a = new AdminDAL();
        int i = 0;
        DataAccessLayer dal = new DataAccessLayer();


        protected void Page_Load(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                    txtItemdescription.Focus();
                    fillno();
                    lblerror.Visible = false;
                    lblerr2.Visible = false;
                    lblerr1.Visible = false;
                    lblerr3.Visible = false;
                    lblerr4.Visible = false;                  


                    pnlsingout.Visible = false;
                    pnllost.Visible = false;
                    lblLossfound.Visible = true;
                    chklost.Visible = true;
                    lblItemsignout.Visible = true;
                    chksingout.Visible = true;



                    lblItemLogged.Visible = true;
                    lblPosition.Visible = true;
                    lblcname.Visible = true;
                    lblItemname.Visible = true;
                    txtlogednric.Visible = true;
                    txtlogedname.Visible = true;
                    txtlogedcompname.Visible = true;


                    if (chksingout.Checked == true)
                    {
                        pnlsingout.Visible = true;
                        lblLossfound.Visible = false;
                        chklost.Visible = false;
                        txtlogednric.Visible = true;
                        txtlogedname.Visible = true;
                        txtlogedcompname.Visible = true;
                    }
                    if (chklost.Checked == true)
                    {
                        pnllost.Visible = true;
                        lblItemsignout.Visible = false;
                        chksingout.Visible = false;
                        lblItemLogged.Visible = false;
                        lblPosition.Visible = false;
                        lblcname.Visible = false;
                        lblItemname.Visible = false;
                        txtlogednric.Visible = false;
                        txtlogedname.Visible = false;
                        txtlogedcompname.Visible = false;

                    }

                   
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
    }



        private void fillno()
        {
            if (IsPostBack == false)
            {
                string pre = string.Empty;
                string sep = "IT";
                int rcode = 0;
                int length = 0;
                string final = string.Empty;
                DataSet ds = new DataSet();
                ds = dal.getdataset("Select id from AutogenCode where descript='Item' ");

                pre = ds.Tables[0].Rows[0][0].ToString();
                length = Convert.ToInt32(pre.Length);

                rcode = Convert.ToInt32(pre.Substring(2, length - 2));
                rcode++;

                final = sep + Convert.ToString(rcode);

                txtItemNo.Text = final;
            }

        }



        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
             {
                 Boolean bal = true;
                 String ZipRegex = "^[0-9]+$";
                // if (Regex.IsMatch(txtItemNo.Text, ZipRegex))
               //  {

                   if (chksingout.Checked == true)
                    {
                        //if (Regex.IsMatch( txtsignednric.Text, ZipRegex))
                        //  {
                             Signout();
                         // }
                         //else
                         //  {
                         //    lblerror.Visible = true;
                         //    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                         //    lblerr3.Visible = true;
                         //    bal = false;
                         // }

                     }

                   if (bal)
                   {

                       if (chklost.Checked == true)
                       {
                           founditem();
                       }

                       else
                       {

                           if (Regex.IsMatch(txtlogednric.Text, ZipRegex))
                           {
                               login();
                           }
                           else
                           {
                               lblerror.Visible = true;
                               lblerror.Text = "Invalid NRIC/FIN No. ..!";
                               lblerr1.Visible = true;
                           }
                       }
                   }
              // }
              //else
              //     {
              //       lblerror.Visible = true;
              //       lblerror.Text = "Invalid Item No. ..!";
              //       lblerr2.Visible = true;
              //     }
             }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }  
        }

          

        String subitem()
        {
            String ZipRegex = "^[0-9]+$";
            cn = a.getconnection();
            if (txtsignednric.Text != "")
            {
                //if (Regex.IsMatch(txtsignednric.Text, ZipRegex))
                //{
                    String q2 = txtsignednric.Text;
                    //String x2 = "select NRICno from UserInformation";
                    //SqlCommand cmd5 = new SqlCommand(x2, cn);
                    //SqlDataAdapter adp5 = new SqlDataAdapter(cmd5);
                    DataSet ds5 = dal.getdataset("Select NRICno from UserInformation");
                    // adp5.Fill(ds5);
                    int count2 = ds5.Tables[0].Rows.Count;
                    for (i = 0; i < count2; i++)
                    {
                        String z2 = ds5.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (string.Equals(q2, z2, StringComparison.CurrentCultureIgnoreCase))
                        {
                           return z2;
                        }
                    }
                    lblerror.Visible = true;
                    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    lblerr3.Visible = true;
                    throw new Exception();
                //}
                //else
                //  {
                //    lblerror.Visible = true;
                //    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                //    lblerr3.Visible = true;
                //    throw new Exception();
                // }
            }
        return "";
     }

        void founditem()
        { 
                String ZipRegex = "^[0-9]+$";
                GetItemData objadditemdata = new GetItemData();
                ItemData Objitemdata = new ItemData();
                //DateTime datetime;
                cn = a.getconnection();

              //if (Regex.IsMatch(txtfoundnric.Text, ZipRegex))
              //    {
                    String q3 = txtfoundnric.Text;
                    //String x3 = "select NRICno from UserInformation";
                    //SqlCommand cmd6 = new SqlCommand(x3, cn);
                    //SqlDataAdapter adp6 = new SqlDataAdapter(cmd6);
                    DataSet ds6 = dal.getdataset("Select NRICno from UserInformation");
                    //adp6.Fill(ds6);
                    int count3 = ds6.Tables[0].Rows.Count;
                    for (i = 0; i < count3; i++)
                    {
                        String z3 = ds6.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (string.Equals(q3, z3, StringComparison.CurrentCultureIgnoreCase))
                        {

                            String v = txtItemNo.Text;
                            //String b = "select Item_no from Item_Manager";
                            //SqlCommand cmd13 = new SqlCommand(b, cn);
                            //SqlDataAdapter adp13 = new SqlDataAdapter(cmd13);

                            DataSet ds13 = dal.getdataset("select Item_no from Item_Manager");
                           // DataSet ds13 = new DataSet();
                           // adp13.Fill(ds13);
                            int count13 = ds13.Tables[0].Rows.Count;
                            for (i = 0; i < count13; i++)
                            {
                                String h = ds13.Tables[0].Rows[i].ItemArray[0].ToString();
                                if (string.Equals(v, h, StringComparison.CurrentCultureIgnoreCase))
                                {

                                    //Objitemdata.Model_No = txtItemNo.Text;
                                    //Objitemdata.Item_Description = txtItemdescription.Text;
                                    //Objitemdata.Item_quantity = txtItemquantity.Text;

                                    //Objitemdata.loged_Nric = txtlogednric.Text;
                                    //Objitemdata.loged_Name = txtlogedname.Text;
                                    //Objitemdata.loged_CompName = txtlogedcompname.Text;
                                    //Objitemdata.loged_Time = Convert.ToDateTime(lbllogedtime.Text);

                                    //Objitemdata.Signed_Nric = txtsignednric.Text;
                                    //Objitemdata.Signed_Name = txtsignedname.Text;
                                    //Objitemdata.Signed_CompName = txtsignedcompname.Text;
                                    //Objitemdata.Signed_Time = DateTime.Now;
                                    //Objitemdata.Remarks = txtremark.Text; 

                                    //Objitemdata.Found_Nric = txtfoundnric.Text;
                                    //Objitemdata.Status = cmbstatus.Text;
                                    //Objitemdata.Foundremark = txtfoundremark.Text;

                                    //AdminBLL ws = new AdminBLL();
                                    //ws.UpdateItemData(Objitemdata);
                                  
                                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                                    Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
                                }
                            }


                                    lblerror.Visible = true;
                                    lblerror.Text = "Invalid Item No. ..!";
                                    lblerr2.Visible = true;
                                    throw new Exception();
                                
                            
                        }
                    }
                    lblerror.Visible = true;
                    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                    lblerr4.Visible = true;
                    throw new Exception();
                //  }
                //else
                //  {
                //    lblerror.Visible = true;
                //    lblerror.Text = "Invalid NRIC/FIN No. ..!";
                //    lblerr4.Visible = true;
                //    throw new Exception();
                //  }
                       
        }


        private void UpdateAutogenCode()
        {
            DataSet dsupage = dal.getdataset("Update AutogenCode set id ='" + txtItemNo.Text.Trim() + "' where Descript='Item' ");
        }

        void login()
        {
            String ZipRegex = "^[0-9]+$";
            
                GetItemData objadditemdata = new GetItemData();
                ItemData Objitemdata = new ItemData();
               // DateTime datetime;
                cn = a.getconnection();

                String q = txtItemNo.Text;
                //String x = "select Item_no from Item_Manager";
                //SqlCommand cmd3 = new SqlCommand(x, cn);
               // SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                DataSet ds = dal.getdataset("select Item_no from Item_Manager");
               // adp.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                for (i = 0; i < count; i++)
                {
                    String z = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    if (string.Equals(q, z, StringComparison.CurrentCultureIgnoreCase))
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Item No. Already Exist ..!";
                        lblerr2.Visible = true;
                        throw new Exception();
                    }
                }

                String q1 =txtlogednric.Text;
               // String x1 = "select NRICno from UserInformation";
               // SqlCommand cmd4 = new SqlCommand(x1, cn);
               // SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);
                DataSet ds4 = dal.getdataset("select NRICno from UserInformation");
                //adp4.Fill(ds4);
                int count1 = ds4.Tables[0].Rows.Count;
                for (i = 0; i < count1; i++)
                {
                    String z1 = ds4.Tables[0].Rows[i].ItemArray[0].ToString();
                    if (string.Equals(q1, z1, StringComparison.CurrentCultureIgnoreCase))
                    {
                       
                        //Objitemdata.Item_no = txtItemNo.Text;
                        //Objitemdata.Item_Description = txtItemdescription.Text;
                        //Objitemdata.Item_quantity = txtItemquantity.Text;

                        //Objitemdata.loged_Nric = txtlogednric.Text;
                        //Objitemdata.loged_Name = txtlogedname.Text;
                        //Objitemdata.loged_CompName = txtlogedcompname.Text;
                        //Objitemdata.loged_Time =DateTime.Now;

                        //Objitemdata.Found_Nric = txtfoundnric.Text;
                        //Objitemdata.Status = cmbstatus.Text;
                        //Objitemdata.Found_Time = DateTime.Now; 


                        AdminBLL ws = new AdminBLL();
                        ws.AddItem(Objitemdata);
                        UpdateAutogenCode();

                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");

                    }
                }

                lblerror.Visible = true;
                lblerror.Text = "Invalid NRIC/FIN No. ..!";
                lblerr1.Visible = true;
                

        }

        void Signout()
        {
            

            GetItemData objadditemdata = new GetItemData();
            ItemData Objitemdata = new ItemData();
            DateTime datetime;
            cn = a.getconnection();

            String q = txtItemNo.Text;
           // String x = "select Item_no from Item_Manager";
            //SqlCommand cmd3 = new SqlCommand(x, cn);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd3);
            DataSet ds = dal.getdataset("select Item_no from Item_Manager");
            //adp.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            for (i = 0; i < count; i++)
            {
                String z = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                if (string.Equals(q, z, StringComparison.CurrentCultureIgnoreCase))
                {

                        String q1 = txtsignednric.Text;
                        //String x1 = "select NRICno from UserInformation";
                        //SqlCommand cmd4 = new SqlCommand(x1, cn);
                        //SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);
                        DataSet ds4 = dal.getdataset("select NRICno from UserInformation");
                       // adp4.Fill(ds4);
                        int count1 = ds4.Tables[0].Rows.Count;
                        for (i = 0; i < count1; i++)
                        {
                            String z1 = ds4.Tables[0].Rows[i].ItemArray[0].ToString();
                            if (string.Equals(q1, z1, StringComparison.CurrentCultureIgnoreCase))
                            {
                                //Objitemdata.Item_no = txtItemNo.Text;
                                //Objitemdata.Item_Description =txtItemdescription.Text;
                                //Objitemdata.Item_quantity =txtItemquantity.Text;

                                //Objitemdata.Signed_Nric = subitem();
                                //Objitemdata.Signed_Name =txtsignedname.Text;                               
                                //Objitemdata.Signed_CompName =txtsignedcompname.Text;
                                //Objitemdata.Signed_Time = DateTime.Now;
                                //Objitemdata.Remarks =txtremark.Text; 

                                //Objitemdata.loged_Nric =txtlogednric.Text;                               
                                //Objitemdata.loged_Name =txtlogedname.Text;                                
                                //Objitemdata.loged_CompName =txtlogedcompname.Text;
                                //Objitemdata.loged_Time =Convert.ToDateTime(lbllogedtime.Text);

                                //Objitemdata.Found_Nric = txtfoundnric.Text;
                                //Objitemdata.Status = cmbstatus.Text;
                                //Objitemdata.Foundremark = txtfoundremark.Text;
                               

                                AdminBLL ws = new AdminBLL();
                                ws.UpdateItemData(Objitemdata);

                                HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                                Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");

                            }
                        }

                        lblerror.Visible = true;
                        lblerror.Text = "Invalid NRIC/FIN No. ..!";
                        lblerr3.Visible = true;
                        throw new Exception();
           }
         }
            lblerror.Visible = true;
            lblerror.Text = "Item No. Doesn't Exist ..!";
            lblerr2.Visible = true;
            throw new Exception();


      }


        protected void imgBtnFromDate2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtnFromDate_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnClearItemAdd_Click(object sender, EventArgs e)
        {

         log4net.ILog logger = log4net.LogManager.GetLogger("File");
         try
          {


              txtItemNo.Text = "";
              txtItemdescription.Text = "";
              txtItemquantity.Text = "";

              txtlogednric.Text = "";
              txtlogedname.Text = "";
              txtlogedcompname.Text = "";
              lbllogedtime.Text = "";

              txtsignednric.Text = "";
              txtsignedname.Text = "";
              txtsignedcompname.Text = "";
              txtremark.Text = "";
              lblsignedtime.Text = "";

              txtfoundnric.Text = "";
              cmbstatus.Text = "";

          }
         catch (Exception ex)
         {
             logger.Info(ex.Message);
         }  
            
        }

        protected void chksingout_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtItemNo_TextChanged(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
          try
          {
              if (chksingout.Checked == true)
              {
                  String ZipRegex = "^[0-9]+$";
                  if (Regex.IsMatch(txtItemNo.Text, ZipRegex))
                  {
                      cn = a.getconnection();
                      SqlCommand command = new SqlCommand("select Top 1 Item_no,Item_Description,Item_quantity,loged_Nric,loged_Name,loged_CompName,loged_Time,Found_Nric,Status from Item_Manager where Item_no='" + txtItemNo.Text + "' ", cn);
                      SqlDataReader rd = command.ExecuteReader();

                      if (rd.HasRows)
                      {
                          if (rd.Read())
                          {
                              txtItemNo.Text = rd.GetValue(0).ToString();
                              txtItemdescription.Text = rd.GetValue(1).ToString();
                              txtItemquantity.Text = rd.GetValue(2).ToString();

                              txtlogednric.Text = rd.GetValue(3).ToString();
                              txtlogedname.Text = rd.GetValue(4).ToString();
                              txtlogedcompname.Text = rd.GetValue(5).ToString();
                              lbllogedtime.Text = rd.GetValue(6).ToString();

                              txtfoundnric.Text = rd.GetValue(7).ToString();
                              cmbstatus.Text = rd.GetValue(8).ToString();

                          }
                          rd.Close();
                          //===============================//
                          rd.Dispose();
                          //==================================//
                        
                      }
                      else
                      {
                          lblerror.Visible = true;
                          lblerror.Text = "Invalid Item No. ..!";
                          lblerr2.Visible = true;
                      }
                  }
                  else
                  {
                      lblerror.Visible = true;
                      lblerror.Text = "Invalid Item No. ..!";
                      lblerr2.Visible = true;
                  }
              }

              if (chklost.Checked == true)
              {

                  String ZipRegex = "^[0-9]+$";
                  if (Regex.IsMatch(txtItemNo.Text, ZipRegex))
                  {
                      cn = a.getconnection();
                      SqlCommand command = new SqlCommand("select Top 1 Item_no,Item_Description,Item_quantity,loged_Time from Item_Manager where Item_no='" + txtItemNo.Text + "' ", cn);
                      SqlDataReader rd = command.ExecuteReader();

                      if (rd.HasRows)
                      {
                          if (rd.Read())
                          {
                              txtItemNo.Text = rd.GetValue(0).ToString();
                              txtItemdescription.Text = rd.GetValue(1).ToString();
                              txtItemquantity.Text = rd.GetValue(2).ToString();                              
                              lbllogedtime.Text = rd.GetValue(3).ToString();
                             

                          }
                          rd.Close();
                          //======================//
                          rd.Dispose();
                          //========================//
                        
                      }
                      else
                      {
                          lblerror.Visible = true;
                          lblerror.Text = "Invalid Item No. ..!";
                          lblerr2.Visible = true;
                      }
                  }
                  else
                  {
                      lblerror.Visible = true;
                      lblerror.Text = "Invalid Item No. ..!";
                      lblerr2.Visible = true;
                  }
              }

          }
          catch (Exception ex)
            {
              logger.Info(ex.Message);
            }

        }

        protected void chklost_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtlogednric_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
