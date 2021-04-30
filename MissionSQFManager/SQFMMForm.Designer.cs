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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQFMMForm));
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
            this.formatInputBox = new System.Windows.Forms.TextBox();
            this.formatLabel = new System.Windows.Forms.Label();
            this.formatHelpBox = new System.Windows.Forms.ListBox();
            this.sortByClassToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.replaceClassnamesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.loadFileToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.discardUnitsCheckBox = new System.Windows.Forms.CheckBox();
            this.discardVehiclesCheckBox = new System.Windows.Forms.CheckBox();
            this.prefixLineInputBox = new System.Windows.Forms.TextBox();
            this.suffixLineInputBox = new System.Windows.Forms.TextBox();
            this.prefixLineLabel = new System.Windows.Forms.Label();
            this.suffixLineLabel = new System.Windows.Forms.Label();
            this.indentsLabel = new System.Windows.Forms.Label();
            this.indentsNumBox = new System.Windows.Forms.NumericUpDown();
            this.relativeXLabel = new System.Windows.Forms.Label();
            this.relativeYLabel = new System.Windows.Forms.Label();
            this.relativeZLabel = new System.Windows.Forms.Label();
            this.relativePosCheckBox = new System.Windows.Forms.CheckBox();
            this.relativeXNumeric = new System.Windows.Forms.NumericUpDown();
            this.relativeYNumeric = new System.Windows.Forms.NumericUpDown();
            this.relativeZNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeXNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeYNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeZNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFileButton.Location = new System.Drawing.Point(109, 574);
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
            this.objectsList.HorizontalScrollbar = true;
            this.objectsList.Location = new System.Drawing.Point(109, 152);
            this.objectsList.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.objectsList.Name = "objectsList";
            this.objectsList.Size = new System.Drawing.Size(899, 407);
            this.objectsList.TabIndex = 1;
            // 
            // objectCounter
            // 
            this.objectCounter.AutoSize = true;
            this.objectCounter.Location = new System.Drawing.Point(106, 124);
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
            this.previewModeDropDown.Location = new System.Drawing.Point(187, 615);
            this.previewModeDropDown.Name = "previewModeDropDown";
            this.previewModeDropDown.Size = new System.Drawing.Size(121, 21);
            this.previewModeDropDown.TabIndex = 3;
            this.previewModeDropDown.SelectedIndexChanged += new System.EventHandler(this.PreviewMode_SelectedIndexChanged);
            // 
            // outputFormatDropDown
            // 
            this.outputFormatDropDown.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.outputFormatDropDown.FormattingEnabled = true;
            this.outputFormatDropDown.Items.AddRange(new object[] {
            "Formatted SQF",
            "Biedi",
            "SQM"});
            this.outputFormatDropDown.Location = new System.Drawing.Point(866, 29);
            this.outputFormatDropDown.Name = "outputFormatDropDown";
            this.outputFormatDropDown.Size = new System.Drawing.Size(142, 21);
            this.outputFormatDropDown.TabIndex = 4;
            this.outputFormatDropDown.SelectedIndexChanged += new System.EventHandler(this.OutputFormat_SelectedIndexChanged);
            // 
            // previewModeLabel
            // 
            this.previewModeLabel.AutoSize = true;
            this.previewModeLabel.Location = new System.Drawing.Point(106, 618);
            this.previewModeLabel.Name = "previewModeLabel";
            this.previewModeLabel.Size = new System.Drawing.Size(75, 13);
            this.previewModeLabel.TabIndex = 5;
            this.previewModeLabel.Text = "Preview Mode";
            // 
            // outputFormatLabel
            // 
            this.outputFormatLabel.AutoSize = true;
            this.outputFormatLabel.Location = new System.Drawing.Point(785, 34);
            this.outputFormatLabel.Name = "outputFormatLabel";
            this.outputFormatLabel.Size = new System.Drawing.Size(74, 13);
            this.outputFormatLabel.TabIndex = 6;
            this.outputFormatLabel.Text = "Output Format";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(106, 101);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(73, 15);
            this.fileName.TabIndex = 7;
            this.fileName.Text = "File Name";
            // 
            // saveOutputButton
            // 
            this.saveOutputButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveOutputButton.Enabled = false;
            this.saveOutputButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveOutputButton.Location = new System.Drawing.Point(227, 574);
            this.saveOutputButton.Name = "saveOutputButton";
            this.saveOutputButton.Size = new System.Drawing.Size(99, 23);
            this.saveOutputButton.TabIndex = 8;
            this.saveOutputButton.Text = "Save Output";
            this.saveOutputButton.UseVisualStyleBackColor = false;
            this.saveOutputButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // sortByNamesCheckBox
            // 
            this.sortByNamesCheckBox.AutoSize = true;
            this.sortByNamesCheckBox.Location = new System.Drawing.Point(353, 580);
            this.sortByNamesCheckBox.Name = "sortByNamesCheckBox";
            this.sortByNamesCheckBox.Size = new System.Drawing.Size(126, 17);
            this.sortByNamesCheckBox.TabIndex = 9;
            this.sortByNamesCheckBox.Text = "Order By Class Name";
            this.sortByNamesCheckBox.UseVisualStyleBackColor = true;
            this.sortByNamesCheckBox.CheckedChanged += new System.EventHandler(this.SortByNames_CheckedChanged);
            // 
            // replaceClassnames
            // 
            this.replaceClassnames.AutoSize = true;
            this.replaceClassnames.Location = new System.Drawing.Point(352, 604);
            this.replaceClassnames.Name = "replaceClassnames";
            this.replaceClassnames.Size = new System.Drawing.Size(189, 17);
            this.replaceClassnames.TabIndex = 10;
            this.replaceClassnames.Text = "Replace Class Names From Config";
            this.replaceClassnames.UseVisualStyleBackColor = true;
            this.replaceClassnames.CheckedChanged += new System.EventHandler(this.ReplaceNames_CheckedChanged);
            // 
            // formatInputBox
            // 
            this.formatInputBox.Location = new System.Drawing.Point(653, 73);
            this.formatInputBox.Name = "formatInputBox";
            this.formatInputBox.Size = new System.Drawing.Size(202, 20);
            this.formatInputBox.TabIndex = 11;
            this.formatInputBox.TextChanged += new System.EventHandler(this.Format_TextChanged);
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Location = new System.Drawing.Point(608, 76);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(39, 13);
            this.formatLabel.TabIndex = 12;
            this.formatLabel.Text = "Format";
            // 
            // formatHelpBox
            // 
            this.formatHelpBox.BackColor = System.Drawing.SystemColors.Window;
            this.formatHelpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formatHelpBox.FormattingEnabled = true;
            this.formatHelpBox.Items.AddRange(new object[] {
            "%0 Class Name",
            "%1 Position",
            "%2 Direction",
            "%3 Init",
            "%4 Has Init (bool: has init = true, no init = false)",
            "%5 Comma (Applies to all entries but last)"});
            this.formatHelpBox.Location = new System.Drawing.Point(325, 67);
            this.formatHelpBox.Margin = new System.Windows.Forms.Padding(10);
            this.formatHelpBox.MultiColumn = true;
            this.formatHelpBox.Name = "formatHelpBox";
            this.formatHelpBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.formatHelpBox.Size = new System.Drawing.Size(246, 78);
            this.formatHelpBox.TabIndex = 13;
            // 
            // discardUnitsCheckBox
            // 
            this.discardUnitsCheckBox.AutoSize = true;
            this.discardUnitsCheckBox.Location = new System.Drawing.Point(903, 579);
            this.discardUnitsCheckBox.Name = "discardUnitsCheckBox";
            this.discardUnitsCheckBox.Size = new System.Drawing.Size(89, 17);
            this.discardUnitsCheckBox.TabIndex = 14;
            this.discardUnitsCheckBox.Text = "Discard Units";
            this.discardUnitsCheckBox.UseVisualStyleBackColor = true;
            this.discardUnitsCheckBox.CheckedChanged += new System.EventHandler(this.DiscardUnits_CheckedChanged);
            // 
            // discardVehiclesCheckBox
            // 
            this.discardVehiclesCheckBox.AutoSize = true;
            this.discardVehiclesCheckBox.Location = new System.Drawing.Point(903, 602);
            this.discardVehiclesCheckBox.Name = "discardVehiclesCheckBox";
            this.discardVehiclesCheckBox.Size = new System.Drawing.Size(105, 17);
            this.discardVehiclesCheckBox.TabIndex = 15;
            this.discardVehiclesCheckBox.Text = "Discard Vehicles";
            this.discardVehiclesCheckBox.UseVisualStyleBackColor = true;
            this.discardVehiclesCheckBox.CheckedChanged += new System.EventHandler(this.DiscardVehicles_CheckedChanged);
            // 
            // prefixLineInputBox
            // 
            this.prefixLineInputBox.Location = new System.Drawing.Point(653, 99);
            this.prefixLineInputBox.Name = "prefixLineInputBox";
            this.prefixLineInputBox.Size = new System.Drawing.Size(355, 20);
            this.prefixLineInputBox.TabIndex = 16;
            this.prefixLineInputBox.TextChanged += new System.EventHandler(this.PrefixLine_TextChanged);
            // 
            // suffixLineInputBox
            // 
            this.suffixLineInputBox.Location = new System.Drawing.Point(653, 125);
            this.suffixLineInputBox.Name = "suffixLineInputBox";
            this.suffixLineInputBox.Size = new System.Drawing.Size(355, 20);
            this.suffixLineInputBox.TabIndex = 17;
            this.suffixLineInputBox.TextChanged += new System.EventHandler(this.SuffixLine_TextChanged);
            // 
            // prefixLineLabel
            // 
            this.prefixLineLabel.AutoSize = true;
            this.prefixLineLabel.Location = new System.Drawing.Point(591, 100);
            this.prefixLineLabel.Name = "prefixLineLabel";
            this.prefixLineLabel.Size = new System.Drawing.Size(56, 13);
            this.prefixLineLabel.TabIndex = 18;
            this.prefixLineLabel.Text = "Prefix Line";
            // 
            // suffixLineLabel
            // 
            this.suffixLineLabel.AutoSize = true;
            this.suffixLineLabel.Location = new System.Drawing.Point(591, 128);
            this.suffixLineLabel.Name = "suffixLineLabel";
            this.suffixLineLabel.Size = new System.Drawing.Size(56, 13);
            this.suffixLineLabel.TabIndex = 19;
            this.suffixLineLabel.Text = "Suffix Line";
            // 
            // indentsLabel
            // 
            this.indentsLabel.AutoSize = true;
            this.indentsLabel.Location = new System.Drawing.Point(894, 75);
            this.indentsLabel.Name = "indentsLabel";
            this.indentsLabel.Size = new System.Drawing.Size(65, 13);
            this.indentsLabel.TabIndex = 21;
            this.indentsLabel.Text = "Indentations";
            // 
            // indentsNumBox
            // 
            this.indentsNumBox.Location = new System.Drawing.Point(965, 73);
            this.indentsNumBox.Name = "indentsNumBox";
            this.indentsNumBox.Size = new System.Drawing.Size(43, 20);
            this.indentsNumBox.TabIndex = 22;
            this.indentsNumBox.ValueChanged += new System.EventHandler(this.Indents_ValueChanged);
            // 
            // relativeXLabel
            // 
            this.relativeXLabel.AutoSize = true;
            this.relativeXLabel.Location = new System.Drawing.Point(610, 607);
            this.relativeXLabel.Name = "relativeXLabel";
            this.relativeXLabel.Size = new System.Drawing.Size(14, 13);
            this.relativeXLabel.TabIndex = 24;
            this.relativeXLabel.Text = "X";
            // 
            // relativeYLabel
            // 
            this.relativeYLabel.AutoSize = true;
            this.relativeYLabel.Location = new System.Drawing.Point(709, 607);
            this.relativeYLabel.Name = "relativeYLabel";
            this.relativeYLabel.Size = new System.Drawing.Size(14, 13);
            this.relativeYLabel.TabIndex = 26;
            this.relativeYLabel.Text = "Y";
            // 
            // relativeZLabel
            // 
            this.relativeZLabel.AutoSize = true;
            this.relativeZLabel.Location = new System.Drawing.Point(803, 607);
            this.relativeZLabel.Name = "relativeZLabel";
            this.relativeZLabel.Size = new System.Drawing.Size(14, 13);
            this.relativeZLabel.TabIndex = 28;
            this.relativeZLabel.Text = "Z";
            // 
            // relativePosCheckBox
            // 
            this.relativePosCheckBox.AutoSize = true;
            this.relativePosCheckBox.Location = new System.Drawing.Point(611, 578);
            this.relativePosCheckBox.Name = "relativePosCheckBox";
            this.relativePosCheckBox.Size = new System.Drawing.Size(126, 17);
            this.relativePosCheckBox.TabIndex = 29;
            this.relativePosCheckBox.Text = "Positions Relative To";
            this.relativePosCheckBox.UseVisualStyleBackColor = true;
            this.relativePosCheckBox.CheckedChanged += new System.EventHandler(this.RelativePos_CheckedChanged);
            // 
            // relativeXNumeric
            // 
            this.relativeXNumeric.DecimalPlaces = 5;
            this.relativeXNumeric.Location = new System.Drawing.Point(630, 604);
            this.relativeXNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.relativeXNumeric.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.relativeXNumeric.Name = "relativeXNumeric";
            this.relativeXNumeric.Size = new System.Drawing.Size(64, 20);
            this.relativeXNumeric.TabIndex = 30;
            this.relativeXNumeric.ValueChanged += new System.EventHandler(this.RelativeX_ValueChanged);
            // 
            // relativeYNumeric
            // 
            this.relativeYNumeric.DecimalPlaces = 5;
            this.relativeYNumeric.Location = new System.Drawing.Point(729, 604);
            this.relativeYNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.relativeYNumeric.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.relativeYNumeric.Name = "relativeYNumeric";
            this.relativeYNumeric.Size = new System.Drawing.Size(64, 20);
            this.relativeYNumeric.TabIndex = 31;
            this.relativeYNumeric.ValueChanged += new System.EventHandler(this.RelativeY_ValueChanged);
            // 
            // relativeZNumeric
            // 
            this.relativeZNumeric.DecimalPlaces = 5;
            this.relativeZNumeric.Location = new System.Drawing.Point(823, 604);
            this.relativeZNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.relativeZNumeric.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.relativeZNumeric.Name = "relativeZNumeric";
            this.relativeZNumeric.Size = new System.Drawing.Size(64, 20);
            this.relativeZNumeric.TabIndex = 32;
            this.relativeZNumeric.ValueChanged += new System.EventHandler(this.RelativeZ_ValueChanged);
            // 
            // SQFMMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 670);
            this.Controls.Add(this.relativeZNumeric);
            this.Controls.Add(this.relativeYNumeric);
            this.Controls.Add(this.relativeXNumeric);
            this.Controls.Add(this.relativePosCheckBox);
            this.Controls.Add(this.relativeZLabel);
            this.Controls.Add(this.relativeYLabel);
            this.Controls.Add(this.relativeXLabel);
            this.Controls.Add(this.indentsNumBox);
            this.Controls.Add(this.indentsLabel);
            this.Controls.Add(this.suffixLineLabel);
            this.Controls.Add(this.prefixLineLabel);
            this.Controls.Add(this.suffixLineInputBox);
            this.Controls.Add(this.prefixLineInputBox);
            this.Controls.Add(this.discardVehiclesCheckBox);
            this.Controls.Add(this.discardUnitsCheckBox);
            this.Controls.Add(this.formatHelpBox);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.formatInputBox);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SQFMMForm";
            this.Text = "SQF Mission Manager";
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeXNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeYNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relativeZNumeric)).EndInit();
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
        private System.Windows.Forms.TextBox formatInputBox;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.ListBox formatHelpBox;
        private System.Windows.Forms.ToolTip sortByClassToolTip;
        private System.Windows.Forms.ToolTip replaceClassnamesToolTip;
        private System.Windows.Forms.ToolTip loadFileToolTip;
        private System.Windows.Forms.ToolTip saveFileToolTip;
        private System.Windows.Forms.CheckBox discardUnitsCheckBox;
        private System.Windows.Forms.CheckBox discardVehiclesCheckBox;
        private System.Windows.Forms.TextBox prefixLineInputBox;
        private System.Windows.Forms.TextBox suffixLineInputBox;
        private System.Windows.Forms.Label prefixLineLabel;
        private System.Windows.Forms.Label suffixLineLabel;
        private System.Windows.Forms.Label indentsLabel;
        private System.Windows.Forms.NumericUpDown indentsNumBox;
        private System.Windows.Forms.Label relativeXLabel;
        private System.Windows.Forms.Label relativeYLabel;
        private System.Windows.Forms.Label relativeZLabel;
        private System.Windows.Forms.CheckBox relativePosCheckBox;
        private System.Windows.Forms.NumericUpDown relativeXNumeric;
        private System.Windows.Forms.NumericUpDown relativeYNumeric;
        private System.Windows.Forms.NumericUpDown relativeZNumeric;
    }
}

