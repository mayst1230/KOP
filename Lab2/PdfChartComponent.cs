using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab2
{
    public partial class PdfChartComponent : Component
    {
        public PdfDataLabelType DataLabelType { get; set; } = PdfDataLabelType.None;

        public PdfChartComponent()
        {
            InitializeComponent();
        }

        public PdfChartComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [System.Obsolete]
        public bool buildChart<T>(Parameters<T> parameters)
        {
            var dict = create(parameters.Data, parameters.PropertyName);

            Document document = new Document();

            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style.Font.Color = Colors.Black;
            style.Font.Bold = true;
            document.Styles.AddStyle("NormalTitle", "Normal");

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph($"Линейная диаграмма по свойству: {parameters.PropertyName}");
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            Chart chart = new Chart();
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Line;
            series.MarkerBackgroundColor = Color.FromRgb(209, 53, 53);
            series.MarkerForegroundColor = Color.FromRgb(209, 53, 53);

            XSeries xseries = chart.XValues.AddXSeries();

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = parameters.PropertyName;

            chart.YAxis.Title.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
            chart.YAxis.Title.Orientation = 90;
            chart.YAxis.Title.Caption = $"Frequancy: {parameters.PropertyName}";
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            foreach (var key in dict.Keys)
            {
                series.Add(dict[key]);
                xseries.Add(key);
            }

            document.LastSection.Add(chart);

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(parameters.Path);
            return true;
        }

        private Dictionary<string, int> create<T>(List<T> dataList, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            if (property != null)
            {
                dict = new Dictionary<string, int>();
                foreach (var elem in dataList)
                {
                    var propertyValue = property.GetValue(elem);
                    string propertyValueString = propertyValue.ToString();
                    if (!string.IsNullOrEmpty(propertyValueString))
                    {
                        if (dict.ContainsKey(propertyValueString))
                        {
                            dict[propertyValueString]++;
                        }
                        else
                        {
                            dict.Add(propertyValueString, 1);
                        }
                    }
                }
            }
            return dict;
        }
    }
}
