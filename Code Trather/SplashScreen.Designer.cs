namespace Code_Trather
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.testIDtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startUT = new System.Windows.Forms.Button();
            this.startNoUT = new System.Windows.Forms.Button();
            this.cwidInputBox = new System.Windows.Forms.NumericUpDown();
            this.warningLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cwidInputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(294, 164);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(176, 27);
            this.nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "CWID:";
            // 
            // testIDtextBox
            // 
            this.testIDtextBox.Location = new System.Drawing.Point(294, 272);
            this.testIDtextBox.Name = "testIDtextBox";
            this.testIDtextBox.Size = new System.Drawing.Size(176, 27);
            this.testIDtextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Test ID:";
            // 
            // startUT
            // 
            this.startUT.Location = new System.Drawing.Point(201, 334);
            this.startUT.Name = "startUT";
            this.startUT.Size = new System.Drawing.Size(95, 55);
            this.startUT.TabIndex = 6;
            this.startUT.Text = "Start with Unit Test";
            this.startUT.UseVisualStyleBackColor = true;
            this.startUT.Click += new System.EventHandler(this.button1_Click);
            // 
            // startNoUT
            // 
            this.startNoUT.Location = new System.Drawing.Point(458, 334);
            this.startNoUT.Name = "startNoUT";
            this.startNoUT.Size = new System.Drawing.Size(95, 55);
            this.startNoUT.TabIndex = 7;
            this.startNoUT.Text = "Start No Unit Test";
            this.startNoUT.UseVisualStyleBackColor = true;
            this.startNoUT.Click += new System.EventHandler(this.button2_Click);
            // 
            // cwidInputBox
            // 
            this.cwidInputBox.Location = new System.Drawing.Point(294, 220);
            this.cwidInputBox.Maximum = new decimal(new int[] {
            0,
            0,
            0});
            this.cwidInputBox.Name = "cwidInputBox";
            this.cwidInputBox.Size = new System.Drawing.Size(176, 27);
            this.cwidInputBox.TabIndex = 8;
            this.cwidInputBox.ValueChanged += new System.EventHandler(this.cwidInputBox_ValueChanged);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(296, 109);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 20);
            this.warningLabel.TabIndex = 9;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.cwidInputBox);
            this.Controls.Add(this.startNoUT);
            this.Controls.Add(this.startUT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.testIDtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "SplashScreen";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.cwidInputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private TextBox testIDtextBox;
        private Label label3;
        private Button startUT;
        private Button startNoUT;
        private NumericUpDown cwidInputBox;
        private Label warningLabel;
    }
}