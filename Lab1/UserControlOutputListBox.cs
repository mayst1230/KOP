using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab1
{
    public partial class UserControlOutputListBox : UserControl
    {
        private Parameters prm = null;

        private string splittingSubstring(string frst, string lst, string mainString, out int pos)
        {
            pos = frst.Length;

            int num = mainString.IndexOf(lst) - 1;

            if (num <= pos)
            {
                num = mainString.Length - 1;
            }

            var result = mainString.Substring(pos, num - pos + 1);
            return result;
        }

        [Category("Спецификация"), Description("Индекс выбранной строки")]
        public int SelectedIndex
        {
            get => listBox.SelectedIndex;
            set
            {
                if (value >= -1 && value < listBox.Items.Count)
                    listBox.SelectedIndex = value;
            }
        }


        public void SetLayout(Parameters layout)
        {
            if (layout != null)
                prm = layout;
        }

        public UserControlOutputListBox()
        {
            InitializeComponent();
        }

        public void Insert<T>(List<T> list)
        {
            if ((list != null && list.Count != 0 && prm != null))
            {
                foreach (var item in list)
                {
                    if (item != null)
                    {
                        var pattrn = prm.patrn;
                        foreach (Match match in Regex.Matches(prm.patrn, prm.getPtrn))
                        {
                            string data;

                            string middleValue = match.Value.Remove(match.Value.Length - 1, 1).Remove(0, 1);
                            string helpPtrn = pattrn;
                            string result = prm.strtChar + middleValue + prm.finshChar;

                            var property = item.GetType().GetProperty(middleValue);
                            if (property != null)
                            {
                                var value = property.GetValue(item, null);
                                data = value?.ToString();
                            }
                            else
                            {
                                data = null;
                            }
                            pattrn = helpPtrn.Replace(result, data);
                        }
                        listBox.Items.Add(pattrn);
                    }
                }
            }
        }

        public T GetProperty<T>() where T : class, new()
        {
            T res;
            int num;
            if (listBox.SelectedIndex != -1 && prm != null)
            {
                T generic = Activator.CreateInstance<T>();
                string selectComboboxItem = listBox.SelectedItem.ToString();
                string ptrn = prm.patrn;
                string[] arr = Regex.Split(ptrn, prm.getPtrn);
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    string split = splittingSubstring(arr[i], arr[i + 1], selectComboboxItem, out num);
                    selectComboboxItem = selectComboboxItem.Remove(0, num + split.Length);
                    string result = splittingSubstring(arr[i], arr[i + 1], ptrn, out num);

                    ptrn = ptrn.Remove(0, num + result.Length);
                    result = result.Substring(1, result.Length - 2);
                    var property = generic.GetType().GetProperty(result);

                    if (property != null)
                    {
                        var propertyInfo = property;
                        object obj = generic;
                        string str1 = split;
                        Type propertyType = null;
                        if (property != null)
                        {
                            propertyType = property.PropertyType;
                        }
                        else
                        {
                            propertyType = null;
                        }
                        propertyInfo.SetValue(obj, Convert.ChangeType(str1, propertyType));
                    }
                }
                res = generic;
            }
            else
            {
                res = default(T);
            }
            return res;
        }
    }
}
