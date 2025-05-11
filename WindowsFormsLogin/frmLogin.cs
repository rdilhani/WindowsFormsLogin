using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLogin
{
    public partial class frmLogin: Form
    {
        SqlConnection con=new DBConnection().GetConnection();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          /*  //Hardcoded login
            if(txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
               new frmHome().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            con.Open();
            SqlCommand cmd = new SqlCommand("select 1 from login where username=@UN and password=@PW",con);
            cmd.Parameters.AddWithValue("@UN", txtUsername.Text);
            cmd.Parameters.AddWithValue("@PW", EncryptPassword(txtPassword.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                new frmHome().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();

        }

        //Password Encryption
        private string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            string encryptedPassword = Convert.ToBase64String(data);
            return encryptedPassword; // Placeholder, replace with actual encryption
        }

        private void picHide_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picHide_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
            new frmSignup().Show();
            this.Hide();
        }

        private void lblSignup_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
