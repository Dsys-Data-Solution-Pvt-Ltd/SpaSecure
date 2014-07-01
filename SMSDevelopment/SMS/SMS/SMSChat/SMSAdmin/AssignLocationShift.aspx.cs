﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.Services.DataService;

namespace SMS.SuperVisor
{
    public partial class AssignLocationShift : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAllocateShift_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in gvAvailableShifts.Rows)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkShift")).Checked)
                {
                    string shiftid = ((CheckBox)gr.Cells[0].FindControl("chkShift")).ToolTip;
                    dal.executesql("insert into LocationShiftMap(LocationID,ShiftID) values ("+ ddlSite.SelectedValue+","+shiftid+")");
                }
            }
            gvAvailableShifts.DataBind();
            grdAssignedShift.DataBind();
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvAvailableShifts.DataBind();
            grdAssignedShift.DataBind();
        }

        protected void lnkUnAssign_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdAssignedShift.Rows)
            {
                if (((CheckBox)gr.Cells[0].FindControl("chkShift")).Checked)
                {
                    string lsid = ((CheckBox)gr.Cells[0].FindControl("chkShift")).ToolTip;
                    dal.executesql("delete from LocationShiftMap where LSID="+lsid);
                }
            }
            gvAvailableShifts.DataBind();
            grdAssignedShift.DataBind();
        }
    }
}