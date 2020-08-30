using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace antbm_do_an
{
    public partial class FormBacSi : Form
    {
        private OracleConnection conn;

        public FormBacSi(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;

           
        }

        public void getthongtinbenhnhan()
        {
            BacSi a = new BacSi();
            dataGridView1.DataSource = a.getthongtinbenhnhan(conn);
        }
        public void getthongtindonthuoc()
        {
            BacSi a = new BacSi();
            dataGridView2.DataSource = a.getthongdonthuoc(conn);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getthongtinbenhnhan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mabenhnhan = textBox1.Text;
            string trieuchungbenh = textBox6.Text;
            
            if (mabenhnhan == ""  || trieuchungbenh == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin.");
            }
            else
            {
                BacSi a = new BacSi();
                a.updatebenhnhan(conn, mabenhnhan, trieuchungbenh);
                MessageBox.Show("Cập nhật thông tin bệnh nhân thành công");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getthongtindonthuoc();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string madonthuoc = textBox2.Text;
            string idds = textBox3.Text;
            string mathuoc = textBox4.Text;
            string soluong = textBox5.Text;
            if (madonthuoc == "" || idds == "" || mathuoc == "" || soluong == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin.");
            }
            else
            {
                BacSi a = new BacSi();

               a.updatedonthuoc(conn, madonthuoc, idds, mathuoc, soluong);
            
                   MessageBox.Show("Cập nhật thông tin bệnh nhân thành công");
          
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BacSi a = new BacSi();
            a.themthuocvaodonthuoc(conn);
            string iddonthuoc =textBox7.Text;
            string mathuoc=textBox8.Text;
            string soluong=textBox9.Text;

            string sqlInsert = "INSERT INTO DBA_USER.DANH_SACH_DON_THUOC(ID_DANHSACHDONTHUOC, MADT, MATHUOC, SOLUONG, DONGIA) VALUES ((SELECT MAX(ID_DANHSACHDONTHUOC) FROM DBA_USER.DANH_SACH_DON_THUOC)+1, " + iddonthuoc + ", " + mathuoc + "," + soluong + ", 15000)";
                    // string sqlInsert = "INSERT INTO DBA_USER.DANH_SACH_DON_THUOC(ID_DANHSACHDONTHUOC, MADT, MATHUOC, SOLUONG, DONGIA) VALUES ( (SELECT MAX(ID_DANHSACHDONTHUOC) FROM DBA_USER.DANH_SACH_DON_THUOC ) + 1,"+iddonthuoc+", "+mathuoc+", "+soluong+", '30000')";
                     Console.Write(sqlInsert);
                    BacSi.runSQL(conn, sqlInsert);
            MessageBox.Show("Đã thêm thành công!");
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView2.SelectedCells[0].ColumnIndex;
            int row = dataGridView2.SelectedCells[0].RowIndex;
            Console.WriteLine("col:" + col);
            Console.WriteLine("row:" + row);
            if (col == 4)
            {
       
                if (dataGridView2.Columns[col].Name.ToUpper() == "MATHUOC")
                {
              
                    string mathuoc = dataGridView2.SelectedCells[0].Value.ToString();
                    string madsdt = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    string sql = "UPDATE DBA_USER.DANH_SACH_DON_THUOC SET MATHUOC= " + mathuoc + " WHERE ID_DANHSACHDONTHUOC=" + madsdt;
                    Console.Write(sql);
                    BacSi.runSQL(conn, sql);
                }
            }
            if (col == 5)
            {
          
                if (dataGridView2.Columns[col].Name.ToUpper() == "SOLUONG")
                {
                    string soluong = dataGridView2.SelectedCells[0].Value.ToString();
                    string mast = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    string sql = "UPDATE DBA_USER.DANH_SACH_DON_THUOC SET SOLUONG=" + soluong + " WHERE ID_DANHSACHDONTHUOC=" + mast;
                    Console.Write(sql);
                    BacSi.runSQL(conn, sql);
                }
            }  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            Console.WriteLine("col:" + col);
            Console.WriteLine("row:" + row);
            if (col == 3)
            {
                if (dataGridView1.Columns[col].Name.ToUpper() == "TRIEUCHUNGBENH")
                {
                    string trieuchungUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string mabenhnhan = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    string sql = "UPDATE DBA_USER.BENH_NHAN_BAC_SI_VIEW SET TRIEUCHUNGBENH = '" + trieuchungUpdate + "' WHERE MABENHNHAN=" + mabenhnhan;
                    Console.Write(sql);
                    BacSi.runSQL(conn, sql);
                }
            }  
        }
    }
}
