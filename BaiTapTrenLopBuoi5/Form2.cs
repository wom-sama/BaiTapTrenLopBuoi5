using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTrenLopBuoi5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        public void Fundtata(TextBox s)
        {
            lblNhan.Text = s.Text;
        }
        public void NhanDuLieu(string username)
        {
            lblNhan.Text = "Xin chào, " + username + "!";
            
            
        }
        public delegate void TraDuLieu(String s);
        public event TraDuLieu TDL;
       

        private void button1_Click(object sender, EventArgs e)
        {
            String x = textBox1.Text;
            TDL?.Invoke(x);
            this.Close();
            

        }
    }
}
