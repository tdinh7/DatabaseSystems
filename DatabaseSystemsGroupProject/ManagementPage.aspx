﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementPage.aspx.cs" Inherits="DatabaseSystemsGroupProject.ManagementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: black; height: 100px; width: 100%; text-align: center;">
            <h1 style="font-family: sans-serif; color: white;">Management Page</h1>
        </div>

        <div style="margin-top: 5%;">

            <div style="float: left; display: inline-block">
                <h2>Add Employee test test2</h2>
                <table style="margin-top: 0%;">
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
                        <td>&nbsp;<asp:Button ID="btnReturnToLogInPage" runat="server" Text="Return To Login Page" BackColor="Green" ForeColor="White" OnClick="btnReturnToLogInPage_Click1"  /></td>

                    </tr>

                   
                </table>
                <h3><asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label></h3>

            </div>

            <div style="float: right; margin-top: 0%;">
                <h2>Employee Table</h2>
                <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                        <asp:BoundField DataField="IsManager" HeaderText="IsManager" />

                        <asp:ButtonField HeaderText="Delete" Text="Delete" />
                        <asp:ButtonField DataTextField="IsManager" HeaderText="IsManager" Text="Button" />

                    </Columns>

                </asp:GridView>
            </div>
        </div>



        <div style="margin-top: 40%;">
            <div style="">
                <h2>Employee Table TEST</h2>
                <asp:GridView ID="GridViewTEST" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewTEST_RowDeleting" OnRowEditing="GridViewTEST_RowEditing" OnRowCancelingEdit="GridViewTEST_RowCancelingEdit" OnRowUpdating="GridViewTEST_RowUpdating">
                    <Columns>
                        <asp:TemplateField>
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

    </form>
</body>
</html>
