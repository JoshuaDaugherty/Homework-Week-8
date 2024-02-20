using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayNights
{
    public partial class frmArrayNights : Form
    {
        public frmArrayNights()
        {
            InitializeComponent();
        }

        decimal[] nightCost = { 200.00m, 180.00m, 160.00m, 145.00m };
        string[] numNights = { "One or Two", "Three or Four", "Five to Seven", "Eight or More" };

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtNightsStayed.Text = "";
            txtCost.Text = "";
            txtTotal.Text = "";
            txtNightsStayed.Focus();
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DetermineNightsStayed();
        }

        private void DetermineNightsStayed()
        {
            int nights = 0;

            try
            {
                nights = Convert.ToInt32(txtNightsStayed.Text.Trim());

                if (nights <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                DetermineBill(nights);
            }
            catch (FormatException fe)
            {
                ShowErrorMessage("System Message:\t" + fe.Message +
                            "\n\n" + "Nights Must be An Integer",
                            "FormatException");
                ClearForm();
                return;

            }
            catch (ArgumentOutOfRangeException aoore)
            {
                ShowErrorMessage("System Message:\t" + aoore.Message +
                            "\n\n" + "Nights Must be An Integer > 0",
                            "ArugmentOutOfRangeException");
                ClearForm();
                return;
            }
        }

        private void DetermineBill(int nights)
        {
            decimal nightlyCost = 0.00m;
            decimal totalCost = 0.00m;
            string numNightsStr = "";

            switch(nights)
            {
                case 1:
                case 2:
                    nightlyCost = nightCost[0];
                    numNightsStr = numNights[0];
                    break;

                case 3:
                case 4:
                    nightlyCost = nightCost[1];
                    numNightsStr = numNights[1];
                    break;

                case 5:
                case 6:
                case 7:
                    nightlyCost = nightCost[2];
                    numNightsStr = numNights[2];
                    break;

                default:
                    nightlyCost = nightCost[3];
                    numNightsStr = numNights[3];
                    break;


            }

            totalCost = nightlyCost * nights;
            btnRate.Text = ($"{numNightsStr}");
            txtTotal.Text = ($"{totalCost:c}");
        }
    }
}
