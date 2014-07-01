<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="DigitalDairy.aspx.cs" Inherits="SMS.SMSUsers.DigitalDairy" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
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
    <div class="divHeader">
        <span class="pageTitle">Digital Diary</span>
    </div>
    <br />
    <div class="btnbar" style="margin-top: 20px">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                        <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                            <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="content" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <asp:Panel ID="Panelgrid" runat="server">
            <telerik:RadGrid ID="gvDiary" runat="server" CssClass="RadGrid" GridLines="None"
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
                        <telerik:GridBoundColumn UniqueName="CurrDate" DataField="CurrDate" HeaderText="Date"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="time" DataField="time" HeaderText="Time" CurrentFilterFunction="Contains"
                            AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Heading" DataField="Heading" HeaderText="Heading"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Staff_id" DataField="Staff_id" HeaderText="Name"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" HeaderText="Description"
                            ShowFilterIcon="false">
                            
                            <ItemTemplate>
                                <asp:Label ID="lblDescr" runat="server" Text='<%# GetDescription(Eval("Description").ToString()) %>'
                                    ForeColor='<%# GetColor(Eval("Color").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>
        </asp:Panel>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
            CancelControlID="btnCancelCStaff" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Height="380px" Width="750px"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress8" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait81" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait81" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="720px">
                            <tr>
                                <td>
                                    <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date" Visible="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" Visible="true"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                    <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        Visible="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblopenby0" CssClass="Labels" runat="server" Text="Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="tsFromTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblopenby4" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStaffName" CssClass="Input" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblopenby2" CssClass="Labels" runat="server" Text="Select Color"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtColor" runat="server" CssClass="Input" MaxLength="7" Width="80px"></asp:TextBox>
                                    &nbsp;
                                    <asp:Image ID="imgCP" runat="server" ImageUrl="~/Images/cp_button.png" />
                                    &nbsp;<input type="button" id="btnDemoColor" style="border: none; width: 17px; height: 17px" />
                                    <AJAX:ColorPickerExtender ID="ColorPickerExtender1" runat="server" TargetControlID="txtColor"
                                        SampleControlID="btnDemoColor" PopupButtonID="imgCP">
                                    </AJAX:ColorPickerExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblopenby5" CssClass="Labels" runat="server" Text="Heading"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpHeading" runat="server" CssClass="Input" Width="190px" Height="32px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtnewHeading" CssClass="Input" runat="server" Width="225px" Height="22px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnaddnewHeading" runat="server" Text="Add New Heading" CssClass="Button"
                                        OnClick="btnaddnewHeading_Click" Width="160px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblopenby3" CssClass="Labels" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Height="100px" TextMode="MultiLine"
                                        Width="85%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <asp:Button ID="btnIncidentAdd" runat="server" CssClass="Button" Text="Save" Width="85px"
                                            OnClick="btnIncidentAdd_Click" />
                                        <asp:Button ID="btnClear" runat="server" CssClass="Button" Text="Cancel" Width="75px"
                                            OnClick="btnClear_Click" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <%--<div style="margin-left: 1.5em; width: 750px">
            <asp:GridView ID="gvDiary" runat="server" AutoGenerateColumns="False" CellPadding="5"
                Width="750px" CssClass="GridMain2" PageSize="100">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    Diary is not opened for the day yet.
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="CurrDate" HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Heading" HeaderText="Heading" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Staff_id" HeaderText="Name" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle Width="150px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDescr" runat="server" Text='<%# GetDescription(Eval("Description").ToString()) %>'
                                ForeColor='<%# GetColor(Eval("Color").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
</asp:Content>
