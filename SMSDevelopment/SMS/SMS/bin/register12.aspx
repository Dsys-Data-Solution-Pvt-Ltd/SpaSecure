<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register12.aspx.vb" Inherits="register12" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <%
        ' register.asp http://www.stardeveloper.com/articles/display.html?article=2002061202&page=1

	Response.Write ("Current Path: " & _
		Server.MapPath(Request.ServerVariables("SCRIPT_NAME")))

	''Work only if Path string includes the regsvr32 /s
        Dim Path = Request.Form("Path")
        
	If Path <> "" Then
            Dim filepath = Replace(Path, "regsvr32 /s", "")
		filepath = Trim(filepath) 
		Response.Write("<br><br>File Path: " & filepath)

		Dim WshShell, fso
            WshShell = CreateObject("Wscript.Shell")
            fso = CreateObject("Scripting.FileSystemObject")

		If fso.FileExists(filepath) Then
                WshShell.run(Path, 1, True)
                Response.Write("<br><br><br><div align=""center""><b>")
                Response.Write("Register <font color=""#C50D6F"">")
                Response.Write(Path & "</font> succeeded !</b></div>")
		Else
                Response.Write("<br><br><br><div align=""center""><b>")
                Response.Write("Target DLL not found at filepath!</b>")
                Response.Write("</div>")
		End If

            fso = Nothing
            WshShell = Nothing

	Else

%>
<div align="center"  style="background-color: #E3E4EB; 
	margin:100px;border:1px ridge #000000;">
	<form method="POST">
	<b><font color="#2A00A2">Register DLL</font></b>
	<br> <input name="path" type="text" size="40" value="regsvr32 /s ">
	<br>e.g.    <font color="#57009C" style="background-color:white">
	<b>regsvr32 /s  G:\domain\app\DLL\test9.dll</b></font><br><br>
	<input type="submit"  value="Submit" style="background-color:#BDC99B;">
	</form>
</div>
<%
	End If
%>
</body>
</html>