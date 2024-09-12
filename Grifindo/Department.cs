using Grifindo.UniversalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo
{
    public partial class Department : Form
    {
        private int ID = 0;
        public Department()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sql = "insert into Department(Department_Name) values('"+ Name_txt.Text+ "')";
            DataBaseClass.save(sql);
            loadDataInMyGridView();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            loadDataInMyGridView();
        }

        private void Department_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            ID = Convert.ToInt32(Department_GridView.Rows[RowIndex].Cells[0].Value.ToString());
            ID_txt.Text = Department_GridView.Rows[RowIndex].Cells[0].Value.ToString();
            Name_txt.Text = Department_GridView.Rows[RowIndex].Cells[1].Value.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update Department set Department_Name = '"+Name_txt.Text+"' where Department_ID = " + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Department where Department_ID = " + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                Name_txt,
                ID_txt
            });
        }

        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Department";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, Department_GridView);
        }
    }
}
