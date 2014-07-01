<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AdminLocation.aspx.cs" Inherits="SMS.ADMIN.AdminLocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Present Site</span></div>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                                        <table width="900px">
                                            <tr>                                              
                                                <td>
                                                    <asp:Label ID="lblLocation" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocation" runat="server" CssClass="Input" 
                                                        Width="131px" />
                                                </td>
                                        </tr>
                                        <tr>
                                                <td>
                                                    <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                                </td>
                                               <td>
                                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                                                     ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                    onclick="imgBtnFromDate2_Click" style="width: 16px" Width="28px"/>
                                               </td>
                                               <td>
                                                        <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                                                        ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                        Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                        ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                        onclick="imgBtnFromDate3_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td height="15px"></td>                                            
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchLocationAdd" Text="Search" runat="server" 
                                                        CssClass="Buttons" onclick="btnSearchLocationAdd_Click" Width="85px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; 
                                                    <asp:Button ID="btnClearLocationAdd" Text="Clear" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearLocationAdd_Click" Width="85px" />
                                                </td>
                                            </tr>
                                        </table>                        
                    </div>
                <br/>
              <div style="overflow: auto">
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
                        cssclass="GridMain" 
                        onselectedindexchanged="gvLoctionTable_SelectedIndexChanged">
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
                        <RowStyle CssClass="NormalRow"/>
                        <AlternatingRowStyle CssClass="AlternateRow"/>
                        <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
                        <SelectedRowStyle CssClass="HighlightedRow"/>
                        <EmptyDataRowStyle CssClass="NoRecords"/>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                            </asp:Label>
                        </EmptyDataTemplate>
                        <Columns>
                                    <asp:BoundField DataField="Location_name" HeaderText="Name"></asp:BoundField>
                                    <asp:BoundField DataField="Loc_Address" HeaderText="Address"></asp:BoundField>
                             <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Location_id") %>' CommandName="EditRow" runat="server"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                               <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Location_id") %>' CommandName="DeleteRow" runat="server"/>
                                </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             </asp:TemplateField> 
                        </Columns>
            </asp:gridview>
    </div>
  <br />
  <br />
    <div> 
         <asp:button id="btnNewLocation" text="Add New Location" runat="server" cssclass="Buttons"
          onclick="btnNewLocation_Click" />
    </div>
  <br/>
 </div> 
</asp:Content>
