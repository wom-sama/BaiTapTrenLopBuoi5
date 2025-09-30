using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public delegate void OpenFile(string s);
        public OpenFile Open;
        // đánh số form
        private static int formCount = 0;
        public Form1()
        {
            InitializeComponent();
            Open = new OpenFile(LoadFile);
            formCount++;
            this.Text = "Soạn thảo văn bản " + formCount;

        }
        public void LoadFile(string s)
        {
            try
            {
                string ext = Path.GetExtension(s).ToLower();                
                richText.LoadFile(s, RichTextBoxStreamType.RichText);              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file: " + ex.Message);
            }
        }   
        private string currentFile = null;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = richText.Text.Split(new char[] { ' ', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            toolStrip1.Text = "Tổng số từ: " + words.Length;
            toolStripLabel1.Text = toolStripLabel1.Text = "Số ký tự: " + richText.Text.Length;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ngan nguoi dung nhap lieu vao combobox
            toolStripComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;


            toolStripComboBox2.Text = "Tahoma";
            toolStripComboBox3.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox2.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox3.Items.Add(s);
            }
            this.richText.SelectionChanged += new EventHandler(richText_SelectionChanged);

        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một Form mới
            Form1 newForm = new Form1();
            newForm.FormClosed += Program.OnFormClosed;
            newForm.Show();  // mở form mới

        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.SelectionColor = fontDlg.Color;
                richText.SelectionFont = fontDlg.Font;
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt;*.rtf|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo form mới
                Form1 newForm = new Form1();

                // Gán lại delegate cho form mới
                newForm.Open = newForm.LoadFile;

                // Gọi delegate để load file
                newForm.Open(ofd.FileName);
                // Đăng ký sự kiện FormClosed để xử lý khi form đóng
                newForm.FormClosed += Program.OnFormClosed;

                // Hiển thị form mới
                newForm.Show();
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text Format|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    richText.SaveFile(sfd.FileName);
                    currentFile = sfd.FileName;
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                }
            }
            else
            {
                richText.SaveFile(currentFile);
                MessageBox.Show("Lưu thành công!", "Thông báo");
            }

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
            tạoVănBảnMớiToolStripMenuItem_Click(sender, e);

        }

        private void Save_Click(object sender, EventArgs e)
        {
            lưuNộiDungVănBảnToolStripMenuItem_Click(sender, e);

        }
        // xử lý sự kiện click cho combobox
        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedItem != null && richText.SelectionFont != null)
            {
                string fontName = toolStripComboBox2.Text;
                float size = richText.SelectionFont.Size;
                richText.SelectionFont = new Font(fontName, size);
            }

        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripComboBox3.Text) && richText.SelectionFont != null)
            {
                string fontName = richText.SelectionFont.FontFamily.Name;
                float size = float.Parse(toolStripComboBox3.Text);
                richText.SelectionFont = new Font(fontName, size);
            }

        }
        // xử lý sự kiện click cho các button B, I, U
        private void B_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
                richText.SelectionFont = new Font(currentFont, newStyle);
                B.BackColor = richText.SelectionFont.Bold ? Color.Blue : SystemColors.Control;
            }

        }

        private void I_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
                richText.SelectionFont = new Font(currentFont, newStyle);
                I.BackColor = richText.SelectionFont.Italic ? Color.Blue : SystemColors.Control;
            }

        }

        private void U_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
                richText.SelectionFont = new Font(currentFont, newStyle);
                U.BackColor = richText.SelectionFont.Underline ? Color.Blue : SystemColors.Control;
            }

        }
        // thêm sự kiện SelectionChanged cho richTextBox để cập nhật combobox khi người dùng chọn văn bản
        private void richText_SelectionChanged(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                toolStripComboBox2.Text = richText.SelectionFont.FontFamily.Name;
                toolStripComboBox3.Text = richText.SelectionFont.Size.ToString();
            }
        }
        // thêm sự kiện SelectedIndexChanged cho combobox để xử lý khi người dùng chọn mục mới
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedItem != null && richText.SelectionFont != null)
            {
                string fontName = toolStripComboBox2.Text;
                float size = richText.SelectionFont.Size;
                richText.SelectionFont = new Font(fontName, size);
            }
        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripComboBox3.Text) && richText.SelectionFont != null)
            {
                string fontName = richText.SelectionFont.FontFamily.Name;
                float size = float.Parse(toolStripComboBox3.Text);
                richText.SelectionFont = new Font(fontName, size);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //nut mo file
            mởTậpTinToolStripMenuItem_Click(sender, e);

        }
    }
}
