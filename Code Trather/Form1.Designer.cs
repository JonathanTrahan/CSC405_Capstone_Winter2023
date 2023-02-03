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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textInput = new ScintillaNET.Scintilla();
            this.textInput_old = new System.Windows.Forms.RichTextBox();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Unit Test";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(11, 56);
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
            this.splitContainer1.Size = new System.Drawing.Size(1335, 650);
            this.splitContainer1.SplitterDistance = 914;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // textInput
            // 
            this.textInput.AutoCMaxHeight = 9;
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.textInput.Location = new System.Drawing.Point(0, 0);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(914, 650);
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
            this.textInput_old.Location = new System.Drawing.Point(3, 2);
            this.textInput_old.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textInput_old.Name = "textInput_old";
            this.textInput_old.Size = new System.Drawing.Size(908, 642);
            this.textInput_old.TabIndex = 3;
            this.textInput_old.Text = "";
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
            this.textOutput.Size = new System.Drawing.Size(403, 642);
            this.textOutput.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1253, 12);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 30);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 3000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTime);
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Location = new System.Drawing.Point(1141, 12);
            this.OpenFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(94, 30);
            this.OpenFileBtn.TabIndex = 4;
            this.OpenFileBtn.Text = "Open";
            this.OpenFileBtn.UseVisualStyleBackColor = true;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 730);
            this.Controls.Add(this.OpenFileBtn);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private SplitContainer splitContainer1;
        private RichTextBox textInput_old;
        private TextBox textOutput;
        private Button saveButton;
        private System.Windows.Forms.Timer UpdateTimer;
        private Button OpenFileBtn;
        private ScintillaNET.Scintilla textInput;
    }
}