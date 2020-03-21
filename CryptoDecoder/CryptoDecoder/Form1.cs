using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace CryptoDecoder
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            string[] list = new string[] { "base64", "ROT-13" };
            comboBox1.Items.AddRange(list);
            InitializeComponent();
            
            
        }


        private void encode_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "base64")
            {
                //clears the box to prevent further additions and converts the text to base
                richTextBox2.Text = "";
                byte[] text = Encoding.UTF8.GetBytes(richTextBox1.Text);
                richTextBox2.Text = Convert.ToBase64String(text).ToString();


            }
            else if (comboBox1.Text == "ROT-13")
            {
                richTextBox2.Text = "";
                const int ROTC = 13;
                foreach (char i in richTextBox1.Text)
                {
                    int character = (int)i+ROTC;
                    richTextBox2.Text += Convert.ToChar(character);
                    //converts to unicode representation
                }
            }
           
            

        }

        private void decode_click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (comboBox1.Text == "base64")
            {
                //try catch to ensure that exceptions are caught and to prevent 
                try
                {
                    char[] newtext = Encoding.UTF8.GetChars(Convert.FromBase64String(richTextBox2.Text));
                    foreach(char i in newtext)
                    {
                        richTextBox1.Text += i;
                    }

                }
                catch(Exception b)
                {
                    label4.Text = "Please enter a valid Base64 string to deocde.";
                }

            }
            else if (comboBox1.Text == "ROT-13")
            {
                richTextBox1.Text = "";
                const int ROTC = 13;
                foreach (char i in richTextBox2.Text)
                {
                    int character = (int)i - ROTC;
                    richTextBox1.Text += Convert.ToChar(character);
                }

            }
         

        }

    }
}

