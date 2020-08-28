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
    public partial class FormQuanLiTaiVu : Form
    {
        private OracleConnection conn;
        public FormQuanLiTaiVu(f_DangNhap login)
        {
            InitializeComponent();
            conn = login.conn;
            //dataGridView1.DataSource = TaiVu.getThuoc(login.conn);
            //login.conn
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TaiVu.getThuoc(conn);
            Console.WriteLine("asasasdasasd");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TaiVu.updateThuoc(conn);
        }
    }
}
