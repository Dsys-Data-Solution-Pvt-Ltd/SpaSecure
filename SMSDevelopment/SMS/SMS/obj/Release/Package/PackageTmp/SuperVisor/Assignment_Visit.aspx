<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="Assignment_Visit.aspx.cs" Inherits="SMS.SuperVisor.Assignment_Visit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForCR">
        <div class="divHeader">
            <span class="pageTitle">Add Site Visit</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="740px">
                <table width="100%" class="table">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNameofAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTo" Text="To" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsubmittedby" Text="Submitted By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtsubmittedby" runat="server" CssClass="Input" Width="500px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNric" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtnric" runat="server" CssClass="Input" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date of Visit"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text="Time"></asp:Label>
                        </td>
                        <td>
                            <MKB:TimeSelector ID="TimeSelector1" runat="server" SelectedTimeFormat="TwentyFour"
                                AllowSecondEditing="True" DisplaySeconds="False" MinuteIncrement="1" />
                        </td>
                    </tr>
                    <tr>
                        <td height="40">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblheadingDetail" Text="DETAILS OF REPORT" CssClass="Labels" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MANPOWER NAMES
                        </td>
                        <td>
                            a) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtIC" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard1" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard2" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            d) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard3" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            e) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard4" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            f) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard5" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            g) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard6" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            h) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard7" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            i) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard8" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            j) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard9" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            k) Security Officer
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard10" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DISCIPLINE
                        </td>
                        <td>
                            a) Dressing
                        </td>
                        <td>
                            <asp:TextBox ID="txtdressing" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Appearance
                        </td>
                        <td>
                            <asp:TextBox ID="txtappearance" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Haircut
                        </td>
                        <td>
                            <asp:TextBox ID="txthaircut" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ALERTNESS
                        </td>
                        <td>
                            <asp:DropDownList ID="ddrAlertness" runat="server" CssClass="Input" Width="100px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Good</asp:ListItem>
                                <asp:ListItem>Fair</asp:ListItem>
                                <asp:ListItem>Poor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DEPLOYMENT
                        </td>
                        <td>
                            <asp:DropDownList ID="ddrDeployment" runat="server" CssClass="Input" Width="100px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Coorect</asp:ListItem>
                                <asp:ListItem>Incorrect</asp:ListItem>
                                <asp:ListItem>Disorder</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            GENERAL PERFORMANCE
                        </td>
                        <td>
                            <asp:DropDownList ID="ddrgeneralPerformance" runat="server" CssClass="Input" Width="100px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Good</asp:ListItem>
                                <asp:ListItem>Average</asp:ListItem>
                                <asp:ListItem>Satisfactory</asp:ListItem>
                                <asp:ListItem>Poor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            OTHER MATTERS
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtotherMatters" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CONCLUSION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtconclustion" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            RECOMMENDATION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtrecommendation" runat="server" CssClass="Input" Width="500px"
                                Height="76px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
                <table width="740px" style="margin-left: 0.005em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="btnAssignmentAdd" Text="Save" runat="server" CssClass="Buttons" Width="85px"
                                OnClick="btnAssignmentAdd_Click" />
                            &nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" Text="Clear" runat="server" CssClass="Buttons"
                                Width="85px" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <br />
    </div>
</asp:Content>
