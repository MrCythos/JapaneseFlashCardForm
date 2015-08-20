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
        public Form1()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //MaximizeBox = false;
            //MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; //this prevents the window from being resized, min/max-imized
            //checkBox1.Text = "Vowel Base"; //just how to manually rename stuff
            button3.Enabled = false; //prevents the image of the chart from being clicked

            checkBoxLine = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11};
            checkBoxBase = new CheckBox[] { checkBox12, checkBox13, checkBox14, checkBox15, checkBox16 };

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
            MessageBox.Show("Howard Kim; Programmed in C# using Windows Forms Application", "Credits");
        }

        private void button1_Click_1(object sender, EventArgs e) //test button
        {
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
            for (int i = 0; i <checkBoxBase.Length; i++)
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
    }
}
