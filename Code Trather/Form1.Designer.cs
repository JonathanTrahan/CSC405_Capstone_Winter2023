namespace Code_Trather
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            textInput = new ScintillaNET.Scintilla();
            button1 = new Button();
            enterInput = new Button();
            userInput = new TextBox();
            textOutput = new TextBox();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            toolStrip1 = new ToolStrip();
            File = new ToolStripDropDownButton();
            saveTSM = new ToolStripMenuItem();
            submitTSM = new ToolStripMenuItem();
            Test = new ToolStripDropDownButton();
            runTSM = new ToolStripMenuItem();
            unitTestTSM = new ToolStripMenuItem();
            toolsDropDown = new ToolStripDropDownButton();
            magnifyTSM = new ToolStripMenuItem();
            zoomInTSM = new ToolStripMenuItem();
            zoomOutTSM = new ToolStripMenuItem();
            zoom100TSM = new ToolStripMenuItem();
            lang = new ToolStripDropDownButton();
            switchToPy = new ToolStripMenuItem();
            switchToJava = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(11, 56);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(textInput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(enterInput);
            splitContainer1.Panel2.Controls.Add(userInput);
            splitContainer1.Panel2.Controls.Add(textOutput);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1335, 611);
            splitContainer1.SplitterDistance = 908;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // textInput
            // 
            textInput.AutoCMaxHeight = 9;
            textInput.Dock = DockStyle.Fill;
            textInput.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            textInput.Location = new Point(0, 0);
            textInput.Name = "textInput";
            textInput.Size = new Size(908, 611);
            textInput.TabIndents = true;
            textInput.TabIndex = 4;
            textInput.InsertCheck += textInput_InsertCheck;
            textInput.KeyDown += keydownrec;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(298, 519);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // enterInput
            // 
            enterInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            enterInput.Enabled = false;
            enterInput.Location = new Point(297, 557);
            enterInput.Margin = new Padding(3, 4, 3, 4);
            enterInput.Name = "enterInput";
            enterInput.Size = new Size(86, 29);
            enterInput.TabIndex = 2;
            enterInput.Text = "Enter";
            enterInput.UseVisualStyleBackColor = true;
            enterInput.Click += enterInput_Click;
            // 
            // userInput
            // 
            userInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userInput.Location = new Point(18, 541);
            userInput.Margin = new Padding(3, 4, 3, 4);
            userInput.Name = "userInput";
            userInput.ReadOnly = true;
            userInput.Size = new Size(248, 27);
            userInput.TabIndex = 1;
            // 
            // textOutput
            // 
            textOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textOutput.Location = new Point(0, 0);
            textOutput.Multiline = true;
            textOutput.Name = "textOutput";
            textOutput.ReadOnly = true;
            textOutput.Size = new Size(413, 511);
            textOutput.TabIndex = 0;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 3000;
            UpdateTimer.Tick += UpdateTime;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { File, Test, toolsDropDown, lang });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(1359, 27);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            File.AccessibleName = "File";
            File.DisplayStyle = ToolStripItemDisplayStyle.Text;
            File.DropDownItems.AddRange(new ToolStripItem[] { saveTSM, submitTSM });
            File.Name = "File";
            File.Size = new Size(46, 24);
            File.Text = "File";
            // 
            // saveTSM
            // 
            saveTSM.Name = "saveTSM";
            saveTSM.Size = new Size(139, 26);
            saveTSM.Text = "Save";
            saveTSM.Click += saveToolStripMenuItem_Click;
            // 
            // submitTSM
            // 
            submitTSM.Name = "submitTSM";
            submitTSM.Size = new Size(139, 26);
            submitTSM.Text = "Submit";
            submitTSM.Click += submitToolStripMenuItem_Click;
            // 
            // Test
            // 
            Test.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Test.DropDownItems.AddRange(new ToolStripItem[] { runTSM, unitTestTSM });
            Test.Image = (Image)resources.GetObject("Test.Image");
            Test.ImageTransparentColor = Color.Magenta;
            Test.Name = "Test";
            Test.Size = new Size(49, 24);
            Test.Text = "Test";
            // 
            // runTSM
            // 
            runTSM.Name = "runTSM";
            runTSM.Size = new Size(149, 26);
            runTSM.Text = "Run";
            runTSM.Click += runToolStripMenuItem_Click;
            // 
            // unitTestTSM
            // 
            unitTestTSM.Name = "unitTestTSM";
            unitTestTSM.Size = new Size(149, 26);
            unitTestTSM.Text = "Unit Test";
            unitTestTSM.Click += runToolUnitTest;
            // 
            // toolsDropDown
            // 
            toolsDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolsDropDown.DropDownItems.AddRange(new ToolStripItem[] { magnifyTSM });
            toolsDropDown.Image = (Image)resources.GetObject("toolsDropDown.Image");
            toolsDropDown.ImageTransparentColor = Color.Magenta;
            toolsDropDown.Name = "toolsDropDown";
            toolsDropDown.Size = new Size(58, 24);
            toolsDropDown.Text = "Tools";
            // 
            // magnifyTSM
            // 
            magnifyTSM.DropDownItems.AddRange(new ToolStripItem[] { zoomInTSM, zoomOutTSM, zoom100TSM });
            magnifyTSM.Name = "magnifyTSM";
            magnifyTSM.Size = new Size(146, 26);
            magnifyTSM.Text = "Magnify";
            // 
            // zoomInTSM
            // 
            zoomInTSM.Name = "zoomInTSM";
            zoomInTSM.Size = new Size(172, 26);
            zoomInTSM.Text = "Zoom In";
            zoomInTSM.Click += zoomInToolStripMenuItem_Click;
            // 
            // zoomOutTSM
            // 
            zoomOutTSM.Name = "zoomOutTSM";
            zoomOutTSM.Size = new Size(172, 26);
            zoomOutTSM.Text = "Zoom Out";
            zoomOutTSM.Click += zoomOutToolStripMenuItem_Click;
            // 
            // zoom100TSM
            // 
            zoom100TSM.Name = "zoom100TSM";
            zoom100TSM.Size = new Size(172, 26);
            zoom100TSM.Text = "Zoom 100%";
            zoom100TSM.Click += zoom100ToolStripMenuItem_Click;
            // 
            // lang
            // 
            lang.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lang.DropDownItems.AddRange(new ToolStripItem[] { switchToPy, switchToJava });
            lang.Image = (Image)resources.GetObject("lang.Image");
            lang.ImageTransparentColor = Color.Magenta;
            lang.Name = "lang";
            lang.Size = new Size(88, 24);
            lang.Text = "Language";
            // 
            // switchToPy
            // 
            switchToPy.Checked = true;
            switchToPy.CheckState = CheckState.Checked;
            switchToPy.Name = "switchToPy";
            switchToPy.Size = new Size(224, 26);
            switchToPy.Text = "Python";
            switchToPy.Click += switchToPy_Click;
            // 
            // switchToJava
            // 
            switchToJava.Name = "switchToJava";
            switchToJava.Size = new Size(224, 26);
            switchToJava.Text = "Java";
            switchToJava.Click += switchToJava_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 691);
            Controls.Add(toolStrip1);
            Controls.Add(splitContainer1);
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SplitContainer splitContainer1;
        private TextBox textOutput;
        private System.Windows.Forms.Timer UpdateTimer;
        private ScintillaNET.Scintilla textInput;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton File;
        private ToolStripMenuItem saveTSM;
        private ToolStripMenuItem submitTSM;
        private ToolStripDropDownButton Test;
        private ToolStripMenuItem runTSM;
        private ToolStripMenuItem unitTestTSM;
        private ToolStripDropDownButton toolsDropDown;
        private ToolStripMenuItem magnifyTSM;
        private ToolStripMenuItem zoomInTSM;
        private ToolStripMenuItem zoomOutTSM;
        private ToolStripMenuItem zoom100TSM;
        private Button enterInput;
        private TextBox userInput;
        private Button button1;
        private ToolStripDropDownButton lang;
        private ToolStripMenuItem switchToPy;
        private ToolStripMenuItem switchToJava;
    }
}