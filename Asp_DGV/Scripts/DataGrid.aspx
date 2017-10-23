<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataGrid.aspx.cs" Inherits="Asp_DGV.Scripts.DataGrid" %>
<%@ Register TagPrefix="My" TagName="UserInfoBoxControl" Src="~/UserInfoBoxControl.ascx" %>
<%@ Register TagPrefix="My" TagName="EventUserControl" Src="~/EventUserControl.ascx" %>

<%@ Reference Control="~/UserInfoBoxControl.ascx" %>

 <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Your name:<br />
        <asp:TextBox runat="server" id="txtName" Text="enter name"/>
            <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtName" Display="Dynamic" errormessage="Please enter your name!" />
        <br /><br />
            <asp:Button runat="server" id="btnSubmitForm" text="Ok" onclick="btnSubmitForm_Click" style="width: 31px"  />
        </div>
        <div>
             <My:UserInfoBoxControl runat="server" ID="MyUserInfoBoxControl" />
            <h1>Hello Web Pages</h1>
            <asp:Panel runat="server" ID="pnlControl" CssClass="pnlControl">
                <table style="height: 12px; width: 313px">
                    <tr> <td><asp:TextBox runat="server" ID="txtPageTitle"  /></td></tr>
                    <tr> <td>  <asp:Label runat="server" id="HelloWorldLabel">Label1</asp:Label> </td></tr>
                    <tr><td> <asp:Button runat="server" ID="GreenButton"  ForeColor="Green" Text="Update" />    </td> </tr>
                </table>
            </asp:Panel>

            <table>
          <tr>
              <td>
                  <asp:TextBox runat="server" ID="TextInput" MaxLength ="10"   EnableViewState="true"/>
              </td> 
              <td><asp:Button runat="server" id="Button1" text="Say Hello!" OnClick="Button1_Click" /></td>
          </tr>
          
                </table >
            <table class="pnlControl">
        <asp:DropDownList runat="server" id="GreetList" autopostback="true" onselectedindexchanged="GreetList_SelectedIndexChanged">            <asp:ListItem value="no one">No one</asp:ListItem>
                    <asp:ListItem value="world">World</asp:ListItem>
                    <asp:ListItem value="universe">Universe</asp:ListItem>
        </asp:DropDownList>
                </table>
           
            <table>
                <asp:PlaceHolder runat="server" ID="phUserInfoBox" />
            </table>

        </div>
        <div>
            <asp:Panel  runat="server" ID="pnlCookies" CssClass="pnlControl">
                 <asp:DropDownList runat="server" id="ColorSelector" autopostback="true" onselectedindexchanged="ColorSelector_IndexChanged">
                    <asp:ListItem value="White" selected="True">Select color...</asp:ListItem>
                    <asp:ListItem value="Red">Red</asp:ListItem>
                    <asp:ListItem value="Green">Green</asp:ListItem>
                    <asp:ListItem value="Blue">Blue</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
            <My:EventUserControl runat="server" ID="MyEventUserControl" OnPageTitleUpdated="MyEventUserControl_PageTitleUpdated" />
        </div>

        <div>
               <asp:Panel  runat="server" ID="Panel1" CssClass="pnlControl">
                <asp:DropDownList runat="server" id="ddlperson" autopostback="true" onselectedindexchanged="ddlperson_IndexChanged">
                </asp:DropDownList>
            </asp:Panel>


            
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
<Columns>
    <asp:BoundField DataField="PersonType" HeaderText="PersonType" />
    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
   
</Columns>
</asp:GridView>




        </div>
    </form>
</body>
</html>
