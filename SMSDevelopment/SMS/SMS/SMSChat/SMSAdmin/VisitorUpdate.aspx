<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="VisitorUpdate.aspx.cs" Inherits="SMS.SMSAdmin.VisitorUpdate" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript"  type="text/javascript">
    function showBrowse(pFile, idx)
    {
        document.getElementById("ctl00_ContentPlaceHolder1_Image3").src=pFile;
    }
</script>


<div class="divContainer">
  <div class="divHeader">
        <span class="pageTitle">Visitor Update</span></div>
         <div id="divErr" runat="server">
                        <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
          </div>
      <br />    
          
        <table id="tblMain" width="80%">
            <tr>
                <td class="style1">
                   
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" 
                        onvaluechanged="hdnBTID_ValueChanged" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" 
                        onvaluechanged="hdnBTName_ValueChanged" />
                </td>
            </tr>
            <tr>
                <td>
                  

                       <table align="left" width="600px">
                               
                                
                                <tr>
                                        <td align="left">
                                           <asp:Label ID="lblVisitorID2" cssclass="Labels" runat="server" 
                                                Text="NRIC / FIN No."></asp:Label>
                                        </td>
                                        
                                        <td class="style4">
                                           <asp:TextBox ID="txtNricID2" cssclass="Input" runat="server" BackColor="#E2E2E2" 
                                                ReadOnly="True"></asp:TextBox> 
                                         </td>                                              
                                        <td align="left">
                                            <asp:Label ID="lblName2" cssclass="Labels" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td class="style3">
                                             <asp:TextBox ID="txtName2" cssclass="Input" runat="server"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>        
                                        <td align="left">
                                            <asp:Label ID="lblAddress2" cssclass="Labels" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress2" cssclass="Input" runat="server"></asp:TextBox>
                                        </td> 
                                        <td align="left">
                                           <asp:Label ID="lblTeleNo2" cssclass="Labels" runat="server" Text="Phone No."></asp:Label>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtTeleNo2" cssclass="Input" runat="server"></asp:TextBox>
                                        </td>
                                                       
                               </tr>
                                <tr>
                                     <td align="left">
                                        <asp:Label ID="lblPassNo" cssclass="Labels" runat="server" Text="Pass No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassNo2" cssclass="Input" runat="server"></asp:TextBox>
                                    </td>
                                     <td align="left">
                                        <asp:Label ID="lblPassType2" cssclass="Labels" runat="server" Text="Pass Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList cssclass="Input" Id="cmbvisitorPass" runat="server" 
                                            onselectedindexchanged="cmbvisitorPass_SelectedIndexChanged" Width="136px" 
                                            Height="40px">
                                         </asp:DropDownList>
                                    </td>
                              
                              
                                </tr>
                                <tr>
                                         <td align="left">
                                            <asp:Label ID="lblKeyNo2" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeyNo2" cssclass="Input" runat="server"></asp:TextBox>                                     
                                        </td> 
                                         <td align="left">
                                            <asp:Label ID="lblVehicleNo2" cssclass="Labels" runat="server" Text="Vehicle No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVehicleNo2" cssclass="Input" runat="server"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                       <asp:Label ID="lblCompanyFrom2" cssclass="Labels" runat="server" Text="Company From"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:TextBox ID="txtCompanyFrom2" cssclass="Input" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                       <asp:Label ID="lblToVisit2" cssclass="Labels" runat="server" Text="To Visit"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:TextBox ID="txtToVisit2" cssclass="Input" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td align="left">
                                       <asp:Label ID="lblVisitorPurpose2" cssclass="Labels" runat="server" Text="Purpose"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:TextBox ID="txtVisitorPurpose2" cssclass="Input" runat="server"></asp:TextBox>                                     
                                    </td>      
                                     <td align="left">
                                        <asp:label id="lblItemDeclear" cssclass="Labels" runat="server" text="Item DeClaration"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtItemDeclear2" cssclass="Input" runat="server"></asp:TextBox>
                                    </td>
                                
                                
                                </tr>
                                   <tr>
                                             <td align="left">
                                                  <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="In Time"></asp:Label>
                                             </td>
                                             <td>
                                                            <asp:TextBox runat="server" ID="calDateOfIncident" Text="" CssClass="Input" 
                                                                ontextchanged="calDateOfIncident_TextChanged" />
                                              &nbsp;       
                                                          <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate" />
                                                            <asp:ImageButton ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp" onclick="imgBtnFromDate_Click" 
                                                                style="width: 16px" />
                                             </td>
                                             <td align="left">
                                                       <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="Out Time"></asp:Label>
                                             </td>
                                             <td>
                                                            <asp:TextBox runat="server" ID="calDateOfIncident1" Text="" CssClass="Input" 
                                                                ontextchanged="calDateOfIncident_TextChanged" />
                                             
                                                    &nbsp;
                                                            <AJAX:CalendarExtender ID="CalendarExtender" runat="server" CssClass="AjaxCalendar"
                                                                Format="MM/dd/yyyy" TargetControlID="calDateOfIncident" PopupButtonID="imgBtnFromDate1" />
                                                            <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" 
                                                                ImageUrl="~/Images/calendar.bmp" onclick="imgBtnFromDate1_Click" />
                                             </td>
                                             
                                        </tr>
                                <tr>
                                                  
                                    <td valign="top" align="left">
                                       <asp:Label ID="lblRemarks2" cssclass="Labels" runat="server" Text="Remarks"></asp:Label>
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtRemarks2" cssclass="Input" runat="server" Height="85px" 
                                            TextMode="MultiLine" Width="411px"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                
                                  
                               
                           
                                <tr>
                                    <td>
                                        <asp:Label ID="out_no" runat="server" Visible="False" CssClass="Labels" ></asp:Label>
                                    </td>
                                     <td height="15px" class="style4">
                                        <asp:Label ID="txtrole" runat="server" Visible="False" CssClass="Labels" ></asp:Label>
                                    </td>
                                    <td width="110px"></td>
                                     <td></td>
                                </tr>
                                <tr>
                                      <td width="110px">
                                      
                                      
                                      </td>
                                
                                </tr>
                                
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnsave" cssclass="Buttons" runat="server" Text="Save" 
                                            onclick="AddCheckInVisitor" Width="85px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:button id="btnback" cssclass="Buttons" runat="server" text="View All" 
                                            onclick="btnback_Click" Width="85px" />
                                   
                                    
                                        
                                    </td>
                                                 
                                </tr>
                            </table>
                  
                </td>
                <td colspan="2" rowspan="3" valign="top">
                            <asp:Panel runat="server" Height="196px" 
                                                 Weight="300px">
                                                      <table>
                                                   
                                                   <tr>
                                                       <td>
                                                          <asp:Image ID="Image3" runat="server" Width="173px" Height="150px" 
                                                               ImageUrl="~/ImageUpload/SearchIcon.jpg" />
                                                       </td>
                                                     </tr>
                                                   <tr>
                                                       <td valign="top">
                                                          <asp:Label runat="server" Text="Capture Image" cssclass="Labels"></asp:Label>
                                                           &nbsp;
                                                          <asp:FileUpload runat="server" cssclass="Labels" ID="FileUpload1"  onchange="javascript:showBrowse(this.value,0);" accept="gif|jpeg|png|jpg" maxlength="5"></asp:FileUpload>
                                                        </td>
                                                   </tr>
                                                   
                                                   </table>
                                 </asp:Panel>
                
                
                </td>
            </tr>
        </table>
        <br />
      </div>
</asp:Content>
