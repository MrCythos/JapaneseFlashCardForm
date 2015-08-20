using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
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
            Application.Run(new Form1());

        }
        static void JapaneseSymbologyStreamer()
        {
            string sFileContents = "";
            using (StreamReader oStreamReader = new StreamReader(File.OpenRead("Japanese Symbology.csv")))
            {
                sFileContents = oStreamReader.ReadToEnd();
            }
        }
    }
}
