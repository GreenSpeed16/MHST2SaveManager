using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace MHST2SaveManager
{
    public partial class Form1 : Form
    {
        Controller Cont;
        public Form1()
        {
            InitializeComponent();

        }

        public void SetController(Controller c)
        {
            Cont = c;
            CurrentSaveLabel.Text = Cont.GetSave();
        }

        public void ListSaves()
        {
            SaveBox.Items.Clear();
            foreach (string Save in Model.SaveList)
            {
                SaveBox.Items.Add(Save);
            }
        }

        public void MainLoaded(bool MainLoaded)
        {
            MainSaveButton.Enabled = !MainLoaded;
        }

        public void EnableButtons(bool WorldPathSet)
        {
            SetMainButton.Enabled = WorldPathSet;
            SaveCurrentSave.Enabled = WorldPathSet;
            LoadButton.Enabled = WorldPathSet;
            DeleteButton.Enabled = WorldPathSet;
            MainSaveButton.Enabled = WorldPathSet;
        }

        private void SetWorldPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Cont.SetWorldPath(folderBrowserDialog1.SelectedPath);
            }
            Cont.SetMain();
            Cont.LoadMain();
            CurrentSaveLabel.Text = "Main";
            EnableButtons(true);
            MainLoaded(true);
        }

        private void MainSaveButton_Click(object sender, EventArgs e)
        {
            Cont.LoadMain();
            CurrentSaveLabel.Text = "Main";
            MainLoaded(true); //User cannot load main save if it is already loaded
        }

        private void SetMainButton_Click(object sender, EventArgs e)
        {
            Cont.SetMain();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string SaveName = SaveBox.SelectedItem.ToString();
            if (SaveName != null)
            {
                Cont.LoadSave(SaveName);
                CurrentSaveLabel.Text = SaveName;
            }
            else
            {
                MessageBox.Show("No Save Selected");
            }

            MainLoaded(false); //Re-enable main save loading
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string SaveName = SaveBox.SelectedItem.ToString();
            if (SaveName != null && SaveName != CurrentSaveLabel.Text)
            {
                Cont.DeleteSave(SaveName);
                Cont.ListSaves();
            }
            else if (SaveName != null)
            {
                MessageBox.Show("Cannot delete currently loaded save.");
            }
            else
            {
                MessageBox.Show("No Save Selected");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cont.Save();
        }

        private void SaveCurrentSave_Click(object sender, EventArgs e)
        {
            string SaveName = Interaction.InputBox("Enter the name of this save file: ", "Create New Save");
            if (SaveName != "")
            {
                Cont.CreateSave(SaveName);
                CurrentSaveLabel.Text = SaveName;
                MainLoaded(false);
                Cont.ListSaves();
            }

        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            string SaveToRename = SaveBox.SelectedItem.ToString();
            string SaveName = Interaction.InputBox("Enter the name of this save file: ", "Create New Save");
            if (SaveName != "")
            {
                Cont.RenameSave(SaveToRename, SaveName);
                Cont.ListSaves();
            }
        }

        private void SaveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            upButton.Enabled = (SaveBox.SelectedIndex > 0);
            downButton.Enabled = (SaveBox.SelectedIndex < SaveBox.Items.Count - 1);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int index = SaveBox.SelectedIndex;
            object item = SaveBox.SelectedItem;
            SaveBox.Items.RemoveAt(SaveBox.SelectedIndex);
            SaveBox.Items.Insert(index - 1, item);
            SaveBox.SelectedIndex = index - 1;
            Cont.ReorderSaves(SaveBox.Items.Cast<String>().ToList());
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int index = SaveBox.SelectedIndex;
            object item = SaveBox.SelectedItem;
            SaveBox.Items.RemoveAt(SaveBox.SelectedIndex);
            SaveBox.Items.Insert(index + 1, item);
            SaveBox.SelectedIndex = index + 1;
            Cont.ReorderSaves(SaveBox.Items.Cast<String>().ToList());
        }
    }
}
