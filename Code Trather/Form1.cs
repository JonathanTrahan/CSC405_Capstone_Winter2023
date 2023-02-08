using ScintillaNET;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_Trather
{
    public partial class Form1 : Form
    {
        string[] keywords = { "False", "await", "else", "import", "pass", "None", "break", "except", "in", "raise", "True", "class", "finally", "is", "return", "and", "continue", "for", "lambda", "try", "as", "def", "from", "nonlocal", "while", "assert", "del", "global", "not", "with", "async", "elif", "if", "or", "yield" };
        Dictionary<string, string> keywordsDict = new Dictionary<string, string>() { { "False", "False" }, { "await", "await" }, { "else", "else" }, { "import", "import" }, { "pass", "pass" }, { "None", "None" }, { "break", "break" }, { "except", "except" }, { "in", "in" }, { "raise", "raise" }, { "True", "True" }, { "class", "class" }, { "finally", "finally" }, { "is", "is" }, { "return", "return" }, { "and", "and" }, { "continue", "continue" }, { "for", "for" }, { "lambda", "lambda" }, { "try", "try" }, { "as", "as" }, { "def", "def" }, { "from", "from" }, { "nonlocal", "nonlocal" }, { "while", "while" }, { "assert", "assert" }, { "del", "del" }, { "global", "global" }, { "not", "not" }, { "with", "with" }, { "async", "async" }, { "elif", "elif" }, { "if", "if" }, { "or", "or" }, { "yield", "yield" } };
        string[] builtins = { "ArithmeticError", "AssertionError", "AttributeError", "BaseException", "BlockingIOError", "BrokenPipeError", "BufferError", "BytesWarning", "ChildProcessError", "ConnectionAbortedError", "ConnectionError", "ConnectionRefusedError", "ConnectionResetError", "DeprecationWarning", "EOFError", "Ellipsis", "EnvironmentError", "Exception", "FileExistsError", "FileNotFoundError", "FloatingPointError", "FutureWarning", "GeneratorExit", "IOError", "ImportError", "ImportWarning", "IndentationError", "IndexError", "InterruptedError", "IsADirectoryError", "KeyError", "KeyboardInterrupt", "LookupError", "MemoryError", "ModuleNotFoundError", "NameError", "NotADirectoryError", "NotImplemented", "NotImplementedError", "OSError", "OverflowError", "PendingDeprecationWarning", "PermissionError", "ProcessLookupError", "RecursionError", "ReferenceError", "ResourceWarning", "RuntimeError", "RuntimeWarning", "StopAsyncIteration", "StopIteration", "SyntaxError", "SyntaxWarning", "SystemError", "SystemExit", "TabError", "TimeoutError", "TypeError", "UnboundLocalError", "UnicodeDecodeError", "UnicodeEncodeError", "UnicodeError", "UnicodeTranslateError", "UnicodeWarning", "UserWarning", "ValueError", "Warning", "WindowsError", "ZeroDivisionError", "abs", "all", "any", "ascii", "bin", "bool", "breakpoint", "bytearray", "bytes", "callable", "chr", "classmethod", "compile", "complex", "copyright", "credits", "delattr", "dict", "dir", "divmod", "enumerate", "eval", "exec", "exit", "filter", "float", "format", "frozenset", "getattr", "globals", "hasattr", "hash", "help", "hex", "id", "input", "int", "isinstance", "issubclass", "iter", "len", "license", "list", "locals", "map", "max", "memoryview", "min", "next", "object", "oct", "open", "ord", "pow", "print", "property", "quit", "range", "repr", "reversed", "round", "set", "setattr", "slice", "sorted", "staticmethod", "str", "sum", "super", "tuple", "type", "vars", "zip" };
        Dictionary<string, string> builtinsDict = new Dictionary<string, string>() { { "ArithmeticError", "ArithmeticError" }, { "AssertionError", "AssertionError" }, { "AttributeError", "AttributeError" }, { "BaseException", "BaseException" }, { "BlockingIOError", "BlockingIOError" }, { "BrokenPipeError", "BrokenPipeError" }, { "BufferError", "BufferError" }, { "BytesWarning", "BytesWarning" }, { "ChildProcessError", "ChildProcessError" }, { "ConnectionAbortedError", "ConnectionAbortedError" }, { "ConnectionError", "ConnectionError" }, { "ConnectionRefusedError", "ConnectionRefusedError" }, { "ConnectionResetError", "ConnectionResetError" }, { "DeprecationWarning", "DeprecationWarning" }, { "EOFError", "EOFError" }, { "Ellipsis", "Ellipsis" }, { "EnvironmentError", "EnvironmentError" }, { "Exception", "Exception" }, { "FileExistsError", "FileExistsError" }, { "FileNotFoundError", "FileNotFoundError" }, { "FloatingPointError", "FloatingPointError" }, { "FutureWarning", "FutureWarning" }, { "GeneratorExit", "GeneratorExit" }, { "IOError", "IOError" }, { "ImportError", "ImportError" }, { "ImportWarning", "ImportWarning" }, { "IndentationError", "IndentationError" }, { "IndexError", "IndexError" }, { "InterruptedError", "InterruptedError" }, { "IsADirectoryError", "IsADirectoryError" }, { "KeyError", "KeyError" }, { "KeyboardInterrupt", "KeyboardInterrupt" }, { "LookupError", "LookupError" }, { "MemoryError", "MemoryError" }, { "ModuleNotFoundError", "ModuleNotFoundError" }, { "NameError", "NameError" }, { "NotADirectoryError", "NotADirectoryError" }, { "NotImplemented", "NotImplemented" }, { "NotImplementedError", "NotImplementedError" }, { "OSError", "OSError" }, { "OverflowError", "OverflowError" }, { "PendingDeprecationWarning", "PendingDeprecationWarning" }, { "PermissionError", "PermissionError" }, { "ProcessLookupError", "ProcessLookupError" }, { "RecursionError", "RecursionError" }, { "ReferenceError", "ReferenceError" }, { "ResourceWarning", "ResourceWarning" }, { "RuntimeError", "RuntimeError" }, { "RuntimeWarning", "RuntimeWarning" }, { "StopAsyncIteration", "StopAsyncIteration" }, { "StopIteration", "StopIteration" }, { "SyntaxError", "SyntaxError" }, { "SyntaxWarning", "SyntaxWarning" }, { "SystemError", "SystemError" }, { "SystemExit", "SystemExit" }, { "TabError", "TabError" }, { "TimeoutError", "TimeoutError" }, { "TypeError", "TypeError" }, { "UnboundLocalError", "UnboundLocalError" }, { "UnicodeDecodeError", "UnicodeDecodeError" }, { "UnicodeEncodeError", "UnicodeEncodeError" }, { "UnicodeError", "UnicodeError" }, { "UnicodeTranslateError", "UnicodeTranslateError" }, { "UnicodeWarning", "UnicodeWarning" }, { "UserWarning", "UserWarning" }, { "ValueError", "ValueError" }, { "Warning", "Warning" }, { "WindowsError", "WindowsError" }, { "ZeroDivisionError", "ZeroDivisionError" }, { "abs", "abs" }, { "all", "all" }, { "any", "any" }, { "ascii", "ascii" }, { "bin", "bin" }, { "bool", "bool" }, { "breakpoint", "breakpoint" }, { "bytearray", "bytearray" }, { "bytes", "bytes" }, { "callable", "callable" }, { "chr", "chr" }, { "classmethod", "classmethod" }, { "compile", "compile" }, { "complex", "complex" }, { "copyright", "copyright" }, { "credits", "credits" }, { "delattr", "delattr" }, { "dict", "dict" }, { "dir", "dir" }, { "divmod", "divmod" }, { "enumerate", "enumerate" }, { "eval", "eval" }, { "exec", "exec" }, { "exit", "exit" }, { "filter", "filter" }, { "float", "float" }, { "format", "format" }, { "frozenset", "frozenset" }, { "getattr", "getattr" }, { "globals", "globals" }, { "hasattr", "hasattr" }, { "hash", "hash" }, { "help", "help" }, { "hex", "hex" }, { "id", "id" }, { "input", "input" }, { "int", "int" }, { "isinstance", "isinstance" }, { "issubclass", "issubclass" }, { "iter", "iter" }, { "len", "len" }, { "license", "license" }, { "list", "list" }, { "locals", "locals" }, { "map", "map" }, { "max", "max" }, { "memoryview", "memoryview" }, { "min", "min" }, { "next", "next" }, { "object", "object" }, { "oct", "oct" }, { "open", "open" }, { "ord", "ord" }, { "pow", "pow" }, { "print", "print" }, { "property", "property" }, { "quit", "quit" }, { "range", "range" }, { "repr", "repr" }, { "reversed", "reversed" }, { "round", "round" }, { "set", "set" }, { "setattr", "setattr" }, { "slice", "slice" }, { "sorted", "sorted" }, { "staticmethod", "staticmethod" }, { "str", "str" }, { "sum", "sum" }, { "super", "super" }, { "tuple", "tuple" }, { "type", "type" }, { "vars", "vars" }, { "zip", "zip" } };

        public Form1()
        {
            InitializeComponent();
            // path that file will be saved at
            Directory.CreateDirectory(Globals.filePath);
            System.IO.File.Create(Globals.downloadAddress).Close();

            // Set up the open file dialog
            openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Python Files (*.py)|*.py|All Files (*.*)|*.*";
            openFileDialog.Filter = "Python Files (*.py)|*.py";
            inputFile = new OpenFileDialog();
            inputFile.Filter = "Text files (*.txt) | *.txt";

            // styling
            InitColors();
            InitSyntaxColoring();
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitColors()
        {
            textInput.SetSelectionBackColor(true, IntToColor(0x114D9C));
        }

        private void InitSyntaxColoring()
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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private string runProcess() {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            //pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Globals.downloadAddress + " " + Globals.inputFilePath;
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

        private void UpdateTime(object sender, EventArgs e)
        {
            WriteTo.writeToSnapshot(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            Clipboard.Clear();
        }

        private OpenFileDialog openFileDialog;
        private OpenFileDialog inputFile;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Load the contents of the file into the text box
                textInput.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e) {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            Application.Exit();

        }

        private async void runToolStripMenuItem_Click(object sender, EventArgs e) {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            textOutput.Text = "";
            string result = await Task.Run(() => runProcess());
            textOutput.Text = result;
            WriteTo.writeToOutput(result);

        }

        private void InputFile_Click(object sender, EventArgs e) {
            if (inputFile.ShowDialog() == DialogResult.OK) {
                string path = Path.GetFullPath(inputFile.FileName);
                Globals.inputFilePath = path;
            }

        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e) {
            textInput.ZoomIn();

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e) {
            textInput.ZoomOut();

        }

        private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e) {
            textInput.Zoom = 0;

        }
    }
}