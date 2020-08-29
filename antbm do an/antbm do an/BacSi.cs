using System;
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
    class BacSi
    {

        public static OracleConnection CreateDBConnection(string username, string password)
        {
            string host = "localhost";
            int port = 1521;
            string sid = "xe";
            return GetDBConnection("localhost", 1521, "xe", username, password);
        }
        public static OracleConnection GetDBConnection(string host, int port, string sid, string user, string password)
        {
            string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=" + user + ";Password=" + password + ";";
            string a = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=" + user + ";Password=" + password + ";";

            OracleConnection conn = new OracleConnection();

            conn.ConnectionString = a;
            return conn;
        }
        public DataTable getthongtinbenhnhan(OracleConnection conn)
        {
            string sql = "select* from DBA_USER.BENH_NHAN_BAC_SI_VIEW"; // select ra nhugn74 user được người dùng tạo ra

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);
            return temp;
        }
        public DataTable getthongdonthuoc(OracleConnection conn)
        {
            string sql = "select bn.mabenhnhan, bn.ten, bn.trieuchungbenh, dsdt.mathuoc, dont.madt,dsdt.id_danhsachdonthuoc from DBA_USER.BENH_NHAN_BAC_SI_VIEW bn, DBA_USER.danh_sach_don_thuoc dsdt, DBA_USER.dieu_tri dt, DBA_USER.donthuoc dont where bn.mabenhnhan=dt.mabenhnhan and dt.id_dieutri=dont.id_dieutri and dont.madt=dsdt.madt";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);
            return temp;
        }
         public DataTable getDonThuoc(OracleConnection conn, string madonthuoc)
        {
           // string sql = "select bn.mabenhnhan, bn.ten, bn.trieuchungbenh, dsdt.mathuoc, dont.madt,dsdt.id_danhsachdonthuoc from DBA_USER.BENH_NHAN_BAC_SI_VIEW bn, DBA_USER.danh_sach_don_thuoc dsdt, DBA_USER.dieu_tri dt, DBA_USER.donthuoc dont where bn.mabenhnhan=dt.mabenhnhan and dt.id_dieutri=dont.id_dieutri and dont.madt=dsdt.madt";
            string sql = "select dt.madt,t.tenthuoc, dsdt.soluong, dt.tonggia,dt.ngaylap from DBA_USER.thuoc t,DBA_USER.danh_sach_don_thuoc dsdt,DBA_USER.donthuoc dt where dt.madt = dsdt.madt and dsdt.mathuoc = t.mathuoc and dt.madt="+madonthuoc+" ";
             OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);
            return temp;
        }


         public DataTable getDonThuoc1(OracleConnection conn)
         {
             // string sql = "select bn.mabenhnhan, bn.ten, bn.trieuchungbenh, dsdt.mathuoc, dont.madt,dsdt.id_danhsachdonthuoc from DBA_USER.BENH_NHAN_BAC_SI_VIEW bn, DBA_USER.danh_sach_don_thuoc dsdt, DBA_USER.dieu_tri dt, DBA_USER.donthuoc dont where bn.mabenhnhan=dt.mabenhnhan and dt.id_dieutri=dont.id_dieutri and dont.madt=dsdt.madt";
             string sql = "select dt.madt,t.tenthuoc, dsdt.soluong, dt.tonggia,dt.ngaylap from DBA_USER.thuoc t,DBA_USER.danh_sach_don_thuoc dsdt,DBA_USER.donthuoc dt where dt.madt = dsdt.madt and dsdt.mathuoc = t.mathuoc";
             OracleCommand cmd = new OracleCommand(sql, conn);
             OracleDataAdapter DA = new OracleDataAdapter(cmd);
             DataTable temp = new DataTable();
             DA.Fill(temp);
             return temp;
         }

        public void updatebenhnhan(OracleConnection conn, string mabn, string trieuchungbenh)
        {
            //string sql = "UPDATE DBA_USER.BENH_NHAN SET namsinh ="+namsinh+",diachilienlac='"+diachi+"',ten='"+tenbn+ "',sdt="+sdt+ ",trieuchungbenh='"+trieuchungbenh+  "' WHERE MABENHNHAN="+mabn;
            string sql = "UPDATE DBA_USER.BENH_NHAN SET TRIEUCHUNGBENH = '"+trieuchungbenh+"' WHERE MABENHNHAN ="+mabn+" ";
            Console.WriteLine(sql);
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            
           
           
        }





        public void themthuocvaodonthuoc(OracleConnection conn)
        {
            //error
            string sql = @"INSERT INTO DBA_USER.DANH_SACH_DON_THUOC(ID_DANHSACHDONTHUOC, MADT, MATHUOC, SOLUONG, DONGIA) VALUES ( (SELECT MAX(ID_DANHSACHDONTHUOC) FROM DBA_USER.DANH_SACH_DON_THUOC ) + 1,'1', '5', '3', '30000')";
            Console.WriteLine(sql);
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
       

        }














        public void updatedonthuoc(OracleConnection conn, string madonthuoc, string idds, string madonthuoc1, string soluong)
        {
            //string sql = "UPDATE DBA_USER.BENH_NHAN SET namsinh ="+namsinh+",diachilienlac='"+diachi+"',ten='"+tenbn+ "',sdt="+sdt+ ",trieuchungbenh='"+trieuchungbenh+  "' WHERE MABENHNHAN="+mabn;
            string sql = "UPDATE DBA_USER.DANH_SACH_DON_THUOC SET MATHUOC="+madonthuoc1+" , MADT="+madonthuoc+" ,SOLUONG="+soluong+" WHERE ID_DANHSACHDONTHUOC="+idds+" ";
            Console.WriteLine(sql);
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
           
           
        }
        public static List<string> getdieutri(OracleConnection conn)
        {
            string sql = "select * from DBA_USER.DIEU_TRI;"; // select ra nhugn74 user được người dùng tạo ra

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);

            List<string> ret = new List<string>();
            foreach (DataRow dr in temp.Rows)
            {
                ret.Add(dr["THOIGIANKHAM"].ToString());
                Console.WriteLine(dr["THOIGIANKHAM"].ToString());
            }
            return ret;
        }

    }
}
