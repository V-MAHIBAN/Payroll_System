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
    public partial class AppliedLeave : Form
    {
        private int ID = 0;
        public AppliedLeave()
        {
            InitializeComponent();
        }






        // this is grid view function
        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Applied_Leave";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, AppliedLeave_GridView);
        }






        // this is form load
        private void AppliedLeave_Load(object sender, EventArgs e)
        {
            DataBaseClass.loadFkDataInComboBox("SELECT *FROM Employee", Employee_ComboBox, "Employee_ID", "Employee_Name");
            loadDataInMyGridView();
        }






        // this is cell click coding
        private void AppliedLeave_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ID = Convert.ToInt32(AppliedLeave_GridView.Rows[index].Cells[0].Value.ToString());
            string sql = "select * from Applied_Leave where Applied_Leave_ID =" + ID;
            DataTable dt = DataBaseClass.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                //This is for text box
                ID_txt.Text = dt.Rows[0]["Applied_Leave_ID"].ToString();
                No_of_Day_txt.Text = dt.Rows[0]["No_of_Day"].ToString();
                Reason_txt.Text = dt.Rows[0]["Reason"].ToString();
                StartDate_dtpicker.Text = dt.Rows[0]["StartDate_or_Time"].ToString();
                EndDate_dtpicker.Text = dt.Rows[0]["EndDate_or_Time"].ToString();

                //This is for combo box
                Employee_ComboBox.SelectedValue = dt.Rows[0]["Employee_FK"].ToString();
            }
        }






        // this is save button coding
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //This is Insert query coding
            string sql = "insert into Applied_Leave(StartDate_or_Time, EndDate_or_Time, No_of_Day, Reason, Employee_FK) values ('"+StartDate_dtpicker.Text+"','"+EndDate_dtpicker.Text+"','"+No_of_Day_txt.Text+"','"+Reason_txt.Text+"', '"+Employee_ComboBox.SelectedValue.ToString()+"')";

            //This is call the funtion from database class
            DataBaseClass.save(sql);

            //This is call the function for gridview load
            loadDataInMyGridView();
        }




        // this is clear button coding
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                StartDate_dtpicker,
                EndDate_dtpicker,
                ID_txt,
                No_of_Day_txt,
                Reason_txt,
                Employee_ComboBox
            });
        }





        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"update Applied_Leave set StartDate_or_Time = '{StartDate_dtpicker.Text}', EndDate_or_Time = '{EndDate_dtpicker.Text}', No_of_Day = '{No_of_Day_txt.Text}', Reason = '{Reason_txt.Text}', Employee_FK = {Employee_ComboBox.SelectedValue.ToString()} where Applied_Leave_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }






        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Applied_Leave where Applied_Leave_ID =" + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }
    }
}
