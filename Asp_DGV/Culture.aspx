<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Culture.aspx.cs" Inherits="Asp_DGV.Culture"  Culture="en-US" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CultureInfo demo</title>
</head>
<body>
    <form id="MainForm" runat="server">
        <% Response.Write("Current date, in a culture specific format: " + DateTime.Now.ToString()); %>
    <br></br>

    <% Response.Write("Current date, in a culture specific format: " + DateTime.Now.ToString(System.Globalization.CultureInfo.GetCultureInfo("de-DE").DateTimeFormat)); %>
    
    </form>
</body>
</html>
