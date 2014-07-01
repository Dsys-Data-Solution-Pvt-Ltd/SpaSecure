<%@ Page Language="C#" MasterPageFile="~/master/spamaster.Master" AutoEventWireup="true"
    CodeBehind="AfterActionReview.aspx.cs" Inherits="SMS.SuperVisor.AfterActionReview"
    Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">After Action Review Form</span>
        </div>
        <div>
            <asp:Label ID="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary"
                Visible="false"></asp:Label><br />
            <br />
        </div>
        <div id="divAdvSearch" runat="server" visible="true" class="table">
            <asp:Panel runat="server" ID="Pnl" BackColor="White" Style="margin-left: 0.8em; margin-top: 0px;"
                Font-Bold="True" Width="750px">
                <asp:Label ID="lblheading" runat="server" CssClass="Labels" Text="This form is for management to correct and verify faults found in the day to day operations of our security personnel."></asp:Label><br />
                <br />
                <div id="divClient" runat="server">
                    <table width="750px">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="Labels" Text="This section is to be completed by the person reporting the fault to the Managing Director."></asp:Label><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="lblIssu" Text="Issue Raised"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtIssueRaised" CssClass="Input" Width="622px" Height="19px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label2" Text="Description Of Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtdescProb" CssClass="Input" Width="615px" TextMode="MultiLine"
                                    Height="131px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label3" Text="Raised By"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtBy" CssClass="Input" Width="622px" TextMode="SingleLine"
                                    Height="22px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="Save" Width="100px"
                                        OnClick="btnAdd_Click" Height="30px" /></center>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
