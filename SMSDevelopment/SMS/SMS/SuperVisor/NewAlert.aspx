<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true" CodeBehind="NewAlert.aspx.cs" Inherits="SMS.SuperVisor.NewAlert" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <div class="divHeader">
            <span class="pageTitle">Alert</span>
            </div>
        <br />

         <div id="content" runat="server">
          <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="Panel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel4">
                                    </telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="Label37"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                 <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
                                    </telerik:RadAjaxLoadingPanel>
             <asp:Panel runat="server" ID="Panel1" BackColor="White" Style=""
                Font-Bold="True" Width="100%">

                 



                <table width="100%" >
                   <tr>
                   <td>
                       <asp:Label ID="Label1" runat="server" Text="Select Location"></asp:Label>
                   </td>
                    <td>
                        <asp:DropDownList ID="DrpLocation" runat="server" DataSourceID="dsLocation" 
                         DataTextField="Location_name" DataValueField="Location_id"
                          AppendDataBoundItems="true" AutoPostBack="true"
                            onselectedindexchanged="DrpLocation_SelectedIndexChanged">
                         
                         
                         <asp:ListItem Text="Select" Value="0" Selected="True">
                        
                         </asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                        SelectCommand="SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc">
                    </asp:SqlDataSource>
                   </td>
                   </tr>
                    <tr>
                   <td colspan="2">
                      
                                      <telerik:RadGrid ID="RadGridActiveUser" runat="server" CssClass="RadGrid" GridLines="None"
                                        AllowPaging="true" AllowSorting="true" AutoGenerateColumns="False" ShowStatusBar="true"
                                        Skin="Simple" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#ad1c1c"
                                        HeaderStyle-ForeColor="white"  HeaderStyle-Font-Size="12px"  AllowMultiRowSelection="false" 
                                        EnableEmbeddedSkins="false" onitemcommand="RadGridActiveUser_ItemCommand">
                                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Staff_ID">
                                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                            <Columns>
                                                <telerik:GridBoundColumn UniqueName="Staff_ID" HeaderText="Staff ID" DataField="Staff_ID">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="FirstName" HeaderText="First Name" DataField="FirstName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="Role" HeaderText="Role" DataField="Role">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="NRICno" HeaderText="NRIC No." DataField="NRICno">
                                                </telerik:GridBoundColumn>
                                               
                                                <telerik:GridTemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="btnOpenWindow1" ForeColor="White" runat="server" Text="Send Alert To All" OnClick="btnOpenWindow_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnOpenWindow" runat="server" Text="Send Alert" CommandName="Send" CommandArgument='<%# Eval("Staff_ID") %>'>
        
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                    
                   </td>
                   </tr>
                </table>
            </asp:Panel>

 <asp:HiddenField ID="hnfld" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupUserList" runat="server" CancelControlID="btnCancle"
        TargetControlID="hnfld" BackgroundCssClass="modalBackground" PopupControlID="pnlsend">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlsend" runat="server" BackColor="White" ScrollBars="Vertical" Height="200px"
        Width="400px">
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <center>
                <h2>Send Alert</h2>
                    <table>
                        <tr>
                            <td>
                            <asp:Label ID="lblMessage" Text="Message" runat="server"></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" Height="72px" 
                                    Width="277px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                             <center>
                                <asp:Button ID="BtnSend" runat="server" CssClass="Button" Text="Send" 
                                    onclick="BtnSend_Click" />
                        
                                <asp:Button ID="btnCancle" runat="server" CssClass="Button" Text="Cancel" 
                                    onclick="btnCancle_Click" />
                            </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

        </div>
</asp:Content>
