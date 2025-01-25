using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebAppLibrary
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Role and access control checks
            if (Session["UserRole"] == null || !IsAdminOrTeacher((int)Session["UserRole"]))
            {
                Response.Write("Access denied.");
                return;
            }

            // Page access check
            if (Session["UserAccesControl"] != null)
            {
                DataTable dt = (DataTable)Session["UserAccesControl"];
                var PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                bool isResourceFound = false;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["RECOURCE_NAME"].ToString().Contains(PageName))
                        {
                            isResourceFound = true;
                            break;
                        }
                    }
                }

                if (!isResourceFound)
                {
                    Response.Write("Page access not allowed.");
                    return;
                }
            }
            else
            {
                Response.Write("User access control not found in session.");
                return;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string userId = txtSearchUserId.Text.Trim();
            if (string.IsNullOrEmpty(userId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a User ID');", true);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string query = "SELECT * FROM dbo.MST_USERS WHERE USER_ID = @USER_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@USER_ID", userId);
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtFirstName.Text = reader["FIRST_NAME"].ToString();
                                txtLastName.Text = reader["LAST_NAME"].ToString();
                                ddlRole.SelectedValue = reader["ROLE_ID"].ToString();
                                txtPhone.Text = reader["PHONE"].ToString();
                                txtAddress.Text = reader["ADDRESS"].ToString();
                                txtDesignation.Text = reader["DESIGNATION"].ToString();
                            }
                            pnlUserInfo.Visible = true;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User not found');", true);
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

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string userId = txtSearchUserId.Text.Trim();
            if (string.IsNullOrEmpty(userId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a valid User ID to update');", true);
                return;
            }

            if (txtFirstName.Text.Trim().Length > 10 ||
                txtLastName.Text.Trim().Length > 10 ||
                txtPhone.Text.Trim().Length > 12 ||
                txtAddress.Text.Trim().Length > 50 ||
                txtDesignation.Text.Trim().Length > 10)
            {
                lblUpdateResult.Visible = true;
                lblUpdateResult.Text = "One or more fields exceed the allowed length.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string updateQuery = "UPDATE dbo.MST_USERS SET FIRST_NAME = @FirstName, LAST_NAME = @LastName, ROLE_ID = @RoleId, " +
                                 "PHONE = @Phone, ADDRESS = @Address, DESIGNATION = @Designation WHERE USER_ID = @UserId";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@RoleId", ddlRole.SelectedValue);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text.Trim());

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        lblUpdateResult.Visible = true;
                        lblUpdateResult.Text = rowsAffected > 0 ? "User updated successfully." : "User not found.";
                        ClearFieldsExceptResultLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                lblUpdateResult.Visible = true;
                lblUpdateResult.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string firstName = txtNewFirstName.Text.Trim();
            string lastName = txtNewLastName.Text.Trim();
            int roleId = int.Parse(ddlNewRole.SelectedValue);
            string phone = txtNewPhone.Text.Trim();
            string address = txtNewAddress.Text.Trim();
            string designation = txtNewDesignation.Text.Trim();

            // Server-side length validation
            if (firstName.Length > 10 || lastName.Length > 10 || phone.Length > 12 || address.Length > 50 || designation.Length > 10)
            {
                lblAddUserResult.Text = "One or more fields exceed the allowed length.";
                return;
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                lblAddUserResult.Text = "First Name and Last Name are required.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string insertQuery = "INSERT INTO dbo.MST_USERS (FIRST_NAME, LAST_NAME, ROLE_ID, PHONE, ADDRESS, DESIGNATION) " +
                                 "VALUES (@FirstName, @LastName, @RoleId, @Phone, @Address, @Designation)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Designation", designation);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        lblAddUserResult.Text = rowsAffected > 0 ? "User added successfully." : "Error adding user.";
                        ClearFieldsExceptResultLabels();  // Clear fields after add but keep result message
                    }
                }
            }
            catch (Exception ex)
            {
                lblAddUserResult.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string userId = txtDeleteUserId.Text.Trim();
            if (string.IsNullOrEmpty(userId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a User ID to delete');", true);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;
            string deleteQuery = "DELETE FROM dbo.MST_USERS WHERE USER_ID = @USER_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@USER_ID", userId);
                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        lblDeleteResult.Visible = true;
                        lblDeleteResult.Text = rowsAffected > 0 ? "User deleted successfully." : "User not found.";
                        ClearFieldsExceptResultLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                lblDeleteResult.Visible = true;
                lblDeleteResult.Text = $"Error: {ex.Message}";
            }
        }
        private void ClearFieldsExceptResultLabels()
        {
            // Clear text fields
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtSearchUserId.Text = string.Empty;
            txtDeleteUserId.Text = string.Empty;
            txtNewFirstName.Text = string.Empty;
            txtNewLastName.Text = string.Empty;
            txtNewPhone.Text = string.Empty;
            txtNewAddress.Text = string.Empty;
            txtNewDesignation.Text = string.Empty;

            // Reset panels
            pnlUserInfo.Visible = false;
        }

        private bool IsAdminOrTeacher(int roleId)
        {
            return roleId == 1 || roleId == 2;
        }
    }
}
