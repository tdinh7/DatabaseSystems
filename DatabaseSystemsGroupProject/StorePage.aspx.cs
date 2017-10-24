﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseSystemsGroupProject
{
    public partial class StorePage : System.Web.UI.Page
    {
        //global varibles
        SqlCommand sqlCommandOBJ = new SqlCommand();
        SqlConnection sqlConnectionOBJ = new SqlConnection();
        SqlDataAdapter sqlDataAdapterOBJ = new SqlDataAdapter();
        DataSet dataSetOBJ = new DataSet();
        //global varibles

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//fires on the first page load
            {
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
            String theDatetimeRightNow = DateTime.Now.ToShortDateString().ToString();
            //gets values from the textboxes on the user interface

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "INSERT INTO Customer(FirstName,LastName,Email,DateJoined) VALUES('" + firstName + "','" + lastName + "','" + email + "','" + theDatetimeRightNow +"')";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back
                lblMessage.Visible = true;

                lblMessage.ForeColor = System.Drawing.Color.AliceBlue;
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
    }
}