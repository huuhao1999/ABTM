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
    class Oracle
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
            string temp = (user == "sys") ? ";DBA Privilege=SYSDBA" : "";
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                            + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                            + sid + ")));Password=" + password + ";User ID=" + user + temp;

            OracleConnection conn = new OracleConnection();

            conn.ConnectionString = connString;
            return conn;
        }

        
        public static List<string> GetAllUsers(OracleConnection conn)
        {
            string sql = "SELECT USERNAME FROM all_users WHERE COMMON = 'NO'"; // select ra nhugn74 user được người dùng tạo ra

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);

            List<string> ret = new List<string>();
            foreach (DataRow dr in temp.Rows)
            {
                ret.Add(dr["USERNAME"].ToString());
            }
            return ret;
        }
        public static List<string> GetAllRoles(OracleConnection conn)
        {
            string sql = "SELECT ROLE FROM dba_roles where COMMON = 'NO'"; // select ra những role được người dùng tạo ra
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable temp = new DataTable();
            DA.Fill(temp);

            List<string> ret = new List<string>();
            foreach (DataRow dr in temp.Rows)
            {
                ret.Add(dr["ROLE"].ToString());
            }
            return ret;
        }

        public static DataTable GetAllPriv(OracleConnection conn, string UserName)
        {
            //string sql = "Select * from all_users";
            string sql=
                "select tpm.name, ur.name grantor, u.name owner,decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name, c.name column_name " +
                "from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c,table_privilege_map tpm " +
                "where oa.obj# = o.obj# and oa.grantor# = ur.user# and c.obj# = o.obj# and oa.grantee# = ue.user# and oa.col# is null and oa.privilege# = tpm.privilege " +
                "and u.user# = o.owner# and o.TYPE# in (2, 4) and ue.name = '"+ UserName + "' and bitand (o.flags, 128) = 0 and (tpm.name = 'SELECT' or tpm.name = 'UPDATE') " +
                "union all " +
                "select tpm.name, ur.name grantor, u.name owner, decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name, c.name column_name " +
                "from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c, table_privilege_map tpm " +
                "where oa.obj# = o.obj# and oa.grantor# = ur.user# and oa.grantee# = ue.user# and oa.obj# = c.obj# and oa.col# = c.col# and bitand(c.property, 32) = 0 and oa.col# is not null " +
                "and oa.privilege# = tpm.privilege and  u.user# = o.owner# and o.TYPE# in (2, 4, 42) and ue.name = '"+UserName+ "' and bitand (o.flags, 128) = 0 and (tpm.name = 'SELECT' or tpm.name = 'UPDATE') " +
                "union all " +
                "select tpm.name, ur.name grantor, u.name owner,decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name,'' column_name "+
                "from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, table_privilege_map tpm "+
                " where oa.obj# = o.obj#  and oa.grantor# = ur.user#   and oa.grantee# = ue.user# and oa.col# is null " +
                " and oa.privilege# = tpm.privilege and (tpm.name = 'INSERT' or tpm.name = 'DELETE') and u.user# = o.owner#  and o.TYPE# in (2, 4)  and ue.name = '" + UserName + "'and bitand (o.flags, 128) = 0";

            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            ret.Columns.Add(new DataColumn("WITH GRANT OPTION", Type.GetType("System.Boolean")));
            //ret.Columns.Add(new DataColumn("ENABLED", Type.GetType("System.Boolean")));
            foreach (DataRow dr in ret.Rows)
            {
                if (dr["GRANTABLE"].ToString() == "NO")
                    dr["WITH GRANT OPTION"] = false;
                else dr["WITH GRANT OPTION"] = true;

                //dr["ENABLED"] = true;
            }
            ret.Columns.Remove("GRANTABLE");
            return ret;
        }

        public static DataTable GetPriv_One_User_2(OracleConnection conn, string UserName, string PrivType, string Table_Name)
        {
            //string sql = "Select * from all_users";
            string view_name = Table_Name.ToUpper() + "_" + UserName + "_" + "VIEW";
            string sql_se_up =
                "select decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name, c.name column_name " +
                "from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c,table_privilege_map tpm " +
                "where oa.obj# = o.obj# and oa.grantor# = ur.user# and c.obj# = o.obj# and oa.grantee# = ue.user# and oa.col# is null and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "' " +
                "and u.user# = o.owner# and o.TYPE# in (2, 4) and ue.name = '" + UserName + "' and bitand (o.flags, 128) = 0 and (o.name = '" + view_name + "' or o.name = '" + view_name + "_GRANTABLE' or o.name = '" + Table_Name + "')" +
                "union all " +
                "select decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name, c.name column_name " +
                "from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c, table_privilege_map tpm " +
                "where oa.obj# = o.obj# and oa.grantor# = ur.user# and oa.grantee# = ue.user# and oa.obj# = c.obj# and oa.col# = c.col# and bitand(c.property, 32) = 0 and oa.col# is not null " +
                "and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "' and  u.user# = o.owner# and o.TYPE# in (2, 4, 42) and ue.name = '" + UserName + "' and bitand (o.flags, 128) = 0 and (o.name = '" + view_name + "' or o.name = '" + view_name + "_GRANTABLE' or o.name = '" + Table_Name + "')";

            string sql_in_de =
            "select decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, table_privilege_map tpm  where oa.obj# = o.obj#  and oa.grantor# = ur.user#   and oa.grantee# = ue.user#          and oa.col# is null  and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "'and u.user# = o.owner#  and o.TYPE# in (2, 4)  and ue.name = '" + UserName + "'and bitand (o.flags, 128) = 0";

            // Tạo một đối tượng Command.

            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            if (PrivType == "SELECT" || PrivType == "UPDATE")
                cmd.CommandText = sql_se_up;    
            else if (PrivType == "INSERT" || PrivType == "DELETE")
                cmd.CommandText = sql_in_de;
            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            //ret.Columns.Add(new DataColumn("WITH GRANT OPTION", Type.GetType("System.Boolean")));
            //ret.Columns.Add(new DataColumn("ENABLED", Type.GetType("System.Boolean")));
            //foreach (DataRow dr in ret.Rows)
            //{
            //    if (dr["GRANTABLE"].ToString() == "NO")
            //        dr["WITH GRANT OPTION"] = false;
            //    else dr["WITH GRANT OPTION"] = true;

            //    dr["ENABLED"] = true;
            //}
            //ret.Columns.Remove("GRANTABLE");
            //ret.Columns.Remove("OBJECT_TYPE");
            return ret;
        }

        public static DataTable Get_All_Col(OracleConnection conn, string Table_Name)
        {
            string sql =
                "SELECT column_name FROM DBA_TAB_COLUMNS WHERE table_name = '"+Table_Name+"'";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DataTable ret = new DataTable();
            DA.Fill(ret);

            // XU LI BO DI NHUNG COT DAC BIET TRONG BANG DANG LE PHAI BI AN
            if (Table_Name == "CUOC_HOP")
            {
                int count = ret.Rows.Count;
                for(int i =0; i< count;i++)
                {
                    if (ret.Rows[i]["COLUMN_NAME"].ToString() == "ROWLABEL")
                    {
                        ret.Rows.Remove(ret.Rows[i]);
                        count--;
                        i--;
                    }
                }
            }
            return ret;
        }

        public static DataTable GetRemain_One_User(OracleConnection conn, string UserName, string PrivType)
        {
            string sql_se_up =
                " select distinct decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name, c.name column_name" +
                " from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c,table_privilege_map tpm" +
                " where oa.obj# = o.obj# and oa.grantor# = ur.user# and c.obj# = o.obj# and oa.grantee# = ue.user# and oa.col# is null and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "' " +
                " and u.user# = o.owner# and o.TYPE# in (2, 4) and ue.name = 'DUMMY_USER' and bitand (o.flags, 128) = 0" +
                " and (o.name, c.name) not in" +
                " ( select o.name object_name, c.name column_name" +
                " from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c,table_privilege_map tpm" +
                " where oa.obj# = o.obj# and oa.grantor# = ur.user# and c.obj# = o.obj# and oa.grantee# = ue.user# and oa.col# is null and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "' " +
                " and u.user# = o.owner# and o.TYPE# in (2, 4) and ue.name = '" + UserName + "' and bitand (o.flags, 128) = 0" +
                " union all" +
                " select o.name object_name, c.name column_name" +
                " from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, sys.col$ c, table_privilege_map tpm" +
                " where oa.obj# = o.obj# and oa.grantor# = ur.user# and oa.grantee# = ue.user# and oa.obj# = c.obj# and oa.col# = c.col# and bitand(c.property, 32) = 0 and oa.col# is not null" +
                " and oa.privilege# = tpm.privilege and tpm.name = '"+PrivType+"' and  u.user# = o.owner# and o.TYPE# in (2, 4, 42) and ue.name = '"+UserName+"' and bitand (o.flags, 128) = 0)";
            string sql_in_de =
            " select decode(mod(oa.option$,2), 1, 'YES', 'NO') grantable, decode(o.TYPE#, 2, 'TABLE', 4, 'VIEW') object_type, o.name object_name from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, table_privilege_map tpm where oa.obj# = o.obj# and oa.grantor# = ur.user#  and oa.grantee# = ue.user# and oa.col# is null  and oa.privilege# = tpm.privilege and tpm.name = '"+PrivType+"' and u.user# = o.owner#  and o.TYPE# in (2, 4)  and ue.name = 'DUMMY_USER'  and bitand (o.flags, 128) = 0" +
            " AND(o.name) NOT IN" +
            " (select distinct o.name object_name from sys.objauth$ oa, sys.obj$ o, sys.user$ u, sys.user$ ur, sys.user$ ue, table_privilege_map tpm where oa.obj# = o.obj#  and oa.grantor# = ur.user#   and oa.grantee# = ue.user#   and oa.col# is null  and oa.privilege# = tpm.privilege and tpm.name = '" + PrivType + "'  and u.user# = o.owner#  and o.TYPE# in (2, 4)  and ue.name = '" + UserName + "'  and bitand (o.flags, 128) = 0)";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (PrivType == "SELECT" || PrivType == "UPDATE")
                cmd.CommandText = sql_se_up;
            else if (PrivType == "INSERT" || PrivType == "DELETE")
                cmd.CommandText = sql_in_de;
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            //ret.Columns.Add(new DataColumn("WITH GRANT OPTION", Type.GetType("System.Boolean")));
            //foreach (DataRow dr in ret.Rows)
            //{
            //    if (dr["GRANTABLE"].ToString() == "NO")
            //        dr["WITH GRANT OPTION"] = false;
            //    else dr["WITH GRANT OPTION"] = true;
            //}
            //ret.Columns.Remove("GRANTABLE");
            ret.Columns.Remove("OBJECT_TYPE");
                ret.Columns.Add(new DataColumn("ENABLED", Type.GetType("System.Boolean")));
            return ret;
        }

        public static DataTable GetRoleGrantedToUser(OracleConnection conn, string UserName)
        {
            //string sql = "Select * from all_users";
            string sql =
                "select GRANTED_ROLE AS ROLE, ADMIN_OPTION " +
                "from sys.dba_role_privs " +
                "where grantee = '"+UserName+"' AND COMMON = 'NO'";
            // Tạo một đối tượng Command.

            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            ret.Columns.Add(new DataColumn("WITH ADMIN OPTION", Type.GetType("System.Boolean")));
            //ret.Columns.Add(new DataColumn("ENABLED", Type.GetType("System.Boolean")));
            foreach (DataRow dr in ret.Rows)
            {
                if (dr["ADMIN_OPTION"].ToString() == "NO")
                    dr["WITH ADMIN OPTION"] = false;
                else dr["WITH ADMIN OPTION"] = true;

                //dr["ENABLED"] = true;
            }
            ret.Columns.Remove("ADMIN_OPTION");
            return ret;
        }

        public static DataTable GetRoleCanGrantToUser(OracleConnection conn,string LoggedInUser)
        {
            string sql =
                "SELECT ROLE FROM sys.dba_roles where COMMON = 'NO' " +
                "AND ROLE NOT IN (SELECT GRANTED_ROLE " +
                "FROM sys.dba_role_privs " +
                "WHERE grantee = '" + LoggedInUser + "' AND COMMON = 'NO' AND ADMIN_OPTION = 'NO')";
            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);
            return ret;
        }

        public static DataTable GetRemainingRole_NotGranted_ToUser(OracleConnection conn, string UserName)
        {
            //string sql = "Select * from all_users";
            string sql =
                "SELECT ROLE FROM dba_roles where COMMON = 'NO' AND ROLE <> 'HOP_OLS_DBA' " +
                " AND ROLE NOT IN " +
                "( select GRANTED_ROLE " +
                "from sys.dba_role_privs " +
                "where grantee = '"+UserName+"')";

            // Tạo một đối tượng Command.

            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            ret.Columns.Add(new DataColumn("ENABLED", Type.GetType("System.Boolean")));
            foreach (DataRow dr in ret.Rows)
            {
                dr["ENABLED"] = false;
            }
            return ret;
        }
        public static DataTable Get_All_Table(OracleConnection conn)
        {
            //string sql = "Select * from all_users";
            string sql =
                "SELECT OWNER, TABLE_NAME " +
                "FROM sys.dba_tables " +
                "where owner in ( " +
                "SELECT USERNAME FROM all_users WHERE COMMON = 'NO') " +
                "ORDER BY owner, table_name";

            // Tạo một đối tượng Command.

            OracleCommand cmd = new OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //List<Users> ret = new List<Users>();
            DataTable ret = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(ret);

            int count = ret.Rows.Count;
            for(int i = 0; i<count; i++)
            {
                if (ret.Rows[i]["TABLE_NAME"].ToString() == "TABLE_NAY_CHA_DE_LAM_GI_CA")
                {
                    ret.Rows.Remove(ret.Rows[i]);
                    count--;
                    i--;
                }
            }

            return ret;
        }


        public static void Create_View_Select(OracleConnection conn,string Table_name, string col_name_str, string User_name, bool Grantable)
        {
            string temp = (Grantable == true) ? "_GRANTABLE" : " ";
            string temp2 = (Grantable == true) ? "WITH GRANT OPTION" : "";
            string view_name = Table_name.ToUpper() + "_" + User_name + "_" + "VIEW" + temp;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            string sql = "";
                sql = "CREATE VIEW " + view_name + " AS " +
                    " SELECT " + col_name_str + " " +
                    " FROM " + Table_name;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "GRANT SELECT ON " + view_name + " TO " + User_name + " " + temp2;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

        }

  
        public static void Drop_View(OracleConnection conn, string Table_name, string User_name)
        {
            string view_name = Table_name.ToUpper() + "_" + User_name + "_" + "VIEW";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            string sql = "BEGIN\n" +
                "      EXECUTE IMMEDIATE 'DROP VIEW " + view_name + "';" +
                "      EXCEPTION WHEN OTHERS THEN NULL;\n" +
                "END;\n";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "BEGIN\n" +
               "      EXECUTE IMMEDIATE 'DROP VIEW " + view_name +  "_GRANTABLE';" +
               "      EXCEPTION WHEN OTHERS THEN NULL;\n" +
               "END;\n";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql =
                "BEGIN\n" +
                "      EXECUTE IMMEDIATE 'REVOKE SELECT ON " + Table_name + " FROM " + User_name + "';\n" +
                "EXCEPTION WHEN OTHERS THEN NULL;\n" +
                "END;\n";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            // Tạo một đối tượng Command.

        }
        public static void Grant_Update(OracleConnection conn, string col_name_str, string table_name, string User_name,bool Grantable)
        {
            string temp = (Grantable == true)?" WITH GRANT OPTION":"";

            string sql = "GRANT UPDATE("+ col_name_str + ") ON " + table_name + " TO "+ User_name + temp;
            OracleCommand cmd = new OracleCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static void Grant_Insert(OracleConnection conn, string table_name, string User_name, bool Grantable)
        {
            string temp = (Grantable == true) ? " WITH GRANT OPTION" : "";

            string sql = "GRANT INSERT ON " + table_name + " TO " + User_name + temp;
            OracleCommand cmd = new OracleCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static void Grant_Delete(OracleConnection conn, string table_name, string User_name, bool Grantable)
        {
            string temp = (Grantable == true) ? " WITH GRANT OPTION" : "";

            string sql = "GRANT DELETE ON " + table_name + " TO " + User_name + temp;
            OracleCommand cmd = new OracleCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static void Grant_Role(OracleConnection conn, string role_name, string User_name, bool Grantable)
        {
            string temp = (Grantable == true) ? " WITH ADMIN OPTION" : "";

            string sql = "GRANT " + role_name + " TO " + User_name + temp;
            OracleCommand cmd = new OracleCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void revoke_priv(OracleConnection conn, string Table_Name,string username, string Priv_type)
        {
            string sql =
                "BEGIN\n" +
                "EXECUTE IMMEDIATE 'REVOKE " + Priv_type + " ON " + Table_Name + " FROM " + username + "';\n" +
                "EXCEPTION WHEN OTHERS THEN NULL;\n" +
                "END;";

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
       
        public static void revoke_role(OracleConnection conn, string RoleName, string UserName)
        {
            string sql =
                "BEGIN\n" +
                "EXECUTE IMMEDIATE 'REVOKE " + RoleName + " FROM " + UserName + "';\n" +
                "EXCEPTION WHEN OTHERS THEN NULL;\n" +
                "END;";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
        //public static bool Is_DBA(OracleConnection conn, string username)
        //{
        //    string sql = "SELECT SYS_CONTEXT(\"userenv\",\"ISDBA\") AS ISDBA from dual";

        //    OracleCommand cmd = new OracleCommand();
        //    cmd.CommandText = sql;
        //    cmd.Connection = conn;

        //    OracleDataAdapter DA = new OracleDataAdapter(cmd);
        //    DataTable temp = new DataTable();
        //    DA.Fill(temp);
        //    return Convert.ToBoolean(temp.Rows[0]["ISDBA"]);
        //}
        public static List<string> Get_object_type(OracleConnection conn)
        {
            string sql = "select distinct OBJECT_TYPE FROM DBA_OBJECTS";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            DataTable temp = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(temp);

            List<string> ret = new List<string>();
            foreach (DataRow i in temp.Rows)
            {
                ret.Add(i["OBJECT_TYPE"].ToString());
            }
            return ret;
        }

        public static DataTable Get_Object(OracleConnection conn, string ObjectType)
        {
            string sql = "select OWNER, OBJECT_NAME,SUBOBJECT_NAME, OBJECT_ID,OBJECT_TYPE, CREATED, STATUS, TEMPORARY, GENERATED, SECONDARY, NAMESPACE, ORACLE_MAINTAINED FROM DBA_OBJECTS WHERE OBJECT_TYPE = '" + ObjectType + "'";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            DataTable temp = new DataTable();
            OracleDataAdapter DA = new OracleDataAdapter(cmd);
            DA.Fill(temp);
            return temp;
        }

        public static void CreateUser(OracleConnection conn, string username, string password)
        {
            conn.Open();
            string temp = (password == "") ? "" : (" IDENTIFIED BY " + password);
            string sql =
                "CREATE USER " + username + " IDENTIFIED BY \"" + password +"\"";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CreateRole(OracleConnection conn, string rolename, string password)
        {
            conn.Open();
            string temp = (password == "") ? "" : (" IDENTIFIED BY " + password);
            string sql =
                "CREATE ROLE " + rolename;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

