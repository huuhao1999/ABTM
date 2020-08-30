namespace antbm_do_an
{
    partial class f_DangNhap
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
            this.f_DangNhap_Username_textbox = new System.Windows.Forms.TextBox();
            this.f_DangNhap_Password_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.f_DangNhap_DangNhap_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // f_DangNhap_Username_textbox
            // 
            this.f_DangNhap_Username_textbox.Location = new System.Drawing.Point(223, 87);
            this.f_DangNhap_Username_textbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_Username_textbox.Name = "f_DangNhap_Username_textbox";
            this.f_DangNhap_Username_textbox.Size = new System.Drawing.Size(183, 22);
            this.f_DangNhap_Username_textbox.TabIndex = 0;
            this.f_DangNhap_Username_textbox.Text = "dba_user";
            this.f_DangNhap_Username_textbox.TextChanged += new System.EventHandler(this.f_DangNhap_Username_textbox_TextChanged);
            // 
            // f_DangNhap_Password_textbox
            // 
            this.f_DangNhap_Password_textbox.Location = new System.Drawing.Point(223, 135);
            this.f_DangNhap_Password_textbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_Password_textbox.Name = "f_DangNhap_Password_textbox";
            this.f_DangNhap_Password_textbox.PasswordChar = '*';
            this.f_DangNhap_Password_textbox.Size = new System.Drawing.Size(183, 22);
            this.f_DangNhap_Password_textbox.TabIndex = 1;
            this.f_DangNhap_Password_textbox.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(59, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName (MaNV):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(59, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // f_DangNhap_DangNhap_button
            // 
            this.f_DangNhap_DangNhap_button.BackColor = System.Drawing.Color.CadetBlue;
            this.f_DangNhap_DangNhap_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.f_DangNhap_DangNhap_button.ForeColor = System.Drawing.SystemColors.Control;
            this.f_DangNhap_DangNhap_button.Location = new System.Drawing.Point(173, 188);
            this.f_DangNhap_DangNhap_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_DangNhap_button.Name = "f_DangNhap_DangNhap_button";
            this.f_DangNhap_DangNhap_button.Size = new System.Drawing.Size(125, 43);
            this.f_DangNhap_DangNhap_button.TabIndex = 4;
            this.f_DangNhap_DangNhap_button.Text = "Đăng nhập";
            this.f_DangNhap_DangNhap_button.UseVisualStyleBackColor = false;
            this.f_DangNhap_DangNhap_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(143, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quản lí bệnh viện";
            // 
            // f_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 273);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.f_DangNhap_DangNhap_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.f_DangNhap_Password_textbox);
            this.Controls.Add(this.f_DangNhap_Username_textbox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "f_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.f_DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_DangNhap_Username_textbox;
        private System.Windows.Forms.TextBox f_DangNhap_Password_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button f_DangNhap_DangNhap_button;
        private System.Windows.Forms.Label label3;
    }
}

