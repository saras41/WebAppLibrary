using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLibrary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoles();
            }
        }

        private void BindRoles()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SP_GET_ROLES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                ddlRole.DataSource = reader;
                ddlRole.DataTextField = "ROLE_NAME";
                ddlRole.DataValueField = "ROLE_ID";
                ddlRole.DataBind();
                conn.Close();
            }

            ddlRole.Items.Insert(0, new ListItem("Select Role", "0"));
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string password = txtPassword.Text.Trim();
            DataTable dt = new DataTable();
            if (ValidateUser(phoneNumber, password, out dt))
            {
                // Store user role in session
                int roleId = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
                Session["UserRole"] = roleId;

                // Get access control based on the role ID
                
                Session["UserAccesControl"] = getAccessControl(roleId);

                // Check the allowed resources and redirect
                //foreach (DataRow row in allowedResources.Rows)
                //{
                //    string resourceName = row["RECOURCE_NAME"].ToString();
                //    if (resourceName == "Registration.aspx")
                //    {
                //        Response.Redirect("Registration.aspx");
                //        return;
                //    }
                //    else if (resourceName == "BookDetails.aspx")
                //    {
                //        Response.Redirect("BookDetails.aspx");
                //        return;
                //    }
                //}
                switch (roleId) 
                    {
                        case 1:
                            Response.Redirect("Registration.aspx");
                            break;
                        case 2:
                            Response.Redirect("Registration.aspx");
                            break;
                    }
                    
               
            }
            else
            {
                lblError.Text = "Invalid phone number or password.";
            }
        }

        private bool ValidateUser(string phoneNumber, string password, out DataTable dt)
        {
            dt = new DataTable();
            string connStr = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM [dbo].[MST_USERS] WHERE PHONE = @PhoneNumber AND PASSWORD = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }

            return dt.Rows.Count > 0;
        }

        private DataTable getAccessControl(int roleId)
        {
            DataTable dt = new DataTable();
            string connStr = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT RECOURCE_NAME FROM [dbo].[ACCESS_CONTROL] WHERE ROLE_ID = @ROLE_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ROLE_ID", roleId);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }

            return dt;
        }
    }
}


