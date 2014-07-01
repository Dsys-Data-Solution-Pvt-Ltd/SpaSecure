<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="UpdateInterview.aspx.cs" Inherits="SMS.ADMIN.UpdateInterview" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Interview Management</span></div>
        <div id="divErr" runat="server">
            <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <asp:Panel ID="printview" runat="server">
            <table width="100%">
                <tr>
                    <td align="left" class="style1">
                        <asp:Label ID="lblincidentno" CssClass="Labels" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInterviewStatus" runat="server" CssClass="Input" Width="126px">
                            <asp:ListItem Selected="True">Prescreen</asp:ListItem>
                            <asp:ListItem>Invite for Interview</asp:ListItem>
                            <asp:ListItem>Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label2" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCandidateName" runat="server" CssClass="Input" Width="420px" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lblEnterDateOfIncident" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="calDateOfIncident" Text="" CssClass="Input" />
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate" />
                        <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lblReportedBy" runat="server" CssClass="Labels" Text="Phone Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCandidatePhone" runat="server" CssClass="Input" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <div runat="server" id="divinterview" title="Invite For Interview">
                <span class="pageTitle">Invite For Interview</span>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtInterviewDate" Text="" CssClass="Input" />
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy hh:mm:ss" TargetControlID="txtInterviewDate" PopupButtonID="ImageButton1" />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterTimeOfIncident" Text="Interview Time" CssClass="Labels" runat="server"
                                Visible="false"></asp:Label>
                        </td>
                        <td>
                            <MKB:TimeSelector ID="interviewtime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                SelectedTimeFormat="Twelve" AllowSecondEditing="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="Interviewer Person" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtinterviewerPerson" Text="" CssClass="Input" Width="430px" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label4" Text="Comment" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtComment" Text="" CssClass="Input" Width="439px"
                                Rows="10" Height="73px" TextMode="MultiLine" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <br />
        <table width="100%">
            <tr>
                <td colspan="5" align="center">
                    <asp:Button ID="btnSearchIncidentAdd" runat="server" CssClass="Buttons" Text="Save"
                        OnClick="btnSearchIncidentAdd_Click" Width="82px" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
