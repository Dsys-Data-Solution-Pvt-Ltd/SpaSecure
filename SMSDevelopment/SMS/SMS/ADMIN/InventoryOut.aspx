<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryOut.aspx.cs" Inherits="SMS.ADMIN.InventoryOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSMain.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSCalander.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSGrid.css" type="text/css" />
</head>
<body>
    <form id="form11" runat="server">
    <table width="100%" border="1">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblbarid" runat="server" Text="Item Type" CssClass="Labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlItemType" runat="server" CssClass="Input" Width="126px"
                    OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblitemqty" runat="server" Text="Item of Details" CssClass="Labels"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlItemName" runat="server" CssClass="Input" Width="126px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Quantity" CssClass="Labels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtquantity" runat="server" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25px">
                <asp:Button ID="btnSearchPassAdd" Text="Add To Cart" runat="server" CssClass="Buttons"
                    Width="95px" OnClick="btnSearchPassAdd_Click" />
            </td>
        </tr>
    </table>
    <div runat="server" id="divGridView">
        <asp:GridView ID="GridView1" runat="server" Width="600px" CellPadding="4" OnRowCommand="GridView1_RowCommand"
            AutoGenerateColumns="False" CssClass="GridMain">
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
            <RowStyle CssClass="NormalRow" />
            <AlternatingRowStyle CssClass="AlternateRow" />
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
            <Columns>
                <asp:BoundField DataField="Item_Type" HeaderText="Item Type">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Name" HeaderText="Item Name">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Qty" HeaderText="Quantity" ReadOnly="True">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Item_ID") %>'
                            CommandName="DeleteRow" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="cmdIssueItem" Text="Proceed" runat="server" CssClass="Buttons" Width="118px"
            OnClick="cmdIssueItem_Click" Visible="false" />
    </div>
    </form>
</body>
</html>
