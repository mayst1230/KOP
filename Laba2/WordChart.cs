using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Laba2
{
    public partial class WordChart : Component
    {
        public WordChart()
        {
            InitializeComponent();
        }

        public WordChart(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// <param name="path">Путь для сохранения файла</param>
        /// <param name="documentName">Название документа (первый абзац в документе)</param>
        /// <param name="chartName">Название диаграммы</param>
        /// <param name="legendLocation">Расположение легенды в диаграмме</param>
        /// <param name="series">Серии</param>
        /// </summary>
        public bool CreateWordChart(string path, string documentName, string chartName, LegendLocation legendLocation, Dictionary<string, int[]> series)
        {
            if (path != null && documentName != null && chartName != null
                && Enum.IsDefined(typeof(LegendLocation), legendLocation) && series != null)
            {
                Word.Application word = new Word.Application();
                word.Visible = false;
                Word.Document document = word.Documents.Add();
                Word.Chart chart = document.InlineShapes.AddChart2(2, Microsoft.Office.Core.XlChartType.xlLineMarkers).Chart;
                Word.ChartData chartData = chart.ChartData;
                Excel.Workbook workbook = (Excel.Workbook)chartData.Workbook;
                Excel.Worksheet dataSheet = (Excel.Worksheet)workbook.Worksheets[1];
                workbook.Application.Visible = false;

                int columnNumber = series.Count + 1;
                string columnName = "";
                while (columnNumber > 0)
                {
                    int byModule = (columnNumber - 1) % 26;
                    columnName = Convert.ToChar('A' + byModule) + columnName;
                    columnNumber = (columnNumber - byModule) / 26;
                }

                Excel.Range tableRange = dataSheet.Cells.get_Range("A1", columnName + (series.ElementAt(0).Value.Length + 1).ToString());
                Excel.ListObject table1 = dataSheet.ListObjects["Таблица1"];
                table1.Resize(tableRange);

                for (int seriesNumber = 0; seriesNumber < series.Count; seriesNumber++)
                {
                    dataSheet.Cells[1, seriesNumber + 2].Value = series.ElementAt(seriesNumber).Key;
                }

                int countOfColumns = series.Values.ElementAt(0).Length;

                for (int seriesNumber = 0; seriesNumber < series.Count; seriesNumber++)
                {
                    for (int numberInSeries = 0; numberInSeries < countOfColumns; numberInSeries++)
                    {
                        dataSheet.Cells[numberInSeries + 2, seriesNumber + 2].Value = series.ElementAt(seriesNumber).Value.ElementAt(numberInSeries);
                    }
                }

                for (int row = 0; row < series.ElementAt(0).Value.Length + 1; row++)
                {
                    dataSheet.Cells[row + 2, 1].Value = "";
                }

                chart.HasTitle = true;
                chart.ChartTitle.Font.Color = Color.FromArgb(255, 255, 255).ToArgb();
                chart.ChartTitle.Font.Italic = true;
                chart.ChartTitle.Font.Size = 18;
                chart.ChartTitle.Text = chartName;
                chart.Legend.Position = (Word.XlLegendPosition)legendLocation;

                int time = 2000;

                Thread.Sleep(time);

                Word.Paragraph paragraph_header = document.Content.Paragraphs.Add(document.Range(document.Content.Start));
                paragraph_header.Range.Text = documentName;

                paragraph_header.Range.Font.Size = 24;
                paragraph_header.Range.Font.Name = "Century Gothic";
                paragraph_header.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paragraph_header.Space2();

                workbook.Application.Quit();

                document.SaveAs(path);
                document.Close();
                word.Quit();

                return true;
            }
            else
            {
                throw new Exception("Не все параметры переданы");
            }
        }
    }
}
