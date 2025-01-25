using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebAppLibrary
{
    public partial class BookIssue : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initial load actions can go here
            }
        }

        protected void btnIssueBook_Click(object sender, EventArgs e)
        {
            try
            {
                string bookId = txtBOOK_ID.Text.Trim();
                string issuedTo = ddlIssuedTo.SelectedValue;
                string issueFromDate = txtIssueFromDate.Text.Trim();
                string issueToDate = txtIssueToDate.Text.Trim();

                if (string.IsNullOrEmpty(bookId) || string.IsNullOrEmpty(issuedTo) ||
                    string.IsNullOrEmpty(issueFromDate) || string.IsNullOrEmpty(issueToDate) ||
                    issuedTo == "Select")
                {
                    Response.Write("<script>alert('Please fill in all fields.');</script>");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand testCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.BOOKS_ISSUE_LEDGER", conn);
                    int count = (int)testCmd.ExecuteScalar();
                    Response.Write("<script>alert('Connected successfully. Records in table: " + count + "');</script>");

                    string insertQuery = "INSERT INTO dbo.BOOKS_ISSUE_LEDGER (BOOK_ID, ISSUED_TO, ISSUE_FROM_DATE, ISSUE_TO_DATE, IS_ACTIVE) " +
                                         "VALUES (@BOOK_ID, @ISSUED_TO, @ISSUE_FROM_DATE, @ISSUE_TO_DATE, @IS_ACTIVE)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BOOK_ID", Convert.ToInt32(bookId));
                        cmd.Parameters.AddWithValue("@ISSUED_TO", issuedTo);
                        cmd.Parameters.AddWithValue("@ISSUE_FROM_DATE", DateTime.Parse(issueFromDate));
                        cmd.Parameters.AddWithValue("@ISSUE_TO_DATE", DateTime.Parse(issueToDate));
                        cmd.Parameters.AddWithValue("@IS_ACTIVE", 1);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Book issued successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Insert failed, no rows affected.');</script>");
                        }
                    }
                }

                ClearFields();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Please ensure dates are in the correct format.');</script>");
            }
            catch (SqlException ex)
            {
                Response.Write("<script>alert('SQL Error: " + ex.Message + " | Number: " + ex.Number + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('General Error: " + ex.Message + "');</script>");
            }
        }


        private void ClearFields()
        {
            txtBOOK_ID.Text = "";
            ddlIssuedTo.SelectedIndex = 0; // Reset to "Select"
            txtIssueFromDate.Text = "";
            txtIssueToDate.Text = "";
        }
    }
}
