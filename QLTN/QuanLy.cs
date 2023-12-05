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
    public partial class QuanLy : Form
    {
        public QuanLy()
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
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                connsql.Open();
                string tk = txtUserName.Text;
                string mk = txtPass.Text;
                string sql = "select * from QuanLy where username = '" + tk + "' and password = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, connsql);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    this.Hide();
                    CCN form2 = new CCN();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("dang nhap That bai");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chonquyen cq = new Chonquyen();
            cq.ShowDialog();
        }

        private void txtUserName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chonquyen cq = new Chonquyen();
            cq.ShowDialog();
        }
    }
}
