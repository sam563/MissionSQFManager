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
            this.objectCounter = new System.Windows.Forms.Label();
            this.previewModeDropDown = new System.Windows.Forms.ComboBox();
            this.outputFormatDropDown = new System.Windows.Forms.ComboBox();
            this.previewModeLabel = new System.Windows.Forms.Label();
            this.outputFormatLabel = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.saveOutputButton = new System.Windows.Forms.Button();
            this.sortByNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.replaceClassnamesCheckBox = new System.Windows.Forms.CheckBox();
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
            this.relativePosCheckBox = new System.Windows.Forms.CheckBox();
            this.objectPerLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.prefixCheckBox = new System.Windows.Forms.CheckBox();
            this.suffixCheckBox = new System.Windows.Forms.CheckBox();
            this.relativePosition = new System.Windows.Forms.TextBox();
            this.objectsList = new System.Windows.Forms.ListBox();
            this.presetDropDown = new System.Windows.Forms.ComboBox();
            this.presetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openFileButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFileButton.Location = new System.Drawing.Point(75, 571);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(99, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Load from file";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // objectCounter
            // 
            this.objectCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.objectCounter.AutoSize = true;
            this.objectCounter.Location = new System.Drawing.Point(72, 87);
            this.objectCounter.Name = "objectCounter";
            this.objectCounter.Size = new System.Drawing.Size(102, 13);
            this.objectCounter.TabIndex = 2;
            this.objectCounter.Text = "No objects loaded...";
            // 
            // previewModeDropDown
            // 
            this.previewModeDropDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previewModeDropDown.FormattingEnabled = true;
            this.previewModeDropDown.Items.AddRange(new object[] {
            "Output Preview",
            "Raw Object Data"});
            this.previewModeDropDown.Location = new System.Drawing.Point(171, 620);
            this.previewModeDropDown.Name = "previewModeDropDown";
            this.previewModeDropDown.Size = new System.Drawing.Size(121, 21);
            this.previewModeDropDown.TabIndex = 3;
            this.previewModeDropDown.SelectedIndexChanged += new System.EventHandler(this.PreviewMode_SelectedIndexChanged);
            // 
            // outputFormatDropDown
            // 
            this.outputFormatDropDown.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.outputFormatDropDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.outputFormatDropDown.FormattingEnabled = true;
            this.outputFormatDropDown.Items.AddRange(new object[] {
            "Formatted SQF",
            "Biedi",
            "SQM"});
            this.outputFormatDropDown.Location = new System.Drawing.Point(152, 117);
            this.outputFormatDropDown.Name = "outputFormatDropDown";
            this.outputFormatDropDown.Size = new System.Drawing.Size(142, 21);
            this.outputFormatDropDown.TabIndex = 4;
            this.outputFormatDropDown.SelectedIndexChanged += new System.EventHandler(this.OutputFormat_SelectedIndexChanged);
            // 
            // previewModeLabel
            // 
            this.previewModeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previewModeLabel.AutoSize = true;
            this.previewModeLabel.Location = new System.Drawing.Point(90, 623);
            this.previewModeLabel.Name = "previewModeLabel";
            this.previewModeLabel.Size = new System.Drawing.Size(75, 13);
            this.previewModeLabel.TabIndex = 5;
            this.previewModeLabel.Text = "Preview Mode";
            // 
            // outputFormatLabel
            // 
            this.outputFormatLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.outputFormatLabel.AutoSize = true;
            this.outputFormatLabel.Location = new System.Drawing.Point(71, 122);
            this.outputFormatLabel.Name = "outputFormatLabel";
            this.outputFormatLabel.Size = new System.Drawing.Size(74, 13);
            this.outputFormatLabel.TabIndex = 6;
            this.outputFormatLabel.Text = "Output Format";
            // 
            // fileName
            // 
            this.fileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(72, 64);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(73, 15);
            this.fileName.TabIndex = 7;
            this.fileName.Text = "File Name";
            // 
            // saveOutputButton
            // 
            this.saveOutputButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveOutputButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveOutputButton.Enabled = false;
            this.saveOutputButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveOutputButton.Location = new System.Drawing.Point(193, 571);
            this.saveOutputButton.Name = "saveOutputButton";
            this.saveOutputButton.Size = new System.Drawing.Size(99, 23);
            this.saveOutputButton.TabIndex = 8;
            this.saveOutputButton.Text = "Save Output";
            this.saveOutputButton.UseVisualStyleBackColor = false;
            this.saveOutputButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // sortByNamesCheckBox
            // 
            this.sortByNamesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sortByNamesCheckBox.AutoSize = true;
            this.sortByNamesCheckBox.Location = new System.Drawing.Point(319, 577);
            this.sortByNamesCheckBox.Name = "sortByNamesCheckBox";
            this.sortByNamesCheckBox.Size = new System.Drawing.Size(126, 17);
            this.sortByNamesCheckBox.TabIndex = 9;
            this.sortByNamesCheckBox.Text = "Order By Class Name";
            this.sortByNamesCheckBox.UseVisualStyleBackColor = true;
            this.sortByNamesCheckBox.CheckedChanged += new System.EventHandler(this.SortByNames_CheckedChanged);
            // 
            // replaceClassnamesCheckBox
            // 
            this.replaceClassnamesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.replaceClassnamesCheckBox.AutoSize = true;
            this.replaceClassnamesCheckBox.Location = new System.Drawing.Point(319, 601);
            this.replaceClassnamesCheckBox.Name = "replaceClassnamesCheckBox";
            this.replaceClassnamesCheckBox.Size = new System.Drawing.Size(189, 17);
            this.replaceClassnamesCheckBox.TabIndex = 10;
            this.replaceClassnamesCheckBox.Text = "Replace Class Names From Config";
            this.replaceClassnamesCheckBox.UseVisualStyleBackColor = true;
            this.replaceClassnamesCheckBox.CheckedChanged += new System.EventHandler(this.ReplaceNames_CheckedChanged);
            // 
            // formatInputBox
            // 
            this.formatInputBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formatInputBox.Location = new System.Drawing.Point(619, 70);
            this.formatInputBox.Name = "formatInputBox";
            this.formatInputBox.Size = new System.Drawing.Size(226, 20);
            this.formatInputBox.TabIndex = 11;
            this.formatInputBox.TextChanged += new System.EventHandler(this.Format_TextChanged);
            // 
            // formatLabel
            // 
            this.formatLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formatLabel.AutoSize = true;
            this.formatLabel.Location = new System.Drawing.Point(574, 73);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(39, 13);
            this.formatLabel.TabIndex = 12;
            this.formatLabel.Text = "Format";
            // 
            // formatHelpBox
            // 
            this.formatHelpBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formatHelpBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.formatHelpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formatHelpBox.FormattingEnabled = true;
            this.formatHelpBox.Items.AddRange(new object[] {
            "%0 Class Name",
            "%1 Position",
            "%2 Direction",
            "%3 Init",
            "%4 Has Init (bool: has init = true, no init = false)",
            "%5 Comma (Applies to all entries but last)"});
            this.formatHelpBox.Location = new System.Drawing.Point(310, 60);
            this.formatHelpBox.Margin = new System.Windows.Forms.Padding(10);
            this.formatHelpBox.MultiColumn = true;
            this.formatHelpBox.Name = "formatHelpBox";
            this.formatHelpBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.formatHelpBox.Size = new System.Drawing.Size(237, 78);
            this.formatHelpBox.TabIndex = 13;
            // 
            // discardUnitsCheckBox
            // 
            this.discardUnitsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.discardUnitsCheckBox.AutoSize = true;
            this.discardUnitsCheckBox.Location = new System.Drawing.Point(869, 576);
            this.discardUnitsCheckBox.Name = "discardUnitsCheckBox";
            this.discardUnitsCheckBox.Size = new System.Drawing.Size(89, 17);
            this.discardUnitsCheckBox.TabIndex = 14;
            this.discardUnitsCheckBox.Text = "Discard Units";
            this.discardUnitsCheckBox.UseVisualStyleBackColor = true;
            this.discardUnitsCheckBox.CheckedChanged += new System.EventHandler(this.DiscardUnits_CheckedChanged);
            // 
            // discardVehiclesCheckBox
            // 
            this.discardVehiclesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.discardVehiclesCheckBox.AutoSize = true;
            this.discardVehiclesCheckBox.Location = new System.Drawing.Point(869, 599);
            this.discardVehiclesCheckBox.Name = "discardVehiclesCheckBox";
            this.discardVehiclesCheckBox.Size = new System.Drawing.Size(105, 17);
            this.discardVehiclesCheckBox.TabIndex = 15;
            this.discardVehiclesCheckBox.Text = "Discard Vehicles";
            this.discardVehiclesCheckBox.UseVisualStyleBackColor = true;
            this.discardVehiclesCheckBox.CheckedChanged += new System.EventHandler(this.DiscardVehicles_CheckedChanged);
            // 
            // prefixLineInputBox
            // 
            this.prefixLineInputBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prefixLineInputBox.Location = new System.Drawing.Point(619, 96);
            this.prefixLineInputBox.Name = "prefixLineInputBox";
            this.prefixLineInputBox.Size = new System.Drawing.Size(323, 20);
            this.prefixLineInputBox.TabIndex = 16;
            this.prefixLineInputBox.TextChanged += new System.EventHandler(this.PrefixLine_TextChanged);
            // 
            // suffixLineInputBox
            // 
            this.suffixLineInputBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suffixLineInputBox.Location = new System.Drawing.Point(619, 122);
            this.suffixLineInputBox.Name = "suffixLineInputBox";
            this.suffixLineInputBox.Size = new System.Drawing.Size(323, 20);
            this.suffixLineInputBox.TabIndex = 17;
            this.suffixLineInputBox.TextChanged += new System.EventHandler(this.SuffixLine_TextChanged);
            // 
            // prefixLineLabel
            // 
            this.prefixLineLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prefixLineLabel.AutoSize = true;
            this.prefixLineLabel.Location = new System.Drawing.Point(557, 97);
            this.prefixLineLabel.Name = "prefixLineLabel";
            this.prefixLineLabel.Size = new System.Drawing.Size(56, 13);
            this.prefixLineLabel.TabIndex = 18;
            this.prefixLineLabel.Text = "Prefix Line";
            // 
            // suffixLineLabel
            // 
            this.suffixLineLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suffixLineLabel.AutoSize = true;
            this.suffixLineLabel.Location = new System.Drawing.Point(557, 125);
            this.suffixLineLabel.Name = "suffixLineLabel";
            this.suffixLineLabel.Size = new System.Drawing.Size(56, 13);
            this.suffixLineLabel.TabIndex = 19;
            this.suffixLineLabel.Text = "Suffix Line";
            // 
            // indentsLabel
            // 
            this.indentsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.indentsLabel.AutoSize = true;
            this.indentsLabel.Location = new System.Drawing.Point(860, 72);
            this.indentsLabel.Name = "indentsLabel";
            this.indentsLabel.Size = new System.Drawing.Size(65, 13);
            this.indentsLabel.TabIndex = 21;
            this.indentsLabel.Text = "Indentations";
            // 
            // indentsNumBox
            // 
            this.indentsNumBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.indentsNumBox.Location = new System.Drawing.Point(931, 70);
            this.indentsNumBox.Name = "indentsNumBox";
            this.indentsNumBox.Size = new System.Drawing.Size(43, 20);
            this.indentsNumBox.TabIndex = 22;
            this.indentsNumBox.ValueChanged += new System.EventHandler(this.Indents_ValueChanged);
            // 
            // relativePosCheckBox
            // 
            this.relativePosCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.relativePosCheckBox.AutoSize = true;
            this.relativePosCheckBox.Location = new System.Drawing.Point(542, 574);
            this.relativePosCheckBox.Name = "relativePosCheckBox";
            this.relativePosCheckBox.Size = new System.Drawing.Size(126, 17);
            this.relativePosCheckBox.TabIndex = 29;
            this.relativePosCheckBox.Text = "Positions Relative To";
            this.relativePosCheckBox.UseVisualStyleBackColor = true;
            this.relativePosCheckBox.CheckedChanged += new System.EventHandler(this.RelativePos_CheckedChanged);
            // 
            // objectPerLinesCheckBox
            // 
            this.objectPerLinesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.objectPerLinesCheckBox.AutoSize = true;
            this.objectPerLinesCheckBox.Checked = true;
            this.objectPerLinesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectPerLinesCheckBox.Location = new System.Drawing.Point(875, 33);
            this.objectPerLinesCheckBox.Name = "objectPerLinesCheckBox";
            this.objectPerLinesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.objectPerLinesCheckBox.Size = new System.Drawing.Size(99, 17);
            this.objectPerLinesCheckBox.TabIndex = 33;
            this.objectPerLinesCheckBox.Text = "Object Per Line";
            this.objectPerLinesCheckBox.UseVisualStyleBackColor = true;
            this.objectPerLinesCheckBox.Visible = false;
            this.objectPerLinesCheckBox.CheckedChanged += new System.EventHandler(this.ObjectPerLines_CheckedChanged);
            // 
            // prefixCheckBox
            // 
            this.prefixCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prefixCheckBox.AutoSize = true;
            this.prefixCheckBox.Checked = true;
            this.prefixCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.prefixCheckBox.Location = new System.Drawing.Point(949, 97);
            this.prefixCheckBox.Name = "prefixCheckBox";
            this.prefixCheckBox.Size = new System.Drawing.Size(15, 14);
            this.prefixCheckBox.TabIndex = 34;
            this.prefixCheckBox.UseVisualStyleBackColor = true;
            this.prefixCheckBox.CheckedChanged += new System.EventHandler(this.Prefix_CheckedChanged);
            // 
            // suffixCheckBox
            // 
            this.suffixCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suffixCheckBox.AutoSize = true;
            this.suffixCheckBox.Checked = true;
            this.suffixCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.suffixCheckBox.Location = new System.Drawing.Point(949, 125);
            this.suffixCheckBox.Name = "suffixCheckBox";
            this.suffixCheckBox.Size = new System.Drawing.Size(15, 14);
            this.suffixCheckBox.TabIndex = 35;
            this.suffixCheckBox.UseVisualStyleBackColor = true;
            this.suffixCheckBox.CheckedChanged += new System.EventHandler(this.Suffix_CheckedChanged);
            // 
            // relativePosition
            // 
            this.relativePosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.relativePosition.Location = new System.Drawing.Point(542, 599);
            this.relativePosition.Name = "relativePosition";
            this.relativePosition.Size = new System.Drawing.Size(226, 20);
            this.relativePosition.TabIndex = 36;
            this.relativePosition.TextChanged += new System.EventHandler(this.RelativePosition_TextChanged);
            // 
            // objectsList
            // 
            this.objectsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.objectsList.FormattingEnabled = true;
            this.objectsList.HorizontalScrollbar = true;
            this.objectsList.Location = new System.Drawing.Point(75, 149);
            this.objectsList.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.objectsList.Name = "objectsList";
            this.objectsList.Size = new System.Drawing.Size(899, 407);
            this.objectsList.TabIndex = 1;
            // 
            // presetDropDown
            // 
            this.presetDropDown.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.presetDropDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.presetDropDown.FormattingEnabled = true;
            this.presetDropDown.Location = new System.Drawing.Point(703, 31);
            this.presetDropDown.Name = "presetDropDown";
            this.presetDropDown.Size = new System.Drawing.Size(142, 21);
            this.presetDropDown.TabIndex = 37;
            this.presetDropDown.SelectedIndexChanged += new System.EventHandler(this.Preset_SelectedIndexChanged);
            // 
            // presetLabel
            // 
            this.presetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.presetLabel.AutoSize = true;
            this.presetLabel.Location = new System.Drawing.Point(658, 33);
            this.presetLabel.Name = "presetLabel";
            this.presetLabel.Size = new System.Drawing.Size(37, 13);
            this.presetLabel.TabIndex = 38;
            this.presetLabel.Text = "Preset";
            // 
            // SQFMMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1051, 670);
            this.Controls.Add(this.presetLabel);
            this.Controls.Add(this.presetDropDown);
            this.Controls.Add(this.relativePosition);
            this.Controls.Add(this.suffixCheckBox);
            this.Controls.Add(this.prefixCheckBox);
            this.Controls.Add(this.objectPerLinesCheckBox);
            this.Controls.Add(this.relativePosCheckBox);
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
            this.Controls.Add(this.replaceClassnamesCheckBox);
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
            this.MinimumSize = new System.Drawing.Size(1000, 675);
            this.Name = "SQFMMForm";
            this.Text = "SQF Mission Manager";
            ((System.ComponentModel.ISupportInitialize)(this.indentsNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label objectCounter;
        private System.Windows.Forms.ComboBox previewModeDropDown;
        private System.Windows.Forms.ComboBox outputFormatDropDown;
        private System.Windows.Forms.Label previewModeLabel;
        private System.Windows.Forms.Label outputFormatLabel;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Button saveOutputButton;
        private System.Windows.Forms.CheckBox sortByNamesCheckBox;
        private System.Windows.Forms.CheckBox replaceClassnamesCheckBox;
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
        private System.Windows.Forms.CheckBox relativePosCheckBox;
        private System.Windows.Forms.CheckBox objectPerLinesCheckBox;
        private System.Windows.Forms.CheckBox prefixCheckBox;
        private System.Windows.Forms.CheckBox suffixCheckBox;
        private System.Windows.Forms.TextBox relativePosition;
        private System.Windows.Forms.ListBox objectsList;
        private System.Windows.Forms.ComboBox presetDropDown;
        private System.Windows.Forms.Label presetLabel;
    }
}

