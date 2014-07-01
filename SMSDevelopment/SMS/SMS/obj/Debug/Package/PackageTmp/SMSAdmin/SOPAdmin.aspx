<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="SOPAdmin.aspx.cs" Inherits="SMS.SMSAdmin.SOPAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        div#ctl00_ContentPlaceHolder1_PanelViewer
        {
            z-index: 199991;
        }
        
        
        .RadSearchBox
        {
            float: left; /*color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        .RadSearchBox:focus
        {
            float: left; /* color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        span.rsbInner
        {
            height: 30px;
            margin-left: -35px;
        }
        
        input.rsbInput.radPreventDecorate.rsbEmptyMessage
        {
            height: 28px;
        }
        button.rsbButton.rsbButtonSearch
        {
            float: None;
            height: 34px;
            margin-left: -1px;
        }
        button.rsbButton.rsbButtonSearch:hover
        {
            height: 34px;
            margin-left: -1px;
        }
        
        input.rsbInput:focus
        {
            margin-top: 6px;
        }
        
        input.rsbInput.radPreventDecorate
        {
            margin-top: 6px;
        }
        .RadGrid_Simple .rgRow td
        {
            /*border-color: #fff #c3c3c3;*/
            text-align: left;
        }
        .RadGrid_Simple .rgAltRow td
        {
            /*border-color: #ca4b0c #ffa517;*/
            text-align: left;
        }
        .RadGrid_Simple .rgSelectedRow a, .RadGrid_Simple .rgHoveredRow a, .RadGrid_Simple .rgActiveRow a
        {
            color: #F3EFED !important;
        }
    </style>
    <script type="text/javascript">

        function checkme(RadAsyncUpload, eventArgs) {

            document.getElementById("<%=lblUploadimage.ClientID %>").style.display = 'none';
        }

        function checkmeremoved(RadAsyncUpload, eventArgs) {

            document.getElementById("<%=lblUploadimage.ClientID %>").style.display = 'block';
        }
    
    
    </script>
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
            <span>Sop Admin</span>
            <br />
        </div>
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgEdit" runat="server" CausesValidation="false" OnClick="ImgEdit_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Edit"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <div id="content" runat="server">
            <asp:Panel ID="panelgrid" runat="server">
                <table width="100%" style="border: 0; margin-top: -7.2px">
                    <tr style="vertical-align: top;">
                        <td style="width: 80%">
                            <%-- <asp:UpdatePanel ID="locupdate" runat="server">
                            <ContentTemplate>--%>
                            <telerik:RadGrid ID="gvSOPTable" runat="server" CssClass="RadGrid" GridLines="None"
                                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                AllowFilteringByColumn="true">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="SOP_ID">
                                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                                    AutoPostBack="True" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="Date_From" HeaderText="Time" DataField="Date_From"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="SOP_Title" HeaderText="Title" DataField="SOP_Title"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn ShowFilterIcon="false" HeaderText="File">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkImagePathName" OnClick="ImagePathName_Click" runat="server"
                                                    Text='<%# Eval("ImagePathName") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%-- <telerik:GridHyperLinkColumn UniqueName="ImagePathName" Target="_blank" HeaderText="File" DataNavigateUrlFields="ImagePathName"
                                            DataTextField="ImagePathName"  CurrentFilterFunction="Contains"
                                            FilterDelay="1000" ShowFilterIcon="false" DataNavigateUrlFormatString="javascript: window.open('../Images/{0}','MessageCompose','height=600,width=500,top=50,left=50,toolbar=no,  menubar=no,location=no,resizable=no,scrollbars=yes,status=no'); return false;">
                                        </telerik:GridHyperLinkColumn>--%>
                                    </Columns>
                                </MasterTableView>
                                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                            </telerik:RadGrid>
                            <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:HiddenField ID="HiddenFieldViewer" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupViewer" runat="server" TargetControlID="HiddenFieldViewer"
            CancelControlID="ButtonCancelViewer" BackgroundCssClass="modalBackground" PopupControlID="PanelViewer">
        </asp:ModalPopupExtender>
        <asp:Panel ID="PanelViewer" runat="server" BackColor="White" Height="620px" Width="730px"
            BorderWidth="1px" Style="display: none; z-index:199999999 !important">
            <asp:UpdatePanel ID="UpdatePanelviewer" runat="server">
                <ContentTemplate>
                <br />
                <center>
                    <asp:Panel runat="server" ID="PanelV" BackColor="White"
                        Font-Bold="True" Width="700px">
                        <table width="100%" style=" border:none;">
                            <tr>
                                <td>
                                    <iframe id="ViewerDoc" runat="server" width="100%" height="530px"></iframe>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <%-- <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                                        <asp:Button ID="ButtonCancelViewer" runat="server" CssClass="Button" OnClick="ButtonCancelViewer_Click"
                                            Text="Cancel" Width="110px" Height="35px" Font-Bold="True" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" CancelControlID="btnClearSOPAdd_Click"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Style="height: 317px; width: 550px;
            margin-top: -15px">
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
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                    <br />
                    <center>
                        <table width="500px">
                            <tr>
                                <td>
                                    <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel runat="server" ID="Updatepanel">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddllocation" runat="server" Width="200px" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSOPIDSearch" Text="SOP No." CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSOPID" runat="server" CssClass="Input" Visible="false" />
                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSOPtitle" Text="Title" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSOPtitle" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSOPsubject" Text="Subject" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSOPsubject" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblgenerate" Text="SOP Created By [NRIC/FIN No.]" CssClass="Labels"
                                        runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtgenerate" runat="server" CssClass="Input" Visible="false" />
                                    <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblimage" Text="Attach File" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadAsyncUpload ID="txtImagePathAdd" runat="server" Width="50px" Height="20px"
                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                        EnableFileInputSkinning="True">
                                    </telerik:RadAsyncUpload>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Button ID="btnAddSOPAdd" runat="server" CssClass="Button" OnClick="btnAddSOP_Click"
                                            Text="Add" Width="100px" Height="30px" Style="margin-top: 20px" />
                                        <asp:Button ID="btnClearSOPAdd" runat="server" CssClass="Button" OnClick="btnClearSOPAdd_Click"
                                            Text="Cancel" Width="100px" Height="30px" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupEdit" runat="server" TargetControlID="HiddenField1"
            BackgroundCssClass="modalBackground" PopupControlID="pnlpopupEdit">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupEdit" runat="server" BackColor="White" Style="height: 350px;
            width: 550px; margin-top: -15px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="up">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait2" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait2" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div id="divErr" runat="server">
                        <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </div>
                    <asp:Label ID="SOP_ID" runat="server" Text="Label" Visible="false"></asp:Label>
                    <br />
                    <center>
                        <table width="500px">
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEnterSOPNo" Text="SOP No." CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUpdateSOPNo" runat="server" CssClass="Input" ReadOnly="True"
                                        BackColor="#E2E2E2" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbllocationUpdate" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocationUpdate" runat="server" CssClass="Input" Width="120px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" Text="Title" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUpdateSOPTitle" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" Text="Subject" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUpdateSOPSubject" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblImagePathName" Text="Attach File" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadAsyncUpload ID="txtImagePathUpdate" runat="server" Width="50px" Height="20px"
                                        OnClientFileSelected="checkme" OnClientFileUploadRemoved="checkmeremoved" CssClass="input"
                                        MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                        EnableFileInputSkinning="True">
                                    </telerik:RadAsyncUpload>
                                    <%-- <asp:Label ID="lblUploadimage" runat="server" Enabled="true" Text="" Style="margin-left: 89px; line-height: 2px;"></asp:Label>--%>
                                    <%-- <asp:HyperLink ID="lblUploadimage" Target="_blank" NavigateUrl="" runat="server" Enabled="true" Text="" Style="margin-left: 89px; line-height: 2px;"></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lblUploadimage" OnClick="lblUploadimage_Click" runat="server"
                                        Style="margin-left: 89px; line-height: 2px;"></asp:LinkButton>
                                </td>
                                <%-- <td colspan="3">
                                    
                                </td>--%>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="Button" OnClick="btnSave_Click"
                                            Width="100px" Height="30px" Style="margin-left: 0.5em; margin-top: 20px" />
                                        <asp:Button ID="btnBack" runat="server" Text="Cancel" CssClass="Button" OnClick="btnBack_Click"
                                            Width="100px" Height="30px" />
                                    </center>
                                </td>
                            </tr>
                        </table>
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
