using ScintillaNET;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_Trather
{
    public partial class Form1 : Form
    {
        // Declare CspParmeters and RsaCryptoServiceProvider
        readonly CspParameters _cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
        const string KeyName = "Key01";

        public Form1()
        {
            InitializeComponent();
            // path that file will be saved at
            Directory.CreateDirectory(Globals.filePath);
            System.IO.File.Create(Globals.downloadAddress).Close();
            WriteTo.CreateFiles();

            // create folder for encryption
            Directory.CreateDirectory(Globals.cryptFolder);

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
            if (error != "")
            {
                WriteTo.writeToError(error);
            }
            pProcess.WaitForExit();
            Globals.inputFilePath = "";
            return output + error;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            Trace.WriteLine("Timer");
            WriteTo.writeToSnapshotHTML(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            Clipboard.Clear();
            WriteTo.writeToKeyLoggerHTML(Globals.keyTracker);
            Globals.keyTracker = "";
            //WriteTo.writeToKeyLoggerHTML("Timer");
        }

        private OpenFileDialog openFileDialog;
        private OpenFileDialog inputFile;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Load the contents of the file into the text box
                textInput.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e) {
            System.IO.File.WriteAllText(Globals.downloadAddress, textInput.Text);
            WriteTo.writeToSnapshotHTML(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            WriteTo.Complete();
            Globals.DONE = true;
            
            encryptSubmit();
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

        private void createKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            var _rsa = new RSACryptoServiceProvider(2048);

            //how to get the private key
            var privKey = _rsa.ExportParameters(true);

            //and the public key ...
            var pubKey = _rsa.ExportParameters(false);

            //converting the public key into a string representation
            string pubKeyString;
            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                //get the string from the stream
                pubKeyString = sw.ToString();
            }

            //converting the public key into a string representation
            string privKeyString;
            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privKeyString = sw.ToString();
            }

            keyTextFile(privKeyString, true);
            keyTextFile(pubKeyString, false);
        }

        private void keyTextFile(string key, bool which_key)
        {
            // Save the public key created by the RSA
            // to a file. Caution, persisting the
            // key to a file is a security risk.
            //Directory.CreateDirectory(Globals.cryptFolder);

            if (which_key)
            {
                using (var sw = new StreamWriter(Globals.PrivKeyFile, false))
                {
                    sw.Write(key);
                }
            }
            else
            {
                using (var sw = new StreamWriter(Globals.PubKeyFile, false))
                {
                    sw.Write(key);
                }
            }
        }

        private void EncryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric encryption of the data.
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();

            // Use RSACryptoServiceProvider to
            // encrypt the AES key.
            // rsa is previously instantiated:
            //    rsa = new RSACryptoServiceProvider(cspp);
            byte[] keyEncrypted = _rsa.Encrypt(aes.Key, false);

            // Create byte arrays to contain
            // the length values of the key and IV.
            int lKey = keyEncrypted.Length;
            byte[] LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            byte[] LenIV = BitConverter.GetBytes(lIV);

            // Write the following to the FileStream
            // for the encrypted file (outFs):
            // - length of the key
            // - length of the IV
            // - ecrypted key
            // - the IV
            // - the encrypted cipher content

            // Change the file's extension to ""
            string outFile =
                Path.Combine(Globals.cryptFolder, Path.ChangeExtension(file.Name, ""));

            using (var outFs = new FileStream(outFile, FileMode.Create))
            {
                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                outFs.Write(keyEncrypted, 0, lKey);
                outFs.Write(aes.IV, 0, lIV);

                // Now write the cipher text using
                // a CryptoStream for encrypting.
                using (var outStreamEncrypted =
                    new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {
                    // By encrypting a chunk at
                    // a time, you can save memory
                    // and accommodate large files.
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (var inFs = new FileStream(file.FullName, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        } while (count > 0);
                    }
                    outStreamEncrypted.FlushFinalBlock();
                }
            }
        }

        private void DecryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric decryption of the data.
            Aes aes = Aes.Create();

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construct the file name for the decrypted file.
            string outFile =
                Path.ChangeExtension(file.FullName.Replace("Encrypt", "Decrypt"), ".zip");

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (var inFs = new FileStream(file.FullName, FileMode.Open))
            {
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Aes key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                //Directory.CreateDirectory(Globals.cryptFolder);
                // Use RSACryptoServiceProvider
                // to decrypt the AES key.
                byte[] KeyDecrypted = _rsa.Decrypt(KeyEncrypted, false);

                // Decrypt the key.
                ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];

                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (var outStreamDecrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);
                        } while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                    }
                }
            }
        }

        private void encryptSubmit()
        {
            using (var sr = new StreamReader(Globals.PubKeyFile))
            {
                _cspp.KeyContainerName = KeyName;
                _rsa = new RSACryptoServiceProvider(_cspp);

                string keytxt = sr.ReadToEnd();
                _rsa.FromXmlString(keytxt);
                _rsa.PersistKeyInCsp = true;
            }

            System.IO.File.Delete(Globals.filePathZip);
            System.IO.Compression.ZipFile.CreateFromDirectory(Globals.filePath, Globals.filePathZip);

            EncryptFile(new FileInfo(Globals.filePathZip));

            System.IO.Directory.Delete(Globals.filePath, true);
            System.IO.File.Delete(Globals.filePathZip);
        }

        private void decryptSubmit()
        {
            using (var sr = new StreamReader(Globals.PrivKeyFile))
            {
                _cspp.KeyContainerName = KeyName;
                _rsa = new RSACryptoServiceProvider(_cspp);

                string keytxt = sr.ReadToEnd();
                _rsa.FromXmlString(keytxt);
                _rsa.PersistKeyInCsp = true;
            }

            DecryptFile(new FileInfo(Globals.encryptedZip));
        }

        private void decryptFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decryptSubmit();
        }

        private void KeyRecorder(object sender, KeyPressEventArgs e)
        {
            
           // WriteTo.writeToKeyLoggerHTML(e.KeyData.ToString());

        }
        
        private void keydownrec(object sender, KeyEventArgs e)
        {
            if (Globals.hotKeys.Any(e.KeyData.ToString().Contains))
            {
                WriteTo.writeToHotKeyHTML(e.KeyData.ToString());
            }
     
            
            Globals.keyTracker += e.KeyData.ToString();
            Globals.keyTracker += "\n";

        }

        private void fifteenSecTimer(object sender, EventArgs e)
        {
            WriteTo.writeToKeyLoggerHTML(Globals.keyTracker);
            Globals.keyTracker = "";
            WriteTo.writeToKeyLoggerHTML("Timer");
        }
    }
}