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
