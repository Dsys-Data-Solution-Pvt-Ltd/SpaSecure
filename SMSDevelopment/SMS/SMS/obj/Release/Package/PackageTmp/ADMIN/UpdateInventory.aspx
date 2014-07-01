<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="UpdateInventory.aspx.cs" Inherits="SMS.ADMIN.UpdateInventory" Title="Update Inventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Inventory Update</span></div>
        <div id="divErr" runat="server">
            <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
        <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
        <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
        <br />
        <div>
        <br />
             <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px" >
                            <table width="700px" class="table">
                                
             <tr>
                <td>
                    <asp:Label ID="lblItemID" Text="Item ID" CssClass="Labels" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtItemID" runat="server" CssClass="Input" Width="200px" Visible="False" />
                </td>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblItemType" Text="Item Type" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddItemType" runat="server" Width="200px" CssClass="Input">
                    </asp:DropDownList>
                </td>
                <%--<td>
                                <asp:Label ID="lblAddNewType" Text="Add New Type" CssClass="Labels" 
                                    runat="server"></asp:Label>
                            </td>
                            
                            <td colspan="2">
                                <asp:TextBox ID="txtItemType" runat="server" CssClass="Input"/>
                                &nbsp;&nbsp;&nbsp;                               
                                
                           
                                <asp:Button ID="btnAddNewType" runat="server" Text="Add Type" 
                                    CssClass="Buttons" />
                            </td>--%>
            </tr>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblItemName" Text="Item Details" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" Width="200px" />
                </td>
            </tr>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblquantity" Text="Quantity" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtqunatity" runat="server" CssClass="Input" Width="200px" />
                </td>
            </tr>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblCreatedBy" runat="server" CssClass="Labels" Text="Created By"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCreatedBy" runat="server" CssClass="Input" Width="200px" />
                </td>
            </tr>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblCreatedTime" runat="server" CssClass="Labels" Text="Created Time"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCreatedTime" runat="server" CssClass="Input" Width="200px" />
                </td>
            </tr>
            <tr><td height="20px"></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lblEditBy" runat="server" CssClass="Labels" Text="Edited By"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEditBy" runat="server" CssClass="Input" Width="200px" />
                </td>
            </tr>
            <tr>
                <td height="50px">
                </td>
            </tr>
            </table>
            </asp:panel>
    <div class="table">
            <table  width="750" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
        <tr><td colspan="4" align="center" style="width: 897px">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" Width="85px"
                        OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" Width="85px"
                        OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
       </div>
        </div>
        <%--<table width="100%">
         
         
                          <tr>
                            <td>
                                <asp:Label ID="lblitemid" Text="Item Code" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtitemid" runat="server" CssClass="Input" 
                                    Width="169px" ReadOnly="True" />
                                <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblItemName" Text="Item Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemName" runat="server" CssClass="Input" 
                                    Width="169px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                                <td>
                                    <asp:Label ID="lblquantity" Text="Available Quantity" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtqunatity" runat="server" CssClass="Input" Width="169px" />
                                </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <asp:Label ID="lblCreatedBy" runat="server" CssClass="Labels" Text="Created By"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtCreatedBy" runat="server" CssClass="Input" Width="169px" 
                                        ReadOnly="True"/>
                              </td>
                        </tr>
                       <tr>
                            <td>
                                <asp:Label ID="lblCreatedTime" runat="server" CssClass="Labels" Text="Created Time"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtCreatedTime" runat="server" CssClass="Input" Width="169px" 
                                      ReadOnly="True"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEditBy" runat="server" CssClass="Labels" Text="Edited By"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditBy" runat="server" CssClass="Input" Width="169px"/>
                             </td>
                        </tr>
                     <tr>
                            <td>
                                <asp:Label ID="lblEditTime" runat="server" CssClass="Labels" Text="Edited Time"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditTime" runat="server" CssClass="Input" Width="169px"/>
                             </td>
              
                        </tr>


                        
                         
                         
       
 
   <tr>
    <td height="25">
       
    </td>
 
 </tr>
 
 
           <tr>
               <td height="45px"></td>
           </tr>   
          <tr>                   
                                        
                  <td align="center" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" 
                      Width="85px" onclick="btnSave_Click" />
                     &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" 
                       Width="85px" onclick="btnBack_Click" />
                                                    
                  </td> 
           </tr> 
        </table>--%>
        <br />
    </div>
</asp:Content>
