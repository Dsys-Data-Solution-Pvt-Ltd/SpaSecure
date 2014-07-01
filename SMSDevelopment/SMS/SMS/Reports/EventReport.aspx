<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="EventReport.aspx.cs" Inherits="SMS.Reports.EventReport" %>

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
   
        <div class="divHeader">
            <span class="pageTitle">Event Report</span>
        </div>
        <div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                   <%-- <li>
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
        <asp:Panel runat="server" ID="Pnl" BackColor="White" Visible="false" Style="margin-left: 1.5em;
            margin-top: 0px;" Font-Bold="True" Width="750px">
            <table width="750px" class="table">
                <tr>
                    <td style="width: 148px">
                        <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 88px">
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px"
                            Style="margin-left: -0.2em" ForeColor="Black">
                        </asp:DropDownList>
                        <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbleventtype" CssClass="Labels" runat="server" Text="EventType"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" CssClass="Labels" runat="server" Width="130px"
                            Style="margin-left: -0.2em" ForeColor="#000099">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="DateFrom"></asp:Label>
                    </td>
                    <td style="width: 88px">
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"
                            Height="21px" Width="127px"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate2_Click" class="calender" />
                    </td>
                    <td>
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" OnTextChanged="txtdateto_TextChanged"
                            Height="21px" Width="126px"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate3_Click" class="calender" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblpersonincharg" CssClass="Labels" runat="server" Text="PersonInCharge"></asp:Label>
                    </td>
                    <td style="width: 88px">
                        <asp:TextBox ID="txtpersonincharg" CssClass="Input" runat="server" OnTextChanged="txtpersonincharg_TextChanged"
                            Height="18px" Width="129px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="50px" style="width: 148px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div class="clear">
        </div>
        <div id="content" runat="server">
        </div>
        <br />
       <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
                <asp:Panel ID="panelgrid" runat="server">
                <telerik:RadGrid ID="gvItemTable1" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Event_ID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Date_From" HeaderText="Start Date" DataField="Date_From"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Date_To" DataField="Date_To" HeaderText="End Date"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Start_time" DataField="Start_time" HeaderText="Start Time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="End_time" DataField="End_time" HeaderText="End Time"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Event_Type" DataField="Event_Type" HeaderText="Event Type"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Incharg_Name" DataField="Incharg_Name" HeaderText="Person Incharge"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
         <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>

        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate"  runat="server" ScrollBars="Vertical" BackColor="White"
            Height="600px" Width="750px" Style="display: none">
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
                        <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em"
                            Font-Bold="True">
                            <table width="100%" cellspacing="8">
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
                                        <asp:Label ID="lblIncidentReport" Text="Event Report" CssClass="Labels" runat="server"
                                            Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                    </td>
                                  <td colspan="3">
                                        <asp:Label ID="txtlocation" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblgaurdreq" CssClass="Labels" runat="server" Text="Number of Guards Required "></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtNoOfGuard" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblspecialreq" CssClass="Labels" runat="server" Text="Special Requirement"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtSpecialReg" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldutyforgaurd" CssClass="Labels" runat="server" Text="Any Special Duty for Guards"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="txtSpecialDuty" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Date" CssClass="Labels" runat="server" Text="Date :   From"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtFromDate" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Dateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtTodate" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text=" Start Time"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtStartTime" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEventend" CssClass="Labels" runat="server" Text="End Time"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtEndTime" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                                    </td>
                                 <td colspan="3">
                                        <asp:Label ID="txtEventType" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblEventComment" runat="server" Text="Comments" CssClass="Labels"></asp:Label>
                                    </td>
                                   <td colspan="3">
                                        <asp:Label ID="txtComment" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblperson" CssClass="Labels" runat="server" Text="Person In Charge: Contact Details"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEnternpir" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPersonNRIC" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPersonName" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPersonContNo" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPersonPosition" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblsuperior" CssClass="Labels" runat="server" Text="Created By :"></asp:Label>
                                    </td>
                                <td colspan="3">
                                        <asp:Label ID="txtSuperior" runat="server" CssClass="Labels"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <div style="background-color: #E4E4E4; width:710px">
                            <center>
                                <a id="print" href="printpage.aspx" class="Button" runat="server" target="_blank"
                                    style="height: 30px; width: 100px; color: White; padding: 7px 30px 7px 30px">Print</a>
                                <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                    Text="Cancel" OnClick="BtnCancelPrint_Click" />
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
                                        Are you sure to Delete the record!
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
        <table id="tblsearch" runat="server" visible="false" width="750px" style="margin-left: 1.4em;
            margin-bottom: -0.4em; border: 1px; border-style: groove; border-color: Black;
            background-color: Gray">
            <tr>
                <td colspan="4" align="center" style="width: 750px">
                    <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch_Click"
                        Width="85px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                        OnClick="btnclear_Click" />
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:Panel ID="panel1" runat="server" Visible="false" Width="750px" Style="margin-left: 1.2em">
                <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" Width="750px" HeaderStyle-HorizontalAlign="Center"
                    OnRowDataBound="gvItem_RowDataBound" OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging"
                    OnSelectedIndexChanged="gvItemTable_SelectedIndexChanged" PageSize="5">
                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                    <RowStyle CssClass="NormalRow" />
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server"></asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                        <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
                        <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                        <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
                        <asp:BoundField DataField="Event_Type" HeaderText="Event Type"></asp:BoundField>
                        <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>'
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
        <div style="background-color: #E4E4E4; width: 100%">
            <center>
                <table style="background-color: #E4E4E4; width: 50%;">
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
                            <asp:Button ID="btnGo" CssClass="Button" Height="30px" Width="100px" runat="server"
                                Text="Go" OnClick="btnGo_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="85px"
                                Visible="False" />
                        </td>
                        <td>
                            <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="85px"
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <br />
  
</asp:Content>
