using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace antbm_do_an
{
    public partial class FormQuanLiTaiVu : Form
    {
        private OracleConnection conn;
        private static int num = 2;
        public FormQuanLiTaiVu(f_DangNhap login)
        {
            InitializeComponent();
            conn = login.conn;
            //dataGridView1.DataSource = TaiVu.getThuoc(login.conn);
            //login.conn
        }
        private void chuyen_mau(Label lb, int a, int b)
        {
            lb.BackColor = Color.FromName("Control");
            lb.ForeColor = Color.FromName("HotTrack");
            num = a;
            if(a!=b)
            {
                switch (b)
                {
                    case 1:
                        {
                            label1.BackColor = Color.FromName("HotTrack");
                            label1.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 2:
                        {
                            label2.BackColor = Color.FromName("HotTrack");
                            label2.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 3:
                        {
                            label3.BackColor = Color.FromName("HotTrack");
                            label3.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 4:
                        {
                            label4.BackColor = Color.FromName("HotTrack");
                            label4.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 5:
                        {
                            label5.BackColor = Color.FromName("HotTrack");
                            label5.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 6:
                        {
                            label6.BackColor = Color.FromName("HotTrack");
                            label6.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 7:
                        {
                            label7.BackColor = Color.FromName("HotTrack");
                            label7.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 8:
                        {
                            label8.BackColor = Color.FromName("HotTrack");
                            label8.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 9:
                        {
                            label9.BackColor = Color.FromName("HotTrack");
                            label9.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 10:
                        {
                            label10.BackColor = Color.FromName("HotTrack");
                            label10.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 11:
                        {
                            label11.BackColor = Color.FromName("HotTrack");
                            label11.ForeColor = Color.FromName("Control");
                            break;
                        }
                    case 12:
                        {
                            label12.BackColor = Color.FromName("HotTrack");
                            label12.ForeColor = Color.FromName("Control");
                            break;
                        }
                }

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            chuyen_mau(label1, 1, num);
            dataGridView1.DataSource = TaiVu.getThuoc(conn);
            dataGridView1.ReadOnly = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            chuyen_mau(label2, 2, num);
            dataGridView1.DataSource = TaiVu.getBenhNhan(conn);
            dataGridView1.ReadOnly = true;
        }


        private void label3_Click(object sender, EventArgs e)
        {
            chuyen_mau(label3, 3, num);
            dataGridView1.DataSource = TaiVu.getDonThuoc(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            chuyen_mau(label4, 4, num);
            dataGridView1.DataSource = TaiVu.getDSDonThuoc(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            chuyen_mau(label5, 5, num);
            dataGridView1.DataSource = TaiVu.getDVKhamBenh(conn);
            dataGridView1.ReadOnly = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            chuyen_mau(label6, 6, num);
            dataGridView1.DataSource = TaiVu.getDSDungDV(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            chuyen_mau(label7, 7, num);
            dataGridView1.DataSource = TaiVu.getDieuTri(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            chuyen_mau(label8, 8, num);
            dataGridView1.DataSource = TaiVu.getNhanVien(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            chuyen_mau(label9, 9, num);
            dataGridView1.DataSource = TaiVu.getPhongBan(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            chuyen_mau(label10, 10, num);
            dataGridView1.DataSource = TaiVu.getTrucPhongKham(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            chuyen_mau(label11, 11, num);
            dataGridView1.DataSource = TaiVu.getLuong(conn);
            dataGridView1.ReadOnly = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            chuyen_mau(label12, 12, num);
            dataGridView1.DataSource = TaiVu.getCuocHop(conn);
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("hahaha");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            
            if (col == 2)
            {
                if(dataGridView1.Columns[col].Name.ToUpper()=="GIATHUOC")
                {
                    string GiaThuocUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string MaThuoc = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    string sql = "UPDATE DBA_USER.THUOC SET GIATHUOC=" + GiaThuocUpdate + " WHERE MATHUOC=" + MaThuoc;
                    TaiVu.runSQL(conn, sql);
                }
                else if (dataGridView1.Columns[col].Name.ToUpper() == "GIADV")
                {
                    string GiaDVUpdate = dataGridView1.SelectedCells[0].Value.ToString();
                    string MaDV = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    string sql = "UPDATE DBA_USER.DICH_VU_KHAM_BENH SET GIADV=" + GiaDVUpdate + " WHERE MADV=" + MaDV;
                    TaiVu.runSQL(conn, sql);
                }
            }    
            
        }
    }
}
