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
    public partial class Login : System.Web.UI.Page
    {
        //global varibles
        SqlCommand sqlCommandOBJ = new SqlCommand();
        SqlConnection sqlConnectionOBJ = new SqlConnection();
        SqlDataAdapter sqlDataAdapterOBJ = new SqlDataAdapter();
        DataSet dataSetOBJ = new DataSet();
        //global varibles

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//if this is the first time the page is laoded
            {

            }
        }
        

        protected void btnlogin_click(object sender, EventArgs e)
        {
            String userName = txtUsername.Text;
            String password = txtPassword.Text;

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Employee WHERE UserName='" + userName + "' AND Password='" + password + "'";
                //sqlCommandOBJ.CommandText = "SELECT * FROM Employee";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Employee");

                if (dataSetOBJ.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Succesfully Login!";

                    Response.Redirect("StorePage.aspx");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Username or Password!";
                }
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

        protected void btnloginmanager_click(object sender, EventArgs e)
        {
            String userName = txtUsername.Text;
            String password = txtPassword.Text;

            sqlConnectionOBJ.ConnectionString = "Data Source=DESKTOP-P0QRTM4;Initial Catalog=DatabaseSystems8490;Integrated Security=True";

            try
            {
                sqlConnectionOBJ.Open();

                sqlCommandOBJ.CommandText = "SELECT * FROM Employee WHERE UserName='" + userName + "' AND Password='" + password + "'";

                sqlCommandOBJ.Connection = sqlConnectionOBJ;
                sqlDataAdapterOBJ.SelectCommand = sqlCommandOBJ;
                sqlDataAdapterOBJ.Fill(dataSetOBJ, "Employee");

                if (dataSetOBJ.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Succesfully Login!";

                    foreach (DataTable table in dataSetOBJ.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            String tempIsManager = dr["IsManager"].ToString();
                            if (tempIsManager == "yes")
                            {
                                Response.Redirect("ManagementPage.aspx");
                            }
                        }
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Username or Password!";
                }
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