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
    public partial class SalaryCycle : Form
    {
        private int ID = 0;
        public SalaryCycle()
        {
            InitializeComponent();
        }
        //This is salarycycle form load coding
        private void SalaryCycle_Load(object sender, EventArgs e)
        {
            //This is combo box coding
            DataBaseClass.loadFkDataInComboBox("SELECT *FROM Administration", AdministrationComboBox, "Administration_ID", "Administration_Name");

            //This is call the function for gridview load
            loadDataInMyGridView();
        }

        // This is save button coding
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //This is Insert query coding
            string sql = $"insert into Salary_Cycle(Date_Range, Begin_Date, End_Date, Administration_FK, Gov_Tax) values ('{DateRange_txt.Text}', '{BeginDate_dtpicker.Text}', '{EndDate_dtpicker.Text}', {AdministrationComboBox.SelectedValue.ToString()}, '{Tax_txt.Text}')";

            //This is call the funtion from database class
            DataBaseClass.save(sql);

            //This is call the function for gridview load
            loadDataInMyGridView();
        }

        //This is GridView load function
        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Salary_Cycle";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, SalaryCycle_GridView);
        }


        // This is Cell click coding
        private void SalaryCycle_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ID = Convert.ToInt32(SalaryCycle_GridView.Rows[index].Cells[0].Value.ToString());
            string sql = "select * from Salary_Cycle where Salary_Cycle_ID =" + ID;
            DataTable dt = DataBaseClass.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                //This is for text box
                DateRange_txt.Text = dt.Rows[0]["Date_Range"].ToString();
                BeginDate_dtpicker.Text = dt.Rows[0]["Begin_Date"].ToString();
                EndDate_dtpicker.Text = dt.Rows[0]["End_Date"].ToString();
                ID_txt.Text = dt.Rows[0]["Salary_Cycle_ID"].ToString();
                Tax_txt.Text = dt.Rows[0]["Gov_Tax"].ToString();

                //This is for combo box
                AdministrationComboBox.SelectedValue = dt.Rows[0]["Administration_FK"].ToString();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update Salary_Cycle set Date_Range = '"+DateRange_txt.Text+"', Begin_Date = '"+BeginDate_dtpicker.Text+"', End_Date = '"+EndDate_dtpicker.Text+ "', Administration_FK = '"+AdministrationComboBox.SelectedValue.ToString()+ "', Gov_Tax = '"+Tax_txt.Text+"' where Salary_Cycle_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                BeginDate_dtpicker,
                EndDate_dtpicker,
                ID_txt,
                DateRange_txt,
                AdministrationComboBox,
                Tax_txt
            });
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Salary_Cycle where Salary_Cycle_ID = " + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }
    }
    
}
