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
    public partial class NewTrainingEvaluation : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnNewPass_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (txtName.Text != "" && txtNRIC.Text != "")
                {
                    string name = txtName.Text;
                    string nric = txtNRIC.Text;
                    DateTime dt = Convert.ToDateTime(txtDate.Text.ToString());
                    string strHandouts = ddlHandout.SelectedItem.Text.ToString();
                    string strDOA = ddlDOA.SelectedItem.Text.ToString();
                    string strESS = ddlESS.SelectedItem.Text.ToString();
                    string strEQ = ddlEQ.SelectedItem.Text.ToString();
                    string strEC = ddlEC.SelectedItem.Text.ToString();
                    string strRR = ddlRR.SelectedItem.Text.ToString();
                    string comment = txtcomment.Text.ToString();
                    string insertQuery = "insert into tblCourseEvaluation(strNameOfTrainee,strNric,dtmDateOfEvaluation,strHandouts,strDuration,strSupportServices,strQuestion,strCapabilities,strReliability,strComments,CourseTitle,strVenue ) values('" + name + "','" + nric + "','" + dt.Date.ToShortDateString() + "','" + strHandouts + "','" + strDOA + "','" + strESS + "','" + strEQ + "','" + strEC + "','" + strRR + "','" + comment + "','" + txtCourseTitle.Text.Trim() + "','"+txtvenue.Text+"')";
                    dal.executesql(insertQuery);
                    Response.Redirect("TrainingEvaluation_Master.aspx");
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Please Fill Name & NRIC No.....";
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


    }
}

