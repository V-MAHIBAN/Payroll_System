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
    public partial class Mobile : Form
    {
        private int ID = 0;
        public Mobile()
        {
            InitializeComponent();
        }






        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Mobile";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, Mobile_GridView);
        }






        private void Mobile_Load(object sender, EventArgs e)
        {
            DataBaseClass.loadFkDataInComboBox("SELECT *FROM Employee", EmployeeComboBox, "Employee_ID", "Employee_Name");
            loadDataInMyGridView();
        }







        private void Mobile_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ID = Convert.ToInt32(Mobile_GridView.Rows[index].Cells[0].Value.ToString());
            string sql = "select * from Mobile where Mobile_ID =" + ID;
            DataTable dt = DataBaseClass.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                //This is for text box
                ID_txt.Text = dt.Rows[0]["Mobile_ID"].ToString();
                Number_txt.Text = dt.Rows[0]["Mobile_Number"].ToString();

                //This is for combo box
                EmployeeComboBox.SelectedValue = dt.Rows[0]["Employee_FK"].ToString();
            }
        }






        private void SaveButton_Click(object sender, EventArgs e)
        {
            //This is Insert query coding
            string sql = "insert into Mobile(Mobile_Number, Employee_FK) values ('"+Number_txt.Text+"', '"+EmployeeComboBox.SelectedValue.ToString()+"')";

            //This is call the funtion from database class
            DataBaseClass.save(sql);

            //This is call the function for gridview load
            loadDataInMyGridView();
        }






        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                Number_txt,
                EmployeeComboBox,
                ID_txt
            });
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Mobile where Mobile_ID =" + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"update Mobile set Mobile_Number = '{Number_txt.Text}', Employee_FK = {EmployeeComboBox.SelectedValue.ToString()} where Mobile_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }
    }
}
