namespace MissionSQFManager
{
    partial class ArrayObjectsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.classnameText = new System.Windows.Forms.Label();
            this.arrayObjectsButton = new System.Windows.Forms.Button();
            this.mapDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Copies all loaded objects relative to position of the selected object for each in" +
    "stance of the classname in the selected map.";
            // 
            // classnameText
            // 
            this.classnameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classnameText.AutoSize = true;
            this.classnameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classnameText.Location = new System.Drawing.Point(46, 22);
            this.classnameText.Name = "classnameText";
            this.classnameText.Size = new System.Drawing.Size(81, 13);
            this.classnameText.TabIndex = 49;
            this.classnameText.Text = "CLASSNAME";
            // 
            // arrayObjectsButton
            // 
            this.arrayObjectsButton.Location = new System.Drawing.Point(50, 84);
            this.arrayObjectsButton.Name = "arrayObjectsButton";
            this.arrayObjectsButton.Size = new System.Drawing.Size(102, 23);
            this.arrayObjectsButton.TabIndex = 50;
            this.arrayObjectsButton.Text = "Array Objects";
            this.arrayObjectsButton.UseVisualStyleBackColor = true;
            this.arrayObjectsButton.Click += new System.EventHandler(this.ArrayObjectsButton_Click);
            // 
            // mapDropDown
            // 
            this.mapDropDown.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.mapDropDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mapDropDown.FormattingEnabled = true;
            this.mapDropDown.Location = new System.Drawing.Point(189, 86);
            this.mapDropDown.Name = "mapDropDown";
            this.mapDropDown.Size = new System.Drawing.Size(142, 21);
            this.mapDropDown.TabIndex = 51;
            // 
            // ArrayObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mapDropDown);
            this.Controls.Add(this.arrayObjectsButton);
            this.Controls.Add(this.classnameText);
            this.Controls.Add(this.label1);
            this.Name = "ArrayObjectsForm";
            this.Text = "Array Objects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label classnameText;
        private System.Windows.Forms.Button arrayObjectsButton;
        private System.Windows.Forms.ComboBox mapDropDown;
    }
}