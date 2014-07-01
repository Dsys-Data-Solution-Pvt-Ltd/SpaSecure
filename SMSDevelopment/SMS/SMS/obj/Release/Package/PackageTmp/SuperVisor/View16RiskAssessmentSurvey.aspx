<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View16RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View16RiskAssessmentSurvey"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Risk Assessment Survey</span></div>  
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
         
                 <table width="100%" cellspacing="8" class="table" style=" background-color:White">
                                           <tr>
                <td colspan="4" style=" height:90px;" align="center">
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                </td>
                </tr>  
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label26" Text="Section X. OTHER" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="Please note any other high-risk situations, unusual activity or other issues observed during the review." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>   
                                                <td colspan="4" height="200" valign="top">                                                                                                         
                                                    <asp:Label ID="PleaseNote" runat="server" CssClass="Labels"></asp:Label>
                                                </td> 
                                                
                                          </tr>
                                           
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label1" Text="Comments/Actions Taken/Recommendations:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>   
                                                <td colspan="4" height="200" valign="top">                                                                                                         
                                                    <asp:Label ID="Comments" runat="server" CssClass="Labels"></asp:Label>
                                                </td> 
                                                
                                          </tr>
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                            </table>    
       
           </asp:Panel>
           
      <table width="738px" style="margin-left:1.5em; height:2.2em; margin-bottom:-0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                    <td>
            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" style="margin-left:18em"
                Width="110px" Height="35px" Font-Bold="True" onclick="btnprint_Click"/> 
            <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>                      
       </td>
                       
    </tr>
     </table>     
        <br />   
           
     </div>
  </div>
</asp:Content>
