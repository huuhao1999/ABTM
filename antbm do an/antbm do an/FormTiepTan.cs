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

        private void button1_Click(object sender, EventArgs e)
        {
            string mabenhnhan = textBox1.Text.ToString();
            TiepTan.getBenhNhan(conn, mabenhnhan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mabenhnhan = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            string ten = dataGridView1.Rows[0].Cells[1].Value.ToString();
            int namsinh = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);
            string diachilienlac = dataGridView1.Rows[0].Cells[3].Value.ToString();
            int sdt = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
            string trieuchungbenh = dataGridView1.Rows[0].Cells[5].Value.ToString();
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
    
    }
}
