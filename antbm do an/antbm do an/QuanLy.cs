
﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data.Common;
using System.Data;

namespace antbm_do_an
{
    class QuanLy
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

        public static DataTable getUpdateTable(OracleConnection conn, string a)
        {
            if(a == "NHANVIEN")
            {
                a = a + " ORDER BY MANV";
            }
            string sql = "SELECT * FROM DBA_USER." + a;
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);
            return temp;
        }

        public static int getCount(OracleConnection conn, string tablename)
        {
            string sql = "SELECT COUNT(*) FROM DBA_USER." + tablename;
            OracleCommand cmd = new OracleCommand(sql, conn);
            String count = cmd.ExecuteScalar().ToString();
            return Convert.ToInt32(count);
        }
        // them vao bang PHONG_BAN
        public static DataTable InsertTableDepartment(OracleConnection conn, string TableName, string value1, string value2)
        {
            string sql = "Insert into DBA_USER." + TableName + "(MaPB, TenPB) values (" + value1 + ", '" + value2 + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Cap nhat TENPB trong bang PHONG_BAN
        public static DataTable UpdateTableDepartment(OracleConnection conn, string TableName, string value1, string value2)
        {
            string sql = "update DBA_USER." + TableName + " SET TENPB = '" + value2 + "' where MAPB =" + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Xoa record trong PHONG_BAN
        public static DataTable DeleteTableDepartment(OracleConnection conn, string TableName, string value1)
        {
            string sql = "delete from DBA_USER." + TableName + " WHERE MAPB = " + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            return getUpdateTable(conn, TableName);
        }

        //them vao bang NHANVIEN
        public static DataTable InsertTableStaff(OracleConnection conn, string TableName, string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {
            string sql = "Insert into DBA_USER." + TableName + " (MANV, MAPB, TENNV, LABACSI, username, LUONGCOBAN, PHUCAP) values (" + value1 + ", " + value2 + ", '" + value3 + "', " + value4 + ",'" + value5 + "'," + value6 + "," + value7 + ")";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Cap nhat TENPB trong bang NHANVIEN
        public static DataTable UpdateTableStaff(OracleConnection conn, string TableName, string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {
            string sql = "update DBA_USER." + TableName + " SET MAPB = " + value2 + ", TENNV = '" + value3 + "', LABACSI = " + value4 + ", USERNAME = '" + value5 + "', LUONGCOBAN = " + value6 + ", PHUCAP = " + value7 + " WHERE MANV = " + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Xoa record trong NHANVIEN
        public static DataTable DeleteTableStaff(OracleConnection conn, string TableName, string value1)
        {
            string sql = "delete from DBA_USER." + TableName + " WHERE MANV = " + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            return getUpdateTable(conn, TableName);
        }

        //them vao bang TRUC_PHONG_KHAM
        public static DataTable InsertTableShift(OracleConnection conn, string TableName, string value2, string value3)
        {
            string sql = "Insert into DBA_USER." + TableName + " (MANV, THOIGIANBATDAUTRUC) values ("+ value2 + ", '" + value3 + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Cap nhat TENPB trong bang NHANVIEN
        public static DataTable UpdateTableShift(OracleConnection conn, string TableName, string value1, string value2, string value3)
        {
            string sql = "update DBA_USER." + TableName + " SET MANV = " + value2 + ", THOIGIANBATDAUTRUC = '" + value3 + "' WHERE ID_TRUCPHONGKHAM = " + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

            return getUpdateTable(conn, TableName);
        }
        // Xoa record trong NHANVIEN
        public static DataTable DeleteTableShift(OracleConnection conn, string TableName, string value1)
        {
            string sql = "delete from DBA_USER." + TableName + " WHERE ID_TRUCPHONGKHAM = " + value1;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            return getUpdateTable(conn, TableName);
        }
    }
}