<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>
<%@ Register TagPrefix="userControl" TagName="GetDate" Src="~/UserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <userControl:GetDate runat="server" />
    </div>
    </form>
</body>
</html>
