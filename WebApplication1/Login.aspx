<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
         <div class="control-group">
        <div class="controls">
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
              </div>
        </div>
             <div class="control-group">
        <div class="controls">
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
              </div>
        </div>
        
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" class="btn btn-primary"/> 
        <asp:Label ID="loginfail" runat="server" ForeColor="Red" Text="incorrect login or password"
            Visible="False"></asp:Label> 
        
</asp:Content>