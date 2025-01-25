using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebAppLibrary
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This method runs when the page is loaded
            if (!IsPostBack)
            {
                if (Session["UserAccesControl"] != null)
                {
                    DataTable dt = (DataTable)Session["UserAccesControl"];
                    var PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                    bool isResourceFound = false;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string name = row["RECOURCE_NAME"].ToString();
                            if (name.Contains(PageName))
                            {
                                isResourceFound = true;
                                break;
                            }
                        }
                    }
                    if (isResourceFound == false)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;

            try
            {
                // Create a SQL connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Create a SQL command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("SP_MST_BOOKS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@BOOK_ID", Convert.ToInt32(txtBOOK_ID.Text.Trim()));
                        cmd.Parameters.AddWithValue("@BOOK_NAME", txtBOOK_NAME.Text.Trim());
                        cmd.Parameters.AddWithValue("@BOOK_DESC", txtBOOK_DESC.Text.Trim());
                        cmd.Parameters.AddWithValue("@IS_ACTIVE", chkIS_ACTIVE.Checked);
                        cmd.Parameters.AddWithValue("@TIME_STAMP", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CREATED_BY", Convert.ToInt32(txtCREATED_BY.Text.Trim()));

                        // Open the connection and execute the command
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // Optionally, display a success message or redirect
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Book details saved successfully!');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}
