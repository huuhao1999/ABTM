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
            this.SuspendLayout();
            // 
            // f_DangNhap_Username_textbox
            // 
            this.f_DangNhap_Username_textbox.Location = new System.Drawing.Point(16, 50);
            this.f_DangNhap_Username_textbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_Username_textbox.Name = "f_DangNhap_Username_textbox";
            this.f_DangNhap_Username_textbox.Size = new System.Drawing.Size(196, 22);
            this.f_DangNhap_Username_textbox.TabIndex = 0;
            this.f_DangNhap_Username_textbox.TextChanged += new System.EventHandler(this.f_DangNhap_Username_textbox_TextChanged);
            // 
            // f_DangNhap_Password_textbox
            // 
            this.f_DangNhap_Password_textbox.Location = new System.Drawing.Point(16, 106);
            this.f_DangNhap_Password_textbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_Password_textbox.Name = "f_DangNhap_Password_textbox";
            this.f_DangNhap_Password_textbox.Size = new System.Drawing.Size(196, 22);
            this.f_DangNhap_Password_textbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName (MaNV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // f_DangNhap_DangNhap_button
            // 
            this.f_DangNhap_DangNhap_button.Location = new System.Drawing.Point(240, 78);
            this.f_DangNhap_DangNhap_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.f_DangNhap_DangNhap_button.Name = "f_DangNhap_DangNhap_button";
            this.f_DangNhap_DangNhap_button.Size = new System.Drawing.Size(100, 53);
            this.f_DangNhap_DangNhap_button.TabIndex = 4;
            this.f_DangNhap_DangNhap_button.Text = "Dang Nhap";
            this.f_DangNhap_DangNhap_button.UseVisualStyleBackColor = true;
            this.f_DangNhap_DangNhap_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 155);
            this.Controls.Add(this.f_DangNhap_DangNhap_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.f_DangNhap_Password_textbox);
            this.Controls.Add(this.f_DangNhap_Username_textbox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "f_DangNhap";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_DangNhap_Username_textbox;
        private System.Windows.Forms.TextBox f_DangNhap_Password_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button f_DangNhap_DangNhap_button;
    }
}

