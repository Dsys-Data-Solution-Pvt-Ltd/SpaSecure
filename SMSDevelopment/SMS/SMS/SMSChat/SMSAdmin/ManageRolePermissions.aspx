<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ManageRolePermissions.aspx.cs" Inherits="SMS.SMSAdmin.ManageRolePermissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script type="text/javascript">
        var TREEVIEW_ID = "<%= tvFunctions.ClientID %>"; //the ID of the TreeView control
        //the constants used by GetNodeIndex()
        var LINK = 0;
        var CHECKBOX = 1;

        //this function is executed whenever user clicks on the node text
        function ToggleCheckBox(senderId) {
            var nodeIndex = GetNodeIndex(senderId, LINK);
            var checkBoxId = TREEVIEW_ID + "n" + nodeIndex + "CheckBox";
            var checkBox = document.getElementById(checkBoxId);
            checkBox.checked = !checkBox.checked;

            ToggleChildCheckBoxes(checkBox);
            ToggleParentCheckBox(checkBox);
        }

        //checkbox click event handler
        function checkBox_Click(eventElement) {
            ToggleChildCheckBoxes(eventElement.target);
            ToggleParentCheckBox(eventElement.target);
        }

        //returns the index of the clicked link or the checkbox
        function GetNodeIndex(elementId, elementType) {
            var nodeIndex;
            if (elementType == LINK) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "t").length);
            }
            else if (elementType == CHECKBOX) {
                nodeIndex = elementId.substring((TREEVIEW_ID + "n").length, elementId.indexOf("CheckBox"));
            }
            return nodeIndex;
        }

        //checks or unchecks the nested checkboxes
        function ToggleChildCheckBoxes(checkBox) {
            var postfix = "n";
            var childContainerId = TREEVIEW_ID + postfix + GetNodeIndex(checkBox.id, CHECKBOX) + "Nodes";
            var childContainer = document.getElementById(childContainerId);
            if (childContainer) {
                var childCheckBoxes = childContainer.getElementsByTagName("input");
                for (var i = 0; i < childCheckBoxes.length; i++) {
                    childCheckBoxes[i].checked = checkBox.checked;
                }
            }
        }


        //unchecks the parent checkboxes if the current one is unchecked
        function ToggleParentCheckBox(checkBox) {
            if (checkBox.checked == false) {
                var parentContainer = GetParentNodeById(checkBox, TREEVIEW_ID);
                if (parentContainer) {
                    var parentCheckBoxId = parentContainer.id.substring(0, parentContainer.id.search("Nodes")) + "CheckBox";
                    if ($get(parentCheckBoxId) && $get(parentCheckBoxId).type == "checkbox") {
                        $get(parentCheckBoxId).checked = false;
                        ToggleParentCheckBox($get(parentCheckBoxId));
                    }
                }
            }
        }

        //returns the ID of the parent container if the current checkbox is unchecked
        function GetParentNodeById(element, id) {
            var parent = element.parentNode;
            if (parent == null) {
                return false;
            }
            if (parent.id.search(id) == -1) {
                return GetParentNodeById(parent, id);
            }
            else {
                return parent;
            }
        }
    </script>

    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Manage Role Permissions</span>
        </div>
        <br />
        <table width="100%">
            <tr>
                <td width="40%" valign="top">
                    <asp:TreeView ID="tvRoleHierarchy" runat="server" ImageSet="Simple" 
                        ShowLines="true" onselectednodechanged="tvRoleHierarchy_SelectedNodeChanged">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <DataBindings>
                            <asp:TreeNodeBinding DataMember="System.Data.DataRowView" TextField="RoleName" ToolTipField="RoleName"
                                ValueField="id" />
                        </DataBindings>
                    </asp:TreeView>
                </td>
                <td valign="top">
                    <asp:TreeView ID="tvFunctions" runat="server" ImageSet="Simple" ShowCheckBoxes="All"
                        ShowLines="true">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="False" ForeColor="Black" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <DataBindings>
                            <asp:TreeNodeBinding DataMember="System.Data.DataRowView" TextField="DisplayText" ToolTipField="DisplayText"
                                ValueField="ID" />
                        </DataBindings>
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td width="40%" valign="top">
                    &nbsp;
                </td>
                <td valign="top">
                    <asp:Button ID="Button1" runat="server" Text="Assign Rights" 
                        OnClick="Button1_Click" CssClass="Buttons" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        var links = document.getElementsByTagName("a");
        for (var i = 0; i < links.length; i++) {
            if (links[i].className == TREEVIEW_ID + "_0") {
                links[i].href = "javascript:ToggleCheckBox(\"" + links[i].id + "\");";
            }
        }

        var checkBoxes = document.getElementsByTagName("input");
        for (var i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i].type == "checkbox") {
                $addHandler(checkBoxes[i], "click", checkBox_Click);
            }
        }
    </script>

</asp:Content>
