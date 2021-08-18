using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MHST2SaveManager
{
    public class Controller
    {
        Form1 __View;
        public Model __Model { get; private set; }

        public Controller(Form1 View, Model Model)
        {
            this.__View = View;
            this.__Model = Model;

            __View.MainLoaded(__Model.MainLoaded);
            if (__Model.WorldPath == null)
            {
                __View.EnableButtons(false);
            }
            else
            {
                __View.EnableButtons(true);
                if (__Model.CurrentSavePath == "Main")
                {
                    __View.MainLoaded(true);
                }
            }
        }

        public void SetWorldPath(string Path)
        {
            __Model.SetWorldFolder(Path);
        }

        public void Save()
        {
            __Model.Save();
        }

        public void LoadSave(string FileName)
        {
            __Model.SwitchSave(FileName);
        }

        public void SetMain()
        {
            __Model.SetMain();
        }

        public string GetSave()
        {
            return __Model.GetSave();
        }

        public void LoadMain()
        {
            __Model.LoadMain();
        }

        public void DeleteSave(string FileName)
        {
            __Model.DeleteSave(FileName);
        }

        public void ListSaves()
        {
            __View.ListSaves();
        }

        public void CreateSave(string FileName)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            FileName = r.Replace(FileName, "");
            __Model.CreateSave(FileName);
        }

        public void RenameSave(string oldName, string newName)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            __Model.RenameSave(oldName, r.Replace(newName, ""));
        }

        public void ReorderSaves(List<string> saveList)
        {
            __Model.ReorderSaves(saveList);
        }
    }
}
