using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab1
{
    public partial class UserControlInputRegexEmail : UserControl
    {
        [Category("Спецификация"), Description("Шаблон вводимого значения")]
        public string Pattern { get; set; } = string.Empty;

        public string Value
        {
            get
            {
                string inputText = textBox.Text;
                string outputText;
                if (!string.IsNullOrEmpty(inputText))
                {
                    if (!Regex.IsMatch(inputText, Pattern))
                    {
                        throw new ArgumentException();
                    }
                    outputText = inputText;
                }
                else
                {
                    outputText = string.Empty;
                }
                return outputText;
            }
            set
            {
                textBox.Text = value;
            }
        }
        public UserControlInputRegexEmail()
        {
            InitializeComponent();
        }

        public void SetToolTip(string prompt)
        {
            toolTip.SetToolTip(textBox, prompt);
        }
    }
}
