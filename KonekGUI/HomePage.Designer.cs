namespace KonekGUI
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label1 = new Label();
            button7 = new Button();
            button9 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 162);
            panel1.Name = "panel1";
            panel1.Size = new Size(659, 441);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(441, 53);
            button3.Name = "button3";
            button3.Size = new Size(196, 341);
            button3.TabIndex = 2;
            button3.Text = "REWARD";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(228, 41);
            button2.Name = "button2";
            button2.Size = new Size(207, 365);
            button2.TabIndex = 1;
            button2.Text = "LOAD";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(26, 53);
            button1.Name = "button1";
            button1.Size = new Size(196, 341);
            button1.TabIndex = 0;
            button1.Text = "PROMO";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Location = new Point(1, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(659, 49);
            panel2.TabIndex = 1;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkSlateGray;
            button6.FlatAppearance.BorderColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F);
            button6.ForeColor = Color.White;
            button6.Location = new Point(432, 0);
            button6.Name = "button6";
            button6.Size = new Size(205, 49);
            button6.TabIndex = 2;
            button6.Text = "Settings";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkSlateGray;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(228, 0);
            button5.Name = "button5";
            button5.Size = new Size(207, 49);
            button5.TabIndex = 1;
            button5.Text = "Home Page";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSlateGray;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(26, 0);
            button4.Name = "button4";
            button4.Size = new Size(206, 49);
            button4.TabIndex = 0;
            button4.Text = "Account";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(202, 90);
            label1.Name = "label1";
            label1.Size = new Size(260, 41);
            label1.TabIndex = 2;
            label1.Text = "SIM Credit System";
            // 
            // button7
            // 
            button7.FlatAppearance.BorderColor = Color.Gainsboro;
            button7.FlatAppearance.BorderSize = 0;
            button7.Location = new Point(433, 48);
            button7.Name = "button7";
            button7.Size = new Size(205, 39);
            button7.TabIndex = 3;
            button7.Text = "Exit";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += button7_Click;
            // 
            // button9
            // 
            button9.Location = new Point(433, 81);
            button9.Name = "button9";
            button9.Size = new Size(205, 39);
            button9.TabIndex = 5;
            button9.Text = "Log-out";
            button9.UseVisualStyleBackColor = true;
            button9.Visible = false;
            button9.Click += button9_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(661, 615);
            Controls.Add(button9);
            Controls.Add(button7);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomePage";
            Load += HomePage_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Label label1;
        private Button button7;
        private Button button9;
    }
}