using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace MissionSQFManager
{
    public partial class SQFMMForm : Form
    {
        private GameObject[] gameObjects = null; //Unmodified gameObjects extracted from current loaded file
        private GameObject[] renamedObjects = null; //gameObjects renamed from config
        private Vector3 center = Vector3.zero; //The average position (center) of all current gameObjects

        private bool updateEnabled = true; //Should the object previewer update?

        public SQFMMForm()
        {
            InitializeComponent();

            objectsList.HorizontalScrollbar = false; //Has huge performance impact. Do not enable!!

            bool configExists = InitializePresets();
            missingConfigWarnLabel.Visible = !configExists;

            relativePosition.LostFocus += UpdateRelativePosition;

            //Set default values for drop downs
            previewModeDropDown.Text = previewModeDropDown.Items[0].ToString();
            outputFormatDropDown.Text = outputFormatDropDown.Items[0].ToString();

            if (configExists)
            {
                presetDropDown.Text = presetDropDown.Items[0].ToString();
            }
            else
            {
                presetDropDown.Visible = false;
                presetLabel.Visible = false;
            }

            UpdateFilters();

            //Tool tips
            sortByClassToolTip.SetToolTip(sortByNamesCheckBox, "Orders objects by their classname alphanumerically.");
            replaceClassnamesToolTip.SetToolTip(replaceClassnamesCheckBox, "Replaces all classnames as defined in config. (Primarily for replacing MAP objects with their lootable counterparts)");
            loadFileToolTip.SetToolTip(openFileButton, "Load Arma generated .sqf mission file for the program to read from.");
            saveFileToolTip.SetToolTip(saveOutputButton, "Save generated output in the selected format.");
            relativePosToolTip.SetToolTip(relativePosition, "Sets object positions to be relative to this point.");
        }

        private bool InitializePresets()
        {
            if (!GetConfigPresets(out XmlNode presets)) return false;
            for (int i = 0; i < presets.ChildNodes.Count; i++)
            {
                XmlNode preset = presets.ChildNodes[i];
                presetDropDown.Items.Add(preset.Name);
            }
            return true;
        }

        private void LoadPreset(int index)
        {
            bool foundConfig = GetConfigPresets(out XmlNode presets);

            missingConfigWarnLabel.Visible = !foundConfig;

            if (!foundConfig) return;

            XmlNode preset = presets.ChildNodes[index];

            string GetNodeText(string xpath)
            {
                try 
                {
                    return preset.SelectSingleNode(xpath).InnerText;
                }
                catch
                {
                    if (index > 0)
                    {
                        try
                        {
                            //Try to get from default preset instead
                            return presets.ChildNodes[0].SelectSingleNode(xpath).InnerText;
                        }
                        catch
                        {
                            return string.Empty;
                        }
                    }

                    return string.Empty;
                }
            }

            updateEnabled = false; //Disable previewer updates

            formatInputBox.Text = GetNodeText("Format");
            prefixLineInputBox.Text = GetNodeText("Prefix");
            suffixLineInputBox.Text = GetNodeText("Suffix");
            if (int.TryParse(GetNodeText("Indents"), out int i)) indentsNumBox.Value = i;
            if (bool.TryParse(GetNodeText("ReplaceClassnames"), out bool rc)) replaceClassnamesCheckBox.Checked = rc;
            if (bool.TryParse(GetNodeText("OrderByClassname"), out bool obc)) sortByNamesCheckBox.Checked = obc;
            if (bool.TryParse(GetNodeText("RelativePositions"), out bool rp)) relativePosCheckBox.Checked = rp;
            relativePosition.Enabled = rp;
            if (bool.TryParse(GetNodeText("DiscardObjects"), out bool doj)) discardObjectsCheckBox.Checked = doj;
            if (bool.TryParse(GetNodeText("DiscardUnits"), out bool du)) discardUnitsCheckBox.Checked = du;
            if (bool.TryParse(GetNodeText("DiscardVehicles"), out bool dv)) discardVehiclesCheckBox.Checked = dv;

            updateEnabled = true;
            UpdatePreviewer();
        }

        private bool GetConfigPresets(out XmlNode presets)
        {
            presets = null;
            if (!Utils.GetConfigXML(out XmlDocument doc)) return false;
            presets = doc.SelectSingleNode("/Config/Presets");
            return true;
        }

        private void UpdatePreviewer()
        {
            if (!updateEnabled) return;

            objectsList.Items.Clear();

            bool isValid = (gameObjects != null && gameObjects.Length > 0);
            saveOutputButton.Enabled = isValid;
            copyToClipboardButton.Enabled = isValid;

            if (!isValid)
            {
                objectsList.EndUpdate();
                fileName.Text = "No file loaded";
                objectCounter.Text = "No objects loaded";
                return;
            }

            if (previewModeDropDown.SelectedIndex == 0)
            {
                //Formatted object data
                var output = GOToOutput(gameObjects);
                if (output == null) return;

                objectsList.Items.AddRange(output);
            }
            else
            {
                //Raw object data
                objectsList.Items.AddRange(gameObjects);
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "sqf files (*.sqf)|*.sqf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = string.Empty;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    fileName.Text = Path.GetFileName(openFileDialog.FileName);
                    gameObjects = SQFToGOConverter.SQFToGameObjects(fileContent);
                    HandleGameObjectUpdate(gameObjects);
                }
            }

            UpdatePreviewer();
        }

        private void HandleGameObjectUpdate(GameObject[] gameObjects)
        {
            //Update object counter
            objectCounter.Text = $"{gameObjects.Length} objects loaded";

            //This only needs to be done once when the file is first loaded
            renamedObjects = GOClassNameReplacer.ReplaceClassnamesFromConfig(gameObjects);

            Vector3 center = Vector3.zero;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                //Calculate center pos
                center += (gameObjects[i].position / gameObjects.Length);
            }
            center.z = 0; //Do not average the height

            if (string.IsNullOrEmpty(relativePosition.Text) || relativePosition.Text == this.center.ToString())
            {
                //Only update if the user has not inputted a custom relative pos
                relativePosition.Text = center.ToString();
            }

            this.center = center;

            UpdateFilters();
        }

        private void UpdateFilters()
        {
            int objCount = 0;
            int vehCount = 0;
            int unitCount = 0;

            if (gameObjects != null)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    //Add object type to correct counter
                    switch (gameObjects[i].type)
                    {
                        case GameObject.Type.Unit:
                            unitCount++;
                            break;
                        case GameObject.Type.Vehicle:
                            vehCount++;
                            break;
                        default:
                            objCount++;
                            break;
                    }
                }
            }

            discardObjectsCheckBox.Enabled = (objCount > 0);
            discardVehiclesCheckBox.Enabled = (vehCount > 0);
            discardUnitsCheckBox.Enabled = (unitCount > 0);
        }

        private void UpdateRelativePosition(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(relativePosition.Text)) relativePosition.Text = center.ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (gameObjects == null) return;

            var lines = GOToOutput(gameObjects, out string extention);

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

        private void CopyToClipboard_Click(object sender, EventArgs e)
        {
            string output = string.Empty;

            string[] outputLines = GOToOutput(gameObjects);

            for (int i = 0; i < outputLines.Length; i++)
            {
                output += outputLines[i] + Environment.NewLine;
            }

            Clipboard.SetText(output);
        }

        private string[] GOToOutput(GameObject[] gameObjects) => GOToOutput(gameObjects, out string _);

        private string[] GOToOutput(GameObject[] gameObjects, out string extention)
        {
            extention = string.Empty;
            if (gameObjects == null) return null;

            string[] lines;

            //No need to rename everytime we update
            gameObjects = (replaceClassnamesCheckBox.Checked) ? renamedObjects : gameObjects;

            var objList = gameObjects.ToList();

            //Convert to relative positions
            if (relativePosCheckBox.Checked)
            {
                Vector3.TryParse(relativePosition.Text, out Vector3 relativePos);

                for (int i = 0; i < objList.Count; i++)
                {
                    var go = GameObject.Copy(objList[i]);

                    go.position -= relativePos;
                    objList[i] = go;
                }
            }

            //Filter out discarded types
            if (discardUnitsCheckBox.Checked || discardVehiclesCheckBox.Checked || discardObjectsCheckBox.Checked)
            {
                var filtered = new List<GameObject>();

                for (int i = 0; i < objList.Count; i++)
                {
                    GameObject go = objList[i];
                    bool isUnit = (go.type == GameObject.Type.Unit);
                    bool isVehicle = (go.type == GameObject.Type.Vehicle);
                    bool isObject = (go.type == GameObject.Type.Object);

                    if (isUnit && !discardUnitsCheckBox.Checked) filtered.Add(go);
                    if (isVehicle && !discardVehiclesCheckBox.Checked) filtered.Add(go);
                    if (isObject && !discardObjectsCheckBox.Checked) filtered.Add(go);
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
                    extention = ".sqf";
                    break;
            }
            return lines;
        }

        private void OutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSelected = (outputFormatDropDown.SelectedIndex == 0);
            formatInputBox.Enabled = isSelected;
            indentsNumBox.Enabled = isSelected;
            prefixCheckBox.Enabled = isSelected;
            suffixCheckBox.Enabled = isSelected;

            prefixLineInputBox.Enabled = isSelected && prefixCheckBox.Checked;
            suffixLineInputBox.Enabled = isSelected && suffixCheckBox.Checked;

            formatHelpBox.Visible = isSelected;

            UpdatePreviewer();
        }

        private void RelativePos_CheckedChanged(object sender, EventArgs e)
        {
            relativePosition.Enabled = relativePosCheckBox.Checked; //Field enabled is determined by checkbox
            UpdatePreviewer();
        }

        private void RelativeFindCenter_Click(object sender, EventArgs e)
        {
            relativePosition.Text = center.ToString();
        }

        private void Prefix_CheckedChanged(object sender, EventArgs e)
        {
            prefixLineInputBox.Enabled = prefixCheckBox.Checked;
            UpdatePreviewer();
        }

        private void Suffix_CheckedChanged(object sender, EventArgs e)
        {
            suffixLineInputBox.Enabled = suffixCheckBox.Checked;
            UpdatePreviewer();
        }

        private void Preset_SelectedIndexChanged(object sender, EventArgs e) => LoadPreset(presetDropDown.SelectedIndex);

        private void PreviewMode_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void SortByNames_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void ReplaceNames_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void Format_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void DiscardUnits_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void DiscardVehicles_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void SuffixLine_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void PrefixLine_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void Indents_ValueChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void ObjectPerLines_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void RelativePosition_TextChanged(object sender, EventArgs e) => UpdatePreviewer();

        private void DiscardObjects_CheckedChanged(object sender, EventArgs e) => UpdatePreviewer();
    }
}
