using Laba2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba2View
{
    public partial class FormMain : Form
    {
        private readonly string[] mainText = {
            "Начальный текст, введите свой текст здесь.",
            "Точка - конец абзаца."
        };

        private readonly string titleText = "Начальный заголовок";

        public FormMain()
        {
            InitializeComponent();

            textBoxTitle.Text = string.Concat(titleText);
            textBoxText.Text = string.Concat(mainText);
        }

        private List<HelperWordTable> headerSettingsTable = new List<HelperWordTable>()
        {
            new HelperWordTable { MainHeader = "CarsInfo", AdvancedHeader = new List<string>() { "NameCarBrand", "VIN" }, Width = 150, Properties = new List<string>() { "NameCarBrand", "VIN" } },
            new HelperWordTable { MainHeader = "Owner", AdvancedHeader = new List<string>(), Width = 70, Properties = new List<string>() { "OwnerName" } },
            new HelperWordTable { MainHeader = "PurchaseInfo", AdvancedHeader = new List<string>() { "SumPurchaseAuto", "YearPurchaseAuto"}, Width = 160, Properties = new List<string>() { "SumPurchaseAuto", "YearPurchaseAuto" } },
        };

        int[] widthColumnsTable = new int[] { 40, 40, 40, 40, 40 };

        List<Cars> listDataTable = new List<Cars>() {
            new Cars { NameCarBrand = "Nissan", VIN = "A2344GB57", OwnerName = "Mark", SumPurchaseAuto = 450000 },
            new Cars { NameCarBrand = "Subaru", OwnerName = "Jonh", SumPurchaseAuto = 700000, YearPurchaseAuto = 2016},
            new Cars { VIN = "HJK67945F", OwnerName = "Robert", SumPurchaseAuto = 620000, YearPurchaseAuto = 2020},
            new Cars { NameCarBrand = "Volvo", VIN = "HM6743FTD", OwnerName = "Vasya", SumPurchaseAuto = 620000 },
        };

        Dictionary<string, int[]> listDataChart = new Dictionary<string, int[]>
        {
            { "Серия 1", new int[] { 3, 6, 7, 9 } },
            { "Серия 2", new int[] { 5, 8, 4, 10 } },
            { "Серия 3", new int[] { 7, 9, 2, 12 } },
            { "Серия 4", new int[] { 4, 2, 3, 1 } },
            { "Серия 5", new int[] { 7, 3, 0, 13 } }
        };

        private void buttonCreateWordText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text) || string.IsNullOrEmpty(textBoxText.Text))
            {
                MessageBox.Show("Введите заголовок и текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (wordComponentText.CreateWordText(new TextComponentParameters()
            {
                Path = "wordTextLab2",
                Title = textBoxTitle.Text,
                Text = textBoxText.Text.Split('.')
            }))
            {
                MessageBox.Show("Файл Word с текстом был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании файла Word с текстом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToWordTable_Click(object sender, EventArgs e)
        {
            bool result = wordComponentTable.CreateWordTable("wordTableLab2.docx", "Word table", widthColumnsTable, headerSettingsTable, listDataTable);

            if (result)
            {
                MessageBox.Show("Документ Word таблицей создан");
            }
            else
            {
                MessageBox.Show("Ошибка при создании документа Word с таблицей");
            }
        }

        private void buttonCreateWordChart_Click(object sender, EventArgs e)
        {
            bool result = wordComponentChart.CreateWordChart("wordChartLab2.docx",
                "Linear chart",
                "Info",
                LegendLocation.Top,
                listDataChart);

            if (result)
            {
                MessageBox.Show("Документ Word с линейной диаграммой успешно создан");
            }
            else
            {
                MessageBox.Show("Ошибка при создании документа Word с линейной диаграммой");
            }
        }
    }
}
