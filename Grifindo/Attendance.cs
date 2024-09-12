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
    public partial class Attendance : Form
    {
        private int ID = 0;
        public Attendance()
        {
            InitializeComponent();
        }





        // this is grid view function
        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Attendance";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, Attendance_GridView);
        }






        private void Attendance_Load(object sender, EventArgs e)
        {
            DataBaseClass.loadFkDataInComboBox("SELECT *FROM Employee", EmployeeComboBox, "Employee_ID", "Employee_Name");
            loadDataInMyGridView();
        }










        private void Attendance_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ID = Convert.ToInt32(Attendance_GridView.Rows[index].Cells[0].Value.ToString());
            string sql = "select * from Attendance where Attendance_ID =" + ID;
            DataTable dt = DataBaseClass.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                //This is for text box
                ID_txt.Text = dt.Rows[0]["Attendance_ID"].ToString();
                InTime_dtpicker.Text = dt.Rows[0]["In_Time"].ToString();
                OutTime_dtpicker.Text = dt.Rows[0]["Out_Time"].ToString();
                WorkDay_dtpicker.Text = dt.Rows[0]["Working_Day"].ToString();

                //This is for combo box
                EmployeeComboBox.SelectedValue = dt.Rows[0]["Employee_FK"].ToString();
            }
        }







        private void SaveButton_Click(object sender, EventArgs e)
        {
            //This is Insert query coding
            string sql = "insert into Attendance(In_Time, Out_Time, Working_Day, Employee_FK) values ('"+InTime_dtpicker.Text+"','"+OutTime_dtpicker.Text+"','"+WorkDay_dtpicker.Text+"', '"+EmployeeComboBox.SelectedValue.ToString()+"')";

            //This is call the funtion from database class
            DataBaseClass.save(sql);

            //This is call the function for gridview load
            loadDataInMyGridView();
        }







        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                InTime_dtpicker,
                OutTime_dtpicker,
                ID_txt,
                WorkDay_dtpicker,
                EmployeeComboBox
            });
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"update Attendance set In_Time = '{InTime_dtpicker.Text}', Out_Time = '{OutTime_dtpicker.Text}', Working_Day = '{WorkDay_dtpicker.Text}', Employee_FK = {EmployeeComboBox.SelectedValue.ToString()} where Attendance_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Attendance where Attendance_ID =" + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }
    }
}
