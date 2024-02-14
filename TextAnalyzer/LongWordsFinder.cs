using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public partial class LongWordsFinder : Form
    {
        public Form1 mainForm;                                                                      
        public LongWordsFinder()
        {
            InitializeComponent();
          
           
            

        }
        public void Stuf()
        {
            string a = mainForm.richTextBox1.Text;
            string[] b = a.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = new string[10];
            int k = 0;
            
            while (k != 10 && k != b.Length)
            {

                string word = "";
                for (int i = 0; i < b.Length; i++)
                {


                    if (b[i].Length > word.Length && !words.Contains(b[i]))
                    {
                        word = b[i];

                    }
                }

                if (word != "")
                {
                    words[k] = word;
                    
                  

                }
                k++;
               
            }



           
            for(int i=0; i<k; i++)
            {
                textBox1.AppendText(words[i]+"\r\n");


            }
                
            



        }
        private void LongWordsFinder_Load(object sender, EventArgs e)
        {

        }
    }
}
