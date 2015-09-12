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
        public static void CardQuizzer(string caption, List<string[]> testList, int toVal, int fromVal) //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
        {
            Form prompt = new Form();

            prompt.Width = 500;
            prompt.Height = 500;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;

            int buttonLeft = 50;
            int buttonWidth = 100;
            int labelLeft = 175;
            int labelTop = 80;
            List<string[]> answerList = new List<string[]>();
            List<string[]> testingList = testList;
            int answerToVal = toVal;
            int questionFromVal = fromVal;
            System.Drawing.Font startTextLabelFont= new System.Drawing.Font("Microsoft Sans Serif", 150f);
            
            Label textLabel = new Label() { Left = 200, Top = 150, Text = "Ready?", Font = new System.Drawing.Font("Microsoft Sans Serif", 40f), AutoSize = true};
            Label returnLabel = new Label() { Left = 50, Top = 400, Text = "" };
            //TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "End Test", Left = 370, Width = 100, Top = 425, DialogResult = DialogResult.OK };
            Button denial = new Button() { Text = "Start Test", Left = 370, Width = 100, Top = 400};
            Button button1 = new Button() { Text = "?", Left = buttonLeft, Width = buttonWidth, Top = 60, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button2 = new Button() { Text = "?", Left = buttonLeft, Width = buttonWidth, Top = 135, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button3 = new Button() { Text = "?", Left = buttonLeft, Width = buttonWidth, Top = 210, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };
            Button button4 = new Button() { Text = "?", Left = buttonLeft, Width = buttonWidth, Top = 285, Font = new System.Drawing.Font("Microsoft Sans Serif", 25f), Size = new System.Drawing.Size(100, 50) };

            Button[] buttonArray = new Button[] { button1, button2, button3, button4 };
            Random randomValue = new Random();
            
            confirmation.Click += (sender, e) => 
            {
                prompt.Close(); 
            };

            denial.Click += (sender, e) =>
            {
                int answerButton = randomValue.Next(0, 4);

                LabelConfig(textLabel, labelTop, labelLeft, startTextLabelFont);
                answerList = ClickGenerate(denial, buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ButtonIterator(buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ClickRefresh(prompt, textLabel, answerList, toVal);
            };

            button1.Click += (sender, e) =>
            {
                int answerButton = randomValue.Next(0, 4);

                ClickTest(button1, answerList, returnLabel, fromVal);

                LabelConfig(textLabel, labelTop, labelLeft, startTextLabelFont);
                answerList = ClickGenerate(denial, buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ButtonIterator(buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ClickRefresh(prompt, textLabel, answerList, toVal);
            };
            button2.Click += (sender, e) =>
            {
                int answerButton = randomValue.Next(0, 4);

                ClickTest(button2, answerList, returnLabel, fromVal);

                LabelConfig(textLabel, labelTop, labelLeft, startTextLabelFont);
                answerList = ClickGenerate(denial, buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ButtonIterator(buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ClickRefresh(prompt, textLabel, answerList, toVal);
            };
            button3.Click += (sender, e) =>
            {
                int answerButton = randomValue.Next(0, 4);

                ClickTest(button3, answerList, returnLabel, fromVal);

                LabelConfig(textLabel, labelTop, labelLeft, startTextLabelFont);
                answerList = ClickGenerate(denial, buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ButtonIterator(buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ClickRefresh(prompt, textLabel, answerList, toVal);
            };
            button4.Click += (sender, e) =>
            {
                int answerButton = randomValue.Next(0, 4);

                ClickTest(button4, answerList, returnLabel, fromVal);

                LabelConfig(textLabel, labelTop, labelLeft, startTextLabelFont);
                answerList = ClickGenerate(denial, buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ButtonIterator(buttonArray, answerList, testList, answerButton, randomValue, fromVal);
                ClickRefresh(prompt, textLabel, answerList, toVal);
            };

            //prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(denial);
            prompt.Controls.Add(textLabel);
            //prompt.AcceptButton = confirmation;
            prompt.Controls.Add(returnLabel);

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
                    Console.WriteLine("FlashCardTester.JTestValue() parsed to end of test list. "+ Environment.NewLine + "Ignore this message.");
                    break;
                }
                if (test == true)
                {
                    jVal++;
                }
                
            }
            //jVal -= 1;
            testValue = rnd.Next(startingValue, jVal);
            //Console.WriteLine(testValue); //testing
            //Console.WriteLine(jVal);
            returnTestValue.Add(jSCsvTrue[testValue]);
            
            return returnTestValue;
        }
        private static void ButtonIterator (Button[] buttonArray, List<string[]> answerList, List<string[]> testList, int answerButton, Random randomValue, int fromVal)
        {
            IEnumerable<string[]> answerEnum = answerList;
            List<string[]> questionList = testList.Except(answerEnum).ToList();

            int sizeOfTest = questionList.Count;

            foreach (Button value in buttonArray)
                {
                    int j = 0;

                    if (value != buttonArray[answerButton])
                    {
                        int questionButton = randomValue.Next(0, sizeOfTest);
                        value.Text = questionList[questionButton][fromVal];

                        while (value.Text == buttonArray[answerButton].Text ) //|| value.Text == ""
                        {
                            value.Text = questionList[questionButton][fromVal];
                        }
                        for (int i = j; i < 0; i--)
                        {
                            if (i != j)
                            {
                                while (value.Text == buttonArray[i].Text)
                                {
                                    value.Text = questionList[questionButton][fromVal];
                                }
                            }
                        }
                        j++;
                    }
                    else
                    {
                    }
                }
        }
        private static void LabelConfig (Label textLabel, int labelTop, int labelLeft, System.Drawing.Font Font)
        {
            textLabel.Top = labelTop;
            textLabel.Left = labelLeft;
            textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 150f);
        }
        public static List<string[]> ClickGenerate(Button denial, Button[] buttonArray, List<string[]> answerList, List<string[]> testList, int answerButton, Random randomValue, int fromVal)
        {
            //int questionFromVal = fromVal++;
            denial.Text = "Skip";
            //answerButton = randomValue.Next(0, 4); //chooses a random button to be the 'answer' 0-4 since next ignores 4 and instead uses the range from 0-3
            answerList = JTestValue(testList); //a single row from the testlist
            buttonArray[answerButton].Text = answerList[0][fromVal];//assigns the hiragana/katakana/romaji to the text in the 'answer' button

            return answerList;
        }
        private static void ClickRefresh(Form prompt, Label textLabel, List<string[]> answerList, int toVal)
        {
            string testText = "";
            prompt.Controls.Remove(textLabel);
            testText = answerList[0][toVal];
            textLabel.Text = testText;
            prompt.Controls.Add(textLabel);
        }
        private static void ClickTest(Button button1, List<string[]> answerList, Label returnLabel, int fromVal)
        {
            if (button1.Text == "?")
            {

            }
            else if (button1.Text == answerList[0][fromVal])
            {
                returnLabel.Text = "That's correct!";
            }
            else
            {
                returnLabel.Text = "That's wrong...";
            }
        }
    }
}
