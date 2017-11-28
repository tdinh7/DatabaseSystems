<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DatabaseSystemsGroupProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Holiday Gift Shop Log In Page</title>

    <style>
        body {
            background-image: url(../IMAGES/bg1.jpg);
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>

    <!--Bootstrap CSS-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="Scripts/jquery-2.2.1.min.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <!--Navbar-->
        <nav class="navbar navbar-default" id="theNavbar">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" id="theNavbarBrand" href="#" style="color: #fff">Holiday Gift Shop Log In Page</a>
                </div>
                <%--<ul class="nav navbar-nav">
                    <li><a href="#" style="color: #fff">Something 1</a></li>
                    <li><a href="#" style="color: #fff">Something 2</a></li>

                </ul>--%>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Logout" runat="server" Visible="False" />
                </ul>
            </div>
        </nav>

        <%--
            
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </div>

        --%>



        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-3">

                    <div style="margin-top: 90%">
                        <table style="">
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

                    <div style="text-align: center">
                        <h3>
                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></h3>
                    </div>

                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>

    </form>
</body>
</html>
