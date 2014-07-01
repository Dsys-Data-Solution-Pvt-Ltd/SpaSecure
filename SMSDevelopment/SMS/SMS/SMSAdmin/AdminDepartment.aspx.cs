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

namespace SMS.SMSAdmin
{
    public partial class AdminDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClearDepartmentAdd_Click(object sender, EventArgs e)
        {
            txtDepartmentCode.Text = "";
            txtDepartmentNameSearch.Text = "";
        }
        //protected void btnNewPass_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Response.Redirect("NewDepartmentAdd.aspx");
        //    }
        //    catch (System.Threading.ThreadAbortException)
        //    {
        //    }
        //}
    }
}
