using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DatabaseSystemsGroupProject;

namespace DatabaseSystemsGroupProject
{
    public partial class StorePage : System.Web.UI.Page
    {
        //global varibles
        SqlCommand sqlCommandOBJ = new SqlCommand();
        SqlConnection sqlConnectionOBJ = new SqlConnection();
        SqlDataAdapter sqlDataAdapterOBJ = new SqlDataAdapter();
        DataSet dataSetOBJ = new DataSet();

        StoreManager storeManager;
        //global varibles

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//fires on the first page load
            {
                storeManager = new StoreManager();
                Session["storeManagerOBJsession"] = storeManager;

                BindAllGridViewControlsOnPage();//binds data to all gridview contols on the page
            }
            else
            {
                if (Session["storeManagerOBJsession"] != null)
                {
                    storeManager = (StoreManager)Session["storeManagerOBJsession"];
                }
            }
        }

        protected void BindAllGridViewControlsOnPage()
        {
            BindGridViewCustomer();//binds the EmployeeGridView to the Employee tabe
            BindItemGridViewITEM();//binds the EmployeeGridView to the Employee tabe
            BindOrderRecordGridViewITEM();// binds data to the GridViewOrderRecord gridview control
            BindOrderItemGridViewITEM();// binds data to the GridViewOrderItem gridview control
                                        //BindItemRepeaterITEM();//binds the EmployeeGridView to the Employee tabe
        }

        protected void BindOrderItemGridViewITEM()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM OrderItem";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                dataSetOBJ = new DataSet();

                sqlDataAdapterOBJ.Fill(dataSetOBJ, "OrderItem");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    GridViewOrderItem.DataSource = dataSetOBJ;
                    GridViewOrderItem.DataBind();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();
            }
        }

        protected void BindOrderRecordGridViewITEM()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM OrderRecord";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                dataSetOBJ = new DataSet();

                sqlDataAdapterOBJ.Fill(dataSetOBJ, "OrderRecord");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    GridViewOrderRecord.DataSource = dataSetOBJ;
                    GridViewOrderRecord.DataBind();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();
            }
        }

        //protected void BindItemRepeaterITEM()
        //{
        //    sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

        //    try
        //    {
        //        sqlConnectionOBJ.Open();

        //        sqlCommandOBJ.CommandText = "SELECT * FROM Item";

        //        sqlCommandOBJ.Connection = sqlConnectionOBJ;
        //        sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
        //        sqlDataAdapterOBJ.Fill(dataSetOBJ, "Item");//we are expecting a DataSet/ResultSet back

        //        if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
        //        {
        //            ItemRepeater.DataSource = dataSetOBJ;
        //            ItemRepeater.DataBind();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
        //        throw;
        //    }
        //    finally
        //    {
        //        sqlConnectionOBJ.Close();
        //        sqlConnectionOBJ.Dispose();
        //    }
        //}

        protected void BindItemGridViewITEM()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Item";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                dataSetOBJ = new DataSet();

                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Item");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    ItemGridView.DataSource = dataSetOBJ;
                    ItemGridView.DataBind();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();
            }
        }

        protected void BindGridViewCustomer()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Customer";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                dataSetOBJ = new DataSet();

                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Customer");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    GridViewCustomer.DataSource = dataSetOBJ;
                    GridViewCustomer.DataBind();
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            //gets values from the textboxes on the user interface
            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String email = txtEmail.Text;

            String theDayMonthYear = DateTime.Now.ToShortDateString().ToString();
            String theTimeInDetailed = DateTime.Now.ToLongTimeString().ToString();

            String bothTimeValuesCombined = theDayMonthYear + " " + theTimeInDetailed;
            //gets values from the textboxes on the user interface

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "INSERT INTO Customer(FirstName,LastName,Email,DateJoined) VALUES('" + firstName + "','" + lastName + "','" + email + "','" + bothTimeValuesCombined + "')";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back
                lblMessage.Visible = true;

                lblMessage.ForeColor = System.Drawing.Color.Blue;
                lblMessage.Text = "***Customer Added To The Database***";


                //clears the values in the textbox
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                //clears the values in the textbox
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR***";
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
            }
            BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page
            lblItemsPurchased.Visible = false;
        }

        protected void GridViewCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCustomer.EditIndex = -1;//reset index
            BindAllGridViewControlsOnPage();//binds data to all gridviewcontols on the page
        }

        protected void GridViewCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)GridViewCustomer.Rows[e.RowIndex];
            HiddenField customerIDHidden = (HiddenField)gvRow.FindControl("CustomerId");

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";
            //code to get all of the records in the OrderRecords table that has a CustomerID = customerIDHidden

            //SELECT * FROM OrderRecord WHERE CustomerID = customerIDHidden
            try
            {
                sqlConnectionOBJ.Open();

                String sqlStatement = String.Format("SELECT * FROM OrderRecord Where CustomerID ={0}", int.Parse(customerIDHidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;
                sqlCommandOBJ.Connection = sqlConnectionOBJ;

                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                DataSet customerDataSetOBJ = new DataSet();

                sqlDataAdapterOBJ.Fill(customerDataSetOBJ, "OrderRecord");//we are expecting a DataSet/ResultSet back

                //gets the stored 'StoreManager' object stored in the session object 
                storeManager = (StoreManager)Session["storeManagerOBJsession"];

                if (customerDataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    //loop through each row and create an object for each row
                    foreach (DataRow row in customerDataSetOBJ.Tables[0].Rows)
                    {
                        String orderRecordID = row["OrderRecordID"].ToString();
                        String customerID = row["CustomerID"].ToString();
                        String dateOrdered = row["DateOrdered"].ToString();
                        String numberOfItems = row["NumberOfItems"].ToString();
                        String totalPrice = row["TotalPrice"].ToString();
                        storeManager.AddOrderRecordToList(orderRecordID, customerID, dateOrdered, numberOfItems, totalPrice);
                    }
                }
                else
                {

                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR*** \n " + ex.Message;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();
            }

            //Loop through the dataset and create an object for each record and store this in an Arraylist

            //Loop through this ArrayList of OrderRecord objects, for each object's OrderRecordID:
            //DELETE * FROM OrderItem WHERE OrderRecordID = "object's OrderRecordID"

            //code to get all of the records in the OrderRecords table that has a CustomerID = customerIDHidden

            //try
            //{
            //    sqlConnectionOBJ.Open();
            //    String sqlStatement = String.Format("DELETE FROM Customer WHERE CustomerId={0}", int.Parse(customerIDHidden.Value.ToString()));

            //    sqlCommandOBJ.CommandText = sqlStatement;
            //    sqlCommandOBJ.Connection = sqlConnectionOBJ;

            //    sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                
            //    sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

            //    GridViewCustomer.EditIndex = -1;//reset index
            //}
            //catch (SqlException ex)
            //{
            //    lblMessage.Visible = true;
            //    ltError.Text = "***SqlException*** ERROR*** \n" + ex.Message;
            //    throw;//wtf is this???
            //}
            //finally
            //{
            //    sqlConnectionOBJ.Close();
            //    sqlConnectionOBJ.Dispose();

            //    BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page           
            //}
        }

        protected void GridViewCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCustomer.EditIndex = e.NewEditIndex;
            BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page           
        }

        protected void GridViewCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewRow gvRow = (GridViewRow)GridViewCustomer.Rows[e.RowIndex];
            HiddenField customerIDhidden = (HiddenField)gvRow.FindControl("CustomerId");
            TextBox txtFirstName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtLastName = (TextBox)gvRow.Cells[2].Controls[0];
            TextBox txtEmail = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox txtDateJoined = (TextBox)gvRow.Cells[4].Controls[0];

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();
                String sqlStatement = String.Format("UPDATE Customer SET FirstName='{0}', LastName='{1}', Email = '{2}', DateJoined = '{3}' WHERE CustomerID = {4}", txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtDateJoined.Text, int.Parse(customerIDhidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                GridViewCustomer.EditIndex = -1;//reset index
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                ltError.Text = "***SqlException*** ERROR*** \n" + ex.Message;

                throw;//wtf is this???
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();

                BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page           
            }
        }


        protected void GridViewItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)ItemGridView.Rows[e.RowIndex];
            HiddenField itemIDHidden = (HiddenField)gvRow.FindControl("ItemId");

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();
                String sqlStatement = String.Format("DELETE FROM Item WHERE ItemId={0}", int.Parse(itemIDHidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;
                sqlCommandOBJ.Connection = sqlConnectionOBJ;

                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                GridViewCustomer.EditIndex = -1;//reset index
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                ltError.Text = "***SqlException*** ERROR*** \n" + ex.Message;



                throw;//wtf is this???
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();

                BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page           
            }
        }


        protected void GridViewItem_RowEditing(object sender, GridViewCancelEditEventArgs e)
        {
            ItemGridView.EditIndex = -1;//reset index
            BindAllGridViewControlsOnPage();//binds data to all gridviewcontols on the page
        }

        protected void GridViewItem_RowCancelingEdit(object sender, GridViewEditEventArgs e)
        {
            ItemGridView.EditIndex = e.NewEditIndex;
            BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page 
        }

        protected void GridViewItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)ItemGridView.Rows[e.RowIndex];
            HiddenField itemIDhidden = (HiddenField)gvRow.FindControl("ItemId");
            TextBox txtName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtPictureUrl = (TextBox)gvRow.Cells[2].Controls[0];
            TextBox txtPrice = (TextBox)gvRow.Cells[3].Controls[0];

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();
                String sqlStatement = String.Format("UPDATE Item SET Name = '{0}', PictureUrl='{1}', Price = '{2}' WHERE ItemID={3}", txtName.Text, txtPictureUrl.Text, txtPrice.Text, int.Parse(itemIDhidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                ItemGridView.EditIndex = -1;//reset index
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
                sqlConnectionOBJ.Dispose();

                BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page           
            }
        }

        //protected void ItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //}

        protected void btnPuchaseItems_Click(object sender, EventArgs e)
        {


            //used in the "OrderRecord" Table
            String customerID = txtCustomerID.Text;

            int numberOfItems = 0;
            Double finalTotalPriceOfItems = 00.00;

            int orderRecordID = 0;

            String theDayMonthYear = DateTime.Now.ToShortDateString().ToString();
            String theTimeInDetailed = DateTime.Now.ToLongTimeString().ToString();
            String bothTimeValuesCombined = theDayMonthYear + " " + theTimeInDetailed;
            //used in the "OrderRecord" Table

            for (int i = 0; i < ItemGridView.Rows.Count; i++)
            {
                CheckBox CheckBoxSelectedItem = (CheckBox)ItemGridView.Rows[i].FindControl("CheckBoxSelectItem");
                HiddenField ItemIDhidden = (HiddenField)ItemGridView.Rows[i].FindControl("ItemId");
                TextBox quantityTextBox = (TextBox)ItemGridView.Rows[i].FindControl("txtQuantity");
                //CheckBoxSelectCourseLittlePrep.BackColor = Color.White;

                if (CheckBoxSelectedItem.Checked)//throw an error message if both checkboxes are checked
                {
                    int tempItemID = int.Parse(ItemIDhidden.Value.ToString());
                    string tempPictureUrl = ItemGridView.Rows[i].Cells[2].Text;
                    string tempName = ItemGridView.Rows[i].Cells[1].Text;
                    string tempPrice = ItemGridView.Rows[i].Cells[3].Text;
                    Double tempPriceForItem = Double.Parse(tempPrice.Substring(1, tempPrice.Length - 1));

                    numberOfItems += int.Parse(quantityTextBox.Text); //increments the number of items for the order
                    finalTotalPriceOfItems += (int.Parse(quantityTextBox.Text)) * (tempPriceForItem);

                    if (Session["storeManagerOBJsession"] != null)// if storeManagerOBJ already exist
                    {
                        storeManager = (StoreManager)Session["storeManagerOBJsession"];
                        storeManager.AddItemToList(tempItemID, tempPictureUrl, tempName, tempPrice, int.Parse(quantityTextBox.Text));
                        Session["storeManagerOBJsession"] = storeManager;
                    }
                    else// if storeManagerOBJ doesn't exist //this clasue will proablly never get hit
                    {
                        Session["storeManagerOBJsession"] = storeManager;
                        storeManager = (StoreManager)Session["storeManagerOBJsession"];
                        storeManager.AddItemToList(tempItemID, tempPictureUrl, tempName, tempPrice, int.Parse(quantityTextBox.Text));
                        Session["storeManagerOBJsession"] = storeManager;
                    }
                }
            }

            //***code to insert into the Order Order table *** ***code to insert into the Order Order table ***            
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";
            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "INSERT INTO OrderRecord(CustomerID, DateOrdered, NumberOfItems, TotalPrice) VALUES('" + customerID + "','" + bothTimeValuesCombined + "','" + numberOfItems + "','" + finalTotalPriceOfItems + "')";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back
                lblMessage.Visible = true;

                lblMessage.ForeColor = System.Drawing.Color.Blue;
                lblMessage.Text = "***Customer Order To The ORDER Table***";


                //clears the values in the textbox
                txtCustomerID.Text = "";

                //clears the values in the textbox
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR***" + "\n" + ex;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
            }
            //***code to insert into the Order Order table *** ***code to insert into the Order Order table ***

            //***code to get the orderId*** ***code to get the orderId***       
            //this is SELECT * WHERE DateOrdered = theTimeInDetail string
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";
            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM OrderRecord WHERE DateOrdered = '" + bothTimeValuesCombined + "'";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                dataSetOBJ = new DataSet();
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "OrderRecord");//we are expecting a DataSet/ResultSet back

                for (int i = 0; i < dataSetOBJ.Tables[0].Rows.Count; i++)
                {
                    orderRecordID = int.Parse(dataSetOBJ.Tables[0].Rows[i]["OrderRecordID"].ToString());
                }
            }
            catch (SqlException ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "SqlException*** ERROR***" + "\n" + ex;
                throw;
            }
            finally
            {
                sqlConnectionOBJ.Close();
            }
            //set the orderId variable here with the dataset that gets returned
            //***code to get the orderId*** ***code to get the orderId***      

            //***get the Item objects in the arraylist
            storeManager = (StoreManager)Session["storeManagerOBJsession"];
            List<Item> itemList = (List<Item>)storeManager.itemList;
            //***get the Item objects in the arraylist

            //***for each item in the list, you need to create a CartItem record
            foreach (Item item in itemList)
            {
                //code to do insert a record for each item into the CartItem table
                sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

                try
                {
                    sqlConnectionOBJ.Open();

                    sqlCommandOBJ.CommandText = "INSERT INTO OrderItem(OrderRecordID,ItemID,Quantity) VALUES('" + orderRecordID + "','" + item.ItemID + "','" + item.quantity + "')";

                    sqlCommandOBJ.Connection = sqlConnectionOBJ;
                    sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                    sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                    lblItemsPurchased.Visible = true;

                    lblItemsPurchased.ForeColor = System.Drawing.Color.White;
                    lblItemsPurchased.Text = "***Items Purchased***";


                    //clears the values in the textbox
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    //clears the values in the textbox
                }
                catch (SqlException ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "SqlException*** ERROR***";
                    throw;
                }
                finally
                {
                    sqlConnectionOBJ.Close();
                }
            }
            //***for each item in the list, you need to create a CartItem record

            BindAllGridViewControlsOnPage();//rebinds data to all gridview controls on the page
            lblMessage.Visible = false;
        }
    }
}