﻿namespace antbm_do_an
{
    partial class QLTNNS
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
            this.btnInsertRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.cbbView = new System.Windows.Forms.ComboBox();
            this.lblView = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.cbbUpdate = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInsertRecord);
            this.panel1.Controls.Add(this.btnDeleteRecord);
            this.panel1.Controls.Add(this.cbbView);
            this.panel1.Controls.Add(this.lblView);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.cbbUpdate);
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Location = new System.Drawing.Point(50, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 426);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnInsertRecord
            // 
            this.btnInsertRecord.Location = new System.Drawing.Point(297, 17);
            this.btnInsertRecord.Name = "btnInsertRecord";
            this.btnInsertRecord.Size = new System.Drawing.Size(131, 23);
            this.btnInsertRecord.TabIndex = 6;
            this.btnInsertRecord.Text = "Thêm dữ liệu";
            this.btnInsertRecord.UseVisualStyleBackColor = true;
            this.btnInsertRecord.Click += new System.EventHandler(this.btnInsertRecord_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(297, 46);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(131, 23);
            this.btnDeleteRecord.TabIndex = 5;
            this.btnDeleteRecord.Text = "Xóa dữ liệu đang chọn";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // cbbView
            // 
            this.cbbView.FormattingEnabled = true;
            this.cbbView.Location = new System.Drawing.Point(589, 32);
            this.cbbView.Name = "cbbView";
            this.cbbView.Size = new System.Drawing.Size(146, 21);
            this.cbbView.TabIndex = 4;
            this.cbbView.SelectedValueChanged += new System.EventHandler(this.cbbView_SelectedValueChanged);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(487, 35);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(96, 13);
            this.lblView.TabIndex = 3;
            this.lblView.Text = "Thông tin theo dõi:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(22, 35);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(132, 13);
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.Text = "Thông tin được chỉnh sửa:";
            // 
            // cbbUpdate
            // 
            this.cbbUpdate.FormattingEnabled = true;
            this.cbbUpdate.Location = new System.Drawing.Point(160, 32);
            this.cbbUpdate.Name = "cbbUpdate";
            this.cbbUpdate.Size = new System.Drawing.Size(131, 21);
            this.cbbUpdate.TabIndex = 1;
            this.cbbUpdate.SelectedIndexChanged += new System.EventHandler(this.cbbUpdate_SelectedIndexChanged);
            this.cbbUpdate.SelectedValueChanged += new System.EventHandler(this.cbbUpdate_SelectedValueChanged);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(3, 87);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(732, 336);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            // 
            // QLTNNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "QLTNNS";
            this.Text = "QLTNNS";
            this.Load += new System.EventHandler(this.QLTNNS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbbUpdate;
        private System.Windows.Forms.ComboBox cbbView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnInsertRecord;
    }
}