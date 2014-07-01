<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="PastSite.aspx.cs" Inherits="SMS.SMSAdmin.PastSite" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Past Site</span></div>
       
                    <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                                        <table width="900px">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblLocationID" Text="Location Code" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLocationID" runat="server" CssClass="Input" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblLocation" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddLocation" runat="server" CssClass="Input" 
                                                        Width="131px" />
                                                </td>
                                        </tr>
                                        <tr>        
                                                <td align="left">
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
                                                
                                               <td align"right" align="left">
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
                            <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                            </asp:Label>
                            <p>Suggestions:</p>                    
                            <li>Try different keywords.</li>
                            <li>Try fewer keywords.</li>
                            <li>Make sure all words are spelled correctly.</li>
                            <li>There may be no records in the system.</li>
                            <li>To add Billing Table click the Add New Billing Table button.</li>
                        </EmptyDataTemplate>
                        <Columns>
                        
                                
                                    <%-- <asp:BoundField DataField="Date_From" HeaderText="Add Time" Visible="false"><HeaderStyle Width="200px" /></asp:BoundField>
                                    --%> 
                                      
                                    <asp:BoundField DataField="Location_id" HeaderText="Location Code"><HeaderStyle Width="200px" /></asp:BoundField>
                                    <asp:BoundField DataField="Location_name" HeaderText="Name"><HeaderStyle Width="200px" /></asp:BoundField>
                                   <asp:BoundField DataField="Loc_Address" HeaderText="Address"><HeaderStyle Width="200px" /></asp:BoundField>
                            
                            
                            
                            
                             <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
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
