<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindDatagridView.aspx.cs" Inherits="Asp_DGV.BindDatagridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> Sample Employee Information

            <asp:GridView ID ="GridView1" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                onrowediting="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                   <asp:TemplateField HeaderText="ID">    
                       <ItemTemplate >          
                           <asp:Label ID="lblNationalIdNumber" runat="server" Text='<%# Eval("NationalIdNumber") %>' > </asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="JobTitle">
                       <ItemTemplate >
                        <asp:Label runat="server" Text='<%# Eval("JobTitle") %>' ></asp:Label>
                   </ItemTemplate>
                   <EditItemTemplate >
                       <asp:TextBox ID="txtJobTitle" runat="server" Text='<%# Eval("JobTitle")%>'  ></asp:TextBox>
                   </EditItemTemplate>
                       </asp:TemplateField>
                    <asp:TemplateField HeaderText="Birthdate">
           <ItemTemplate>
               <asp:Label ID="lblBirthdate" runat="server"  Text='<%# Eval 	("Birthdate") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
               <asp:TextBox ID="txtBirthdate" runat="server" TextMode="Date" Text='<%# Eval("Birthdate") %>' ></asp:TextBox>
           </EditItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Maritalstatus">
           <ItemTemplate >
               <asp:Label ID="lblMaritalstatus" runat="server" Text='<%# Eval("Maritalstatus") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                <asp:RadioButtonList ID="rblMaritalstatus" runat="server" >
                       <asp:ListItem value="S">Single</asp:ListItem>
                       <asp:ListItem value="M">Married</asp:ListItem>
                </asp:RadioButtonList>
           </EditItemTemplate>
           </asp:TemplateField>
        <asp:TemplateField HeaderText="Salaried">
           <ItemTemplate >
               <asp:Label ID="lblSalaried" runat="server" Text='<%# 	Eval("SalariedFlag") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                
                <asp:CheckBox ID="chkSalaried" runat="server" Text ="Salaried"  >  
                    <%--<asp:ListItem value ="1" >Salried</asp:ListItem> --%>
                    
                </asp:CheckBox>
           </EditItemTemplate>
           </asp:TemplateField>

        <asp:TemplateField HeaderText="Department">
           <ItemTemplate >
               <asp:Label ID="lblName" runat="server" EnableViewState="true"    Text='<%# 	Eval("Name") %>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate >
                <asp:DropDownList ID="ddlDepartment" runat="server" >   
             
                </asp:DropDownList>
           </EditItemTemplate>
           </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit" ShowHeader="false">
               <ItemTemplate>
                   <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" ></asp:LinkButton>
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" ></asp:LinkButton>
                   <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
               </EditItemTemplate>
            </asp:TemplateField>











                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
