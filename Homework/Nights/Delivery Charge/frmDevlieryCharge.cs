using System;
using System.Windows.Forms;

namespace Delivery_Charge
{
    public partial class frmDevlieryCharge : Form
    {

        decimal[] deliveryCharge = { 20.00m, 12.00m, 25.00m, 15.00m, 10.00m, 23.00m, 18.00m, 20.00m, 17.00m, 12.00m };
        string[] zipCode = { "63101", "63103", "63105", "63109", "63113", "63118", "63130", "63133", "63136", "63137" };
                public frmDevlieryCharge()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtZipCode.Text = "";
            lblResult.Text = "";
            txtZipCode.Focus();
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

        private void frmDevlieryCharge_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateCharge();
        }

        private void CalculateCharge()
        {
            int Zipcode = 0;

            try
            {
                Zipcode = Convert.ToInt32(txtZipCode.Text.Trim());

                if(Zipcode <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                DetermineCost(Zipcode);

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

        private void DetermineCost(int Zipcode)
        {
            decimal delivery = 0.00m;
            
            string zipCodeStr = "";

            switch(Zipcode)
            {
                case 1:
                case 2:
                    delivery = deliveryCharge[0];
                    zipCodeStr = zipCode[0];
                    break;

                case 3:
                case 4:
                    delivery = deliveryCharge[1];
                    zipCodeStr = zipCode[1];
                    break;

                case 5:
                case 6:
                    delivery = deliveryCharge[2];
                    zipCodeStr = zipCode[2];
                    break;

                case 7:
                case 8:
                    delivery = deliveryCharge[3];
                    zipCodeStr = zipCode[3];
                    break;

                case 9:
                case 10:
                    delivery = deliveryCharge[4];
                    zipCodeStr = zipCode[4];
                    break;

                   
            }

            lblResult.Text = ($"{zipCodeStr}");
        }
    }
}
