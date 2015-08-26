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

        public static List<string[]> JapaneseSymbologyValues() //this will read the csv file and convert that into a list/array 3x47 and return it
        {
            string jStreamContents = "";
            //string JCSVFile = "";
            string JSBFileDirectory = Directory.GetCurrentDirectory();
            string JSBFile = Path.Combine(JSBFileDirectory, "Japanese Symbology Bool.csv");
            Console.WriteLine(JSBFile);

            //reads the contents of the csv file and converts it into a string "jstreamcontents"
            using (StreamReader oStreamReader = new StreamReader(JSBFile))
            {
                jStreamContents = oStreamReader.ReadToEnd();
            }

            List<string[]> oJCsvList = new List<string[]>();

            //this will read the contents of the string and put that into a list with "splitting" characters that are seperated with a comma
            string[] sFileLines = jStreamContents.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string sFileline in sFileLines)
            {
                oJCsvList.Add(sFileline.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            }

            //int iColumnNumber = 0;
            //int iRowNumber = 0;

            //Console.WriteLine("Column{0}, row {1} = \"{2}\"", iColumnNumber, iRowNumber, oJCsvList[iColumnNumber][iRowNumber]);

            //iColumnNumber = 3;
            //iColumnNumber = 2;

            //Console.WriteLine("Column{0}, row {1} = \"{2}\"", iColumnNumber, iRowNumber, oJCsvList[iColumnNumber][iRowNumber]);

            //returns the list to the method
            return oJCsvList;
        }
        public static void ReplaceBoolValue(List<string[]> boolList, int row) //this method will change the 4th value string (bool) from false to true and vice versa
        {

            List<string[]> boolValues = boolList;
            bool boolParse = Boolean.Parse(boolValues[row][3]);
            string boolString = boolValues[row][3];

            if (boolParse == false)
            {
                Console.WriteLine(boolString + " " + row);
                boolValues[row][3] = "true";
                Console.WriteLine(boolValues[row][0]);
                Console.WriteLine("False to True");
            }
            else if (boolParse == true)
            {
                Console.WriteLine(boolString + " " + row);
                boolValues[row][3] = "false";
                Console.WriteLine(boolValues[row][0]);
                Console.WriteLine("True to false");
            }
            else Console.WriteLine("Error in replacement");
        }
    }
}
