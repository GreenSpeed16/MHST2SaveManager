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
        public static bool MainLoaded { get; private set; }
        public static Dictionary<int, string> SavePaths;
        public string SavePath { get; private set; }
        public string AppDataPath { get; private set; }
        public static ProgramState State;

        public Model()
        {
            binaryFormatter = new BinaryFormatter();
            State = ProgramState.State;
            AppDataPath = State.AppDataPath;
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
                MessageBox.Show("You are about to switch off of one of your main saves. Would you like to back it up?", "Confirm Save Switch", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        //Backup Main State
                        File.Delete(AppDataPath + "\\MainSave\\main_slot_1.sav");
                        File.Copy(SavePath + "\\mhr_slot_1.sav", AppDataPath + "\\MainSave\\main_slot_1.sav");
                        File.Delete(AppDataPath + "\\MainSave\\main_slot_2.sav");
                        File.Copy(SavePath + "\\mhr_slot_2.sav", AppDataPath + "\\MainSave\\main_slot_2.sav");
                        File.Delete(AppDataPath + "\\MainSave\\main_slot_3.sav");
                        File.Copy(SavePath + "\\mhr_slot_3.sav", AppDataPath + "\\MainSave\\main_slot_3.sav");
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("This application doesn't work for the demo version of Stories 2. Please install the full version.");
                    }
                    
                }
                
            }

            SavePaths[slot] = FileName;
            File.Delete(SavePath + "\\mhr_slot_" + slot + ".sav");
            File.Copy(AppDataPath + "\\Saves\\" + FileName + ".sav", SavePath + "\\mhr_slot_" + slot + ".sav");
            MainLoaded = false;
        }

        public void Save()
        {
            //Pass data to CurrentState
            State.Save(SavePath, SavePaths, MainLoaded);
            //Save to file
            using (Stream output = File.Create(AppDataPath + "\\program.state"))
            {
                binaryFormatter.Serialize(output, State);
            }
        }

        public void CreateSave(string FilePath, int slot)
        {
            //Check for existing save with name
            if (!SaveList.Contains(FilePath))
            {
                File.Copy(SavePath + "\\mhr_slot_" + slot + ".sav", AppDataPath + "\\Saves\\" + FilePath);
                SavePaths[slot] = FilePath.Replace(".sav", "");
                MainLoaded = false;
                SaveList.Add(FilePath.Replace(".sav", ""));
            }
            else
            {
                DialogResult result = MessageBox.Show("A save with that name already exists. Would you like to replace it?", "Save Already Exists",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete(AppDataPath + "\\Saves\\" + FilePath);
                    File.Copy(SavePath + "\\mhr_slot_" + slot + ".sav", AppDataPath + "\\Saves\\" + FilePath);
                    SavePaths[slot] = FilePath.Replace(".sav", "");
                    MainLoaded = false;
                }
            }

        }

        public void RenameSave(string oldPath, string newPath)
        {
            SaveList.Remove(oldPath);
            SaveList.Add(newPath);

            newPath = AppDataPath + "\\Saves\\" + newPath;
            oldPath = AppDataPath + "\\Saves\\" + oldPath;
            File.Copy(oldPath, newPath);
            File.Delete(oldPath);
        }

        public void LoadMain()
        {
            if (!MainLoaded)
            {
                File.Delete(SavePath + "\\mhr_slot_1.sav");
                File.Copy(AppDataPath + "\\MainSave\\main_slot_1.sav", SavePath + "\\mhr_slot_1.sav");

                File.Delete(SavePath + "\\mhr_slot_2.sav");
                File.Copy(AppDataPath + "\\MainSave\\main_slot_2.sav", SavePath + "\\mhr_slot_2.sav");

                File.Delete(SavePath + "\\mhr_slot_3.sav");
                File.Copy(AppDataPath + "\\MainSave\\main_slot_3.sav", SavePath + "\\mhr_slot_3.sav");
                MainLoaded = true;
                SavePaths[1] = "Main";
                SavePaths[2] = "Main";
                SavePaths[3] = "Main";
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
            if (File.Exists(AppDataPath + "\\MainSave\\MainData"))
            {
                string confirmation = Interaction.InputBox("You are about to overwrite your main save file. Type \"Confirm\" to continue.");

                if (confirmation.ToUpper() != "CONFIRM")
                {
                    MessageBox.Show("Cancelled save set.", "Cancelled");
                    return;
                }
            }

            File.Delete(AppDataPath + "\\MainSave\\main_slot_1.sav");
            File.Copy(SavePath + "\\mhr_slot_1.sav", AppDataPath + "\\MainSave\\main_slot_1.sav");

            File.Delete(AppDataPath + "\\MainSave\\main_slot_2.sav");
            File.Copy(SavePath + "\\mhr_slot_2.sav", AppDataPath + "\\MainSave\\main_slot_2.sav");

            File.Delete(AppDataPath + "\\MainSave\\main_slot_3.sav");
            File.Copy(SavePath + "\\mhr_slot_3.sav", AppDataPath + "\\MainSave\\main_slot_3.sav");
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
                File.Delete(AppDataPath + "\\Saves\\" + FileName);
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
