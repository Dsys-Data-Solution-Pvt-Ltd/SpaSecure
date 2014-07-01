<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ContractorReportForPast.aspx.cs" Inherits="SMS.SMSUsers.Reports.ContractorReportForPast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Contractor Report</span>
        </div>
        <br />
        <asp:panel runat="server" ID="Pnl" BackColor="White" 
                            style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True"  Width="750px">
            <table width="750px" class="table"> 
            <tr>
                <td>
                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px" style="margin-left:-0.3em" 
                        OnSelectedIndexChanged="ddllocation_SelectedIndexChanged" 
                        ForeColor="Black" >
                    </asp:DropDownList>
                    <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblnricno" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnricno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblpasstype" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpasstype" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblkeyno" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtkeyno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="DateFrom"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                    <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                        OnClick="imgBtnFromDate2_Click" class="calender"/>
                </td>
                <td align="left" style="width: 110px">
                    <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                </td>
                <td style="width: 170px">
                    <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                    <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                        OnClick="imgBtnFromDate3_Click" class="calender"/>
                </td>
                <td style="width: 92px">
                    <asp:Label ID="lblvehicleno" CssClass="Labels" runat="server" Text="Vehicle No."
                        Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvehicleno" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td >
                    <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                    <asp:TextBox ID="txtrole" runat="server" Visible="False" Width="15px">Contractor</asp:TextBox>
               
            </tr>
            <tr>
            <td style="height:50px">
               
               </td>
               </tr>
               
             </table>
        </asp:panel>

            <table  width="750px" style="margin-left:1.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black; background-color:Gray">

                                            <tr>
                                                <td colspan="4" align="center" style="width: 750px">
                    <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch1_Click"
                        Width="85px" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                        OnClick="btnclear_Click" />
                </td>
            </tr>
            
        </table>
       
        <br />
        <div>
            <asp:Panel ID="panel11" runat="server" Width="750px" style="margin-left:1.2em">
                <asp:GridView ID="gvItemTable"  runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" Width="750px"
                    OnRowDataBound="gvItem_RowDataBound" OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                    HeaderStyle-HorizontalAlign="Center" PageSize="20">
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <HeaderStyle CssClass="HeaderRow" />
                    <RowStyle CssClass="NormalRow" />
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                        </asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="checkin_time" HeaderText="In Time"></asp:BoundField>
                        <asp:BoundField DataField="checkout_time" HeaderText="Out Time"></asp:BoundField>
                        <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No."></asp:BoundField>
                        <asp:BoundField DataField="user_name" HeaderText=" Name"></asp:BoundField>
                        <asp:BoundField DataField="telephone" HeaderText="Phone No."></asp:BoundField>
                        <asp:BoundField DataField="pass_no" HeaderText="Pass No."></asp:BoundField>
                        <asp:BoundField DataField="company_from" HeaderText="Company From"></asp:BoundField>
                        <asp:BoundField DataField="to_visit" HeaderText="To Visit"></asp:BoundField>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../../Images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="DeleteRow" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <div>
           <asp:panel runat="server" ID="Pnl3" BackColor="White" 
                            style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True"  Width="750px">
            <table width="750px"> 
                <tr>
                    <td style="width: 122px">
                        <asp:Label ID="exportto" runat="server" CssClass="Labels" Font-Bold="true" ForeColor="#000099"
                            Text="Export To:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Labels" ForeColor="#000099"
                            Width="81px">
                            <asp:ListItem>Pdf</asp:ListItem>
                            <asp:ListItem>Word</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;&nbsp;
                        <asp:Button ID="btnGo" runat="server" CssClass="Buttons" OnClick="btnGo_Click" Text="Go"
                            Width="60px" />
                    </td>
                    <td>
                        <asp:Button ID="btnEmail" runat="server" CssClass="Buttons" Text="E-Mail" Width="85px"
                            OnClick="btnEmail_Click" Visible="False" />
                    </td>
                    <td>
                        <asp:Button ID="btnPrint" runat="server" CssClass="Buttons" Text="Print" Width="85px"
                            OnClick="btnPrint_Click" Visible="False" />
                    </td>
                </tr>
            
           </table> </asp:panel>
        </div>
        <br />
    </div>
</asp:Content>
