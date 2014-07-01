<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="Event1.aspx.cs" Inherits="SMS.SMSUsers.Event1" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Add Event</span></div>
        <br />
        <table>
        <tr>
        <td valign="top">
            
            <asp:Label ID="Date" CssClass="Labels" runat="server"  Text="Date"></asp:Label>
            
            </td> 
           
            <td>
                                <asp:TextBox runat="server" ID="txtFromDate" Text="" CssClass="Input" />
                                <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                                <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 		ImageUrl="~/Images/calendar.bmp" />
           </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLocation" CssClass="Labels" runat="server" Text="Location"></asp:Label></td>
                <td>
                    <asp:dropdownlist runat="server" CssClass="Input"></asp:dropdownlist>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbleventtype" CssClass="Labels" runat="server" Text="Event Type"></asp:Label></td>
                <td> <asp:dropdownlist runat="server" CssClass="Input"></asp:dropdownlist></td>
                <td></td>
            </tr>
            
            <tr>
                <td><asp:Label ID="lblEventstarttype" CssClass="Labels" runat="server" Text="Event Start Time"></asp:Label></td>
                <td><asp:TextBox ID="txtEventstarttype" CssClass="Input" runat="server" ></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
            <td><asp:Label ID="lblEventend" CssClass="Labels" runat="server" Text="Event End"></asp:Label></td>
            <td><asp:TextBox ID="txteventend" CssClass="Input" runat="server"></asp:TextBox>  </td>
            
            
            </tr>
            <tr>
                <td><asp:Label ID="lblpersonincharge" CssClass="Labels" runat="server" Text="Person Incharge"></asp:Label></td>
                <td><asp:TextBox ID="txtpersonincharge" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            
            <tr>
            <td><asp:Label ID="lblspecialreq" CssClass="Labels" runat="server" Text="Special Reqirment"></asp:Label></td>
            <td><asp:TextBox ID="txtspecialreq" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            
            </tr>
            
            <tr><td><asp:Label ID="lblgaurdreq" CssClass="Labels" runat="server" Text="GaurdRequirment "></asp:Label></td>
            <td><asp:TextBox ID="txtgaurdreq" CssClass="Input" runat="server"></asp:TextBox></td>
            
            </tr>
            <tr>
                <td><asp:Label ID="lbldutyforgaurd" CssClass="Labels" runat="server" Text="Any Special duty For Gaurd"></asp:Label></td>
                <td><asp:TextBox ID="txtdutygaurd" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblperson" CssClass="Labels" runat="server" Text="Person Incharge Contect Detail" Font-Bold="true"></asp:Label></td>
                <td>&nbsp;</td>
                <td></td>
            </tr>
            <tr>
            <td><asp:Label ID="lblEnterName" CssClass="Labels" runat="server" Text="Name"></asp:Label></td>
               <td><asp:TextBox ID="txtCountry" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            
            </tr>
            
            <tr> 
            <td><asp:Label ID="lblEnternpir" CssClass="Labels" runat="server" Text="NRIC/FINNO"></asp:Label></td>
             <td> 
                 <asp:TextBox ID="txtMobNo" CssClass="Input" runat="server"></asp:TextBox>
                </td>   
            
            </tr>
            <tr>
                <td><asp:Label ID="lblEnterPosition" CssClass="Labels" runat="server" Text="Position"></asp:Label></td>
                <td><asp:TextBox ID="txtPosition" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEnterContactno" CssClass="Labels" runat="server" Text="ContactNo"></asp:Label></td>
                <td><asp:TextBox ID="txtFax" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblsuperior" CssClass="Labels" runat="server" Text="Name Of Superior"></asp:Label></td>
                <td><asp:TextBox ID="txtEmail" CssClass="Input" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            
            <tr>
            
                <td align="right"><asp:Button ID="cmdbuttonadd" CssClass="Buttons" runat="server" Text="Add" Width="100px" onclick="btnNewUserAdd_Click"/> </td>
            
          
                
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
