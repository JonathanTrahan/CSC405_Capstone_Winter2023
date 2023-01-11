namespace Code_Trather
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            string download = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py";
            //File.Create("C:/Users/meaga/Desktop/file.py");
            //string file = download + "/file.py";
            File.Create(download).Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            File.WriteAllText(Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py", textBox1.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void button2_Click(object sender, EventArgs e) {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/C python " + Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/file.py";
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            string error = pProcess.StandardError.ReadToEnd();
            pProcess.WaitForExit();
            label1.Text = output + error;
        }
    }
}