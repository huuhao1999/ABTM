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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public void readBenhNhan(OracleConnection conn)
        {

        }
        public void addBenhNhan(OracleConnection conn)
        {

        }
        public void updateBenhNhan(OracleConnection conn)
        {
            
        }
    }
}
