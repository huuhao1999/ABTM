namespace antbm_do_an
{
    partial class ChucNang_form
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
            this.NAME_label = new System.Windows.Forms.Label();
            this.ChonRole_button = new System.Windows.Forms.Button();
            this.ChonUser_button = new System.Windows.Forms.Button();
            this.GanQuyen_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Select_User_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select_User_dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.RoleGrantedToUser_dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.user_comboBox = new System.Windows.Forms.ComboBox();
            this.role_comboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Select_User_dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_User_dataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGrantedToUser_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 464);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NAME_label);
            this.tabPage1.Controls.Add(this.ChonRole_button);
            this.tabPage1.Controls.Add(this.ChonUser_button);
            this.tabPage1.Controls.Add(this.GanQuyen_button);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.user_comboBox);
            this.tabPage1.Controls.Add(this.role_comboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // NAME_label
            // 
            this.NAME_label.AutoSize = true;
            this.NAME_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAME_label.ForeColor = System.Drawing.Color.Red;
            this.NAME_label.Location = new System.Drawing.Point(77, 102);
            this.NAME_label.Name = "NAME_label";
            this.NAME_label.Size = new System.Drawing.Size(0, 13);
            this.NAME_label.TabIndex = 25;
            // 
            // ChonRole_button
            // 
            this.ChonRole_button.Location = new System.Drawing.Point(291, 69);
            this.ChonRole_button.Name = "ChonRole_button";
            this.ChonRole_button.Size = new System.Drawing.Size(96, 21);
            this.ChonRole_button.TabIndex = 24;
            this.ChonRole_button.Text = "Chon Role";
            this.ChonRole_button.UseVisualStyleBackColor = true;
            this.ChonRole_button.Click += new System.EventHandler(this.ChonRole_button_Click);
            // 
            // ChonUser_button
            // 
            this.ChonUser_button.Location = new System.Drawing.Point(291, 29);
            this.ChonUser_button.Name = "ChonUser_button";
            this.ChonUser_button.Size = new System.Drawing.Size(96, 21);
            this.ChonUser_button.TabIndex = 23;
            this.ChonUser_button.Text = "Chon user";
            this.ChonUser_button.UseVisualStyleBackColor = true;
            this.ChonUser_button.Click += new System.EventHandler(this.ChonUser_button_Click);
            // 
            // GanQuyen_button
            // 
            this.GanQuyen_button.Location = new System.Drawing.Point(415, 29);
            this.GanQuyen_button.Name = "GanQuyen_button";
            this.GanQuyen_button.Size = new System.Drawing.Size(217, 61);
            this.GanQuyen_button.TabIndex = 21;
            this.GanQuyen_button.Text = "GAN QUYEN CHO USER/ROLE";
            this.GanQuyen_button.UseVisualStyleBackColor = true;
            this.GanQuyen_button.Click += new System.EventHandler(this.GanQuyen_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "QUYEN CUA ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(3, 118);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(646, 314);
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Select_User_dataGridView1);
            this.tabPage3.Controls.Add(this.Select_User_dataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 288);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "SELECT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Select_User_dataGridView1
            // 
            this.Select_User_dataGridView1.AllowUserToAddRows = false;
            this.Select_User_dataGridView1.AllowUserToDeleteRows = false;
            this.Select_User_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Select_User_dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.Select_User_dataGridView1.Name = "Select_User_dataGridView1";
            this.Select_User_dataGridView1.ReadOnly = true;
            this.Select_User_dataGridView1.Size = new System.Drawing.Size(629, 282);
            this.Select_User_dataGridView1.TabIndex = 8;
            // 
            // Select_User_dataGridView
            // 
            this.Select_User_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Select_User_dataGridView.Location = new System.Drawing.Point(3, -32768);
            this.Select_User_dataGridView.Name = "Select_User_dataGridView";
            this.Select_User_dataGridView.Size = new System.Drawing.Size(427, 282);
            this.Select_User_dataGridView.TabIndex = 6;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.RoleGrantedToUser_dataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(638, 288);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ROLE";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // RoleGrantedToUser_dataGridView
            // 
            this.RoleGrantedToUser_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleGrantedToUser_dataGridView.Location = new System.Drawing.Point(3, 4);
            this.RoleGrantedToUser_dataGridView.Name = "RoleGrantedToUser_dataGridView";
            this.RoleGrantedToUser_dataGridView.Size = new System.Drawing.Size(629, 281);
            this.RoleGrantedToUser_dataGridView.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ROLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "USER";
            // 
            // user_comboBox
            // 
            this.user_comboBox.FormattingEnabled = true;
            this.user_comboBox.Location = new System.Drawing.Point(6, 29);
            this.user_comboBox.Name = "user_comboBox";
            this.user_comboBox.Size = new System.Drawing.Size(264, 21);
            this.user_comboBox.TabIndex = 10;
            this.user_comboBox.SelectedIndexChanged += new System.EventHandler(this.user_comboBox_SelectedIndexChanged);
            // 
            // role_comboBox
            // 
            this.role_comboBox.FormattingEnabled = true;
            this.role_comboBox.Location = new System.Drawing.Point(6, 69);
            this.role_comboBox.Name = "role_comboBox";
            this.role_comboBox.Size = new System.Drawing.Size(264, 21);
            this.role_comboBox.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ChucNang_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "ChucNang_form";
            this.Text = "Chuc Nang";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Select_User_dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_User_dataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleGrantedToUser_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox user_comboBox;
        private System.Windows.Forms.ComboBox role_comboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Select_User_dataGridView1;
        private System.Windows.Forms.Button GanQuyen_button;
        private System.Windows.Forms.Button ChonRole_button;
        private System.Windows.Forms.Button ChonUser_button;
        private System.Windows.Forms.Label NAME_label;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView Select_User_dataGridView;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView RoleGrantedToUser_dataGridView;
    }
}