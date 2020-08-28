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
                conn = Oracle.CreateDBConnection(username, password);
                LogedIn_Username = username;
                //MainForm.username = f_DangNhap_Username_textbox.Text;
                MessageBox.Show("Da dang nhap voi username:" +username);
                if (username.StartsWith("sy") == true)
                {
                    ChucNang_form MainFrom = new ChucNang_form(this);
                    MainFrom.Show();
                }
                if (username.StartsWith("bs") == true)
                {
                    FormBacSi bacsi = new FormBacSi(this);
                    bacsi.Show();
                }
                if (username.StartsWith("bt") == true)
                {
                    FormBanThuoc bt = new FormBanThuoc();
                    bt.Show();
                }
                
               
                this.Hide();
            }
            catch(Exception er)
            {
                MessageBox.Show("Error: " + er);
            }
        }
    }
}