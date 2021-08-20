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

        //Current Selected Save
        public int selectedSlot { get; private set; }

        //Movable form variables
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Form1()
        {
            InitializeComponent();
            selectedSlot = 0;
        }

        public void SetController(Controller c)
        {
            Cont = c;
            CurrentSaveLabel.Text = Cont.GetSave(selectedSlot);
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
            upButton.Enabled = WorldPathSet;
            downButton.Enabled = WorldPathSet;
            RenameButton.Enabled = WorldPathSet;
        }

        private void SetWorldPath_Click(object sender, EventArgs e)
        {
            /*if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
            }*/
            if (Cont.SetSavePath())
            {
                Cont.SetMain();
                Cont.LoadMain();
                CurrentSaveLabel.Text = "Main";
                EnableButtons(true);
                MainLoaded(true);
            }
            
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
                //Cont.LoadSave(SaveName);
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
            if(selectedSlot != 0)
            {
                string SaveName = Interaction.InputBox("Enter the name of this save file: ", "Create New Save");
                if (SaveName != "")
                {
                    Cont.CreateSave(SaveName, selectedSlot);
                    CurrentSaveLabel.Text = Model.SavePaths[selectedSlot];
                    MainLoaded(false);
                    Cont.ListSaves();
                }
            }
            else
            {
                MessageBox.Show("Select a slot to back up first.", "No Slot Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void slot1Button_Click(object sender, EventArgs e)
        {
            if(selectedSlot != 1)
            {
                selectedSlot = 1;
                slot1Button.BackColor = Color.FromArgb(238, 221, 175);
                slot1Button.ForeColor = Color.FromArgb(64, 64, 64);

                slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                slot2Button.ForeColor = Color.White;

                slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                slot3Button.ForeColor = Color.White;

            }
        }

        private void slot2Button_Click(object sender, EventArgs e)
        {
            if (selectedSlot != 2)
            {
                selectedSlot = 2;
                slot2Button.BackColor = Color.FromArgb(238, 221, 175);
                slot2Button.ForeColor = Color.FromArgb(64, 64, 64);

                slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                slot1Button.ForeColor = Color.White;

                slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                slot3Button.ForeColor = Color.White;
            }
        }

        private void slot3Button_Click(object sender, EventArgs e)
        {
            if (selectedSlot != 3)
            {
                selectedSlot = 3;
                slot3Button.BackColor = Color.FromArgb(238, 221, 175);
                slot3Button.ForeColor = Color.FromArgb(64, 64, 64);

                slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                slot2Button.ForeColor = Color.White;

                slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                slot1Button.ForeColor = Color.White;
            }
        }
    }
}
