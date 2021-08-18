using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHST2SaveManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MVC
            Form1 v = new Form1();
            Model m = new Model();
            Controller c = new Controller(v, m);
            v.SetController(c);
            c.ListSaves();
            Application.Run(v);
        }
    }
}
