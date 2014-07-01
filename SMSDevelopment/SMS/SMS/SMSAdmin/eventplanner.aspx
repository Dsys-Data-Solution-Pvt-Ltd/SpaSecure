<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="eventplanner.aspx.cs" Inherits="SMS.SMSAdmin.eventplanneraspx" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">


     .RadCalendarPopup {

        z-index:500000000 !important;

    }

      .RadCalendarPopupShadows {

  
z-index: 5000000000 !important;


    }
        /*div[style] {
            z-index: 500000000 !important;
        }*/


        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
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
            <span class="pageTitle">Event Planner</span>
        </div>
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
                        <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgUpdate_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Edit"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                Delete </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <div id="divAdvSearch" runat="server" visible="false">
            <br />
            <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750">
                <table width="700" class="table">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="lblLocation1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                        </td>
                        <td style="width: 142px">
                            <asp:DropDownList ID="drlLocation" runat="server" CssClass="Labels" ForeColor="Black">
                            </asp:DropDownList>
                            <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                        </td>
                        <td align="left" style="width: 95px">
                            <asp:Label ID="lblEventType1" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                        </td>
                        <td style="width: 189px">
                            <asp:DropDownList ID="ddlEventType" runat="server" CssClass="Labels" ForeColor="Black">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 122px">
                            <asp:Label ID="lblpersonincharg" CssClass="Labels" runat="server" Text="Person In Charge"></asp:Label>
                        </td>
                        <td style="width: 142px">
                            <asp:TextBox ID="txtpersonincharg" CssClass="Input" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 95px">
                            <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                        </td>
                        <td style="width: 130px">
                            <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" Width="100px"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                            <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                CssClass="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                        </td>
                        <td style="width: 130px">
                            <asp:TextBox ID="txtdateto" runat="server" CssClass="Input" Width="100px"></asp:TextBox>
                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" PopupButtonID="imgBtnFromDate3" TargetControlID="txtdateto" />
                            <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                CssClass="calender" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                        </td>
                    </tr>
                </table>
                <table width="100%" style="margin-left: 0.01em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" OnClick="btnSearch1_Click"
                                Width="85px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCanel" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                                OnClick="btnCanel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
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
                <telerik:RadGrid ID="gvNewEventSearch1" runat="server" CssClass="RadGrid" GridLines="None"
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
                            <telerik:GridBoundColumn UniqueName="Date_From" DataFormatString="{0:MM/dd/yyyy}"
                                HeaderText="Start Date" DataField="Date_From" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Date_To" DataFormatString="{0:MM/dd/yyyy}" DataField="Date_To"
                                HeaderText="End Date" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                ShowFilterIcon="false">
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
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
             BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Height="600px" Width="750px"
            Style="display: none;">
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
                                    <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drlLocationAdd" runat="server" CssClass="Labels" ForeColor="Black"
                                        Width="170px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblgaurdreq" CssClass="Labels" runat="server" Text="Number of Guards Required "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtgaurdreq" CssClass="Input" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtgaurdreq"
                                        ErrorMessage="Please Enter Numeric Value!..." ValidationExpression="^\d+$" Font-Bold="True"
                                        Font-Size="17px" TabIndex="1"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblspecialreq" CssClass="Labels" runat="server" Text="Special Requirement"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtspecialreq" CssClass="Input" runat="server" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbldutyforgaurd" CssClass="Labels" runat="server" Text="Any Special Duty for Guards"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtdutygaurd" CssClass="Input" runat="server" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Date" CssClass="Labels" runat="server" Text="Date :   From"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFromDate" Text="" CssClass="Input" />
                                    <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                                    <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Dateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttoDate" CssClass="Input" runat="server"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="Calendar" runat="server" CssClass="AjaxCalendar" Format="MM/dd/yyyy"
                                        TargetControlID="txttoDate" PopupButtonID="imgBtnFromDate1" />
                                    <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text=" Start Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
<%--
                                    <telerik:RadTimePicker ID="RadTimePicker1" runat="server" ShowPopupOnFocus="true"> 
                                    <TimeView TimeFormat="hh:mm tt" Interval="00:01:00" > 
                                                </TimeView> 
                                   </telerik:RadTimePicker>--%>
                                </td>
                                <td>
                                    <asp:Label ID="lblEventend" CssClass="Labels" runat="server" Text="End Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="TimeSelector2" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="Twelve" AllowSecondEditing="true" DisplaySeconds="False" />
                                  <%--  <telerik:RadTimePicker ID="RadTimePicker2" runat="server" ShowPopupOnFocus="true"> 
                                    <TimeView TimeFormat="hh:mm tt" Interval="00:01:00" > 
                                                </TimeView> 
                                   </telerik:RadTimePicker>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbleventtype" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drlEventType" runat="server" CssClass="Labels" ForeColor="Black"
                                        Width="160px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbladdeventtype" CssClass="Labels" runat="server" Text="Add Event Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtaddeventtype" Text="" CssClass="Input" Width="130" />
                                    <asp:Button ID="cmdadd2" CssClass="Button" runat="server" Text="Add" Width="50px"
                                        Style="margin: -26px 0 0 140px;" OnClick="cmdadd2_Click" />
                                </td>
                            </tr>
                            <tr id="mmn0" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lblEventComment" runat="server" Text="Comments" CssClass="Labels"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEventComment" runat="server" CssClass="Input" Height="77px" Width="450px"
                                        TextMode="MultiLine"></asp:TextBox>
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
                                <telerik:RadComboBox ID="txtNricNo" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true" OnSelectedIndexChanged="txtStaffiD_TextChanged"
                                                        EnableVirtualScrolling="true" >
                                                    </telerik:RadComboBox>                                                    
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                                        SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>


                                    <%--<asp:TextBox ID="txtNricNo" CssClass="Input" runat="server" AutoPostBack="True" OnTextChanged="txtNricNo_TextChanged"
                                        Width="192px"></asp:TextBox>--%>
                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtname" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContact" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPosition" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblsuperior" CssClass="Labels" runat="server" Text="Created By :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="txtSupireorName" CssClass="Input" runat="server" Width="192px">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>

                                <td colspan="4">
                                <center>
                                    <asp:Button ID="btnAddVisitor" runat="server" Text="Add" OnClick="cmdbuttonadd_Click"
                                        CssClass="Button" Height="30px" Width="100px" />
                                    <asp:Button ID="btnCancelCStaff" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="cmdbuttonClear_Click" />
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
            BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
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
                        <table width="700px">
                            <tr>
                                <td colspan="4">
                                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drlLocationUpdate" runat="server" CssClass="Input" Width="160px">
                                        <asp:ListItem> </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtEventID" CssClass="Input" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                                </td>
                              
                           
                                <td>
                                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Number of Guards Required "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtgaurdreqUpdate" CssClass="Input" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Special Requirement"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtspecialreqUpdate" CssClass="Input" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Any Special Duty for Guards"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtdutygaurdUpdate" CssClass="Input" runat="server" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="Date :   From"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFromDateUpdate" Text="" CssClass="Input" />
                                    <AJAX:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDateUpdate" PopupButtonID="ImageButton1" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        Style="width: 16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="To"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ToDateUpdate" CssClass="Input" runat="server" Height="20px" Width="150px"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="ToDateUpdate" PopupButtonID="ImageButton2" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        Style="width: 16px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" CssClass="Labels" runat="server" Text=" Start Time"></asp:Label>
                                </td>
                                <td valign="top">
                                    <MKB:TimeSelector ID="TimeSelector3" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="Twelve" AllowSecondEditing="true" style=" vertical-align:top" />

                                    <%-- <telerik:RadTimePicker ID="RadTimePicker3" runat="server" ShowPopupOnFocus="true"> 
                                    <TimeView TimeFormat="hh:mm tt" Interval="00:01:00"  > 
                                                </TimeView> 
                                   </telerik:RadTimePicker>--%>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" CssClass="Labels" runat="server" Text="End Time"></asp:Label>
                                </td>
                                <td valign="top">

                                    <MKB:TimeSelector ID="TimeSelector4" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="Twelve" AllowSecondEditing="true" style=" vertical-align:top" />


                               <%--      <telerik:RadTimePicker ID="RadTimePicker4" runat="server"  ShowPopupOnFocus="true"> 
                                    <TimeView TimeFormat="hh:mm tt" Interval="00:01:00"  > 
                                                </TimeView> 
                                   </telerik:RadTimePicker>--%>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                                </td>
                                <td>
                                 <asp:TextBox ID="ddlEventTypeUpdate" runat="server" CssClass="Input" ></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddlEventTypeUpdate" runat="server" CssClass="Input" Width="126px">
                                    </asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr id="fsfs" runat="server" visible="false">
                                <td valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="Comments" CssClass="Labels"></asp:Label>
                                </td>
                                <td colspan="7" height="55">
                                    <asp:TextBox ID="txtCommentUpdate" runat="server" CssClass="Input" Height="74px"
                                        Width="435px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="style1">
                                    <asp:Label ID="Label11" CssClass="Labels" runat="server" Text="Person In Charge: Contact Details"
                                        Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                </td>
                                <td>
                                <telerik:RadComboBox ID="txtNricNoUpdate" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                                        EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                                        DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                                        EnableVirtualScrolling="true" >
                                                    </telerik:RadComboBox> 

                                    <%--<asp:TextBox ID="txtNricNoUpdate" CssClass="Input" runat="server" Width="192px"></asp:TextBox>--%>
                                </td>
                               
                                <td>
                                    <asp:Label ID="Label13" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNameUpdate" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" CssClass="Labels" runat="server" Text="Contact No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactUpdate" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                               
                                <td>
                                    <asp:Label ID="Label15" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPositionUpdate" CssClass="Input" runat="server" Width="192px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" CssClass="Labels" runat="server" Text="Created By :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="txtSupireorNameUpdate" runat="server" CssClass="Input" Width="192px">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                <center>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                        CssClass="Button" Height="30px" Width="100px" />
                                    <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="BtnCancelUpdate_Click" />
                                        <%--<asp:Button ID="Button1" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="BtnCancelUpdate_Click" />--%>
                                        </center>
                                        
                                </td>
                            </tr>
                        </table>
                        <%--<table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocationUpdate" runat="server" CssClass="Labels">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDateUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDateUpdate" PopupButtonID="Image1" />
                                    <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="Labels" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDateUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtToDateUpdate" PopupButtonID="Image2" />
                                    <asp:Image ID="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" CssClass="Labels" Text="Expected Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="tsExpectedTimeUpdate" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                                </td>
                               <td>
                                    <asp:Label ID="Label16" runat="server" CssClass="Labels" Text="Purpose"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpurposeUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNameUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" CssClass="Labels" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompanyUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPositionUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="Labels" Text="Vehicle Registration No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVechicleUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" CssClass=" Labels" Text="Invited By"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="txtInvitedByUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                          
                                <td>
                                    <asp:Label ID="Label18" runat="server" CssClass=" Labels" Text="Telephone"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="txttelephoneUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                        CssClass="Button" Height="30px" Width="100px" />
                                    <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="BtnCancelUpdate_Click" />
                                </td>
                            </tr>
                        </table>--%>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
             BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
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
        <div style="width: 750px; margin-left: 1.5em;">
            <asp:GridView ID="gvNewEventSearch" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvNewEvent_RowDataBound"
                OnRowCommand="gvNewEvent_RowCommand" OnPageIndexChanging="gvNewEvent_PageIndexChanging"
                PageSize="5">
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
                    <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                    <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
                    <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                    <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
                    <asp:BoundField DataField="Event_Type" HeaderText="Event Type"></asp:BoundField>
                    <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>'
                                CommandName="EditRow" runat="server" />
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
        </div>
        <br />
        <div class="table">
            <asp:Panel ID="pnn" Width="102%" runat="server" Style="margin-left: 0.1em; margin-bottom: -0.4em;
                border: 1px; border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <asp:Button ID="btnAddNewEvent" CssClass="Buttons" runat="server" Text="Add New Event"
                    Style="margin-left: 20em" OnClick="btnAddNewEvent_Click" />
            </asp:Panel>
        </div>
        <br />
    </div>
</asp:Content>
