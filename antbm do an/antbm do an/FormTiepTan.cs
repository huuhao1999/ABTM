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
    public partial class FormTiepTan: Form
    {
        private OracleConnection conn;
        public FormTiepTan(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;
        }
        public void getthongtinbenhnhan()
        {

            string mabenhnhan = textBox1.Text.ToString();
            if(mabenhnhan=="")
            { MessageBox.Show("Bạn chưa điền thông tin"); }
            else
            {
            dataGridView1.DataSource=TiepTan.getBenhNhan(conn, mabenhnhan);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getthongtinbenhnhan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mabenhnhan = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            string ten = dataGridView1.Rows[0].Cells[1].Value.ToString();
            int namsinh = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);
            string diachilienlac = dataGridView1.Rows[0].Cells[3].Value.ToString();
            int sdt = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
            string trieuchungbenh = dataGridView1.Rows[0].Cells[5].Value.ToString();
            Console.Write("ten:" + ten);
           TiepTan.updateBenhNhan(conn, mabenhnhan, ten, namsinh, diachilienlac,sdt,trieuchungbenh);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ten = dataGridView1.Rows[0].Cells[1].Value.ToString();
            int namsinh = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);
            string diachilienlac = dataGridView1.Rows[0].Cells[3].Value.ToString();
            int sdt = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
            string trieuchungbenh = dataGridView1.Rows[0].Cells[5].Value.ToString();
            TiepTan.addBenhNhan(conn, ten, namsinh, diachilienlac,sdt, trieuchungbenh);
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            Console.WriteLine("col:" + col);
            Console.WriteLine("row:" + row);
            if (col == 5)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "TRIEUCHUNGBENH")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();

                    string sql = "UPDATE DBA_USER.BENH_NHAN SET TRIEUCHUNGBENH = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    MessageBox.Show("Cập nhật thành công");
                    TiepTan.runSQL(conn, sql);

                }
            }
            if (col == 4)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "SDT")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();

                    string sql = "UPDATE DBA_USER.BENH_NHAN SET SDT = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    MessageBox.Show("Cập nhật thành công");
                   TiepTan.runSQL(conn, sql);

                }
            }
            if (col == 3)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "DIACHILIENLAC")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();

                    string sql = "UPDATE DBA_USER.BENH_NHAN SET DIACHILIENLAC = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    MessageBox.Show("Cập nhật thành công");
                    TiepTan.runSQL(conn, sql);

                }
            }
            if (col == 2)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "NAMSINH")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();

                    string sql = "UPDATE DBA_USER.BENH_NHAN SET NAMSINH = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    MessageBox.Show("Cập nhật thành công");
                    TiepTan.runSQL(conn, sql);

                }
            }
            if (col == 1)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "TEN")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();

                    string sql = "UPDATE DBA_USER.BENH_NHAN SET TEN = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    MessageBox.Show("Cập nhật thành công");
                    TiepTan.runSQL(conn, sql);

                }
            } 

        }
    
    }
}
