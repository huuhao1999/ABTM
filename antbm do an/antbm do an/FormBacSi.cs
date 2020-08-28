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
            string ten = textBox2.Text;
            string namsinh = textBox3.Text;
            string diachi = textBox4.Text;
            string sdt = textBox5.Text;
            string trieuchungbenh = textBox6.Text;
            
            if (diachi == "" || mabenhnhan == "" || ten == "" || trieuchungbenh == "" || sdt == "" || namsinh=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin.");
            }
            else
            {
                BacSi a = new BacSi();
                a.updatebenhnhan(conn, mabenhnhan, ten, namsinh, diachi, sdt, trieuchungbenh);
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
    }
}
