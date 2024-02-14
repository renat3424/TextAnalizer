using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TextAnalyzer
{
    public partial class Form1 : Form
    {
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }
        
        FontDialog fd;
        
        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Gold; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Gold; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Gold; }
            }
        }

        int textLength;
        public Form1()
        {
            
            
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            textLength = 0;
            time.Start();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.Font;
            if (fd.ShowDialog() == DialogResult.OK)
            {
              
                richTextBox1.Font = fd.Font;
                

            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordFinder f = new WordFinder();
            f.mainForm = this;
            
            

            
            f.Show();
            

        }

       
      
        private void time_Tick(object sender, EventArgs e)
        {
            if (textLength != richTextBox1.Text.Length)
            {
                string a = richTextBox1.Text;
                int letters = a.Count(char.IsLetter);
                string[] b = richTextBox1.Text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int words = b.Length;
                int m;
                string biggestword = "";
                if (b.Length == 0)
                {
                    m = 0;
                }
                else
                {
                    m = b[0].Length;
                    biggestword = b[0];
                }

                for (int i = 0; i < words; i++)
                {


                    if (m < b[i].Length)
                    {

                        m = b[i].Length;
                        biggestword = b[i];
                    }
                }
                string another = "Number of words: " + words + " Number of Letters: " + letters + " Biggest word: " + biggestword;


                label1.Text = another;
                textLength = richTextBox1.Text.Length;
               
            }


        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "My open file dialog";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void longestWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LongWordsFinder f = new LongWordsFinder();
            f.mainForm = this;
            f.Stuf();
            f.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
   
        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|doc files(*.doc)|*.doc";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.ShowDialog();
            
            this.Text = "TextAnalyzer " + saveFileDialog.FileName;
            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            richTextBox1.ForeColor = Color.White;
        }

        private void копироватьToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставкаToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
    }
}
