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
    public partial class ChucNang_form : Form
    {
        private TabPage RoleTab;
        public f_DangNhap Login_Form;
        public bool is_user;
        public string username;
        public bool is_DBA;
        //public string username;
        public ChucNang_form(f_DangNhap form)
        {
          
            Login_Form = form;
            InitializeComponent();
      
                GetUsers();
                GetRoles();
           
            RoleTab = tabControl2.TabPages[1];
        }

        private void GetUsers()
        {
            user_comboBox.DataSource = Oracle.GetAllUsers(Login_Form.conn);
        }
        private void GetRoles()
        {
            role_comboBox.DataSource = Oracle.GetAllRoles(Login_Form.conn);
        }

        private void ChonUser_button_Click(object sender, EventArgs e)
        {
            if (tabControl2.TabCount < 2)
                tabControl2.TabPages.Add(RoleTab);
            this.username= user_comboBox.Text;
            string username = user_comboBox.Text;
            is_user = true;
            NAME_label.Text = "USER " + username;
            // Select
            DataTable ret = Oracle.GetAllPriv(Login_Form.conn, username);
            //DataTable ret2 = Oracle.GetRemain_One_User(Login_Form.conn, username, "SELECT");
            Priv_Preprocessing(ret);
            Select_User_dataGridView1.DataSource = ret;

            // ROLE
            ret = Oracle.GetRoleGrantedToUser(Login_Form.conn, username);
            RoleGrantedToUser_dataGridView.DataSource = ret;
        }

        private void ChonRole_button_Click(object sender, EventArgs e)
        {
            tabControl2.TabPages.Remove(RoleTab);
            string role = role_comboBox.Text;
            is_user = false;
            this.username = role_comboBox.Text;

            NAME_label.Text = "ROLE " + role;

            // Select
            DataTable ret = Oracle.GetAllPriv(Login_Form.conn, role);
            Priv_Preprocessing(ret);
            Select_User_dataGridView1.DataSource = ret;



        }

        private void test_button_Click(object sender, EventArgs e)
        {

        }
        private void user_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GanQuyen_button_Click(object sender, EventArgs e)
        {
            Choose_Priv_Type Chon_Priv_type = new Choose_Priv_Type(this);
            Chon_Priv_type.Show();
        }

        private DataTable Get_Revoke_Grant_Priv(DataTable Goc,DataTable Sua_Doi)
        {
            DataTable temp_Goc = Goc.Copy();
            //DataTable temp_Sua_Doi = Sua_Doi.Copy();
            //DataRow dr1 = Goc.NewRow();
            //DataRow dr2 = Sua_Doi.NewRow();
            int Sua_doi_count = Sua_Doi.Rows.Count;
            int temp_Goc_count = temp_Goc.Rows.Count;
            int flag = 0;

            for(int i = 0; i < Sua_doi_count; i++)
            {
                DataRow dr2 = Sua_Doi.Rows[i];
                for(int j = 0; j < temp_Goc_count; j++)
                {
                    DataRow dr1 = temp_Goc.Rows[j];
                    if(dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString() && Convert.ToBoolean(dr1["WITH GRANT OPTION"]) == Convert.ToBoolean(dr2["WITH GRANT OPTION"]))
                    {
                        flag = 1;
                        temp_Goc.Rows.Remove(temp_Goc.Rows[j]);
                        temp_Goc_count--; j--;
                        break; // do chắc chắn trong mỗi datatable chỉ có 1 giá trị 
                    }
                }
                if (flag == 1)
                {
                    Sua_Doi.Rows.Remove(Sua_Doi.Rows[i]);
                    i--; Sua_doi_count--;
                    flag = 0;
                }
            }
            int Goc_count = Goc.Rows.Count;
                temp_Goc_count = temp_Goc.Rows.Count;
                for (int i = 0; i < temp_Goc_count; i++)
                {
                    DataRow dr1 = temp_Goc.Rows[i];
                    for (int j = 0; j < Goc_count; j++)
                    {
                        DataRow dr2 = Goc.Rows[j];
                        if (dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString() && Convert.ToBoolean(dr1["WITH GRANT OPTION"]) == Convert.ToBoolean(dr2["WITH GRANT OPTION"]))
                        {
                            Goc.Rows.Remove(Goc.Rows[j]);
                            Goc_count--;
                            break; // do chắc chắn trong mỗi datatable chỉ có 1 giá trị 
                        }
                    }
                }

            DataTable ret = temp_Goc.Copy();
            return ret;
        }

        private void Select_Priv_Preprocessing(DataTable Select_Priv, DataTable Remain_Select_Priv)
        {
            int Remain_select_priv_count = Remain_Select_Priv.Rows.Count;
            string sep = "_" + ((is_user) ? user_comboBox.Text.ToUpper() : role_comboBox.Text.ToUpper()) + "_VIEW";
            List<DataRow> temp_del_list = new List<DataRow>();

            // XỬ LÍ TÊN
            foreach (DataRow dr in Select_Priv.Rows)
            {
                if (dr["OBJECT_NAME"].ToString().Contains(sep) == true)
                {
                    string[] temp = dr["OBJECT_NAME"].ToString().Split(new[] { sep }, StringSplitOptions.None);
                    //MessageBox.Show(temp[0]);
                    dr["OBJECT_NAME"] = temp[0];

                    for (int i = 0; i < Remain_select_priv_count; i++)
                    {
                        DataRow dr2 = Remain_Select_Priv.Rows[i];
                        if (dr["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString())
                        {
                            Remain_Select_Priv.Rows.Remove(Remain_Select_Priv.Rows[i]);
                            Remain_select_priv_count--;
                            break;
                        }
                    }
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

        private bool Check_Row_In_Datatable(DataTable dt, DataRow dr1)
        {
            bool ret = false;
            foreach(DataRow dr2 in dt.Rows)
            {
                if (dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString())
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        // Datatable basic là datatable chứa 1 group đầy đủ của Table_Name và Datatable Check là check trên đó.
        private bool Check_Group(DataTable basic,DataTable check, string Table_name, bool Check_Grant_col = false, bool Check_Grant_Value_As = false)
        {
            List<DataRow> temp_list = new List<DataRow>();
            foreach(DataRow dr in basic.Rows)
            {
                if (dr["OBJECT_NAME"].ToString() == Table_name)
                    temp_list.Add(dr);
            }
            int count = 0;
            if (Check_Grant_col)
            {
                bool temp = (Check_Grant_Value_As) ? true : Convert.ToBoolean(temp_list[0]["WITH GRANT OPTION"]); // lấy giá trị with grant option của dòng đầu ra,
                foreach (DataRow dr1 in temp_list)
                {
                    foreach (DataRow dr2 in check.Rows)
                    {
                        if (dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString() && Convert.ToBoolean(dr1["WITH GRANT OPTION"]) == temp)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow dr1 in temp_list)
                {
                    foreach (DataRow dr2 in check.Rows)
                    {
                        if (dr1["OBJECT_NAME"].ToString() == dr2["OBJECT_NAME"].ToString() && dr1["COLUMN_NAME"].ToString() == dr2["COLUMN_NAME"].ToString())
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return (count == temp_list.Count) ? true : false;
        }

        public void Priv_Preprocessing(DataTable Select_Priv)
        {
            //int Remain_select_priv_count = Remain_Select_Priv.Rows.Count;
            string sep = "_" + this.username.ToUpper() + "_VIEW";
            List<DataRow> temp_del_list = new List<DataRow>();

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


    }


}
