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
            <span>
                <asp:Button Style="float: right; height: 70px; color: orangered; width: 100px" ID="btnLogout" runat="server" Text="Log Out;" OnClick="btnLogout_Click" /></span>
            <h1 style="font-family: sans-serif; color: white;">Gift Shop Page </h1>

        </div>

        <div>
            <div style="float: left; display: inline-block">
                <h1>Add Customer Here</h1>
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
                                    <asp:HiddenField ID="CustomerId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CustomerId") %>' />
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


        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div>
            <div style="">
                <div style="">
                    <h1>Item GridView</h1>
                    <asp:GridView ID="ItemGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewItem_RowDeleting" OnRowEditing="GridViewItem_RowCancelingEdit" OnRowCancelingEdit="GridViewItem_RowEditing" OnRowUpdating="GridViewItem_RowUpdating" BackColor="#669999">
                        <Columns>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:HiddenField ID="ItemId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ItemId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="false" />
                            <asp:BoundField DataField="PictureUrl" HeaderText="PictureUrl" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" ImageUrl='<%# Eval("PictureUrl") %>' runat="server" Width="200px" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Select Item" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxSelectItem" runat="server" CssClass="CheckboxSize" Enabled="true" />
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center" Width="130px" Height="30px" VerticalAlign="Middle"></ItemStyle>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>

                    </asp:GridView>
                </div>
                <h3>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </h3>
            </div>

            <div>
                <asp:Button ID="btnPuchaseItems" runat="server" Text="Purchase Items" OnClick="btnPuchaseItems_Click" />
            </div>
        </div>


        <div>

            <asp:Repeater ID="ItemRepeater" runat="server" Visible="true" OnItemCommand="ItemRepeater_ItemCommand">
                <ItemTemplate>
                    <table style="border: 1px solid; background-color: #FFF7E7">
                        <tr>
                            <td style="width: 200px">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("PictureUrl") %>' runat="server" Width="200px" />
                            </td>
                            <td style="width: 450px">

                                <table>
                                    <tr>
                                        <td>
                                            <b>Name:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Price:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblItemPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </td>


                        </tr>
                    </table>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
