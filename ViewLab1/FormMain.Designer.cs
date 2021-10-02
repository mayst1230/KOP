namespace ViewLab1
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new Lab1.UserControlOutputListBox();
            this.comboBox = new Lab1.UserControlSelectedComboBox();
            this.textBoxEmail = new Lab1.UserControlInputRegexEmail();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxSetDescrption = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonSetDesc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Location = new System.Drawing.Point(443, 20);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox.Name = "listBox";
            this.listBox.SelectedIndex = -1;
            this.listBox.Size = new System.Drawing.Size(337, 305);
            this.listBox.TabIndex = 0;
            // 
            // comboBox
            // 
            this.comboBox.Location = new System.Drawing.Point(13, 20);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox.Name = "comboBox";
            this.comboBox.SelectedItem = "";
            this.comboBox.Size = new System.Drawing.Size(290, 28);
            this.comboBox.TabIndex = 0;
            this.comboBox.ComboBoxSelectedElementChange += new System.EventHandler(this.comboBox_ComboBoxSelectedElementChange);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(13, 126);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Pattern = "";
            this.textBoxEmail.Size = new System.Drawing.Size(324, 36);
            this.textBoxEmail.TabIndex = 1;
            this.textBoxEmail.Value = "";
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(14, 56);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(125, 27);
            this.textBoxAdd.TabIndex = 2;
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.Location = new System.Drawing.Point(14, 90);
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(125, 27);
            this.textBoxSelect.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(145, 56);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(109, 29);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(146, 90);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(108, 29);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "buttonSelect";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(311, 20);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 28);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "buttonClr";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxSetDescrption
            // 
            this.textBoxSetDescrption.Location = new System.Drawing.Point(13, 169);
            this.textBoxSetDescrption.Name = "textBoxSetDescrption";
            this.textBoxSetDescrption.Size = new System.Drawing.Size(125, 27);
            this.textBoxSetDescrption.TabIndex = 8;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(343, 133);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(94, 29);
            this.buttonEnter.TabIndex = 9;
            this.buttonEnter.Text = "buttonEntr";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonSetDesc
            // 
            this.buttonSetDesc.Location = new System.Drawing.Point(146, 169);
            this.buttonSetDesc.Name = "buttonSetDesc";
            this.buttonSetDesc.Size = new System.Drawing.Size(94, 29);
            this.buttonSetDesc.TabIndex = 11;
            this.buttonSetDesc.Text = "setDesc";
            this.buttonSetDesc.UseVisualStyleBackColor = true;
            this.buttonSetDesc.Click += new System.EventHandler(this.buttonSetDesc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.buttonSetDesc);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxSetDescrption);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSelect);
            this.Controls.Add(this.textBoxAdd);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.listBox);
            this.Name = "FormMain";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lab1.UserControlOutputListBox listBox;
        private Lab1.UserControlSelectedComboBox comboBox;
        private Lab1.UserControlInputRegexEmail textBoxEmail;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxSetDescrption;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonSetDesc;
    }
}

