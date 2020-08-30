namespace antbm_do_an
{
    partial class FormCreateUserRole
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.UserName_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Add_User_button = new System.Windows.Forms.Button();
            this.Add_Role_button = new System.Windows.Forms.Button();
            this.Role_password_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Role_name_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(272, 132);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Add_User_button);
            this.tabPage1.Controls.Add(this.Password_textBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.UserName_textBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(264, 106);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "USER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Add_Role_button);
            this.tabPage2.Controls.Add(this.Role_password_textbox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Role_name_textBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(264, 106);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ROLE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // UserName_textBox
            // 
            this.UserName_textBox.Location = new System.Drawing.Point(6, 24);
            this.UserName_textBox.Name = "UserName_textBox";
            this.UserName_textBox.Size = new System.Drawing.Size(147, 20);
            this.UserName_textBox.TabIndex = 1;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(6, 65);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(147, 20);
            this.Password_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // Add_User_button
            // 
            this.Add_User_button.Location = new System.Drawing.Point(164, 24);
            this.Add_User_button.Name = "Add_User_button";
            this.Add_User_button.Size = new System.Drawing.Size(93, 61);
            this.Add_User_button.TabIndex = 4;
            this.Add_User_button.Text = "THEM USER";
            this.Add_User_button.UseVisualStyleBackColor = true;
            this.Add_User_button.Click += new System.EventHandler(this.Add_User_button_Click);
            // 
            // Add_Role_button
            // 
            this.Add_Role_button.Location = new System.Drawing.Point(161, 27);
            this.Add_Role_button.Name = "Add_Role_button";
            this.Add_Role_button.Size = new System.Drawing.Size(93, 61);
            this.Add_Role_button.TabIndex = 9;
            this.Add_Role_button.Text = "THEM ROLE";
            this.Add_Role_button.UseVisualStyleBackColor = true;
            this.Add_Role_button.Click += new System.EventHandler(this.Add_Role_button_Click);
            // 
            // Role_password_textbox
            // 
            this.Role_password_textbox.Location = new System.Drawing.Point(8, 68);
            this.Role_password_textbox.Name = "Role_password_textbox";
            this.Role_password_textbox.Size = new System.Drawing.Size(147, 20);
            this.Role_password_textbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // Role_name_textBox
            // 
            this.Role_name_textBox.Location = new System.Drawing.Point(8, 27);
            this.Role_name_textBox.Name = "Role_name_textBox";
            this.Role_name_textBox.Size = new System.Drawing.Size(147, 20);
            this.Role_name_textBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Role Name";
            // 
            // FormCreateUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 133);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormCreateUserRole";
            this.Text = "FormCreateUserRole";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Add_User_button;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Add_Role_button;
        private System.Windows.Forms.TextBox Role_password_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Role_name_textBox;
        private System.Windows.Forms.Label label4;
    }
}