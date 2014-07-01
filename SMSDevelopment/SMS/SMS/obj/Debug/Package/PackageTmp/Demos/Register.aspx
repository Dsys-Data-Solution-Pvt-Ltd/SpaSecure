<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SMS.Demos.Register" %>

<%@ Register Src="FingerPrint.ascx" TagName="FingerPrint" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:FingerPrint  ID="UserIdentity1" ButtonValue="Register" runat="server" />
    </form>
    <object id="DPFPEnrollment" style="display: none;"  classid="clsid:0B4409EF-FD2B-4680-9519-D18C528B265E">
    </object>
    <script type="text/vbscript">
    ' Start to capture fingerprints.  Instruct the user.
    Sub Submit
        ' If the hidden field DOM element is not found, the user is not running within Visual Studio with IE.
        If document.getElementById("UserIdentity1_HiddenField2") Is Nothing Then
            SendMessage("Error.  Please make sure you are using IE 7+, and you are running within Visual Studio 2005+.")
            Exit Sub
        End If

        If document.getElementById("UserIdentity1_HiddenField2").value <> "" Then
            SendMessage("hhh")
            aspnetForm.submit()
        Else
            SendMessage("")
            DPFPEnrollment.style.display = "block"            
            DPFPEnrollment.MaxEnrollFingerCount = 2
        End If        
    End Sub
    
    Sub DPFPEnrollment_OnEnroll(finger, template, status)
            ' If no template has been saved, save the template using serialize and to hex functions, clear the enrollment template, and alert the user.  
            ' If a template has been saved, save the second template, clear the enrollment template, alert the user, then submit the templates.
            If document.getElementById("UserIdentity1_HiddenField1").value = "" Then
               document.getElementById("UserIdentity1_HiddenField1").value = OctetToHexStr(template.Serialize)   
               SendMessage("gggggggggg")
            Else
                SendMessage("ggggg")
                document.getElementById("UserIdentity1_HiddenField2").value = OctetToHexStr(template.Serialize)
                DPFPEnrollment.style.display = "none"      
                SendMessage("Enrolling.  Please wait.")
                aspnetForm.submit()
            End If
    End Sub   
    </script>
</body>
</html>
