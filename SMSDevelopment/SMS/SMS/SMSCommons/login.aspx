<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SMS.SMSCommons.login"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Log In</span></div> 
    <table  border="0" width="100%">    
    <tr valign="top" align="center">
        <td>
            <table  border="0">
                <tr>
                    <td  colspan="4">
                        <div id="divMsg" runat="server" visible="false">
                            <asp:Label ID="lblMsg" CssClass="ValSummary" runat="server"></asp:Label>
                        </div>
                    </td>   
                </tr>
            </table>
            
            <table width="40%">
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" Text="User Name" CssClass="Labels" runat="server" />&nbsp;<span class="req">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUserName" CssClass="Input" runat="server" />
                    </td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" Text="Password" CssClass="Labels" runat="server" />&nbsp;<span class="req">*</span>
                    </td>
                    <td align="left">    
                        <asp:TextBox ID="txtPassword" CssClass="Input" TextMode="Password" runat="server" />
                    </td>
                </tr>
                
               <%-- <tr>
                    <td>
                        <asp:Label ID="lblPassword0" Text="Location" CssClass="Labels" runat="server" />&nbsp;<span class="req">*</span>
                    </td>
                    <td align="left" colspan="2">    
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="Input" 
                            DataSourceID="dsLocation" DataTextField="Location_name" 
                            DataValueField="Location_id" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                
                <tr>
                    <td colspan="2" align="center">
                            <%--<asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:tspsecur_SMSConnectionString %>"
                                
                            SelectCommand="SELECT 0 as [Location_id],'- Select -' as  [Location_name],0 as Temp FROM [location] UNION SELECT Location_id, Location_name,1 as Temp FROM location order by Temp,Location_name"></asp:SqlDataSource>--%>
                            
                        <asp:Button ID="btnLogin" Text="Login" CssClass="Buttons" runat="server" 
                            onclick="btnLogin_Click" />
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnForgetPswd" Text="Forgot Password" CssClass="LnkButton" runat="server" onclick="lnkBtnForgetPswd_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    </div>  
    <br />       
</asp:Content>
