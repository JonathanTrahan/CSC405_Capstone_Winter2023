namespace Code_Trather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string download = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py";
            File.Create(download).Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e) {
            File.WriteAllText(Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py", textInput.Text);
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py";
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            string error = pProcess.StandardError.ReadToEnd();
            pProcess.WaitForExit();
            textOutput.Text = output + error;

        }
    }
}