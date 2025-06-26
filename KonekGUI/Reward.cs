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
    public partial class Reward : Form
    {
        KonekService konekService;

        public Reward(KonekService service)
        {
            InitializeComponent();
            this.konekService = service;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // panel all rewards 1

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // rewards whole panel

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            // panel limited offer panel 2.2
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            // btnpanel 1.2
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            // btnpanel 2.2
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // btn next 1
            panel5.Visible = true;
            panel4.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // btn next 1.2
            panel5.Visible = false;
            panel4.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // btn next 2
            panel7.Visible = true;
            panel8.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // btn next 2.2
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // HomePage btn
            HomePage homePageForm = new HomePage(konekService);
            homePageForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Account Menu Buttonn 
            i_Accounts accountForm = new i_Accounts(konekService);
            accountForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Button Settings
            if (button17.Visible == false && button19.Visible == false && button20.Visible == false)
            {
                button17.Visible = true;
                button19.Visible = true;
                button20.Visible = true;
            }
            else
            {
                button17.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Theme
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Button Back from Settings
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Button Logout
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void Reward_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 1;
            KonekService.promoName = "Chamba Juice";
            
            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                    "Reward Cost: 2.0");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 2;
            KonekService.promoName = "Star Baks' Donut"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                    "Reward Cost: 4.5");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 3;
            KonekService.promoName = "FB1Day"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 2.9");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 4;
            KonekService.promoName = "YT1Hour"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 1.2");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 5;
            KonekService.promoName = "TextDay"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 0.5");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 6;
            KonekService.promoName = "TawagDay"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 0.7");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 7;
            KonekService.promoName = "TiktikDay"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 2.0");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            KonekService.choiceReward = 8;
            KonekService.promoName = "FB3Days"; // name of the reward

            if (konekService.CanPurchaseReward(Login.inputNumber))
            {
                konekService.UpdatesRewardPoints_FromReward(Login.inputNumber);
                MessageBox.Show("Reward redeemed successfully!\n" +
                                    "Reward Cost: 12.0");
            }
            else
            {
                MessageBox.Show("Insufficient Reward Points.");
            }
        }
    }
}
