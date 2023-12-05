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
    public partial class QuanLyCauHoi : Form
    {
        private SqlConnection CN = new SqlConnection(@"Data Source=LAPTOP-AD9OSNGE\SQLEXPRESS;Initial Catalog=QLTN;Integrated Security=True");

        private void QuanLyCauHoi_Load(object sender, EventArgs e)
        {
    }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            string Cauhoi = rtbNoidung.Text;
            string CauA = txtDapanA.Text;
            string CauB = txtDapanB.Text;
            string CauC = txtDapanC.Text;
            string CauD = txtDapanD.Text;

            // Tạo đối tượng SqlCommand
            SqlCommand cmd = new SqlCommand("INSERT INTO Cauhoi VALUES (@ID, @Cauhoi, @CauA, @CauB, @CauC, @CauD)", CN);

            // Gán giá trị cho các biến tham số
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Cauhoi", Cauhoi);
            cmd.Parameters.AddWithValue("@CauA", CauA);
            cmd.Parameters.AddWithValue("@CauB", CauB);
            cmd.Parameters.AddWithValue("@CauC", CauC);
            cmd.Parameters.AddWithValue("@CauD", CauD);

            // Thực thi câu lệnh SQL
            try
            {
                CN.Open();
                cmd.ExecuteNonQuery();
                CN.Close();

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm thành công!");

                // Xóa dữ liệu trong các control
                textBox1.Text = "";
                rtbNoidung.Text = "";
                txtDapanA.Text = "";
                txtDapanB.Text = "";
                txtDapanC.Text = "";
                txtDapanD.Text = "";
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message);
            }
        }

        private void rtbNoidung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDapanB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDapanA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDapanC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDapanD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDapandung_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
