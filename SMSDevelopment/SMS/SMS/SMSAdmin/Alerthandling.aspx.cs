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

namespace SMS.SMSAdmin
{
    public partial class Alerthandling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {  
            
            MultiView1.ActiveViewIndex = 0;
            txtTo1.Focus();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            { 
            MultiView1.ActiveViewIndex = 1;
            txtEmpID2.Focus();
          }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            txtCc1.Text = "";
            txtmsg1.Text = "";
            txtTo1.Text = "";
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            txtEmpID2.Text = "";
            txtmsg2.Text = "";
        }
    }
}
