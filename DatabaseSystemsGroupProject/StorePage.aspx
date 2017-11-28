<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorePage.aspx.cs" Inherits="DatabaseSystemsGroupProject.StorePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Systems Group Project</title>
    <style>
        body {
            background-image: url(../IMAGES/bg5.jpg);
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: 100%;
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

    <link href="Bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="Bootstrap/jquery-ui-1.10.3.custom.css" rel="stylesheet" />

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
                    <a class="navbar-brand" id="theNavbarBrand" href="#" style="color: #fff">Holiday Gift Shop - Store Page</a>
                </div>
              <%--  <ul class="nav navbar-nav">
                    <li><a href="#" style="color: #fff">Something 1</a></li>
                    <li><a href="#" style="color: #fff">Something 2</a></li>
                </ul>--%>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Logout" runat="server" OnClick="btnLogout_Click" />
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
                <div class="col-md-4">
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
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
                <div class="col-md-4">
                    <div>
                        <div style="">
                            <h1 class="betterVis">Add Customer Here</h1>
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
                            </table>
                            <asp:Button ID="btnCreateCustomer" CssClass="btn btn-success" runat="server" Text="Create Customer" BackColor="" ForeColor="Black" OnClick="btnCreateCustomer_Click" />


                            <h3>
                                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
                    <div>
                        <div style="">
                            <div style="">
                                <h1 class="betterVis">Customer Table</h1>
                                <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewCustomer_RowDeleting" OnRowEditing="GridViewCustomer_RowEditing" OnRowCancelingEdit="GridViewCustomer_RowCancelingEdit" OnRowUpdating="GridViewCustomer_RowUpdating" BackColor="#669999" OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="CustomerId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CustomerId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="false" />
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="DateJoined" HeaderText="DateJoined" />
                                        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" />
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:CommandField ShowDeleteButton="False" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <h3>
                                <asp:Literal ID="ltError" runat="server"></asp:Literal>
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <div style="">
                            <div style="">
                                <h1 class="betterVis">Item GridView</h1>
                            </div>
                            <asp:GridView ID="ItemGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewItem_RowDeleting" OnRowEditing="GridViewItem_RowCancelingEdit" OnRowCancelingEdit="GridViewItem_RowEditing" OnRowUpdating="GridViewItem_RowUpdating" BackColor="#669999">
                                <Columns>
                                    <asp:TemplateField Visible="true">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="ItemId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ItemId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="false" ItemStyle-Width="220px"/>
                                    <asp:BoundField DataField="PictureUrl" HeaderText="PictureUrl" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="220px"/>

                                    <asp:TemplateField Visible="true" HeaderText="Quantity" ControlStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuantity" runat="server"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Picture" ControlStyle-Width="170px">
                                        <ItemTemplate>
<%--                                            <asp:Image ID="Image1" class="img-thumbnail" ImageUrl='<%# Eval("PictureUrl") %>' runat="server" Width="200px" />--%>
                                            <asp:Image ID="Image1" class="img-rounded" ImageUrl='<%# Eval("PictureUrl") %>' runat="server" Width="200px" />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Select Item" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxSelectItem" runat="server" CssClass="CheckboxSize" Enabled="true" />
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="130px" Height="30px" VerticalAlign="Middle"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:CommandField ShowDeleteButton="False" />
                                </Columns>

                            </asp:GridView>


                            <h3>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </h3>
                        </div>


                    </div>
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-md-4">

                    <div style="margin-top:70%">

                        <h1 class="betterVis">Purchase Order Here</h1>
                    <table style="margin-top: 0%; background-color: cadetblue;">
                        <tr>
                            <td>&nbsp;CustomerID:</td>
                            <td>&nbsp;<asp:TextBox ID="txtCustomerID" runat="server" placeholder="Enter CustomerID"></asp:TextBox></td>
                        </tr>

                    </table>
                        <br />
                    <div >
                        <asp:Button ID="btnPuchaseItems" CssClass="btn btn-info" runat="server" Text="Purchase Items" OnClick="btnPuchaseItems_Click" />

                    </div>
                    <div>
                        <asp:Label ID="lblItemsPurchased" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>
                    </div>

                    <%--<div>
                        <asp:Repeater ID="ItemRepeater" runat="server" Visible="false" OnItemCommand="ItemRepeater_ItemCommand">
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
                    </div>--%>
                </div>
            </div>
        </div>

        <br />
        <br />

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-0">
                </div>
                <div class="col-md-6">
                    <div style="">
                        <h1 class="betterVis">OrderRecord Table</h1>
                        <asp:GridView ID="GridViewOrderRecord" runat="server" AutoGenerateColumns="False" BackColor="#669999">
                            <Columns>
                                <asp:BoundField DataField="OrderRecordID" HeaderText="OrderRecordID" ReadOnly="true" ItemStyle-Width="150px"/>
                                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ItemStyle-Width="150px"/>
                                <asp:BoundField DataField="DateOrdered" HeaderText="Date Ordered" ItemStyle-Width="340px"/>
                                <asp:BoundField DataField="NumberOfItems" HeaderText="Number Of Items Ordered" ItemStyle-Width="270px"/>
                                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price In $$$" ItemStyle-Width="220px"/>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
                <div class="col-md-4">
                    <div style="">
                        <h1 class="betterVis">OrderItem Table</h1>
                        <asp:GridView ID="GridViewOrderItem" runat="server" AutoGenerateColumns="False" BackColor="#669999">
                            <Columns>
                                <asp:BoundField DataField="OrderItemID" HeaderText="OrderItemID" ReadOnly="true" ItemStyle-Width="220px"/>
                                <asp:BoundField DataField="OrderRecordID" HeaderText="OrderRecordID" ItemStyle-Width="220px"/>
                                <asp:BoundField DataField="ItemID" HeaderText="ItemID" ItemStyle-Width="220px"/>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="220px"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>

    </form>
</body>
</html>
