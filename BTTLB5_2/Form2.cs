using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTLB5_2
{
    public partial class Form2 : Form
    {
        public Form2(String imgfile)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imgfile);
            Text = imgfile.Substring(imgfile.LastIndexOf("\\") + 1);
        }
    }
}
