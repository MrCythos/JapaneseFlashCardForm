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
        public static void CardQuizzer(string caption, string text, List<string[]> testList, int toVal, int fromVal) //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
        {
            Form prompt = new Form();

            prompt.Width = 500;
            prompt.Height = 500;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;

            string testText = text;
            int buttonLeft = 350;
            int buttonWidth = 100;
            List<string[]> answerList = new List<string[]>();
            
            Label textLabel = new Label() { Left = 80, Top = 75, Text = testText, Font = new System.Drawing.Font("Microsoft Sans Serif", 150f), AutoSize = true};
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Confirm", Left = 370, Width = 100, Top = 425, DialogResult = DialogResult.OK };
            Button denial = new Button() { Text = "Skip", Left = 370, Width = 100, Top = 400};
            Button button1 = new Button() { Text = "1", Left = buttonLeft, Width = buttonWidth, Top = 60, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button2 = new Button() { Text = "2", Left = buttonLeft, Width = buttonWidth, Top = 135, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button3 = new Button() { Text = "3", Left = buttonLeft, Width = buttonWidth, Top = 210, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button4 = new Button() { Text = "4", Left = buttonLeft, Width = buttonWidth, Top = 285, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };

            Button[] buttonArray = new Button[] { button1, button2, button3, button4 };
            Random randomButton = new Random();
            int answerButton = 0;


            //buttonArray[0].Text = "Hello";
            
            confirmation.Click += (sender, e) => 
            { 
                prompt.Close(); 
            };
            denial.Click += (sender, e) =>
            {
                answerButton = randomButton.Next(0, 4);
                answerList = JTestValue(testList);
                buttonArray[answerButton].Text = answerList[0][fromVal];

                for (int i = 0; i < 4; i++)
                {
                    Button[] tempButtonArray = new Button[]{buttonArray[i]};
                    Button tempButton = buttonArray[i];
                    if (i != answerButton)
                    {
                        Button[] tempList = buttonArray.SkipWhile(element => element = tempButton);//buttonArray.Except(tempButton);
                        //buttonArray.SkipWhile(element => element == buttonArray[i]);
                        while (buttonArray[i].Text != tempList[0].Text || buttonArray[i].Text != tempList[1].Text || buttonArray[i].Text != tempList[2].Text)
                        {

                        }
                        buttonArray[i].Text = JTestValue(testList)[0][fromVal];
                    }
                    else
                    {

                    }
                }

                prompt.Controls.Remove(textLabel);
                testText = answerList[toVal][0];
                textLabel.Text = testText;
                prompt.Controls.Add(textLabel);
            }; //refreshes form to show new character

            //prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(denial);
            prompt.Controls.Add(textLabel);
            //prompt.AcceptButton = confirmation;

            for (int i = 0; i < 4; i++)
            {
            prompt.Controls.Add(buttonArray[i]);
            }

            prompt.ShowDialog();
        }
        public static List<string[]> JSCReturn(List<string[]> jSCsv) //reads the current list and reads+adds a row if the 4th column is bool.parse'd true
        {
            List<string[]> jSCsvCheck = jSCsv; //the old list
            List<string[]> testingList = new List<string[]>(); //the testing/true list
            int listLength = 0;

            for (int i = 0; i < 50; i++) //for loop will loop through all the values in the 4th column
            {
                bool jSCBool;
                jSCBool = bool.Parse(jSCsvCheck[i][3]); //parses and assigns the string to a new variable
                string emptyCheck = jSCsvCheck[i][0];
                if (jSCBool == true && emptyCheck != "") //if that jSCBool is true then the row will be added to the new list
                {
                    testingList.Add(jSCsvCheck[i]);
                    listLength++;
                }
            }
            //for (int i = 0; i < listLength; i++)
            //{
            //    if (testingList[i][0] == "")
            //    {
            //        testingList.Remove(testingList[i]);
            //    }
            //}
            return testingList; //return testing list which contains values for testings
        }
        public static List<string[]> JTestValue(List<string[]> jSCsvTrue) //toVal is the "question" being asked
        {
            List<string[]> jList = jSCsvTrue;
            int startingValue = 0;
            int jVal = 0;
            Random rnd = new Random();
            int testValue;
            List<string[]> returnTestValue = new List<string[]>();

            for (int i = 0; i < 50; i++)
            {
                bool test;
                //jSCBool = bool.Parse(jSCsvCheck[i][3]);
                try
                {
                    test = bool.Parse(jList[i][3]);
                }
                catch
                {
                    Console.WriteLine("FlashCardTester.JTestValue() parsed to end of test list. "+ Environment.NewLine + "Count is finished.");
                    break;
                }
                if (test == true)
                {
                    jVal++;
                }
                
            }
            jVal -= 1;
            testValue = rnd.Next(startingValue, jVal);
            Console.WriteLine(testValue); //testing
            Console.WriteLine(jVal);
            Console.WriteLine();
            returnTestValue.Add(jSCsvTrue[testValue]);
            
            return returnTestValue;
        }
    }
}
