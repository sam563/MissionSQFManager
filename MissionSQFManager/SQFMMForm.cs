using System;
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

            sortByClassToolTip.SetToolTip(sortByNamesCheckBox, "Orders objects by their classname alphanumerically.");
            replaceClassnamesToolTip.SetToolTip(replaceClassnames, "Replaces all classnames as defined in config. (Primarily for replacing MAP objects with their lootable counterparts)");
            loadFileToolTip.SetToolTip(openFileButton, "Load Arma generated .sqf mission file for the program to read from.");
            saveFileToolTip.SetToolTip(saveOutputButton, "Save generated output in the selected format.");
        }

        private void UpdatePreviewer(GameObject[] gameObjects)
        {
            bool isFormattedSQF = (outputFormatDropDown.SelectedIndex == 0);
            formatInputBox.Enabled = isFormattedSQF;
            formatHelpBox.Visible = isFormattedSQF;

            objectsList.Items.Clear();

            bool isValid = (gameObjects != null && gameObjects.Length > 0);

            saveOutputButton.Enabled = isValid;

            if (!isValid)
            {
                fileName.Text = "No file loaded";
                objectCounter.Text = "No objects loaded";
                return;
            }

            if (previewModeDropDown.SelectedIndex == 0)
            {
                //Formatted object data
                objectsList.Items.AddRange(GOToLines(gameObjects));
            }
            else
            {
                //Raw object data
                objectsList.Items.AddRange(SQFToGOConverter.GameObjects);
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

            UpdatePreviewer(gameObjects);
        }

        private void SaveButton_Click(object sender, EventArgs e)
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

            saveFileDialog.Dispose();
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

            if (discardUnitsCheckBox.Checked || discardVehiclesCheckBox.Checked)
            {
                var filtered = new List<GameObject>();

                for (int i = 0; i < objList.Count; i++)
                {
                    GameObject go = objList[i];
                    bool isUnit = (go.type == GameObject.Type.Unit);
                    bool isVehicle = (go.type == GameObject.Type.Vehicle);

                    if (isUnit && !discardUnitsCheckBox.Checked) filtered.Add(go);
                    if (isVehicle && !discardVehiclesCheckBox.Checked) filtered.Add(go);
                }

                objList = filtered;
            }

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

        private void SortByNamesCheckBox_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void ReplaceNames_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void FormatInputBox_TextChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void DiscardUnitsCheckBox_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);

        private void DiscardVehiclesCheckBox_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer(SQFToGOConverter.GameObjects);
    }
}
