using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Telerik.Web.UI;
using System.Web.Configuration;
using System.Configuration;
namespace SMS
{
    public partial class treeaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadMenu rd = (RadMenu)rdDBMenu;
            //TreeView tr = (TreeView)TreeView1;
            //SqlDataAdapter adapter = new SqlDataAdapter("select * from UserRoleMaster1", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
            //DataSet links = new DataSet();
            //adapter.Fill(links);
            //tr.DataSource = new HierarchicalDataSet(links,"userrole", "ParentId");
            ////TreeView1.DataSource = links;
            //tr.DataBind();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from UserRoleMaster", ConfigurationManager.ConnectionStrings["tspsecur_SMSConnectionString"].ConnectionString);
            DataSet links = new DataSet();
            adapter.Fill(links);
            rd.DataTextField = "UserRole";
            //rd.DataNavigateUrlField = "NavigateUrl";
            rd.DataFieldID = "ID";
            rd.DataFieldParentID = "ParentId";
            rd.DefaultGroupSettings.ExpandDirection.Equals("Down");//tried to change the direction OF FLOW OF MENU
            rd.DataSource = links;
            rd.DataBind();

            foreach (RadMenuItem rmi in rd.Items)
            {
                rmi.Attributes.Add("style", "cursor:pointer");
                foreach (RadMenuItem ci in rmi.Items)
                {
                    ci.Attributes.Add("style", "cursor:pointer");
                }
            }
           

        }
        protected void rdDBMenu_ItemClick(object sender, RadMenuEventArgs e)
        {
            Label1.Text = e.Item.Text;
            //Label2.Text = e.Item.Value;
            //Label3.Text = e.Item.ToString();
        }
        
    }
}