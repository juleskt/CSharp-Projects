using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorText.Text = "";
        successText.Text = "";
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        // Build query string with parametrized arguments (to prevent injections)
        string sqlQuery =
            "DELETE FROM " +
                "dbo.Conversions " +
            "WHERE " +
               "id = @id";

        successText.Text = "Successfully deleted \"" + inputUnit.SelectedItem.Text + "\" from Database!";

        try
        {
            // Build connection, sub in the query values (to prevent injections), and execute
            using (SqlConnection connection = new SqlConnection(SqlDataSource1.ConnectionString))
            {
                SqlCommand deleteCommand = new SqlCommand(
                    sqlQuery, connection);

                deleteCommand.Parameters.AddWithValue("@id", inputUnit.SelectedValue);

                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            
            inputUnit.DataBind();
        }
        catch (Exception ex)
        {
            errorText.Text = "Oops! Looks like something went wrong";
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    protected void add_Click(object sender, EventArgs e)
    {
        // Check if entry already exists, we don't want duplicate units (really should use a SELECT for this)
        foreach(ListItem li in inputUnit.Items)
        {s
            if (li.Text == inputUnitText.Text)
            {
                errorText.Text = "Can't have duplicate unit names!";
                return;
            }
        }

        try
        {
            if (Convert.ToDouble(inputFactorText.Text) <= 0)
            {
                errorText.Text = "Please enter a positive, non-zero factor";
                return;
            }
            else if (inputUnitText.Text.Length <= 0)
            {
                errorText.Text = "Please enter a name for the unit";
                return;
            }
        }
        catch (Exception ex)
        {
            errorText.Text = "Please enter a valid number for a factor";
            System.Diagnostics.Debug.WriteLine(ex.ToString());
            return;
        }

        // Build query string with parametrized arguments (to prevent injections)
        string sqlQuery =
           "INSERT INTO " +
               "dbo.Conversions " +
               "(Unit, Factor) " +
           "VALUES " +
              "(@Unit, @Factor)";

        try
        {
            // Build connection, sub in the query values (to prevent injections), and execute
            using (SqlConnection connection = new SqlConnection(SqlDataSource1.ConnectionString))
            {
                SqlCommand addCommand = new SqlCommand(
                    sqlQuery, connection);

                addCommand.Parameters.AddWithValue("@Unit", inputUnitText.Text);
                addCommand.Parameters.AddWithValue("@Factor", inputFactorText.Text);

                connection.Open();
                addCommand.ExecuteNonQuery();
            }

            successText.Text = "Successfully added \"" + inputUnitText.Text + "\" to Database!";
            inputUnit.DataBind();
        }
        catch (Exception ex)
        {
            errorText.Text = "Oops! Looks like something went wrong";
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    protected void conversion_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
}