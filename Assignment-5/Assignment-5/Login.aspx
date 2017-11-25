<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3> Login as a member to gain access to the member page, or as staff to gain access to all pages</h3>
    <p>Haven't registered yet? Click <a href="/Register.aspx">register</a> to sign up</p>
    <form runat="server">
      <table>
        <tr>
          <td> User Name:  </td>
          <td>
            <asp:TextBox ID= "txtUserName" RunAt="server" />
          </td>
        </tr>
        <tr>
            <td> Password: </td><td>
            <asp:TextBox ID="txtPassword" TextMode="password"
              RunAt="server" />
		</td>
        </tr>
        <tr>
		    <td>
			    <asp:Button ID="btnLogin" Text= "Login" RunAt="server" OnClick="btnLogin_Click" />    
            </td>
            <td>
			    <asp:Button ID="btnLoginAsStaff" Text= "Login as Staff" RunAt="server" OnClick="btnLoginAsStaff_Click"/>    
            </td>
            <td>
			    <asp:Button ID="btnLogout" Text="Logout" RunAt="server" OnClick="btnLogout_Click1"/>    
            </td>
        </tr>

      </table>
    </form>
    <asp:Label runat="server" ID="lblOutput"></asp:Label>

</body>
</html>
