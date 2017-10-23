<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DatabaseSystemsGroupProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Systems Group Project Log In Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: black; height: 100px; width: 100%; text-align: center">
            <h1 style="font-family: sans-serif; color: white;">Welcome! Please Log In!</h1>

        </div>

        <div style="">
            <table style="margin-top: 10%" align="center">
                <tr>
                    <td>&nbsp;Username:</td>
                    <td>&nbsp;<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;Password:</td>
                    <td>&nbsp;<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;<asp:Button ID="btnlogin" runat="server" Text="employee login" BackColor="green" ForeColor="white" OnClick="btnlogin_click" /></td>
                    <td>&nbsp;<asp:Button ID="btnloginmanager" runat="server" Text="manager login" BackColor="green" ForeColor="white" OnClick="btnloginmanager_click" /></td>

                </tr>

            </table>
        </div>

        <div style="text-align:center">
            <h3 >
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></h3>
        </div>

    </form>
</body>
</html>
