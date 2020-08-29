using System;
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
    public partial class Choose_Priv : Form
    {
        public ChucNang_form MainForm;
        public string Priv_type;    
        public string Table_name;
        public string name_without_owner;
        public Choose_Priv(ChucNang_form form, string Priv_Type, string table_name = "")
        {
            MainForm = form;
            this.Priv_type = Priv_Type;
            this.Table_name = table_name;
            InitializeComponent();
            label1.Text = "CHON PRIVILEGES " + Priv_Type + " DE GRANT CHO USER TRONG BANG " + table_name + ": ";
            if (Priv_Type == "SELECT" || Priv_Type == "UPDATE") //SELECT, UPDATE
            {
                name_without_owner = table_name.Split('.')[1];
                //name_without_owner = table_name.Split('.')[1];
                DataTable Col = Oracle.Get_All_Col(MainForm.Login_Form.conn, name_without_owner);
                Col.Columns.Add("ENABLED", Type.GetType("System.Boolean"));
                Col.Columns.Add("WITH GRANT OPTION", Type.GetType("System.Boolean"));
                foreach (DataRow dr1 in Col.Rows)
                {
                    dr1["WITH GRANT OPTION"] = false;
                    dr1["ENABLED"] = false;
                }
                DataTable Priv_user = Oracle.GetPriv_One_User_2(MainForm.Login_Form.conn, MainForm.username, Priv_Type, name_without_owner);
                if (Priv_Type == "SELECT")
                    Select_Priv_Preprocessing(Priv_user);
                foreach (DataRow dr in Priv_user.Rows)
                {
                    foreach (DataRow dr1 in Col.Rows)

                        if (dr["COLUMN_NAME"].ToString() == dr1["COLUMN_NAME"].ToString())
                        {
                            if (dr["GRANTABLE"].ToString() == "NO")
                                dr1["WITH GRANT OPTION"] = false;
                            else dr1["WITH GRANT OPTION"] = true;

                            dr1["ENABLED"] = true;
                            break;
                        }
                }

                if (MainForm.is_user != true)
                {
                    Col.Columns.Remove("WITH GRANT OPTION");
                }

                Priv_dataGridView.DataSource = Col;

            }
            else if (Priv_Type == "INSERT" || Priv_Type == "DELETE")
            {
                //string name = MainForm.username;
                DataTable All_tables = Oracle.Get_All_Table(MainForm.Login_Form.conn);
                All_tables.Columns.Add("ENABLED", Type.GetType("System.Boolean"));
                All_tables.Columns.Add("WITH GRANT OPTION", Type.GetType("System.Boolean"));
                foreach (DataRow dr1 in All_tables.Rows)
                {
                    dr1["WITH GRANT OPTION"] = false;
                    dr1["ENABLED"] = false;
                }
                DataTable Priv_user = Oracle.GetPriv_One_User_2(MainForm.Login_Form.conn, MainForm.username, Priv_Type, table_name);
                foreach (DataRow dr in Priv_user.Rows)
                {
                    foreach (DataRow dr1 in All_tables.Rows)
                        if (dr["OBJECT_NAME"].ToString() == dr1["TABLE_NAME"].ToString() && dr["OWNER"].ToString() == dr1["OWNER"].ToString())
                        {
                            if (dr["GRANTABLE"].ToString() == "NO")
                                dr1["WITH GRANT OPTION"] = false;
                            else dr1["WITH GRANT OPTION"] = true;
                            dr1["ENABLED"] = true;
                            break;
                        }
                }
                if (MainForm.is_user != true)
                {
                    All_tables.Columns.Remove("WITH GRANT OPTION");
                }

                Priv_dataGridView.DataSource = All_tables;
                //DataTable User_Priv = Oracle.GetPriv_One_User_2(MainForm.Login_Form.conn, name, );

            }
            else
            {
                DataTable Role_Granted_To_User = Oracle.GetRoleGrantedToUser(MainForm.Login_Form.conn, MainForm.username);

                DataTable All_Role = Oracle.GetRoleCanGrantToUser(MainForm.Login_Form.conn,MainForm.Login_Form.LogedIn_Username.ToUpper());
                All_Role.Columns.Add("ENABLED", Type.GetType("System.Boolean"));
                All_Role.Columns.Add("WITH ADMIN OPTION", Type.GetType("System.Boolean"));

                foreach (DataRow dr1 in All_Role.Rows)
                {
                    dr1["ENABLED"] = false; ;
                    dr1["WITH ADMIN OPTION"] = false; ;
                }

                foreach (DataRow dr1 in All_Role.Rows)
                {                   
                    foreach (DataRow dr in Role_Granted_To_User.Rows)
                    {
                        if(dr1["ROLE"].ToString() == dr["ROLE"].ToString())
                        {
                            dr1["ENABLED"] = true;
                            if (Convert.ToBoolean(dr["WITH ADMIN OPTION"]))
                            {
                                dr1["WITH ADMIN OPTION"] = true;
                            }
                            break;
                        }
                    }
                }
                Priv_dataGridView.DataSource = All_Role;
            }
        }

        public void Select_Priv_Preprocessing(DataTable Select_Priv)
        {
            //int Remain_select_priv_count = Remain_Select_Priv.Rows.Count;
            string sep = "_" + MainForm.username.ToUpper() + "_VIEW";
            List<DataRow> temp_del_list = new List<DataRow>();

            // XỬ LÍ TÊN
            foreach (DataRow dr in Select_Priv.Rows)
            {
                if (dr["OBJECT_NAME"].ToString().Contains(sep) == true)
                {
                    string[] temp = dr["OBJECT_NAME"].ToString().Split(new[] { sep }, StringSplitOptions.None);
                    //MessageBox.Show(temp[0]);
                    dr["OBJECT_NAME"] = temp[0];
                }
            }
            // XỬ LÍ NHỮNG DÒNG DƯ KHI ĐÃ CÓ WITH GRANT OPTION
            int count = Select_Priv.Rows.Count;
            //int flag = 0;
            for (int i = 0; i < count; i++)
            {
                DataRow dr1 = Select_Priv.Rows[i];
                for (int j = i + 1; j < count; j++)
                {
                    DataRow dr2 = Select_Priv.Rows[j];
                    if (dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString())
                    {
                        if (dr1["GRANTABLE"].ToString() == "NO")
                        {
                            Select_Priv.Rows.Remove(Select_Priv.Rows[i]);
                            i--; count--;
                            break;
                        }
                        else if (dr2["GRANTABLE"].ToString() == "YES")
                        {
                            Select_Priv.Rows.Remove(Select_Priv.Rows[j]);
                            j--; count--;
                            break;
                        }
                    }
                }
            }
        }

        private void Priv_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if(Priv_type == "SELECT")
            {
                temp = Select_Grant();

            }
            else if (Priv_type == "UPDATE")
            {
                temp = Update_Grant();


            }
            else if (Priv_type == "INSERT")
            {
                temp = Insert_Grant();

            }
            else if (Priv_type == "DELETE")
            {
                temp = Delete_Grant();

            }
            else
            {
                temp = Role_Grant();
            }
            if(temp == 1)
                MessageBox.Show("Đã Gán quyền thành công!!!", "SUCCEED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private int Select_Grant()
        {

            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            string Grant_select_No_GrantOption_str = "";
            string Grant_select_WithGrantOption_str = "";
            // NẾU CHỌN VÀO NHỮNG CỘT BỊ MÃ HÓA THÌ THỰC HIỆN NGƯNG QUI TRÌNH VÀ HIỆN LỖI
            foreach (DataRow dr in temp.Rows)
            {
                if ((dr["COLUMN_NAME"].ToString().ToUpper() == "LUONG" || dr["COLUMN_NAME"].ToString().ToUpper() == "PHUCAP") && this.Table_name == "LUONG")
                {
                    MessageBox.Show("CỘT " + dr["COLUMN_NAME"].ToString().ToUpper() + "ĐÃ ĐƯỢC MÃ HÓA, KHÔNG ĐƯỢC PHÉP ADD QUYỀN SELECT QUA APP!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            MainForm.Login_Form.conn.Open();
            // THỰC HIỆN DROP HẾT QUYỀN SELECT CỦA USER CÓ THỂ CÓ TRÊN OBJECT TUONG ỨNG
            Oracle.Drop_View(MainForm.Login_Form.conn, Table_name, MainForm.username);

            // KHỞI TẠO RA STRING GỒM CÁC CỘT ĐỂ ĐƯỢC GRANT
            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    
                    Grant_select_No_GrantOption_str += dr["COLUMN_NAME"].ToString() + ',';
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]) && MainForm.is_user)
                        Grant_select_WithGrantOption_str += dr["COLUMN_NAME"].ToString() + ',';
                }
            }
            if (Grant_select_No_GrantOption_str != "")
            {
                // BỎ KÍ TỰ ',' DƯ
                Grant_select_No_GrantOption_str = Grant_select_No_GrantOption_str.Remove(Grant_select_No_GrantOption_str.Length - 1, 1);

                // THỰC HIỆN GRANT
                Oracle.Create_View_Select(MainForm.Login_Form.conn, Table_name, Grant_select_No_GrantOption_str, MainForm.username, false);
            }
                if (Grant_select_WithGrantOption_str != "")
                {
                    // BỎ KÍ TỰ ',' DƯ
                    Grant_select_WithGrantOption_str = Grant_select_WithGrantOption_str.Remove(Grant_select_WithGrantOption_str.Length - 1, 1);
                    Oracle.Create_View_Select(MainForm.Login_Form.conn,Table_name, Grant_select_WithGrantOption_str, MainForm.username, true);
                }
                //MessageBox.Show(Grant_select_No_GrantOption_str);
                //MessageBox.Show(Grant_select_WithGrantOption_str);
            MainForm.Login_Form.conn.Close();
            return 1;
        }

        private int Update_Grant()
        {
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;

            foreach (DataRow dr in temp.Rows)
            {
                if ((dr["COLUMN_NAME"].ToString().ToUpper() == "LUONG" || dr["COLUMN_NAME"].ToString().ToUpper() == "PHUCAP") && this.Table_name == "LUONG")
                {
                    MessageBox.Show("CỘT " + dr["COLUMN_NAME"].ToString().ToUpper() + "ĐÃ ĐƯỢC MÃ HÓA, KHÔNG ĐƯỢC PHÉP ADD QUYỀN SELECT QUA APP!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            MainForm.Login_Form.conn.Open();

            Oracle.revoke_priv(MainForm.Login_Form.conn, Table_name, MainForm.username, "UPDATE");
            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]) && MainForm.is_user)
                        Oracle.Grant_Update(MainForm.Login_Form.conn, dr["COLUMN_NAME"].ToString(), Table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Update(MainForm.Login_Form.conn, dr["COLUMN_NAME"].ToString(), Table_name, MainForm.username, false);
                }
            }

            MainForm.Login_Form.conn.Close();
            return 1;
        }

        private int Insert_Grant()
        {
            
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;

            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]) && dr["TABLE_NAME"].ToString() == "LUONG")
                {
                    MessageBox.Show("BANG " + dr["TABLE_NAME"].ToString().ToUpper() + "ĐÃ ĐƯỢC MÃ HÓA, KHÔNG ĐƯỢC PHÉP ADD QUYỀN SELECT QUA APP!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            MainForm.Login_Form.conn.Open();

            foreach (DataRow dr in temp.Rows)
            {
                string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString();
                Oracle.revoke_priv(MainForm.Login_Form.conn, table_name, MainForm.username, "INSERT");
            }

            foreach(DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]) && MainForm.is_user)
                {
                    string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString(); ;
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                        Oracle.Grant_Insert(MainForm.Login_Form.conn, table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Insert(MainForm.Login_Form.conn, table_name, MainForm.username, false);
                }
            }
            MainForm.Login_Form.conn.Close();
            return 1;
        }

        private int Delete_Grant()
        {
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            // CHECK XEM CÓ BẢNG NÀO THUỘC DẠNG EXCEPTION KHÔNG, NẾU CÓ BÁO ERROR (DO CHƯA CÓ CÁCH XỬ LÍ)
            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]) && dr["TABLE_NAME"].ToString() == "LUONG")
                {
                    MessageBox.Show("BANG " + dr["TABLE_NAME"].ToString().ToUpper() + "ĐÃ ĐƯỢC MÃ HÓA, KHÔNG ĐƯỢC PHÉP ADD QUYỀN SELECT QUA APP!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            MainForm.Login_Form.conn.Open();

            foreach (DataRow dr in temp.Rows)
            {
                string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString();
                Oracle.revoke_priv(MainForm.Login_Form.conn, table_name, MainForm.username, "DELETE");
            }

            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]) && MainForm.is_user)
                {
                    string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString(); ;
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                        Oracle.Grant_Delete(MainForm.Login_Form.conn,  table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Delete(MainForm.Login_Form.conn,  table_name, MainForm.username, false);
                }
            }
            MainForm.Login_Form.conn.Close();
            return 1;
        }

        private int Role_Grant()
        {
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            //// CHECK XEM CÓ BẢNG NÀO THUỘC DẠNG EXCEPTION KHÔNG, NẾU CÓ BÁO ERROR (DO CHƯA CÓ CÁCH XỬ LÍ)
            //foreach (DataRow dr in temp.Rows)
            //{
            //    if (Convert.ToBoolean(dr["ENABLED"]) && dr["TABLE_NAME"].ToString() == "LUONG")
            //    {
            //        MessageBox.Show("BANG " + dr["TABLE_NAME"].ToString().ToUpper() + "ĐÃ ĐƯỢC MÃ HÓA, KHÔNG ĐƯỢC PHÉP ADD QUYỀN SELECT QUA APP!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return 0;
            //    }
            //}
            MainForm.Login_Form.conn.Open();

            foreach (DataRow dr in temp.Rows)
            {
                Oracle.revoke_role(MainForm.Login_Form.conn, dr["ROLE"].ToString(), MainForm.username);
            }
            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    //string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString(); ;
                    if (Convert.ToBoolean(dr["WITH ADMIN OPTION"]))
                        Oracle.Grant_Role(MainForm.Login_Form.conn,dr["ROLE"].ToString(), MainForm.username, true);
                    else
                        Oracle.Grant_Role(MainForm.Login_Form.conn, dr["ROLE"].ToString(), MainForm.username, false);
                }
            }
            MainForm.Login_Form.conn.Close();
            return 1;
        }
    }
}
