namespace antbm_do_an
{
    partial class Choose_Priv_Type
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
            this.Priv_Type_datagridview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Priv_Type_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // Priv_Type_datagridview
            // 
            this.Priv_Type_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Priv_Type_datagridview.Location = new System.Drawing.Point(12, 28);
            this.Priv_Type_datagridview.Name = "Priv_Type_datagridview";
            this.Priv_Type_datagridview.Size = new System.Drawing.Size(161, 196);
            this.Priv_Type_datagridview.TabIndex = 0;
            this.Priv_Type_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHON LOẠI QUYỀN";
            // 
            // Choose_Priv_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 236);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Priv_Type_datagridview);
            this.Name = "Choose_Priv_Type";
            this.Text = "Choose_Priv_Type";
            ((System.ComponentModel.ISupportInitialize)(this.Priv_Type_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Priv_Type_datagridview;
        private System.Windows.Forms.Label label1;
    }
}