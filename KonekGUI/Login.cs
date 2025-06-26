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
using KonekCommon;

namespace KonekGUI
{
    public partial class Login : Form
    {
        KonekService konekService = new KonekService();
        public static string inputNumber = string.Empty;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Login Button


            inputNumber = textBox1.Text; // phone number
            KonekService.userPin = textBox2.Text; // password

            if (!konekService.ValidateAccount(inputNumber, KonekService.userPin)) // false
            {
                MessageBox.Show("Account don't match. Please try again!");
                // clear the text boxes
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {  // true
                HomePage homePage = new HomePage(konekService);
                homePage.Show();
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // phone number

        }

        private void textBox2_TextChanged(object sender, EventArgs e)   
        {
            // password

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // show password
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
