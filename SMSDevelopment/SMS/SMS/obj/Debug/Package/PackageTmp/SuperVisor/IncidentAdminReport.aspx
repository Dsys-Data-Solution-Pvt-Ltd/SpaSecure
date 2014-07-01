<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="IncidentAdminReport.aspx.cs" Inherits="SMS.SuperVisor.IncidentAdminReport"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Incident Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="740px" Height="70em">
                <table width="100%" cellspacing="10px" class="table">
                    <tr>
                        <td align="center" colspan="4" height="70px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Incident Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldate" Text="Incident Date :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8em;">
                            <asp:Label ID="lblReportno" Text="Report No. :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 5em;">
                            <asp:Label ID="txtReportno" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTime" Text="Incident Time :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txttime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsite" Text="Incident Site :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtsite" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblplace" Text="Place of Incident" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblplaceofincident" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblstatement" Text="Report/ Statement :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="300px" valign="top">
                            <asp:Label ID="txtstatement" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblFollowStatement" Text="Follow-Up Statement :" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="150px" valign="top">
                            <asp:Label ID="txtFollowUpStatement" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblreportedby" Text="Reported By :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtreportedby" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVerifiedby" Text="Verified By :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtVerifiedby" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReceivedBy" Text="Received By :" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtReceivedBy" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReceivedVerifiedBy" Text="Verified By :" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtReceivedVerifiedBy" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="55px" colspan="3">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="740px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print " Width="110px"
                                Height="30px" OnClick="btnprint_Click" Font-Bold="True" Font-Size="Medium" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
