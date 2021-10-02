
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Lab2
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
        /// Метод для создания документа Word с настраиваемой таблицей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Путь до документа</param>
        /// <param name="document_header">Название документа</param>
        /// <param name="width_columns">Массив ширины столбцов</param>
        /// <param name="height_rows">Массив высот строк</param>
        /// <param name="headers">Названия колонок</param>
        /// <param name="list_of_data">Список данных (Объектов)</param>
        /// <returns>Получилось ли создать документ</returns>
        public bool CreateDoc<T>(String path, String document_header, int[] width_columns, string[] headers, List<T> list_of_data)
        {
                if (path != null && document_header != null && width_columns != null && headers != null && list_of_data != null)
                {
                    //Свойства объекта
                    PropertyInfo[] properties = list_of_data[0].GetType().GetProperties();

                    //Создаем приложение Word
                    Application application = new Application();
                    application.Visible = true;

                    //Открываем документ
                    Document document = application.Documents.Add(Visible: true);

                    Paragraph paragraph_header = document.Content.Paragraphs.Add();
                    paragraph_header.Range.Text = document_header;
                    paragraph_header.Range.Font.Size = 24;
                    paragraph_header.Range.Font.Name = "Century Gothic";
                    paragraph_header.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    Paragraph paragraph = document.Content.Paragraphs.Add();
                    paragraph = document.Content.Paragraphs.Add();

                    //Создаем таблицу (Дополнительная строка под шапку)
                    Table table = document.Tables.Add(paragraph.Range, list_of_data.Count + 1, properties.Length);
                    table.Borders.Enable = 1;

                    //Нумерация колонок и строк в Word ничинается с 1 а не с 0
                    for (int row = 1; row <= table.Rows.Count; row++)
                    {
                        // Сдвиг в колонке идет из-за шапки
                        for (int column = 1; column <= table.Columns.Count; column++)
                        {
                            if (row == 1)
                            {
                                table.Cell(row, column).Range.Text = properties[column - 1].Name;
                                table.Cell(row, column).Range.Font.Bold = 1;
                                table.Cell(row, column).Column.Width = width_columns[column - 1];
                            }
                            else
                            {
                                var data = list_of_data[row - 2].GetType().GetProperty(properties[column - 1].Name)
                                    .GetValue(list_of_data[row - 2]) ?? null;

                                if (data != null)
                                {
                                    table.Cell(row, column).Range.Text = data.ToString();
                                }

                                table.Cell(row, column).Range.Font.Bold = column == 1 ? 1 : 0;

                            }

                            table.Cell(row, column).Range.Font.Name = "verdana";
                            table.Cell(row, column).Range.Font.Size = 10;
                            table.Cell(row, column).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            table.Cell(row, column).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                    }

                    bool check_headers = true;

                    for (int column = 1; column <= table.Columns.Count; column++)
                    {
                        if (table.Cell(1, column).Range.Text == "\r\a")
                        {
                            check_headers = false;
                        }
                    }

                    for (int row = 1; row <= table.Rows.Count; row++)
                    {
                        if (table.Cell(row, 1).Range.Text == "\r\a")
                        {
                            check_headers = false;
                        }
                    }

                    document.SaveAs(path);

                    document.Close();
                    application.Quit();

                    if (!check_headers)
                    {
                        return false;
                    }

                    return true;
                }
                return false;
            
        }
    }
}
