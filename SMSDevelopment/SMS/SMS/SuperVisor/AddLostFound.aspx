<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AddLostFound.aspx.cs" Inherits="SMS.SuperVisor.AddLostFound" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 406px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Lost And Found Item</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                                                    
                       <table width="750px" class="table" style=" background-color:White">
                                            <tr>
                                                <td colspan="5" height="25" valign="top">
                                                    <asp:Label ID="lblItem" Text="Details Of Item" CssClass="Labels" runat="server" 
                                                        Font-Bold="True" ></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                 <td>
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" 
                                                     Width="130px"></asp:DropDownList>
                                                     <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                                                </td>                                            
                                            </tr>
                                              <tr>
                                                    <td>
                                                        <asp:Label ID="lblDateofLost" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="style1">
                                                            <asp:TextBox runat="server" ID="calDate" Text="" CssClass="Input"/>
                                                            <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDate" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp"/>
                                                    </td>
                                             </tr>
                                             
                                            <tr>
                                                    <td>
                                                            <asp:Label ID="lblTimeLost" Text="To Time" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td class="style1">
                                                            <MKB:timeselector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" AllowSecondEditing="true"/>
                                                    </td>                                            
                                            </tr>
                                            <tr>                                            
                                                
                                            
                                                    <td>
                                                            <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="300px"/>
                                                    </td>
                                                
                                          </tr>
                                          
                                          <tr>
                                                   
                                                     <td>
                                                            <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtNRIC" runat="server" CssClass="Input"/>
                                                    </td>
                                                     <td>
                                                            <asp:Label ID="lblTelephone" Text="Contact No." CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="Input" Width="200px"/>
                                                    </td>
                                                    
                                                    
                                            </tr>
                                          
                                          
                                          <tr>      
                                                
                                                <td valign="top">
                                                    <asp:Label ID="lblDescription" Text="Description" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="Input" 
                                                        Width="600px" Height="75px" TextMode="MultiLine" />
                                                </td>
                                         </tr>
                                         
                                          <tr>
                                                   
                                                     <td>
                                                            <asp:Label ID="lblStatus" Text="Status" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                         <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Input">
                                                           <asp:ListItem>Lost</asp:ListItem>
                                                           <asp:ListItem>Found</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                           </tr>         
                                         
                                         
                                         
                                         
                                    </table>
             
                       <br />
                       <br />
                       <br />
                                    
                               <table width="750" class="table" style=" background:url(../Images/1397d40aa687.jpg)">           
                                            
                                            <tr>
                                                <td align="Center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Save" Width="85px" onclick="btnItemAdd_Click"/>
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px" onclick="btnClearItemAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                    </div>
    </div>

</asp:Content>
