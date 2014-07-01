<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="ViewDigitalDairy.aspx.cs" Inherits="SMS.SMSUsers.ViewDigitalDairy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Digital Dairy Report</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White" style=" margin-left:1.5em" Font-Bold="True">
                <table width="100%" cellspacing="10">
                <tr>
            <td align="center" colspan="4">
                   <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
             </td>
            </tr>
                    <tr>
                        <td align="center" colspan="2" height="40px" valign="top">
                            <asp:Label ID="lblIncidentReport" Text="Digital Dairy Report" CssClass="Labels" runat="server"
                                Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>    
                    <tr>
                        <td>
                            <asp:Label ID="lbldate" CssClass="Labels" runat="server" Text="Date :" 
                                Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>                     
                        <td>
                            <asp:Label ID="txtdate" runat="server" CssClass="Labels" Font-Bold="True" 
                                Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pan1" runat="server" BorderStyle="None">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="lbltime" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txttime" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="lblopenby4" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtName" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="lblopenby5" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtheading" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="lblopenby3" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="txtDescription" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>    
                 <asp:Panel ID="Panel1" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label7" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label8" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel2" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label9" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label11" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label13" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label15" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label16" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel3" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label17" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label19" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label20" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label21" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label23" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label24" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel4" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label25" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label26" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label27" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label28" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label29" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label31" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label32" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel5" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label33" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label34" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label35" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label36" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label37" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label38" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label39" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label40" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel6" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label41" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label42" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label43" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label44" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label45" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label46" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label47" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label48" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel7" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label49" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label50" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label51" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label52" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label53" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label54" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label55" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label56" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel8" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label57" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label58" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label59" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label60" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label61" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label62" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label63" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label64" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel9" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label65" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label66" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label67" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label68" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label69" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label70" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label71" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label72" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel10" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label73" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label74" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label75" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label76" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label77" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label78" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label79" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label80" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel11" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label81" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label82" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label83" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label84" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label85" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label86" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label87" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label88" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel12" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label89" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label90" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label91" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label92" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label93" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label94" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label95" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label96" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel13" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label97" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label98" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label99" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label100" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label101" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label102" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label103" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label104" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel14" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label105" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label106" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label107" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label108" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label109" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label110" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label111" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label112" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel15" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label113" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label114" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label115" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label116" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label117" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label118" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label119" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label120" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel16" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label121" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label122" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label123" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label124" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label125" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label126" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label127" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label128" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel17" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label129" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label130" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label131" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label132" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label133" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label134" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label135" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label136" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel18" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label137" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label138" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label139" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label140" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label141" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label142" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label143" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label144" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel19" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label145" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label146" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label147" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label148" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label149" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label150" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label151" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label152" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel20" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label153" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label154" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label155" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label156" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label157" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label158" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label159" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label160" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel21" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label161" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label162" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label163" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label164" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label165" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label166" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label167" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label168" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel22" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label169" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label170" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label171" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label172" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label173" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label174" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label175" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label176" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
                 <asp:Panel ID="Panel23" runat="server">
                   <table width="50%">
                     <tr>      
                        <td>
                            <asp:Label ID="Label177" CssClass="Labels" runat="server" Text="Time :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label178" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>               
                     <tr>
                        <td>
                            <asp:Label ID="Label179" CssClass="Labels" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label180" runat="server" CssClass="Labels"></asp:Label>
                        </td>                    
                        <td>
                            <asp:Label ID="Label181" CssClass="Labels" runat="server" Text="Heading :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label182" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                    
                     <tr>
                        <td valign="top">
                            <asp:Label ID="Label183" CssClass="Labels" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td colspan="3" height="75" valign="top">
                            <asp:Label ID="Label184" runat="server" CssClass="Labels"></asp:Label>
                        </td>
                    </tr>                   
                   </table>                
                </asp:Panel>  
            </asp:Panel>
            <br />
            <div align="center">
            <asp:panel ID="btnpanel" runat="server" style=" background:url(../../Images/1397d40aa687.jpg); margin-left:1.5em; margin-top:-1em">    
                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="Buttons" Font-Bold="True"
                    Height="25px" Width="100px" OnClick="btnprint_Click" />
                    </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
