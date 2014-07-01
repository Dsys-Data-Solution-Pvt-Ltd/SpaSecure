<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewCamera.aspx.cs" Inherits="SMS.Controller.AddNewCamera" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Camera</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <table width="600px">
                <tr>
                    <td>
                        <asp:Label ID="lblEnterPassNumber" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" 
                            Width="150px">
                           </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEnterPass" Text="URL" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddURL" runat="server" CssClass="Input" Height="25px" 
                            Width="710px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCameraDescription" runat="server" CssClass="Input" 
                            Height="23px" Width="708px" />
                    </td>
                </tr>
                
                <tr>
                    <td height="25px">
                    
                    </td>
                </tr>
                
                <tr>
                <td align="Center" colspan="5">
                        <asp:Button ID="btnSearchPassAdd" Text="Add" runat="server" CssClass="Buttons" 
                            Width="85px" onclick="btnSearchPassAdd_Click" />
                     &nbsp;&nbsp;
                    <asp:Button ID="btnback" runat="server" CssClass="Buttons"  Text="View All" 
                            onclick="btnback_Click" />
                </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
