using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace DatabaseSystemsGroupProject
{
    public partial class ManagementPage : System.Web.UI.Page
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
                BindEmployeeGridViewEMPLOYEE();//binds the EmployeeGridView to the Employee tabe
            }
        }


        protected void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String username = txtUserName.Text;
            String password = txtPassword.Text;
            String isManager = DropDownListIsManager.SelectedValue.ToString();

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "INSERT INTO Employee(FirstName,LastName,UserName,Password,IsManager) VALUES('" + firstName + "','" + lastName + "','" + username + "','" + password + "','" + isManager + "')";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back
                lblMessage.Visible = true;

                lblMessage.ForeColor = System.Drawing.Color.White;
                lblMessage.Text = "***Employee Added To The Database***";


                //clears the values in the textbox
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
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
                BindEmployeeGridViewEMPLOYEE();//rebinds the EmployeeGridView to reflect the new change
            }
        }


        protected void BindEmployeeGridViewEMPLOYEE()
        {
            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Employee";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Employee");//we are expecting a DataSet/ResultSet back

                if (dataSetOBJ.Tables[0].Rows.Count > 0)//run if there's more than one row in the dataset
                {
                    GridViewEMPLOYEE.DataSource = dataSetOBJ;
                    GridViewEMPLOYEE.DataBind();
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



        protected void GridViewTEST_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewRow gvRow = (GridViewRow)GridViewEMPLOYEE.Rows[e.RowIndex];
            HiddenField employeeIDhidden = (HiddenField)gvRow.FindControl("GVEmployeeID");

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();
                String sqlStatement = String.Format("DELETE FROM Employee WHERE EmployeeID={0}", int.Parse(employeeIDhidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;
                sqlCommandOBJ.Connection = sqlConnectionOBJ;

                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;

                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                GridViewEMPLOYEE.EditIndex = -1;//reset index
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
                BindEmployeeGridViewEMPLOYEE();//rebinds the EmployeeGridView to reflect the new change
            }
        }

        protected void GridViewTEST_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewEMPLOYEE.EditIndex = e.NewEditIndex;
            BindEmployeeGridViewEMPLOYEE();
        }

        protected void GridViewTEST_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEMPLOYEE.EditIndex = -1;//reset index
            BindEmployeeGridViewEMPLOYEE();//rebinds with data from Employee table
        }

        protected void GridViewTEST_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = String.Empty;
            GridViewRow gvRow = (GridViewRow)GridViewEMPLOYEE.Rows[e.RowIndex];
            HiddenField employeeIDhidden = (HiddenField)gvRow.FindControl("GVEmployeeID");
            TextBox txtFirstName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtLastName = (TextBox)gvRow.Cells[2].Controls[0];
            TextBox txtUserName = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox txtPassword = (TextBox)gvRow.Cells[4].Controls[0];
            TextBox txtIsManager = (TextBox)gvRow.Cells[5].Controls[0];

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();
                String sqlStatement = String.Format("UPDATE Employee SET FirstName='{0}', LastName='{1}', UserName = '{2}',Password = '{3}',IsManager = '{4}' WHERE EmployeeID={5}", txtFirstName.Text, txtLastName.Text, txtUserName.Text, txtPassword.Text, txtIsManager.Text, int.Parse(employeeIDhidden.Value.ToString()));

                sqlCommandOBJ.CommandText = sqlStatement;

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlCommandOBJ.ExecuteNonQuery();//since we are not expecting a DataSet/ResultSet back

                GridViewEMPLOYEE.EditIndex = -1;//reset index
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
                BindEmployeeGridViewEMPLOYEE();//rebinds the EmployeeGridView to reflect the new change
            }
        }



        protected void btnReturnToLogInPage_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


    }
}