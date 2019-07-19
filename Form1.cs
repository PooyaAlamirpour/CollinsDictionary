using CollinsDictionary.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollinsDictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                String Word = txtWord.Text;
                if(!String.IsNullOrEmpty(Word))
                {
                    String Dictionary = Collins.Search(Word);
                    if(!String.IsNullOrEmpty(Dictionary))
                    {
                        txtDictionary.Text = Dictionary;
                    }
                    else
                    {
                        txtDictionary.Text = "Nothing was finded.";
                    }
                }
                else
                {
                    MessageBox.Show("The word field must not be empty.");
                }
            }
        }
    }
}
