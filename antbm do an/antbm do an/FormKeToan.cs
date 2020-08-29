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
    public partial class FormKeToan : Form
    {
        private OracleConnection conn;
        public FormKeToan(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maNV = Convert.ToInt32(textBox2.Text);
            int thang = Convert.ToInt32(textBox3.Text);
            int nam = Convert.ToInt32(textBox4.Text);
            int songaycong = Convert.ToInt32(textBox5.Text);
            int luong = Convert.ToInt32(textBox6.Text);
            KeToan.insertLuong(conn, maNV, thang, nam, songaycong, luong);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int luongId = Convert.ToInt32(textBox1.Text);
            int songaycong = Convert.ToInt32(textBox5.Text);
            int luong = Convert.ToInt32(textBox6.Text);
            KeToan.updateLuong(conn, luongId, songaycong, luong);
        }

    }

}
