<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState.aspx.cs" Inherits="Asp_DGV.ViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewState</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" id="NameField" />
        <asp:Button runat="server" id="SubmitForm" onclick="SubmitForm_Click" text="Submit & set name" />
        <asp:Button runat="server" id="RefreshPage" text="Just submit" />
        <br /><br />
        Name retrieved from ViewState: <asp:Label runat="server" id="NameLabel" />
    </form> 
</body>
</html>
