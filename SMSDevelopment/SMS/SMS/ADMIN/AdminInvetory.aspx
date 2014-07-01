<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    EnableViewState="true" CodeBehind="AdminInvetory.aspx.cs" Inherits="SMS.ADMIN.AdminInvetory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
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
            <span class="pageTitle">Inventory Management</span><br />
            <br />
        </div>
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imgAdd_Click">
                        <span class="iconAdd" id="SpanAdd1" runat="server" style="line-height: 120px;">
                            <asp:Label ID="SpanAdd" runat="server" Text="Add New Inventory"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                        <span class="iconUpdate" id="SpanUpdate1" runat="server" style="line-height: 120px;">
                            <asp:Label ID="SpanUpdate" runat="server" Text="Edit"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                        <span class="iconDelete" id="SpanDelete" runat="server" style="line-height: 120px;">
                            <asp:Label ID="Label1" runat="server" Text="Delete"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgout" runat="server" CausesValidation="false" OnClick="imgout_Click">
                        <span class="iconInventoryOut" id="Span1" runat="server" style="line-height: 120px;">
                            <asp:Label ID="Label6" runat="server" Text="Inventory Out"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <%--<asp:UpdatePanel ID="UpdatePanelradgri" runat="server">
            <ContentTemplate>--%>
        <br />
        <asp:Panel ID="panelgrid" runat="server">
            <telerik:RadGrid ID="RadGridCatalog" runat="server" Skin="Simple" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white"
                AutoGenerateColumns="False" ShowStatusBar="true" AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Item_Id">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" EnableViewState="true" OnCheckedChanged="CheckBox1_CheckedChanged"
                                    AutoPostBack="true" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="Item_Type" HeaderText="Item Type" DataField="Item_Type"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            <HeaderStyle Width="60px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Item_Name" HeaderText="Details" DataField="Item_Name"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Item_qty" HeaderText="Item Quantity" DataField="Item_qty"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>
            <%--    </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnupdate" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnupdate"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAdd" runat="server" BackColor="White" Width="600px" Height="380px"
            Style="display: none; padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait" runat="server" Text=" Please wait... " Font-Bold="true" Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblItemType" runat="server" CssClass="Labels" Text="Item Type"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddItemType" runat="server" CssClass="Labels" Width="180px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddNewType" runat="server" CssClass="Labels" Text="Add New Type"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtItemType" runat="server" CssClass="Input" Width="180px" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAddNewType" runat="server" CssClass="Button" OnClick="btnAddNewType_Click"
                                    Style="position: relative; float: left; margin-top: -25px; margin-left: 190px;
                                    height: 20px;" Text="Add Type" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblserialNo" Text="Serial No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSerialNo" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmodelno" Text="Model No." CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtModelno" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblItemName" Text="Item Details" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblquantity" Text="Quantity" CssClass="Labels" runat="server"></asp:Label>
                                <br />
                            </td>
                            <td>
                                <asp:TextBox ID="txtqunatity" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCreatedBy" runat="server" CssClass="Labels" Text="Created By"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCreatedBy" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnAdd" Text="Add" runat="server" CssClass="Button" Height="30px"
                                        Width="100px" OnClick="btnaddNewItem_Click" />
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="Button" Style="margin-left: 10px"
                                        Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="HiddenField1"
            CancelControlID="btncancelupdate" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupUpdate" runat="server" BackColor="White" Width="600px" Height="380px"
            Style="display: none; padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWaitupd" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWaitupd" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <br />
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                    <table width="100%" class="table">
                        <tr>
                            <td>
                                <asp:Label ID="lblItemID" Text="Item ID" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemID" runat="server" CssClass="Input" Width="200px" Visible="False" />
                            </td>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" Text="Item Type" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddItemTypeupdate" runat="server" Width="200px" CssClass="Input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="20px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" Text="Item Details" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItemNameupd" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" Text="Quantity" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtqunatityupd" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="Labels" Text="Created By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreatedByupd" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCreatedTime" runat="server" CssClass="Labels" Text="Created Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreatedTime" runat="server" ReadOnly="true" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEditBy" runat="server" CssClass="Labels" Text="Edited By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEditBy" runat="server" ReadOnly="true" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Button ID="Button1" Text="Update" runat="server" CssClass="Button" Height="30px"
                                            Width="100px" OnClick="btnSave_Click" />
                                        <asp:Button ID="btncancelupdate" Text="Cancel" runat="server" CssClass="Button" Style="margin-left: 10px"
                                            Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                    </center>
                                </td>
                            </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="HiddenField2"
            CancelControlID="btncanceldelete" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupDelete" runat="server" BackColor="White" Width="400px" Style="display: none;
            padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress3" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWaitdel" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWaitdel" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <br />
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <center>
                                    Do You want to Delete This Record?<br />
                                    <br />
                                    <asp:HiddenField ID="hdnitmID" runat="server" />
                                    <asp:Button ID="Button2" Text="Yes" runat="server" CssClass="Button" Height="30px"
                                        Width="100px" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btncanceldelete" Text="No" runat="server" CssClass="Button" Style="margin-left: 10px"
                                        Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupout" runat="server" TargetControlID="HiddenField3"
            CancelControlID="btncancelout" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupOut">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupOut" runat="server" BackColor="White" Width="500px" Style="display: none;
            padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress4" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWaitout" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWaitout" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <br />
                    <table width="100%" class="table">
                        <tr>
                            <td>
                                <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txtnric" runat="server" CssClass="Input" Width="180px" AutoPostBack="True"
                                    OnTextChanged="txtnric_TextChanged" />--%>

                                     <telerik:RadComboBox ID="txtnric" runat="server" Width="150" EnableAutomaticLoadOnDemand="true"
                                    EmptyMessage="Select NRIC No" AutoPostBack="true" Style="z-index: 1000000;" DataSourceID="SqlDataSource1"
                                    DataTextField="NRICno" DataValueField="NRICno" ItemsPerRequest="10" ShowMoreResultsBox="true"
                                    OnSelectedIndexChanged="txtIssuedToNRIC_TextChanged" EnableVirtualScrolling="true">
                                </telerik:RadComboBox>
                             
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                                    SelectCommand="SELECT NRICno from UserInformation"></asp:SqlDataSource>
                                <%--
                                    <telerik:RadSearchBox ID="txtnric" runat="server" DataTextField="NRICno" DataValueField="NRICno" DropDownSettings-Height="200px"
                                     Width="180px" DataSourceID="SqlDataNRIC"></telerik:RadSearchBox>

                                  
     
                                      <asp:SqlDataSource ID="SqlDataNRIC" runat="server" DataSourceMode="DataSet"
                                    ConnectionString="<%$ ConnectionStrings:SPASecureConnectionString %>" EnableCaching="True"
                                    CacheDuration="20" SelectCommand="SELECT DISTINCT [NRICno] FROM [UserInformation]">
                                </asp:SqlDataSource>--%>
                                <asp:Label ID="txtstffid" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblname" runat="server" CssClass="Labels" Font-Bold="True" Text="Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblposition" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtposition" runat="server" CssClass="Input" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblComment" runat="server" CssClass="Labels" Text="Comment"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtComment" runat="server" CssClass="Input" Height="84px" TextMode="MultiLine"
                                    Width="350px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Labels" Text="Item Type"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" CssClass="Labels"
                                    ForeColor="Black" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblitemDetail" runat="server" CssClass="Labels" Text="Item Details"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlItemName" runat="server" CssClass="Input" Width="80px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl1" runat="server" Text="(Total Qty)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttotalqty" runat="server" Font-Bold="True" ForeColor="#0066FF"
                                    ReadOnly="True" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblitemqty" runat="server" CssClass="Labels" Text="Issue Quantity"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtquantity" runat="server" CssClass="Input" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="Button3" runat="server" CssClass="Button" Height="30px" OnClick="btnNewInventoryOut_Click"
                                        Text="Inventory Out" Width="100px" />
                                    <asp:Button ID="btncancelout" runat="server" CssClass="Button" Height="30px" OnClick="btnCancel_Click"
                                        Style="margin-left: 10px" Text="Cancel" Width="100px" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
