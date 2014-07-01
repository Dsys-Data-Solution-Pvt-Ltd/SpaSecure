<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ClientVisitThumb.aspx.cs" Inherits="SMS.SuperVisor.ClientVisitThumb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hdnFP" runat="server" />
 <script language="vbscript" type="text/vbscript">
        function DPFPVerificationControl_OnComplete(VerificationFeatureSet, Status)
            document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(VerificationFeatureSet.Serialize)
            document.getElementById("ctl00_ContentPlaceHolder1_btnThumbCheckIn").Click
        End function 
        
        ' Format a byte array to a hex string to be sent to the server.
        Function OctetToHexStr(ByVal arrbytOctet)
            Dim k
            For k = 1 To Lenb(arrbytOctet)
                OctetToHexStr = OctetToHexStr _
                  & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
            Next
        End Function
    </script>
    
    <script type="text/javascript">
        function ShowVerificationPortion()
        {
            document.getElementById("VerificationControl").style.display = "";
            document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_tblThumbInfo").style.display = "none";
        }

        function ShowManualPortion() {
            document.getElementById("VerificationControl").style.display = "none";
            document.getElementById("tblEntry").style.display = "";
            document.getElementById("Menus").style.display = "none";
        }

        function ShowMenu() {
            document.getElementById("VerificationControl").style.display = "none";
            document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "";
        }
    </script>
<div class="divContainer">
  <div>
         <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
  </div>
  <br />

  <div>
                                  <table id="Menus" width="100%">
                                           <tr>
                                            <td align="left" style="margin-left: 80px">
                                            
                                                <asp:Label ID="Label1" runat="server" CssClass="Labels" Font-Bold="True" 
                                                    Text="Verified by Thumb Print"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                            
                                                <img alt="Thumb Print" src="../Images/thumbphoto.jpg" 
                                                    style="width: 100px; height: 100px;cursor:pointer" 
                                                    onclick="ShowVerificationPortion();" align="left" />
                                            </td>                                                    
                                         </tr>
                                      </table>
                           <div id="VerificationControl" style="display:none">
                            <object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
                            </object>
                            <asp:Button ID="btnThumbCheckIn" runat="server" Text="" style="display:none" Width="0" onclick="btnThumbCheckIn_Click" />
                            <br />
                            <br />
                            <table width="500px" id="tblThumbInfo" style="display:none" runat="server">
                                <tr>
                                    <td colspan="2">
                                       <asp:Image ID="UserImage" Height="100px" Width="100px" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%">
                                        <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFin" CssClass="Labels" runat="server" Text=""></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    <asp:Label ID="Label8" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" CssClass="Labels" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPhone" CssClass="Labels" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    <asp:Button ID="btnContinue" CssClass="Buttons" runat="server" 
                                        Text="Proceed To Check In" onclick="btnContinue_Click" />
                                    </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                <a href="#" onclick="ShowMenu();" class="Labels">Go Back To Menu</a>
                                </td>
                            </tr>
                        </table>
                            <a href="#" onclick="ShowMenu();" class="Labels">Go Back To Menu</a>
                        </div> 
                                   
           <br />
   </div>
 </div>
</asp:Content>
