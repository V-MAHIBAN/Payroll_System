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
    public partial class Holiday : Form
    {
        private int ID = 0;
        public Holiday()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sql = "insert into Holiday(No_Of_Day,Holiday_Month) values('"+ No_of_Day_txt.Text+ "','"+ Month_dtpicker.Text+ "')";  
            DataBaseClass.save(sql);
            loadDataInMyGridView();
        }

        private void Holiday_Load(object sender, EventArgs e)
        {
            loadDataInMyGridView();
        }

        private void Holiday_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            ID = Convert.ToInt32(Holiday_GridView.Rows[RowIndex].Cells[0].Value.ToString());
            ID_txt.Text = Holiday_GridView.Rows[RowIndex].Cells[0].Value.ToString();
            No_of_Day_txt.Text = Holiday_GridView.Rows[RowIndex].Cells[1].Value.ToString();
            Month_dtpicker.Text = Holiday_GridView.Rows[RowIndex].Cells[2].Value.ToString();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?","Update Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update Holiday set No_Of_Day = '"+ No_of_Day_txt.Text+ "',Holiday_Month = '"+ Month_dtpicker.Text+ "' where Holiday_ID = " + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?","Delete Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Holiday where Holiday_ID = " + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                No_of_Day_txt,
                Month_dtpicker,
                ID_txt
            });
        }
        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Holiday";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, Holiday_GridView);
        }
    }
}
