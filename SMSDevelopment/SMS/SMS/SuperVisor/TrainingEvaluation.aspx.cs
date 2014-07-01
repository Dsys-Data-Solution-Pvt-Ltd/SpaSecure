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
using SMS.Services.DataService;

namespace SMS.SuperVisor
{
    public partial class TrainingEvaluation : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    DataSet dsdepartment =dal.getdataset("select * from tblCourseEvaluation where intID=" + Convert.ToInt32(Request.QueryString["id"].ToString()));
                    if (dsdepartment.Tables[0].Rows.Count > 0)
                    {
                        txtNameofTrainee.Text = dsdepartment.Tables[0].Rows[0]["strNameOfTrainee"].ToString();
                        txtdat.Text = dsdepartment.Tables[0].Rows[0]["dtmDateOfEvaluation"].ToString();
                        txtNRICno.Text = dsdepartment.Tables[0].Rows[0]["strNric"].ToString();
                        lblHand.Text = dsdepartment.Tables[0].Rows[0]["strHandouts"].ToString();
                        lblDOA.Text = dsdepartment.Tables[0].Rows[0]["strDuration"].ToString();
                        lblESS.Text = dsdepartment.Tables[0].Rows[0]["strSupportServices"].ToString();
                        lblEQ.Text = dsdepartment.Tables[0].Rows[0]["strQuestion"].ToString();
                        lblEC.Text = dsdepartment.Tables[0].Rows[0]["strCapabilities"].ToString();
                        lblRR.Text = dsdepartment.Tables[0].Rows[0]["strReliability"].ToString();
                        txtcomment.Text = dsdepartment.Tables[0].Rows[0]["strComments"].ToString();
                        txtCourceTitle.Text = dsdepartment.Tables[0].Rows[0]["CourseTitle"].ToString();

                    }
                }
            }
        }

        protected void btnNewPass_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Session["ctrl"] = printview;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('printpage.aspx','PrintMe','height=730px,width=830px,scrollbars=1');</script>");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



    }
}
