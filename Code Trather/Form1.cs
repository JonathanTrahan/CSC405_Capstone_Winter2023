using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Code_Trather
{
    public partial class Form1 : Form
    {
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
            // path that file will be saved at
            Directory.CreateDirectory(Globals.filePath);
            File.Create(Globals.downloadAddress).Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e) {
            // write to file at this path, overwrites what is currently in there
            File.WriteAllText(Globals.downloadAddress, textInput.Text);
        }

        private async void button1_Click(object sender, EventArgs e) {
            textOutput.Text = "";
            string result = await Task.Run(() =>  runProcess());
            textOutput.Text = result;

        }
        private string runProcess() {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Globals.downloadAddress;
            // code either compiles or it doesn't
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            // start the command prompt
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            string error = pProcess.StandardError.ReadToEnd();
            pProcess.WaitForExit(10);
            return output + error;

        }

        private void UpdateTime(object sender, EventArgs e)
        {
            WriteTo.writeToSnapshot(textInput.Text);
            WriteTo.writeToClipboard(Clipboard.GetText());
            Clipboard.Clear();
        }
    }
}