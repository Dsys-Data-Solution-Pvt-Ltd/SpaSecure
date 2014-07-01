<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="checkOut.aspx.cs" Inherits="SMS.SMSUsers.checkOut" Title="Check Out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
  <div class="divContainer">
      <div class="divHeader">
        <table>
         <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" CssClass="LnkButton" runat="server" onclick="LinkButton1_Click" 
                Font-Underline="false">Check Out Guard</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" CssClass="LnkButton" runat="server" onclick="LinkButton2_Click"
                 Font-Underline="false">Check Out Visitors</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" CssClass="LnkButton" runat="server" onclick="LinkButton3_Click"
                 Font-Underline="false">Check Out Contractor</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
            </td>
            <td>
                <asp:LinkButton ID="LinkButton4" CssClass="LnkButton" runat="server" onclick="LinkButton4_Click"
                 Font-Underline="false">Check Out Staff</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
            </td>
          </tr>
        </table>   
      </div> 

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table align="left">
                 <tr align="left">
                    <td colspan="4" align="left"><span class="pageTitle">Check Out Guards</span></td>                    
                </tr>
                <tr>
                    <td>          
                    </td>
                    <td>
                        <asp:Button ID="btnHistory1" CssClass="Buttons" runat="server" Text="Display History" />
                    </td>
                    <td >  
                        <asp:Button ID="btnItemToDiclear1" CssClass="Buttons" runat="server" Text="Item To Declare" />         
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
                      <asp:Label ID="lblID1" CssClass="Labels" runat="server" Text="Guard ID"></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtID1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                      <asp:Label ID="lblTeleNo1" CssClass="Labels" runat="server" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtTeleNo1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName1" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblRemarks1" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>  <td>  
                    </td>            
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress1" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtAddress1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                        <asp:Label ID="lblVehicelNo1" CssClass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicle1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblcompanyfrom1" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtCompanyFrom1" CssClass="Input" runat="server"></asp:TextBox>
                      
                    </td>
                    <td>
                       <asp:Label ID="lblKeyNo1" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtKeyNo1" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>  
                    </td>
                </tr>
                <tr>
                   <td>
                     <asp:Label ID="lblGoingTo1" CssClass="Labels" runat="server" Text="To Visit"></asp:Label></td>
                   <td>
                      <asp:TextBox ID="txtToVisit1" CssClass="Input" runat="server"></asp:TextBox>
                   </td>
                   <td>
                      <asp:Label ID="lblPassNo1" CssClass="Labels" runat="server" Text="Pass No"></asp:Label>
                   </td>
                   <td>
                      <asp:TextBox ID="txtPassNo1" CssClass="Input" runat="server"></asp:TextBox>
                   </td>
                   <td>  
                   </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear1" CssClass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear1_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckOut1" cssclass="Buttons" runat="server"  
                            Text="Check Out" onclick="AddCheckOutGuard"   />
                    </td> 
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload1" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>                   
                </tr>
            </table>
        </asp:View>
        
        <asp:View ID="View2" runat="server">
            <table align="left">
                <tr align="left">
                    <td colspan="4" align="left"><span class="pageTitle">Check Out Visitors</span></td>                    
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:Button ID="btnHistory2" CssClass="Buttons" runat="server" Text="Display History" />
                    </td>
                 
                    <td>
                        <asp:Button ID="btnItemToDiclare2" CssClass="Buttons" runat="server" Text="ItemToDeclare" />
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
                       <asp:Label ID="lblVisitorID2" CssClass="Labels" runat="server" Text="Visitor ID#"></asp:Label>
                    </td>
                    <td >
                       <asp:TextBox ID="txtNricID2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblTeleNo2" CssClass="Labels" runat="server" Text="Tele. No."></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtTeleNo2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td >
                    </td>                         
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblVisitorPurpose2" CssClass="Labels" runat="server" Text="Purpose"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtVisitorPurpose2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                       <asp:Label ID="lblRemarks2" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                     <td >
                    </td>   
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblName2" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtName2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblVehicleNo2" CssClass="Labels" runat="server" Text="Vehicle No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleNo2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblAddress2" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtAddress2" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td>
                      <asp:Label ID="lblKeyNo2" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtKeyNo2" CssClass="Input" runat="server"></asp:TextBox>
                    </td> 
                    <td >
                    </td>                  
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblCompanyFrom2" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtCompanyFrom2" CssClass="Input" runat="server"></asp:TextBox>
                       
                    </td>
                    <td>
                      <asp:Label ID="lblPassNo2" CssClass="Labels" runat="server" Text="Pass No"></asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtPassNo2" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblToVisit2" CssClass="Labels" runat="server" Text="To Visit"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="txtToVisit2" CssClass="Input" runat="server"></asp:TextBox>
                      
                    </td>
                    <td colspan="2" >
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear2" CssClass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear2_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckOut2" CssClass="Buttons" runat="server" 
                            Text="Check Out" onclick="AddCheckOutVisitor" />
                    </td>
                    <td >
                    </td> 
                    <td>
                        <asp:Button ID="btnUpload2" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>                   
                </tr>
            </table>
        </asp:View>
        
        <asp:View ID="view3" runat="server">
            <table align="left" >
                <tr>
                    <td colspan="4" align="left"><span class="pageTitle">Check Out Contractor</span></td>                    
                </tr>
                <tr>
                   <td>
                   </td>
                   <td>
                      <asp:Button ID="btnHistory3" CssClass="Buttons" runat="server" Text="Display History" />
                   </td>
                   <td>
                      <asp:Button ID="btnitemToDeclear3" CssClass="Buttons" runat="server" Text="Item To Declare" />
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
                       <asp:Label ID="lblContractorID3" CssClass="Labels" runat="server" Text="Contract ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNricID3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>                    
                    <td>
                        <asp:Label ID="lblTeleNo3" CssClass="Labels" runat="server" Text="Tele. No."></asp:Label>
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
                        <asp:Label ID="lblPassType3" CssClass="Labels" runat="server" Text="Pass No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassType3" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnClear3" CssClass="Buttons" runat="server" Text="Clear" 
                            onclick="btnClear3_Click" />
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnCheckOut3" runat="server" CssClass="Buttons" Text="Check Out" onclick="AddCheckOutSaleman"/>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload3" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>                    
                </tr>
            </table>
        </asp:View>
        
        <asp:View ID="view4" runat="server">
            <table align="left">
                <tr>
                    <td colspan="4" align="left"><span class="pageTitle">Check Out Staff</span></td>                    
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnHistory4" CssClass="Buttons" runat="server" Text="Display History" />
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
                      <asp:Label ID="lblPassType4" CssClass="Labels" runat="server" Text="Pass No"></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="txtPassType4" CssClass="Input" runat="server"></asp:TextBox>
                    </td>
                </tr>              
                <tr>
                   <td colspan="2" align="right">
                      <asp:Button ID="btnClear4" CssClass="Buttons" runat="server" Text="Clear" 
                           onclick="btnClear4_Click" />
                   </td>
                   <td colspan="2" align="left">
                       <asp:Button ID="btncheckOut4" CssClass="Buttons" runat="server" Text="Check Out" onclick="AddCheckOutSaleman"/>
                    </td> 
                    <td>
                    </td> 
                    <td>
                        <asp:Button ID="btnUpload4" CssClass="Buttons" runat="server" Text="Upload" />
                    </td>             
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
  </div>
    <br />
</asp:Content>
