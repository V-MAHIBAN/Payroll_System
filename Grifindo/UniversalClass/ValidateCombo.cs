using System.Windows.Forms;

namespace Grifindo.UniversalClass
{
    internal class ValidateCombo
    {
        public TextBox myInputTextBox { get; set; }
        public Label myValidationText { get; set; }
        public ValidateCombo(TextBox _myInputTextBox,Label _myValidationText)
        {
            myInputTextBox = _myInputTextBox;
            myValidationText = _myValidationText;
        }
    }
}