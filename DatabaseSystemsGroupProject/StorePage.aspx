<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorePage.aspx.cs" Inherits="DatabaseSystemsGroupProject.StorePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Systems Group Project</title>

    <style>
        body {
            background-image: url(../IMAGES/bg5.jpg);
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: black; height: 70px; width: 100%; text-align: center">
            <span> <asp:Button style="float:right; height:70px; color:orangered; width:100px" ID="btnLogout" runat="server" Text="Log Out;" OnClick="btnLogout_Click" /></span>
            <h1 style="font-family: sans-serif; color: white;">Gift Shop Page </h1>
               
        </div>

        <div>
            <div style="float: left; display: inline-block">
                <h1>Add Customer Here</h1>
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
                        <td>&nbsp;Email:</td>
                        <td>&nbsp;<asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email"></asp:TextBox></td>
                    </tr>
                    <%--
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
                    </tr>--%>
                </table>
                        <asp:Button ID="btnCreateCustomer" runat="server" Text="Create Employee" BackColor="Green" ForeColor="White" OnClick="btnCreateCustomer_Click" />
                <h3>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor=""></asp:Label></h3>
            </div>


        </div>

        <div>
            <div style="float: right; margin-top: 0%;">
                <div style="">
                    <h1>Employee Table</h1>
                    <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewCustomer_RowDeleting" OnRowEditing="GridViewCustomer_RowEditing" OnRowCancelingEdit="GridViewCustomer_RowCancelingEdit" OnRowUpdating="GridViewCustomer_RowUpdating" BackColor="#669999">
                        <Columns>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:HiddenField ID="CustomerId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "EmployeeID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="false" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="Email" HeaderText="UserName" />
                            <asp:BoundField DataField="DateJoined" HeaderText="Password" />
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
