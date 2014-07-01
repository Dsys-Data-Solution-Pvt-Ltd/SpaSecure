<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AddNewEmergencyContact.aspx.cs" Inherits="SMS.SuperVisor.AddNewEmergencyContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">New Emergency Contact</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750">
                <table width="700" class="table">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignmentid" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="175px">
                            </asp:DropDownList>
                            <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmobileno" Text="Mobile No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmobileno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblofficeno" Text="Office No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtofficeno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblhomeno" Text="Home No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthomeno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" style="width: 162px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblgrade" Text="Extension" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGrade" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="60px">
                        </td>
                    </tr>
                    <table width="100%" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                        border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                        <tr>
                            <td colspan="4" align="center" style="width: 897px">
                                <asp:Button ID="btnSearchPassAdd" Text="Add" runat="server" CssClass="Buttons" Width="85px"
                                    OnClick="btnSearchPassAdd_Click" />
                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearPassAdd" Text="Cancel" runat="server"
                                    CssClass="Buttons" Width="85px" OnClick="btnClearPassAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </table>
            </asp:Panel>
        </div>
        <br />
    </div>
    <br />
</asp:Content>
