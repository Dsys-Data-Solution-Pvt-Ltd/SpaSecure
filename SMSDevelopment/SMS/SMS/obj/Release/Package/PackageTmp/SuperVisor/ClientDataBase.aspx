<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientDataBase.aspx.cs" Inherits="SMS.SuperVisor.ClientDataBase" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function PrintGridData() {
            var prtGrid = document.getElementById('<%=printview.ClientID %>');

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
        <span class="pageTitle">Client Database</span>
    </div>
    <div class="btnbar" style="margin-top: 20px">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImageView">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="content" runat="server">
    <asp:Panel ID="Panelgrid" runat="server">
        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadGrid ID="gvItemTable" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Location_id">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Location_id" DataField="Location_id" HeaderText="Site ID"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Location_name" DataField="Location_name" HeaderText="Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <NoRecordsTemplate>
                         <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                <li>To add Billing Table click the Add New Item Code.</li>
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnView" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupView" runat="server" TargetControlID="hdnView"
            CancelControlID="btnCancelView" BackgroundCssClass="modalBackground" PopupControlID="pnlView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" BackColor="White" Height="560px" Width="750px"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait82" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait82" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <center>
                        <asp:Panel runat="server" ID="printview" BackColor="White">
                            <table width="650px">
                                <tr>
                                    <td colspan="4">
                                    <center>
                                        <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black; width: 700px" />
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" valign="middle">
                                    <center>
                                        <asp:Label ID="lblIncidentReport" Text="Client Database" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblOperationsContact" Text="Operations Contact  :" CssClass="Reportcolor"
                                            runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOperationName" Text="Name" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtOperationName" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOperationsContactTele" Text="Telephone" CssClass="Reportcolor"
                                            runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtOperationsContactTele" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOperationsContactMobile" Text="Mobile" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtOperationsContactMobile" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOperationsContactEmail" Text="E-mail" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtOperationsContactEmail" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOperationsContactFax" Text="Fax" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtOperationsContactFax" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="35" valign="bottom">
                                        <asp:Label ID="lblManagementContact" Text="Management Contact  :" CssClass="Reportcolor"
                                            runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblManageName" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtManageName" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblManageTele" Text="Telephone" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtManageTele" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblManageMobile" Text="Mobile" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtManageMobile" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblManageEmail" Text="E-mail" CssClass="Reportcolor" runat="server"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtManageEmail" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblManageFax" Text="Fax" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtManageFax" CssClass="Reportcolor" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                   

                    <br />
                        <div style="background-color: #E4E4E4; width:720px" >
                        <center>
                          <a id="print" href="~/Reports/printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                        <asp:Button ID="btnCancelView" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="btnCancelView_Click" />

                                       <%--  <asp:Button ID="btnprint" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Print" OnClientClick="javascript:PrintGridData();"/>--%>
                                        </center>
                        </div>
                         </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <%--<div style=" margin-left:1.5em; width:750px">       
          <asp:gridview id="gvItemTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="750px"
            onrowdatabound="gvItem_RowDataBound"
            onrowcommand="gvItem_RowCommand" 
            onpageindexchanging="gvItem_PageIndexChanging"
            cssclass="GridMain2" 
            onselectedindexchanged="gvItemTable_SelectedIndexChanged" PageSize="20">
            
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
                     <asp:BoundField DataField="Location_id" HeaderText="Site ID"></asp:BoundField>
                     <asp:BoundField DataField="Location_name" HeaderText="Name"></asp:BoundField>                    
                   
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Location_id") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>
                   <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                  <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
              
                
            </Columns>
    </asp:gridview>    
    <br /> 
    </div>--%>
</asp:Content>
