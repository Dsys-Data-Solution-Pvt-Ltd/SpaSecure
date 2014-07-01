<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="IncidentFollowUp.aspx.cs" Inherits="SMS.SuperVisor.IncidentFollowUp"
    Title="Incident Follow-Up" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Incident Follow-Up</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary"></asp:Label>
            <asp:TextBox ID="Incident_id" runat="server" Visible="false"></asp:TextBox>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="740px" Height="70em">
                <table width="100%" class="table">
                    <tr>
                        <td style="width: 12em">
                            <asp:Label ID="lblReport" Text="Ref. Report No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReportNumber" runat="server" CssClass="Input" ReadOnly="True" />
                            <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterDateOfIncident" Text="Date of Incident" CssClass="Labels"
                                runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="calDateOfIncident" Text="" CssClass="Input" />
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate" />
                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterTimeOfIncident" Text="Time of Incident" CssClass="Labels"
                                runat="server"></asp:Label>
                        </td>
                        <td>
                            <MKB:TimeSelector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                SelectedTimeFormat="Twelve" AllowSecondEditing="true" />
                        </td>
                    </tr>
                    <%--<tr>
                                                     <td>
                                                            <asp:Label ID="lblAssignment" runat="server" CssClass="Labels" 
                                                            Text="Assignment/Sites"></asp:Label>
                                                    </td>
                                                   <td>
                                                           <asp:TextBox ID="txtAssignment" runat="server" CssClass="Input" />                      
                                                    </td>
                                                           
                                             </tr>--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblPlaceOfIncident" runat="server" CssClass="Labels" Text="Place of Incident"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnterPlaceOfIncident" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblReportStatement" Text="Statement" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="3" valign="top">
                            <asp:TextBox ID="txtEnterReportstatement" runat="server" CssClass="Input" Height="250px"
                                TextMode="multiline" Width="550px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblFollowStatement" Text="Follow-Up Statement" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="3" valign="top">
                            <asp:TextBox ID="txtFollowStatement" runat="server" CssClass="Input" Height="250px"
                                TextMode="multiline" Width="550px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInvestigatedBy" runat="server" CssClass="Labels" Text="Investigation By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInvestigationby" runat="server" CssClass="Input" />
                            <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFollowVerifiedby" Text="Verified By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFollowVerified" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td height="50px">
                            <asp:Label ID="lblStatus" runat="server" Text="lbl" CssClass="Labels" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="740px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="Button1" runat="server" CssClass="Buttons" Text="Save" OnClick="btnIncidentFollowUp_Click"
                                Width="100px" />
                        </td>
                        <td></td>
                        <td>
                            <asp:Button ID="Button2" runat="server" CssClass="Buttons" Text="Cancel" Width="100px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
