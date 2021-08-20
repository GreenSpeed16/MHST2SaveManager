using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MHST2SaveManager
{
    [Serializable]
    public class ProgramState
    {
        //Fields
        public bool MainLoaded { get; private set; }
        public string SavePath { get; private set; }
        public SortedDictionary<int, string> SavePaths { get; private set; }
        public List<string> SaveList { get; private set; }

        //Singleton class
        private static ProgramState state = null;
        public static ProgramState State
        {
            get
            {
                if (state == null)
                {
                    try
                    {
                        using (Stream input = File.OpenRead("program.state"))
                        {
                            state = (ProgramState)Model.binaryFormatter.Deserialize(input); //Load existing state if exists
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        state = new ProgramState();
                        Directory.CreateDirectory("Saves");
                        Directory.CreateDirectory("MainSave");
                        state.MainLoaded = false;
                        state.SaveList = new List<string>();
                    }
                }
                return state;
            }
        }

        private ProgramState()
        {
        }

        public void Save(string SavePath, SortedDictionary<int, string> SavePaths, bool MainLoaded)
        {
            this.SavePath = SavePath;
            this.SavePaths = SavePaths;
            SaveList = Model.SaveList;
            this.MainLoaded = MainLoaded;
        }
    }
}
