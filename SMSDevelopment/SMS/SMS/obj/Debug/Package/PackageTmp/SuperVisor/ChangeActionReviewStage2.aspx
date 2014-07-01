<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ChangeActionReviewStage2.aspx.cs" Inherits="SMS.SuperVisor.ChangeActionReviewStage2"
    Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 154px;
        }
        .style2
        {
            width: 665px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">After Action Review Form: Stage 2</span>
        </div>
        <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
            Font-Bold="True" Width="750px">
            <div>
                <asp:Label ID="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary"
                    Visible="false"></asp:Label><br />
                <br />
            </div>
            <div id="divAdvSearch" runat="server" visible="true" class="table">
                <asp:Label ID="lblheading" runat="server" CssClass="Labels" Text="This form is for all staff to report,correct and verify faults found in the day to day operations."></asp:Label><br />
                <br />
                <div id="divClient" runat="server">
                    <table border="1" width="730px">
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="lblIssu" Text="Issue Raised"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtIssueRaised" CssClass="Input" Width="620px" Height="19px"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label2" Text="Description Of Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtdescProb" CssClass="Input" Width="620px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="Labels" ID="Label3" Text="Raised By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtBy" CssClass="Input" Width="622px" TextMode="SingleLine"
                                    Height="22px" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="calDate" CssClass="Input" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divoperations" runat="server">
                    <table border="1" width="730px">
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label1" Text="Root Cause of the Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRootCause" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label4" Text="Analysis Of Critical Task Performance"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAOC" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label5" Text="Analysis Of OutCome"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAO" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label6" Text="Goals & Objectives"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtGO" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label7" Text="Actions Required To Fix The Problem"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAR" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label8" Text="Actions Required To Prevent Recurrence"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtART" CssClass="Input" Width="610px" TextMode="MultiLine"
                                    Height="131px" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label runat="server" CssClass="Labels" ID="Label9" Text="Expected Completion Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtexpected" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtexpected" PopupButtonID="imgBtnFromDate" />
                                <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                            </td>
                        </tr>
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                        <table style="margin-left: 0.005em; margin-bottom: -0.4em; border: 1px; border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)" 
                            width="730px">
                            <tr>
                                <td align="center" class="style2" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="Buttons" Height="30px" 
                                        OnClick="btnAdd_Click" Text="Submit" Width="90px" />
                                </td>
                            </tr>
                        </table>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
