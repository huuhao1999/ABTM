
using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace antbm_do_an
{
    public partial class QLTNNS : Form
    {
        private OracleConnection conn;

        public QLTNNS(f_DangNhap form)
        {
            InitializeComponent();
            conn = form.conn;
        }


        private void QLTNNS_Load(object sender, EventArgs e)
        {
            try
            {
                cbbUpdate.Items.Add("PHONG_BAN");
                cbbUpdate.Items.Add("NHANVIEN");
                cbbUpdate.Items.Add("TRUC_PHONG_KHAM");

                cbbView.Items.Add("THUOC");
                cbbView.Items.Add("DICH_VU_KHAM_BENH");
                cbbView.Items.Add("DIEU_TRI");
                cbbView.Items.Add("DONTHUOC");
                cbbView.Items.Add("DANH_SACH_DON_THUOC");
                cbbView.Items.Add("DANH_SACH_SU_DUNG_DICH_VU");
                cbbView.Items.Add("LUONG");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        String tablename;
        private void cbbUpdate_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                String Utable = this.cbbUpdate.SelectedItem.ToString();
                tablename = Utable;
                dgvData.DataSource = QuanLy.getUpdateTable(conn, Utable);
                if (Utable != "PHONG_BAN" && Utable != "NHANVIEN" && Utable != "TRUC_PHONG_KHAM")
                {
                    dgvData.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        String  deleteID;
        String deleteTable;

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String ColName = this.dgvData.Columns[0].Name;
                String id = dgvData.Rows[e.RowIndex].Cells[ColName].Value.ToString();
                //MessageBox.Show(ColName);
                int temp;
                if (id == "")
                {
                    temp = 0;
                }
                else
                {
                    temp = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[ColName].Value.ToString());
                }
                if (temp == 0)
                {
                    if (tablename == "PHONG_BAN")
                    {
                        int c = QuanLy.getCount(conn, tablename) + 1;
                        String tenpb = dgvData.Rows[e.RowIndex].Cells["TENPB"].Value.ToString();
                        dgvData.DataSource = QuanLy.InsertTableDepartment(conn, tablename, c.ToString(), tenpb);
                    }
                    if (tablename == "NHANVIEN")
                    {
                        int c = QuanLy.getCount(conn, tablename) + 1;
                        String mapb = dgvData.Rows[e.RowIndex].Cells["MAPB"].Value.ToString();
                        String tennv = dgvData.Rows[e.RowIndex].Cells["TENNV"].Value.ToString();
                        String labacsi = dgvData.Rows[e.RowIndex].Cells["LABACSI"].Value.ToString();
                        String username = dgvData.Rows[e.RowIndex].Cells["username"].Value.ToString();
                        String luong = dgvData.Rows[e.RowIndex].Cells["LUONGCOBAN"].Value.ToString();
                        String phucap = dgvData.Rows[e.RowIndex].Cells["PHUCAP"].Value.ToString();
                        dgvData.DataSource = QuanLy.InsertTableStaff(conn, tablename, c.ToString(), mapb, tennv, labacsi, username, luong, phucap);
 
                    }
                    if (tablename == "TRUC_PHONG_KHAM")
                    {
                        //int c = QuanLy.getCount(conn, tablename) + 1;
                        String manv = dgvData.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
                        DateTime today = DateTime.Today;
                        String thoigian = today.ToString("dd-MMMM-yy");
                        //MessageBox.Show(thoigian);
                        dgvData.DataSource = QuanLy.InsertTableShift(conn, tablename, manv, thoigian);
                    }
                }
                else
                {
                    if (tablename == "PHONG_BAN")
                    {
                        String tenpb = dgvData.Rows[e.RowIndex].Cells["TENPB"].Value.ToString();
                        dgvData.DataSource = QuanLy.UpdateTableDepartment(conn, tablename, temp.ToString(), tenpb);
                    }
                    if (tablename == "NHANVIEN")
                    {
                        String mapb = dgvData.Rows[e.RowIndex].Cells["MAPB"].Value.ToString();
                        String tennv = dgvData.Rows[e.RowIndex].Cells["TENNV"].Value.ToString();
                        String labacsi = dgvData.Rows[e.RowIndex].Cells["LABACSI"].Value.ToString();
                        String username = dgvData.Rows[e.RowIndex].Cells["username"].Value.ToString();
                        String luong = dgvData.Rows[e.RowIndex].Cells["LUONGCOBAN"].Value.ToString();
                        String phucap = dgvData.Rows[e.RowIndex].Cells["PHUCAP"].Value.ToString();
                        dgvData.DataSource = QuanLy.UpdateTableStaff(conn, tablename, temp.ToString(), mapb, tennv, labacsi, username, luong, phucap);
                    }
                    if (tablename == "TRUC_PHONG_KHAM")
                    {
                        DateTime today = DateTime.Today;
                        String thoigian = today.ToString("dd-MMMM-yy");
                        String manv = dgvData.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
                        //String thoigian = dgvData.Rows[e.RowIndex].Cells["THOIGIANBATDAUTRUC"].Value.ToString();
                        dgvData.DataSource = QuanLy.UpdateTableShift(conn, tablename, temp.ToString(), manv, thoigian);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (deleteTable == "PHONG_BAN")
            {
                deleteID = dgvData.Rows[e.RowIndex].Cells["MAPB"].Value.ToString();
                MessageBox.Show(deleteID);
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (deleteTable == "PHONG_BAN")
                {
                    MessageBox.Show(deleteTable);
                    dgvData.DataSource = QuanLy.DeleteTableDepartment(conn, tablename, deleteID);
                }
                if (deleteTable == "NHANVIEN")
                {
                    dgvData.DataSource = QuanLy.DeleteTableDepartment(conn, tablename, deleteID);
                }
                if (deleteTable == "TRUC_PHONG_KHAM")
                {
                    dgvData.DataSource = QuanLy.DeleteTableDepartment(conn, tablename, deleteID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbbView_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                String Utable = this.cbbView.SelectedItem.ToString();
                tablename = Utable;
                dgvData.DataSource = QuanLy.getUpdateTable(conn, Utable);
                dgvData.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}