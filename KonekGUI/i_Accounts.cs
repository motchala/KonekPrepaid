using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonekLogicProcess;

namespace KonekGUI
{
    public partial class i_Accounts : Form
    {
        private KonekService konekService;
        static string inputNumber = string.Empty;
        public i_Accounts(KonekService service)
        {
            InitializeComponent();
            konekService = service;

            inputNumber = Login.inputNumber;
            RefreshAccountInfo();
            CheckActivePromo();
        }
        public void CheckActivePromo() // pampagana sa active promo
        {
            string promoName = konekService.GetActivePromo(inputNumber);
            if (!string.IsNullOrEmpty(promoName))
            {
                label11.Text = promoName;
            }
            else
            {
                label11.Text = "No Active Promo";
            }
        }


        public void RefreshAccountInfo()
        {
            label8.Text = konekService.GetAccountName(inputNumber);
            label9.Text = konekService.GetAccountEmail(inputNumber);
            label10.Text = konekService.GetAccountNumber(inputNumber);
            label11.Text = konekService.GetActivePromo(inputNumber);
            label12.Text = konekService.GetAccountBalance(inputNumber).ToString(); // updated
            label13.Text = konekService.GetAccountRewardPoints(inputNumber).ToString();
        }







































        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Done Button
            this.Hide();
        }

        private void i_Accounts_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
