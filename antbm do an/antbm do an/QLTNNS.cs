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
        String nvID;
        String nvMapb;
        String nvTen;
        String nvLabacsi;
        String nvUserName;
        String nvLuong;
        String nvPhucap;

        String pbID;
        String pbTen;

        String tpkMaNV;
        String tpkThoigian;

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

        String deleteTable;
        String tablename;
        private void cbbUpdate_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                String Utable = this.cbbUpdate.SelectedItem.ToString();
                tablename = Utable;
                deleteTable = Utable;
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
                        pbID = c.ToString();
                        String tenpb = dgvData.Rows[e.RowIndex].Cells["TENPB"].Value.ToString();
                        pbTen = tenpb;
                        //dgvData.DataSource = QuanLy.InsertTableDepartment(conn, tablename, c.ToString(), tenpb);
                    }
                    if (tablename == "NHANVIEN")
                    {
                        int c = QuanLy.getCount(conn, tablename) + 1;
                        nvID = c.ToString();
                        String mapb = dgvData.Rows[e.RowIndex].Cells["MAPB"].Value.ToString();
                        nvMapb = mapb;
                        String tennv = dgvData.Rows[e.RowIndex].Cells["TENNV"].Value.ToString();
                        nvTen = tennv;
                        String labacsi = dgvData.Rows[e.RowIndex].Cells["LABACSI"].Value.ToString();
                        nvLabacsi = labacsi;
                        String username = dgvData.Rows[e.RowIndex].Cells["username"].Value.ToString();
                        nvUserName = username;
                        String luong = dgvData.Rows[e.RowIndex].Cells["LUONGCOBAN"].Value.ToString();
                        nvLuong = luong;
                        String phucap = dgvData.Rows[e.RowIndex].Cells["PHUCAP"].Value.ToString();
                        nvPhucap = phucap;
                        //dgvData.DataSource = QuanLy.InsertTableStaff(conn, tablename, c.ToString(), mapb, tennv, labacsi, username, luong, phucap);
 
                    }
                    if (tablename == "TRUC_PHONG_KHAM")
                    {
                        //int c = QuanLy.getCount(conn, tablename) + 1;
                        String manv = dgvData.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
                        tpkMaNV = manv;
                        DateTime today = DateTime.Today;
                        String thoigian = today.ToString("dd-MMMM-yy");
                        tpkThoigian = thoigian;
                        //MessageBox.Show(thoigian);
                        //dgvData.DataSource = QuanLy.InsertTableShift(conn, tablename, manv, thoigian);
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
            }
            if (deleteTable == "NHANVIEN")
            {
                deleteID = dgvData.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            }
            if (deleteTable == "TRUC_PHONG_KHAM")
            {
                deleteID = dgvData.Rows[e.RowIndex].Cells["ID_TRUCPHONGKHAM"].Value.ToString();
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (deleteTable == "PHONG_BAN")
                {
                    dgvData.DataSource = QuanLy.DeleteTableDepartment(conn, tablename, deleteID);
                }
                if (deleteTable == "NHANVIEN")
                {
                    dgvData.DataSource = QuanLy.DeleteTableStaff(conn, tablename, deleteID);
                }
                if (deleteTable == "TRUC_PHONG_KHAM")
                {
                    dgvData.DataSource = QuanLy.DeleteTableShift(conn, tablename, deleteID);
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

        private void btnInsertRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablename == "PHONG_BAN")
                {
                    dgvData.DataSource = QuanLy.InsertTableDepartment(conn, tablename, pbID, pbTen);
                    pbID = null;
                    pbTen = null;
                    MessageBox.Show("Nhap phong ban moi thanh cong");
                }
                if (tablename == "NHANVIEN")
                {
                    dgvData.DataSource = QuanLy.InsertTableStaff(conn, tablename, nvID, nvMapb, nvTen, nvLabacsi, nvUserName, nvLuong, nvPhucap);
                    nvID = null;
                    nvMapb = null;
                    nvTen = null;
                    nvLabacsi = null;
                    nvUserName = null;
                    nvLuong = null;
                    nvPhucap = null;
                    MessageBox.Show("Nhap nhan vien moi thanh cong!");
                }
                if (tablename == "TRUC_PHONG_KHAM")
                {
                    dgvData.DataSource = QuanLy.InsertTableShift(conn, tablename, tpkMaNV, tpkThoigian);
                    tpkMaNV = null;
                    tpkThoigian = null;
                }
            }
            catch(Exception ex)
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