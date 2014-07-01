<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="SOPUpdate.aspx.cs" Inherits="SMS.SMSAdmin.SOPUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">SOP Update</span></div>
        <div id="divErr" runat="server">
            <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label>

        </div>
    <asp:Label ID="SOP_ID" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />  
   <div id="divAdvSearch" runat="server" visible="true">
  <asp:panel runat="server" ID="Pnl" BackColor="White" style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True" Width="700px">
            <table width="700px" class="table">
          <tr>
                <td>             
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                </td>
            </tr>
            <tr>
                <td>
                   
                                            <tr  width="15em">
                                                <td height="50px">
                                                    <asp:Label ID="lblEnterSOPNo" Text="SOP No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUpdateSOPNo" runat="server" CssClass="Input" 
                                                        Readonly="True" BackColor="#E2E2E2" />
                                                </td>
                                            </tr>
                                            <tr>                                                 
                                                 <td height="50px">
                                                    <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                                </td>
                                               <td height="50px">
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" 
                                                        Width="120px">
                                                    </asp:DropDownList>
                                                </td>
                                           
                                                <td height="50px">
                                                    <asp:Label ID="lblSOPTitle" Text="Title" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUpdateSOPTitle" runat="server" CssClass="Input" />
                                                </td>
                                                
                                          </tr>
                                          <tr>      
                                                <td height="50px">
                                                    <asp:Label ID="lblSOPSubject" Text="Subject" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUpdateSOPSubject" runat="server" CssClass="Input" />
                                                </td>
                                                <td height="50px">
                                                    <asp:Label ID="lblImagePathName" Text="SOP File" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <%--<asp:FileUpload ID="txtImagePath" runat="server" accept="gif|jpeg|png|jpg" 
                                                        CssClass="Input" maxlength="5" onchange="showBrowse(this.value,0);" />--%>
                                                        <asp:FileUpload ID="txtImagePath" runat="server" accept="gif|jpeg|png|jpg" 
                                                        CssClass="Input" maxlength="5"/>
                                                </td>    
                                         </tr>
                                         <tr>
                                                <td height="180px" width="55px">
                                                    <br />
                                                </td>
                                         </tr>
                                         </table>
                                         <table  width="700px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                                <td colspan="4" align="center" width=" 700px">
                  <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" 
                      OnClick="btnSave_Click" Width="85px"  style=" margin-left:0.5em"/>
                       &nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" 
                                                        OnClick="btnBack_Click" Width="85px" />                            
                      </td>
                    </tr>
                 </table> 
                                         </asp:panel>
                                         </div> 
        <br />
    
</asp:Content>
