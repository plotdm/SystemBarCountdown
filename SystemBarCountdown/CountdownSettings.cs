using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemBarCountdown.Validation;

namespace SystemBarCountdown
{
    public partial class CountdownSettingsForm : Form
    {
        private List<Validator> _hoursValidators;
        private List<Validator> _minutesValidators;
        private List<Validator> _secondsValidators;

        public CountdownSettingsForm()
        {
            InitializeComponent();

            _hoursValidators = new List<Validator>()
            {
                new IsNumberValidator()
            };
            _minutesValidators = _secondsValidators = new List<Validator>()
            {
                new IsNumberValidator()
            };
        }

        private void startTimerButton_Click(object sender, EventArgs e)
        {
            var timerDisplay = new TimerDisplay();
            timerDisplay.finishAt = MakeFinishTime();
            timerDisplay.ShowDialog();
        }

        private DateTime MakeFinishTime()
        {
            int hours = Convert.ToInt32(hoursTextBox.Text);
            int minutes = Convert.ToInt32(minutesTextBox.Text);
            int seconds = Convert.ToInt32(secondsTextBox.Text);

            return DateTime.Now + new TimeSpan(hours, minutes, seconds);
        }

        private void hoursTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidateWithValidators((TextBox)sender, _hoursValidators);
        }

        private void minutesTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidateWithValidators((TextBox)sender, _minutesValidators);
        }

        private void secondsTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidateWithValidators((TextBox)sender, _secondsValidators);
        }

        private bool ValidateWithValidators(TextBox textBox, List<Validator> validators)
        {
            foreach (var validator in validators)
            {
                validator.Value = textBox.Text;
                validator.Validate();
                if (validator.IsValid)
                {
                    HideValidationErrorForTextBox(textBox);
                }
                else
                {
                    ShowValidationErrorForTextBox(textBox, validator.Error);
                    return false;
                }
            }
            return true;
        }

        private void ShowValidationErrorForTextBox(TextBox textBox, ValidationError error)
        {
            textBox.BackColor = Color.Red;
        }

        private void HideValidationErrorForTextBox(TextBox textBox)
        {
            textBox.BackColor = SystemColors.Window;
        }
    }
}
