<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItXml.aspx.cs" Inherits="Assignment_5.TryItPages.TryItXml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<a href="index.html">Home</a>
    <h3>View changes made at ~/Assignment-5/App_Data/Staff.xml || Member.Xml</h3>
    <p>The only entry in Staff.xml is for "TA", "Cse445ta!" and is encrypted</p>
    <p>Don't register multiple users with the same name</p>
    <form id="form1" runat="server">
    <div>
    
        Username<br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="txtPW1" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Re-enter Password<br />
        <asp:TextBox ID="txtPW2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        
        <asp:Button ID="btnWriteMember" runat="server" Text="Write to Staff.xml" OnClick="btnWriteStaff_Click" />
        <asp:Button ID="btnWriteStaff" runat="server" Text="Write to Member.xml" OnClick="btnWriteMember_Click"/>
        
        <br/>
        
        <h1>(Methods below utilize encryption)</h1>
        <asp:Button ID="btnRegister" runat="server" Text="Register Member" OnClick="btnRegisterMember_Click"/>
        <asp:Button ID="btnRegisterStaff" runat="server" Text="Register Staff" OnClick="btnRegisterStaff_Click"/>
        <asp:Label runat="server" ID="lblError"></asp:Label>
        
        <h1>Authentication</h1>
        <p>Simply enter in the user name and password (only first password field) to attempt authentication</p>
        <p>Note that only members/staff that have been created using the encrpyted methods (directly above) can be authenticated</p>
        <asp:Button runat="server" ID="btnAuthStaff" Text="Authenticate as Staff" OnClick="btnAuthStaff_Click"/>
        <asp:Button runat="server" ID="btnAuthMember" Text="Authenticate as Member" OnClick="btnAuthMember_Click"/>
        <asp:Label runat="server" ID="lblAuthSucc"></asp:Label>
    </div>
    </form>
</body>
</html>
