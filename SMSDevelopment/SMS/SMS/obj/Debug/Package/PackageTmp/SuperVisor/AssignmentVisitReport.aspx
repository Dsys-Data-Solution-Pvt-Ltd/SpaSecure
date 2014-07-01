<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AssignmentVisitReport.aspx.cs" Inherits="SMS.SuperVisor.AssignmentVisitReport"
    Title="Assignment Visit Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForCR">
        <div class="divHeader">
            <span class="pageTitle">Assignment Visit Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel runat="server" ID="printview" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="740px">
                <table width="740px" class="table">
                <tr>
                <td colspan="4" style=" height:90px;" align="center">
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black; width:650px"></hr>
                </td>
                </tr>
                    <tr>
                        <td align="center" colspan="3" height="70px" valign="middle">
                            <asp:Label ID="lblIncidentReport" Text="Assignment Visit Report" CssClass="Labels"
                                runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTo" Text="TO" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="Input" Width="500px" OnTextChanged="txtTo_TextChanged"
                                Visible="False">a</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsubmittedby" Text="SUBMITTED BY" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtsubmittedby" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNameofAssignment" Text="NAME OF ASSIGNMENT" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtNameofAssignment" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="DATE / TIME OF VISIT"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtdateofvisit" runat="server" CssClass="Reportcolor"></asp:Label>
                            <%--<AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>--%>
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
                            a) SuperVisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtIC" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Guard 1.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard1" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Guard 2.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard2" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            d) Guard 3.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard3" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            e) Guard 4.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard4" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            f) Guard 5.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard5" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            g) Guard 6.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard6" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            h) Guard 7.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard7" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            i) Guard 8.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard8" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            j) Guard 9.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard9" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            k) Guard 10.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard10" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
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
                            <asp:TextBox ID="txtdressing" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Appearance
                        </td>
                        <td>
                            <asp:TextBox ID="txtappearance" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Haircut
                        </td>
                        <td>
                            <asp:TextBox ID="txthaircut" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ALERTNESS
                        </td>
                        <td>
                            <asp:Label ID="txtAlertness" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DEPLOYMENT
                        </td>
                        <td>
                            <asp:Label ID="txtDeployment" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            GENERAL PERFORMANCE
                        </td>
                        <td>
                            <asp:Label ID="txtgeneralPerformance" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            OTHER MATTERS
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtotherMatters" runat="server" CssClass="Input" Width="500px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CONCLUSTION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtconclustion" runat="server" CssClass="Input" Width="500px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            RECOMMENDATION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtrecommendation" runat="server" CssClass="Input" Width="500px"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="table">
                <table width="740px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 897px">
                            <asp:Button ID="Button1" runat="server" CssClass="Buttons" Text="Print" Width="110px"
                                Height="30px" OnClick="btnprint_Click" Font-Bold="True" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
