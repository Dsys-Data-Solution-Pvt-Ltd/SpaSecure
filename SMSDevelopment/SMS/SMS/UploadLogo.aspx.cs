using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SMS.Services.DALUtilities;
using log4net;
using log4net.Config;
using SMS.master;
using System.IO;
namespace SMS
{
    public partial class UploadLogo : System.Web.UI.Page
    {
        string thubpath, thubpathMaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgUpload.Visible = false;
            lblErr.Visible = false;
            BtnSave.Visible = false;
        }

        #region Code for Uploading Image

        protected void BtnUpload_Click1(object sender, EventArgs e)
        {
            SpaMaster MyMasterPage = (SpaMaster)Page.Master;
            if (FileUpload1.PostedFile.FileName != "")
            {
                ImgUpload.Visible = true;
                string file = FileUpload1.PostedFile.FileName;
                string filename = Path.GetFileName(FileUpload1.FileName);
                thubpath = ("/Images" + "/" + filename);//Chnages According to Requirement Logic
                //thubpathMaster=("master/Images"+"/"+filename);//According to Requirement
                FileUpload1.PostedFile.SaveAs(Server.MapPath("Images/") + filename);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("master/Images/") + filename);//According to Requirement
                ImgUpload.ImageUrl = thubpath;
                TextBox1.Text = thubpath;
                TextBox2.Text = Server.MapPath(thubpath).Trim();
                BtnSave.Visible = true;
            }
            else
            {
                ImgUpload.Visible = false;
                MyMasterPage.ShowErrorMessage("Please choose a file.");
                //lblErr.Visible = true;
                //lblErr.Text = "Please choose a file!!!";
            }
        }

        #endregion
        #region Code for Saving Image In DB

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                SpaMaster MyMasterPage = (SpaMaster)Page.Master;
                if (TextBox1.Text.Trim() != "")
                {
                    int count = 0;
                    DBConnectionHandler1 db = new DBConnectionHandler1();
                    SqlConnection cn = db.getconnection();
                    cn.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from UploadLogo", cn);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(0).ToString() != "")
                        {
                            count += 1;
                            dr.Close();
                            cmd1.Dispose();
                        }
                    }
                    else
                    {
                        dr.Close();
                        cmd1.Dispose();
                    }
                    if (count > 0)
                    {
                        SqlCommand cmd = new SqlCommand("update  UploadLogo set ImagePath=@ImagePath,fullpathname=@fullpathname", cn);
                        cmd.Parameters.AddWithValue("@ImagePath", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@fullpathname", TextBox2.Text);
                        cmd.ExecuteNonQuery();
                        // lblErr.Visible = true;
                        // lblErr.Text = "Add Successfully!";
                        MyMasterPage.ShowErrorMessage("Add Successfully!");
                        TextBox1.Text = "";
                        count = 0;
                        cn.Close();

                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into UploadLogo values(@ImagePath,@fullpathname)", cn);
                        cmd.Parameters.AddWithValue("@ImagePath", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@fullpathname", TextBox2.Text);
                        cmd.ExecuteNonQuery();
                        // lblErr.Visible = true;
                        // lblErr.Text = "Add Successfully!";
                        MyMasterPage.ShowErrorMessage("Add Successfully!");
                        TextBox1.Text = "";
                        //count = 0;
                        cn.Close();
                    }
                    cn.Close();

                }
                else
                {
                    MyMasterPage.ShowErrorMessage("Please choose a file.");
                    //lblErr.Visible = true;
                    //lblErr.Text = "Please choose a file!!!";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        #endregion
    }

}
