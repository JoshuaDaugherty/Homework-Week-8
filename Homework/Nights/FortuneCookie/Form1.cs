﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortuneCookie
{
    public partial class frmCookie : Form
    {
        public frmCookie()
        {
            InitializeComponent();
        }

        string[] Fortune = { "Birthdays are like friends. The more you have the better.",
                             "Your smile is a treasure to all who know you.",
                             "You never hesitate to tackle the most difficult problems.",
                             "The most obvious solution is not always the best.",
                             "If you want the rainbow, you will have to tolerate the rain.",
                             "The early bird gets the worm, but the second mouse gets the cheese.",
                              "From listening comes wisdom and from speaking repentance",
                             "A smile is your personal welcome mat.",
                             "Courage is not the absence of fear; it is the conquest of it.",
                             "A ship in harbor is safe, but that’s not why ships are built",
                             "The wise man is the one that makes you think that he is dumb.",
                             "One that would have the fruit must climb the tree."};

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            lblResult.Text = "";
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GenerateFortune();
        }

        private void GenerateFortune()
        {
            // Create a Random object
            Random rand = new Random();
            // Generate a random index less than the size of the array.
            int index = rand.Next(Fortune.Length);

            lblResult.Text = ($"{Fortune[index]}");
            
        }
        
    }
}
