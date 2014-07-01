<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="FacilityBooking.aspx.cs" Inherits="SMS.ADMIN.FacilityBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Add Facility Booking</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblTypeFacility" CssClass="Labels" runat="server" Text="Type of Facility"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeOfFacility" runat="server" CssClass="Input" Width="130px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Add New Type of Facility"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddTypeOfFacility" runat="server" CssClass="Input" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAddNewType" runat="server" Text="Add " CssClass="Buttons" OnClick="btnAddNewType_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                        </asp:DropDownList>
                        <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtname" runat="server" CssClass="Input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblposition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtposition" runat="server" CssClass="Input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblunitno" CssClass="Labels" runat="server" Text="Unit No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtunitno" runat="server" CssClass="Input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblbookingDate" CssClass="Labels" runat="server" Text="Booking Date From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbookingdate" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtbookingdate" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                    </td>
                    <td>
                        <asp:Label ID="lblbookingto" CssClass="Labels" runat="server" Text="To Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbookingto" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtbookingto" PopupButtonID="ImageButton1" />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblbookingtimeFrom" Text="Booking Time From" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <MKB:TimeSelector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1"
                            SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
                    </td>
                    <td>
                        <asp:Label ID="lblbookingtimeto" Text="To Time" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <MKB:TimeSelector ID="TimeSelector12" runat="server" MinuteIncrement="1" SecondIncrement="1"
                            SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblcomment" CssClass="Labels" runat="server" Text="Comment"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtcomment" runat="server" CssClass="Input" Height="120px" TextMode="MultiLine"
                            Width="537px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" CssClass="Labels" runat="server" Text="Status" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStatus" runat="server" CssClass="Input" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td height="50px" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" Text="Submit" Width="85px"
                            OnClick="btnNewItemAdd_Click" />
                        &nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" Text="Cancel"
                            Width="85px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
