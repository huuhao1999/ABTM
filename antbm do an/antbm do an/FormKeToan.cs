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
    }
}
