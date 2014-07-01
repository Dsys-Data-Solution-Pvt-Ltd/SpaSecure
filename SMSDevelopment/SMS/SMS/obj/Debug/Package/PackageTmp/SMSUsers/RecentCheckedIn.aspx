<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true" CodeBehind="RecentCheckedIn.aspx.cs" Inherits="SMS.SMSUsers.RecentChecedIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
        <div class="divHeader"><span class="pageTitle">Checked In To Evacuation List</span>  
        </div>
        <br />
         <div id="content" runat="server">
    
        <br />
    <asp:Panel ID="Panelgrid" runat="server" >
         <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" >
            <ContentTemplate>--%>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
            </telerik:RadAjaxLoadingPanel>

            <telerik:RadGrid ID="gvItemTable" runat="server" CssClass="RadGrid" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <%--<telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                    AutoPostBack="True" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridBoundColumn UniqueName="Checkin_DateTime" DataField="Checkin_DateTime" HeaderText="In Time"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="user_name" DataField="user_name" HeaderText="Name"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="NRICno" DataField="NRICno" HeaderText="NRIC/FIN No."
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="telephone" DataField="telephone" HeaderText="Phone No." CurrentFilterFunction="Contains"
                            AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Vehicle_No" DataField="Vehicle_No" HeaderText="Vehicle No."
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="to_visit" DataField="to_visit" HeaderText="To Visit"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>

            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        </div>

      
        <asp:panel runat="server" ID="Panel1" BackColor="White" Visible="false" 
                            style=" margin-left:1.5em" Font-Bold="True" width="700px">
            <table width="700px" class="table">
            <tr><td height="10"></td></tr>
              <tr>
                  
            
                    <td style="width: 191px">
                         <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 158px">
                         <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" 
                             onselectedindexchanged="ddllocation_SelectedIndexChanged"></asp:DropDownList>                        
                           <asp:Label ID="SearchLocID" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                             
                    </td>
                    
                    <td>
                      <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select Role : "></asp:Label>
                  </td>
                  <td>
                       <asp:DropDownList ID="txtrole" runat="server" cssclass="Labels" 
                           ForeColor="Black" 
                         onselectedindexchanged="txtrole_SelectedIndexChanged"> 
                        <%-- <asp:ListItem></asp:ListItem> --%>
                         <asp:ListItem>Visitor</asp:ListItem> 
                         <asp:ListItem>Contractor</asp:ListItem>   
                      </asp:DropDownList>
                  </td>
                    
                    
                    
              </tr>
              
            <tr>
                <td align="left" style="width: 191px">
                    <asp:Label ID="Label1nricno" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                </td>
                <td style="width: 158px">
                    <asp:TextBox ID="txtnricno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Label ID="vehicleno" CssClass="Labels"  runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvehicleno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                
            
                <td align="left">
                    <asp:Label ID="keyno" CssClass="Labels"  runat="server" Text="Key No." 
                        Visible="False"></asp:Label>
                </td>
             
                <td>
                    <asp:TextBox ID="txtkeyno" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                </td>
             </tr>
             <tr>
                    <td align="left" style="width: 191px">
                        <asp:Label ID="passtype" CssClass="Labels"  runat="server" Text="Pass No." 
                            Visible="False"></asp:Label>
                     </td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtpasstype" CssClass="Input" runat="server" Visible="False"></asp:TextBox>
                     </td>

                    <td align="left">
                       <asp:Label ID="date" CssClass="Labels"  runat="server" Text="Date:  From" 
                            Visible="False"></asp:Label> </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                            ontextchanged="txtdatefrom_TextChanged" Visible="False"></asp:TextBox>                            
                         <ajax:calendarextender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" 
                            PopupButtonID="imgBtnFromDate2" />                                    
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" 
                            ImageUrl="~/Images/calendar.bmp" onclick="imgBtnFromDate2_Click" 
                            Visible="False" class="calender"/></td>
                    <td align="left">
                         <asp:Label ID="dateto" CssClass="Labels"  runat="server" Text="To" 
                             Visible="False"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                             ontextchanged="txtdateto_TextChanged" Visible="False"></asp:TextBox>
                        <ajax:calendarextender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdateto" 
                             PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                        ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"  
                             onclick="imgBtnFromDate3_Click" Visible="False" class="calender"/>
                     
                     </td>
                   
                </tr>
                <tr>
                        <td height="30px" style="width: 191px">
                            
                        </td>
                
                </tr>
                </table>
              <table  width="700px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">

                                            <tr>
                                                <td colspan="4" align="center" width="700px">
                    <asp:Button ID="Button11" CssClass="Buttons" runat="server" Text="Search" 
                        Width="85px" onclick="Button11_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" 
                        Width="85px" onclick="btnclear_Click"  />
                </td>
                
            </tr>
            </table>
           
             </asp:panel>
     
    
        <div style=" margin-left:1.5em; width:750px">
         
          <asp:gridview id="gvItemTable1" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="700px"
            onrowdatabound="gvItem_RowDataBound"
            onrowcommand="gvItem_RowCommand" 
            onpageindexchanging="gvItem_PageIndexChanging"
            cssclass="GridMain2" 
            onselectedindexchanged="gvItemTable_SelectedIndexChanged" PageSize="100">
            
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
                <li>To add Billing Table click the Add New Item Code.</li>
            </EmptyDataTemplate>
            <Columns>
            
            
                    <asp:BoundField DataField="Checkin_DateTime" HeaderText="In Time"> </asp:BoundField>
                     <asp:BoundField DataField="user_name" HeaderText="Name"> </asp:BoundField>
                    <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No."> </asp:BoundField>                   
                     <asp:BoundField DataField="telephone" HeaderText="Phone No."></asp:BoundField>
                     <asp:BoundField DataField="Vehicle_No" HeaderText="Vehicle No."></asp:BoundField>
                     <asp:BoundField DataField="to_visit" HeaderText="To Visit"></asp:BoundField>
                    
                   
                 <%--<asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.checkin_id") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.checkin_id") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>

                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> --%>
                
            </Columns>
    </asp:gridview>
    
    <br /> 
    </div>
     
        
       
          <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                    <tr>
                     <td style="width: 126px">
                       <asp:Label ID="visitor1" CssClass="Labels" runat="server" Text="Total :" 
                        ForeColor="#000099" Font-Bold="True" Visible="False"></asp:Label> </td>

                    <td><asp:Label ID="visitor2" CssClass="Labels"  runat="server" ForeColor="#000099" 
                            Font-Bold="True" Visible="False"></asp:Label></td>
                        <td>
                           <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"
                            Font-Bold="true" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Labels" ForeColor="#000099"
                                Width="81px">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem>Pdf</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnGo" CssClass="Button" Height="30px" Width="100px" runat="server" Text="Go" OnClick="btnGo_Click" />
                        </td>
                         <td>
                        <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="85px"
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="85px"
                            OnClick="btnPrint_Click" Visible="False" />
                    </td>
                    </tr>
                </table>
                </center>
                </div>
     
   

</asp:Content>
