
namespace Laba2View
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.wordComponentTable = new Laba2.WordTable(this.components);
            this.wordComponentText = new Laba2.WordText(this.components);
            this.wordComponentChart = new Laba2.WordChart(this.components);
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonCreateWordChart = new System.Windows.Forms.Button();
            this.buttonCreateWordText = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(11, 12);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(286, 32);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "createWordTable";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToWordTable_Click);
            // 
            // buttonCreateWordChart
            // 
            this.buttonCreateWordChart.Location = new System.Drawing.Point(11, 49);
            this.buttonCreateWordChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateWordChart.Name = "buttonCreateWordChart";
            this.buttonCreateWordChart.Size = new System.Drawing.Size(286, 29);
            this.buttonCreateWordChart.TabIndex = 2;
            this.buttonCreateWordChart.Text = "createWordChart";
            this.buttonCreateWordChart.UseVisualStyleBackColor = true;
            this.buttonCreateWordChart.Click += new System.EventHandler(this.buttonCreateWordChart_Click);
            // 
            // buttonCreateWordText
            // 
            this.buttonCreateWordText.Location = new System.Drawing.Point(11, 302);
            this.buttonCreateWordText.Name = "buttonCreateWordText";
            this.buttonCreateWordText.Size = new System.Drawing.Size(286, 31);
            this.buttonCreateWordText.TabIndex = 3;
            this.buttonCreateWordText.Text = "createWordText";
            this.buttonCreateWordText.UseVisualStyleBackColor = true;
            this.buttonCreateWordText.Click += new System.EventHandler(this.buttonCreateWordText_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(11, 118);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(285, 22);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(11, 163);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(286, 133);
            this.textBoxText.TabIndex = 5;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(8, 98);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(72, 17);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Enter title:";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(8, 143);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(72, 17);
            this.labelText.TabIndex = 7;
            this.labelText.Text = "Enter text:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 345);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonCreateWordText);
            this.Controls.Add(this.buttonCreateWordChart);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Laba2.WordText wordComponentText;
        private Laba2.WordTable wordComponentTable;
        private Laba2.WordChart wordComponentChart;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonCreateWordChart;
        private System.Windows.Forms.Button buttonCreateWordText;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelText;
    }
}

