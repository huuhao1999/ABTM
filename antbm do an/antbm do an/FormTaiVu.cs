using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace antbm_do_an
{
    public partial class FormTaiVu : Form
    {
        private OracleConnection conn;
        public FormTaiVu(f_DangNhap login)
        {
            InitializeComponent();
            conn = login.conn;
            dataGridView1.DataSource = TaiVu.getViewTaiVu(conn);
            dataGridView1.ReadOnly = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            
            if (col == 5)
            {
                if(dataGridView1.Columns[col].Name.ToUpper()=="GIATIEN")
                {
                    string GiaTienUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string IDSuDungDichVu = dataGridView1.Rows[row].Cells[4].Value.ToString();
                    string sql = "UPDATE DBA_USER.DANH_SACH_SU_DUNG_DICH_VU SET GIATIEN=" + GiaTienUpdate + " WHERE ID_SUDUNGDICHVU=" + IDSuDungDichVu;
                    TaiVu.runSQL(conn, sql);
                }
            }    
            
        }
    }
}
