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
using SMS.Services.DALUtilities;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using System.Text.RegularExpressions;
using SMS.Services.DataService;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

using System.Net.Mail;
using System.Web.Mail;
using SMS.Web;


namespace SMS.SMSCommons
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection cn;
        AdminDAL a = new AdminDAL();


    protected void Page_Load(object sender, EventArgs e)
     {
     log4net.ILog logger = log4net.LogManager.GetLogger("File");
      try
            {
                txtUserName.Focus();
                lblMsg.Visible = false;
                DBConnectionHandler1 db = new DBConnectionHandler1();
                cn = db.getconnection();
                cn.Open();
                String p;
                p = "select Description from log where ID='securityquestion'";
                SqlCommand cmd1 = new SqlCommand(p, cn);
                SqlDataReader rec1 = cmd1.ExecuteReader();
                while (rec1.Read())
                {
                    if (!IsPostBack)
                        ddlSecQues.Items.Add(rec1.GetValue(0).ToString());
                }

                rec1.Close();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                cn.Close();
            }
        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                /*Boolean val = false;
                cn = a.getconnection();
                String p1;
                p1 = "select UserID from UserInformation";
                SqlCommand cmd = new SqlCommand(p1, cn);
                SqlDataReader rec = cmd.ExecuteReader();

                if (rec.HasRows)
                {
                    while (rec.Read())
                    {

                        string keyvalue = (rec.GetValue(0).ToString());
                        if (keyvalue == txtUserName.Text)
                        {
                            rec.Close();

                            string p3;
                            p3 = "select UserPassword from UserInformation where UserID ='" + keyvalue + "' and Squrity_Question = '" + ddlSecQues.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(p3, cn);
                            SqlDataReader rec3 = cmd3.ExecuteReader();
                            
                            while (rec3.Read())
                            {

                                string keyvalu1 = (rec3.GetValue(0).ToString());
                                val = true;
                                if (val)
                                {
                                    rec3.Close();
                                    txtpassword.Visible = true;
                                    txtpassword.Text = keyvalu1;

                                    string p4;
                                    p4 = "select EmailId from UserInformation where UserID ='" + keyvalue + "' and UserSecretQues = '" + ddlSecQues.Text + "'";
                                    SqlCommand cmd4 = new SqlCommand(p4, cn);
                                    SqlDataReader rec4 = cmd4.ExecuteReader();

                                    while (rec4.Read())
                                    {
                                        string keyvalu3 = (rec4.GetValue(0).ToString());
                                        txtemail.Visible = true;
                                        txtemail.Text = keyvalu3;
                                       email();
                                    }
                                }
                                else
                                {
                                    txtpassword.Visible = false;
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "! Invalid Answer";
                                    
                                    throw new Exception();
                                }

                            }
                            rec3.Close();
                            lblMsg.Visible = true;
                            lblMsg.Text = "! Invalid Answer!";
                            throw new Exception();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "!! Invalid User Name!";
                            throw new Exception();
                        }
                    }
                }
                rec.Close();

                lblMsg.Visible = true;
                lblMsg.Text = "! No User";
                throw new Exception();*/
                DBConnectionHandler1 db = new DBConnectionHandler1();
                cn = db.getconnection();
                cn.Open();
                String p1;
                //p1 = "select UserPassword from UserInformation where UsreID=" + txtUserName.Text + " and Squrity_Question=" + ddlSecQues.SelectedValue.Trim();
                //p1 = "select * from UserInformation where UserID=" + txtUserName.Text;
                SqlCommand cmd = new SqlCommand("select UserPassword from UserInformation where UserID=@UserID", cn);
                cmd.Parameters.AddWithValue("@UserID", txtUserName.Text);
                //cmd.Parameters.AddWithValue("Squrity_Question", ddlSecQues.SelectedValue.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    dr.Dispose();
                    SqlCommand cmd1 = new SqlCommand("select UserPassword from UserInformation where UserID=@UserID and Squrity_Question=@Squrity_Question", cn);
                    cmd1.Parameters.AddWithValue("@UserID", txtUserName.Text);
                    cmd1.Parameters.AddWithValue("@Squrity_Question", ddlSecQues.SelectedValue.Trim());
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        if (dr1.GetString(0).ToString() != " ")
                        {
                            txtpassword.Visible = true;
                            txtpassword.Text = dr1.GetString(0);
                            dr1.Close();
                            cn.Dispose();
                            cn.Close();
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        txtpassword.Visible = false;
                        lblMsg.Text = "!! Invalid Answer!";
                        dr1.Close();
                        cn.Dispose();
                        cn.Close();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    txtpassword.Visible = false;
                    lblMsg.Text = "!! Invalid User ID!";
                    dr.Close();
                    cn.Dispose();
                    cn.Close();
                }

            }

            catch (Exception ex)
            {
                cn.Dispose();
                cn.Close();
                txtpassword.Visible = false;
                logger.Info(ex.Message);
            }
        }
        void email()
        {
               string s=txtpassword.Text;
               MailHelper.SendEmail(txtemail.Text, "deepak.dubey@gmail.com", "", "ramendrapratapsingh9@gmail.com", "Regarding Stall Booking", true);
               lblMsg.Text = "Thank You for Contacting us.We will get back to you soon.";

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
         log4net.ILog logger = log4net.LogManager.GetLogger("File");
         try
            {
                Response.Redirect("../master/login3.aspx");
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
 }
