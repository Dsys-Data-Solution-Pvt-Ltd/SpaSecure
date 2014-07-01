<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ClientVisitMinutes.aspx.cs" Inherits="SMS.SuperVisor.ClientVisitMinutes"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForCR">
        <div class="divHeader">
            <span class="pageTitle">Client Visit Minutes</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left:1.5em"
                Font-Bold="True" Width="750px">
                <table width="740px" class="table">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblcompletedby" Text="Completed By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtcompletedby" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date"></asp:Label>
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
                            <asp:Label ID="lblMetwith" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtClientName" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="40" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            1) COMPLAINTS/ ABSENTEEISM
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtcomplaints" runat="server" CssClass="Input" Width="720px" Height="55px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            2) POSITIVE COMMENTS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtpositivecomments" runat="server" CssClass="Input" Width="720px"
                                Height="55px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            3) DEPLOYMENT/ OTHER CHANGES
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtdeployment" runat="server" CssClass="Input" Width="720px" Height="55px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            4) UP-COMING EVENTS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtupcomingevent" runat="server" CssClass="Input" Width="720px"
                                Height="55px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            5) REMARKS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtremarks" runat="server" CssClass="Input" Width="720px" Height="60px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                        </td>
                    </tr>
                    <tr>
                        <%--  <td>Acknowledgment </td>
                                             <td> <asp:TextBox ID="txtAcknowledge" runat="server" CssClass="Input" Width="500px"></asp:TextBox></td>  --%>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
                <table width="750px" style="margin-left:0.005em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" width="750px">
                            <asp:Button ID="btnAssignmentAdd" Text="Save" runat="server" CssClass="Buttons" Width="85px"
                                OnClick="btnAssignmentAdd_Click" />
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" Text="Clear" runat="server"
                                CssClass="Buttons" Width="85px" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <br />
    </div>
</asp:Content>
