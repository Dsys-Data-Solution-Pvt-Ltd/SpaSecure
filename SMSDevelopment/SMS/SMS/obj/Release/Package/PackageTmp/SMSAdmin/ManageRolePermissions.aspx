<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageRolePermissions.aspx.cs" Inherits="SMS.SMSAdmin.ManageRolePermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    
    table {
background: white;
margin-bottom: -40px;
border: solid 1px #dddddd;
}


    .TreeView a:hover {

	text-decoration: none;
	color: red;
	text-shadow: none;
	-webkit-transition: 500ms linear 0s;
	-moz-transition: 500ms linear 0s;
	-o-transition: 500ms linear 0s;
	transition: 500ms linear 0s;
	outline: 0 none;


    }


   .TreeView input[type="checkbox"] {
    height: 1.2em;
    width: 1.2em;
    vertical-align: middle;
    margin: 0 0.4em 0.4em 0;
    border: 1px solid rgba(0, 0, 0, 0.3);
    background: -webkit-linear-gradient(#FCFCFC, #DADADA);
    -webkit-appearance: none;
    -webkit-transition: box-shadow 200ms;
     box-shadow:inset 1px 1px 0 #fff, 0 1px 1px rgba(0,0,0,0.1);
}
 
/* border radius for radio*/
.TreeView input[type="radio"] {
    -webkit-border-radius:100%;
    border-radius:100%;
}
 
/* border radius for checkbox */
.TreeView input[type="checkbox"] {
    -webkit-border-radius:2px;
    border-radius:2px;
}
 
/* hover state */
.TreeView input[type="radio"]:not(:disabled):hover,
.TreeView input[type="checkbox"]:not(:disabled):hover {
    border-color:rgba(0,0,0,0.5);
    box-shadow:inset 1px 1px 0 #fff, 0 0 4px rgba(0,0,0,0.3);
}
 
/* active state */
.TreeView input[type="radio"]:active:not(:disabled),
.TreeView input[type="checkbox"]:active:not(:disabled) {
    background-image: -webkit-linear-gradient(#C2C2C2, #EFEFEF);
    box-shadow:inset 1px 1px 0 rgba(0,0,0,0.2), inset -1px -1px 0 rgba(255,255,255,0.6);
    border-color:rgba(0,0,0,0.5);
}
 
/* focus state */
.TreeView input[type="radio"]:focus,
.TreeView input[type="checkbox"]:focus {
    outline:none;
    box-shadow: 0 0 1px 2px rgba(0, 240, 255, 0.4);
}
 
/* input checked border color */
.TreeView input[type="radio"]:checked,
.TreeView input[type="checkbox"]:checked {
    border-color:rgba(0, 0, 0, 0.5)
}
 
/* radio checked */
.TreeView input[type="radio"]:checked:before {
display: block;
height: 0.3em;
width: 0.3em;
position: relative;
left: 0.4em;
top: 0.4em;
background: rgba(0, 0, 0, 0.7);
border-radius: 100%;
content: '';
}
 
/* checkbox checked */
.TreeView input[type="checkbox"]:checked:before {
font-weight: bold;
color: rgba(0, 0, 0, 0.7);
content: '\2713';
-webkit-margin-start: 0;
margin-left: 2px;
font-size: 0.9em;
}
 
/* disabled input */
.TreeView input:disabled {
opacity: .6;
box-shadow: none;
background: rgba(0, 0, 0, 0.1);
box-shadow:none;
}
 
/* style label for disabled input */
.TreeView input:disabled + label {
opacity: .6;
cursor:default;
-webkit-user-select: none;
}


</style>



    <style type="text/css">
    .treeNode {
        color:red;
        font: 14px Arial, Sans-Serif;
        width:30px;
    }

    .rootNode {
        font-size: 18px;
        color:blue;
        width:30px;
    }

    .leafNode {
        padding: 4px;
        color:orange;
        width:30px;
    }

    .selectNode {
        font-weight: bold;
        color:purple;
    }
</style>



    



    
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
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
      
        <asp:Panel runat="server" ID="Pnl" BackColor="White" 
            Font-Bold="True">
            <table width="100%">
                <tr>
                    <td  valign="top" >
                        <asp:TreeView ID="tvRoleHierarchy" runat="server" ImageSet="Simple" CssClass="TreeView" ShowLines="false" EnableTheming="true" 
                            RootNodeStyle-ImageUrl="~/icon/super.png" LeafNodeStyle-ImageUrl="~/icon/admin.png " ParentNodeStyle-ImageUrl="~/icon/user.png"
                            
                            OnSelectedNodeChanged="tvRoleHierarchy_SelectedNodeChanged">
                            <ParentNodeStyle Font-Bold="False"/>
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="Red" HorizontalPadding="0px"
                                VerticalPadding="0px" CssClass="selectNode"  />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                                NodeSpacing="0px" VerticalPadding="0px"  />
                            <DataBindings>
                                <asp:TreeNodeBinding DataMember="System.Data.DataRowView" TextField="UserRole" ToolTipField="UserRole"
                                    ValueField="id" />
                            </DataBindings>
                        </asp:TreeView>
                    </td>
                    <td  valign="top">
                        <asp:TreeView ID="tvFunctions" runat="server" ImageSet="Simple" ShowCheckBoxes="All" CssClass="TreeView" ExpandDepth="0"
                            ShowLines="false" RootNodeStyle-ImageUrl="~/icon/power.png" LeafNodeStyle-ImageUrl="~/icon/power.png " ParentNodeStyle-ImageUrl="~/icon/power.png" >
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="False" ForeColor="Black" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="Red" HorizontalPadding="0px"
                                VerticalPadding="0px" CssClass="selectNode" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                                NodeSpacing="0px" VerticalPadding="0px"  />
                            <DataBindings>
                                <asp:TreeNodeBinding DataMember="System.Data.DataRowView" TextField="DisplayText"
                                    ToolTipField="DisplayText" ValueField="ID" />
                            </DataBindings>
                        </asp:TreeView>
                    </td>
                </tr>
                <tr>
                    
                <td colspan="2">
                 <div style=" background-color: #E4E4E4;">
                    <center>
                        <asp:Button ID="Button2" runat="server" CssClass="Button" OnClick="Button1_Click"
                            Text="Assign Rights" />
                      
                           
                    </center>
                </div>
                </td>
                </tr>
            </table>
            
        </asp:Panel>
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
