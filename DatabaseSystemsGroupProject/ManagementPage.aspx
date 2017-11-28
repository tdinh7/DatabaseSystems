<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementPage.aspx.cs" Inherits="DatabaseSystemsGroupProject.ManagementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Page</title>

    <style>
        body {
            background-image: url(../IMAGES/bg4.jpg);
            background-repeat: no-repeat;
            background-size: cover;
        }

        
        .betterVis {
            /*background-color:grey;*/
            color: black;
            font-size: 320%;
            font-weight: bolder;
            font-family: Sans-Serif;
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
                    <a class="navbar-brand" id="theNavbarBrand" href="#" style="color: #fff">Holiday Gift Shop - Management Page</a>
                </div>
                <%--<ul class="nav navbar-nav">
                    <li><a href="#" style="color: #fff">Something 1</a></li>
                    <li><a href="#" style="color: #fff">Something 2</a></li>

                </ul>--%>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnReturnToLogInPage" runat="server" Text="Return To Login Page" CssClass="btn btn-primary" Visible="True" OnClick="btnReturnToLogInPage_Click1" />
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

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-5">
                </div>
                <div class="col-md-5">
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>

        --%>


        <div class="container-fluid">
            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-5">
                    <div style="">
                        <h1 class="betterVis">Add Employee Here</h1>
                        <table style="margin-top: 0%; background-color: cadetblue;">
                            <tr>
                                <td>&nbsp;First Name:</td>
                                <td>&nbsp;<asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Last Name:</td>
                                <td>&nbsp;<asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Username:</td>
                                <td>&nbsp;<asp:TextBox ID="txtUserName" runat="server" placeholder="Enter User Name"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Password:</td>
                                <td>&nbsp;<asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Is Manager:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsManager" runat="server">
                                        <asp:ListItem>no</asp:ListItem>
                                        <asp:ListItem>yes</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>&nbsp;<asp:Button ID="btnCreateEmployee" runat="server" Text="Create Employee" BackColor="Green" ForeColor="White" OnClick="btnCreateEmployee_Click" /></td>
                            </tr>

                        </table>
                        <h3>
                            <asp:Label ID="lblMessage" runat="server" Text=""  ForeColor="white" Style="font-size: 120%; font-weight: bolder; font-family: Sans-Serif;background-color: yellowgreen"></asp:Label></h3>
                    </div>
                </div>
                <div class="col-md-5">
                    <div style="">
                        <div style="">
                            <h1 class="betterVis">Employee Table</h1>
                            <asp:GridView ID="GridViewEMPLOYEE" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewTEST_RowDeleting" OnRowEditing="GridViewTEST_RowEditing" OnRowCancelingEdit="GridViewTEST_RowCancelingEdit" OnRowUpdating="GridViewTEST_RowUpdating" BackColor="#669999">
                                <Columns>
                                    <asp:TemplateField Visible="true">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="GVEmployeeID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "EmployeeID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="false" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                    <asp:BoundField DataField="IsManager" HeaderText="IsManager" />

                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>

                            </asp:GridView>
                        </div>
                        <h3>
                            <asp:Literal ID="ltError" runat="server"></asp:Literal>
                        </h3>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
