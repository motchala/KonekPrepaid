using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonekCommon;
using KonekLogicProcess;

namespace KonekGUI
{
    public partial class Load : Form
    {
        private KonekService konekService;
        static string inputNumber = string.Empty;

        public Load(KonekService service)
        {
            InitializeComponent();
            konekService = service; // receive and store the passed instance
            inputNumber = Login.inputNumber;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Load_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // HomePage Button
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
            if (button7.Visible == false && button8.Visible == false && button9.Visible == false)
            {
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
            }
            else
            {
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Button Back from Settings
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Button Logout
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Enter Amount TextBox


        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Buy Load Button

            KonekService.loadAmount = Convert.ToInt32(textBox1.Text);


            if (KonekService.loadAmount < 10)
            {
                MessageBox.Show("    ! Transaction Unsuccessful !\n" +
                    "    ! Minimum load is 10 pesos !");
            }
            else
            {
                konekService.LoadProcess(inputNumber);
                MessageBox.Show("Transaction Successful!");
            }
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 10 load
            textBox1.Text = "10";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "20";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "30";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "50";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "100";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "150";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "180";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "200";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "250";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "300";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "500";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "800";

        }
    }
}
 