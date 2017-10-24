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
    </style>
</head>

    
<body>
    <form id="form1" runat="server">
        <div style="background-color: black; height: 70px; width: 100%; text-align: center;">
            <h1 style="font-family: sans-serif; color: white;">Management Page</h1>
        </div>

        <div style="margin-top: 1%;">
            <div style="float: left; display: inline-block">
                <h1>Add Employee Here</h1>
                <table style="margin-top: 0%;background-color:cadetblue;" >
                    <tr>
                        <td>&nbsp;First Name:</td>
                        <td>&nbsp;<asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;Last Name:</td>
                        <td>&nbsp;<asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;User Name:</td>
                        <td>&nbsp;<asp:TextBox ID="txtUserName" runat="server" placeholder="Enter User Name"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;Password:</td>
                        <td>&nbsp;<asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;Is Manger:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsManager" runat="server">
                                <asp:ListItem>no</asp:ListItem>
                                <asp:ListItem>yes</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>&nbsp;<asp:Button ID="btnCreateEmployee" runat="server" Text="Create Employee" BackColor="Green" ForeColor="White" OnClick="btnCreateEmployee_Click" /></td>
                        <td>&nbsp;<asp:Button ID="btnReturnToLogInPage" runat="server" Text="Return To Login Page" BackColor="Green" ForeColor="White" OnClick="btnReturnToLogInPage_Click1" /></td>
                    </tr>

                </table>
                <h3>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor=""></asp:Label></h3>
            </div>

            <div style="float: right; margin-top: 0%;">
                <div style="">
                    <h1>Employee Table</h1>
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

    </form>
</body>
</html>
