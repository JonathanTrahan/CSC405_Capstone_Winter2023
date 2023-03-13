using ScintillaNET;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System;

namespace Code_Trather
{
    public partial class Form1 : Form
    {
        StreamWriter myStreamWriter;

        public Form1()
        {
            InitializeComponent();

            // Set up the open file dialog
            openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Python Files (*.py)|*.py|All Files (*.*)|*.*";
            openFileDialog.Filter = "Python Files (*.py)|*.py";
            inputFile = new OpenFileDialog();
            inputFile.Filter = "Text files (*.txt) | *.txt";

            
            // initialize scintilla
            InitSelectionColor();
            InitPythonSyntaxColoring();
            InitNumberMargin();
        }

        #region ScintillaNET Stuff

        /// <summary>
        /// Helper function for converting a hex color value (in the form 0x000000) to a System.Drawing.Color structure
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        /// <summary>
        /// Initialize the background color for selected text
        /// </summary>
        private void InitSelectionColor()
        {
            textInput.SetSelectionBackColor(true, IntToColor(0xC0C0C0));
        }

        /// <summary>
        /// Defines the python syntax coloring
        /// </summary>
        private void InitPythonSyntaxColoring()
        {
            // Configure the default style
            textInput.StyleResetDefault();
            textInput.Styles[Style.Default].Font = "Courier New";
            textInput.Styles[Style.Default].Size = 10;
            textInput.Styles[Style.Default].BackColor = IntToColor(0xFFFFFF);
            textInput.Styles[Style.Default].ForeColor = IntToColor(0x000000);
            textInput.StyleClearAll();

            // Configure the Python lexer styles
            textInput.Styles[Style.Python.Character].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x0000FF);
            textInput.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x808080);
            textInput.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x808080);
            textInput.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFF8000);
            textInput.Styles[Style.Python.DefName].ForeColor = IntToColor(0x0000FF);
            textInput.Styles[Style.Python.Identifier].ForeColor = IntToColor(0x000000);
            textInput.Styles[Style.Python.Number].ForeColor = IntToColor(0x000000);
            textInput.Styles[Style.Python.Operator].ForeColor = IntToColor(0x000000);
            textInput.Styles[Style.Python.String].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.Triple].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.Word].ForeColor = IntToColor(0xFF7700);
            textInput.Styles[Style.Python.Word2].ForeColor = IntToColor(0x900090);

            textInput.Lexer = Lexer.Python;

            textInput.SetKeywords(0, "False await else import pass None break except in raise True class finally is return and continue for lambda try as def from nonlocal while assert del global not with async elif if or yield");
            textInput.SetKeywords(1, "self ArithmeticError AssertionError AttributeError BaseException BlockingIOError BrokenPipeError BufferError BytesWarning ChildProcessError ConnectionAbortedError ConnectionError ConnectionRefusedError ConnectionResetError DeprecationWarning EOFError Ellipsis EnvironmentError Exception FileExistsError FileNotFoundError FloatingPointError FutureWarning GeneratorExit IOError ImportError ImportWarning IndentationError IndexError InterruptedError IsADirectoryError KeyError KeyboardInterrupt LookupError MemoryError ModuleNotFoundError NameError NotADirectoryError NotImplemented NotImplementedError OSError OverflowError PendingDeprecationWarning PermissionError ProcessLookupError RecursionError ReferenceError ResourceWarning RuntimeError RuntimeWarning StopAsyncIteration StopIteration SyntaxError SyntaxWarning SystemError SystemExit TabError TimeoutError TypeError UnboundLocalError UnicodeDecodeError UnicodeEncodeError UnicodeError UnicodeTranslateError UnicodeWarning UserWarning ValueError Warning WindowsError ZeroDivisionError abs all any ascii bin bool breakpoint bytearray bytes callable chr classmethod compile complex copyright credits delattr dict dir divmod enumerate eval exec exit filter float format frozenset getattr globals hasattr hash help hex id input int isinstance issubclass iter len license list locals map max memoryview min next object oct open ord pow print property quit range repr reversed round set setattr slice sorted staticmethod str sum super tuple type vars zip");
        }

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0xE3E3E3;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0x828a91;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// Initialize the line number margin on the left side of the textInput
        /// </summary>
        private void InitNumberMargin()
        {
            textInput.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            textInput.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            textInput.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            textInput.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = textInput.Margins[NUMBER_MARGIN];
            nums.Width = 46;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        #endregion

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// runProcess 
        /// handles the creation, execution, and exit of command prompt process 
        /// also handles redirection of user input, code output, and error messages
        /// called by <see cref="runToolStripMenuItem_Click">
        /// </summary>
        private string runProcess()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C python " + Globals.downloadAddress + " " + Globals.inputFilePath;
            // code either compiles or it doesn't
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            // start the command prompt
            process.Start();

            myStreamWriter = process.StandardInput;

            string output = "";
            while (!process.StandardOutput.EndOfStream) {
                char val = (char)process.StandardOutput.Read();
                var threadParam = new System.Threading.ThreadStart(delegate { UpdateOutput(val); });
                var thread2 = new System.Threading.Thread(threadParam);
                thread2.Start();
                thread2.Join();
                output += val;

            }
            string error = process.StandardError.ReadToEnd();

            if (error != "") {
                WriteTo.writeToError(error);
            }
            process.WaitForExit();
            Globals.inputFilePath = "";
            if (error != "")
            {
                WriteTo.writeToError(error);
            }
            return output + error;
        }

        private void UpdateOutput(char line) {
            if (textOutput.InvokeRequired) {
                Action safeWrite = delegate { UpdateOutput(line); };
                textOutput.Invoke(safeWrite);
            }
            else {
                textOutput.Text += line;
            }
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            WriteTo.writeToSnapshotHTML(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            Clipboard.Clear();
            WriteTo.writeToKeyLoggerHTML(Globals.keyTracker);
            Globals.keyTracker = "";
        }

        private OpenFileDialog openFileDialog;
        private OpenFileDialog inputFile;

        /// <summary>
        /// saveToolStripMenuItem_Click 
        /// saves all text in the input textbox to an assignment file
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
        }

        /// <summary>
        /// openToolStripMenuItem_Click
        /// open a file from anywhere on the device and display its contents in the input text box
        /// *TO BE REMOVED IN FUTURE, MEANT FOR DEVELOPER TESTING PURPOSES*
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the contents of the file into the text box
                textInput.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// submitToolStripMenuItem_Click
        /// final save of all text in the input textbox to the assignment file
        /// then encrypts the folder containing the assigment and all logs
        /// finally it exits the program
        /// </summary>
        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            WriteTo.Complete();
            Globals.DONE = true;
            Cryptog.encryptSubmit();
            Application.Exit();
        }

        /// <summary>
        /// runToolStripMenuItem_Click
        /// asynchronous method that unlocks user input text box, calls <see cref="runProcess"/>
        /// sets output textbox to result returned by <see cref="runProcess"/>
        /// and writes necessary information to <see cref="Globals.snapshothtmlAddress"/> <see cref="Globals.clipboardhtmlAddress"/>, and <see cref="Globals.outputAddress"/> log files
        /// </summary>
        private async void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            textOutput.Text = "";
            userInput.ReadOnly = false;
            string result = await Task.Run(() => runProcess());
            textOutput.Text = result;
            WriteTo.writeToOutput(result);
            userInput.ReadOnly = true;
        }
        /// <summary>
        /// InputFile_Click
        /// allows user to select a text file to read input from
        /// *Likely to be removed in final version*
        /// </summary>
        private void InputFile_Click(object sender, EventArgs e)
        {
            if (inputFile.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(inputFile.FileName);
                Globals.inputFilePath = path;
            }
        }

        /// <summary>
        /// zoomInToolStripMenuItem_Click
        /// increase magnification of text in input text box
        /// </summary>
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInput.ZoomIn();
        }

        /// <summary>
        /// zoomOutToolStripMenuItem_Click
        /// decrease magnification of text in input text box
        /// </summary>
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInput.ZoomOut();
        }

        /// <summary>
        /// zoom100ToolStripMenuItem_Click
        /// reset magnification of text in input text box
        /// </summary>
        private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInput.Zoom = 0;
        }

        private void decryptFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //decryptSubmit();
            Cryptog.DecryptFile(Globals.encryptedZip, Globals.decryptedZip);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// enterInput_Click
        /// redirects input enter by user in <see cref="userInput"/> to command line
        /// </summary>
        private void enterInput_Click(object sender, EventArgs e) {
            myStreamWriter.WriteLine(userInput.Text);
            userInput.Text = "";
        }
        /// <summary>
        /// Records what keys are pressed. Will record key presses to log file every update interval 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keydownrec(object sender, KeyEventArgs e)
        {
            if (Globals.hotKeys.Any(e.KeyData.ToString().Contains))
            {
                WriteTo.writeToHotKeyHTML(e.KeyData.ToString());
            }


            Globals.keyTracker += e.KeyData.ToString();
            Globals.keyTracker += "\n";

        }



        private string runUnitTest()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            //pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Globals.unitTestFilePath + " " + Globals.inputFilePath;
            // code either compiles or it doesn't
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            // start the command prompt
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            string error = pProcess.StandardError.ReadToEnd();
            pProcess.WaitForExit();
            Globals.inputFilePath = "";
            return output + error;
        }

        private async void runToolUnitTest(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            textOutput.Text = "";
            string result = await Task.Run(() => runUnitTest());
            textOutput.Text = result;
            WriteTo.writeToOutput(result);
            if (Globals.DONE == false)
            {
                WriteTo.writeToFile(Globals.snapshothtmlAddress, Globals.htmlFoot);
                WriteTo.writeToFile(Globals.clipboardhtmlAddress, Globals.htmlFoot);
                WriteTo.writeToFile(Globals.outputAddress, Globals.htmlFoot);


                Globals.DONE = true;
            }
        }
    }
}