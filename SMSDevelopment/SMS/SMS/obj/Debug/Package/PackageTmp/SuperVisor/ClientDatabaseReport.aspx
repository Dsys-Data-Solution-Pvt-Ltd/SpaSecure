<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ClientDatabaseReport.aspx.cs" Inherits="SMS.SuperVisor.ClientDatabaseReport"
    Title="View Client Database" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Client Database</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel runat="server" ID="printview" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750px">
                <table width="750px" class="table">
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                            <hr style="background-color: Black; color: Black; border-color: Black; Width:700px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" height="70px" valign="middle">
                            <asp:Label ID="lblIncidentReport" Text="Client Database" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="35">
                            <asp:Label ID="lblOperationsContact" Text="Operations Contact  :" CssClass="Reportcolor"
                                runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblOperationName" Text="Name" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtOperationName" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblOperationsContactTele" Text="Telephone" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtOperationsContactTele" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblOperationsContactMobile" Text="Mobile" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtOperationsContactMobile" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblOperationsContactEmail" Text="E-mail" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtOperationsContactEmail" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblOperationsContactFax" Text="Fax" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtOperationsContactFax" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="35" valign="bottom">
                            <asp:Label ID="lblManagementContact" Text="Management Contact  :" CssClass="Reportcolor"
                                runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblManageName" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtManageName" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblManageTele" Text="Telephone" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtManageTele" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblManageMobile" Text="Mobile" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtManageMobile" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblManageEmail" Text="E-mail" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtManageEmail" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblManageFax" Text="Fax" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtManageFax" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="55px" colspan="2">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="750px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                                Height="30px" OnClick="btnprint_Click" Font-Bold="True" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
