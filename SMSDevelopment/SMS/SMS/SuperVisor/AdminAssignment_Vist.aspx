<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminAssignment_Vist.aspx.cs" Inherits="SMS.SuperVisor.AdminAssignment_Vist" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">

    function PrintGridData() {
        var prtGrid = document.getElementById('<%=tblview.ClientID %>');

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
    <div class="divContainerForCR">
        <div class="divHeader">
            <span class="pageTitle">Admin Site Visit</span></div>
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
        <br />
        <asp:Panel ID="Panelgrid" runat="server" >
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
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="intID">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="strNameOfAssignment" DataField="strNameOfAssignment" HeaderText="Location"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="strSubmittedBy" DataField="strSubmittedBy" HeaderText="Submitted By"
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
        <asp:Panel ID="pnlAdd" runat="server" ScrollBars="Vertical" BackColor="White" Height="600px" Width="750px"
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
                         <table width="700px">
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblNameofAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTo" Text="To" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsubmittedby" Text="Submitted By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtsubmittedby" runat="server" CssClass="Input" Width="500px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNric" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtnric" runat="server" CssClass="Input" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Date of Visit"></asp:Label>
                        </td>
                         <td colspan="2">
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="ImageButton1" />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text="Time"></asp:Label>
                        </td>
                         <td colspan="2">
                            <MKB:TimeSelector ID="TimeSelector1" runat="server" SelectedTimeFormat="TwentyFour"
                                AllowSecondEditing="True" DisplaySeconds="False" MinuteIncrement="1" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblheadingDetail" Text="DETAILS OF REPORT" CssClass="Labels" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MANPOWER NAMES
                        </td>
                        <td>
                            a) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtIC" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard1" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Supervisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard2" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            d) Security Officer1
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard3" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            e) Security Officer2
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard4" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            f) Security Officer3
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard5" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            g) Security Officer4
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard6" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            h) Security Officer5
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard7" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            i) Security Officer6
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard8" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            j) Security Officer7
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard9" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            k) Security Officer8
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard10" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DISCIPLINE
                        </td>
                        <td>
                            a) Dressing
                        </td>
                        <td>
                            <asp:TextBox ID="txtdressing" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Appearance
                        </td>
                        <td>
                            <asp:TextBox ID="txtappearance" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Haircut
                        </td>
                        <td>
                            <asp:TextBox ID="txthaircut" runat="server" CssClass="Input" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ALERTNESS
                        </td>
                        <td>
                            <asp:DropDownList ID="ddrAlertness" runat="server" CssClass="Input" Width="100px">
                             
                                <asp:ListItem>Good</asp:ListItem>
                                <asp:ListItem>Fair</asp:ListItem>
                                <asp:ListItem>Poor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DEPLOYMENT
                        </td>
                       <td colspan="2">
                            <asp:DropDownList ID="ddrDeployment" runat="server" CssClass="Input" Width="100px">
                             
                                <asp:ListItem>Coorect</asp:ListItem>
                                <asp:ListItem>Incorrect</asp:ListItem>
                                <asp:ListItem>Disorder</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            GENERAL PERFORMANCE
                        </td>
                       <td colspan="2">
                            <asp:DropDownList ID="ddrgeneralPerformance" runat="server" CssClass="Input" Width="100px">
                              
                                <asp:ListItem>Good</asp:ListItem>
                                <asp:ListItem>Average</asp:ListItem>
                                <asp:ListItem>Satisfactory</asp:ListItem>
                                <asp:ListItem>Poor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            OTHER MATTERS
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtotherMatters" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CONCLUSION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtconclustion" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            RECOMMENDATION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtrecommendation" runat="server" CssClass="Input" Width="500px"
                                Height="76px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                         <td colspan="3">
                         <center>
                         <asp:Button ID="btnAssignmentAdd" Text="ADD" runat="server" CssClass="Button" Width="85px"
                                OnClick="btnAssignmentAdd_Click" CausesValidation="false" />
                            <asp:Button ID="btnClear" Text="Cancel" runat="server" CssClass="Button"
                                Width="85px" OnClick="btnClear_Click" CausesValidation="false"/>
                                </center>
                        </td>
                    </tr>
                </table>
               
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
        <asp:HiddenField ID="hdnView" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupView" runat="server" TargetControlID="hdnView"
            CancelControlID="btnCancelView" BackgroundCssClass="modalBackground" PopupControlID="pnlView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" BackColor="White" ScrollBars="Vertical" Height="600px" Width="750px"
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
                        <table width="700px" id="tblview" runat="server" >
                <tr>
                <td colspan="4" style=" height:90px;">
                <center>
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black; width:650px"></hr></center>
                </td>
                </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="TO" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtToView" runat="server" CssClass="Input" Width="500px" 
                                Visible="False">a</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" Text="SUBMITTED BY" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtsubmittedbyView" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" Text="NAME OF ASSIGNMENT" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtNameofAssignmentView" runat="server" CssClass="Input" Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="DATE / TIME OF VISIT"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="txtdateofvisitView" runat="server" CssClass="Reportcolor"></asp:Label>
                            <%--<AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>--%>
                        </td>
                    </tr>
                   
                    <tr>
                         <td colspan="3">
                            <asp:Label ID="Label7" Text="DETAILS OF REPORT" CssClass="Labels" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MANPOWER NAMES
                        </td>
                        <td>
                            a) SuperVisor
                        </td>
                        <td>
                            <asp:TextBox ID="txtICView" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Guard 1.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard1View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Guard 2.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard2View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            d) Guard 3.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard3View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            e) Guard 4.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard4View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            f) Guard 5.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard5View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            g) Guard 6.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard6View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            h) Guard 7.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard7View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            i) Guard 8.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard8View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            j) Guard 9.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard9View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            k) Guard 10.
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuard10View" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DISCIPLINE
                        </td>
                        <td>
                            a) Dressing
                        </td>
                        <td>
                            <asp:TextBox ID="txtdressingView" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            b) Appearance
                        </td>
                        <td>
                            <asp:TextBox ID="txtappearanceView" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            c) Haircut
                        </td>
                        <td>
                            <asp:TextBox ID="txthaircutView" runat="server" CssClass="Input" Width="345px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ALERTNESS
                        </td>
                        <td colspan="2">
                            <asp:Label ID="txtAlertnessView" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DEPLOYMENT
                        </td>
                        <td colspan="2">
                            <asp:Label ID="txtDeploymentView" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            GENERAL PERFORMANCE
                        </td>
                        <td>
                            <asp:Label ID="txtgeneralPerformanceView" runat="server" Text="" CssClass="Reportcolor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            OTHER MATTERS
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtotherMattersView" runat="server" CssClass="Input" Width="500px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CONCLUSTION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtconclustionView" runat="server" CssClass="Input" Width="500px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            RECOMMENDATION
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtrecommendationView" runat="server" CssClass="Input" Width="500px"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                   
                </table>
                 <br />
                 <div style="width:640px;padding:7px 30px 7px 30px">
                    <center>
                    <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                    <%-- <asp:Button ID="Button1" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="30px" Font-Bold="True" CausesValidation="false" OnClientClick="javascript:PrintGridData();" />--%>

                                <asp:Button ID="btnCancelView" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="btnCancelView_Click" CausesValidation="false" />
                    </center>
                    </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
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
                            <asp:Label ID="lblAssignmentid" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation111" runat="server" CssClass="Labels">
                            </asp:DropDownList>
                            <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblsubmitedBy" Text="Submitted By" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsubmitedBy" runat="server" CssClass="Input" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdatefrom1" CssClass="Input" runat="server"></asp:TextBox>
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
            <table width="740px" style="margin-left: 1.4em; margin-bottom: -0.4em; border: 1px;
                border-style:groove; border-color:Black; background: url(../Images/1397d40aa687.jpg)">
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
        <br />
        <%--<div style=" margin-left:1.5em; width:750px">
            <asp:GridView ID="gvPassTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="745px" OnRowDataBound="gvPass_RowDataBound"
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
                    <asp:BoundField DataField="strNameOfAssignment" HeaderText="Location"></asp:BoundField>
                    <asp:BoundField DataField="strSubmittedBy" HeaderText="Submitted By"></asp:BoundField>
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.intID") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.intID") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
        <br />
       
            <%--<table width="745px" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnNewPass" Text="Add New Site Visit" runat="server" CssClass="Buttons"
                            OnClick="btnNewPass_Click" />
                    </td>
                </tr>
            </table>--%>
       
        <br />
    </div>
</asp:Content>
