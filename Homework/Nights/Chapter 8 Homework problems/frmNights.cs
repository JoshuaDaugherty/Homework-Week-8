using System;
using System.Windows.Forms;

namespace Chapter_8_Homework_problems
{
    public partial class frmNights : Form
    {
        public frmNights()
        {
            InitializeComponent();
        }

        const decimal ONEORTWONIGHTS = 200.00m;
        const decimal THREEORFOURNIGHTS = 180.00m;
        const decimal FIVETOSEVENNIGHTS = 160.00m;
        const decimal EIGHTORMORENIGHTS = 145.00m;
        const string ONEORTWO = "One or Two";
        const string THREEORFOUR = "Three or Four";
        const string FIVETOSEVEN = "Five to Seven";
        const string EIGHTORMORE = "Eight or More";

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

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

                if(nights <= 0)
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

            totalCost = nightlyCost * nights;
            btnRate.Text = ($"{numNightsStr}");
            txtTotal.Text = ($"{totalCost:c}");
        }
    }
}
