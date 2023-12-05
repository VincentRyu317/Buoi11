using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLTN
{
    public partial class BatDauThi : Form
    {
        public BatDauThi()
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

        int i = 1;
        int CauCuoi = 2; //Hàm đếm số câu hỏi trong sql
        private void BatDauThi_Load(object sender, EventArgs e)
        {
           
            //Đồng hồ
            Phut = 60;
            timer1.Start();

            //Thông tin sinh viên
            ThongTin_RowEnter();

            //Load câu 1:
            CauHoi(i);

            //Danh sách câu hỏi:



        }
        private int _phut;

        public int Phut
        {
            get { return _phut; }
            set { _phut = value; }
        }
        public int giay = 1;
        private string _mathisinh;

        public string Mathisinh
        {
            get { return _mathisinh; }
            set { _mathisinh = value; }
        }
        private string _tenmonthi;

        public string Tenmonthi
        {
            get { return _tenmonthi; }
            set { _tenmonthi = value; }
        }
        private int _thoigianthi;

        public int Thoigianthi
        {
            get { return _thoigianthi; }
            set { _thoigianthi = value; }
        }
        private string _MAMONHOC;

        public string MAMONHOC
        {
            get { return _MAMONHOC; }
            set { _MAMONHOC = value; }
        }
        private void ReadOnly()
        {
            txt_A.ReadOnly = true;
            txt_B.ReadOnly = true;
            txt_C.ReadOnly = true;
            txt_D.ReadOnly = true;
            txt_CauHoi.ReadOnly = true;
        }
        //Đồng hồ
        private void timer1_Tick(object sender, EventArgs e)
        {
            giay = giay - 1;
            lbl_Giay.Text = giay.ToString();
            if (giay == 0)
            {
                Phut = Phut - 1;
                lbl_Phut.Text = Phut.ToString();
                giay = 60;
            }
            if (Phut == 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết thời gian làm bài.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lbl_Phut.Text = "00";
                lbl_Giay.Text = "00";
                btn_Nop_Click(sender, e);
            }
        }

        //Thông tin:
        private void ThongTin_RowEnter()
        {
            try
            {
                connsql.Open();
                string sql = "SELECT username, HoTen FROM NguoiDung where username = 'thisinh1'";
                SqlCommand cmd = new SqlCommand(sql, connsql);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.HasRows)
                {
                    dta.Read();
                    lbl_Mon.Text = "Công nghệ NET";
                    string Hoten = dta["Hoten"].ToString();
                    string MSSV = dta["username"].ToString();
                    lbl_HoTen.Text = Hoten;
                    lbl_MSSV.Text = MSSV;
                }
                dta.Close();
                connsql.Close();
            }
            catch
            { }
        }

        //Load câu hỏi
        private void CauHoi(int i)
        {
            connsql.Open();
            string sql = "SELECT * from cauhoi WHERE ID = " + i;
            SqlCommand cmd = new SqlCommand(sql, connsql);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.HasRows)
            {
                dta.Read();
                string CauHoi = dta["CauHoi"].ToString();
                string CauA = dta["CauA"].ToString();
                string CauB = dta["CauB"].ToString();
                string CauC = dta["CauC"].ToString();
                string CauD = dta["CauD"].ToString();
                txt_CauHoi.Text = CauHoi;
                txt_A.Text = CauA;
                txt_B.Text = CauB;
                txt_C.Text = CauC;
                txt_D.Text = CauD;
            }
            connsql.Close();
        }
        private void btn_Nop_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Truoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (i <= 1)
                {
                    MessageBox.Show("Đây là câu đầu tiên");
                }
                else
                {
                    txt_CauHoi.Clear();
                    txt_A.Clear();
                    txt_B.Clear();
                    txt_C.Clear();
                    txt_D.Clear();
                    i--;
                    CauHoi(i);
                }
            }
            catch
            { }
        }

        private void btn_Sau_Click(object sender, EventArgs e)
        {
            try
            {
                if (i >= CauCuoi)
                {
                    MessageBox.Show("Đây là câu cuối cùng");
                }
                else
                {
                    txt_CauHoi.Clear();
                    txt_A.Clear();
                    txt_B.Clear();
                    txt_C.Clear();
                    txt_D.Clear();

                    i++;
                    CauHoi(i);
                }
            }
            catch
            { }
        }

        private void cbb_DsCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DsCauHoi.Items.Clear();
            string[] dt = { "Đã trả lời", "Chưa trả lời", "Tất cả câu" };
            foreach (string s in dt)
            {
                cbb_DsCauHoi.Items.Add(s);
            }
        }
    }
    //
}

