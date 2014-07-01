<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="Add New Inventory.aspx.cs" Inherits="SMS.ADMIN.Add_New_Inventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Inventory</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
            Font-Bold="True" Width="740px">
            <table width="100%" class="table">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblItemType" runat="server" CssClass="Labels" Text="Item Type"></asp:Label>
                    </td>
                    <td style="width: 187px">
                        <asp:DropDownList ID="ddItemType" runat="server" CssClass="Labels" 
                            Width="180px" onselectedindexchanged="ddItemType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 124px">
                        <asp:Label ID="lblAddNewType" runat="server" CssClass="Labels" Text="Add New Type"></asp:Label>
                        <br />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtItemType" runat="server" CssClass="Input" />
                        &nbsp;&nbsp;&nbsp;
                        <%-- </td>
                            <td>--%>
                        <asp:Button ID="btnAddNewType" runat="server" CssClass="Buttons" OnClick="btnAddNewType_Click"
                            Text="Add Type" />
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblserialNo" Text="Serial No." CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 187px">
                        <asp:TextBox ID="txtSerialNo" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblmodelno" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 187px">
                        <asp:TextBox ID="txtModelno" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblItemName" Text="Item Details" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 187px">
                        <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td height="30px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblquantity" Text="Quantity" CssClass="Labels" runat="server"></asp:Label>
                        <br />
                    </td>
                    <td style="width: 187px">
                        <asp:TextBox ID="txtqunatity" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCreatedBy" runat="server" CssClass="Labels" Text="Created By"></asp:Label>
                    </td>
                    <td style="width: 187px">
                        <asp:TextBox ID="txtCreatedBy" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <%-- <tr>
                            <td>
                                <asp:Label ID="lblCreatedTime" runat="server" CssClass="Labels" Text="Created Time"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtCreatedTime" runat="server" CssClass="Input" Width="169px"/>
                            </td>
                        </tr>--%>
                <%--<tr>
                            <td>
                                <asp:Label ID="lblEditBy" runat="server" CssClass="Labels" Text="Edited By"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditBy" runat="server" CssClass="Input" Width="169px"/>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEditTime" runat="server" CssClass="Labels" Text="Edited Time"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditTime" runat="server" CssClass="Input" Width="169px"/>
                             </td>
              
                        </tr>--%>
                <tr>
                    <td height="55">
                    </td>
                </tr>
            </table>
            <table width="740px" style="margin-left: 0.005em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" style="width: 897px">
                        <asp:Button ID="btnaddNewItem" Text="Add" runat="server" CssClass="Buttons" Width="85px"
                            OnClick="btnaddNewItem_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnClearNewItem" Text="Cancel"
                            runat="server" CssClass="Buttons" Width="85px" OnClick="btnClearNewItem_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    </div>
</asp:Content>
