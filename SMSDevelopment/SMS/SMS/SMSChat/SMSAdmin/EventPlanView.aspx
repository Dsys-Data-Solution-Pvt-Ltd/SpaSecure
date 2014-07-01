<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="EventPlanView.aspx.cs" Inherits="SMS.SMSAdmin.EventPlanView"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 247px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Event Planner Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:panel runat="server" ID="printview" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
                <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
                    <tr>
                        <td align="center" colspan="4" height="70px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Event Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtLocation" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbleventtype" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Type"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txteventtype" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblgaurdreq" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Number of Guards Required "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtgaurdreq" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEventID" Text="Event ID" CssClass="Reportcolor" runat="server"
                                Font-Bold="True" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventID" CssClass="Reportcolor" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblspecialreq" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Special Requirement"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtspecialreq" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbldutyforgaurd" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Any Special Duty for Guard"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdutygaurd" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventDate" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Date :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventdate" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblEventDateTo" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="To Date :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventDateTo" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventstartTime" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Event Start Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventstartTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEventEndTime" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="End Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEventEndTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="55">
                            <asp:Label ID="Label1" CssClass="Reportcolor" Font-Bold="True" runat="server" Text="Person In Charge: Contact Details"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblpersonNRIC" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="NRIC No."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtpersonNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEnterName" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtEnterName" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterContactno" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Contact No."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtContactNo" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPosition" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Position"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtPosition" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCreatedBy" CssClass="Reportcolor" Font-Bold="True" runat="server"
                                Text="Created By:"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="txtCreatedBy" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="55px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </div>
            <div class="table">
                 <table  width="102%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                   <tr>
                       <td colspan="4" align="center" style="width: 897px">
                <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                    Height="30px" OnClick="btnprint_Click" Font-Bold="True" />
                </td></tr></table>
            </div>
            <br />
    </div>
</asp:Content>
