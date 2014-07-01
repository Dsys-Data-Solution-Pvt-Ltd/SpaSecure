<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="LogSetting.aspx.cs" Inherits="SMS.ADMIN.LogSetting" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
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
            <span class="pageTitle">Log List Setting</span></div>
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
                                <asp:Label ID="spanUpdate" runat='server' Text="Update"></asp:Label></span>
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
                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Logid">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                    AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                            AutoPostBack="True" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="ID" DataField="ID" HeaderText="Type" CurrentFilterFunction="Contains"
                                    AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Description" DataField="Description" HeaderText="Description"
                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system."
                                    runat="server">
                                </asp:Label>
                                <p>
                                    Suggestions:</p>
                                <li>Try different keywords.</li>
                                <li>Try fewer keywords.</li>
                                <li>Make sure all words are spelled correctly.</li>
                                <li>There may be no records in the system.</li>
                            </NoRecordsTemplate>
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
            <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Height="180px" Width="500px"
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
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" Text="Type" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txttype" runat="server" CssClass="Input" Width="200px"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbltype" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdesc" runat="server" CssClass="Input" Width="330px" Height="29px" />
                                    </td>
                                    <tr>
                                      
                                            <td colspan="2">
                                            <center>
                                                <asp:Button ID="btnadd" Text="Add" runat="server" CssClass="Button" Width="85px"
                                                    OnClick="btnadd_Click" />
                                                     <asp:Button ID="btnCancelCStaff" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="btnCancelCStaff_Click" /></center>
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
            <asp:Panel ID="pnlUpdate" runat="server" BackColor="White" Height="150px" Width="530px"
                Style="display: none">
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
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblID" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtID" runat="server" CssClass="Input" Width="400px" />
                                    </td>
                                   </tr> <tr>
                                    <td colspan="2"><center>
                                        <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="Button" Width="85px"
                                            OnClick="btnUpdate_Click" />
                                             <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                        Text="Cancel" OnClick="BtnCancelUpdate_Click" /></center>
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
        </div>
        <%-- <asp:Label ID="searchid" runat="server" Visible="false"></asp:Label>
        <br />
        <div style="margin-left: 1.5em; width: 750px">
            <asp:GridView ID="gvPassTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvPass_RowDataBound"
                OnRowCommand="gvPass_RowCommand" CssClass="GridMain2" OnPageIndexChanging="gvPassTable_PageIndexChanging"
                OnSelectedIndexChanged="gvPassTable_SelectedIndexChanged" PageSize="20">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system."
                        runat="server">
                    </asp:Label>
                    <p>
                        Suggestions:</p>
                    <li>Try different keywords.</li>
                    <li>Try fewer keywords.</li>
                    <li>Make sure all words are spelled correctly.</li>
                    <li>There may be no records in the system.</li>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Type"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                    <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/True.gif" ID="btnadd" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Logid") %>'
                                CommandName="AddRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Logid") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Logid") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
    </div>
</asp:Content>
