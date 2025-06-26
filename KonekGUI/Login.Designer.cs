namespace KonekGUI
{
    partial class Login
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(236, 432);
            button1.Name = "button1";
            button1.Size = new Size(195, 46);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(262, 202);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 1;
            label1.Text = "Contact Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(186, 92);
            label2.Name = "label2";
            label2.Size = new Size(288, 46);
            label2.TabIndex = 2;
            label2.Text = "SIM Credit Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(289, 307);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(195, 241);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 31);
            textBox1.TabIndex = 4;
            textBox1.UseWaitCursor = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(195, 349);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(270, 31);
            textBox2.TabIndex = 5;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.FlatAppearance.BorderColor = Color.LightGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(471, 345);
            button2.Name = "button2";
            button2.Size = new Size(36, 36);
            button2.TabIndex = 6;
            button2.Text = "👁";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(661, 615);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
    }
}