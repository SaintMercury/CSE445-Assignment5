<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_5.DefaultCpy" %>
<%@ Register TagPrefix="userControl" TagName="GetDate" Src="UserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome to Group16 Assignment 5 page!<br />
        <br />
        <userControl:GetDate runat="server" />
        <br />
        <br />
    
    </div>
        Member Sign In<br />
        Username<br />
        <asp:TextBox ID="mUsername" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="mPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign In" />
        <br />
        <br />
        Don&#39;t have an account?<br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Register!" />
        <br />
        <br />
        <br />
        Admin Sign In<br />
        Username<br />
        <asp:TextBox ID="aUsername" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="aPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sign In" />
    </form>
</body>
</html>
