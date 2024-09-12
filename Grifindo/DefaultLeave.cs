using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Grifindo.UniversalClass;
using System.Runtime.Remoting.Lifetime;

namespace Grifindo
{
    public partial class DefaultLeave : Form
    {
        private int ID = 0;
        public DefaultLeave()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sql = "insert into Leave(Annual_Leave,Casual_Leave) values('"+AnnualLeave_txt.Text+"','"+CasualLeave_txt.Text+"')";
            DataBaseClass.save(sql);
            loadDataInMyGridView();
        }

        private void DefaultLeave_Load(object sender, EventArgs e)
        {
            loadDataInMyGridView();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update Leave set Annual_Leave = '"+AnnualLeave_txt.Text+"',Casual_Leave = '"+CasualLeave_txt.Text+"' where Leave_ID = " + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void DefaultLeave_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            ID = Convert.ToInt32(DefaultLeave_GridView.Rows[RowIndex].Cells[0].Value.ToString());
            ID_txt.Text = DefaultLeave_GridView.Rows[RowIndex].Cells[0].Value.ToString();
            AnnualLeave_txt.Text = DefaultLeave_GridView.Rows[RowIndex].Cells[1].Value.ToString();
            CasualLeave_txt.Text = DefaultLeave_GridView.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Leave where Leave_ID = " + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                AnnualLeave_txt,
                CasualLeave_txt,
                ID_txt
            });
        }
        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Leave";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, DefaultLeave_GridView);
        }
    }
}
