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
    public partial class Administration : Form
    {
        private int ID = 0;
        public Administration()
        {
            InitializeComponent();
        }



        private void Administration_Load(object sender, EventArgs e)
        {
            loadDataInMyGridView();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sql = "insert into Administration(Administration_Name, Admin_UserName, Admin_Password) values ('"+Name_txt.Text+"', '"+UserName_txt.Text+"','"+Password_txt.Text+"')";
            DataBaseClass.save(sql);
            loadDataInMyGridView();
        }
        private void AdministrationGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update Administration set Administration_Name = '"+Name_txt.Text+"', Admin_UserName = '"+UserName_txt.Text+"', Admin_Password = '"+Password_txt.Text+"' where Administration_ID =" + ID;
                DataBaseClass.update(sql);
                loadDataInMyGridView();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                Name_txt, UserName_txt, Password_txt,ID_txt
            });
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from Administration where Administration_ID =" + ID;
                DataBaseClass.delete(sql);
                loadDataInMyGridView();
            }
        }

        private void AdministrationGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            ID = Convert.ToInt32(AdministrationGridView.Rows[RowIndex].Cells[0].Value.ToString());
            ID_txt.Text = AdministrationGridView.Rows[RowIndex].Cells[0].Value.ToString();
            Name_txt.Text = AdministrationGridView.Rows[RowIndex].Cells[1].Value.ToString();
            UserName_txt.Text = AdministrationGridView.Rows[RowIndex].Cells[2].Value.ToString();
            Password_txt.Text = AdministrationGridView.Rows[RowIndex].Cells[3].Value.ToString();
        }

        private void loadDataInMyGridView()
        {
            //This is sql query
            string sql = "SELECT *FROM Administration";

            //This is call the loadDataFromDBtoDataGridView function from database class
            DataBaseClass.loadDataFromDBtoDataGridView(sql, AdministrationGridView);
        }
    }
}
