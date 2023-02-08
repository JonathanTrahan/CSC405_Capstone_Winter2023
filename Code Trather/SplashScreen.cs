using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Code_Trather
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        //with unit test
        private void button1_Click(object sender, EventArgs e)
        {
            //check if inputs are full
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                warningLabel.Text = "Please enter your name.";
                return;
            }
            if (string.IsNullOrEmpty(testIDtextBox.Text))
            {
                warningLabel.Text = "Please enter a valid test ID.";
                return;
            }
            if (cwidInputBox.Text == "" | cwidInputBox.Text == "0")
            {
                warningLabel.Text = "Please enter your CWID.";
                return;
            }

            //get inputs
            Program.studentName = nameTextBox.Text;
            Program.cwid = (int)cwidInputBox.Value;
            Program.testID = testIDtextBox.Text;

            //lanch main program
            Program.hasUnitTest = true;
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Hide();
        }

        //without unit test
        private void button2_Click(object sender, EventArgs e)
        {
            //check if inputs are full
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                warningLabel.Text = "Please enter your name.";
                return;
            }
            if (string.IsNullOrEmpty(testIDtextBox.Text))
            {
                warningLabel.Text = "Please enter a valid test ID.";
                return;
            }
            if (cwidInputBox.Text == "" | cwidInputBox.Text == "0")
            {
                warningLabel.Text = "Please enter your CWID.";
                return;
            }

            //get inputs
            Program.studentName = nameTextBox.Text;
            Program.cwid = (int)cwidInputBox.Value;
            Program.testID = testIDtextBox.Text;

            //lanch main program
            Program.hasUnitTest = false;
            Form1 f1 = new Form1();
            f1.ShowDialog(); 
            this.Hide();
        }

        private void cwidInputBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}