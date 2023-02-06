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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textInput = new ScintillaNET.Scintilla();
            this.textInput_old = new System.Windows.Forms.RichTextBox();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Test = new System.Windows.Forms.ToolStripDropDownButton();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.magnifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(10, 42);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textInput);
            this.splitContainer1.Panel1.Controls.Add(this.textInput_old);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textOutput);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 488);
            this.splitContainer1.SplitterDistance = 799;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // textInput
            // 
            this.textInput.AutoCMaxHeight = 9;
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.textInput.Location = new System.Drawing.Point(0, 0);
            this.textInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(799, 488);
            this.textInput.TabIndents = true;
            this.textInput.TabIndex = 4;
            this.textInput.Text = "scintilla1";
            // 
            // textInput_old
            // 
            this.textInput_old.AcceptsTab = true;
            this.textInput_old.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInput_old.Enabled = false;
            this.textInput_old.Location = new System.Drawing.Point(3, 2);
            this.textInput_old.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textInput_old.Name = "textInput_old";
            this.textInput_old.Size = new System.Drawing.Size(794, 482);
            this.textInput_old.TabIndex = 3;
            this.textInput_old.Text = "";
            this.textInput_old.Visible = false;
            this.textInput_old.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            // 
            // textOutput
            // 
            this.textOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutput.Location = new System.Drawing.Point(3, 2);
            this.textOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(352, 482);
            this.textOutput.TabIndex = 0;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 3000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTime);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Test,
            this.InputFile,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1189, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.AccessibleName = "File";
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.submitToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(38, 22);
            this.File.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // submitToolStripMenuItem
            // 
            this.submitToolStripMenuItem.Name = "submitToolStripMenuItem";
            this.submitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.submitToolStripMenuItem.Text = "Submit";
            this.submitToolStripMenuItem.Click += new System.EventHandler(this.submitToolStripMenuItem_Click);
            // 
            // Test
            // 
            this.Test.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.unitTestToolStripMenuItem});
            this.Test.Image = ((System.Drawing.Image)(resources.GetObject("Test.Image")));
            this.Test.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(40, 22);
            this.Test.Text = "Test";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // unitTestToolStripMenuItem
            // 
            this.unitTestToolStripMenuItem.Name = "unitTestToolStripMenuItem";
            this.unitTestToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.unitTestToolStripMenuItem.Text = "Unit Test";
            // 
            // InputFile
            // 
            this.InputFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InputFile.Image = ((System.Drawing.Image)(resources.GetObject("InputFile.Image")));
            this.InputFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InputFile.Name = "InputFile";
            this.InputFile.Size = new System.Drawing.Size(60, 22);
            this.InputFile.Text = "Input File";
            this.InputFile.Click += new System.EventHandler(this.InputFile_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.magnifyToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "Tools";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Tools";
            // 
            // magnifyToolStripMenuItem
            // 
            this.magnifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoom100ToolStripMenuItem});
            this.magnifyToolStripMenuItem.Name = "magnifyToolStripMenuItem";
            this.magnifyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.magnifyToolStripMenuItem.Text = "Magnify";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoom100ToolStripMenuItem
            // 
            this.zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
            this.zoom100ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoom100ToolStripMenuItem.Text = "Zoom 100%";
            this.zoom100ToolStripMenuItem.Click += new System.EventHandler(this.zoom100ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 548);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SplitContainer splitContainer1;
        private RichTextBox textInput_old;
        private TextBox textOutput;
        private System.Windows.Forms.Timer UpdateTimer;
        private ScintillaNET.Scintilla textInput;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton File;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem submitToolStripMenuItem;
        private ToolStripDropDownButton Test;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem unitTestToolStripMenuItem;
        private ToolStripButton InputFile;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem magnifyToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem zoom100ToolStripMenuItem;
    }
}