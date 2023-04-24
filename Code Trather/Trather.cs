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
    /// <summary>
    /// Form that the contains the area that the students can code, run test, and submit their code
    /// </summary>
    public partial class Trather : Form
    {
        StreamWriter myStreamWriter;
        bool isjava = false;

        public Trather()
        {
            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

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

            // Character
            textInput.Styles[Style.Python.Character].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.Character].BackColor = IntToColor(0xFFFFFF);

            // ClassName
            textInput.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x0000FF);
            textInput.Styles[Style.Python.ClassName].BackColor = IntToColor(0xFFFFFF);

            // CommentBlock
            textInput.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x808080);
            textInput.Styles[Style.Python.CommentBlock].BackColor = IntToColor(0xFFFFFF);

            // CommentLine
            textInput.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x808080);
            textInput.Styles[Style.Python.CommentLine].BackColor = IntToColor(0xFFFFFF);

            // Decorator
            textInput.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFF8000);
            textInput.Styles[Style.Python.Decorator].BackColor = IntToColor(0xFFFFFF);

            // DefName
            textInput.Styles[Style.Python.DefName].ForeColor = IntToColor(0x0000FF);
            textInput.Styles[Style.Python.DefName].BackColor = IntToColor(0xFFFFFF);

            // Identifier
            textInput.Styles[Style.Python.Identifier].ForeColor = IntToColor(0x000000);
            textInput.Styles[Style.Python.Identifier].BackColor = IntToColor(0xFFFFFF);

            // Number
            textInput.Styles[Style.Python.Number].ForeColor = IntToColor(0xFF8000);
            textInput.Styles[Style.Python.Number].BackColor = IntToColor(0xFFFFFF);

            // Operator
            textInput.Styles[Style.Python.Operator].ForeColor = IntToColor(0x000000);
            textInput.Styles[Style.Python.Operator].BackColor = IntToColor(0xFFFFFF);

            // String
            textInput.Styles[Style.Python.String].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.String].BackColor = IntToColor(0xFFFFFF);

            // StringEol
            textInput.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.StringEol].BackColor = IntToColor(0xFFFFFF);

            // Triple
            textInput.Styles[Style.Python.Triple].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.Triple].BackColor = IntToColor(0xFFFFFF);

            // TripleDouble
            textInput.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0x00AA00);
            textInput.Styles[Style.Python.TripleDouble].BackColor = IntToColor(0xFFFFFF);

            // Word
            textInput.Styles[Style.Python.Word].ForeColor = IntToColor(0xFF7700);
            textInput.Styles[Style.Python.Word].BackColor = IntToColor(0xFFFFFF);

            // Word2
            textInput.Styles[Style.Python.Word2].ForeColor = IntToColor(0x900090);
            textInput.Styles[Style.Python.Word2].BackColor = IntToColor(0xFFFFFF);

            textInput.Lexer = Lexer.Python;

            // Word
            textInput.SetKeywords(0, "False await else import pass None break except in raise True class finally is return and continue for lambda try as def from nonlocal while assert del global not with async elif if or yield");
            // Word2
            textInput.SetKeywords(1, "self ArithmeticError AssertionError AttributeError BaseException BlockingIOError BrokenPipeError BufferError BytesWarning ChildProcessError ConnectionAbortedError ConnectionError ConnectionRefusedError ConnectionResetError DeprecationWarning EOFError Ellipsis EnvironmentError Exception FileExistsError FileNotFoundError FloatingPointError FutureWarning GeneratorExit IOError ImportError ImportWarning IndentationError IndexError InterruptedError IsADirectoryError KeyError KeyboardInterrupt LookupError MemoryError ModuleNotFoundError NameError NotADirectoryError NotImplemented NotImplementedError OSError OverflowError PendingDeprecationWarning PermissionError ProcessLookupError RecursionError ReferenceError ResourceWarning RuntimeError RuntimeWarning StopAsyncIteration StopIteration SyntaxError SyntaxWarning SystemError SystemExit TabError TimeoutError TypeError UnboundLocalError UnicodeDecodeError UnicodeEncodeError UnicodeError UnicodeTranslateError UnicodeWarning UserWarning ValueError Warning WindowsError ZeroDivisionError abs all any ascii bin bool breakpoint bytearray bytes callable chr classmethod compile complex copyright credits delattr dict dir divmod enumerate eval exec exit filter float format frozenset getattr globals hasattr hash help hex id input int isinstance issubclass iter len license list locals map max memoryview min next object oct open ord pow print property quit range repr reversed round set setattr slice sorted staticmethod str sum super tuple type vars zip");
        }

        /// <summary>
        /// Creates the lexer for the Java programming language.
        /// </summary>
        public void CreateJavaLexer()
        {
            // Configure the default style
            textInput.StyleResetDefault();
            textInput.Styles[Style.Default].Font = "Courier New";
            textInput.Styles[Style.Default].Size = 10;
            textInput.Styles[Style.Default].BackColor = IntToColor(0xFFFFFF);
            textInput.Styles[Style.Default].ForeColor = IntToColor(0x000000);
            textInput.StyleClearAll();

            // PREPROCESSOR
            textInput.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(128, 64, 0); // #804000
            textInput.Styles[Style.Cpp.Preprocessor].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // DEFAULT
            textInput.Styles[Style.Cpp.Default].ForeColor = Color.FromArgb(0, 0, 0); // #000000;
            textInput.Styles[Style.Cpp.Default].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // INSTRUCTION WORD
            textInput.Styles[Style.Cpp.Word].Bold = true;
            textInput.Styles[Style.Cpp.Word].ForeColor = Color.FromArgb(0, 0, 255); // #0000FF
            textInput.Styles[Style.Cpp.Word].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // TYPE WORD
            textInput.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(128, 0, 255); // #8000FF 
            textInput.Styles[Style.Cpp.Word2].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // NUMBER
            textInput.Styles[Style.Cpp.Number].ForeColor = Color.FromArgb(255, 128, 0); // #FF8000 
            textInput.Styles[Style.Cpp.Number].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // STRING
            textInput.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(128, 128, 128); // #808080 
            textInput.Styles[Style.Cpp.String].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // CHARACTER
            textInput.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(128, 128, 128); // #808080 
            textInput.Styles[Style.Cpp.Character].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // OPERATOR
            textInput.Styles[Style.Cpp.Operator].Bold = true;
            textInput.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(0, 0, 128); // #000080 
            textInput.Styles[Style.Cpp.Operator].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // VERBATIM
            textInput.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(0, 0, 0); // #000000 
            textInput.Styles[Style.Cpp.Verbatim].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // REGEX
            textInput.Styles[Style.Cpp.Regex].Bold = true;
            textInput.Styles[Style.Cpp.Regex].ForeColor = Color.FromArgb(0, 0, 0); // #000000 
            textInput.Styles[Style.Cpp.Regex].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT
            textInput.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // #008000 
            textInput.Styles[Style.Cpp.Comment].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT LINE
            textInput.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // #008000 
            textInput.Styles[Style.Cpp.CommentLine].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT DOC
            textInput.Styles[Style.Cpp.CommentDoc].ForeColor = Color.FromArgb(0, 128, 128); // #008080 
            textInput.Styles[Style.Cpp.CommentDoc].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT LINE DOC
            textInput.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(0, 128, 128); // #008080 
            textInput.Styles[Style.Cpp.CommentLineDoc].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT DOC KEYWORD
            textInput.Styles[Style.Cpp.CommentDocKeyword].Bold = true;
            textInput.Styles[Style.Cpp.CommentDocKeyword].ForeColor = Color.FromArgb(0, 128, 128); // #008080 
            textInput.Styles[Style.Cpp.CommentDocKeyword].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            // COMMENT DOC KEYWORD ERROR
            textInput.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = Color.FromArgb(0, 128, 128); // #008080 
            textInput.Styles[Style.Cpp.CommentDocKeywordError].BackColor = Color.FromArgb(255, 255, 255); // #FFFFFF

            textInput.Lexer = Lexer.Cpp;

            textInput.SetKeywords(0, "instanceof assert if else switch case default break goto return for while do continue new throw throws try catch finally this super extends implements import true false null");
            textInput.SetKeywords(1, "package transient strictfp void char short int long double float const static volatile byte boolean class interface native private protected public final abstract synchronized enum");
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
            if (isjava)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C java " + Globals.downloadAddressJava + " " + Globals.inputFilePath;
                // code either compiles or it doesn't
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                // start the command prompt
                process.Start();

                myStreamWriter = process.StandardInput;

                string output = "";
                while (!process.StandardOutput.EndOfStream)
                {
                    char val = (char)process.StandardOutput.Read();
                    var threadParam = new System.Threading.ThreadStart(delegate { UpdateOutput(val); });
                    var thread2 = new System.Threading.Thread(threadParam);
                    thread2.Start();
                    thread2.Join();
                    output += val;

                    if (buttonWasClicked)
                    {
                        process.Close();
                        buttonWasClicked = false;
                        return output;
                    }

                }
                string error = process.StandardError.ReadToEnd();

                if (error != "")
                {
                    WriteTo.writeToError(error);
                    List<string> errorList = error.Split(' ').ToList();
                    appendError(error, Globals.errorList);
                }
                process.WaitForExit();
                Globals.inputFilePath = "";
                return output + error;
            }
            else
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
                while (!process.StandardOutput.EndOfStream)
                {
                    char val = (char)process.StandardOutput.Read();
                    var threadParam = new System.Threading.ThreadStart(delegate { UpdateOutput(val); });
                    var thread2 = new System.Threading.Thread(threadParam);
                    thread2.Start();
                    thread2.Join();
                    output += val;

                    if (buttonWasClicked)
                    {
                        process.Close();
                        buttonWasClicked = false;
                        return output;
                    }

                }
                string error = process.StandardError.ReadToEnd();

                if (error != "")
                {
                    WriteTo.writeToError(error);
                    List<string> errorList = error.Split(' ').ToList();
                    appendError(error, Globals.errorList);
                }
                process.WaitForExit();
                Globals.inputFilePath = "";
                return output + error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorList"></param>
        private void appendError(string error, List<string> errorList)
        {

            foreach (var e in errorList)
            {
                if (error.Contains(e))
                {
                    Globals.words.Add(e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        private void UpdateOutput(char line)
        {
            if (textOutput.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateOutput(line); };
                textOutput.Invoke(safeWrite);
            }
            else
            {
                textOutput.Text += line;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTime(object sender, EventArgs e)
        {
            WriteTo.writeToSnapshotHTML(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            //Clipboard.Clear();
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
            //System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            saveAssignment();
        }

        /// <summary>
        /// submitToolStripMenuItem_Click
        /// final save of all text in the input textbox to the assignment file
        /// then encrypts the folder containing the assigment and all logs
        /// finally it exits the program
        /// </summary>
        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            //System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            saveAssignment();

            textOutput.Text = "";
            userInput.ReadOnly = false;
            enterInput.Enabled = true;
            string result = await Task.Run(() => runProcess());
            textOutput.Text = result;
            WriteTo.writeToOutput(result);
            userInput.ReadOnly = true;
            enterInput.Enabled = false;
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

        /*private void decryptFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cryptog.decryptSubmit();
        }*/

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            saveAssignment();

            List<string> newWord = Globals.listReader(Globals.words);
            List<string> usedKeys = Globals.listReader(Globals.usedHotKeys);
            System.IO.File.AppendAllText(Globals.execSum, ",");
            foreach (var word in newWord)
            {
                System.IO.File.AppendAllText(Globals.execSum, word);
                Console.WriteLine(word + " ");
            }
            System.IO.File.AppendAllText(Globals.execSum, ",");
            foreach (var word in usedKeys)
            {
                System.IO.File.AppendAllText(Globals.execSum, word);
                Console.WriteLine(word + " ");
            }

            WriteTo.Complete();
            Globals.DONE = true;
            Cryptog.encryptSubmit();
            Application.Exit();
        }

        /// <summary>
        /// enterInput_Click
        /// redirects input enter by user in <see cref="userInput"/> to command line
        /// </summary>
        private void enterInput_Click(object sender, EventArgs e)
        {
            if (userInput.Text != null)
            {
                myStreamWriter.WriteLine(userInput.Text);
                userInput.Text = "";
            }

        }
        /// <summary>
        /// Records what keys are pressed. Will record key presses to log file every update interval 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keydownrec(object sender, KeyEventArgs e)
        {
            string write = e.KeyData.ToString();
            if (e.KeyData.ToString().Any(",".Contains))
            {
                write = WriteTo.addPlus(write);
            }
            if (Globals.hotKeys.Any(e.KeyData.ToString().Contains))
            {
                if (!Globals.nonHotKeys.Any(e.KeyData.ToString().Contains))
                {
                    WriteTo.writeToHotKeyHTML(write);
                }
            }


            Globals.keyTracker += write;
            Globals.keyTracker += "\n";
        }

        private string runUnitTest()
        {
            if (isjava)
            {
                Process jProcess = new Process();
                jProcess.StartInfo.UseShellExecute = false;
                jProcess.StartInfo.FileName = "cmd.exe";
                jProcess.StartInfo.Arguments = @"/c cd " + Globals.filePath + @" && javac " + Globals.javaUnitTestVersion + @" && java " + Globals.unitTestFilePathJava + @" && cd ..";
                // code either compiles or it doesn't
                jProcess.StartInfo.RedirectStandardOutput = true;
                jProcess.StartInfo.RedirectStandardError = true;
                // start the command prompt
                jProcess.Start();
                string output = jProcess.StandardOutput.ReadToEnd();
                string error = jProcess.StandardError.ReadToEnd();
                jProcess.WaitForExit();
                Globals.inputFilePath = "";
                return output + error;
            }
            else
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
        }

        private async void runToolUnitTest(object sender, EventArgs e)
        {
            //System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            saveAssignment();

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

        private bool buttonWasClicked = false;
        private void button1_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to close the application. You will NOT be able to view/edit your work. Close application and submit work?", "Are you sure you want to quit?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Auto indents when a \n is added after a ':' or a '{'. if a \n is added between two brackets {\n}, then add indent and another \n for formatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textInput_InsertCheck(object sender, InsertCheckEventArgs e)
        {
            if (e.Text.EndsWith("\r") || e.Text.EndsWith("\n"))
            {
                int startPos = textInput.Lines[textInput.LineFromPosition(textInput.CurrentPosition)].Position;
                int endPos = e.Position;
                string curLineText = textInput.GetTextRange(startPos, (endPos - startPos)); //Text until the caret.
                // get the first group of spaces/tabs
                Match indent = Regex.Match(curLineText, @"^[ \s\t]*");
                string spaces = new string(' ', (indent.Value.Length / 4) * 4);

                e.Text = e.Text + spaces;
                if (Regex.IsMatch(curLineText, @"^[ \s\t]*(def|for|while|if|elif|else|try|except|finally|with).*:$"))
                {
                    e.Text = e.Text + new string(' ', 4);
                }
                else if (Regex.IsMatch(curLineText, @"^[ \s\t]*.*{$"))
                {
                    e.Text = e.Text + new string(' ', 4);
                }
            }
        }

        private void saveAssignment()
        {
            if (isjava)
            {
                System.IO.File.WriteAllText(Globals.downloadAddressJava, textInput.Text);
                System.IO.File.WriteAllText(Globals.javaUnitTestVersion, "package Test;\r\n\r\n" + textInput.Text);
            }
            else
            {
                System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            }
        }

        private void switchToJava_Click(object sender, EventArgs e)
        {
            isjava = true;
            CreateJavaLexer();
            switchToPy.Checked = false;
            switchToJava.Checked = true;
        }

        private void switchToPy_Click(object sender, EventArgs e)
        {
            isjava = false;
            InitPythonSyntaxColoring();
            switchToPy.Checked = true;
            switchToJava.Checked = false;
        }
    }
}