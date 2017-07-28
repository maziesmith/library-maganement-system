using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class UserControlUi : System.Web.UI.Page
    {
        private string message = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UserName = UserNameTextBox.Text;
            string Password = PasswordTextBox.Text;
            string ConfirmPassword = ConfirmPasswordTextBox.Text;
            string Email = EmailTextBox.Text;
            string Country = CountryTextBox.Text;

            string constring =
                ConfigurationManager.ConnectionStrings["LibraryManagementDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spuserdetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Country", Country);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    message = (string) cmd.Parameters["@ERROR"].Value;
                    con.Close();
                    lblErrorMsg.Text = message;
                }
            }



        }
    }
}