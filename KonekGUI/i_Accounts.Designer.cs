namespace KonekGUI
{
    partial class i_Accounts
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(186, 460);
            button1.Name = "button1";
            button1.Size = new Size(146, 47);
            button1.TabIndex = 0;
            button1.Text = "Done";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(110, 151);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "Full Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 243);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 2;
            label2.Text = "Account Number :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 196);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 3;
            label3.Text = "Email :";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(110, 340);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 4;
            label4.Text = "Load Balance :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 395);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 5;
            label5.Text = "Reward Points :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(110, 291);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 6;
            label6.Text = "Active Promo :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(186, 67);
            label7.Name = "label7";
            label7.Size = new Size(153, 28);
            label7.TabIndex = 7;
            label7.Text = "Account Details";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(301, 151);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 8;
            label8.Text = "label8";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(301, 196);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 9;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(301, 243);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 10;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(301, 291);
            label11.Name = "label11";
            label11.Size = new Size(58, 20);
            label11.TabIndex = 11;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(301, 340);
            label12.Name = "label12";
            label12.Size = new Size(58, 20);
            label12.TabIndex = 12;
            label12.Text = "label12";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(301, 395);
            label13.Name = "label13";
            label13.Size = new Size(58, 20);
            label13.TabIndex = 13;
            label13.Text = "label13";
            // 
            // i_Accounts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(521, 615);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "i_Accounts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "i_Accounts";
            Load += i_Accounts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}