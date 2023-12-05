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
namespace QLTN
{
    public partial class CauHoi : Form
    {
        public CauHoi()
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string ND = txtCauhoi.Text;
            string A = txtCauA.Text;
            string B = txtCauB.Text;
            string C = txtCauC.Text;
            string D = txtCauD.Text;
            string DA = txtDapandung.Text;
            // Check if the username or D is already in use
            string sql = "SELECT COUNT(*) FROM cauhoi WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, connsql);
            cmd.Parameters.AddWithValue("@id", ID);
            connsql.Open();
            int count = (int)cmd.ExecuteScalar();
            connsql.Close();

            if (count > 0)
            {
                if (count == 1)
                {
                    MessageBox.Show("ID đã được sử dụng!", "Thông báo", MessageBoxButtons.OK);
                }
                return;
            }

            // Check if the password and password confirmation match

            // Proceed with registration
            sql = "INSERT INTO cauhoi (ID, CauHoi, CauA, CauB, CauC, CauD, DA) VALUES (@id, @CauHoi, @cauA, @cauB, @cauC, @cauD, @DapAn)";
            cmd = new SqlCommand(sql, connsql);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@CauHoi", ND);
            cmd.Parameters.AddWithValue("@cauA", A);
            cmd.Parameters.AddWithValue("@cauB", B);
            cmd.Parameters.AddWithValue("@cauC", C);
            cmd.Parameters.AddWithValue("@cauD", D);
            cmd.Parameters.AddWithValue("@DapAn", DA);

            connsql.Open();
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Add(txtID.Text, txtCauhoi.Text, txtCauA.Text, txtCauB.Text, txtCauC.Text, txtCauD.Text, txtDapandung.Text);
            txtID.Clear();
            txtCauhoi.Clear();
            txtCauA.Clear();
            txtCauB.Clear();
            txtCauC.Clear();
            txtCauD.Clear();
            txtDapandung.Clear();
            connsql.Close();
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void CauHoi_Load(object sender, EventArgs e)
        {
             loadData();
        }
        private void loadData()
        {
            // Connect to the database
            connsql.Open();
            string sql = "SELECT * FROM cauhoi";
            SqlCommand cmd = new SqlCommand(sql, connsql);

            // Execute the SELECT statement
            SqlDataReader reader = cmd.ExecuteReader();

            // Add data to the DataGridView
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"].ToString(), reader["CauHoi"].ToString(), reader["CauA"].ToString(), reader["CauB"].ToString(), reader["CauC"].ToString(), reader["CauD"].ToString(), reader["DA"].ToString());
            }

            // Close the database connection and data reader
            connsql.Close();
            reader.Close();
        }
        private void txtCauhoi_TextChanged(object sender, EventArgs e)
        {
            string nd = txtCauhoi.Text;
        }

        private void txtCauA_TextChanged(object sender, EventArgs e)
        {
            string a = txtCauA.Text;
        }

        private void txtCauB_TextChanged(object sender, EventArgs e)
        {
            string b = txtCauB.Text;
        }

        private void txtCauC_TextChanged(object sender, EventArgs e)
        {
            string c = txtCauC.Text;
        }

        private void txtCauD_TextChanged(object sender, EventArgs e)
        {
            string d = txtCauD.Text;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string id = txtID.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string nd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string a = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string b = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string d = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string da = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            // Hiển thị thông tin
            txtID.Text = id;
            txtCauhoi.Text = nd;
            txtCauA.Text = a;
            txtCauB.Text = b;
            txtCauC.Text = c;
            txtCauD.Text = d;
            txtDapandung.Text = da;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string sql = "DELETE FROM cauhoi WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, connsql);
                cmd.Parameters.AddWithValue("@id", id);

                connsql.Open();
                cmd.ExecuteNonQuery();
                connsql.Close();

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);

                MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void txtDapandung_TextChanged(object sender, EventArgs e)
        {
            string da = txtDapandung.Text;
        }
    }
}
