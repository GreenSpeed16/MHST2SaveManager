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
            if (Model.SavePaths.ContainsKey(1) && Model.SavePaths.ContainsKey(2) && Model.SavePaths.ContainsKey(3))
            {
                InitSlots();
            }            
        }

        public void SetController(Controller c)
        {
            Cont = c;
        }

        public void SetSavePath()
        {
            if (Cont.SetSavePath())
            {
                Cont.SetMain();
                Cont.LoadMain();
                EnableButtons(true);
                UpdateSlots("Main");
                MainLoaded(true);
            }
        }

        private void InitSlots()
        {
            slot1Button.Text = "Slot 1: " + Model.SavePaths[1];
            slot2Button.Text = "Slot 2: " + Model.SavePaths[2];
            slot3Button.Text = "Slot 3: " + Model.SavePaths[3];
        }

        private void UpdateSlots(string SaveName)
        {
            if(SaveName == "Main" || Model.MainLoaded)
            {
                slot1Button.Text = "Slot 1: " + SaveName;
                slot2Button.Text = "Slot 2: " + SaveName;
                slot3Button.Text = "Slot 3: " + SaveName;
            }

            switch (selectedSlot)
            {
                case 1:
                    slot1Button.Text = "Slot 1: " + SaveName;
                    break;
                case 2:
                    slot2Button.Text = "Slot 2: " + SaveName;
                    break;
                case 3:
                    slot3Button.Text = "Slot 3: " + SaveName;
                    break;
            }
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
            MainSaveButton.Enabled = WorldPathSet;
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
                EnableButtons(true);
                UpdateSlots("Main");
                MainLoaded(true);
            }
            
        }

        private void MainSaveButton_Click(object sender, EventArgs e)
        {
            Cont.LoadMain();
            UpdateSlots("Main");
            MainLoaded(true); //User cannot load main save if it is already loaded
        }

        private void SetMainButton_Click(object sender, EventArgs e)
        {
            Cont.SetMain();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string fileName = SaveBox.SelectedItem.ToString();
            Cont.LoadSave(fileName, selectedSlot);
            UpdateSlots(fileName);

            //Re-enable main save loading
            MainLoaded(false);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string SaveName = SaveBox.SelectedItem.ToString();
            if (SaveName != null && SaveName != Model.SavePaths[selectedSlot])
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
                    UpdateSlots(SaveName);
                    MainLoaded(false);
                    Cont.ListSaves();
                }
            }
            else
            {
                MessageBox.Show("Select a slot to back up first.", "No Slot Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EnableSaveButtons()
        {
            if (selectedSlot != 0)
            {
                LoadButton.Enabled = (SaveBox.Items.Count > 0);
                RenameButton.Enabled = (SaveBox.Items.Count > 0);
                DeleteButton.Enabled = (SaveBox.Items.Count > 0);
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

            EnableSaveButtons();
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

            EnableSaveButtons();
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

            EnableSaveButtons();
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

            EnableSaveButtons();
        }

        private void updateFolder_Click(object sender, EventArgs e)
        {
            string SavePath = Interaction.InputBox("Please type the Stories 2 Savedata path here: \n (Steam\\userdata\\<9-digit number>\\1277400\\remote)");
            Model.SavePath = SavePath;
        }
    }
}
