using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab1
{
    public partial class UserControlSelectedComboBox : UserControl
    {
        private event EventHandler _comboBoxSelectedElementChange;

        [Category("Спецификация"), Description("Выбранный элемент")]
        public string SelectedItem
        {
            get => comboBox.SelectedItem == null ? string.Empty : comboBox.SelectedItem.ToString();
            set => comboBox.SelectedItem = value;
        }

        [Category("Спецификация"), Description("Событие выбора элемента из списка")]
        public event EventHandler ComboBoxSelectedElementChange
        {
            add { _comboBoxSelectedElementChange += value; }
            remove { _comboBoxSelectedElementChange -= value; }
        }

        public UserControlSelectedComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                _comboBoxSelectedElementChange?.Invoke(sender, e);
            };
        }
        public void Clear()
        {
            comboBox.Items.Clear();
            comboBox.Text = string.Empty;
        }

        public void Insert(List<string> list)
        {
            foreach (var elem in list)
            {
                comboBox.Items.Add(elem);
            }
        }
    }
}
