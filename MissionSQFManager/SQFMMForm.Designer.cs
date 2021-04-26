namespace MissionSQFManager
{
    partial class SQFMMForm
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.objectsList = new System.Windows.Forms.ListBox();
            this.objectCounter = new System.Windows.Forms.Label();
            this.previewModeDropDown = new System.Windows.Forms.ComboBox();
            this.outputFormatDropDown = new System.Windows.Forms.ComboBox();
            this.previewModeLabel = new System.Windows.Forms.Label();
            this.outputFormatLabel = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.saveOutputButton = new System.Windows.Forms.Button();
            this.sortByNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.replaceClassnames = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFileButton.Location = new System.Drawing.Point(110, 557);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(99, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Load from file";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButtonClick);
            // 
            // objectsList
            // 
            this.objectsList.FormattingEnabled = true;
            this.objectsList.Location = new System.Drawing.Point(110, 135);
            this.objectsList.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.objectsList.Name = "objectsList";
            this.objectsList.Size = new System.Drawing.Size(899, 407);
            this.objectsList.TabIndex = 1;
            // 
            // objectCounter
            // 
            this.objectCounter.AutoSize = true;
            this.objectCounter.Location = new System.Drawing.Point(107, 107);
            this.objectCounter.Name = "objectCounter";
            this.objectCounter.Size = new System.Drawing.Size(102, 13);
            this.objectCounter.TabIndex = 2;
            this.objectCounter.Text = "No objects loaded...";
            // 
            // previewModeDropDown
            // 
            this.previewModeDropDown.FormattingEnabled = true;
            this.previewModeDropDown.Items.AddRange(new object[] {
            "Output Preview",
            "Raw Object Data"});
            this.previewModeDropDown.Location = new System.Drawing.Point(888, 95);
            this.previewModeDropDown.Name = "previewModeDropDown";
            this.previewModeDropDown.Size = new System.Drawing.Size(121, 21);
            this.previewModeDropDown.TabIndex = 3;
            this.previewModeDropDown.SelectedIndexChanged += new System.EventHandler(this.PreviewModeDropDown_SelectedIndexChanged);
            // 
            // outputFormatDropDown
            // 
            this.outputFormatDropDown.FormattingEnabled = true;
            this.outputFormatDropDown.Items.AddRange(new object[] {
            "Formatted SQF",
            "Biedi"});
            this.outputFormatDropDown.Location = new System.Drawing.Point(888, 562);
            this.outputFormatDropDown.Name = "outputFormatDropDown";
            this.outputFormatDropDown.Size = new System.Drawing.Size(121, 21);
            this.outputFormatDropDown.TabIndex = 4;
            this.outputFormatDropDown.SelectedIndexChanged += new System.EventHandler(this.OutputFormatDropDown_SelectedIndexChanged);
            // 
            // previewModeLabel
            // 
            this.previewModeLabel.AutoSize = true;
            this.previewModeLabel.Location = new System.Drawing.Point(807, 98);
            this.previewModeLabel.Name = "previewModeLabel";
            this.previewModeLabel.Size = new System.Drawing.Size(75, 13);
            this.previewModeLabel.TabIndex = 5;
            this.previewModeLabel.Text = "Preview Mode";
            // 
            // outputFormatLabel
            // 
            this.outputFormatLabel.AutoSize = true;
            this.outputFormatLabel.Location = new System.Drawing.Point(807, 567);
            this.outputFormatLabel.Name = "outputFormatLabel";
            this.outputFormatLabel.Size = new System.Drawing.Size(74, 13);
            this.outputFormatLabel.TabIndex = 6;
            this.outputFormatLabel.Text = "Output Format";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(107, 84);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(54, 13);
            this.fileName.TabIndex = 7;
            this.fileName.Text = "File Name";
            // 
            // saveOutputButton
            // 
            this.saveOutputButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveOutputButton.Enabled = false;
            this.saveOutputButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveOutputButton.Location = new System.Drawing.Point(228, 557);
            this.saveOutputButton.Name = "saveOutputButton";
            this.saveOutputButton.Size = new System.Drawing.Size(99, 23);
            this.saveOutputButton.TabIndex = 8;
            this.saveOutputButton.Text = "Save Output";
            this.saveOutputButton.UseVisualStyleBackColor = false;
            this.saveOutputButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // sortByNamesCheckBox
            // 
            this.sortByNamesCheckBox.AutoSize = true;
            this.sortByNamesCheckBox.Location = new System.Drawing.Point(370, 561);
            this.sortByNamesCheckBox.Name = "sortByNamesCheckBox";
            this.sortByNamesCheckBox.Size = new System.Drawing.Size(134, 17);
            this.sortByNamesCheckBox.TabIndex = 9;
            this.sortByNamesCheckBox.Text = "Order By Alphanumeric";
            this.sortByNamesCheckBox.UseVisualStyleBackColor = true;
            this.sortByNamesCheckBox.CheckedChanged += new System.EventHandler(this.SortByNamesCheckBox_CheckedChanged);
            // 
            // replaceClassnames
            // 
            this.replaceClassnames.AutoSize = true;
            this.replaceClassnames.Location = new System.Drawing.Point(536, 561);
            this.replaceClassnames.Name = "replaceClassnames";
            this.replaceClassnames.Size = new System.Drawing.Size(184, 17);
            this.replaceClassnames.TabIndex = 10;
            this.replaceClassnames.Text = "Replace Classnames From Config";
            this.replaceClassnames.UseVisualStyleBackColor = true;
            this.replaceClassnames.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // SQFMMForum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 694);
            this.Controls.Add(this.replaceClassnames);
            this.Controls.Add(this.sortByNamesCheckBox);
            this.Controls.Add(this.saveOutputButton);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.outputFormatLabel);
            this.Controls.Add(this.previewModeLabel);
            this.Controls.Add(this.outputFormatDropDown);
            this.Controls.Add(this.previewModeDropDown);
            this.Controls.Add(this.objectCounter);
            this.Controls.Add(this.objectsList);
            this.Controls.Add(this.openFileButton);
            this.Name = "SQFMMForum";
            this.Text = "SQF Mission Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.ListBox objectsList;
        private System.Windows.Forms.Label objectCounter;
        private System.Windows.Forms.ComboBox previewModeDropDown;
        private System.Windows.Forms.ComboBox outputFormatDropDown;
        private System.Windows.Forms.Label previewModeLabel;
        private System.Windows.Forms.Label outputFormatLabel;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Button saveOutputButton;
        private System.Windows.Forms.CheckBox sortByNamesCheckBox;
        private System.Windows.Forms.CheckBox replaceClassnames;
    }
}

