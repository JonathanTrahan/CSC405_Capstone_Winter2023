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
            Directory.CreateDirectory(Program.filePath);
            File.Create(Program.download).Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e) {
            // write to file at this path, overwrites what is currently in there
            File.WriteAllText(Program.download, textInput.Text);
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            // compile through the command prompt
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Program.download;
            // code either compiles or it doesn't
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            // start the command prompt
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            string error = pProcess.StandardError.ReadToEnd();
            pProcess.WaitForExit(50);
            textOutput.Text = output + error;

        }

        private void timer1_Tick(object sender, EventArgs e) {

        }
    }
}