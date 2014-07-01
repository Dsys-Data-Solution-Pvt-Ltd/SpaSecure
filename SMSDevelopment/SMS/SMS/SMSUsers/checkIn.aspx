<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="checkIn.aspx.cs" Inherits="SMS.SMSUsers.checkIn" Title="Check In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
      <div class="divHeader">
        <table>
            <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" CssClass="LnkButton" runat="server"  
                  Font-Underline="false" onclick="LinkButton1_Click">Check In Guard</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp</td>
            <td>
                <asp:LinkButton ID="LinkButton2" CssClass="LnkButton" runat="server" onclick="LinkButton2_Click" 
                   Font-Underline="false">Check In Visitors</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp</td>
            <td>
                <asp:LinkButton ID="LinkButton3" CssClass="LnkButton" runat="server" onclick="LinkButton3_Click" 
                Font-Underline="false">Check In Contractor</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp</td>
                    
            <td>
              <asp:LinkButton ID="LinkButton5" CssClass="LnkButton" runat="server"  
                Font-Underline="false" onclick="LinkButton5_Click">Check In Staffs</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp</td>
        </tr>
        </table>   
      </div> 
   
    <asp:MultiView ID="MultiView1" runat="server">
    
        <asp:View ID="View1" runat="server">
       <table align="left">
                <tr align="left">
                    <td colspan="2" align="left"><span class="pageTitle">Check In Guards</span></td>                    
                </tr>
                <tr>
                        <td><br />
                
                            <asp:Button ID="btnprintthumb" runat="server" cssclass="Buttons" 
                                Text="Thumb Print" />
                        </td>
                        <td><br />
                            <asp:Button ID="btnscan" runat="server" cssclass="Buttons" 
                                Text="Scan ID" onclick="btnscan_Click" />
                        </td>
                 </tr>
               <tr>
                 </tr>
                 
                 
         </table>
          <%--  <table align="center" >
                <tr align="center">
                    <td colspan="4" align="center"><span class="pageTitle">Check In Guards</span></td>                    
                </tr>
                <tr>
                    <td>          
                    </td>
                    <td>
                        <asp:Button ID="btnThumbPrint" cssclass="Buttons" runat="server" Text="Thumb Print" />
                    </td>
                    <td  >  
                        <asp:Button ID="btnScanid" cssclass="Buttons" runat="server" Text="Scan ID" />         
                    </td>
                    <td>  
                    </td>
                    <td>  
                    </td>
                    <td rowspan="6">
                        <asp:Image ID="Image1" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td>
                      <asp:Label ID="lblID1" cssclass="Labels" runat="server" Text="Gaurd ID"></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtID1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                      <asp:Label ID="lblTeleNo1" cssclass="Labels" runat="server" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtTeleNo1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName1" cssclass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblRemarks1" cssclass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>  <td>  
                    </td>            
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress1" cssclass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtAddress1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                        <asp:Label ID="lblVehicelNo1" cssclass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleNo1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblcompanyfrom1" cssclass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtCompanyFrom1" cssclass="Input" runat="server"></asp:TextBox>
                      
                    </td>
                    <td>
                       <asp:Label ID="lblKeyNo1" cssclass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtKeyNo1" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
              
                <tr>
                  
                   <td>
                     <asp:Label ID="lblGoingTo1" cssclass="Labels" runat="server" Text="To Visit"></asp:Label></td>
                   <td>
                      <asp:TextBox ID="txtToVisit1" cssclass="Input" runat="server"></asp:TextBox>
                      
                   </td>
                   <td>
                      <asp:Label ID="lblPassNo1" cssclass="Labels" runat="server" Text="Pass Type"></asp:Label>
                   </td>
                   <td>
                      <asp:TextBox ID="txtPassNo1" cssclass="Input" runat="server" ReadOnly="true"></asp:TextBox>
                   </td>
                   <td>  
                    </td>
                    
                </tr>
            
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear1" cssclass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear1_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckIn1" cssclass="Buttons" runat="server" Text="Check In" onclick="AddCheckInGuard" />
                    </td> 
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload1" cssclass="Buttons" runat="server" Text="Upload" />
                    </td>                   
                </tr>
            </table>--%>
        </asp:View>
        
        <asp:View ID="View2" runat="server">
            <table align="left">
                <tr align="left">
                    <td colspan="4" align="left"><span class="pageTitle">Check In Visitors</span></td>                    
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:Button ID="btndisplayHistory2" cssclass="Buttons" runat="server" Text="Display History" />
                    </td>
                 
                    <td>
                        <asp:Button ID="btnItemToDiclare2" cssclass="Buttons" runat="server" Text="ItemToDeclare" />
                    </td>
                    <td >
                    </td>
                    <td >
                    </td>
                    <td rowspan="6">
                       <asp:Image ID="Image2" runat="server" Width="150px" />
                    </td>                     
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblVisitorID2" cssclass="Labels" runat="server" Text="NRIC/FIN No"></asp:Label>
                    </td>
                    <td >
                       <asp:TextBox ID="txtNricID2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblTeleNo2" cssclass="Labels" runat="server" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtTeleNo2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td >
                    </td>                         
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblVisitorPurpose2" cssclass="Labels" runat="server" Text="Purpose"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtVisitorPurpose2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                       <asp:Label ID="lblRemarks2" cssclass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                     <td >
                    </td>   
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblName2" cssclass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtName2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblVehicleNo2" cssclass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleNo2" cssclass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblAddress2" cssclass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtAddress2" cssclass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                      <asp:Label ID="lblKeyNo2" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtKeyNo2" cssclass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td >
                    </td>                  
                </tr>
               
                <tr>
                    <td>
                       <asp:Label ID="lblCompanyFrom2" cssclass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtCompanyFrom2" cssclass="Input" runat="server"></asp:TextBox>
                       
                    </td>
                    <td>
                      <asp:Label ID="lblPassNo2" cssclass="Labels" runat="server" Text="Pass Type"></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtPassNo2" cssclass="Input" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td >
                    </td>
                </tr>
              
                <tr>
                    <td>
                       <asp:Label ID="lblToVisit2" cssclass="Labels" runat="server" Text="To Visit"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtToVisit2" cssclass="Input" runat="server"></asp:TextBox>
                      
                    </td>
                    <td colspan="2" >
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear2" cssclass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear2_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckIn2" cssclass="Buttons" runat="server" Text="Check In" onclick="AddCheckInVisitor" />
                    </td>
                    <td >
                    </td> 
                    <td>
                        <asp:Button ID="btnUpload2" cssclass="Buttons" runat="server" Text="Upload" />
                    </td>                   
                </tr>
            </table>
        </asp:View>
        
        <asp:View ID="view3" runat="server">
            <table align="left" >
                <tr>
                    <td colspan="4" align="left"><span class="pageTitle">Check In Contractor</span></td>                    
                </tr>
                <tr>
                   <td>
                   </td>
                   <td>
                      <asp:Button ID="btnDisplayHistory3" cssclass="Buttons" runat="server" Text="Display History" />
                   </td>
                   <td>
                      <asp:Button ID="btnitemToDeclear3" cssclass="Buttons" runat="server" Text="Item To Declare" />
                   </td> 
                   <td>
                   </td> 
                   <td>
                   </td> 
                   <td rowspan="6">
                       <asp:Image ID="Image3" runat="server" Width="150px" />
                   </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblContractorID3" cssclass="Labels" runat="server" Text="NRIC/FIN No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNricID3" cssclass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                        <asp:Label ID="lblTeleNo3" cssclass="Labels" runat="server" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTeleNo3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName3" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblRemarks3" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtRemarks3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress3" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress3" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:Label ID="lblVehicleNo3" CssClass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleNo3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                   
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblCompanyfrom3" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyfrom3" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:Label ID="lblKeyNo3" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyNo3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblServingAt1" CssClass="Labels" runat="server" Text="Serving At/Workstation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServingAt1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPassType3" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassType3" CssClass="Input" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                   
                </tr>

                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear3" CssClass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear3_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckIn3" runat="server" CssClass="Buttons" Text="Check In" onclick="AddCheckInContractor" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload3" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>                    
                </tr>
            </table>
        </asp:View>
        
        <asp:View ID="View4" runat="server">
            <table align="left">
                <tr>
                    <td colspan="3" align="left"><span class="pageTitle">Check In Salesman</span></td>                    
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnDisplayHistory4" CssClass="Buttons" runat="server" Text="Display History" />
                    </td>
                    <td>
                        <asp:Button ID="btnitemToDeclear4" CssClass="Buttons" runat="server" Text="Item To Declare" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td rowspan="6">
                        <asp:Image ID="Image4" runat="server" Width="150px"/>
                    </td>
                </tr>
                <tr>  
                    <td>
                        <asp:Label ID="lblId4" runat="server" CssClass="Labels" Text="Salesman ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalesmanID4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblTeleno4" runat="server" CssClass="Labels" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTeleNo4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName4" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblRemarks4" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtRemarks4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress4" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress4" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:Label ID="lblVehicleNo4" CssClass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleNo4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                   
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblCompanyfrom4" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyfrom4" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                        <asp:Label ID="lblKeyNo4" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyNo4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                      <asp:Label ID="lblToVisit4" CssClass="Labels" runat="server" Text="To Visit"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToVisit4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                      <asp:Label ID="lblPassType4" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="txtPassType4" CssClass="Input" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>              

                <tr>
                   
                   <td colspan="2" align="right">
                      <asp:Button ID="btnClear4" CssClass="Buttons" runat="server" Text="Clear" 
                           onclick="btnClear4_Click" />
                   </td>
                   <td colspan="2" align="left">
                       <asp:Button ID="btncheckin4" CssClass="Buttons" runat="server" Text="Check In" onclick="AddCheckInSalesman"  />
                    </td> 
                    <td>
                    </td> 
                    <td>
                        <asp:Button ID="btnUpload4" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>             
                </tr>
            </table>
        </asp:View> 
            
         <asp:View ID="view5" runat="server">
            <table align="left">
                <tr>
                    <td colspan="4" align="left"><span class="pageTitle">Check In Staffs</span></td>                    
                </tr>
                <tr>
                    <td><asp:Label ID="lblStaffID5" CssClass="Labels" runat="server" Text="NRIC/FIN No"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtStaffID5" CssClass="Input" runat="server"></asp:TextBox></td>                    
                    <td>
                        <asp:Button ID="btnDisplayHistory5" CssClass="Buttons" runat="server" Text="Display History" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblName5" CssClass="Labels" runat="server" Text="Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtName5" CssClass="Input" runat="server"></asp:TextBox></td>
                    <td><asp:Label ID="lblTeleNo5" CssClass="Labels" runat="server" Text="Direct Line/Extn"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTeleNo5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblAddress5" CssClass="Labels" runat="server" Text="Department Name"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAddress5" CssClass="Input" runat="server"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear5" CssClass="Buttons" runat="server" Text="Clear" /></td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckIn5" runat="server" CssClass="Buttons" Text="Check In" /></td>                    
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </div>
    <br />
</asp:Content>
