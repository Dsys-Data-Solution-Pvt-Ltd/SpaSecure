<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="AssignmentVisit.aspx.cs" Inherits="SMS.Operations.AssignmentVisit"
    %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Assignment Visit Report</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
            <br />
            <table width="100%">
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
                        <asp:TextBox ID="txtsubmittedby" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNameofAssignment" Text="Name of Assignment :" CssClass="Labels"
                            runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNameofAssignment" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date / Time of Visit"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
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
                        a) IC
                    </td>
                    <td>
                        <asp:TextBox ID="txtIC" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        b) Guard 1.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard1" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        c) Guard 2.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard2" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        d) Guard 3.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard3" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        e) Guard 4.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard4" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        f) Guard 5.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard5" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        g) Guard 6.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard6" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        h) Guard 7.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard7" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        i) Guard 8.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard8" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        j) Guard 9.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard9" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        k) Guard 10.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuard10" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
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
                        <asp:TextBox ID="txtdressing" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        b) Appearance
                    </td>
                    <td>
                        <asp:TextBox ID="txtappearance" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        c) Haircut
                    </td>
                    <td>
                        <asp:TextBox ID="txthaircut" runat="server" CssClass="Input" Width="345px"></asp:TextBox>
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
                            <asp:ListItem>Correct</asp:ListItem>
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
                            <asp:ListItem>Goog</asp:ListItem>
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
                        CONCLUSTION
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtconclustion" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        RECOMMENDATION
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtrecommendation" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="25px">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:Button ID="btnAssignmentAdd" Text="Save" runat="server" CssClass="Buttons" Width="85px"
                            OnClick="btnAssignmentAdd_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" Text="Clear" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
