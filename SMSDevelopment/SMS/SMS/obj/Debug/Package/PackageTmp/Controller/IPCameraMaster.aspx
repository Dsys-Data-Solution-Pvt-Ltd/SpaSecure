<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="IPCameraMaster.aspx.cs" Inherits="SMS.Controller.IPCameraMaster"
   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">IP Camera</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
            <br />
            <table width="50%" class="table">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblPassNumber" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="25px" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5">
                        <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnSearchPassAdd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvPassTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" OnRowDataBound="gvPass_RowDataBound"
                OnRowCommand="gvPass_RowCommand" OnPageIndexChanging="gvPass_PageIndexChanging"
                CssClass="GridMain2" 
                OnSelectedIndexChanged="gvPassTable_SelectedIndexChanged" PageSize="20">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="There may be no IP Camera in the system for this Location."
                        runat="server">
                    </asp:Label>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="IPCamera_IP" HeaderText="Camera URL"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/magnify.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.IPCamera_IP") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.IP_id") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <table width="100%" class="table">
                <tr>
                    <td>
                        <asp:Button ID="btnNewPass" Text="Add New Camera" runat="server" CssClass="Buttons"
                            OnClick="btnNewPass_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
