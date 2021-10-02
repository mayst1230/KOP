using Microsoft.Office.Interop.Word;
using System;
using System.ComponentModel;

namespace Laba2
{
    public partial class WordText : Component
    {
        public WordText()
        {
            InitializeComponent();
        }

        public WordText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateWordText(TextComponentParameters parameters)
        {
            if (parameters.Title != null && parameters.Path != null && parameters.Text != null)
            {
                var application = new Application();
                application.Visible = false;

                var document = application.Documents.Add(Visible: false);

                var paragraphTitle = document.Content.Paragraphs.Add();
                paragraphTitle.Range.Text = parameters.Title;
                paragraphTitle.Range.Font.Size = 14;
                paragraphTitle.Range.Font.Bold = 1;
                paragraphTitle.Range.Font.Name = "Times New Roman";
                paragraphTitle.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                var section = document.Content.Paragraphs.Add();
                section = document.Content.Paragraphs.Add();
                section.Range.Font.Bold = 0;

                foreach (var text in parameters.Text)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        var paragraphContent = section;
                        paragraphContent.Range.Font.Bold = 0;
                        paragraphContent.Range.Text = paragraphContent.Range.Text + text + '.';
                        paragraphContent = document.Content.Paragraphs.Add();
                    }
                }

                document.SaveAs(parameters.Path);
                document.Close();
                application.Quit();

                return true;
            }
            else
            {
                throw new Exception("Не все параметры переданы");
            }
        }
    }
}
