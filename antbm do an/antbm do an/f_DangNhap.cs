﻿using System;
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
    public partial class f_DangNhap : Form
    {
        public OracleConnection conn;
        public string LogedIn_Username;
        public f_DangNhap()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = f_DangNhap_Username_textbox.Text;
                username=username.ToLower();
                string password = f_DangNhap_Password_textbox.Text;
                //Oracle db = new Oracle();
                //MainForm = new ChucNang_form();
                
                LogedIn_Username = username;
                //MainForm.username = f_DangNhap_Username_textbox.Text;
                //MessageBox.Show("Da dang nhap voi username:" +username);
                if (username.StartsWith("sy") == true || username.StartsWith("dba") == true)
                {
                    conn = Oracle.CreateDBConnection(username, password);
                    ChucNang_form MainFrom = new ChucNang_form(this);
                    MainFrom.Show();
                }
                if (username.StartsWith("tt") == true)
                {
                    conn = TiepTan.CreateDBConnection(username, password);
                    try
                    { 
                   // conn.Open();
                    FormTiepTan tieptan = new FormTiepTan(this);
                    tieptan.Show();
                     }
                    catch
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("kt") == true)
                {
                    conn = Oracle.CreateDBConnection(username, password);
                    conn.Open();
                    FormKeToan ketoan = new FormKeToan(this);
                    ketoan.Show();
                }
                if (username.StartsWith("bs") == true)
                {
                    conn = BacSi.CreateDBConnection(username, password);
                    try
                    {
                        conn.Open();
                        FormBacSi bacsi = new FormBacSi(this);
                        bacsi.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("bt") == true)
                {
                    conn = BacSi.CreateDBConnection(username, password);
                    try
                    {
                    FormBanThuoc bt = new FormBanThuoc(this);
                    bt.Show();
                                        }
                    catch
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("tv") == true)
                {
                    conn = TaiVu.CreateDBConnection(username, password);
                    try
                    {
                        conn.Open();
                        FormTaiVu f_tv = new FormTaiVu(this);
                        f_tv.Show();
                        //this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("ql002") == true)
                {
                    conn = TaiVu.CreateDBConnection(username, password);
                    try
                    {
                        conn.Open();
                        FormQuanLiTaiVu f_qltv = new FormQuanLiTaiVu(this);
                        f_qltv.Show();
                        //this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("ql001") == true)
                {
                    conn = QuanLy.CreateDBConnection(username, password);
                    try
                    {
                        conn.Open();
                        QLTNNS f_qltnns = new QLTNNS(this);
                        f_qltnns.Show();
                        //this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                if (username.StartsWith("ql003") == true)
                {
                    conn = QuanLy.CreateDBConnection(username, password);
                    try
                    {
                        conn.Open();
                        QLCM f_qlcm = new QLCM(this);
                        f_qlcm.Show();
                        //this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Error: " + er);
            }
        }

        private void f_DangNhap_Username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void f_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
