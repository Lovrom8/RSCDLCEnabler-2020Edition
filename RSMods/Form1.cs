﻿using RSModsConsole;
using System;
using System.Windows.Forms;
using System.IO;

namespace RSMods
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            WriteSettings.NoSettingsDetected(); // Creates Settings File
            InitializeComponent();

            // Fill Songlist List
                this.Songlist.Items.AddRange(new object[] {
                    ImportPriorSettings()[0],
                    ImportPriorSettings()[1],
                    ImportPriorSettings()[2],
                    ImportPriorSettings()[3],
                    ImportPriorSettings()[4],
                    ImportPriorSettings()[5] });

            // Fill Modlist List
            this.ModList.Items.AddRange(new object[] {
                "Toggle Loft",
                "Add Volume",
                "Decrease Volume",
                "Show Song Timer",
                "Force ReEnumeration",
                "Rainbow Strings"});

            // Mod Key Values
                this.ToggleLoftKey.Text = "Toggle Loft: " + ImportPriorSettings()[6];
                this.AddVolumeKey.Text = "Add Volume: " + ImportPriorSettings()[7];
                this.DecreaseVolumeKey.Text = "Decrease Volume: " + ImportPriorSettings()[8];
                this.SongTimerKey.Text = "Show Song Timer: " + ImportPriorSettings()[9];
                this.ReEnumerationKey.Text = "Force ReEnumeration: " + ImportPriorSettings()[10];
                this.RainbowStringsAssignment.Text = "Rainbow Strings: " + ImportPriorSettings()[11];

            // Load Checkbox Values
                if (ImportPriorSettings()[12].ToString() == "true") // Toggle Loft Enabled / Disabled
                {
                    this.ToggleLoftCheckbox.Checked = true;
                }
                else
                {
                    this.ToggleLoftCheckbox.Checked = false;
                }

                if (ImportPriorSettings()[13].ToString() == "true") // Add Volume Enabled / Disabled
                {
                    this.AddVolumeCheckbox.Checked = true;
                }
                else
                {
                    this.AddVolumeCheckbox.Checked = false;
                }
                if (ImportPriorSettings()[14].ToString() == "true") // Decrease Volume Enabled / Disabled
                {
                    this.DecreaseVolumeCheckbox.Checked = true;
                }
                else
                {
                    this.DecreaseVolumeCheckbox.Checked = false;
                }
                if (ImportPriorSettings()[15].ToString() == "true") // Show Song Timer Enabled / Disabled
                {
                    this.SongTimerCheckbox.Checked = true;
                }
                else
                {
                    this.SongTimerCheckbox.Checked = false;
                }
                if (ReadSettings.ProcessSettings(17) == "true") // Rainbow String Enabled / Disabled
                {
                    this.RainbowStringsEnabled.Checked = true;
                }
                else
                {
                    this.RainbowStringsEnabled.Checked = false;
                }
                if (ReadSettings.ProcessSettings(15) == "automatic" ^ ReadSettings.ProcessSettings(15) == "manual") // Force ReEnumeration Manual / Automatic / False
                {
                    this.ForceEnumerationCheckbox.Checked = true;
                    this.ForceEnumerationAutomaticRadio.Visible = true;
                    this.ForceEnumerationManualRadio.Visible = true;

                    if(ReadSettings.ProcessSettings(15) == "automatic")
                    {
                        this.ForceEnumerationAutomaticRadio.Checked = true;
                    }
                    if (ReadSettings.ProcessSettings(15) == "manual")
                    {
                        this.ForceEnumerationManualRadio.Checked = true;
                    }
                }
                if (ImportPriorSettings()[18].ToString() == "true") // Extended Range Enabled / Disabled
                {
                    this.ExtendedRangeEnabled.Checked = true;
                    this.ExtendedRangeTuningText.Visible = true;
                    this.ExtendedRangeTunings.Visible = true;
                }
                else
                {
                    this.ExtendedRangeEnabled.Checked = false;
                }
        }

        private void ModList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ModList.GetSelected(0))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(6);
            }
            if (this.ModList.GetSelected(1))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(7);
            }
            if (this.ModList.GetSelected(2))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(8);
            }
            if (this.ModList.GetSelected(3))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(9);
            }
            if (this.ModList.GetSelected(4))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(10);
            }
            if (this.ModList.GetSelected(5))
            {
                this.NewAssignmentTxtBox.Text = ReadSettings.ProcessSettings(16);
            }
        }

        private void Songlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NewSongListNameTxtbox.Text = Songlist.SelectedItem.ToString();
        }
        
        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // If enter is pressed
            {
                Save_SaveChanges(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        
        private void SaveAndQuitFunction (object sender, EventArgs e)
        {
            Save_SaveChanges(sender, e);
            Application.Exit();
        }

        private void ResetToDefaultSettings (object sender, EventArgs e)
        {
            File.Delete(@WriteSettings.dumpLocation);
            RefreshForm();
        }

        private void Save_SaveChanges(object sender, EventArgs e)
        {
            // Songlists
                if (this.Songlist.GetSelected(0) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(0)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 1
                {
                    SaveChanges(1, this.NewSongListNameTxtbox.Text);
                }
                if (this.Songlist.GetSelected(1) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(1)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 2
                {
                    SaveChanges(2, this.NewSongListNameTxtbox.Text);
                }
                if (this.Songlist.GetSelected(2) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(2)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 3
                {
                    SaveChanges(3, this.NewSongListNameTxtbox.Text);
                }
                if (this.Songlist.GetSelected(3) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(3)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 4
                {
                    SaveChanges(4, this.NewSongListNameTxtbox.Text);
                }
                if (this.Songlist.GetSelected(4) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(4)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 5
                {
                    SaveChanges(5, this.NewSongListNameTxtbox.Text);
                }
                if (this.Songlist.GetSelected(5) & (this.NewSongListNameTxtbox.Text != ReadSettings.ProcessSettings(5)) & (this.NewSongListNameTxtbox.Text != "")) // Songlist 6
                {
                    SaveChanges(6, this.NewSongListNameTxtbox.Text);
                }
            // Mods
                if (this.ModList.GetSelected(0) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(6)) & (this.NewAssignmentTxtBox.Text != "")) // Toggle Loft Key
                {
                    SaveChanges(7, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
                if (this.ModList.GetSelected(1) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(7)) & (this.NewAssignmentTxtBox.Text != "")) // Add Volume Key
                {
                    SaveChanges(8, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
                if (this.ModList.GetSelected(2) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(8)) & (this.NewAssignmentTxtBox.Text != "")) // Decrease Volume Key
                {
                    SaveChanges(9, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
                if (this.ModList.GetSelected(3) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(9)) & (this.NewAssignmentTxtBox.Text != "")) // Show Song Timer Key
                {
                    SaveChanges(10, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
                if (this.ModList.GetSelected(4) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(10)) & (this.NewAssignmentTxtBox.Text != "")) // Force ReEnumeration Key
                {
                    SaveChanges(11, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
                if (this.ModList.GetSelected(5) & (this.NewAssignmentTxtBox.Text != ReadSettings.ProcessSettings(16)) & (this.NewAssignmentTxtBox.Text != "")) {
                    SaveChanges(12, KeyConversion.VirtualKey(this.NewAssignmentTxtBox.Text));
                }
            // Toggle Mods
                if (this.ToggleLoftCheckbox.Checked.ToString() != ReadSettings.ProcessSettings(11)) // Toggle Loft Enabled/ Disabled
                {
                    SaveChanges(13, this.ToggleLoftCheckbox.Checked.ToString().ToLower());
                }
                if (this.AddVolumeCheckbox.Checked.ToString() != ReadSettings.ProcessSettings(13)) // Add Volume Enabled/ Disabled
                {
                    SaveChanges(14, this.AddVolumeCheckbox.Checked.ToString().ToLower());
                }
                if (this.DecreaseVolumeCheckbox.Checked.ToString() != ReadSettings.ProcessSettings(14)) // Decrease Volume Enabled / Disabled
                {
                    SaveChanges(15, this.DecreaseVolumeCheckbox.Checked.ToString().ToLower());
                }
                if (this.SongTimerCheckbox.Checked.ToString() != ReadSettings.ProcessSettings(15)) // Show Song Timer Enabled / Disabled
                {
                    SaveChanges(16, this.SongTimerCheckbox.Checked.ToString().ToLower());
                }
                if (this.ForceEnumerationCheckbox.Checked == true) // Force Enumeration Manual / Automatic / Disabled
                {
                    if (this.ForceEnumerationAutomaticRadio.Checked == true)
                    {
                        SaveChanges(17, "automatic");
                    } else
                    {
                        SaveChanges(17, "manual");
                    }
                } else
                {
                    SaveChanges(17, "false");
                }
                if (this.RainbowStringsEnabled.Checked.ToString() != ReadSettings.ProcessSettings(17)) // Rainbow Strings Enabled / Disabled
                {
                    SaveChanges(18, this.RainbowStringsEnabled.Checked.ToString().ToLower());
                }
                if (this.ExtendedRangeEnabled.Checked.ToString() != ReadSettings.ProcessSettings(18)) // Extended Range Mode Enabled / Disabled
                {
                    SaveChanges(19, this.ExtendedRangeEnabled.Checked.ToString().ToLower());
                }
            // Extended Range
                if (this.ExtendedRangeTunings.GetSelected(0))
                {
                    SaveChanges(20, "DropD");
                }
                if (this.ExtendedRangeTunings.GetSelected(1))
                {
                    SaveChanges(20, "DropC#");
                }
                if (this.ExtendedRangeTunings.GetSelected(2))
                {
                    SaveChanges(20, "DropC");
                }
                if (this.ExtendedRangeTunings.GetSelected(3))
                {
                    SaveChanges(20, "DropB");
                }
                if (this.ExtendedRangeTunings.GetSelected(4))
                {
                    SaveChanges(20, "DropA#");
                }
                if (this.ExtendedRangeTunings.GetSelected(5))
                {
                    SaveChanges(20, "DropA");
                }
                if (this.ExtendedRangeTunings.GetSelected(6))
                {
                    SaveChanges(20, "DropG#");
                }
                if (this.ExtendedRangeTunings.GetSelected(7))
                {
                    SaveChanges(20, "DropG");
                }
                if (this.ExtendedRangeTunings.GetSelected(8))
                {
                    SaveChanges(20, "DropF#");
                }
                if (this.ExtendedRangeTunings.GetSelected(9))
                {
                    SaveChanges(20, "DropF");
                }
                if (this.ExtendedRangeTunings.GetSelected(10))
                {
                    SaveChanges(20, "DropE");
                }
            RefreshForm();
        }

        private void RefreshForm()
        {
            this.Hide();
            var newForm = new MainForm();
            newForm.Closed += (s, args) => this.Close();
            newForm.Show();
        }

        private void SaveChanges(int ElementToChange, string ChangedSettingValue)
        {
            string[] StringArray = File.ReadAllLines(@WriteSettings.dumpLocation);

            if (ElementToChange == 1) // Songlist 1
            {
                StringArray[1] = ReadSettings.Songlist1Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 2) // Songlist 2
            {
                StringArray[2] = ReadSettings.Songlist2Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 3) // Songlist 3
            {
                StringArray[3] = ReadSettings.Songlist3Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 4) // Songlist 4
            {
                StringArray[4] = ReadSettings.Songlist4Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 5) // Songlist 5
            {
                StringArray[5] = ReadSettings.Songlist5Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 6) // Songlist 6
            {
                StringArray[6] = ReadSettings.Songlist6Identifier + ChangedSettingValue;
            }
            if (ElementToChange == 7) // Toggle Loft Key
            {
                StringArray[8] = ReadSettings.ToggleLoftIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 8) // Add Volume Key
            {
                StringArray[9] = ReadSettings.AddVolumeIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 9) // Decrease Volume Key
            {
                StringArray[10] = ReadSettings.DecreaseVolumeIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 10) // Show Timer Key
            {
                StringArray[11] = ReadSettings.ShowSongTimerIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 11) // Force ReEnumeration Key
            {
                StringArray[12] = ReadSettings.ForceReEnumerationIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 12) // Rainbow Strings Key
            {
                StringArray[13] = ReadSettings.RainbowStringsIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 13) // Toggle Loft Enabled / Disabled
            {
                StringArray[15] = ReadSettings.ToggleLoftEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 14) // Add Volume Enabled / Disabled
            {
                StringArray[16] = ReadSettings.AddVolumeEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 15) // Decrease Volume Enabled / Disabled
            {
                StringArray[17] = ReadSettings.DecreaseVolumeEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 16) // Show Song Timer Enabled / Disabled
            {
                StringArray[18] = ReadSettings.ShowSongTimerEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 17) // Force ReEnumeration Manual / Automatic / Disabled
            {
                StringArray[19] = ReadSettings.ForceReEnumerationEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 18) // Rainbow String Enabled / Disabled
            {
                StringArray[20] = ReadSettings.RainbowStringsEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 19) // Extended Range Enabled / Disabled
            {
                StringArray[21] = ReadSettings.ExtendedRangeEnabledIdentifier + ChangedSettingValue;
            }
            if (ElementToChange == 20) // Extended Range Tuning Name
            {
                StringArray[22] = ReadSettings.ExtendedRangeTuningIdentifier + ChangedSettingValue;
            }
            WriteSettings.ModifyINI(StringArray);
        }
        public object[] ImportPriorSettings()
        {
            object[] priorSettings = new object[20];
            priorSettings[0] = ReadSettings.ProcessSettings(0);
            priorSettings[1] = ReadSettings.ProcessSettings(1);
            priorSettings[2] = ReadSettings.ProcessSettings(2);
            priorSettings[3] = ReadSettings.ProcessSettings(3);
            priorSettings[4] = ReadSettings.ProcessSettings(4);
            priorSettings[5] = ReadSettings.ProcessSettings(5);
            priorSettings[6] = ReadSettings.ProcessSettings(6);
            priorSettings[7] = ReadSettings.ProcessSettings(7);
            priorSettings[8] = ReadSettings.ProcessSettings(8);
            priorSettings[9] = ReadSettings.ProcessSettings(9);
            priorSettings[10] = ReadSettings.ProcessSettings(10);
            priorSettings[11] = ReadSettings.ProcessSettings(16);
            priorSettings[12] = ReadSettings.ProcessSettings(11);
            priorSettings[13] = ReadSettings.ProcessSettings(12);
            priorSettings[14] = ReadSettings.ProcessSettings(13);
            priorSettings[15] = ReadSettings.ProcessSettings(14);
            priorSettings[16] = ReadSettings.ProcessSettings(15);
            priorSettings[17] = ReadSettings.ProcessSettings(17);
            priorSettings[18] = ReadSettings.ProcessSettings(18);
            priorSettings[19] = ReadSettings.ProcessSettings(19);
            return priorSettings;
        }
    }
}
