<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TripPlanner.aspx.cs" Inherits="Assignment_5.ProtectedMember.TripPlanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Enter your starting location </h3>
        <p>"[street], [city], [state]"</p>
        <asp:Label runat="server">Start Location:</asp:Label>
        <asp:TextBox runat="server" ID="txtStartAddress"></asp:TextBox>
        
        <asp:Label runat="server">Destination Location</asp:Label>
        <asp:TextBox runat="server" ID="txtDestAddress"></asp:TextBox>
        <asp:Button runat="server" text="Get Distance" ID="btnGet_Distance_By_Address" OnClick="btnGet_Distance_By_Address_Click1"/>
        <asp:Label ID="lblDistBetweenAddr" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
