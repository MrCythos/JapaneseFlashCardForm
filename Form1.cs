using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<string[]> JCSVList = Program.JapaneseSymbologyValues(); //outisde public form so that the list is accessible to all methods in form1
        List<string[]> JSCVTest; //list for values to be tested
        int toColumn = 0; //column in jSCVList to take answers testing
        int fromColumn = 2; //column in JSCVList to take from testing

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            //MinimizeBox = false;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; //this prevents the window from being resized, min/max-imized
            //checkBox1.Text = "Vowel Base"; //just how to manually rename stuff
            button3.Enabled = false; //prevents the image of the chart from being clicked

            //checkboxline is an array for the lines and checkboxbase is an array for the bases
            checkBoxLine = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11}; //organizes checkboxes
            checkBoxBase = new CheckBox[] { checkBox12, checkBox13, checkBox14, checkBox15, checkBox16 };

            textBox1.Hide(); //hides textbox //note: why did i put a textbox here?

        }
        CheckBox[] checkBoxLine; //an array of line/columns of checkboxes of hiragana
        CheckBox[] checkBoxBase; //an array of base/rows of checkboxes of hiragana

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void kataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void romajiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Howard Kim /u/Cythos; Programmed in C# using Windows Forms Application. Default testing parameters set to Hiragana to Romaji.", "Credits");
        }

        private void button1_Click_1(object sender, EventArgs e) //test-start button
        {
            //this.WindowState = System.Windows.Forms.FormWindowState.Minimized; //minimizes form when pressed
            //Form1.ActiveForm.Hide;
            JSCVTest = FlashCardTester.JSCReturn(JCSVList); //creates a list to be tested
            try
            {   //test list isn't correctly being passed into jtestvalue method
                FlashCardTester.CardQuizzer("Hiragana to Romaji", JSCVTest, toColumn, fromColumn);
            }
            catch
            {
                MessageBox.Show("You have nothing selected", "Testing Error");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //reset button
        {
            //MessageBox.Show("Checkboxes Reset", "Reset Confirmation");
            for (int i = 0; i < checkBoxLine.Length; i++)
            {
                checkBoxLine[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i <checkBoxBase.Length; i++)
            {
                checkBoxBase[i].CheckState = CheckState.Unchecked;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Hiragana Chart button, disabled for now
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("All Checkboxes Selected", "Selection Confirmation");
            for (int i = 0; i < checkBoxLine.Length; i++)
            {
                checkBoxLine[i].CheckState = CheckState.Checked;
            }
            for (int i = 0; i < checkBoxBase.Length; i++)
            {
                checkBoxBase[i].CheckState = CheckState.Checked;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxBase.Length; i++)
            {
                checkBoxBase[i].CheckState = CheckState.Checked;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxLine.Length; i++)
            {
                checkBoxLine[i].CheckState = CheckState.Checked;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            int j = 0; //starting point for replaceboolvalue method

            for (int i = 0; i < 5; i++) 
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked) //check the checkboxbase rows to see if they're unchecked, if so proceed.
                {
                    Program.ReplaceBoolValue(JCSVList, j); //
                }
                else
                {
                }
                j++;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ////Console.WriteLine("\n");
            //for (int i = 0; i < JCSVList.Count-1; i+=5)
            //{
            //    Program.ReplaceBoolValue(JCSVList, i);
            //}
            int j = 0; //starting point for replaceboolvalue method
            
            for (int i = 0; i < 10; i++) //using 10 because the 11th box is for the "n" character which can be ignored
            {
                if (checkBoxLine[i].CheckState == CheckState.Unchecked) //check if the state of the checkboxes of "line" are checked
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j += 5; //increment by 5 so that we mark only the base symbols
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int j = 5;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int j = 10;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            int j = 15;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int j = 20;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            int j = 25;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            int j = 30;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            int j = 35;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            int j = 40;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            int j = 45;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j++;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            int j = 50;

            for (int i = 0; i < 5; i++)
            {
                if (checkBoxBase[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 1; i < JCSVList.Count - 1; i += 5)
            //{
            //    Program.ReplaceBoolValue(JCSVList, i);
            //}
            int j = 1;

            for (int i = 0; i < 10; i++)
            {
                if (checkBoxLine[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j += 5;
            }

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 2; i < JCSVList.Count - 1; i += 5)
            //{
            //    Program.ReplaceBoolValue(JCSVList, i);
            //}
            int j = 2;

            for (int i = 0; i < 10; i++)
            {
                if (checkBoxLine[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j += 5;
            }

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 3; i < JCSVList.Count - 1; i += 5)
            //{
            //    Program.ReplaceBoolValue(JCSVList, i);
            //}
            int j = 3;

            for (int i = 0; i < 10; i++)
            {
                if (checkBoxLine[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j += 5;
            }

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 4; i < JCSVList.Count - 1; i += 5)
            //{
            //    Program.ReplaceBoolValue(JCSVList, i);
            //}
            int j = 4;

            for (int i = 0; i < 10; i++)
            {
                if (checkBoxLine[i].CheckState == CheckState.Unchecked)
                {
                    Program.ReplaceBoolValue(JCSVList, j);
                }
                else
                {
                }
                j += 5;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void toHiraganaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toColumn = 0;
            fromColumn = 2;
        }

        private void toKatakanaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toColumn = 1;
            fromColumn = 2;
        }

        private void katakanaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toHiraganaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toColumn = 0;
            fromColumn = 1;
        }

        private void toRomajiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toColumn = 2;
            fromColumn = 1;
        }

        private void toKatakanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toColumn = 1;
            fromColumn = 0;
        }

        private void toRomajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toColumn = 2;
            fromColumn = 0;
        }
    }
}
