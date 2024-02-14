using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public partial class WordFinder : Form
    {
        public WordFinder()
        {
            InitializeComponent();
        }
        String foundword;
        int t;
        public Form1 mainForm;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button buter = (Button)sender;
            buter.BackColor = Color.Gold;
            buter.ForeColor = Color.Black;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Button buter = (Button)sender;
            buter.BackColor = Color.Black;
            buter.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string word = textBox1.Text;
            if (word.Length == 1)
            {

                string a = mainForm.richTextBox1.Text;
                int k = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].ToString() == word)
                    {

                        k++;
                    }


                }

                label1.Text = "Number of words " + k;
                if (foundword == word && mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.None) != -1)
                {

                    t = mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.None);
                    if (t == -1)
                    {
                        t = 0;
                        return;
                    }
                    mainForm.richTextBox1.SelectionStart = t;
                    t = t + word.Length;
                    mainForm.richTextBox1.Focus();

                }
                else
                {

                    t = 0;
                    t = mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.None);
                    if (t == -1)
                    {
                        t = 0;
                        return;
                    }
                    mainForm.richTextBox1.SelectionStart = t;
                    t = t + word.Length;
                    mainForm.richTextBox1.Focus();
                }
                foundword = word;
            }
            else
            {


                string[] a = mainForm.richTextBox1.Text.Split(new char[] { '"', '.', '?', '!', ' ', ';', ':', ',', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                int k = 0;
                for(int i=0; i<a.Length; i++)
                {


                    if (a[i] == word)
                    {

                        k++;
                        
                         
                    }
                }
                label1.Text = "Number of words " + k;
                if (foundword == word && (mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.None) != -1))
                {

                    t = mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.WholeWord|RichTextBoxFinds.MatchCase);
                    if (t == -1)
                    {
                        t = 0;
                        return;
                    }
                    mainForm.richTextBox1.SelectionStart = t;
                    t = t + word.Length;
                    mainForm.richTextBox1.Focus();

                }
                else
                {

                    t = 0;
                    t = mainForm.richTextBox1.Find(word, t, RichTextBoxFinds.WholeWord|RichTextBoxFinds.MatchCase);
                    if (t == -1)
                    {
                        t = 0;
                        return;
                    }
                    mainForm.richTextBox1.SelectionStart = t;
                    t = t + word.Length;
                    mainForm.richTextBox1.Focus();
                }
                foundword = word;



            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
      
        private void MostCommon()
        {
            Action act;
            string[] a = new string[1];

            act = () => { a = mainForm.richTextBox1.Text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries); };
            Invoke(act);
            List<string> strs = new List<string>();
            string word = "";
            int k;
            int t = 0;
            for (int i = 0; i < a.Length; i++)
            {
                k = 0;
                if (!strs.Contains(a[i]))
                {
                    for (int j = 0; j < a.Length; j++)
                    {

                        if (a[i] == a[j])
                        {
                            k++;
                        }



                    }
                    strs.Add(a[i]);

                }

                if (k > t)
                {
                    t = k;
                    word = a[i];

                }



            }


            act = () => { label3.Text = word; button2.Enabled = true; };
            Invoke(act);
            

        }
        Thread newthread;
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Please wait";
            newthread = new Thread(MostCommon);
            newthread.Start();
            button2.Enabled = false;

            
        }
    }
}
