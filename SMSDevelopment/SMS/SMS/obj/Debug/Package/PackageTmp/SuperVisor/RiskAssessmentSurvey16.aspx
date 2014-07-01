<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey16.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey16"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Security/ Risk Assessment Survey</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                                                    
                       <table width="80%" class="table" cellspacing="5" style=" background-color:White;"> 
                                           
                                           
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
                                                <td colspan="4">                                                                                                         
                                                    <asp:TextBox ID="txtXNote" runat="server" CssClass="Input" Width="90%" 
                                                        Height="400px" TextMode="MultiLine"></asp:TextBox>
                                                </td> 
                                                
                                          </tr>
                                           
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label1" Text="Comments/Actions Taken/Recommendations:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>   
                                                <td colspan="4">                                                                                                         
                                                    <asp:TextBox ID="txtXComments" runat="server" CssClass="Input" Width="90%" 
                                                        Height="400px" TextMode="MultiLine"></asp:TextBox>
                                                </td> 
                                                
                                          </tr>
                                          
                                           
                                         
                                         
                                          
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                                          
                                          
                                          
                                          
                            </table>    
                                           
                       <br />
                       <br />
                                    
                               <table width="100%" class="table" style=" margin-top:-2.2em; background: url(../Images/1397d40aa687.jpg); height:2.2em">       
                                            
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="End of Survey" onclick="btnItemAdd_Click"/>
                                                        
                                                        <asp:Label ID="lblid" runat="server" Text="" Visible="False"></asp:Label>  
                                                        
                                                   <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px"/>--%>
                                                </td>
                                            </tr>
                                 </table>
                           <br />
                    </div>
    </div>


</asp:Content>
