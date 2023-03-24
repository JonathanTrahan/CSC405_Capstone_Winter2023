using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            // path that file will be saved at
            Directory.CreateDirectory(Globals.filePath);
            System.IO.File.Create(Globals.downloadAddress).Close();
            

            // create folder for encryption
            Directory.CreateDirectory(Globals.cryptFolder);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private OpenFileDialog openFileDialog;

        //with unit test
        private void button1_Click(object sender, EventArgs e)
        {
            //check if inputs are full
            /*if (string.IsNullOrEmpty(nameTextBox.Text))
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
            }*/

            //get inputs
            Program.studentName = nameTextBox.Text;
            Program.cwid = (int)cwidInputBox.Value;
            Program.testID = testIDtextBox.Text;
            Program.hasUnitTest = true;
            File.WriteAllText(Globals.execSum, nameTextBox.Text);
            File.AppendAllText(Globals.execSum, "," + cwidInputBox.Value.ToString());

            // Set up the open file dialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Python Files (*.py)|*.py";

            //open the main form if file has been selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file and save it in the output directory 
                string unitTestFile = openFileDialog.FileName;
                System.IO.File.WriteAllText(Globals.unitTestFilePath, System.IO.File.ReadAllText(unitTestFile));

                //lanch main program
                Program.hasUnitTest = true;
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
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
            string[] sName = Program.studentName.Split(' ');
            
            Globals.fName = sName[0];
            if (sName.Length > 1)
            {
                Globals.lName = sName[1];
            }

            Program.cwid = (int)cwidInputBox.Value;
            Program.testID = testIDtextBox.Text;
            Program.hasUnitTest = false;
            WriteTo.CreateFiles();
            File.WriteAllText(Globals.execSum, nameTextBox.Text);
            File.AppendAllText(Globals.execSum, "," + cwidInputBox.Value.ToString());

            //lanch main program
            Program.hasUnitTest = false;
            Form1 f1 = new Form1();
            f1.ShowDialog(); 
            this.Close();
        }

        private void cwidInputBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
