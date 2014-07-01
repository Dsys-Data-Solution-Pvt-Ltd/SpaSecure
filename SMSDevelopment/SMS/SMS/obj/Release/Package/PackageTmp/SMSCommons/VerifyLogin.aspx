<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyLogin.aspx.cs" Inherits="SMS.SMSCommons.VerifyLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Sunlight Secure</title>
    <link rel="Stylesheet" href= "../App_Themes/SMSThemes/chat.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSCalander.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSGrid.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="background-color: #133E67; height: 180px; width: 80em;">
 <div>     
               <div id="LogoHeader">
                <asp:Image runat="server" ImageUrl="~/Images/sunlight banner.jpg" 
                AlternateText="Security Management System" id="masterLogo" Height="180px" 
                Width="80em"/>
        </div>       
        <div>
            <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
          <br />
          <div>
              <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="80%" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                            OnRowCommand="grdLocations_RowCommand">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
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
        <div class="Container" align="center">
           <span class="footertext"><asp:Label ID="lblTitle_Header" Text="Copyright © 2010-2011 D-Sys Data Solutions. All rights reserved." CssClass="Labels" runat="server"/></span>
       </div>
</div>

</form></body></html>