<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddNewInventoryOut.aspx.cs" Inherits="SMS.ADMIN.AddNewInventoryOut"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 217px;
        }
        .style9
        {
            width: 185px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Inventory Out</span></div>
               <div>
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
             </div>
             
                    <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                        <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1em" Font-Bold="True" Width="750px">

                        <table width="700PX" class="table">
                        <tr><td></td></tr>
                        <tr>
                        <td style="width:90px">
                        <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width:250px">
                        <asp:TextBox ID="txtnric" runat="server" CssClass="Input" Width="180px" 
                         AutoPostBack="True" ontextchanged="txtnric_TextChanged" />
                         <asp:Label ID="txtstffid" runat="server" Text="" Visible="false"></asp:Label>
                        
                        </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                        <td style="width:90px">
                        <asp:Label ID="lblname" Text="Name" CssClass="Labels" runat="server" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width:250px">
                        <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="180px" />
                 
                        </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                        <td style="width:90px">
                        <asp:Label ID="lblposition" Text="Position" CssClass="Labels" runat="server"></asp:Label>
                         </td>
                        <td style="width:250px">
                        <asp:TextBox ID="txtposition" runat="server" CssClass="Input" Width="180px" />
                        </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                        <td style="width:90px">
                        <asp:Label ID="lblComment" Text="Comment" CssClass="Labels" runat="server"></asp:Label>
                         </td>
                        <td style="width:250px">
                        <asp:TextBox ID="txtComment" runat="server" CssClass="Input" Width="350px" 
                                                        Height="84px" TextMode="MultiLine" />
                                 
                        </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                        <td style="width:90px">
                         </td>
                        <td style="width:150px">
                          
                                                  </td>
                         
                        </tr>
                        
                        </table>
                        </asp:panel>
             
                        <asp:panel runat="server" ID="Panel2" BackColor="White" 
                            style=" margin-left:1em" Font-Bold="True" Height="141px" Width="750px">

                        <table width="100%" class="table">
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                        <td width="25px">
                        <asp:Label ID="lblitemtype" runat="server" Text="Item Type" CssClass="Labels"></asp:Label>
                        
                         </td>
                        <td >
                         <asp:DropDownList ID="ddlItemType" runat="server" CssClass="Labels" 
                          onselectedindexchanged="ddlItemType_SelectedIndexChanged" 
                           AutoPostBack="True" ForeColor="Black" width="100px">
                                                     </asp:DropDownList>
                   </td>
                   <td width="25px">
                    <asp:Label ID="lblitemDetail" runat="server" Text="Item Details" 
                     CssClass="Labels"></asp:Label>

                        </td>
                        <td >
                        <asp:DropDownList ID="ddlItemName" runat="server" CssClass="Input" Width="80px">
                                                      </asp:DropDownList>
                                                   
                       
                        </td>

                       </tr>
                       <tr>
                       <td>
                           &nbsp;<td width="100px">
                               &nbsp;</td>
                           <td>
                               &nbsp;</td>
                           <td width="100px">
                               &nbsp;</td>
                        </tr>
                            <tr>
                                <td width="25px">
                                    <asp:Label ID="lbl1" runat="server" Text="(Total Qty)"></asp:Label></td>
                                    <td width="100px">
                                        <asp:TextBox ID="txttotalqty" runat="server" Font-Bold="True" 
                                            ForeColor="#0066FF" ReadOnly="True" Width="99px"></asp:TextBox>
                                    </td>
                                    <td width="25Px">
                                        <asp:Label ID="lblitemqty" runat="server" CssClass="Labels" 
                                            Text="Issue Quantity"></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="txtquantity" runat="server" CssClass="Input" Width="99px"></asp:TextBox>
                                    </td>
                               
                            </tr>
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        </table>
                        </asp:panel>
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" style=" margin-left:1em" width="750px">
                        <table width="100%" class="table">
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <table  width="750px" style="margin-left:-0.0em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                        <tr>
                        <td >
                        <asp:button id="btnNewInventoryOut" text=" Inventory Out" runat="server" 
              cssclass="Buttons" onclick="btnNewInventoryOut_Click" style=" margin-left:350px" /> </td>           
                        </tr></table>
                        </table>
                        </asp:Panel>   
                        
                    </div>
                <br/>
             
 
  <br />
    <div align="center">
             
    </div>
    <br/>
 </div> 
</asp:Content>
