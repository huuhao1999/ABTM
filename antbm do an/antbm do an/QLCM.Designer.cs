namespace antbm_do_an
{
    partial class QLCM
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTableView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTableView = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTableView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbTableView);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 427);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvTableView
            // 
            this.dgvTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableView.Location = new System.Drawing.Point(3, 55);
            this.dgvTableView.Name = "dgvTableView";
            this.dgvTableView.Size = new System.Drawing.Size(771, 369);
            this.dgvTableView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên bảng cần xem:";
            // 
            // cbbTableView
            // 
            this.cbbTableView.FormattingEnabled = true;
            this.cbbTableView.Location = new System.Drawing.Point(347, 18);
            this.cbbTableView.Name = "cbbTableView";
            this.cbbTableView.Size = new System.Drawing.Size(184, 21);
            this.cbbTableView.TabIndex = 0;
            this.cbbTableView.SelectedIndexChanged += new System.EventHandler(this.cbbTableView_SelectedIndexChanged);
            this.cbbTableView.SelectedValueChanged += new System.EventHandler(this.cbbTableView_SelectedValueChanged);
            // 
            // QLCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "QLCM";
            this.Text = "QLCM";
            this.Load += new System.EventHandler(this.QLCM_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTableView;
        private System.Windows.Forms.DataGridView dgvTableView;
    }
}