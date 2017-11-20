<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>
<%@ Register TagPrefix="userControl" TagName="GetDate" Src="~/UserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>
    <title></title>
    <meta charset="utf-8" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <userControl:GetDate runat="server" />
    </div>
        <div>
            <table>
                <tr>
            <td>Max Henzerling</td>
            <td>wordFilter(string phraseToFilter): string[]</td>
            <td><a href="http://webstrar16.fulton.asu.edu/page0/Service.aspx">Try It</a></td>
            <td>Given a strig of words, remove the stop words</td>
            <td>Wrote my own code</td>
        </tr>
        <tr>
            <td>Max Henzerling</td>
            <td>newsFocus(string[] args): string[]</td>
            <td><a href="http://webstrar16.fulton.asu.edu/page0/Service.aspx">Try It</a></td>
            <td>Given a topic, search for links related to the topic</td>
            <td>Google News Search call</td>
        </tr>
        <tr>
            <td>Max Henzerling</td>
            <td>getChar(string name): string</td>
            <td><a href="http://webstrar16.fulton.asu.edu/page0/Service.aspx">Try It</a></td>
            <td>Make a character, given your name</td>
            <td>Wrote my own code</td>
        </tr>
        <tr>
            <td>Max Henzerling</td>
            <td>huntTreasure(string address): string[]</td>
            <td><a href="http://webstrar16.fulton.asu.edu/page0/Service.aspx">Try It</a></td>
            <td>Given your location, return all the geocoding information to get to a shovel and a park.</td>
            <td>
            </table>
        </div>
    </form>
</body>
</html>
