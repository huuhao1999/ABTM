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
        public ChucNang_form MainForm;
        public FormCreateUserRole(ChucNang_form form )
        {
            MainForm = form;
            InitializeComponent();
        }

        private void Add_User_button_Click(object sender, EventArgs e)
        {
            try
            {
                Oracle.CreateUser(MainForm.Login_Form.conn, UserName_textBox.Text, Password_textBox.Text);
                MessageBox.Show("ĐA TAO USER " + UserName_textBox.Text + " THANH CONG!!", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.GetUsers();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Role_button_Click(object sender, EventArgs e)
        {
            try
            {
                Oracle.CreateRole(MainForm.Login_Form.conn, Role_name_textBox.Text, Role_password_textbox.Text);
                MessageBox.Show("ĐA TAO ROLE " + Role_name_textBox.Text + " THANH CONG!!", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.GetRoles();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
