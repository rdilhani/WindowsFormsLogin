using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsLogin
{
    public partial class frmSignup: Form
    {
        SqlConnection con = new DBConnection().GetConnection();
        public frmSignup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into login(username,password) select @UN,@PW where not exists(select username from login where username=@UN)", con);
            cmd.Parameters.AddWithValue("@UN", txtUsername.Text);
            cmd.Parameters.AddWithValue("@PW", txtPassword.Text);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Signup Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new frmLogin().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username already exists", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
    }
}
