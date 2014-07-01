<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="PreRegisterVisitors.aspx.cs" Inherits="SMS.Client.PreRegisterVisitors"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <asp:Label ID="lblHead" runat="server" CssClass="pageTitle" Text="Add Pre-Registered Visitors"></asp:Label>
            <asp:HiddenField ID="hdnCSID" runat="server" />
        </div>
        <asp:HiddenField ID="hdnPRVSID" runat="server" />
        <asp:Label ID="lblerror" runat="server" Text="lblerror " ForeColor="Red" CssClass="ValSummary"></asp:Label>
        <div id="divAdvSearch" runat="server" visible="true">
        <br />
        <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750px" class="table">
            <tr><td height="10" style="width: 14%"></td></tr>
            <tr>
                <td style="width: 14%">
                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" 
                        AutoPostBack="True" onselectedindexchanged="ddllocation_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 14%">
                    <asp:Label ID="Label8" runat="server" CssClass="Labels" Text="From Date"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="Input"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                    <asp:Image ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender" />
                </td>
                <td style="width: 45%">
                    <asp:Label ID="Label9" runat="server" CssClass="Labels" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="Input"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtToDate" PopupButtonID="imgBtnToDate" />
                    <asp:Image ID="imgBtnToDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                </td>
            </tr>
            <tr>
                <td style="width: 14%">
                    <asp:Label ID="Label10" runat="server" CssClass="Labels" Text="Expected Time"></asp:Label>
                </td>
                <td style="width: 215px">
                    <MKB:TimeSelector ID="tsExpectedTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                </td>
                <td style="width: 45%">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" colspan="4">
                    <asp:Button ID="btnAddCStaff" CssClass="Buttons" runat="server" Text="Add"
                        Width="85px" Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="pnlVisitors" runat="server" Width="721px">
                        <table style="width:750px" >
                            <tr>
                                <td width="20%">
                                    <asp:Label ID="Label1" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td width="20%">
                                    <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    <asp:Label ID="Label3" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td width="20%">
                                    <asp:Label ID="lblVechicle" runat="server" CssClass="Labels" Text="Vehicle Registration No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVechicle" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    <asp:Label ID="lblpurpose" runat="server" CssClass="Labels" Text="Purpose"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpurpose" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="35" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    <asp:Label ID="lblInvitedBy" runat="server" CssClass=" Labels" Text="Invited By"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtInvitedBy" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    <asp:Label ID="lbltelephone" runat="server" CssClass=" Labels" Text="Telephone"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txttelephone" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="20" colspan="3">
                                </td>
                            </tr>
                            </table>     
                    </asp:Panel>
                    <br />
                </td>
            </tr>
        </table>
        <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                                <td colspan="4" align="center" style="width: 750px">
                                    <asp:Button ID="btnAddVisitor" CssClass="Buttons" runat="server" Text="Add  Visitor"
                                        OnClick="btnAddVisitor_Click" Width="130px" />
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    <%--</td>
                                <td>--%>
                                    <asp:Button ID="btnCancelCStaff" CssClass="Buttons" runat="server" Text="Cancel"
                                        OnClick="btnCancelCStaff_Click" Width="85px" />
                                </td>
                            </tr>
                        </table>
        </asp:panel>
        </div>
        <br />
        <div style=" margin-left:1.5em; width:750px">
            <asp:GridView ID="gvPreRegisteredVisits" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvPreRegisteredVisits_RowDataBound"
                OnRowCommand="gvPreRegisteredVisits_RowCommand" OnPageIndexChanging="gvPreRegisteredVisits_PageIndexChanging"
                CssClass="GridMain2" PageSize="20">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="No records in the system." runat="server">
                    </asp:Label>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="FromDate1" HeaderText="From Date" HeaderStyle-Width="120px">
                    </asp:BoundField>
                    <asp:BoundField DataField="ToDate1" HeaderText="To Date" HeaderStyle-Width="120px">
                    </asp:BoundField>
                    <asp:BoundField DataField="ExpectedTime" HeaderText="Arrival Time" HeaderStyle-Width="100px">
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="140px"></asp:BoundField>
                    <asp:BoundField DataField="Invited_By" HeaderText="Invited By" HeaderStyle-Width="120px">
                    </asp:BoundField>
                    <asp:BoundField DataField="Company" HeaderText="Company"></asp:BoundField>
                    <asp:BoundField DataField="Position" HeaderText="Position"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
