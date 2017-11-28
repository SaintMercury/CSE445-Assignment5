<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Assignment_5.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <a href="Login.aspx">Home</a>
    <form id="form1" runat="server">
    <div>
    
        Registration Page<br />
        <br />
        Username<br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="txtPW1" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Re-enter Password<br />
        <asp:TextBox ID="txtPW2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        IMAGE<br />
        <asp:Image ID="CAPTCHA_Image" runat="server" />
        <asp:TextBox ID="ImageTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="Register Member" OnClick="btnRegisterMember_Click"/>
        <asp:Button ID="btnRegisterStaff" runat="server" Text="Register Staff" OnClick="btnRegisterStaff_Click"/>
        <br />
    
    </div>
    <asp:Label runat="server" ID="lblError"></asp:Label>
    </form>
    <p>**IMPORTANT FOR STAFF REGISTRATION** After registering a staff member, go to ~/ProtectStaff/Web.config and in the element titled allow, add your user's name to the users attribute.</p>
    <p>example: < allow users="TA, MyNewStaffName></p>

</body>
</html>
