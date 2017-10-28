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
                BindItemRepeaterITEM();//binds the EmployeeGridView to the Employee tabe

            }
            else
            {
                if (Session["storeManagerOBJsession"] != null)
                {
                    storeManager = (StoreManager)Session["storeManagerOBJsession"];
                }
            }
        }

        protected void BindItemRepeaterITEM()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Item";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Item");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    ItemRepeater.DataSource = dataSetOBJ;
                    ItemRepeater.DataBind();
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

        protected void ItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnPuchaseItems_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ItemGridView.Rows.Count; i++)
            {
                CheckBox CheckBoxSelectedItem = (CheckBox)ItemGridView.Rows[i].FindControl("CheckBoxSelectItem");
                HiddenField ItemIDhidden = (HiddenField)ItemGridView.Rows[i].FindControl("ItemId");
                //CheckBoxSelectCourseLittlePrep.BackColor = Color.White;

                if (CheckBoxSelectedItem.Checked)//throw an error message if both checkboxes are checked
                {
                    int tempItemID = int.Parse(ItemIDhidden.Value.ToString());
                    string tempPictureUrl = ItemGridView.Rows[i].Cells[2].Text;
                    string tempName = ItemGridView.Rows[i].Cells[1].Text;
                    string tempPrice = ItemGridView.Rows[i].Cells[3].Text;

                    if (Session["storeManagerOBJsession"] == null)
                    {
                        
                        storeManager.AddItemToList(tempItemID, tempPictureUrl, tempName, tempPrice);
                        //storeManager = (StoreManager)Session["storeManagerOBJsession"];
                        Session["storeManagerOBJsession"] = storeManager;
                    }
                    else
                    {
                        storeManager = (StoreManager)Session["storeManagerOBJsession"];
                        storeManager.AddItemToList(tempItemID, tempPictureUrl, tempName, tempPrice);

                        Session["storeManagerOBJsession"] = storeManager;
                    }
                }
            }
        }
    }
}