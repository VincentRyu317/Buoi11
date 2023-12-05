using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace QLTN
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
            connsql = kn.connect;
            StartPosition = FormStartPosition.CenterScreen;
        }
        class Connect
        {
            private static string connectstring = Properties.Resources.sql;
            public SqlConnection connect;
            public Connect()
            {

                connect = new SqlConnection(connectstring);
            }
            public Connect(string strcm)
            {
                connect = new SqlConnection(strcm);
            }
        }
        Connect kn = new Connect();
        SqlConnection connsql;
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tk = txtentaikhoan.Text;
            string mk = txtmatkhau.Text;
            string xmk = textBox1.Text;
            string ht = txthovaten.Text;
            string email = txtemail.Text;

            // Check if the username or email is already in use
            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE username = @username OR email = @email";
            SqlCommand cmd = new SqlCommand(sql, connsql);
            cmd.Parameters.AddWithValue("@username", tk);
            cmd.Parameters.AddWithValue("@email", email);

            connsql.Open();
            int count = (int)cmd.ExecuteScalar();
            connsql.Close();

            if (count > 0)
            {
                if (count == 1)
                {
                    MessageBox.Show("Tài khoản đã được sử dụng!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Email đã được sử dụng!", "Thông báo", MessageBoxButtons.OK);
                }

                return;
            }

            // Check if the password and password confirmation match
            if (xmk != mk)
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // Validate email format
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$"))
            {
                MessageBox.Show("Định dạng email không đúng!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // Proceed with registration
            sql = "INSERT INTO NguoiDung (username, password, HoTen, Email) VALUES (@username, @password, @HoTen, @email)";
            cmd = new SqlCommand(sql, connsql);
            cmd.Parameters.AddWithValue("@username", tk);
            cmd.Parameters.AddWithValue("@password", mk);
            cmd.Parameters.AddWithValue("@HoTen", ht);
            cmd.Parameters.AddWithValue("@email", email);

            connsql.Open();
            cmd.ExecuteNonQuery();
            connsql.Close();

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void QLTDN_Click(object sender, EventArgs e)
        {
            this.Hide();
            NguoiDung DN = new NguoiDung();
            DN.ShowDialog();
        }
    }
}
