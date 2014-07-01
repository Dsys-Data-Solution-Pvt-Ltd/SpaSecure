<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="eventplanner.aspx.cs" Inherits="SMS.SMSAdmin.eventplanneraspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Event Planner</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <br />
            <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
            <tr><td height="10"></td></tr>
                <tr>
                    <td style="width: 162px">
                        <asp:Label ID="lblLocation1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td style="width: 172px">
                        <asp:DropDownList ID="drlLocation" runat="server" CssClass="Labels" 
                            ForeColor="Black">
                        </asp:DropDownList>
                        <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                    </td>
                    <td align="left" style="width: 95px">
                        <asp:Label ID="lblEventType1" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                    </td>
                    <td style="width: 189px">
                        <asp:DropDownList ID="ddlEventType" runat="server" CssClass="Labels" 
                            ForeColor="Black">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 162px">
                        <asp:Label ID="lblpersonincharg" CssClass="Labels" runat="server" Text="Person In Charge"></asp:Label>
                    </td>
                    <td style="width: 172px">
                        <asp:TextBox ID="txtpersonincharg" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 95px">
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                    </td>
                    <td style="width: 189px">
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate2_Click" CssClass="calender" />
                    </td>
                    <td>
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" OnTextChanged="txtdateto_TextChanged"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate3_Click" CssClass="calender"/>
                    </td>
                </tr>
                <tr><td height="30px"></td></tr>
                </table>
                <table  width="100%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch1_Click"
                            Width="85px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCanel" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                            OnClick="btnCanel_Click" />
                    </td>
                </tr>
            </table>
            </asp:panel>
        </div>
        <br />
        <div >
            <asp:GridView ID="gvNewEventSearch" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" OnRowDataBound="gvNewEvent_RowDataBound"
                OnRowCommand="gvNewEvent_RowCommand" OnPageIndexChanging="gvNewEvent_PageIndexChanging"
                CssClass="GridMain2" 
                OnSelectedIndexChanged="gvNewEvent_SelectedIndexChanged" PageSize="100">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                    </asp:Label>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                    <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
                    <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                    <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
                    <asp:BoundField DataField="Event_Type" HeaderText="Event Type"></asp:BoundField>
                    <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="table">
         <table  width="102%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
             <tr>
                <td colspan="4" align="center" style="width: 897px">
                <asp:Button ID="btnAddNewEvent" CssClass="Buttons" runat="server" Text="Add New Event"
                OnClick="btnAddNewEvent_Click" />
                </td>
                </tr>
                </table>
        </div>
        <br />
    </div>
</asp:Content>
