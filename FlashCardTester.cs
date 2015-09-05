using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    class FlashCardTester
    {
        public static void CardQuizzer(string caption, string text) //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 500;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Font = new System.Drawing.Font("Microsoft Sans Serif", 100f), AutoSize = true};
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Confirm", Left = 370, Width = 100, Top = 425, DialogResult = DialogResult.OK };
            Button denial = new Button() { Text = "Update", Left = 370, Width = 100, Top = 400};
            confirmation.Click += (sender, e) => { prompt.Close(); };
            denial.Click += (sender, e) => { prompt.Update(); }; //maybe refreshes form, build method to [.Refresh() or .Update()]
            //prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(denial);
            prompt.Controls.Add(textLabel);
            //prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }
        public static List<string[]> JSCReturn(List<string[]> jSCsv) //reads the current list and reads+adds a row if the 4th column is bool.parse'd true
        {
            List<string[]> jSCsvCheck = jSCsv; //the old list
            List<string[]> testingList = new List<string[]>(); //the testing/true list
            for (int i = 0; i < 50; i++) //for loop will loop through all the values in the 4th column
            {
                bool jSCBool;
                jSCBool = bool.Parse(jSCsvCheck[i][3]); //parses and assigns the string to a new variable
                if (jSCBool == true) //if that jSCBool is true then the row will be added to the new list
                {
                    testingList.AddRange(jSCsvCheck.ToArray());
                }
                else
                {
                    //nothing
                }
            }

            return testingList; //return testing list which contains values for testings
        }
        public static string JTestValue (List<string[]> jSCsvTrue, int toVal) //toVal is the "question" being asked
        {
            List<string[]> jList = jSCsvTrue;
            int startingValue = 0;
            int jVal = 0;
            Random rnd = new Random();
            int testValue;
            string returnTestValue;

            for (int i = 0; i < 50; i++)
            {
                bool test;
                //jSCBool = bool.Parse(jSCsvCheck[i][3]);
                test = bool.Parse(jList[i][3]);
                if (test == true)
                {
                    jVal++;
                }
                else break;
            }

            testValue = rnd.Next(startingValue, jVal);
            Console.WriteLine(testValue); //testing
            returnTestValue = jSCsvTrue[testValue][toVal];

            return returnTestValue;
        }
    }
}
