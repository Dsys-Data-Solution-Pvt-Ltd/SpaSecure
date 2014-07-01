<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="AssignSitesToUsers.aspx.cs" Inherits="SMS.Operations.AssignSitesToUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function jqCheckAll(item, clas) {
            $("." + clas + " [type='checkbox']").attr('checked', item.checked);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divHeader">
        <span class="pageTitle">Assign Locations To Users</span>
    </div>
    <table width="100%">
        <tr>
            <td align="left">
                <asp:Label ID="lblShiftID2" CssClass="Labels" runat="server" Text="Select Role"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="Labels" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:Label ID="lblShiftID3" CssClass="Labels" runat="server" Text="Select User"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlUser" runat="server" CssClass="Input" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="yu" runat="server" visible="false">
            <td style="width: 138px">
                <asp:Label ID="lblcharator" Text="Alphabet By" CssClass="Labels" runat="server"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpcharactor" runat="server" CssClass="Input" AutoPostBack="True"
                    OnSelectedIndexChanged="drpcharactor_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>G</asp:ListItem>
                    <asp:ListItem>H</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>J</asp:ListItem>
                    <asp:ListItem>K</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>O</asp:ListItem>
                    <asp:ListItem>P</asp:ListItem>
                    <asp:ListItem>Q</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>
                    <asp:ListItem>S</asp:ListItem>
                    <asp:ListItem>T</asp:ListItem>
                    <asp:ListItem>U</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>
                    <asp:ListItem>X</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>Z</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 24%">
                &nbsp;
            </td>
            <td align="left" style="width: 15%">
                &nbsp;
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Locations"></asp:Label>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                      <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="5" Width="700px" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                    PageSize="100">
                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                    <RowStyle CssClass="NormalRow" />
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" CssClass="unassigned" runat="server" AutoPostBack="true"
                                    OnCheckedChanged="chkSelectAll_CheckedChanged" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSite" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Location_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Location" DataField="Location_name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White"
                            ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                     <SelectedRowStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <center>
                <div style="background-color: #E4E4E4;">
                    <asp:Button ID="btnAssignSites" Text="Assign Locations" runat="server" CssClass="Button"
                        OnClick="btnAssignSites_Click" Width="150px"/>
                    <asp:Button ID="Button1" Text="DeAssign" runat="server" CssClass="Button" OnClick="Button1_Click" />
                </div>
                </center>
            </td>
        </tr>
    </table>

     <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" ScrollBars="Vertical" Height="500px" Width="700px"
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
                        <table width="650PX">
               
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="Input" Width="200px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Users"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="2">
                     
                        <asp:GridView ID="grdUser" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="650px" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                            PageSize="100">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" CssClass="unassigned" runat="server" AutoPostBack="true" 
              OnCheckedChanged="chkSelectAll_CheckedChanged1" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUser" CssClass="unassigned" runat="server" ToolTip='<%# Eval("StaffID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="User" DataField="FirstName" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White"
                                    ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr><td colspan="2" >
                <center>
                 <asp:Button ID="Button2" Text="DeAssign Locations" Width="200px" runat="server" CssClass="Button"
                            OnClick="btnAssignSites_Click1" />
                              <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="Button"
                            OnClick="btnbtnCancel_Click" />
                            </center>
                </td></tr>
               
            </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
</asp:Content>
