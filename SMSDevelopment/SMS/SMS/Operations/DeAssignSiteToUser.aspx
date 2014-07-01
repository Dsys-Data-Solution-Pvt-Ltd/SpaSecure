<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="DeAssignSiteToUser.aspx.cs" Inherits="SMS.Operations.DeAssignSiteToUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function jqCheckAll(item, clas) {
            $("." + clas + " [type='checkbox']").attr('checked', item.checked);
        }
    </script>
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Assign Locations To Users</span>
        </div>
       
            <table width="700PX" class="table">
               
                <tr>
                    <td>
                        <asp:Label ID="lblShiftID3" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="Input" Width="200px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Users"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="2">
                     
                        <asp:GridView ID="grdUser" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="700px" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                            PageSize="100" OnRowDataBound="grdUser_RowDataBound">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" CssClass="unassigned" runat="server" AutoPostBack="true" 
              OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUser" CssClass="unassigned" runat="server" ToolTip='<%# Eval("StaffID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="User" DataField="FirstName" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr><td colspan="2">
                <center>
                 <asp:Button ID="btnAssignSites" Text="DeAssign Locations" runat="server" CssClass="Buttons"
                            OnClick="btnAssignSites_Click" /></center>
                </td></tr>
               
            </table>
         
       
    </div>
</asp:Content>
