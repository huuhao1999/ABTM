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
    public partial class FormBanThuoc : Form
    {
                private OracleConnection conn;
                public FormBanThuoc(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;
        }
                public void getchitietdonthuocc()
                {
                    BacSi a = new BacSi();
                    string ab = textBox1.Text;
                    if (ab=="")
                    {
                        MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                    }
                    else { dataGridView1.DataSource = a.getDonThuoc(conn, ab); }
                    
                }
                public void getchitietdonthuocc1()
                {
                    BacSi a = new BacSi();
                    
                    dataGridView1.DataSource = a.getDonThuoc1(conn);

                }

        private void button1_Click(object sender, EventArgs e)
        {
            getchitietdonthuocc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getchitietdonthuocc1();
        }
    }
}
