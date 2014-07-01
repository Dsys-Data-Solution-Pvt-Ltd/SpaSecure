<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="PenaltySecurity.aspx.cs" Inherits="SMS.SuperVisor.PenaltySecurity" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function PrintGridData() {
            var prtGrid = document.getElementById('<%=gvPassTable.ClientID %>');

            //window.print();
            prtGrid.border = 0;
            //GridView1.Attributes(style) = "page-break-after:always"         
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="Panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divHeader">
        <span class="pageTitle">Penalty Clause For Security</span></div>
        <br />
    <div id="content" runat="server">

    <asp:Panel ID="Panelgrid" runat="server">
        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadGrid ID="gvPassTable" runat="server" CssClass="RadGrid" GridLines="None"
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
                            <telerik:GridBoundColumn UniqueName="Heading" DataField="Heading" HeaderText="Heading"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Clause" DataField="Clause" HeaderText="Clause"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Fine" DataField="Fine" HeaderText="Fine" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <NoRecordsTemplate>
                         <asp:Label ID="lblNoRecords" text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
                </asp:Panel>
                <br />
                <div style=" background-color: #E4E4E4;">
                    <center>
                    <%--<a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>
--%>
                        <asp:Button ID="btnprint" CssClass="Button" Height="30px" Width="100px" runat="server"
                            Text="Print" OnClientClick="javascript:PrintGridData();" />
                    </center>
                </div>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        
    </div>
    <%--<div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                    CssClass="ValSummary"></asp:Label>
             </div>                                 
           <br />    --%>
    <%--<asp:Panel ID="printview" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True" width="750px">
       
            <div align="center" style="height: 22px"><asp:Label id="Label1" runat="server"  
                    Font-Bold="True" CssClass="Labels" 
                    Text="PENALTY CLAUSE FOR ALL SECURITY PERSONNEL" Font-Size="Medium"></asp:Label></div> 
            <br />
            <br />      
           <div style=" margin-left:0.1em; width:750px">
            <asp:gridview id="gvPassTable1" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="750px" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" onpageindexchanging="gvPass_PageIndexChanging"
                cssclass="GridMain2" 
                   onselectedindexchanged="gvPassTable_SelectedIndexChanged" PageSize="100">
            
            <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle cssclass="NormalRow"/>
            <AlternatingRowStyle cssclass="AlternateRow"/>
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow"/>
            <EmptyDataRowStyle cssclass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>           
                                        
                                
                    <asp:BoundField datafield="Heading" headertext="Heading"></asp:BoundField>
                    <asp:BoundField datafield="Clause" headertext="Clause"></asp:BoundField>
                     <asp:BoundField datafield="Fine" headertext="Fine" ItemStyle-Width="100px"></asp:BoundField>                     
                 
                <%--  <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Penality_id") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Penalty_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> --%>
    <%-- </Columns>
       </asp:gridview>
  </div> 
  </asp:Panel>--%>
    <%-- <br />
          <div class="table">
                <table  width="750px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr><td colspan="4" align="center" style="width: 897px">
                          <asp:button id="btnNewPass" text="Print" runat="server" 
                            cssclass="Buttons" onclick="btnNewPass_Click" Font-Bold="True" Height="35px" 
                               Width="100px"/>
                </td> </tr>
                </table>
                       
                        
          </div>
        <br />--%>
</asp:Content>
