<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="DigitalDairyReport.aspx.cs" Inherits="SMS.Reports.DigitalDairyReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        <span class="pageTitle">Digital Dairy Report</span>
    </div>
    <div class="btnbar">
        <div class="btnbarBox">
            <ul>
                <%--<li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>--%>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                        <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                            <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
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
        <asp:Panel ID="panelgrid" runat="server">
            <telerik:RadGrid ID="gvItemTable" runat="server" CssClass="RadGrid" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="DDID">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                    AutoPostBack="True" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="AddedTime" HeaderText="AddedTime" DataField="AddedTime"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="time" HeaderText="Leave Type" DataField="time"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Staff_id" HeaderText="Total Day" DataField="Staff_id"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Description" HeaderText="Description" DataField="Description"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn UniqueName="SuperiorName" HeaderText="Superior Name" DataField="SuperiorName"
                                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>--%>
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>
        </asp:Panel>
    </div>
    <br />
    <div style="background-color: #E4E4E4; width: 100%">
        <center>
            <table style="background-color: #E4E4E4; width: 50%;">
                <tr>
                    <td style="width: 124px">
                        <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To:" ForeColor="#000099"
                            Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                            Height="26px" Width="81px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>Pdf</asp:ListItem>
                            <asp:ListItem>Word</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnGo" CssClass="Button" runat="server" Text="Go" Width="60px" OnClick="btnGo_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <asp:HiddenField ID="hdnAdd" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="lnkDelete" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
        BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlAdd" runat="server" ScrollBars="Vertical" BackColor="White" Style="height: 620px;
        width: 775px; margin-top: -15px;">
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
                <asp:Panel ID="printview" runat="server" BackColor="White" Style="margin-left: 1.5em;
                    width: 730px;" Font-Bold="True">
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"
                        Visible="False"></asp:Label>
                    <table width="100%" cellspacing="10">
                        <tr>
                            <td colspan="4">
                                <center>
                                    <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                    <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="40px" valign="top">
                                <center>
                                    <asp:Label ID="lblIncidentReport" Text="Digital Dairy Report" CssClass="Labels" runat="server"
                                        Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbldate" CssClass="Labels" runat="server" Text="Date :" Font-Bold="True"
                                    Font-Size="Medium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtdate" runat="server" CssClass="Labels" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pan1" runat="server" BorderStyle="None">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbltime" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txttime" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblopenby4" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtName" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblopenby5" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtheading" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblopenby3" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="txtDescription" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label7" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label8" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label15" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label16" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label21" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label23" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label24" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label25" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label27" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label31" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label32" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel5" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label33" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label34" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label36" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label37" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label38" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label39" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label40" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel6" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label41" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label42" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label43" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label44" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label45" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label46" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label47" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label48" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel7" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label49" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label50" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label51" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label52" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label53" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label54" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label55" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label56" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel8" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label57" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label58" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label59" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label60" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label61" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label62" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label63" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label64" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel9" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label65" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label66" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label67" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label68" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label69" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label70" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label71" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label72" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel10" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label73" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label74" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label75" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label76" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label77" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label78" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label79" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label80" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label81" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label82" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label83" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label84" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label85" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label86" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label87" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label88" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel12" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label89" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label90" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label91" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label92" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label93" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label94" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label95" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label96" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel13" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label97" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label98" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label99" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label100" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label101" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label102" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label103" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label104" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel14" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label105" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label106" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label107" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label108" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label109" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label110" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label111" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label112" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel15" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label113" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label114" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label115" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label116" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label117" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label118" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label119" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label120" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel16" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label121" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label122" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label123" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label124" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label125" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label126" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label127" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label128" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel17" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label129" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label130" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label131" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label132" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label133" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label134" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label135" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label136" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel18" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label137" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label138" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label139" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label140" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label141" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label142" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label143" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label144" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel19" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label145" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label146" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label147" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label148" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label149" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label150" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label151" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label152" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel20" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label153" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label154" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label155" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label156" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label157" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label158" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label159" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label160" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel21" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label161" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label162" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label163" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label164" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label165" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label166" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label167" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label168" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel22" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label169" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label170" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label171" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label172" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label173" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label174" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label175" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label176" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel23" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label177" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label178" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label179" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label180" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label181" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label182" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label183" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td colspan="3" height="75" valign="top">
                                    <asp:Label ID="Label184" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                            <td>
                               <center>
                                    <a id="print" href="printpage.aspx" class="Button" runat="server" target="_blank"
                                        style="height: 30px; width: 100px; color: White; padding: 7px 30px 7px 30px">Print</a>
                                    <%-- <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Button" Font-Bold="True"
                                    Height="25px" Width="100px" OnClick="btnprint_Click" />--%>
                                    <asp:Button ID="BtnCancelView" runat="server" Text="Cancel" CssClass="Button" Font-Bold="True"
                                        Height="30px" Width="100px" OnClick="BtnCancelView_Click" />
                               </center>
                            </td>
                        </tr>
                        </table>
                    </asp:Panel>
                 
                   
                   
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="delete" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="delete"
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
                                    <%--Deleting a Asset record and all associated: Base Fixtures<br />
                                        <br />
                                        Do you wish to continue?--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    <center>
                                        <asp:Button ID="BtnDeleteYes" OnClick="btnDeleCancel_Click" CausesValidation="false"
                                            Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                        <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" OnClick="btnCancel_Click"
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
</asp:Content>
