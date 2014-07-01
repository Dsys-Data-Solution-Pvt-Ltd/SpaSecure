<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="VerifyLogin.aspx.cs" Inherits="GaurdPatroSystem.VerifyLogin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     
        <%--<div id="LogoHeader">
            <asp:Image runat="server" ImageUrl="~/Images/one banner.jpg" 
                AlternateText="Security Management System" id="masterLogo" Height="180px" 
                Width="80em"/>
        </div>--%>       
        <div>
            <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
          <br />
          <div class="table">
              <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="80%" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                            OnRowCommand="grdLocations_RowCommand">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                             <EmptyDataRowStyle CssClass="NoRecords" />
                            <EmptyDataTemplate>
                                <asp:Label ID="lblNoRecords" Text="No Assign Location of the User."
                                    runat="server">
                                </asp:Label>
                                
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Select Location">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLoc" runat="server" CssClass="LnkButton" Text='<%# Eval("Location_name") %>'
                                            CommandArgument='<%# Eval("Location_id") %>' CommandName="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>          
          </div>      
       <br />
       
</div>



</asp:Content>
