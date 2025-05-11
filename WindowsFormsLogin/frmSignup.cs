using System;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Security.Cryptography;
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
            cmd.Parameters.AddWithValue("@PW", EncryptPassword(txtPassword.Text));
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

        //Password Encryption
        private string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data=md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            string encryptedPassword = Convert.ToBase64String(data);
            return encryptedPassword; // Placeholder, replace with actual encryption
        }

        private void picHide_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picHideConfirm_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassConfirm.UseSystemPasswordChar = false;
        }

        private void picHide_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void picHideConfirm_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassConfirm.UseSystemPasswordChar = true;
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            txtPassConfirm.UseSystemPasswordChar = true;
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
