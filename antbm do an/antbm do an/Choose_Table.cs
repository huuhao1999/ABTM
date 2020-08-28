using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace antbm_do_an
{
    public partial class Choose_Table : Form
    {
        public ChucNang_form MainForm;
        public string Priv_Type;
        public Choose_Table(ChucNang_form form, string Priv_Type)
        {
            this.Priv_Type = Priv_Type;
            MainForm = form;
            InitializeComponent();
            label1.Text = "CHON BANG DE GRANT QUYEN " + Priv_Type + ": ";
            All_Table_dataGridView.DataSource = Oracle.Get_All_Table(MainForm.Login_Form.conn);
            All_Table_dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            All_Table_dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            All_Table_dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Table_Name = All_Table_dataGridView.Rows[e.RowIndex].Cells["TABLE_NAME"].Value.ToString();
            string Owner = All_Table_dataGridView.Rows[e.RowIndex].Cells["OWNER"].Value.ToString();
            Table_Name = Owner + "." + Table_Name;
            Choose_Priv form = new Choose_Priv(MainForm,Priv_Type, Table_Name);
            form.Show();
        }
    }
}
