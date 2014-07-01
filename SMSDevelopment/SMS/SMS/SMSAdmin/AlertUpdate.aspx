<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AlertUpdate.aspx.cs" Inherits="SMS.SMSAdmin.AlertUpdate" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Update Alert Handling  </span></div>
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
       
           <div id="divAdvSearch" runat="server" visible="true">
        <br />                            
              <table width="700px">
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddNRIC" runat="server" CssClass="Input" 
                                                            BackColor="#E9E9E9" ReadOnly="True" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblItemDesc" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddItemDesc" runat="server" CssClass="Input" />
                                                         
                                                    </td>
                                          </tr>
                                            <tr>      
                                                    <td>
                                                        <asp:Label ID="lblAlertType" Text="Alert Type" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="Input" width="126px">
                                                       
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompany" Text="Company" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddCompany" runat="server" CssClass="Input" />
                                                        
                                                    </td>
                                                
                                            </tr>
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblVehicle" Text="Vehicle Registration No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddVehicle" runat="server" CssClass="Input" />
                                                       
                                                    </td>
                                           </tr>        
                                            <tr>
                                                    <td valign="top">
                                                        <asp:Label ID="lblmessage" Text="Alert Message" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtmessage" runat="server" CssClass="Input" 
                                                            TextMode="multiline" width="460px" Height="80px" />
                                                       
                                                    </td>
                                            </tr>
                                           <tr>
                                                <td height="35px">
                                                </td>
                                           </tr> 
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblalertedby" runat="server" CssClass="Labels" Font-Bold="True" 
                                                            Text="Alerted By:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                
                                                    <td>
                                                        <asp:Label ID="lblbynric" runat="server" CssClass="Labels" Text="NRIC/FIN No."></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbynric" runat="server" CssClass="Input" BackColor="#E9E9E9" 
                                                            ReadOnly="True" />
                                                    </td>
                                                
                                                        <td>
                                                            <asp:Label ID="lblname" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtname" runat="server" CssClass="Input" />
                                                        </td>
                                                        
                                                </tr>
                                                <tr>        
                                                        
                                                        
                                                        <td>
                                                            <asp:Label ID="lbldepartment" runat="server" CssClass="Labels" 
                                                                Text="Department"></asp:Label>
                                                        </td>
                                                        <td>
                                                             <asp:DropDownList ID="ddlRole0" runat="server" CssClass="Input" width="132px">
                                                  
                                                             </asp:DropDownList>
                                                        </td>
                                                    
                                                
                                                            <td>
                                                               <asp:Label ID="lblphone" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                                          </td>
                                                          <td>
                                                               <asp:TextBox ID="txtphone" runat="server" CssClass="Input" />
                                                          </td>
                                                 </tr>
                                                <tr>
                                               
                                                        <td>
                                                            <asp:Label ID="lbldesignation" runat="server" CssClass="Labels" 
                                                                Text="Designation"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtdesignation" runat="server" CssClass="Input" />
                                                        </td>
                                                </tr>
                                                <tr>
                                                     <td height="60px">                                                     
                                                     </td>
                                                
                                                </tr>
                                                        
                                                        <tr>
                                                            <td align="Center" colspan="5">
                                                                <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                                                    onclick="btnsave_Click" Text="Save" Width="85px" />
                                                                &nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="btnback" runat="server" CssClass="Buttons" 
                                                                    onclick="btnback_Click" Text="View all" Width="85px" />
                                                            </td>
                                                        </tr>
                                                                                      
                                        </table>
                              
           <br/> 
         </div>
     </div>
<br/>
</asp:Content>
