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
    public partial class Employee : Form
    {
        private int ID = 0;
        public Employee()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sql = $"insert into Employee ( Employee_Name, Employee_Address, Employee_Age, Monthly_Salary, Overtime_Rate, Allowence, Department_FK , Leave_FK, Administration_FK) values ('{Name_txt.Text}', '{ Address_txt.Text }', '{ Age_txt.Text }', '{ MonthlySalary_txt.Text }', '{ OverTimeRate_txt.Text }', '{ Allowence_txt.Text }', { DepartmentComboBox.SelectedValue.ToString() }, { DefaultLeaveComboBox.SelectedValue.ToString() },'{AdministrationComboBox.SelectedValue.ToString()}')";
            DataBaseClass.save(sql);
            loadDataInMyGridView();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // dipartment 
            DataBaseClass.loadFkDataInComboBox("SELECT *FROM Department", DepartmentComboBox, "Department_ID", "Department_Name");
            DataBaseClass.loadFkDataInComboBox("select * from Leave", DefaultLeaveComboBox, "Leave_ID", "Leave_ID");
            DataBaseClass.loadFkDataInComboBox("select * from Administration", AdministrationComboBox, "Administration_ID", "Administration_Name");
            loadDataInMyGridView();
        }

        private void loadDataInMyGridView()
        {
            string sql = "SELECT e.Employee_ID, e.Employee_Name , d.Department_Name, l.Annual_Leave, l.Casual_Leave  FROM Employee e join Department d on e.Department_FK = d.Department_ID join Leave l on e.Leave_FK = l.Leave_ID";
            DataBaseClass.loadDataFromDBtoDataGridView(sql, Employee_GridView);
        }

        private void Employee_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ID = Convert.ToInt32(Employee_GridView.Rows[index].Cells[0].Value.ToString());
            string sql = "select * from Employee where Employee_ID ="+ ID;
            DataTable dt = DataBaseClass.getDataFromDB(sql);

            if( dt.Rows.Count > 0 )
            {
                Name_txt.Text = dt.Rows[0]["Employee_Name"].ToString();
                MonthlySalary_txt.Text = dt.Rows[0]["Monthly_Salary"].ToString();
                Address_txt.Text = dt.Rows[0]["Employee_Address"].ToString();
                Age_txt.Text = dt.Rows[0]["Employee_Age"].ToString();
                OverTimeRate_txt.Text = dt.Rows[0]["Overtime_Rate"].ToString();
                Allowence_txt.Text = dt.Rows[0]["Allowence"].ToString();


                DefaultLeaveComboBox.SelectedValue = dt.Rows[0]["Leave_Fk"].ToString();
                DepartmentComboBox.SelectedValue = dt.Rows[0]["Department_Fk"].ToString();
                AdministrationComboBox.SelectedValue = dt.Rows[0]["Administration_Fk"].ToString();
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                Name_txt,
                Address_txt,
                Age_txt,
                OverTimeRate_txt,
                Allowence_txt,
                DefaultLeaveComboBox,
                MonthlySalary_txt,
                DepartmentComboBox,
                AdministrationComboBox,
                ID_txt
            });
        }











        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"update Employee set Employee_Name = '{Name_txt.Text}', Employee_Address = '{Address_txt.Text}', Employee_Age = '{Age_txt.Text}', Monthly_Salary = '{MonthlySalary_txt.Text}', Overtime_Rate = '{OverTimeRate_txt.Text}', Allowence = '{Allowence_txt.Text}', Department_FK = {DepartmentComboBox.SelectedValue.ToString()}, Leave_FK = {DefaultLeaveComboBox.SelectedValue.ToString()}, Administration_FK = {AdministrationComboBox.SelectedValue.ToString()} where Employee_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Employee where Employee_ID =" + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }
    }
}
