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
    public partial class HomePage : Form
    {
        private KonekService konekService;

        public HomePage(KonekService service)
        {
            InitializeComponent();
            konekService = service;
        }


        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Load loadForm = new Load(konekService);
            loadForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Promo promoForm = new Promo(konekService);
            promoForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // HomePage Button

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Rewards Button
            Reward rewardForm = new Reward(konekService);
            rewardForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Account Menu Buttonn 
            i_Accounts accountForm = new i_Accounts(konekService);
            accountForm.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Log-out button
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Settings buttons
            if (button7.Visible == false && button8.Visible == false && button9.Visible == false)
            {
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;

            }else
            {
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Button Exit from Settings
            this.Close();
        }
    }
}
