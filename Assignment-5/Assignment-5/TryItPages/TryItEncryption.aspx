<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItEncryption.aspx.cs" Inherits="Assignment_5.TryItEncryption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<a href="index.html">Home</a>
<h1>Encryption/Decryption Methods</h1>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txtEncrpytIn"></asp:TextBox>
        <asp:Button runat="server" ID="btnEncrypt" Text="
            Encrypt" OnClick="btnEncrypt_Click"/>
        <asp:Label runat="server" ID="lblEncrypted"></asp:Label>
        
        <br/>
        
        <asp:TextBox runat="server" ID="txtDecryptIn"></asp:TextBox>
        <asp:Button runat="server" ID="btnDecrpyt" Text="Decrypt" OnClick="btnDecrpyt_Click"/>
        <asp:Label runat="server" ID="lblDecrypted"></asp:Label>
    </div>
    </form>
</body>
</html>
