namespace Code_Trather
{
    partial class Trather
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trather));
            splitContainer1 = new SplitContainer();
            textInput = new ScintillaNET.Scintilla();
            stopBTN = new Button();
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(11, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textInput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(stopBTN);
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
            this.textInput.AutoCMaxHeight = 9;
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.textInput.Location = new System.Drawing.Point(0, 0);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(908, 611);
            this.textInput.TabIndents = true;
            this.textInput.TabIndex = 4;
            // 
            // stopBTN
            // 
            stopBTN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            stopBTN.Location = new Point(290, 519);
            stopBTN.Margin = new Padding(3, 4, 3, 4);
            stopBTN.Name = "stopBTN";
            stopBTN.Size = new Size(86, 31);
            stopBTN.TabIndex = 3;
            stopBTN.Text = "Stop";
            stopBTN.UseVisualStyleBackColor = true;
            stopBTN.Click += stopBTN_Click;
            // 
            // enterInput
            // 
            enterInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            enterInput.Enabled = false;
            enterInput.Location = new Point(289, 557);
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
            userInput.Size = new Size(240, 27);
            userInput.TabIndex = 1;
            // 
            // textOutput
            // 
            textOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textOutput.Location = new Point(0, 0);
            textOutput.Multiline = true;
            textOutput.Name = "textOutput";
            textOutput.ReadOnly = true;
            textOutput.Size = new Size(405, 511);
            textOutput.TabIndex = 0;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 3000;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Test,
            this.toolsDropDown,
            this.lang});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1359, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.AccessibleName = "File";
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTSM,
            this.submitTSM});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(46, 24);
            this.File.Text = "File";
            // 
            // saveTSM
            // 
            saveTSM.Name = "saveTSM";
            saveTSM.Size = new Size(139, 26);
            saveTSM.Text = "Save";
            saveTSM.Click += saveTSM_Click;
            // 
            // submitTSM
            // 
            submitTSM.Name = "submitTSM";
            submitTSM.Size = new Size(139, 26);
            submitTSM.Text = "Submit";
            submitTSM.Click += submitTSM_Click;
            // 
            // Test
            // 
            this.Test.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runTSM,
            this.unitTestTSM});
            this.Test.Image = ((System.Drawing.Image)(resources.GetObject("Test.Image")));
            this.Test.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(49, 24);
            this.Test.Text = "Test";
            // 
            // runTSM
            // 
            runTSM.Name = "runTSM";
            runTSM.Size = new Size(149, 26);
            runTSM.Text = "Run";
            runTSM.Click += runTSM_Click;
            // 
            // unitTestTSM
            // 
            unitTestTSM.Name = "unitTestTSM";
            unitTestTSM.Size = new Size(149, 26);
            unitTestTSM.Text = "Unit Test";
            unitTestTSM.Click += unitTestTSM_Click;
            // 
            // toolsDropDown
            // 
            this.toolsDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.magnifyTSM,
            this.themesToolStripMenuItem});
            this.toolsDropDown.Image = ((System.Drawing.Image)(resources.GetObject("toolsDropDown.Image")));
            this.toolsDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsDropDown.Name = "toolsDropDown";
            this.toolsDropDown.Size = new System.Drawing.Size(58, 24);
            this.toolsDropDown.Text = "Tools";
            // 
            // magnifyTSM
            // 
            this.magnifyTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInTSM,
            this.zoomOutTSM,
            this.zoom100TSM});
            this.magnifyTSM.Name = "magnifyTSM";
            this.magnifyTSM.Size = new System.Drawing.Size(146, 26);
            this.magnifyTSM.Text = "Magnify";
            // 
            // zoomInTSM
            // 
            zoomInTSM.Name = "zoomInTSM";
            zoomInTSM.Size = new Size(172, 26);
            zoomInTSM.Text = "Zoom In";
            zoomInTSM.Click += zoomInTSM_Click;
            // 
            // zoomOutTSM
            // 
            zoomOutTSM.Name = "zoomOutTSM";
            zoomOutTSM.Size = new Size(172, 26);
            zoomOutTSM.Text = "Zoom Out";
            zoomOutTSM.Click += zoomOutTSM_Click;
            // 
            // zoom100TSM
            // 
            zoom100TSM.Name = "zoom100TSM";
            zoom100TSM.Size = new Size(172, 26);
            zoom100TSM.Text = "Zoom 100%";
            zoom100TSM.Click += zoom100TSM_Click;
            // 
            // lang
            // 
            this.lang.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchToPy,
            this.switchToJava});
            this.lang.Image = ((System.Drawing.Image)(resources.GetObject("lang.Image")));
            this.lang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lang.Name = "lang";
            this.lang.Size = new System.Drawing.Size(88, 24);
            this.lang.Text = "Language";
            // 
            // switchToPy
            // 
            switchToPy.Checked = true;
            switchToPy.CheckState = CheckState.Checked;
            switchToPy.Name = "switchToPy";
            switchToPy.Size = new Size(137, 26);
            switchToPy.Text = "Python";
            switchToPy.Click += switchToPy_Click;
            // 
            // switchToJava
            // 
            switchToJava.Name = "switchToJava";
            switchToJava.Size = new Size(137, 26);
            switchToJava.Text = "Java";
            switchToJava.Click += switchToJava_Click;
            // 
            // Trather
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 691);
            Controls.Add(toolStrip1);
            Controls.Add(splitContainer1);
            MinimizeBox = false;
            Name = "Trather";
            Text = "Trather";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosing += Trather_FormClosing;
            FormClosed += Trather_FormClosed;
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
        private Button stopBTN;
        private ToolStripDropDownButton lang;
        private ToolStripMenuItem switchToPy;
        private ToolStripMenuItem switchToJava;
        private ToolStripMenuItem themesToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
    }
}