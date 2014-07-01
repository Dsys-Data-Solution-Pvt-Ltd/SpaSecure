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
using GaurdPatroSystem.Services.DataService;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;
using SMS.Services.DataService;
using System.Data.SqlClient;

namespace GaurdPatroSystem
{
    public partial class EditPatroSystem : System.Web.UI.Page
    {
        DataALayer dal = new DataALayer();
        string where = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HyperLink hy7 = (HyperLink)Master.FindControl("HyperLink1");
                    hy7.Visible = true;
                    HyperLink hy = (HyperLink)Master.FindControl("LoginHome");
                    hy.Visible = true;
                    HyperLink hy1 = (HyperLink)Master.FindControl("Home1");
                    hy1.Visible = false;
                    HyperLink hy2 = (HyperLink)Master.FindControl("Home2");
                    hy2.Visible = true;
                    HyperLink hy3 = (HyperLink)Master.FindControl("fileby");
                    hy3.Visible = true;
                    HyperLink hy4 = (HyperLink)Master.FindControl("recordby");
                    hy4.Visible = true;
                    LinkButton hy6 = (LinkButton)Master.FindControl("LinkButton1");
                    hy6.Visible = true;
                    if (Request.QueryString["id1"] != null)
                    {

                        
                        if (Request.QueryString["id"] != null)
                        {
                            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                            ddlocation1.Items.Add(Request.QueryString["id1"].ToString());
                            PopulateFuntion(id);
                            btnupdate.Visible = true;
                            btnAdd.Visible = false;
                            getLocationIDByName(ddlocation1.SelectedValue.ToString());
                            BindGridWithFilter(where);
                            lbllocation.Visible = false;
                        }
                        else
                        {
                            ddlocation1.Items.Add(Request.QueryString["id1"].ToString());
                            btnupdate.Visible = false;
                            btnAdd.Visible = true;
                            BindGridWithFilter(where);
                            lbllocation.Visible = false;
                            getLocationIDByName(ddlocation1.SelectedValue.ToString());
                        }
                    }
                    
                    if (Request.QueryString["qer"] != null)
                    {
                        btnupdate.Visible = false;
                        btnAdd.Visible = true;
                        BindGridWithFilter(where);
                        getLocationName();
                        lbllocation.Visible =true;
                        ddlocation2.Visible = true;
                        
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                        PopulateFuntion(id);
                        btnupdate.Visible = true;
                        btnAdd.Visible = false;
                        lbllocation.Visible = false;
                        ddlocation2.Visible = false;
                        BindGridWithFilter(where);
                    }
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void getLocationName()
        {
            ddlocation2.Items.Clear();
            ddlocation2.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            // para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddlocation2.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                SearchLocID.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private void PopulateFuntion(int argid)
        {
            DataSet dsedit = dal.getdataset("Select * from GaurdTourSystem where GTid = " + argid);
            if (dsedit.Tables[0].Rows.Count > 0)
            {
                lblid.Text = argid.ToString();
                txtpersonnel.Text = dsedit.Tables[0].Rows[0]["Personnel"].ToString();
                txtpatrotime.Text = dsedit.Tables[0].Rows[0]["PatrolTime"].ToString();
                txtrout.Text = dsedit.Tables[0].Rows[0]["Rout"].ToString();
                txtremark.Text = dsedit.Tables[0].Rows[0]["Remark"].ToString();
                txtevent.Text = dsedit.Tables[0].Rows[0]["GEvent"].ToString();
                txtchkpoint.Text = dsedit.Tables[0].Rows[0]["Check_Point"].ToString();
                txtreader.Text = dsedit.Tables[0].Rows[0]["Reader"].ToString();
                txtpersonnelNo.Text = dsedit.Tables[0].Rows[0]["Personnel#"].ToString();
                txtCheckPoint.Text = dsedit.Tables[0].Rows[0]["Check_Point#"].ToString();
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string time = TimeSelector1.Date.TimeOfDay.ToString();
                string dtime = txtpatrotime.Text;
                dal.executesql("Update GaurdTourSystem set Personnel='" + txtpersonnel.Text + "',PatrolTime='" + dtime + "',Remark='" + txtremark.Text + "',Rout='" + txtrout.Text + "',GEvent='" + txtevent.Text + "',Reader='" + txtreader.Text + "',Check_Point='" + txtchkpoint.Text + "',Personnel#='" + txtpersonnelNo.Text + "',Check_Point#='" + txtCheckPoint.Text + "' where GTid ='" + lblid.Text + "' ");
                 //Response.Redirect("PatroTimeSystem.aspx");
                 if (ddlocation1.SelectedValue.ToString()!="")
                 {
                     Server.Transfer("PatroTimeSystem.aspx?BTID=" + ddlocation1.SelectedValue.ToString());
                 }
                 else
                 {
                     Server.Transfer("PatroTimeSystem.aspx");
                 }


            }
            catch (Exception ex)
            {
            }
        }
        protected void btnviewall_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id1"] != null)
                {
                    Server.Transfer("GPS_locSearch.aspx");
                }
                else
                {
                    Server.Transfer("PatroTimeSystem.aspx");
                }
                //Response.Redirect("GPS_locSearch.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            getLocationIDByName(ddlocation2.SelectedValue.ToString());
            DBConnectionHandler1 db = new DBConnectionHandler1();
            SqlConnection cn = db.getconnection();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select GTSID from GaurdTourSystem2 where LocationID=@location", cn);
            cmd.Parameters.AddWithValue("@location",SearchLocID.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { Session["location"] = dr.GetInt32(0); cmd.Dispose(); dr.Close(); cn.Close(); }
            try
            {
                string time = TimeSelector1.Date.TimeOfDay.ToString();
                string dtime = txtpatrotime.Text + " " + time;
                dal.executesql("Insert into GaurdTourSystem (Personnel,PatrolTime,Remark,Rout,GEvent,Reader,Check_Point,Personnel#,Check_Point#,GTSID) values('" + txtpersonnel.Text + "','" + dtime + "','" + txtremark.Text + "','" + txtrout.Text + "','" + txtevent.Text + "','" + txtreader.Text + "','" + txtchkpoint.Text + "','" + txtpersonnelNo.Text + "','" + txtCheckPoint.Text + "','" + Session["location"].ToString() + "')");
                //Response.Redirect("PatroTimeSystem.aspx");
                if (ddlocation1.SelectedValue.ToString() != "")
                {
                    Server.Transfer("PatroTimeSystem.aspx?BTID=" + ddlocation1.SelectedValue.ToString());
                }
                else
                {
                    Server.Transfer("PatroTimeSystem.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure to delete this record?')");
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvLoctionTable.Columns[0].FooterText = "Total Records: 20";
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "View")
                {
                    Server.Transfer("EditPatroSystem.aspx?id=" + _BTId);
                }
                if (e.CommandName == "DeleteRow")
                {
                    dal.executesql("Delete from GaurdTourSystem where GTid=" + _BTId);
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvLoctionTable.PageIndex = e.NewPageIndex;
                    BindGridWithFilter(where);
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        private void BindGridWithFilter(string where)
        {
            try
            {
               // string where = ReturnWhere();
                DataSet dsitem = new DataSet();
                if (Request.QueryString["id1"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        getLocationIDByName(ddlocation1.SelectedValue.ToString());
                        dsitem = dal.getdataset("select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + SearchLocID.Text + ") order by PatrolTime desc");
                    }
                    else
                    {
                        getLocationIDByName(ddlocation1.SelectedValue.ToString());
                        dsitem = dal.getdataset("select * from GaurdTourSystem where GTSID IN(select GTSID from GaurdTourSystem2 where LocationID=" + SearchLocID.Text + ") order by PatrolTime desc");
                    }

                }
                else
                {
                    dsitem = dal.getdataset("Select * from GaurdTourSystem" + where);
                }
                //dsitem = dal.getdataset("Select * from GaurdTourSystem" + where);
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    //gvLoctionTable.PageSize = 20;
                    gvLoctionTable.DataSource = dsitem.Tables[0];
                    gvLoctionTable.DataBind();
                }
                else
                {
                    gvLoctionTable.DataSource = null;
                    gvLoctionTable.DataBind();
                }
            }
            catch (Exception ex)
            {
                // logger.Info(ex.Message);
            }
        }

        //private string ReturnWhere()
        //{
        //    string str = string.Empty;
        //    string makeWhereClause = string.Empty;
        //    try
        //    {
        //        List<String> arr = new List<String>();
        //        arr.Add("test");

        //        if (txtpersonnel.Text.Trim() != "")
        //        {
        //            if (arr.Count == 1)
        //            {
        //                makeWhereClause = " where ";
        //                str += " where Personnel='" + txtpersonnel.Text.Trim() + "'";
        //                arr.Add("1");
        //            }
        //            else
        //            {
        //                str += " and Personnel='" + txtpersonnel.Text.Trim() + "'";
        //            }
        //        }
        //        if (txtchkpoint.Text.Trim() != "")
        //        {
        //            if (arr.Count == 1)
        //            {
        //                makeWhereClause = " where ";
        //                str += " where Check_Point='" + txtchkpoint.Text.Trim() + "'";
        //                arr.Add("4");
        //            }
        //            else
        //            {
        //                str += " and Check_Point='" + txtchkpoint.Text.Trim() + "'";
        //            }
        //        }

        //        if (txtdateto.Text != "" && txtdatefrom.Text != "")
        //        {
        //            if (arr.Count == 1)
        //            {
        //                str += " where PatrolTime BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
        //                arr.Add("2");
        //            }
        //            else
        //            {
        //                str += " and PatrolTime BETWEEN '" + txtdatefrom.Text + "' AND '" + txtdateto.Text + "'";
        //            }
        //        }
        //        if (txtdatefrom.Text != "" && txtdateto.Text == "")
        //        {
        //            if (arr.Count == 1)
        //            {
        //                str += " where PatrolTime='" + txtdatefrom.Text + "'";
        //                arr.Add("3");
        //            }
        //            else
        //            {
        //                str += " and PatrolTime='" + txtdatefrom.Text + "'";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // logger.Info(ex.Message);
        //    }
        //    return (str);
        //}

        protected void gvLoctionTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpsearchtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (drpsearchtime.Text == "Ascending")
            {
                where = " order by PatrolTime Asc";
            }
            if (drpsearchtime.Text == "Descending")
            {
                where = " order by PatrolTime desc";
            }
            BindGridWithFilter(where);
        }
        
    }
}
