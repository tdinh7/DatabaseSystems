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

                BindEmployeeGridViewEMPLOYEE();//binds the EmployeeGridView to the Employee tabe

                BindItemGridViewITEM();//binds the EmployeeGridView to the Employee tabe
                //BindItemRepeaterITEM();//binds the EmployeeGridView to the Employee tabe

            }
            else
            {
                if (Session["storeManagerOBJsession"] != null)
                {
                    storeManager = (StoreManager)Session["storeManagerOBJsession"];
                }
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

        protected void BindEmployeeGridViewEMPLOYEE()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Customer";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Employee");//we are expecting a DataSet/ResultSet back

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
        }

        protected void GridViewCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridViewCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }


        protected void GridViewItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void GridViewItem_RowEditing(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridViewItem_RowCancelingEdit(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

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
                    Double tempPriceForItem = Double.Parse(tempPrice.Substring(1, tempPrice.Length-1));

                    numberOfItems += int.Parse(quantityTextBox.Text); //increments the number of items for the order
                    finalTotalPriceOfItems += (int.Parse(quantityTextBox.Text))*(tempPriceForItem);

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
            }
            //***for each item in the list, you need to create a CartItem record
        }
    }
}