<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true" CodeBehind="OM_CheckInReport.aspx.cs" Inherits="SMS.SMSUsers.Reports.OM_visitReport" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>

<div class="divContainer">
<div class="divHeader">
            <span class="pageTitle"> Operation Manager Visit Report</span>
        </div>
<div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                    <%--<li>
                        <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="View"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                Delete </span>
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
        
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <%-- </ContentTemplate>        
        </asp:UpdatePanel>--%>
        <asp:panel runat="server" ID="Pnl" BackColor="White" Visible="false"
                            style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True"  Width="750px">
            <table width="750px" class="table">   
            <tr>
                <td>
                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px" style="margin-left:0.3em"
                        OnSelectedIndexChanged="ddllocation_SelectedIndexChanged" class="Lable2">
                    </asp:DropDownList>
                    
                </td>
                <td>
                    <asp:Label ID="Label1nricno" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnricno" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="passtype" CssClass="Labels" runat="server" Text="Pass No." Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpasstype" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="keyno" CssClass="Labels" runat="server" Text="Key No." Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtkeyno" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="date" CssClass="Labels" runat="server" Text="DateFrom"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                    <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                </td>
                <td>
                    <asp:Label ID="dateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                    <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                         class="calender"/>
                </td>
                <td>
                    <asp:Label ID="vehicleno" CssClass="Labels" runat="server" Text="VehicleNo." Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvehicleno" CssClass="Input" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                    <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="OM Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="50px">
                    <asp:TextBox ID="txtrole" runat="server" Visible="False" Width="25px">Operations Manager</asp:TextBox>
                <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            </table>
        </asp:panel>
            <table id="tablebtn" runat="server" visible="false"  width="750px" style="margin-left:1.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black; background-color:Gray">

                                            <tr>
                                                <td colspan="4" align="center" style="width: 750px">
                    <asp:Button ID="Button1" CssClass="Buttons" runat="server" Text="Search" Width="85px"
                        OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                        OnClick="btnclear_Click" />
                </td>
            </tr>
            </table>
        
        <div>
        <div class="clear">
        </div>
        <div id="content" runat="server">
        </div>
        <br />
    <%--    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
                 <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvItemTable1" runat="server" CssClass="RadGrid" GridLines="None"
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
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="checkin_time" HeaderText="In Time" DataField="checkin_time" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>                            
                            <telerik:GridBoundColumn UniqueName="NRICno" DataField="NRICno" HeaderText="NRIC No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="user_name" DataField="user_name" HeaderText="OM Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="LocationID" DataField="LocationID" HeaderText="Loc.To Visit"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>                            
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" ScrollBars="Vertical" runat="server" BackColor="White"
            Height="550px" Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait83" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait83" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                    <asp:Panel ID="printview" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True">
                <table width="100%" cellspacing="10px">
                <tr>
            <td  colspan="4">
            <center>
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                   </center>
             </td>
            </tr>
                    <tr>
                        <td colspan="4">
                        <center>
                            <asp:Label ID="lblIncidentReport" Text="OM Visit Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </center>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInTime" Text="In Time" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            : <asp:Label ID="txtInTime" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblNameView" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtnameView" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtNRIC" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblToVisit" Text="To Visit Loc." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtToVisit" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblRemark" Text="Remarks" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="35" valign="top">
                           : <asp:Label ID="txtRemark" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                  
                </table>
            </asp:Panel>
            <br />
             <div style="background-color: #E4E4E4;">
                            <center>
                            
                            <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                               <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="100px"
                                    Height="30px" OnClick="btnprint_Click" CausesValidation="false" OnClientClick="javascript:PrintGridData();" />--%>
                                <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                    Text="Cancel" OnClick="BtnCancelPrint_Click" />
                            </center>
                        </div>
            <%--<div align="center">
              <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1.5em">    

                <asp:Button ID="Button2" runat="server" Text="Print" CssClass="Buttons" Font-Bold="True"
                    Height="30px" Width="110px" OnClick="btnprint_Click" />
                    </asp:Panel>
                    </div>--%>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
       
        <asp:HiddenField ID="hdnCurr" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupCurr" runat="server" TargetControlID="hdnCurr"
            CancelControlID="btnCancelPrintCurr" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdateCurr">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdateCurr" ScrollBars="Vertical" runat="server" BackColor="White"
            Height="550px" Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgressCurr" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanelCurr">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait84" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait84" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanelCurr" runat="server">
                <ContentTemplate>
                    <center>
                    <asp:Panel ID="PrintViewCurr" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True">
                <table width="100%" cellspacing="10px">
                <tr>
            <td  colspan="4">
            <center>
                   <asp:Image runat="server" ID="image2" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                   </center>
             </td>
            </tr>
                    <tr>
                        <td colspan="4">
                        <center>
                            <asp:Label ID="Label1" Text="OM Visit Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInTimeCurr" Text="In Time" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                            : <asp:Label ID="txtInTimeViewCurr" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblNameViewCurr" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtNameViewCurr" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNRICViewCurr" Text="NRIC No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtNRICViewCurr" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblToVisitCurrView" Text="To Visit Loc." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3">
                           : <asp:Label ID="txtToVisitViewCurr" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblRemarkViewCurr" Text="Remarks" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="3" height="35" valign="top">
                           : <asp:Label ID="txtRemarkViewCurr" CssClass="Reportcolor" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                </table>                
            </asp:Panel>
            <br />
            <div style="background-color: #E4E4E4;">
                            <center>
                            
                            <a id="A1" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                               <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="100px"
                                    Height="30px" OnClick="btnprint_Click" CausesValidation="false" OnClientClick="javascript:PrintGridData();" />--%>
                                <asp:Button ID="btnCancelPrintCurr" CssClass="Button" Height="30px" Width="100px" runat="server"
                                    Text="Cancel" OnClick="BtnCancelPrintCurr_Click" />
                            </center>
                        </div>
                     </center>
                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:Panel>
        
        
        
        <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
            CancelControlID="btnCancelDelete" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
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
                                        Are you sure you want to delete the record!
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancelDelete" Text="No" runat="server" CausesValidation="false"
                                                OnClick="btnCancelDelete_Click" CssClass="Button" Style="margin-left: 10px" Height="30px"
                                                Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>



            <asp:Panel ID="panel1" runat="server" Visible="false" Width="750px" style="margin-left:1.3em">
                <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvItem_RowDataBound"
                    OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                     
                    OnSelectedIndexChanged="gvItemTable_SelectedIndexChanged" PageSize="5">
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
                        <asp:BoundField DataField="checkin_time" HeaderText="In Time"></asp:BoundField>
                       <%-- <asp:BoundField DataField="checkout_time" HeaderText="Out Time"></asp:BoundField>--%>
                        <asp:BoundField DataField="NRICno" HeaderText="NRIC No."></asp:BoundField>
                        <asp:BoundField DataField="user_name" HeaderText=" OM Name"></asp:BoundField>
                        <asp:BoundField DataField="LocationID" HeaderText="Loc.To Visit"></asp:BoundField>
                        <%--<asp:BoundField DataField="telephone" HeaderText="Phone No."></asp:BoundField>
                        <asp:BoundField DataField="pass_no" HeaderText="Pass No."></asp:BoundField>
                        <asp:BoundField DataField="company_from" HeaderText="Company From"></asp:BoundField>
                        <asp:BoundField DataField="to_visit" HeaderText="To Visit"></asp:BoundField>--%>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../../Images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.checkout_id") %>'
                                    CommandName="DeleteRow" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
       <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                <tr>
                    <td style="width: 111px">
                        <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"
                            Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                            Height="30px" Width="75px">
                            <asp:ListItem>Pdf</asp:ListItem>
                            <asp:ListItem>Word</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                    
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
        <br />
    </div>
</asp:Content>
