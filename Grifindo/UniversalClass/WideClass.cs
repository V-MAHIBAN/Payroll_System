using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo.UniversalClass
{
    internal class WideClass
    {
        // application close btn click fun
        public static void appsCloseBtnFun()
        {
            Application.Exit();
        }

        // form close btn click
        public static void formCloseBtnFun(Form formName)
        {
            formName.Close();
        }

        // application min btn click fun
        public static void appsMinBtnFun(Form formName)
        {
            formName.WindowState = FormWindowState.Minimized;
        }


        // application new form Open btn without close current Form
        public static void appsNewFormOpenBtnWithoutCurrentFormClose(Form formName)
        {
            formName.Show();
        }


        // application new form Open btn with close current Form
        public static void appsNewFormOpenBtnWithCurrentFormClose(Form formName,
            Form currentFom)
        {
            formName.Show();
            currentFom.Hide();
        }


        // Display form inside panel
        public static void appsFormLoadInsidePanel(Form formName, Panel panelName)
        {
            // cleare Constrols first
            panelName.Controls.Clear();

            // add controls
            formName.TopLevel = false;
            formName.AutoScroll = true;
            panelName.Controls.Add(formName);
            formName.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formName.Dock = DockStyle.Fill;
            formName.Show();

        }

        public static void isEmptyValidation(List<ValidateCombo> textBoxes)
        {
            foreach (ValidateCombo combo in textBoxes)
            {
                if (combo.myInputTextBox.Text != "")
                {
                    combo.myValidationText.Visible = false;
                }
                else
                {
                    combo.myValidationText.Visible = true;
                }
            }
        }
    }
}
