<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindDDLinlistview.aspx.cs" Inherits="Asp_DGV.BindDDLinlistview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <asp:ListView ID="ListView1" runat="server" OnItemEditing="OnItemEditing" OnItemDataBound="OnItemDataBound"
    OnItemCanceling="OnItemCanceling" OnItemUpdating="OnItemUpdating" GroupPlaceholderID="groupPlaceHolder1"
    ItemPlaceholderID="itemPlaceHolder1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" style="margin-right: 309px">
    <LayoutTemplate>
        <table cellpadding="2" cellspacing="0" border="1" style="width: 200px; border: dashed 2px #04AFEF;
            background-color: #B0E2F5">
            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        </table>
    </LayoutTemplate>
                 <GroupTemplate>
        <tr>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
        </tr>
    </GroupTemplate>
    <ItemTemplate>
        <td><asp:Label ID="lblNationalIdNumber" runat="server" Text='<%# Eval("NationalIdNumber") %>'></asp:Label> </td>
        <td> <asp:Label ID="lblJobTitile" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label></td>
        <td><asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
        <td><asp:Button ID="btnEdit" runat="server" Text='Edit' CommandName="Edit" /></td>
    </ItemTemplate>
    <EditItemTemplate>
        <td> <asp:Label ID="lblNationalIdNumber" runat="server" Text='<%# Eval("NationalIdNumber") %>'></asp:Label>         </td>
        <td> <asp:Label ID="lblJobTitile" runat="server" Text='<%# Eval("JobTitle") %>' Visible="true"></asp:Label>    </td>
        <td> <asp:DropDownList ID="ddlDepartment" runat="server">  </asp:DropDownList>
             <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' Visible="false"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnEdit" runat="server" Text='Update' CommandName="Update" />
            <asp:Button ID="Button1" runat="server" Text='Cancel' CommandName="Cancel" />
        </td>
    </EditItemTemplate>
 </asp:ListView>



        </div>
    </form>
</body>
</html>
