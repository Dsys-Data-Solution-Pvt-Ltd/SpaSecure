<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ThumbPersonDigital.aspx.cs" Inherits="SMS.ADMIN.ThumbPersonDigital"%>
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
            //document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "none";
            //document.getElementById("ctl00_ContentPlaceHolder1_tblThumbInfo").style.display = "none";
        }

        function ShowManualPortion() {
            document.getElementById("VerificationControl").style.display = "none";
            //document.getElementById("tblEntry").style.display = "";
            document.getElementById("Menus").style.display = "none";
        }

        function ShowMenu() {
            document.getElementById("VerificationControl").style.display = "none";
            //document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "";
        }
    </script>


 <div class="divContainer">
   <div>
         <asp:Label ID="lblerror" runat="server" Text=" "></asp:Label>
   </div>
    <br />
        <div>
                
                 <table id="Menus" width="100%" class="table" style=" background-color:White">
                 <tr><td></td></tr> 
                        <tr>                                           
                             <td>
                                <asp:Label ID="lbllocation" Text="Location" CssClass="Labels" 
                                      runat="server" style=" margin:3em; font-size:18px" Visible="False"></asp:Label>&nbsp;&nbsp;
                            
                                 <asp:DropDownList ID="ddllocation" runat="server" Visible="False" CssClass="Labels" Width="200px">
                                 </asp:DropDownList>
                                 <asp:Label ID="SearchLocID" runat="server" Visible="False" CssClass="Input"></asp:Label>
                              </td>
                        </tr> 
                        <tr><td></td></tr> 
                          <tr><td></td></tr> 

                        <tr>
                            <td>
                               <asp:Label ID="Label1" runat="server" CssClass="Labels" Font-Bold="True" Text="Check In by Thumb Print" style=" margin-left:3em"></asp:Label>
                            </td>
                       </tr>
                       <tr>
                           <td>                                            
                               <img alt="Thumb Print" src="../Images/thumbphoto.jpg" style="width: 100px; height: 100px;cursor:pointer" style=" margin-left:3em" onclick="ShowVerificationPortion();"  />
                          </td>
                      </tr>
                </table>
                <div id="VerificationControl" style="display:none; margin-left:3em; background-color:White">
                            <object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
                            </object>
                            <asp:Button ID="btnThumbCheckIn" runat="server" Text="" style="display:none" Width="0" onclick="btnThumbCheckIn_Click" />
                            <br />
                            <br />
                 </div>               
        </div>
   </div>     
</asp:Content>
