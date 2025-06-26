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
    public partial class Promo : Form
    {
        private KonekService konekService;
        static string inputNumber = Login.inputNumber;

        public Promo(KonekService service)
        {
            InitializeComponent();
            konekService = service;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            // Account Menu Buttonn 
            i_Accounts accountForm = new i_Accounts(konekService);
            accountForm.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // HomePage Button
            HomePage homePageForm = new HomePage(konekService);
            homePageForm.Show();
            this.Hide();
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
        private void button20_Click(object sender, EventArgs e)
        {
            // Button Exit from Settings
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Button Logout
            Login loginForm = new Login(konekService);
            loginForm.Show();
            this.Hide();
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }



        private void button8_Click(object sender, EventArgs e)
        {
            // buttonpanel 1
            panel4.Visible = true;
            panel5.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // buttonpanel 1.2
            panel4.Visible = false;
            panel5.Visible = false;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            // btn next 2
            panel8.Visible = true;
            panel7.Visible = true;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            // btn next 2.2
            panel8.Visible = false;
            panel7.Visible = false;
        }











        private void button1_Click(object sender, EventArgs e)
        {
            // Konek59
            KonekService.promoName = "Konek59";
            KonekService.choicePromo = 1;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek59 Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek59!");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // Konek75
            KonekService.promoName = "Konek75";
            KonekService.choicePromo = 2;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek75 Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek75!");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            // Konek99
            KonekService.promoName = "Konek99";
            KonekService.choicePromo = 3;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek99 Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek99!");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            // Konek129
            KonekService.promoName = "Konek129";
            KonekService.choicePromo = 4;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek129 Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek129!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Konek75+
            KonekService.promoName = "Konek75+";
            KonekService.choicePromo = 5;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek75+ Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek75+!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Konek99+
            KonekService.promoName = "Konek99+";
            KonekService.choicePromo = 6;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek99+ Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek99+!");
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            // Konek35+
            KonekService.promoName = "Konek35+";
            KonekService.choicePromo = 7;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek35+ Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek35+!");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            // Konek249+
            KonekService.promoName = "Konek249+";
            KonekService.choicePromo = 8;

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                MessageBox.Show("Konek249 Activated!\nTransaction Successful!");
            }
            else
            {
                MessageBox.Show("Insufficient Load for Konek249!");
            }
        }







        private void label9_Click(object sender, EventArgs e)
        {

        }






















































        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // buttonpanel 2

        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            // buttonpanel 2.2

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // panel 1

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // panel 2 all time fav

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            // panel 2.2 all time fav
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Promo_Load(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }
    }
}
