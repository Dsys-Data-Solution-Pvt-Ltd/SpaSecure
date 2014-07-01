<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AttendanceReportPast.aspx.cs" Inherits="SMS.SMSUsers.Reports.AttendanceReportPast" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid1" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                        <telerik:AjaxUpdatedControl ControlID="panelgrid2" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>


    
 <div class="divHeader">
            <span class="pageTitle">Attendance Report</span>
        </div>
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    <%--<li>
                        <asp:LinkButton ID="imgview" runat="server" CausesValidation="false" >
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="View"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                     <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImgView_Click">
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
           
                       <%-- <asp:UpdatePanel ID="updateReport" runat="server">
                            <ContentTemplate>--%>
                            <asp:Panel ID="panelgrid1" runat="server">
                                <telerik:RadGrid ID="gvItemTable" runat="server" CssClass="RadGrid" GridLines="None"
                                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                    AllowFilteringByColumn="true">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="checkout_id">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                                AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelectionCheckOut"
                                                        AutoPostBack="True" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="checkin_time" HeaderText="In Time" DataField="checkin_time"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="checkout_time" HeaderText="Out Time" DataField="checkout_time"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="NRICno" HeaderText="NRIC No" DataField="NRICno"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn UniqueName="ln" HeaderText="Location" DataField="ln"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="user_name" HeaderText="Name" DataField="user_name"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pass_no" HeaderText="Pass No." DataField="pass_no"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="key_no" HeaderText="Key No." DataField="key_no"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                </telerik:RadGrid>
                       <%--     </ContentTemplate>
                        </asp:UpdatePanel>--%>

                        </asp:Panel>
                    
                    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                            <asp:Panel ID="panelgrid2" runat="server">
                                <telerik:RadGrid ID="gvCheckin" runat="server" CssClass="RadGrid" GridLines="None"
                                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                    AllowFilteringByColumn="true">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="checkin_id">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                                AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelectionCheckin"
                                                        AutoPostBack="True" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="Checkin_DateTime" HeaderText="In Time" DataField="Checkin_DateTime"  
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="NRICno" HeaderText="NRIC No" DataField="NRICno"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="user_name" HeaderText="Name" DataField="user_name"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pass_no" HeaderText="Pass No." DataField="pass_no"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="key_no" HeaderText="Key No." DataField="key_no"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                               <telerik:GridBoundColumn UniqueName="Location_name" HeaderText="Location" DataField="Location_name"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                </telerik:RadGrid>
                         <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </asp:Panel>
                  
         <br />
                <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                    <tr>
                        <td>
                            <asp:Label ID="exportto" runat="server" CssClass="Labels" Font-Bold="true" 
                                Text="Export To:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Labels" 
                                Width="81px">
                                <asp:ListItem>Pdf</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                            </asp:DropDownList>
                     
                            <asp:Button ID="btnGo" runat="server" CssClass="Button" OnClick="btnGo_Click" Text="Go" style="margin-left:20px"
                               Height="25px" Width="68px" />
                        </td>
                        </tr>
                    
                     
                </table>
               
              </center>
            </div>


        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />

        <asp:ModalPopupExtender ID="ModalPopupCheckinView" runat="server" CancelControlID="btnCheckinCancel"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlCheckinView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlCheckinView" runat="server" BackColor="White" Style="height:350px;
            width: 730px; margin-top: -15px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                   <center>
                   <asp:Panel ID="printview" runat="server" BackColor="White"> 
                            <table width="700px">
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Label ID="lblIncidentReport" Text="Attendance Report" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtlocation" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblchkIn" CssClass="Labels" runat="server" Text="Check In Time"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtChkIn" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtNRIC" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPassNo" CssClass="Labels" runat="server" Text="Pass No." Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPassNo" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblKeyNo" CssClass="Labels" runat="server" Text="Key No." Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtKeyNo" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                             
                                   
                            </table>
                             </asp:Panel>
                             <br />
                            
                            <div style="background-color: #E4E4E4; width:700px" >
                      
                          <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>


                                            <asp:Button ID="btnCheckinCancel" runat="server" Text="Cancel" CssClass="Button" Font-Bold="True"
                                            Height="30px" Width="100px" OnClick="btnCheckinCancel_Click" />
                                    </div></center>
                           
                       
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:ModalPopupExtender ID="ModalPopupCheckOutView" runat="server" CancelControlID="btnCheckOutCancel"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlCheckOutView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlCheckOutView" runat="server" BackColor="White" Style="height:350px;
            width: 730px; margin-top: -15px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait2" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait2" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                     <center>
                         <asp:Panel ID="printview1" runat="server" BackColor="White"> 
                            <table width="700px">
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Image runat="server" ID="image2" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black" />
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="4">
                                    <center>
                                        <asp:Label ID="Label1" Text="Attendance Report" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="chkoutlblNam" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                       
                                        <asp:Label ID="chkoutlblName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Check In Time"></asp:Label>
                                    </td>
                                    <td>
                                      
                                        <asp:Label ID="chkoutlblTime" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblchkOut" CssClass="Labels" runat="server" Text="Check Out Time"></asp:Label>
                                    </td>
                                    <td>
                                       
                                        <asp:Label ID="txtChkOut" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                <td>
                                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Total Hours"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalHours" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                                    </td>
                                    <td>
                                       
                                        <asp:Label ID="chkoutlblNRIC" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                             
                                    
                                </table>
                                </asp:Panel>
                                <br />
                             
                                <div style="background-color: #E4E4E4; width:700px" >
                      
                          <a id="A1" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                                  <asp:Button ID="btnCheckOutCancel" runat="server" Text="Cancel" CssClass="Button" Font-Bold="True"
                                            Height="30px" Width="100px" OnClick="btnCheckOutCancel_Click" />

                                      
                               </div>
                                 </center>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="lnkDelete"
            CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" Height="200px" Width="320px"
            BorderWidth="2px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress5" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait5" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait5" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <center>
                        <br />
                        <div>
                            <table width="290px" style="height: 170px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDeleteMsg" runat="server" Text="Are You Sure To Delete Record ?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" OnClick="btnCancelDelete_Click"
                                                CssClass="Button" Style="margin-left: 10px" Height="30px" Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
