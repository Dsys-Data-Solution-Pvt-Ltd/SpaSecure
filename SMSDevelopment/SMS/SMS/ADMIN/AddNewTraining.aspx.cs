using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.IO;
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities;
using SMS.Services.DALUtilities;
using SMS.Services.BusinessServices;
using SMS.Services;
using System.Collections;

namespace SMS.ADMIN
{
    public partial class AddNewTraining : System.Web.UI.Page
    {
        DataAccessLayer Dal = new DataAccessLayer();
        AdminDAL adal = new AdminDAL();
        AdminBLL bll = new AdminBLL();
        DropDownList[] ddl;
        ArrayList A1 = new ArrayList();

        protected void page_init(object sender, EventArgs e)
        {
            ddltrainees.Items.Insert(0, new ListItem("-select-", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                txttraingType.Focus();
                lblerror.Visible = false;
                lblerr.Visible = false;
                txtTrainees.Visible = false;
                for (int i = 1; i <= 100; i++)
                {
                    string x = Convert.ToString(i);
                    ddltrainees.Items.Add(x);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAddTraining_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AddNewTrainingRequest objAddNewTrainingRequest = new AddNewTrainingRequest();
                AddTraining objaddTraining = new AddTraining();

                if (txttraingType.Text.Trim() != "")
                {
                    if (txtdatefrom.Text.Trim() != "" && txtdateto.Text.Trim() != "")
                    {

                        objaddTraining.training_type = txttraingType.Text.Trim();
                        objaddTraining.Venue = txtVenue.Text.Trim();
                        objaddTraining.T_startdate = Convert.ToDateTime(txtdatefrom.Text.Trim());
                        objaddTraining.T_enddate = Convert.ToDateTime(txtdateto.Text.Trim());
                        objaddTraining.Trainee = txtTrainees.Text.Trim();
                        objaddTraining.Facilitation = txtfacilitation.Text.Trim();
                        objaddTraining.TraineeDetail = txtTraineeDetail.Text.Trim();

                        AdminBLL ws = new AdminBLL();
                        ws.AddTraining(objaddTraining);

                        HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                        Server.Transfer("CompleteForm.aspx");
                    }
                    lblerror.Visible = true;
                    lblerror.Text = "Start and End Date is required....!";
                }
                else
                {
                    lblerr.Visible = true;
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill Training Topic....!";

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClearTraining_Click(object sender, EventArgs e)
        {
            txttraingType.Text = "";
            txtVenue.Text = "";
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtTrainees.Text = "";
            txtfacilitation.Text = "";
            txtTraineeDetail.Text = "";

        }

        protected void ddltrainees_SelectedIndexChanged(object sender, EventArgs e)
        {
            A1.Clear();
            txtTrainees.Text = "";
            DataSet ds = Dal.getdataset("select FirstName from UserInformation");
            GridViewTrainee.DataSource = ds.Tables[0];
            GridViewTrainee.DataBind();
        }

        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            A1.Add(ddl.SelectedValue.ToString() + " , ");

            foreach (object o in A1)
            {
                txtTrainees.Text += (string)o;
            }
        }

        protected void GridViewTrainee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ddl = new DropDownList[Convert.ToInt32(ddltrainees.SelectedValue)];

                for (int i = 0; i <= Convert.ToInt32(ddltrainees.SelectedValue) - 1; i++)
                {
                    //ddl[i].Attributes.Add = "-select-";
                    DataSet ds = Dal.getdataset("select FirstName from UserInformation");
                    ddl[i] = new DropDownList();                    
                    ddl[i].AutoPostBack = true;
                    ddl[i].SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                    ddl[i].DataTextField = "FirstName";
                    ddl[i].DataSource = ds;
                    ddl[i].DataBind();
                    ddl[i].Items.Insert(0, new ListItem("- Select -", "0"));
                    e.Row.Cells[0].Controls.Add(ddl[i]);
                }
            }
        }

        protected void GridViewTrainee_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewTrainee.Rows.Count; i++)
            {
                GridViewTrainee.Rows[i].Visible = false;
            }
        }
    }
}
