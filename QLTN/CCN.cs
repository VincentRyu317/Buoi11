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
    public partial class CCN : Form
    {
        public CCN()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CauHoi CH = new CauHoi();
            CH.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SinhVien SV = new SinhVien();
            SV.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void CCN_Load(object sender, EventArgs e)
        {

        }
    }
}
