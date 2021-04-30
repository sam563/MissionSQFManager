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

            //Load presets from config
            if (Utils.GetElementFromConfig("Format", out string format)) formatInputBox.Text = format;
            if (Utils.GetElementFromConfig("Prefix", out string prefix)) prefixLineInputBox.Text = prefix;
            if (Utils.GetElementFromConfig("Suffix", out string suffix)) suffixLineInputBox.Text = suffix;
            if (Utils.GetElementFromConfig("Indents", out string indents) && int.TryParse(indents, out int intdent)) indentsNumBox.Value = intdent;

            //Set default values for drop downs
            previewModeDropDown.Text = previewModeDropDown.Items[0].ToString();
            outputFormatDropDown.Text = outputFormatDropDown.Items[0].ToString();

            //Make sure relative pos input fields reflect checkbox state on startup
            SetRelativeInputFieldsEnabled();

            //Tool tips
            sortByClassToolTip.SetToolTip(sortByNamesCheckBox, "Orders objects by their classname alphanumerically.");
            replaceClassnamesToolTip.SetToolTip(replaceClassnames, "Replaces all classnames as defined in config. (Primarily for replacing MAP objects with their lootable counterparts)");
            loadFileToolTip.SetToolTip(openFileButton, "Load Arma generated .sqf mission file for the program to read from.");
            saveFileToolTip.SetToolTip(saveOutputButton, "Save generated output in the selected format.");
        }

        private void UpdatePreviewer()
        {
            var gameObjects = SQFToGOConverter.GameObjects;

            bool isFormattedSQF = (outputFormatDropDown.SelectedIndex == 0);
            formatInputBox.Enabled = isFormattedSQF;
            indentsNumBox.Enabled = isFormattedSQF;
            objectPerLinesCheckBox.Enabled = isFormattedSQF;
            prefixCheckBox.Enabled = isFormattedSQF;
            suffixCheckBox.Enabled = isFormattedSQF;

            prefixLineInputBox.Enabled = isFormattedSQF && prefixCheckBox.Checked;
            suffixLineInputBox.Enabled = isFormattedSQF && suffixCheckBox.Checked;

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
                var output = GOToOutput(gameObjects);
                if (output == null) return;
                objectsList.Items.AddRange(GOToOutput(gameObjects));
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

            SQFToGOConverter.SQFToGameObjects(fileContent);

            UpdatePreviewer();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (SQFToGOConverter.GameObjects == null) return;

            var lines = GOToOutput(SQFToGOConverter.GameObjects, out string extention);

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

        private string[] GOToOutput(GameObject[] gameObjects) => GOToOutput(gameObjects, out string _);

        private string[] GOToOutput(GameObject[] gameObjects, out string extention)
        {
            extention = string.Empty;
            if (gameObjects == null) return null;

            string[] lines;

            //Replace classnames from config file
            if (replaceClassnames.Checked)
            {
                gameObjects = GOClassNameReplacer.ReplaceClassnamesFromConfig(gameObjects);
            }

            var objList = gameObjects.ToList();

            //Convert to relative positions
            if (relativePosCheckBox.Checked)
            {
                for (int i = 0; i < objList.Count; i++)
                {
                    var go = GameObject.Copy(objList[i]);
                    go.position -= new Vector3((float)relativeXNumeric.Value, (float)relativeYNumeric.Value, (float)relativeZNumeric.Value);
                    objList[i] = go;
                }
            }

            //Discard units or vehicles
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

            //Sort by classname
            if (sortByNamesCheckBox.Checked)
            {
                objList.Sort((x, y) => string.Compare(x.className, y.className));
            }

            //Get output lines for correct format
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
                    string prefix = prefixCheckBox.Checked ? prefixLineInputBox.Text : "";
                    string suffix = suffixCheckBox.Checked ? suffixLineInputBox.Text : "";
                    lines = GOToFormattedSQF.FormatGameObjects(objList.ToArray(), formatInputBox.Text, (int)indentsNumBox.Value, prefix, suffix);
                    if (!objectPerLinesCheckBox.Checked) lines = new string[] { string.Join(null, lines) };
                    extention = ".sqf";
                    break;
            }

            return lines;
        }

        private void SetRelativeInputFieldsEnabled()
        {
            bool enabled = relativePosCheckBox.Checked;
            relativeXNumeric.Enabled = enabled;
            relativeYNumeric.Enabled = enabled;
            relativeZNumeric.Enabled = enabled;
        }

        private void PreviewMode_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void OutputFormat_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void SortByNames_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void ReplaceNames_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void Format_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void DiscardUnits_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();
        private void DiscardVehicles_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void SuffixLine_TextChanged(object sender, EventArgs e) => UpdatePreviewer();
        private void PrefixLine_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void Indents_ValueChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void RelativePos_CheckedChanged(object sender, EventArgs e)
        {
            SetRelativeInputFieldsEnabled();
            UpdatePreviewer();
        }

        private void RelativeX_ValueChanged(object sender, EventArgs e) => UpdatePreviewer();
        private void RelativeY_ValueChanged(object sender, EventArgs e) => UpdatePreviewer();
        private void RelativeZ_ValueChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void ObjectPerLines_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void Prefix_CheckedChanged(object sender, EventArgs e)  => UpdatePreviewer();

        private void Suffix_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();
    }
}
