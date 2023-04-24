namespace Code_Trather
{
    partial class Login
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
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            testIDtextBox = new TextBox();
            label3 = new Label();
            startUT = new Button();
            startNoUT = new Button();
            cwidInputBox = new NumericUpDown();
            warningLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)cwidInputBox).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(294, 164);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(176, 27);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 141);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 197);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "CWID:";
            // 
            // testIDtextBox
            // 
            testIDtextBox.Location = new Point(294, 272);
            testIDtextBox.Name = "testIDtextBox";
            testIDtextBox.Size = new Size(176, 27);
            testIDtextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(294, 249);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 5;
            label3.Text = "Test ID:";
            // 
            // startUT
            // 
            startUT.Location = new Point(201, 334);
            startUT.Name = "startUT";
            startUT.Size = new Size(95, 55);
            startUT.TabIndex = 6;
            startUT.Text = "Start with Unit Test";
            startUT.UseVisualStyleBackColor = true;
            startUT.Click += startUT_Click;
            // 
            // startNoUT
            // 
            startNoUT.Location = new Point(458, 334);
            startNoUT.Name = "startNoUT";
            startNoUT.Size = new Size(95, 55);
            startNoUT.TabIndex = 7;
            startNoUT.Text = "Start No Unit Test";
            startNoUT.UseVisualStyleBackColor = true;
            startNoUT.Click += startNoUT_Click;
            // 
            // cwidInputBox
            // 
            cwidInputBox.Location = new Point(294, 220);
            cwidInputBox.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            cwidInputBox.Name = "cwidInputBox";
            cwidInputBox.Size = new Size(176, 27);
            cwidInputBox.TabIndex = 8;
            cwidInputBox.ValueChanged += cwidInputBox_ValueChanged;
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.ForeColor = Color.Red;
            warningLabel.Location = new Point(296, 109);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(0, 20);
            warningLabel.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(warningLabel);
            Controls.Add(cwidInputBox);
            Controls.Add(startNoUT);
            Controls.Add(startUT);
            Controls.Add(label3);
            Controls.Add(testIDtextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)cwidInputBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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