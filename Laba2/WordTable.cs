using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Laba2
{
    public partial class WordTable : Component
    {
        public WordTable()
        {
            InitializeComponent();
        }

        public WordTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// <param name="path">Путь для сохранения файла</param>
        /// <param name="documentHeader">Заголовок документа</param>
        /// <param name="widthColumns">Ширина ячеек</param>
        /// <param name="headers">Заголовки</param>
        /// <param name="dataList">Список с данными</param>
        /// </summary>
        public bool CreateWordTable<T>(string path, string documentHeader, int[] widthColumns, List<HelperWordTable> headers, List<T> dataList)
            where T : class
        {
            if (path != null && documentHeader != null && widthColumns != null && headers != null && dataList != null)
            {
                PropertyInfo[] properties = dataList[0].GetType().GetProperties();

                Application application = new Application();
                application.Visible = false;
                Document document = application.Documents.Add(Visible: false);
                Paragraph paragraphHeader = document.Content.Paragraphs.Add();
                paragraphHeader.Range.Text = documentHeader;
                paragraphHeader.Range.Font.Size = 24;
                paragraphHeader.Range.Font.Name = "Century Gothic";
                paragraphHeader.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Paragraph paragraph = document.Content.Paragraphs.Add();
                paragraph = document.Content.Paragraphs.Add();
                Table table = document.Tables.Add(paragraph.Range, 1, headers.Count);
                table.Borders.Enable = 1;
                table.Range.Font.Name = "verdana";
                table.Range.Font.Size = 10;
                table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                for (int column = 1; column < headers.Count + 1; column++)
                {
                    table.Cell(1, column).Column.Width = headers[column - 1].Width;
                }

                int shift = 0;

                for (int column = 1; column < headers.Count + 1; column++)
                {
                    if (headers[column - 1].AdvancedHeader?.Count != 0 && headers[column - 1].AdvancedHeader != null)
                    {
                        int dop_column = column + shift;

                        table.Cell(1, column).Split(NumRows: 2);
                        table.Cell(1, column).Range.Text = headers[column - 1].MainHeader;
                        table.Cell(2, dop_column).Split(NumColumns: headers[column - 1].AdvancedHeader.Count);

                        for (int j = 0; j < headers[column - 1].AdvancedHeader.Count; j++)
                        {
                            table.Cell(2, dop_column + j).Range.Text = headers[column - 1].AdvancedHeader[j];
                        }

                        shift += headers[column - 1].AdvancedHeader.Count - 1;
                    }
                    else
                    {
                        table.Cell(1, column).Range.Text = headers[column - 1].MainHeader;
                    }
                }

                List<string> headersPropertiesColumns = new List<string>();
                for (int mainHeader = 0; mainHeader < headers.Count; mainHeader++)
                {
                    for (int property = 0; property < headers[mainHeader].Properties.Count; property++)
                    {
                        headersPropertiesColumns.Add(headers[mainHeader].Properties[property]);
                    }
                }

                int rowIndex = 3;

                for (int dataElement = 0; dataElement < dataList.Count(); dataElement++)
                {
                    table.Rows.Add();

                    for (int column = 1; column < table.Columns.Count + 1; column++)
                    {
                        var data = dataList[dataElement].GetType().GetProperty(headersPropertiesColumns[column - 1]).GetValue(dataList[dataElement]) ?? null;

                        if (data != null)
                        {
                            table.Cell(rowIndex, column).Range.Text = data.ToString();
                        }
                    }

                    rowIndex++;
                }

                document.SaveAs(path);
                document.Close();
                application.Quit();

                return true;
            }

            return false;
        }
    }
}
