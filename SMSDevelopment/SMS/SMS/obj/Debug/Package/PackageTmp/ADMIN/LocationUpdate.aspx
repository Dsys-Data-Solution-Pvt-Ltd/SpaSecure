<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="LocationUpdate.aspx.cs" Inherits="SMS.ADMIN.LocationUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Location Update</span></div>
       <div id="divErr" runat="server">
             <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
             ForeColor="Red"></asp:Label>
      </div> 
       <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
        <asp:HiddenField ID="hdnBTName" runat="server" Value="" /> 
   <br />      
         <asp:Panel id="Panel1" runat="server" style="margin-left:1.5em; width:58em; height:105em">
                 <AJAX:TabContainer ID="TabContainer1" runat="server" Font-Bold="True">
                 <AJAX:TabPanel ID="TabPanel1" HeaderText="New Location" runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
                 <ContentTemplate> 
                  <table width="100%" class="table">
                  <tr>
                       <td>
                          <asp:Label ID="lblEnterLocationCode" Text="Location Code" CssClass="Labels" 
                               runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                           <asp:TextBox ID="txtUpdateLocationName" runat="server" CssClass="Input" 
                            Readonly="True" Visible="False" />
                        </td>
                                    
              </tr>
                                  
              
           
                        <tr>
                            <td>
                                <asp:Label ID="lblEnterLocation" Text="Location Name" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddLocation" runat="server" CssClass="Input" 
                                    Width="380px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblsiteAddress" Text="Address" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsiteaddres" runat="server" CssClass="Input" 
                                        Height="72px" Width="380px" TextMode="MultiLine" />
                                </td>
                        </tr>
                          <tr>
             <td>
                 <asp:Label ID="lblClientUserID" runat="server" CssClass="Labels" Text="Client UserID"></asp:Label>
            </td>
             <td>
                 <asp:TextBox ID="txtClientUserID" runat="server" CssClass="Input" Width="385px" />
            </td>   
     </tr>
    <tr>
    <td>
        <asp:Label ID="lblContractStartDate" CssClass="Labels" runat="server" Text="Start Date:"></asp:Label>
    </td>

                                               
                                               <td>
                                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" ontextchanged="txtdatefrom_TextChanged" 
                                                     ></asp:TextBox>
                                                        
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" 
                                                        PopupButtonID="imgBtnFromDate2" Enabled="True" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                        onclick="imgBtnFromDate2_Click" style="width: 16px" 
                                                    />
                                               </td>
                                                
   </tr>                             
                                                
                                             
                                          
 
 
 
 
 
 <tr>
    <td>
        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Expiry Date:"></asp:Label>
    </td>
    <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" ontextchanged="txtdateto_TextChanged" 
                                                            ></asp:TextBox>
                                                                
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdateto" 
                                                            PopupButtonID="imgBtnFromDate3" Enabled="True" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                          style="width: 16px" onclick="imgBtnFromDate3_Click" />
           </td>
     </tr>
     <tr>
        <td>
            <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Contract Value"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtContractValue" runat="server" CssClass="Input"/>
        </td>
     </tr>     
     <tr>
        <td height="25">       
        </td> 
     </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
<tr>                          
                <td colspan="8">
                  <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Buttons" 
                     OnClick="btnSave_Click" Width="85px" style=" margin-left:204px"/>
                     &nbsp;&nbsp; &nbsp;
                     <asp:Button ID="btnBack" runat="server" Text="View All" CssClass="Buttons" 
                      OnClick="btnBack_Click" Width="85px" />                                                   
                 </td> 
           </tr> 

     </table>
 </ContentTemplate>
 </AJAX:TabPanel> 
<AJAX:TabPanel ID="TabPanel5" HeaderText="Finance Contact" runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
 <table width="100%" class="table">
 <tr>
                            <td>
                                <asp:Label ID="lblFinanceName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtFinaceName" runat="server" CssClass="Input" 
                                      Width="380px" />
                              </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblfinanceContactTel" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtFinanceContactTel" runat="server" CssClass="Input" 
                                   Width="380px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactMob" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFinanceContactMob" runat="server" CssClass="Input" 
                                 Width="380px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFinanceContactEmail" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinanceContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFinanceContactFax" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
                <tr>                          
                <td colspan="8">
                  <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="Buttons" 
                     OnClick="btnSave1_Click" Width="85px" style=" margin-left:159px"/>                                                
                 </td> 
                </tr> 

 </table>   
 </ContentTemplate>
  </AJAX:TabPanel> 
<AJAX:TabPanel ID="TabPanel6" HeaderText="Operation Contact" runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
 <table width="100%" class="table">
<tr>
                            <td>
                                <asp:Label ID="lblOperationName" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtOperationName" runat="server" CssClass="Input" 
                                  Width="380px" />
                              </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactTele" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                   <asp:TextBox ID="txtOperationsContactTelephone" runat="server" CssClass="Input" 
                                    Width="380px" />
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtOperationsContactMobile" runat="server" CssClass="Input" 
                                   Width="380px" />
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOperationsContactEmail" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperationsContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOperationsContactFax" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
 
                 <tr>                          
                <td colspan="8">
                  <asp:Button ID="btnSave2" runat="server" Text="Save" CssClass="Buttons" 
                     OnClick="btnSave2_Click" Width="85px" style=" margin-left:159px"/>                                                
                 </td> 
                </tr> 

</table> 
</ContentTemplate>
 </AJAX:TabPanel>
<AJAX:TabPanel ID="TabPanel7" HeaderText="Management Contact " runat="server" Font-Bold="True" Font-Size="20px" Font-Names="Arial">  
 <ContentTemplate>  
<table width="100%" class="table">
                         <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtManagementName" runat="server" CssClass="Input" 
                                  Width="380px" />
                              </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactTelephone" runat="server" CssClass="Labels" Text="Telephone"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtlblManagementContactTelephone" runat="server" CssClass="Input" 
                                  Width="380px" />
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactMobile" runat="server" CssClass="Labels" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtManagementContactMobile" runat="server" CssClass="Input" 
                                  Width="380px" />
                              </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactEmail" runat="server" CssClass="Labels" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementContactEmail" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManagementContactFax" runat="server" CssClass="Labels" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementContactFax" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
                              <tr>
                            <td>
                              <asp:Label ID="lblEmergencyContactEmail" runat="server" CssClass="Labels" Text="Emergency Contact Email"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmergencyContactEmail" runat="server" CssClass="Input" 
                                    Width="380px" />
                             </td>
                        </tr>
<tr style=" height:4em;"><td></td></tr>
 </table>
 <table  width="101.8%" style="margin-left:-0.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
 
                <tr>                          
                <td colspan="8">
                  <asp:Button ID="btnSave3" runat="server" Text="Save" CssClass="Buttons" 
                     OnClick="btnSave3_Click" Width="85px" style=" margin-left:304px"/>                                                
                 </td> 
                </tr> 
</table>  
</ContentTemplate>
</AJAX:TabPanel>
</AJAX:TabContainer>
</asp:panel>
 
<table width="100%" class="table" visible="false">
<tr>
                            <td><asp:Label ID="lblChiefSecurityOfficer" runat="server" CssClass="Labels" Text="Chief Security Officer Required" visible="false"/></td>
                            <td>
                                <asp:Label ID="lblChiefSecurityRequiredDay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChiefSecurityRequiredDay" runat="server" CssClass="Input" 
                                    Width="77px" visible="false"/>
                            </td>
                            <td>
                                <asp:Label ID="lblChiefSecurityRequiredEvening" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChiefSecurityRequiredEvening" runat="server" 
                                    CssClass="Input" Width="67px" visible="false"/>
                             </td>
                        </tr>
 <tr>
                            <td><asp:Label ID="lblSuperVisorRequired" runat="server" CssClass="Labels" Text="Supervisor Required" visible="false"/></td>
                            <td>
                                <asp:Label ID="lblSuperVisorRequiredDay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsupervisorrequiredDay" runat="server" CssClass="Input" 
                                    Width="75px" visible="false"/>
                             </td>
                                 <td>
                                <asp:Label ID="lblSupervisorRequireNight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSupervisorRequireNight" runat="server" CssClass="Input" 
                                    Width="66px" visible="false"/>
                             </td>
                        </tr>                        
 <tr>
    <td><asp:Label ID="lblSeniorSecurity" runat="server" CssClass="Labels" Text="Senior Security Officer Required" visible="false"/></td>
    <td>
        <asp:Label ID="lblSSO" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TxtSSODay" runat="server" CssClass="Input" 
            Width="75px" visible="false"/>
     </td>
     <td>
        <asp:Label ID="lblSSONight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtSSONight" runat="server" CssClass="Input" 
            Width="66px" visible="false"/>
     </td>
</tr>
 <tr>
    <td><asp:Label ID="Label1" runat="server" CssClass="Labels" Text="Security Officer Required" visible="false"/></td>
    <td>
        <asp:Label ID="lblSODay" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtSODay" runat="server" CssClass="Input" 
            Width="75px" visible="false"/>
     </td>
         <td>
        <asp:Label ID="lblSONight" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtSONight" runat="server" CssClass="Input" Width="66px" visible="false"/>
     </td>
</tr>


<tr>
   <td>
       <asp:CheckBox ID="chkoter" runat="server" Text="Others"
           CssClass="Labels" visible="false"/>
   </td>
</tr>
    <tr>
     <td colspan="6">
             <asp:Panel ID="PnlOther" runat="server">
              <table width="90%">
                   <tr>
                        <td>
                            <asp:TextBox ID="txtOther1" runat="server" CssClass="Input" visible="false"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther1_day" runat="server" CssClass="Input" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther1_nig" runat="server" CssClass="Input" Width="66px" visible="false"/>
                         </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:TextBox ID="txtOther2" runat="server" CssClass="Input" visible="false"></asp:TextBox>
                         </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther2_day" runat="server" CssClass="Input" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label9" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther2_nig" runat="server" CssClass="Input" Width="66px" visible="false"/>
                         </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtOther3" runat="server" CssClass="Input" visible="false"></asp:TextBox>
                         </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="Labels" Text="Day Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther3_day" runat="server" CssClass="Input" 
                                Width="75px" visible="false"/>
                         </td>
                        <td>
                             <asp:Label ID="Label12" runat="server" CssClass="Labels" Text="Night Shift" visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther3_nig" runat="server" CssClass="Input" Width="66px" visible="false"/>
                         </td>
                    </tr>
                  </table>  
          </asp:Panel>
     </td>
  </tr>
 
</table> 
</div>
</asp:Content>
