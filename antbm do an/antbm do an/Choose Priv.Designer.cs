namespace antbm_do_an
{
    partial class Choose_Priv
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
            this.Priv_dataGridView = new System.Windows.Forms.DataGridView();
            this.Grant_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Priv_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Priv_dataGridView
            // 
            this.Priv_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Priv_dataGridView.Location = new System.Drawing.Point(12, 25);
            this.Priv_dataGridView.Name = "Priv_dataGridView";
            this.Priv_dataGridView.Size = new System.Drawing.Size(561, 387);
            this.Priv_dataGridView.TabIndex = 0;
            this.Priv_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Priv_dataGridView_CellContentClick);
            // 
            // Grant_button
            // 
            this.Grant_button.Location = new System.Drawing.Point(12, 418);
            this.Grant_button.Name = "Grant_button";
            this.Grant_button.Size = new System.Drawing.Size(561, 33);
            this.Grant_button.TabIndex = 1;
            this.Grant_button.Text = "THUC HIEN GRANT";
            this.Grant_button.UseVisualStyleBackColor = true;
            this.Grant_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = " ";
            // 
            // Choose_Priv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grant_button);
            this.Controls.Add(this.Priv_dataGridView);
            this.Name = "Choose_Priv";
            this.Text = "Choose_Priv";
            ((System.ComponentModel.ISupportInitialize)(this.Priv_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Priv_dataGridView;
        private System.Windows.Forms.Button Grant_button;
        private System.Windows.Forms.Label label1;
    }
}