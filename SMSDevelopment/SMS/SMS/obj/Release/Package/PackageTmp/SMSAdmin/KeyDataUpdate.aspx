<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="KeyDataUpdate.aspx.cs" Inherits="SMS.SMSAdmin.KeyDataUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divContainer">
        <div class="divHeader">
          <span class="pageTitle">Key Update</span></div>
               <div id="divErr" runat="server">
                            <asp:label id="lblErrMsg" cssclass="ValSummary" runat="server" Font-Bold="True" 
                                ForeColor="Red"></asp:label>
               </div>
                       
                        <asp:hiddenfield id="hdnBTID" runat="server" value="" />
                        <asp:hiddenfield id="hdnBTName" runat="server" value="" />
               <br />  
               <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="700">
            <table width="700px" class="table">       
            <table id="tblMain" width="100%" class="table">
            
                                    <tr>    
                                                <td>
                                                    <asp:Label ID="lblKeyNo" Text="Key No." CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtKeyNo" runat="server" CssClass="Input" BackColor="#E1E1E1" 
                                                        ReadOnly="True"/>
                                                </td>
                                                
                                 
                                                <td>
                                                    <asp:Label ID="lblKeyDesc" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtKeyDesc" runat="server" CssClass="Input"/>
                                                </td>
                                                
                                                
                                    </tr> 
                                    
                                     <tr>
                                            <%--<td><asp:Label ID="lblKeyStatus" Text="Status" CssClass="Labels" runat="server" 
                                                    Visible="False"></asp:Label></td>
                                            <td><asp:TextBox ID="txtKeyStatus" runat="server" CssClass="Input" Visible="False" 
                                                    BackColor="#E1E1E1" ReadOnly="True"/></td>--%>
                                            
                                    </tr>
                   
                                 <tr>
                                           <td height="50px"></td>
                                 </tr>
                   
                                <tr> 
                                    <td>
                                        <asp:Label ID="lblKeySign" runat="server" CssClass="Labels" 
                                          Text="Key Signed In By:" font-Bold="True"></asp:Label>
                                     </td>
                                </tr>
                                
                               <tr>
                                            <td><asp:Label ID="lblKeyNRIC" Text="NRIC/FIN No." CssClass="Labels" runat="server"></asp:Label> </td>
                                            <td><asp:TextBox ID="txtKeyNRIC" runat="server" CssClass="Input"/></td>
                                
                                                <td><asp:Label ID="lblKeyName" Text="Name" CssClass="Labels" runat="server"></asp:Label>   </td>
                                                <td> <asp:TextBox ID="txtKeyName" runat="server" CssClass="Input"/> </td>
                                            
                                </tr>
                                <tr>  
                                            <td><asp:Label ID="lblKeyPosition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                                             </td>
                                             <td><asp:TextBox ID="txtKeyPosition" runat="server" CssClass="Input"/> </td>
                                             <td><asp:Label ID="lblKeyCount" Text="Count" CssClass="Labels" runat="server"></asp:Label></td>
                                            <td><asp:TextBox ID="txtKeyConnt" runat="server" CssClass="Input"/> </td>
                                </tr>
                                     
                              
                                <tr>
                                       <td height="50px">
                                       </td>
                                
                                </tr>
                  </table>
                   <table  width="700" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                   <tr>
                      
                           <td colspan="5">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" 
                                    OnClick="btnSave_Click" Width="85px"  style=" margin-left:13.3em"/>
                                &nbsp;&nbsp; &nbsp;
                              <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" 
                                    OnClick="btnBackPassAdmin_Click" Width="85px" />
                        
                       </td>
               </tr></table>
           
            </asp:panel>
           <br />
    </div>
</asp:Content>
