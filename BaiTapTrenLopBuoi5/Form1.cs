using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTrenLopBuoi5
{
    public partial class Form1 : Form
    {
        public delegate void TruyenDuLieu(String s);
        private String tk = "Nam";
        private String mk = "123";
        public Form1()
        {
            InitializeComponent();
        }
        

        private void btnGui_Click(object sender, EventArgs e)
        {
            //kiem tra thong tin dang nhap
            String TK = txtTK.Text;
            String MK = txtMK.Text;
           if (TK == tk && MK == mk)
            {
                // Mở Form2
                Form2 f2 = new Form2();

                // Gán delegate cho Form2
                TruyenDuLieu truyenDuLieu = new TruyenDuLieu(f2.NhanDuLieu);
                 truyenDuLieu(TK); // truyền dữ liệu
                f2.TDL += new Form2.TraDuLieu(this.NhanDL);
                //thong bao dang nhap thanh cong
                MessageBox.Show("Bạn đã Dăng nhập thành công", "Thông Báo");


                f2.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Sai Tài Khoản Hoạc Mật Khẩu, vui lòng đăng nhập lại", "Thông báo");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void NhanDL(String s)
        {
            label1.Text = s;
           this.Show();

        }
    }
}
