﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MissionSQFManager
{
    public partial class SQFMMForm : Form
    {
        public SQFMMForm()
        {
            InitializeComponent();

            previewModeDropDown.Text = previewModeDropDown.Items[0].ToString();
            outputFormatDropDown.Text = outputFormatDropDown.Items[0].ToString();

            if (GOToFormattedSQF.GetFormatFromConfig(out string format)) formatInputBox.Text = format;
        }

        private void UpdatePreviewer(GameObject[] gameObjects)
        {
            bool isFormattedSQF = (outputFormatDropDown.SelectedIndex == 0);
            formatInputBox.Enabled = isFormattedSQF;
            formatHelpBox.Visible = isFormattedSQF;

            if (gameObjects == null || gameObjects.Length <= 0)
            {
                objectCounter.Text = "No objects loaded";
                return;
            }

            objectsList.Items.Clear();
            if (previewModeDropDown.SelectedIndex == 0)
            {
                //Formatted object data
                objectsList.Items.AddRange(GOToLines(gameObjects));
            }
            else
            {
                //Raw object data
                objectsList.Items.AddRange(gameObjects);
            }

            objectCounter.Text = $"{gameObjects.Length} objects loaded";
        }

        private void OpenFileButtonClick(object sender, EventArgs e)
        {
            string fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "sqf files (*.sqf)|*.sqf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    fileName.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }

            var gameObjects = SQFToGOConverter.SQFToGameObjects(fileContent);

            bool isValid = gameObjects.Length > 0;

            UpdatePreviewer(gameObjects);

            objectCounter.Visible = isValid;

            saveOutputButton.Enabled = (gameObjects.Length > 0);
        }

        private string[] GOToLines(GameObject[] gameObjects) => GOToLines(gameObjects, out string _);

        private string[] GOToLines(GameObject[] gameObjects, out string extention)
        {
            extention = string.Empty;
            if (gameObjects == null) return null;

            string[] lines;

            if (replaceClassnames.Checked)
            {
                gameObjects = GOClassNameCorrector.ReplaceClassnamesFromConfig(gameObjects);
            }

            var objList = gameObjects.ToList();
            if (sortByNamesCheckBox.Checked)
            {
                objList.Sort((x, y) => string.Compare(x.className, y.className));
            }

            switch (outputFormatDropDown.SelectedIndex)
            {
                case 1:
                    //Biedi
                    lines = GOToBiediConverter.GOToBiedi(objList.ToArray());
                    extention = ".biedi";
                    break;
                case 2:
                    //SQM
                    lines = GOToSQMConverter.GOToSQM(objList.ToArray());
                    extention = ".sqm";
                    break;
                default:
                    //Formatted SQF
                    lines = GOToFormattedSQF.FormatGameObjects(objList.ToArray(), formatInputBox.Text);
                    extention = ".sqf";
                    break;
            }

            return lines;
        }

        private void PreviewModeDropDown_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void OutputFormatDropDown_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void Button1_Click(object sender, EventArgs e)
        {
            if (SQFToGOConverter.GameObjects == null) return;

            var lines = GOToLines(SQFToGOConverter.GameObjects, out string extention);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = string.Format("{0} files (*{0})|*{0}", extention),
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, lines);
            }
           
        }

        private void SortByNamesCheckBox_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void FormatInputBox_TextChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);
    }
}
