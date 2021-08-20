using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace MHST2SaveManager
{
    public class Model
    {
        public static BinaryFormatter binaryFormatter { get; private set; }
        public static List<string> SaveList { get; private set; }
        public bool MainLoaded { get; private set; }
        public static SortedDictionary<int, string> SavePaths;
        public string SavePath { get; private set; }
        public static ProgramState State;

        public Model()
        {
            binaryFormatter = new BinaryFormatter();
            State = ProgramState.State;
            SavePaths = State.SavePaths;
            SavePath = State.SavePath;
            MainLoaded = State.MainLoaded;
            SaveList = State.SaveList;
        }

        public void SwitchSave(string FileName, int slot)
        {
            if (MainLoaded)
            {
                DialogResult dialogResult =
                MessageBox.Show("You are about to switch off of your main save file. Would you like to save it?", "Confirm Save Switch", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    //Backup Main State
                    File.Delete(".\\MainSave\\main_slot_1.txt");
                    File.Copy(SavePath + "\\mhr_slot_1.txt", ".\\MainSave\\main_slot_1.txt");
                    File.Delete(".\\MainSave\\main_slot_2.txt");
                    File.Copy(SavePath + "\\mhr_slot_2.txt", ".\\MainSave\\main_slot_2.txt");
                    File.Delete(".\\MainSave\\main_slot_3.txt");
                    File.Copy(SavePath + "\\mhr_slot_3.txt", ".\\MainSave\\main_slot_3.txt");
                }
                
            }

            SavePaths[slot] = FileName;
            File.Delete(SavePath + "\\mhr_slot_" + slot + ".txt");
            File.Copy(".\\Saves\\" + FileName, SavePath + "\\mhr_slot_" + slot + ".txt");
            MainLoaded = false;
        }

        public void Save()
        {
            //Pass data to CurrentState
            State.Save(SavePath, SavePaths, MainLoaded);
            //Save to file
            using (Stream output = File.Create("program.state"))
            {
                binaryFormatter.Serialize(output, State);
            }
        }

        public void CreateSave(string FilePath, int slot)
        {
            //Check for existing save with name
            if (!SaveList.Contains(FilePath))
            {
                File.Copy(SavePath + "\\mhr_slot_" + slot + ".txt", ".\\Saves\\" + FilePath);
                SavePaths[slot] = FilePath.Replace(".txt", "");
                MainLoaded = false;
                SaveList.Add(FilePath.Replace(".txt", ""));
            }
            else
            {
                DialogResult result = MessageBox.Show("A save with that name already exists. Would you like to replace it?", "Save Already Exists",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete(".\\Saves\\" + FilePath);
                    File.Copy(SavePath + "\\mhr_slot_" + slot + ".txt", ".\\Saves\\" + FilePath);
                    SavePaths[slot] = FilePath.Replace(".txt", "");
                    MainLoaded = false;
                }
            }

        }

        public void RenameSave(string oldPath, string newPath)
        {
            SaveList.Remove(oldPath);
            SaveList.Add(newPath);

            newPath = ".\\Saves\\" + newPath;
            oldPath = ".\\Saves\\" + oldPath;
            File.Copy(oldPath, newPath);
            File.Delete(oldPath);
        }

        public void LoadMain()
        {
            if (!MainLoaded)
            {
                File.Delete(SavePath + "\\mhr_slot_1.txt");
                File.Copy(".\\MainSave\\main_slot_1.txt", SavePath + "\\mhr_slot_1.txt");

                File.Delete(SavePath + "\\mhr_slot_2.txt");
                File.Copy(".\\MainSave\\main_slot_2.txt", SavePath + "\\mhr_slot_2.txt");

                File.Delete(SavePath + "\\mhr_slot_3.txt");
                File.Copy(".\\MainSave\\main_slot_3.txt", SavePath + "\\mhr_slot_3.txt");
                MainLoaded = true;
                SavePaths[0] = "Main";
                SavePaths[1] = "Main";
                SavePaths[2] = "Main";
            }
        }

        public bool SetSaveFolder()
        {
            object steamPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null);
            string[] userdataFolder = Directory.GetDirectories(steamPath.ToString() + "\\userdata");
            bool storiesFolderExists = false;
            foreach (string folder in userdataFolder)
            {
                Console.WriteLine(folder);
                Console.WriteLine(folder.Substring(folder.LastIndexOf("\\") + 1));
                if (Regex.IsMatch(folder.Substring(folder.LastIndexOf("\\") + 1), "^[0-9]{9}"))
                //Folder is the Id folder
                {
                    foreach (string subFolder in Directory.GetDirectories(folder))
                    {
                        if (subFolder.Substring(subFolder.LastIndexOf("\\") + 1) == "1277400")
                        {
                            SavePath = folder + "\\1277400\\remote";
                            return true;
                        }
                    }
                    if (!storiesFolderExists)
                    {
                        MessageBox.Show("Stories 2 Folder Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
            }
            return false;
        }

        public void SetMain()
        {
            if (File.Exists(".\\MainSave\\MainData"))
            {
                string confirmation = Interaction.InputBox("You are about to overwrite your main save file. Type \"Confirm\" to continue.");

                if (confirmation.ToUpper() != "CONFIRM")
                {
                    MessageBox.Show("Cancelled save set.", "Cancelled");
                    return;
                }
            }

            File.Delete(".\\MainSave\\main_slot_1.txt");
            File.Copy(SavePath + "\\mhr_slot_1.txt", ".\\MainSave\\main_slot_1.txt");

            File.Delete(".\\MainSave\\main_slot_2.txt");
            File.Copy(SavePath + "\\mhr_slot_2.txt", ".\\MainSave\\main_slot_2.txt");

            File.Delete(".\\MainSave\\main_slot_3.txt");
            File.Copy(SavePath + "\\mhr_slot_3.txt", ".\\MainSave\\main_slot_3.txt");
        }

        public string GetSave(int slot)
        {
            if(slot != 0)
            {
                return SavePaths[slot - 1];
            }
            else
            {
                return "Main";
            }
        }

        public void DeleteSave(string FileName)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to delete " + FileName + ". Continue?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(".\\Saves\\" + FileName);
                SaveList.Remove(FileName);
            }

        }

        public void ReorderSaves(List<string> saveList)
        {
            SaveList = saveList;
        }

        public List<string> ListSaves()
        {
            return SaveList;
        }
    }
}
