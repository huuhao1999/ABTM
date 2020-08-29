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
            if(Priv_Type == "SELECT" || Priv_Type == "UPDATE") //SELECT, UPDATE
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

                Priv_dataGridView.DataSource = Col;

            }
            else // INSERT, DELETE
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
                Priv_dataGridView.DataSource = All_tables;
                //DataTable User_Priv = Oracle.GetPriv_One_User_2(MainForm.Login_Form.conn, name, );

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
                        if (Convert.ToBoolean(dr1["WITH GRANT OPTION"]) == false)
                        {
                            Select_Priv.Rows.Remove(Select_Priv.Rows[i]);
                            i--; count--;
                            break;
                        }
                        else if (Convert.ToBoolean(dr2["WITH GRANT OPTION"]) == false)
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
            if(Priv_type == "SELECT")
            {
                Select_Grant();

            }
            else if (Priv_type == "UPDATE")
            {
                Update_Grant();


            }
            else if (Priv_type == "INSERT")
            {
                Insert_Grant();

            }
            else
            {
                Delete_Grant();

            }
            MessageBox.Show("Đã Gán quyền thành công!!!", "SUCCEED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Select_Grant()
        {
            MainForm.Login_Form.conn.Open();
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            string Grant_select_No_GrantOption_str = "";
            string Grant_select_WithGrantOption_str = "";

            // KHỞI TẠO RA STRING GỒM CÁC CỘT ĐỂ ĐƯỢC GRANT
            foreach (DataRow dr in temp.Rows)
            {
                Grant_select_No_GrantOption_str += dr["COLUMN_NAME"].ToString() + ',';
                if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                    Grant_select_WithGrantOption_str += dr["COLUMN_NAME"].ToString() + ',';
            }
                // BỎ KÍ TỰ ',' DƯ
                Grant_select_No_GrantOption_str = Grant_select_No_GrantOption_str.Remove(Grant_select_No_GrantOption_str.Length - 1, 1);

                // THỰC HIỆN GRANT
                Oracle.Create_View_Select(MainForm.Login_Form.conn, Table_name, Grant_select_No_GrantOption_str,MainForm.username, false);

                if (Grant_select_WithGrantOption_str != "")
                {
                    // BỎ KÍ TỰ ',' DƯ
                    Grant_select_WithGrantOption_str = Grant_select_WithGrantOption_str.Remove(Grant_select_WithGrantOption_str.Length - 1, 1);
                    Oracle.Create_View_Select(MainForm.Login_Form.conn,Table_name, Grant_select_WithGrantOption_str, MainForm.username, true);
                }
                MessageBox.Show(Grant_select_No_GrantOption_str);
                MessageBox.Show(Grant_select_WithGrantOption_str);
            MainForm.Login_Form.conn.Close();
        }

        private void Update_Grant()
        {
            MainForm.Login_Form.conn.Open();
            
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            Oracle.revoke_priv(MainForm.Login_Form.conn, Table_name, MainForm.username, "UPDATE");
            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                        Oracle.Grant_Update(MainForm.Login_Form.conn, dr["COLUMN_NAME"].ToString(), Table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Update(MainForm.Login_Form.conn, dr["COLUMN_NAME"].ToString(), Table_name, MainForm.username, false);
                }
            }
        }

        private void Insert_Grant()
        {
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;
            
            foreach(DataRow dr in temp.Rows)
            {
                string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString();
                Oracle.revoke_priv(MainForm.Login_Form.conn, table_name, MainForm.username, "INSERT");
            }

            foreach(DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString(); ;
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                        Oracle.Grant_Insert(MainForm.Login_Form.conn, table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Insert(MainForm.Login_Form.conn, table_name, MainForm.username, false);
                }
            }
        }

        private void Delete_Grant()
        {
            DataTable temp = (DataTable)Priv_dataGridView.DataSource;

            foreach (DataRow dr in temp.Rows)
            {
                string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString();
                Oracle.revoke_priv(MainForm.Login_Form.conn, table_name, MainForm.username, "DELETE");
            }

            foreach (DataRow dr in temp.Rows)
            {
                if (Convert.ToBoolean(dr["ENABLED"]))
                {
                    string table_name = dr["OWNER"].ToString() + "." + dr["TABLE_NAME"].ToString(); ;
                    if (Convert.ToBoolean(dr["WITH GRANT OPTION"]))
                        Oracle.Grant_Delete(MainForm.Login_Form.conn,  table_name, MainForm.username, true);
                    else
                        Oracle.Grant_Delete(MainForm.Login_Form.conn,  table_name, MainForm.username, false);
                }
            }

        }
    }
}
