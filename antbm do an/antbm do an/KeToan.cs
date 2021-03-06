﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antbm_do_an
{
    class KeToan
    {

        public static OracleConnection CreateDBConnection(string username, string password)
        {
            string host = "localhost";
            int port = 1521;
            string sid = "xe";
            return GetDBConnection(host, port, sid, username, password);
        }
        public static OracleConnection GetDBConnection(string host, int port, string sid, string user, string password)
        {
            string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + sid + ")));User Id=" + user + ";Password=" + password + ";";
            OracleConnection conn = new OracleConnection(ConnectionString);
            return conn;
        }

       
        public static void updateLuong(OracleConnection conn, int LuongId, int songaycong, int luong)
        {
            string sql = @"execute Update_SNC_LUONG_LUONG('" + LuongId + "', '" + songaycong + "','" + luong + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public static void insertLuong(OracleConnection conn, int MaNV, int thang, int nam, int songaycong,int luong)
        {
            string sql = @"execute insert_luong((SELECT MAX(mabenhnhan) FROM DBA_USER.ID-Luong) + 1,'" + MaNV + "', '" + thang + "','" + nam + "', '" + songaycong + "','" + luong + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        // public static DataTable getDonThuoc(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.DONTHUOC";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getDSDonThuoc(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.DANH_SACH_DON_THUOC";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getDVKhamBenh(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.DICH_VU_KHAM_BENH";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getDSDungDV(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.DANH_SACH_SU_DUNG_DICH_VU";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getDieuTri(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.DIEU_TRI";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getNhanVien(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.NHANVIEN";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getPhongBan(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.PHONG_BAN";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getTrucPhongKham(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.TRUC_PHONG_KHAM";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getLuong(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.ENCRYPTED_LUONG";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        // public static DataTable getCuocHop(OracleConnection conn)
        // {
        //     string sql = "SELECT * FROM DBA_USER.CUOC_HOP";
        //     OracleCommand cmd = new OracleCommand(sql, conn);
        //     OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //     DataTable temp = new DataTable();
        //     DA.Fill(temp);
        //     return temp;
        // }
        public static void runSQL(OracleConnection conn, string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { };
        }

    }
}


