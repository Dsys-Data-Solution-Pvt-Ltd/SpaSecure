<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ViewTraining.aspx.cs" Inherits="SMS.ADMIN.ViewTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Training Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server">
                <table width="100%" cellspacing="10px">
                    <tr>
                        <td align="center" colspan="4" height="70px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Training Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTrainingTopic" Text="Training Topic" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtTrainingTopic" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblStartDate" Text="Start Date" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtStartDate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEndDate" Text="End Date" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtEndDate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblVenue" Text="Venue" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtVenue" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFacilities" Text="Facilitator" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtfacilities" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblTrainee" Text="Trainees" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="45" valign="top">
                            <asp:Label ID="txtTrainee" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblTraineeDetail" Text=" Details" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="85" valign="top">
                            <asp:Label ID="txtTraineeDetail" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px" colspan="3">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <div align="center">
                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" Font-Bold="True"
                    Height="35px" Width="110px" OnClick="btnprint_Click" />
            </div>
        </div>
    </div>
</asp:Content>
