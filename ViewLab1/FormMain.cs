using Lab1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewLab1
{
    public partial class FormMain : Form
    {
        private const string patern = "^([\\w\\d\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

        private const string toolTip = "nick@gmail.com";

        private Parameters layout = new Parameters()
        {
            finshChar = '}',
            strtChar = '{',
            patrn = "company {Company}; numberCar - {NumberCar}"
        };

        private List<Cars> cars = new List<Cars>()
        {
            new Cars() { Company = "Nissan", NumberCar = 456 },
            new Cars() { Company = "Tayota", NumberCar = 123 },
            new Cars() { Company = "VAZ", NumberCar = 890 },
            new Cars() { Company = "Mazda", NumberCar = 454 },
            new Cars() { Company = "Subaru", NumberCar = 231 },
            new Cars() { Company = "Volvo", NumberCar = 676 },
        };

        public FormMain()
        {
            InitializeComponent();
            comboBox.Insert(new List<string> { "House", "Car" });
            textBoxEmail.Pattern = patern;
            textBoxEmail.SetToolTip(toolTip);
            listBox.SetLayout(layout);
            listBox.Insert(cars);
        }

        private void comboBox_ComboBoxSelectedElementChange(object sender, System.EventArgs e)
        {
            MessageBox.Show("Элемент: " + comboBox.SelectedItem + " есть в списке", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {

            List<string> addEl = new List<string>();

            addEl.Add(textBoxAdd.Text);
            if (string.IsNullOrEmpty(textBoxAdd.Text))
            {
                MessageBox.Show("Введите название элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            comboBox.Insert(addEl);
            textBoxAdd.Text = string.Empty;
        }

        private void buttonSelect_Click(object sender, System.EventArgs e)
        {
            string select = textBoxSelect.Text;
            if (string.IsNullOrEmpty(select))
            {
                MessageBox.Show("Введите название элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            comboBox.SelectedItem = select;
            comboBox.Text = string.Empty;
        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            comboBox.Clear();
        }

        private void buttonEnter_Click(object sender, System.EventArgs e)
        {
            try
            {
                string mail = textBoxEmail.Value;
                MessageBox.Show("Введенная почта валидна", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Введенная почта невалидна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetPattern_Click(object sender, System.EventArgs e)
        {
            /*string pattern = textBoxSetPatrn.Text;
            if (string.IsNullOrEmpty(pattern))
            {
                MessageBox.Show("Введите шаблон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxEmail.Pattern = pattern;
            textBoxSetPatrn.Text = string.Empty;*/
        }

        private void buttonSetDesc_Click(object sender, System.EventArgs e)
        {
            string description = textBoxSetDescrption.Text;
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Введите подсказку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxEmail.SetToolTip(description);
            textBoxSetDescrption.Text = string.Empty;
        }
    }
}
