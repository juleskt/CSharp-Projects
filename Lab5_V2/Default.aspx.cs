using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // inputUnit.DataBind();
            // outputUnit.DataBind();
        }
        errorText.Text = "";
        outputText.Text = "";
    }

    protected void convert_Click(object sender, EventArgs e)
    {
        if (inputUnit.Text == "")
        {
            errorText.Text = "Input field must be populated. Please enter a number.";
        }
        else
        {
            try
            {
                double input = Convert.ToDouble(inputText.Text);
                // double inputFactor = getFactorFromQuery(inputUnit.Text);
                // double outputFactor = getFactorFromQuery(outputUnit.Text);

                if (input > 0.0)
                {
                    double inputFactor = Convert.ToDouble(inputUnit.SelectedValue);
                    double outputFactor = Convert.ToDouble(outputUnit.SelectedValue);
                    double outputValue = (input * inputFactor) / outputFactor;
                    outputText.Text = outputValue.ToString();
                }
                else
                {
                    errorText.Text = "Please enter a valid number";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                errorText.Text = "Please enter a valid number";
                inputText.Text = String.Empty;
            }
        }
    }

    protected void modify_Click(object sender, EventArgs e)
    {
        Response.Redirect("Modify.aspx", false);
    }

    /*protected double getFactorFromQuery(string whereClause)
    {
        string sqlQuery =
            "SELECT "               +
                "* "                +
            "FROM "                 +
                "dbo.Conversions "  +
            "WHERE "                +
               "Unit = \'" + whereClause + "\'";

        using (SqlConnection connection = new SqlConnection(SqlDataSource1.ConnectionString))
        {
            SqlCommand getInputCommand = new SqlCommand(
                sqlQuery, connection);

            connection.Open();
            SqlDataReader reader = getInputCommand.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine(reader["Factor"]);
                    return Convert.ToDouble(reader["Factor"]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                errorText.Text = "Oops! Something went wrong.";
                return 0.0;
            }
        }
        return 0.0;
    } */
}