using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Services.DataService;
using MKB.TimePicker;
using System.Data;

namespace SMS.ADMIN
{
    public partial class AddShift : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (!IsPostBack)
            {
                if (Request["SID"] != null)
                {
                    DataTable dt = dal.getdata("select * from Shift_Master where shift_ID=" + Request["SID"]);
                    string FromTime = dt.Rows[0][1].ToString();
                    tsFromTime.Hour = int.Parse(FromTime.Split(' ')[0].Split(':')[0]);
                    tsFromTime.Minute = int.Parse(FromTime.Split(' ')[0].Split(':')[1]);
                    string AMPM = FromTime.Split(' ')[1].Replace(".", "");
                    if (AMPM.ToLower() == "am")
                    {
                        tsFromTime.AmPm = TimeSelector.AmPmSpec.AM;
                    }
                    else
                    {
                        tsFromTime.AmPm = TimeSelector.AmPmSpec.PM;
                    }
                    string ToTime = dt.Rows[0][2].ToString();
                    tsToTime.Hour = int.Parse(ToTime.Split(' ')[0].Split(':')[0]);
                    tsToTime.Minute = int.Parse(ToTime.Split(' ')[0].Split(':')[1]);
                    AMPM = ToTime.Split(' ')[1].Replace(".", "");
                    if (AMPM.ToLower() == "am")
                    {
                        tsToTime.AmPm = TimeSelector.AmPmSpec.AM;
                    }
                    else
                    {
                        tsToTime.AmPm = TimeSelector.AmPmSpec.PM;
                    }
                    ViewState["SID"] = Request["SID"];
                    btnSearchLocationAdd.Text = "Update";
                }
            }
        }

        protected void btnSearchLocationAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            string minute = "";
            if (tsFromTime.Minute == 0)
                minute = tsFromTime.Minute.ToString() + "0";
            else
                minute = tsFromTime.Minute.ToString();

            string FromTime = tsFromTime.Hour + ":" + minute + " ";
            
            //int.Parse(FromTime.Split(' ')[0].Split(':')[1]);

            if (tsFromTime.AmPm == TimeSelector.AmPmSpec.AM)
            {
                FromTime += "A.M.";
            }
            else
            {
                FromTime += "P.M.";
            }
            string tominute = "";
            if (tsToTime.Minute == 0)
                tominute = tsToTime.Minute.ToString() + "0";
            else
                tominute = tsToTime.Minute.ToString();

            string ToTime = tsToTime.Hour + ":" + tominute + " ";
            if (tsToTime.AmPm == TimeSelector.AmPmSpec.AM)
            {
                ToTime += "A.M.";
            }
            else
            {
                ToTime += "P.M.";
            }
            try
            {
                if (btnSearchLocationAdd.Text.ToLower() == "add")
                {
                    dal.executesql("insert into Shift_Master (ShiftTimeFrom,ShiftTimeTo) values ('" + FromTime + "','" + ToTime + "')");
                    Response.Redirect("ViewShifts.aspx");
                }
                else
                {
                    dal.executesql("Update Shift_Master set ShiftTimeFrom='" + FromTime + "',ShiftTimeTo='" + ToTime + "' where shift_ID=" + ViewState["SID"].ToString());
                    ViewState["SID"] = "";
                    Response.Redirect("ViewShifts.aspx");
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = "Error Occured";
                logger.Info(ex.Message);
            }
        }

        protected void btnClearLocationAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewShifts.aspx");
        }
    }
}
