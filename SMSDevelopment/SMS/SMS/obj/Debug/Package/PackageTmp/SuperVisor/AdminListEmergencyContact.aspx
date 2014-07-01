<%@ Page Language="C#" MasterPageFile="~/master/Spamaster.Master" AutoEventWireup="true"
    CodeBehind="AdminListEmergencyContact.aspx.cs" Inherits="SMS.SuperVisor.AdminListEmergencyContact" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Emergency Contact Number</span>
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
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                        <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                            Delete </span>
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
                <telerik:RadGrid ID="gvPassTable" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Emg_id">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="name" DataField="name" HeaderText="Name"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Position" DataField="Position" HeaderText="Position"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Mobile_No" DataField="Mobile_No" HeaderText="Mobile No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Office_No" DataField="Office_No" HeaderText="Office No." CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Home_No" DataField="Home_No" HeaderText="Home No."
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                          <%--  <telerik:GridBoundColumn UniqueName="Company" DataField="Company" HeaderText="Company"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="Extension" DataField="Extension" HeaderText="Extension"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ln" HeaderText="Location" DataField="ln"
                                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    </telerik:GridBoundColumn>
                           
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
            </asp:Panel>


        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
            CancelControlID="btnClearPassAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Height="420px" Width="400px"
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
                        <table width="350PX">
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblAssignmentid" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="175px">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="Label2" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="Label3" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblmobileno" Text="Mobile No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmobileno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblofficeno" Text="Office No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtofficeno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblhomeno" Text="Home No." CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthomeno" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblgrade" Text="Extension" CssClass="Labels" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGrade" runat="server" CssClass="Input" Width="175px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <center>
                         <asp:Button ID="btnSearchPassAdd" Text="Add" runat="server" CssClass="Button" Width="85px"
                                    OnClick="btnSearchPassAdd_Click" />
                                <asp:Button ID="btnClearPassAdd" Text="Cancel" runat="server"
                                    CssClass="Button" Width="85px" OnClick="btnClearPassAdd_Click" />
                                    </center>
                        </td>
                    </tr>
                   
                </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnUpdate" runat="server" />
       
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
        </div>
        <br />
      <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:40%;" >
                    <tr>
                        <td>
                            <asp:Label ID="exportto" runat="server" CssClass="Labels" Font-Bold="true" ForeColor="#000099"
                                Text="Export To:"></asp:Label>
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
                            <asp:Button ID="btnGo" runat="server" CssClass="Button" OnClick="btnGo_Click" Text="Go"
                                Width="60px" />
                        </td>
                    </tr>
                </table>
                </center>
                </div>
               
























      <%--  <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>--%>
     <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="Searchid1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Panel runat="server" ID="Panel1" BackColor="White" Style="margin-left: 1.5em"
            Font-Bold="True" Width="750px" Visible="false">
            <table width="750px">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddllocation1" runat="server" CssClass="Labels" ForeColor="Black">
                        </asp:DropDownList>
                        <%--<asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtname1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblposition" CssClass="Labels" runat="server" Text="Position"></asp:Label>
                    </td>
                    <td style="width: 600px">
                        <asp:TextBox ID="txtposition1" CssClass="Input" runat="server" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblmobile" CssClass="Labels" runat="server" Text="Mobile No."></asp:Label>
                    </td>
                    <td style="width: 400px">
                        <asp:TextBox ID="txtmobile" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="lbloffice" CssClass="Labels" runat="server" Text="Office No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtoffice" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date: From"></asp:Label>
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
                    <td height="20px">
                    </td>
                </tr>
            </table>
            <table width="100%" style="margin-left: 0.01em; margin-bottom: -0.4em; border: 1px;
                border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td align="Center" colspan="4">
                        <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" Text="Search" Width="85px"
                            OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnclear" CssClass="Buttons" runat="server" Text="Clear" Width="85px"
                            OnClick="btnclear_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
     
        <%--<div style="width: 750px; margin-left: 1.5em">
            <asp:GridView ID="gvPassTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvPass_RowDataBound"
                OnRowCommand="gvPass_RowCommand" OnPageIndexChanging="gvPass_PageIndexChanging"
                CssClass="GridMain2" OnSelectedIndexChanged="gvPassTable_SelectedIndexChanged"
                PageSize="100">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="There are no records in the system." runat="server"></asp:Label>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
                    <asp:BoundField DataField="Position" HeaderText="Position"></asp:BoundField>
                    <asp:BoundField DataField="Mobile_No" HeaderText="Mobile No."></asp:BoundField>
                    <asp:BoundField DataField="Office_No" HeaderText="Office No."></asp:BoundField>
                    <asp:BoundField DataField="Home_No" HeaderText="Home No."></asp:BoundField>
                    <asp:BoundField DataField="Extension" HeaderText="Extension"></asp:BoundField>
                    <%--   <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Emg_id") %>' CommandName="View" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>                         
                       <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Emg_id") %>' CommandName="EditRow" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Emg_id") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
      
        <div>
            <asp:Panel runat="server" ID="Pnl2" BackColor="White" Style="margin-left: 1.5em"
                Font-Bold="True" Width="750" Visible="false">
                <table width="100%" style="margin-left: 0.1em; margin-bottom: -0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                        <td colspan="4" align="center" style="width: 750px">
                            <asp:Button ID="btnAddnewIncident" runat="server" Text="Add New Emergency Contact"
                                CssClass="Buttons" Width="285px" OnClick="btnAddnewIncident_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                
            </asp:Panel>
        </div>

        
     
    </div>
</asp:Content>
