using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedPhrase
{
    public partial class frmSorted : Form
    {
        public frmSorted()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtPhrase.Text = "";
            lblResult.Text = "";
            txtPhrase.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void ExitForm()
        {
            DialogResult dialog = MessageBox.Show(
        "Do You Really Want To Exit The Program?",
        "EXIT NOW?",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SortWords();
        }

        private void SortWords()
        {
            string result = "";
            string phrase = txtPhrase.Text.Trim();
            string[] words = phrase.Split(' ');
            Array.Sort(words);
            foreach (string str in words)
            {
                result = result + " " + str;
            }
            lblResult.Text = result;
        }
    }
}

