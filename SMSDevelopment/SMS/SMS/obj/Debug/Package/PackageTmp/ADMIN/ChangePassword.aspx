<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="SMS.ADMIN.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Change Password</span></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <br />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lbluserid" Text="User ID" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtuserid" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblnewpassword" Text="New Password" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="Input" TextMode="Password" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblrepassword" Text="Confirm Password" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtrepassword" runat="server" CssClass="Input" TextMode="Password" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                        <center>
                            <asp:Button ID="btnsubmit" runat="server" Text="Save" CssClass="Button" OnClick="btnsubmit_Click" />
                            </center>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
