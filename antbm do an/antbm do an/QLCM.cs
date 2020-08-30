using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace antbm_do_an
{
    public partial class QLCM : Form
    {
        private OracleConnection conn;

        public QLCM(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;
        }

        private void QLCM_Load(object sender, EventArgs e)
        {
            try
            { 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QLCM_Load_1(object sender, EventArgs e)
        {
            try
            {

                cbbTableView.Items.Add("PHONG_BAN");
                cbbTableView.Items.Add("NHANVIEN");
                cbbTableView.Items.Add("TRUC_PHONG_KHAM");
                cbbTableView.Items.Add("THUOC");
                cbbTableView.Items.Add("DICH_VU_KHAM_BENH");
                cbbTableView.Items.Add("DIEU_TRI");
                cbbTableView.Items.Add("DONTHUOC");
                cbbTableView.Items.Add("DANH_SACH_DON_THUOC");
                cbbTableView.Items.Add("DANH_SACH_SU_DUNG_DICH_VU");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        String tablename;

        private void cbbTableView_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                String Utable = this.cbbTableView.SelectedItem.ToString();
                tablename = Utable;
                dgvTableView.DataSource = QuanLy.getUpdateTable(conn, Utable);
                dgvTableView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbTableView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
