using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebAppLibrary
{
    public partial class LibraryMember : System.Web.UI.Page
    {
        private const int MaxBookNameLength = 15; // Maximum length for book name
        private const int MaxBookDescLength = 50; // Maximum length for book description

        protected void Page_Load(object sender, EventArgs e)
        {
            // Role check, assuming role management exists like in Administrator
            if (Session["UserRole"] == null)
            {
                Response.Write("Access denied.");
                return;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string bookId = txtSearchBookID.Text.Trim();
            if (string.IsNullOrEmpty(bookId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a Book ID');", true);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string query = "SELECT * FROM dbo.MST_BOOKS WHERE BOOK_NAME LIKE '%"+ bookId + "%'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BOOK_NAME", bookId);
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtUpdateBookName.Text = reader["BOOK_NAME"].ToString();
                                txtUpdateBookDesc.Text = reader["BOOK_DESC"].ToString();
                            }
                            pnlUpdateBook.Visible = true;
                            lblSearchResult.Text = "Book found!";
                        }
                        else
                        {
                            lblSearchResult.Text = "Book not found.";
                            pnlUpdateBook.Visible = false;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        protected void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string bookId = txtSearchBookID.Text.Trim();
            if (string.IsNullOrEmpty(bookId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a valid Book ID to update');", true);
                return;
            }

            // Validate book name and description lengths
            if (txtUpdateBookName.Text.Trim().Length > MaxBookNameLength)
            {
                lblUpdateResult.Text = $"Book name cannot exceed {MaxBookNameLength} characters.";
                return;
            }

            if (txtUpdateBookDesc.Text.Trim().Length > MaxBookDescLength)
            {
                lblUpdateResult.Text = $"Book description cannot exceed {MaxBookDescLength} characters.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string updateQuery = "UPDATE dbo.MST_BOOKS SET BOOK_NAME = @BOOK_NAME, BOOK_DESC = @BOOK_DESC WHERE BOOK_ID = @BOOK_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@BOOK_ID", bookId);
                        cmd.Parameters.AddWithValue("@BOOK_NAME", txtUpdateBookName.Text.Trim());
                        cmd.Parameters.AddWithValue("@BOOK_DESC", txtUpdateBookDesc.Text.Trim());

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        lblUpdateResult.Text = rowsAffected > 0 ? "Book updated successfully." : "Book not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblUpdateResult.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnDeleteBook_Click(object sender, EventArgs e)
        {
            string bookId = txtDeleteBookID.Text.Trim();
            if (string.IsNullOrEmpty(bookId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a Book ID to delete');", true);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string deleteQuery = "DELETE FROM dbo.MST_BOOKS WHERE BOOK_ID = @BOOK_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@BOOK_ID", bookId);
                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        lblDeleteResult.Text = rowsAffected > 0 ? "Book deleted successfully." : "Book not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblDeleteResult.Text = $"Error: {ex.Message}";
            }
        }
    }
}
