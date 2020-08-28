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
        public f_DangNhap Login_Form;
        public FormBacSi(f_DangNhap form)
        {
            InitializeComponent();
            Login_Form = form;
            InitializeComponent();
            getdieutri();
        }
        private void getdieutri()
        {
            BacSi.getdieutri(Login_Form.conn);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
