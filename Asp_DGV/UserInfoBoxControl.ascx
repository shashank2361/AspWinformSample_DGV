<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfoBoxControl.ascx.cs" Inherits="Asp_DGV.UserInfoBoxControl" %>
<b>Information about <%= this.UserName %></b>
<br /><br />
<%= this.UserName %> is <%= this.UserAge %> years old and lives in <%= this.UserCountry %>