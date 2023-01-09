using System;
using System.Windows.Forms;
using System.Drawing;

namespace TextEditor
{
    public class TextEditorForm : Form
    {
        private TextBox textBox;
        private string fileName;

        public TextEditorForm()
        {
            // Set up the form
            this.ClientSize = new Size(600, 400);
            this.Text = "Text Editor";

            // Create the text box
            textBox = new TextBox();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font(FontFamily.GenericMonospace, 12);
            textBox.Multiline = true;
            textBox.WordWrap = false;
            this.Controls.Add(textBox);

            // Set up the menu
            MenuStrip menuStrip = new MenuStrip();
            this.Controls.Add(menuStrip);

            // File menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            menuStrip.Items.Add(fileMenu);

            // File > New
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New");
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newMenuItem.Click += (sender, args) => NewFile();
            fileMenu.DropDownItems.Add(newMenuItem);

            // File > Open
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open...");
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Click += (sender, args) => OpenFile();
            fileMenu.DropDownItems.Add(openMenuItem);

            // File > Save
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save");
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Click += (sender, args) => SaveFile();
            fileMenu.DropDownItems.Add(saveMenuItem);

            // File > Save As...
            ToolStripMenuItem saveAsMenuItem = new ToolStripMenuItem("Save As...");
            saveAsMenuItem.Click += (sender, args) => SaveFileAs();
            fileMenu.DropDownItems.Add(saveAsMenuItem);

            // Set up the open file dialog
            openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Python Files (*.py)|*.py|All Files (*.*)|*.*";
            openFileDialog.Filter = "Python Files (*.py)|*.py";


            // Set up the save file dialog
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        }

        private void NewFile()
        {
            // Clear the text box and reset the file name
            textBox.Clear();
            fileName = null;
        }

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the contents of the file into the text box
                textBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
            }
        }

        private void SaveFile()
        {
            if (fileName == null)
            {
                // If the file has not been saved before, show the Save As dialog
                SaveFileAs();
            }
            else
            {
                // Otherwise, save the file
                System.IO.File.WriteAllText(fileName, textBox.Text);
            }
        }

        private void SaveFileAs()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the file and update the file name
                System.IO.File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                fileName = saveFileDialog.FileName;
            }
        }

        // Set up the open file dialog
        private OpenFileDialog openFileDialog;

        // Set up the save file dialog
        private SaveFileDialog saveFileDialog;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TextEditorForm());
        }
    }
}

