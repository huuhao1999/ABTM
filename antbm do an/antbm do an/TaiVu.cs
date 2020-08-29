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
    class TaiVu
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
        public static DataTable getThuoc(OracleConnection conn)
        {
            string sql = "SELECT * FROM DBA_USER.THUOC;";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);
            return temp;
        }
        public static void updateThuoc(OracleConnection conn)
        {
            string sql = "UPDATE DBA_USER.THUOC SET TENTHUOC = 'hahahafedf' WHERE MATHUOC = 1";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            //OracleDataAdapter DA = new OracleDataAdapter(cmd);
            Console.WriteLine(sql);
        }

    }
}
