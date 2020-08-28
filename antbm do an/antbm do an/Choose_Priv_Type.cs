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
    public partial class Choose_Priv_Type : Form
    {
        public ChucNang_form MainForm;
        public Choose_Priv_Type(ChucNang_form form)
        {
            MainForm = form;
            DataTable const_dt = new DataTable();
            const_dt.Columns.Add(new DataColumn("PRIV TYPE", Type.GetType("System.String")));

            DataRow dr = const_dt.NewRow();
            dr["PRIV TYPE"] = "SELECT";
            const_dt.Rows.Add(dr);

            dr = const_dt.NewRow();
            dr["PRIV TYPE"] = "UPDATE";
            const_dt.Rows.Add(dr);

            dr = const_dt.NewRow();
            dr["PRIV TYPE"] = "DELETE";
            const_dt.Rows.Add(dr);

            dr = const_dt.NewRow();
            dr["PRIV TYPE"] = "INSERT";
            const_dt.Rows.Add(dr);
            InitializeComponent();

            Priv_Type_datagridview.DataSource = const_dt;

            Priv_Type_datagridview.ReadOnly = true;
            Priv_Type_datagridview.AllowUserToAddRows = false;
            //Priv_Type_datagridview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Priv_Type_datagridview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Priv_Type_datagridview.AutoResizeColumns();
            //Priv_Type_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string priv_type = Priv_Type_datagridview.Rows[e.RowIndex].Cells[0].Value.ToString();
            //Choose_Table chon_bang = new Choose_Table(conn);
            if(priv_type == "SELECT")
            {
                Choose_Table chon_bang = new Choose_Table(MainForm,priv_type);
                chon_bang.Show();
            }
            else if (priv_type == "UPDATE")
            {
                Choose_Table chon_bang = new Choose_Table(MainForm, priv_type);
                chon_bang.Show();

            }
            else if (priv_type == "INSERT")
            {
                Choose_Priv chon_priv = new Choose_Priv(MainForm, priv_type);
                chon_priv.Show();
            }
            else if (priv_type == "DELETE")
            {
                Choose_Table chon_priv = new Choose_Table(MainForm, priv_type);
                chon_priv.Show();
            }
            else
            {
                MessageBox.Show("LỖI!!");
            }

        }
    }
}
