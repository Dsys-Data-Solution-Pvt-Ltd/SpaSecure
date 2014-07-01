<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="IncidentReport.aspx.cs" Inherits="SMS.SuperVisor.IncidentReport"
    Title="Incident Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add New Incident</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="740px">
                <table width="730px" class="table" style="background-color: White">
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignment" runat="server" CssClass="Labels" Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
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
                        <td>
                            <asp:Label ID="lblReport" Text="Report No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReportNumber" runat="server" CssClass="Input" />
                            <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
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
                            <asp:Label ID="lblReportStatement" Text="Statement" CssClass="Labels" runat="server"
                                Visible="false"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtEnterReportstatement" runat="server" CssClass="Input" Height="380px"
                                TextMode="multiline" Width="664px" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReportedBy" runat="server" CssClass="Labels" Text="Reported By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReportedBy" runat="server" CssClass="Input" />
                            <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" Text="Verified By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReceivedBy" runat="server" CssClass="Labels" Text="Received By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceivedBy" runat="server" CssClass="Input" />
                        </td>
                        <td>
                            <asp:Label ID="lblReceivedVerifiedBy" Text="Verified By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceivedVerifiedBy" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td height="50px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="btnpanel" runat="server" Style="width:750px; margin-left: 1.5em;
                background: url(../Images/1397d40aa687.jpg); height:35px">
                <asp:Label ID="lblstatusopen" Text="Open" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                <asp:Button ID="btnSearchIncidentAdd" runat="server" CssClass="Buttons" Style="margin-left: 18em;
                    height: 32px" Text="Add" Width="85px" OnClick="btnSearchIncidentAdd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClearIncidentAdd" runat="server" CssClass="Buttons" Text="Cancel"
                    Width="85px" Height="32px"/>
                <%-- <asp:Button ID="btnEmail" runat="server" cssclass="Buttons" text="E-Mail" 
                                                         width="85px"/>
                                                         <asp:Button ID="btnPrint" runat="server" cssclass="Buttons" text="Print" 
                                                         width="85px" onclick="btnPrint_Click"/>
                --%>
            </asp:Panel>
        </div>
        <br />
    </div>
</asp:Content>
