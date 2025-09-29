using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string currentFile = null;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = richText.Text.Split(new char[] { ' ', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            toolStrip1.Text = "Tổng số từ: " + words.Length;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            toolStripComboBox2.Text = "Tahoma";
            toolStripComboBox3.Text = "14";
            richText.Font = new Font("Tahoma", 14);
            currentFile = string.Empty;

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
            ofd.Filter = "Rich Text Format|*.rtf|Text Files|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.EndsWith(".rtf"))
                    richText.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                else
                    richText.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);



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
            Application.Exit();

        }

        private void New_Click(object sender, EventArgs e)
        {
            tạoVănBảnMớiToolStripMenuItem_Click(sender, e);

        }

        private void Save_Click(object sender, EventArgs e)
        {
            lưuNộiDungVănBảnToolStripMenuItem_Click(sender, e);

        }

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

        private void B_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }

        }

        private void I_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }

        }

        private void U_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }

        }
    }
}
