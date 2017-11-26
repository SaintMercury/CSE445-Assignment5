<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharacterMaker.aspx.cs" Inherits="Assignment_5.ProtectedMember.CharacterMaker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Enter your name (or any string for that matter)</h3>
        <asp:Label runat="server">Name: </asp:Label>
        <asp:TextBox runat="server" ID="inputName"></asp:TextBox>
        <asp:Button runat="server" text="Make Character" ID="makeCharBtn" OnClick="makeCharacter"/>
        <br />
        <asp:TextBox ID="outputBox" runat="server" Height="407px" TextMode="MultiLine" Width="295px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
