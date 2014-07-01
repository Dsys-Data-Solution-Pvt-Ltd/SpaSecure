<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AdminIncident.aspx.cs" Inherits="SMS.SuperVisor.AdminIncident" Title="Admin Incident" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Incident</span></div>
        <br />
        <asp:Panel runat="server" ID="Panel2" BackColor="White" Style="margin-left: 1.5em"
            Font-Bold="True" Width="740px">
            <table width="740px" class="table">
                <tr>
                    <td style="width: 6em">
                        <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                        </asp:DropDownList>
                        <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblreport" CssClass="Labels" runat="server" Text="Reported By"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtreport" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 6em">
                        <asp:Label ID="lblincidentno" CssClass="Labels" runat="server" Text="Report No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtincidentno" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblplaceofincident" CssClass="Labels" runat="server" Text="Place of Incident"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtplaceofincident" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 6em">
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date: From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            class="calender" />
                    </td>
                    <td align="left">
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            class="calender" />
                    </td>
                </tr>
                <td style="width: 6em">
                    <asp:Label ID="lblverifiedby" CssClass="Labels" runat="server" Text="Verified By"
                        Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtverifiedby" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                </td>
                <tr>
                    <td height="20px" style="width: 6em">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table width="740px" style="margin-left: 1.4em; margin-bottom: -0.4em; border: 1px;
            border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" Text="Search" Width="85px"
                        OnClick="btnSearch_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                        OnClick="btnclear_Click" />
                </td>
            </tr>
        </table>
        <br />
        <div style=" margin-left:1.5em; width:750px">
            <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="740px" OnRowDataBound="gvItem_RowDataBound"
                OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                CssClass="GridMain2" OnSelectedIndexChanged="gvItemTable_SelectedIndexChanged"
                PageSize="20">
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
                    <asp:BoundField DataField="Date_of_Incident" HeaderText="Date of Incident"></asp:BoundField>
                    <asp:BoundField DataField="Time_of_Incident" HeaderText="Time of Incident"></asp:BoundField>
                    <asp:BoundField DataField="Report_No" HeaderText="Report No."></asp:BoundField>
                    <asp:BoundField DataField="Place_of_Incident" HeaderText="Place of Incident"></asp:BoundField>
                    <asp:BoundField DataField="followstatus" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="AlertStatus" HeaderText="Alert Status"></asp:BoundField>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Incident_id") %>'
                                CommandName="View" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Follow-Up Incident" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Incident_id") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Incident_id") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            <%--<tr>
                   <td>
                       <asp:label id="incident1" cssclass="Labels" runat="server" text="Total Incident :"
                        forecolor="#000099" Font-Bold="true"></asp:label></td>
                   <td>
                       <asp:label id="incident2" cssclass="Labels" runat="server" forecolor="#000099" Font-Bold="true"></asp:label></td>
              </tr> 
               <tr>
                   <td>
                        <asp:label id="exportto" cssclass="Labels" runat="server" text="Export To :" forecolor="#000099" Font-Bold="true"></asp:label>
                   </td>
                   <td>
                         <asp:dropdownlist id="DropDownList1" cssclass="Labels" runat="server" 
                          forecolor="#000099" Width="79px" Height="16px">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                        <asp:ListItem>Html</asp:ListItem>    
                        </asp:dropdownlist>
                   </td>
                
                    <td>
                        <asp:button id="btnGo" cssclass="Buttons" runat="server" text="Go" 
                        width="85px"/>          
                    </td>
                    <td>
                        <asp:button id="btnEmail" cssclass="Buttons" runat="server" text="E-Mail" 
                            width="85px" />
                    </td>
                    <td>
                        <asp:button id="btnPrint" cssclass="Buttons" runat="server" text="Print" 
                            width="85px"/>
                    </td>--%>
            <table width="740px" style="margin-left: 1.4em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" style="width: 897px">
                        <asp:Button ID="btnAddnewIncident" runat="server" Text="Add New Incident" CssClass="Buttons"
                            OnClick="btnAddnewIncident_Click" />
                        <asp:Button ID="IncidentFollowUp" runat="server" Text="Incident Follow-Up" CssClass="Buttons"
                            OnClick="IncidentFollowUp_Click" Visible="False" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
