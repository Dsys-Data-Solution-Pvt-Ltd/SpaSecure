<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AdminTraining.aspx.cs" Inherits="SMS.ADMIN.AdminTraining" Title="Admin Training" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Training Management</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <br />
            <table width="100%" class="table">
                <tr>
                    <td align="left">
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                    </td>
                    <td>
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                    </td>
                </tr>
                <tr>
                    <td height="15px">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5">
                        <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="Buttons" Width="85px"
                            OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClear" Text="Clear" runat="server" CssClass="Buttons" Width="85px"
                            OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvLoctionTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" OnRowDataBound="gvLocation_RowDataBound"
                OnRowCommand="gvLocation_RowCommand" OnPageIndexChanging="gvLocation_PageIndexChanging"
                CssClass="GridMain2" 
                OnSelectedIndexChanged="gvLoctionTable_SelectedIndexChanged" PageSize="20">
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
                    <asp:BoundField DataField="T_startdate" HeaderText="Start Date">
                        <HeaderStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="T_enddate" HeaderText="End Date">
                        <HeaderStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="training_type" HeaderText="Training Topic">
                        <HeaderStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="Facilitation" HeaderText="Facilitator"></asp:BoundField>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnview" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.training_id") %>'
                                CommandName="View" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.training_id") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.training_id") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div class="table">
            <asp:Button ID="btnNewTraining" Text="Add New Training" runat="server" CssClass="Buttons"
                OnClick="btnNewTraining_Click" />
        </div>
        <br />
    </div>
</asp:Content>
