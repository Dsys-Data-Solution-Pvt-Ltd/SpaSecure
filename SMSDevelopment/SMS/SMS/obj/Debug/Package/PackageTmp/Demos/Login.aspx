<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMS.Demos.Login" %>

<%@ Register Src="FingerPrint.ascx" TagName="FingerPrint" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
      <form id="form1" method="post" action="./Login.aspx"  runat="server">
    <uc1:FingerPrint  ID="UserIdentity1" ButtonValue="Register" runat="server" />
    </form>
    
    <object id="DPFPVerify" style="display: none;"  classid="clsid:F4AD5526-3497-4B8C-873A-A108EA777493">
    </object>
    <script type="text/vbscript">
    ' Start to capture fingerprints.  Instruct the user.
    Sub Submit
        ' If the hidden field DOM element is not found, the user is not running within Visual Studio with IE.
        If document.getElementById("UserIdentity1_HiddenField2") Is Nothing Then
            SendMessage("Error.  Please make sure you are using IE 7+, and you are running within Visual Studio 2005+.")
            Exit Sub
        End If

        If document.getElementById("UserIdentity1_HiddenField1").value <> "" And document.getElementById("ctl00_ContentPlaceHolder1_UserIdentity1_Label3").innerHTML <> "Login Failed." And document.getElementById("UserIdentity1_Label3").innerHTML <> "Login Successful." Then
            aspnetForm.submit()
        Else
            SendMessage("Please put a registered finger on the fingerprint reader.")
            DPFPVerify.Active = true
            DPFPVerify.style.display = "block"   
        End If        
    End Sub

    ' Fired by the reader when a Sample is ready.  
    Sub DPFPVerify_OnComplete(featureSet, status)
        ' Save the featureset into the form, stop capture and submit.
        document.getElementById("UserIdentity1_HiddenField1").value = OctetToHexStr(featureSet.Serialize)
        DPFPVerify.style.display = "none"      
        aspnetForm.submit
    End Sub
    </script>
</body>
</html>
