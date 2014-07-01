using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Services.DataService;
using System.Data;
using SMS.Services.BusinessServices;
using SMS.BusinessEntities.Main;
using SMS.BusinessEntities.Authorization;

namespace SMS.SMSAdmin
{
    public partial class ManageRolePermissions : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = dal.getdataset("select * from RoleMaster");
                tvRoleHierarchy.SetDataSourceFromDataSet(ds, "id", "ParentID");
                tvRoleHierarchy.DataBind();

                DataSet dsMenu = dal.getdataset("select * from MenuMaster");
                tvFunctions.SetDataSourceFromDataSet(dsMenu, "ID", "ParentID");
                tvFunctions.DataBind();

                //foreach (TreeNode tn in tvFunctions.Nodes)
                //{
                //    AddRightsNodes(tn);
                //}
            }
        }


        private void AddRightsNodes(TreeNode tn)
        {
            if (tn.ChildNodes.Count > 0)
            {
                foreach (TreeNode tn1 in tn.ChildNodes)
                {
                    AddRightsNodes(tn1);
                }
            }
            else
            {
                TreeNode tna = new TreeNode("Add", "Add");
                tna.ShowCheckBox = true;

                TreeNode tne = new TreeNode("Edit", "Edit");
                tna.ShowCheckBox = true;

                TreeNode tnd = new TreeNode("Delete", "Delete");
                tna.ShowCheckBox = true;

                tn.ChildNodes.Add(tna);
                tn.ChildNodes.Add(tne);
                tn.ChildNodes.Add(tnd);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                dal.executesql("delete from RoleMenuMap where RoleID=" + tvRoleHierarchy.SelectedValue);
                foreach (TreeNode tn in tvFunctions.Nodes)
                {
                    if (tn.ChildNodes.Count > 0)
                    {
                        AssignCheckedMenus(tn);
                    }
                    else
                    {
                        if (tn.Checked)
                        {
                            dal.executesql("insert into RoleMenuMap (RoleID,MenuID) values (" + tvRoleHierarchy.SelectedNode.Value + "," + tn.Value + ")");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        private void GetSelectedIDs(TreeNode tn, ref string deleteids)
        {
            foreach (TreeNode tn1 in tn.ChildNodes)
            {
                if (tn1.Checked)
                {
                    deleteids += "," + tn1.Value;
                }
                GetSelectedIDs(tn1, ref deleteids);
            }
        }

        private bool AssignCheckedMenus(TreeNode tn)
        {
            bool finalbool = false;
            bool tempbool = false;
            if (tn.ChildNodes.Count > 0)
            {
                foreach (TreeNode tn1 in tn.ChildNodes)
                {
                    tempbool = AssignCheckedMenus(tn1);
                    finalbool = finalbool || tempbool;
                }
                if (finalbool)
                {
                    dal.executesql("insert into RoleMenuMap (RoleID,MenuID) values (" + tvRoleHierarchy.SelectedNode.Value + "," + tn.Value + ")");
                }
            }
            else
            {
                if (tn.Checked)
                {
                    finalbool = true;
                    dal.executesql("insert into RoleMenuMap (RoleID,MenuID) values (" + tvRoleHierarchy.SelectedNode.Value + "," + tn.Value + ")");
                }
            }
            return finalbool;
        }


        protected void tvRoleHierarchy_SelectedNodeChanged(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tvFunctions.Nodes)
            {
                DataTable dt = dal.getdata("select ID from vwRoleMenu where RoleID=" + tvRoleHierarchy.SelectedValue + " and ID=" + tn.Value);
                if (dt.Rows.Count > 0)
                {
                    tn.Checked = true;
                }
                else
                {
                    tn.Checked = false;
                }
                SelectRoleFunction(tn, tvRoleHierarchy.SelectedValue);
            }
        }

        private void SelectRoleFunction(TreeNode tn, string val)
        {
            foreach (TreeNode tn1 in tn.ChildNodes)
            {
                DataTable dt = dal.getdata("select ID from vwRoleMenu where RoleID=" + val + " and ID=" + tn1.Value);
                if (dt.Rows.Count > 0)
                {
                    tn1.Checked = true;
                }
                else
                {
                    tn1.Checked = false;
                }
                SelectRoleFunction(tn1, val);
            }
        }







    }
}
