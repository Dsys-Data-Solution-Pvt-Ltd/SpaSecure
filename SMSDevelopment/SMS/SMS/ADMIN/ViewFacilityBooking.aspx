<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ViewFacilityBooking.aspx.cs" Inherits="SMS.ADMIN.ViewFacilityBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 526px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Facility Booking Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server">
                <table width="100%" cellspacing="10px">
                    <tr>
                        <td align="center" colspan="4" height="70px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Facility Booking Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lbltypeoffacility" Text="Type of Facility" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txttypeoffacility" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lbllocation" Text="Location" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtlocation" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblname" Text="Name" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtname" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblposition" Text="Position" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtposition" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblunitno" Text="Unit No." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtunitno" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style1">
                            <asp:Label ID="lblfromdate" Text="Booking Date From" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtfromdate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style1">
                            <asp:Label ID="lbltodate" Text="Booking Date To" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txttodate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="style1">
                            <asp:Label ID="Label1" Text="Booking Time From" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtfromtime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="style1">
                            <asp:Label ID="Label3" Text="Booking Time To" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txttotime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label2" Text="Comments" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="85" valign="top">
                            <asp:Label ID="txtcomments" CssClass="Reportcolor" runat="server"></asp:Label>
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
                    Height="35px" Width="110px" onclick="btnprint_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
