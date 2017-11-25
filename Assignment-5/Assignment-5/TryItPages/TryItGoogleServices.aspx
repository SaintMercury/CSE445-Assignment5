<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItGoogleServices.aspx.cs" Inherits="Assignment_5.TryItGoogleServices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<a href="index.html">Home</a>
    <form id="form1" runat="server">
    <div>
        <h3>Enter an address to get it's coordinates</h3>

        <p>"[street], [city], [state]"</p>
        <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
        <asp:Button runat="server" text="Get Coordinates" ID="btnGet_Coordinates" OnClick="btnGet_Coordinates_Click"/>
    </div>
    <asp:Label ID="lblLocation" runat="server"></asp:Label>

    <div>
        <h3>Enter 2 pairs of lat/lng to calculate the distance between them</h3>
        
        <asp:Label runat="server">Lat1</asp:Label>
        <asp:TextBox ID="txtLat1" runat="server"></asp:TextBox>
        
        <br/>

        <asp:Label runat="server">Lng1</asp:Label>
        <asp:TextBox ID="txtLng1" runat="server"></asp:TextBox>
        
        <br/>
        
        <asp:Label runat="server">Lat2</asp:Label>
        <asp:TextBox ID="txtLat2" runat="server"></asp:TextBox>
        
        <br/>

        <asp:Label runat="server">Lng2</asp:Label>
        <asp:TextBox ID="txtLng2" runat="server"></asp:TextBox>
        
        <br/>
        <asp:Button ID="btnGet_Distance" runat="server" text="Get Distance" OnClick="btnGet_Distance_Click"/>
        
        <asp:Label ID="lblDistance" runat="server"></asp:Label>
    </div>
    <div>
        <h3>Enter 2 addresses to get the distance between them</h3>

        <p>"[street], [city], [state]"</p>
        <asp:Label runat="server">Address 1</asp:Label>
        <asp:TextBox runat="server" ID="txtAddress1"></asp:TextBox>
        
        <asp:Label runat="server">Address 2</asp:Label>
        <asp:TextBox runat="server" ID="txtAddress2"></asp:TextBox>
        <asp:Button runat="server" text="Get Distance" ID="btnGet_Distance_By_Address" OnClick="btnGet_Distance_By_Address_Click"/>
        <asp:Label ID="lblDistBetweenAddr" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
