using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLibrary
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserRole"] == null || !(IsAdminOrTeacher((int)Session["UserRole"])))
            {

                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
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
                PopulateDropdown();
            }
        }

        protected void PopulateDropdown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_ROLES", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        ddlRole.DataSource = reader;
                        ddlRole.DataTextField = "ROLE_NAME";
                        ddlRole.DataValueField = "ROLE_ID";
                        ddlRole.DataBind();
                    }

                    reader.Close();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string dbo = "SP_INSERT_MST_USERS";

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyTestDB"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(dbo, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FIRST_NAME", txtFIRST_NAME.Text.Trim());
                        cmd.Parameters.AddWithValue("@LAST_NAME", txtLAST_NAME.Text.Trim());
                        cmd.Parameters.AddWithValue("@ROLE_ID", Convert.ToInt32(ddlRole.SelectedValue.Trim()));
                        cmd.Parameters.AddWithValue("@IS_ACTIVE", 1);
                        cmd.Parameters.AddWithValue("@TIME_STAMP", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@PASSWORD", txtPASSWORD.Text.Trim());
                        cmd.Parameters.AddWithValue("@PHONE", txtPHONE.Text.Trim());
                        cmd.Parameters.AddWithValue("@ADDRESS", txtADDRESS.Text.Trim());
                        cmd.Parameters.AddWithValue("@DESIGNATION", txtDESIGNATION.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration Successful');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        // Helper method to determine if the user is Admin or Teacher
        private bool IsAdminOrTeacher(int roleId)
        {
            return roleId == 1 || roleId == 2; // Assuming 1=Admin, 2=Teacher; adjust as necessary
        }
    }
}
