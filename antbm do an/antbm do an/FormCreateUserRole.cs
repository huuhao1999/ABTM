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
    public partial class FormCreateUserRole : Form
    {
        public OracleConnection conn;
        public FormCreateUserRole(ChucNang_form MainForm)
        {
            conn = MainForm.Login_Form.conn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oracle.CreateUser(conn, Add_username_textBox.Text, Add_Password_textBox.Text);
        }

        private void THEM_ROLE_BUTTON_Click(object sender, EventArgs e)
        {
            Oracle.CreateUser(conn, Add_RoleName_textBox.Text, Add_Role_password_textBox.Text);
        }
    }
}
