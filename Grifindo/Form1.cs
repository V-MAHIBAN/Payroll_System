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
    public partial class Grifindo_DashBoard : Form
    {
        public Grifindo_DashBoard()
        {
            InitializeComponent();
        }

        

        private void Grifindo_DashBoard_Load(object sender, EventArgs e)
        {
            FormTitle_lbl.Text = "Home";
            WideClass.appsFormLoadInsidePanel(new Home(), FillPanel);
        }

        private void Admin_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Administration";
            // this code for call the form in dashboard panel when click the button
            WideClass.appsFormLoadInsidePanel(new Administration(), FillPanel);
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Home";
            WideClass.appsFormLoadInsidePanel(new Home(), FillPanel);
        }

        private void Employee_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Employee";
            WideClass.appsFormLoadInsidePanel(new Employee(), FillPanel);
        }

        private void Attendance_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Attendance";
            WideClass.appsFormLoadInsidePanel(new Attendance(), FillPanel);
        }

        private void AppliedLeave_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Applied Leave";
            WideClass.appsFormLoadInsidePanel(new AppliedLeave(), FillPanel);
        }

        private void SalaryCycle_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Salary Cycle";
            WideClass.appsFormLoadInsidePanel(new SalaryCycle(), FillPanel);
        }

        private void Salary_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Salary";
            WideClass.appsFormLoadInsidePanel(new Salary(), FillPanel);
        }

        private void Department_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Department";
            WideClass.appsFormLoadInsidePanel(new Department(), FillPanel);
        }

        private void Mobile_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Mobile";
            WideClass.appsFormLoadInsidePanel(new Mobile(), FillPanel);
        }

        private void DefaultLeave_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Default Leave";
            WideClass.appsFormLoadInsidePanel(new DefaultLeave(), FillPanel);
        }

        private void Holiday_btn_Click(object sender, EventArgs e)
        {
            // this code for load page title
            FormTitle_lbl.Text = "Holiday";
            WideClass.appsFormLoadInsidePanel(new Holiday(), FillPanel);
        }

        private void LogOut_btn_Click(object sender, EventArgs e)
        {
            // Perform any logout-related actions, such as clearing session data, resetting UI, etc.

            // Assuming you want to go back to the login screen or close the current form.
            Login loginForm = new Login(); // Replace with the actual login form class
            loginForm.Show();
            this.Hide(); // Hide the current form (assuming it's the main form)
        }
    }
}
