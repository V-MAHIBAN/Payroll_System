using Grifindo.UniversalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Grifindo
{
    public partial class Salary : Form
    {
        private string connectionString = "Data Source=MAHIBAN\\SQLEXPRESS;Initial Catalog=Grifindo;Integrated Security=True";
        
        public Salary()
        {
            InitializeComponent();
        }

        private void Find_btn_Click(object sender, EventArgs e)
        {
            // Retrieve employee details from the database
            RetrieveEmployeeDetails();
        }

        private void RetrieveEmployeeDetails()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = $"SELECT e.Employee_ID, e.Employee_Name, e.Monthly_Salary, e.Allowence, e.Overtime_Rate, (SELECT Date_Range FROM Salary_Cycle WHERE Salary_Cycle_ID = '10') AS DateRange, (SELECT Gov_Tax FROM Salary_Cycle WHERE Salary_Cycle_ID = '10') AS Tax, (SELECT No_Of_Day FROM Holiday WHERE MONTH(Holiday_Month) = MONTH('{SalaryCalculation_dtpicker.Text}') AND YEAR(Holiday_Month) = YEAR('{SalaryCalculation_dtpicker.Text}')) AS Holidays, (SELECT SUM(No_of_Day) FROM Applied_Leave WHERE Employee_FK = e.Employee_ID AND MONTH(EndDate_or_Time) = MONTH('{SalaryCalculation_dtpicker.Text}') AND YEAR(EndDate_or_Time) = YEAR('{SalaryCalculation_dtpicker.Text}')) AS Leaves, (SELECT COUNT(*) FROM Attendance WHERE Employee_FK = e.Employee_ID AND MONTH(Working_Day) = MONTH('{SalaryCalculation_dtpicker.Text}') AND YEAR(Working_Day) = YEAR('{SalaryCalculation_dtpicker.Text}')) AS WorkedDays, (SELECT SUM(DATEDIFF(HOUR, In_Time, Out_Time)) FROM Attendance WHERE Employee_FK = e.Employee_ID AND MONTH(Working_Day) = MONTH('{SalaryCalculation_dtpicker.Text}') AND YEAR(Working_Day) = YEAR('{SalaryCalculation_dtpicker.Text}')) AS WorkedHours FROM Employee e WHERE e.Employee_ID = '{EmployeeID_txt.Text}'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Retrieve data and store it in variables
                    int EmployeeID = Convert.ToInt32(reader["Employee_ID"]);
                    string EmployeeName = reader["Employee_Name"].ToString();
                    double MonthlySalary = Convert.ToDouble(reader["Monthly_Salary"]);
                    double Allowence = Convert.ToDouble(reader["Allowence"]);
                    double OverTimeRate = Convert.ToDouble(reader["Overtime_Rate"]);
                    int DateRange = Convert.ToInt32(reader["DateRange"]);
                    double GovernmentTax = Convert.ToDouble(reader["Tax"]);
                    int Holiday = Convert.ToInt32(reader["Holidays"]);
                    int AppliedLeaves = Convert.ToInt32(reader["Leaves"]);
                    int WorkedDays = Convert.ToInt32(reader["WorkedDays"]);
                    double WorkedHours = Convert.ToDouble(reader["WorkedHours"]);


                    // Display data to text boxes
                    EmpID_txt.Text = EmployeeID.ToString();
                    EmpName_txt.Text = EmployeeName.ToString();
                    MonthlySalary_txt.Text = MonthlySalary.ToString();
                    Allowence_txt.Text = Allowence.ToString();
                    DateRange_txt.Text = DateRange.ToString();
                    Tax_txt.Text = GovernmentTax.ToString();
                    Holiday_txt.Text = Holiday.ToString();
                    AppliedLeave_txt.Text = AppliedLeaves.ToString();
                    WorkedDays_txt.Text = WorkedDays.ToString();
                    WorkedHour_txt.Text = WorkedHours.ToString();

                    // Call PerformCalculations with retrieved values
                    PerformCalculations(MonthlySalary, Allowence, OverTimeRate, DateRange, GovernmentTax, Holiday, AppliedLeaves, WorkedDays, WorkedHours);
                    
                }
                else
                {
                    MessageBox.Show("Please Check The Employee ID & Selected Date");
                }
            }
        }


        private void PerformCalculations(double MonthlySalary, double Allowence, double OverTimeRate, int DateRange, double GovernmentTax, int Holiday, int AppliedLeaves, int WorkedDays, double WorkedHours)
        {
            // Calculate total salary
            
            double TotalSalary = MonthlySalary + Allowence;

            // Calculate the number of absent days
            int Absent = DateRange - (AppliedLeaves + Holiday + WorkedDays);

            // Calculate the number of overtime hours
            double OverTimeHour = WorkedHours - (DateRange * 8);

            // Calculate over time amount
            double OverTimeAmount = OverTimeHour * OverTimeRate;

            // Calculate no pay
            double NoPay = (TotalSalary / DateRange) * Absent;

            // Calculate base pay
            double BasePay = MonthlySalary + Allowence + (OverTimeAmount);

            // Calculate gross pay
            double GrossPay = BasePay - (NoPay + (BasePay * (GovernmentTax/100)));


            DisplayCalculations(Absent, OverTimeHour, NoPay, BasePay, GrossPay, OverTimeAmount);

        }


        private void DisplayCalculations(int Absent, double OverTimeHour, double NoPay, double BasePay, double GrossPay, double OverTimeAmount)
        {
            //Assuming you have labels for displaying the calculated salary and employee details
            BasePay_txt.Text = BasePay.ToString();
            GrossPay_txt.Text = GrossPay.ToString();
            NoPay_txt.Text = NoPay.ToString();
            OverTimeHour_txt.Text = OverTimeHour.ToString();
            OverTimeRate_txt.Text = OverTimeAmount.ToString();

            if (Absent > 0)
            {
                Absent_txt.Text = Absent.ToString();
            }
            else
            {
                Absent_txt.Text = "No absences";
            }
        }


        // Clear the data from text boxes

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            DataBaseClass.clearInputs(new List<Control>()
            {
                EmployeeID_txt, SalaryCalculation_dtpicker, BasePay_txt, GrossPay_txt, NoPay_txt, Absent_txt, OverTimeHour_txt,
                DateRange_txt, WorkedDays_txt, WorkedHour_txt, AppliedLeave_txt, Holiday_txt, EmpID_txt, EmpName_txt,
                Tax_txt, MonthlySalary_txt, Allowence_txt, OverTimeRate_txt
            });
        }

        private void Pay_btn_Click(object sender, EventArgs e)
        {
            string sql = $"insert into Salary(Salary_Month, Base_Pay, Gross_Pay, No_Pay, Overtime_Hour, Overtime_Amount, No_of_AppliedLeave, No_of_Absent, Holiday_FK, Employee_FK) values ('{SalaryCalculation_dtpicker.Text}', '{BasePay_txt.Text}', '{GrossPay_txt.Text}', '{NoPay_txt.Text}', '{OverTimeHour_txt.Text}', '{OverTimeRate_txt.Text}', '{AppliedLeave_txt.Text}', '{Absent_txt.Text}', '{Holiday_txt.Text}', '{EmpID_txt.Text}')";

            DataBaseClass.save(sql);
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }
    }
}
