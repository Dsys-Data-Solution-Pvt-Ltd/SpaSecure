<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminClientVisitMinutes.aspx.cs" Inherits="SMS.SuperVisor.AdminClientVisitMinutes" %>

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

    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Admin Client Visit Minutes</span></div>
        <div class="btnbar" style="margin-top: 20px">
            <div class="btnbarBox">
                <ul>
                    <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    
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
        <div id="divAdvSearch" runat="server" visible="false">
            <div>
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
            <br />
            <asp:Panel runat="server" ID="Pnl" BackColor="White" Style="margin-left: 1.5em; margin-top: 0px;"
                Font-Bold="True" Width="740px">
                <table width="740px" class="table">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                            </asp:DropDownList>
                            <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblcompletedby" Text="Completed By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtcompletedby" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                        <td>
                            <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                            <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                class="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table width="740px" style="margin-left: 1.5em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnSearchPassAdd_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Clear" runat="server"
                            CssClass="Buttons" Width="85px" OnClick="btnClearPassAdd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <div id="content" runat="server">
        </div>
        <br />
        <asp:Panel ID="Panelgrid" runat="server" >
        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadGrid ID="gvPassTable1" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="strCVID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="Location" HeaderText="Location" DataField="Location"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CompletedBy" DataField="CompletedBy" HeaderText="Completed By"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
            CancelControlID="btnCancelCStaff" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" ScrollBars="Vertical" BackColor="White" Height="600px"
            Width="700px" Style="display: none;">
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
                        <table width="650px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocationAdd" runat="server" CssClass="Input" Width="130px">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" Text="Completed By" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompletedByAdd" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdatefromAdd" CssClass="Input" runat="server" Width="200px"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtdatefromAdd" PopupButtonID="ImageButton1" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMetwith" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClientName" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    1) COMPLAINTS/ ABSENTEEISM
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtcomplaints" runat="server" CssClass="Input" Width="600px" Height="55px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    2) POSITIVE COMMENTS
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtpositivecomments" runat="server" CssClass="Input" Width="600px"
                                        Height="55px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    3) DEPLOYMENT/ OTHER CHANGES
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtdeployment" runat="server" CssClass="Input" Width="600px" Height="55px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    4) UP-COMING EVENTS
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtupcomingevent" runat="server" CssClass="Input" Width="600px"
                                        Height="55px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    5) REMARKS
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtremarks" runat="server" CssClass="Input" Width="600px" Height="60px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                <center>
                                    <asp:Button ID="btnAssignmentAdd" runat="server" Text="Add" CssClass="Button" Height="30px"
                                        Width="100px" OnClick="btnAssignmentAdd_Click" />
                                    <asp:Button ID="btnClear" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="btnClear_Click" />
                                        </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" ScrollBars="Vertical" runat="server" BackColor="White"
            Height="600px" Width="750px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
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
                        <asp:Panel ID="printview" runat="server">
                            <table width="690px">
                                <tr>
                                    <td colspan="4" style="height: 90px;" >
                                    <center>
                                        <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                        <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="2">
                                    <center>
                                        <asp:Label ID="lblIncidentReport" Text="Client Visit Minutes Reports" CssClass="Labels"
                                            runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAssignmentView" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="ddlocationView" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblcompletedbyView" Text="Completed By" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtcompletedbyView" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldatefromView" CssClass="Labels" runat="server" Text="Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtdatefromView" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMetwithView" Text="Client Name" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtClientNameView" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        1) COMPLAINTS/ ABSENTEEISM
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="50px" valign="top">
                                        <asp:Label ID="txtcomplaintsView" Text="" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        2) POSITIVE COMMENTS
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="50px" valign="top">
                                        <asp:Label ID="txtpositivecommentsView" Text="" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        3) DEPLOYMENT/ OTHER CHANGES
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="50px" valign="top">
                                        <asp:Label ID="txtdeploymentView" Text="" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        4) UP-COMING EVENTS
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="50px" valign="top">
                                        <asp:Label ID="txtupcomingeventView" Text="" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        5) REMARKS
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="55" valign="top">
                                        <asp:Label ID="txtremarksView" Text="" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                </tr>
                               
                            </table>
                        </asp:Panel>
                        <br />
                         <div style=" background-color: #E4E4E4; width:630px;padding:7px 30px 7px 30px">
                    <center>
                    <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                               <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="100px"
                                    Height="30px" OnClick="btnprint_Click" CausesValidation="false" OnClientClick="javascript:PrintGridData();" />--%>
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
        <div style="margin-left: 1.5em; width: 750px">
            <asp:GridView ID="gvPassTable" runat="server" AllowPaging="True" AllowSorting="True"
                Visible="false" AutoGenerateColumns="False" CellPadding="5" Width="740px" OnRowDataBound="gvPass_RowDataBound"
                OnRowCommand="gvPass_RowCommand" CssClass="GridMain2" PageSize="100">
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
                    <asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>
                    <asp:BoundField DataField="CompletedBy" HeaderText="Completed By"></asp:BoundField>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.strCVID") %>'
                                CommandName="View" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.strCVID") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="table" id="add0" runat="server" visible="false">
            <table width="740px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnNewPass" Text="Add New Client Visit Minutes" runat="server" CssClass="Buttons"
                            OnClick="btnNewPass_Click" Width="275px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
