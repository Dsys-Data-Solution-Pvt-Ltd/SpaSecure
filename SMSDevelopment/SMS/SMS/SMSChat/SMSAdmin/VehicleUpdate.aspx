<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="VehicleUpdate.aspx.cs" Inherits="SMS.SMSAdmin.VehicleUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Vehicle Update</span></div>
         <div id="divErr" runat="server">
             <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
             ForeColor="Red"></asp:Label>
         </div>
         <br />
    <table id="tblMain" width="100%">
         <tr>
                <td>
                   
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                </td>
            </tr>
        
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                                 
                           <table width="100%">
                           
                                       <tr>
                                                <td>
                                                    <asp:Label ID="lblEnterVehicleNo" Text="Registration No." CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEnterVehicleNo" runat="server" CssClass="Input" 
                                                        BackColor="#E2E2E2" ReadOnly="True" />
                                                    
                                                </td>
                                                
                                       
                                                <td>
                                                    <asp:Label ID="lblEnterVehicleType" Text=" Type" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:DropDownList ID="drpvehicletype" runat="server" cssclass="Input" 
                                                            Width="136px">
                                                        </asp:DropDownList>
                                               </td>
                                       </tr>
                                       <tr>
                                                <td>
                                                    <asp:Label ID="lblVehicleColor" runat="server" CssClass="Labels" Text="Color"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVehicleColor" runat="server"  cssclass="Input"></asp:TextBox>
                                                  
                                                </td>
                                                <td>
                                                    <asp:Label  ID="lblVehicleModel" runat="server" CssClass="Labels" Text="Model"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVehicleModel" runat="server"  cssclass="Input"></asp:TextBox>
                                                 
                                                </td>
                                       </tr>
                                       <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblEnterVehicleRemark" Text="Remarks" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtEnterVehicleRemark" runat="server" CssClass="Input" 
                                                        Height="80px" Width="75%" />
                                                     
                                                </td>
                                        </tr>
                                        <tr>
                                           <td height="40px"></td>
                                        
                                        </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    
                                                     <asp:Button ID="btnsave" Text="Save" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearVehicleAdd_Click" Width="10%" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnback" Text="View All" runat="server" CssClass="Buttons" 
                                                        width="10%" onclick="btnback_Click" />
                                                    
                                                </td>
                                            </tr>
                                  </table>
                              
                    </div>
                </td>
            </tr>
        </table>
        <br />
    </div>

</asp:Content>
