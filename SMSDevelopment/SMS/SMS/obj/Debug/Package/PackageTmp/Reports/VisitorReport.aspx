<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="VisitorReport.aspx.cs" Inherits="SMS.Reports.VisitorReport" %>

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

    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Visitor Report</span>
        </div>
        <div class="btnbar">
            <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imgview" runat="server" CausesValidation="false" OnClick="ImgView_Click">
                        <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                            <asp:Label ID="spanUpdate" runat='server' Text="View"></asp:Label></span>
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
        <div class="clear">
        </div>
      
        <div>
            <br />
            <asp:Panel ID="panelgrid" runat="server" Width="100%">
                <telerik:RadGrid ID="gvItemTable" runat="server" CssClass="RadGrid" GridLines="None"
                    HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                    HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                    AllowFilteringByColumn="true">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="checkout_id">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelectionCheckOut"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="checkin_time" HeaderText="In Time" DataField="checkin_time"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="checkout_time" HeaderText="Out Time" DataField="checkout_time"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="NRICno" HeaderText="NRIC No" DataField="NRICno"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="user_name" HeaderText="Name" DataField="user_name"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="telephone" HeaderText="Phone No." DataField="telephone"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="pass_no" HeaderText="Pass No." DataField="pass_no"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="company_from" HeaderText="Company From" DataField="company_from"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="to_visit" HeaderText="To Visit" DataField="to_visit"
                                CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </telerik:RadGrid>
            </asp:Panel>
        </div>
        <br />
        <div style=" background-color: #E4E4E4; width:100%">
      <center>
        <table style=" background-color: #E4E4E4; width:50%;" >
                    <tr>
                        <td style="width: 111px">
                            <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"
                                Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099"
                                Height="25px" Width="75px">
                                <asp:ListItem>Pdf</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnGo" CssClass="Button" runat="server" Text="Go" Width="60px" OnClick="btnGo_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="85px"
                                Visible="False" />
                        </td>
                        <td>
                            <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="85px"
                                OnClick="btnPrint_Click" Visible="False" />
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <br />
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupCheckinView" runat="server" CancelControlID="btnCheckinCancel"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlCheckinView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlCheckinView" runat="server" BackColor="White" Style="height: 400px;
            width: 750px; margin-top: -15px">
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
                    <asp:Panel ID="printview1" runat="server" BackColor="White">
                        <table width="700px" style="margin-left: 18px;" class="table">
                            <tr>
                                <td colspan="2">
                                <center>
                                    <asp:Image runat="server" ID="image1" Style="height: 80px; width: 100px"></asp:Image>
                                    <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                <center>
                                    <asp:Label ID="lblIncidentReport" Text="Visitor Report" CssClass="Labels" runat="server"
                                        Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                        </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="txtName" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtlocation" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblchkIn" CssClass="Labels" runat="server" Text="Check In Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtChkIn" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtNRIC" runat="server" CssClass="Labels"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPassNo" CssClass="Labels" runat="server" Text="Pass No." Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtPassNo" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblKeyNo" CssClass="Labels" runat="server" Text="Key No." Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtKeyNo" runat="server" CssClass="Labels" Visible="false"></asp:Label>
                                </td>
                            </tr>
                           
                        </table>
                    </asp:Panel>
                    <br />
                     <div style="background-color: #E4E4E4; width:700px" >
                        <center>
                                    <a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                    <asp:Button ID="btnCheckinCancel" runat="server" Text="Cancel" CssClass="Button"
                                        Font-Bold="True" Height="30px" Width="100px"  />
                               </center></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupIframe" runat="server" TargetControlID="HiddenField1"
            CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" Height="550px" Width="750px"
            BorderWidth="2px" Style="display: none;">
            <center>
                <br />
                            <asp:Panel ID="printview" runat="server" BackColor="White" width="700px" 
                                Font-Bold="True">
                                <table width="700px">
                                    <tr>
                                        <td colspan="4">
                                        <center>
                                            <asp:Image runat="server" ID="image2" Style="height: 80px; width: 100px"></asp:Image>
                                            <hr style="background-color: Black; color: Black; border-color: Black"></hr>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" height="10px" valign="top">
                                        <center>
                                            <asp:Label ID="Label1" Text="Visitor Report" CssClass="Labels" runat="server" Font-Bold="True"
                                                Font-Size="20px" ForeColor="Black"></asp:Label>
                                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblInTime" Text="In Time" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtInTime" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblName1" Text="Name" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtName1" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNRIC1" Text="NRIC No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtNRIC1" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAddress" Text="Address" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtAddress" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPhone" Text="Contact No." CssClass="Reportcolor" runat="server"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtPhone" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPass" Text="Pass No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtPass" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPassType" Text="Pass Type" CssClass="Reportcolor" runat="server"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                         <td colspan="3">
                                            :
                                            <asp:Label ID="txtPassType" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblKeyNo1" Text="Key No." CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                          <td colspan="3">
                                            :
                                            <asp:Label ID="txtKeyNo1" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblVehicle" Text="Vehicle No." CssClass="Reportcolor" runat="server"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                         <td colspan="3">
                                            :
                                            <asp:Label ID="txtVehicle" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCompanyFrom" Text="Company From" CssClass="Reportcolor" runat="server"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtCompanyFrom" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblToVisit" Text="To Visit" CssClass="Reportcolor" runat="server"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtToVisit" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblRemark" Text="Remarks" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            :
                                            <asp:Label ID="txtRemark" CssClass="Reportcolor" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </asp:Panel>
                           
                           
                     
                     <br />
                    <div style="background-color: #E4E4E4; width:700px" >
                        <center>
                          <a id="A1" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                                    <asp:Button ID="btnCancel21" Text="Cancel" runat="server" CausesValidation="false" CssClass="Button"
                                        Style="margin-left: 10px" Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                           
                    </div>
              
            </center>
        </asp:Panel>

        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="imgDelete"
            CancelControlID="MyDeleteCancel" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete11">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete11" runat="server" BackColor="White" Height="200px" Width="320px"
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
                                            <asp:Button ID="Mydelelte" OnClick="Mydelelte_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="MyDeleteCancel" Text="No" runat="server" CausesValidation="false"
                                                OnClick="MyDeleteCancel_Click" CssClass="Button" Style="margin-left: 10px" Height="30px"
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
</asp:Content>
