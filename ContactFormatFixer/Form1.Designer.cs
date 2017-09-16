namespace ContactFormatFixer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPickOriginalFile = new System.Windows.Forms.Button();
            this.btnPickNewFolder = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "STEP 1 : Pick a .CSV or .TXT file to fix by clicking the \'Pick Original File\' but" +
    "ton.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "STEP 2 : Pick a location and name for the fixed file by clicking the \'Pick New Fi" +
    "le\' button.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "STEP 3 : Click the \'Fix\' button to let the application do its\' magic.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(511, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "STEP 4 : Wait for message box to pop up letting you know the file fixing is done," +
    " then close the application.";
            // 
            // btnPickOriginalFile
            // 
            this.btnPickOriginalFile.Location = new System.Drawing.Point(54, 100);
            this.btnPickOriginalFile.Name = "btnPickOriginalFile";
            this.btnPickOriginalFile.Size = new System.Drawing.Size(144, 23);
            this.btnPickOriginalFile.TabIndex = 4;
            this.btnPickOriginalFile.Text = "Pick &Original File";
            this.btnPickOriginalFile.UseVisualStyleBackColor = true;
            this.btnPickOriginalFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPickNewFolder
            // 
            this.btnPickNewFolder.Enabled = false;
            this.btnPickNewFolder.Location = new System.Drawing.Point(204, 100);
            this.btnPickNewFolder.Name = "btnPickNewFolder";
            this.btnPickNewFolder.Size = new System.Drawing.Size(144, 23);
            this.btnPickNewFolder.TabIndex = 5;
            this.btnPickNewFolder.Text = "Pick &New File";
            this.btnPickNewFolder.UseVisualStyleBackColor = true;
            this.btnPickNewFolder.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFix
            // 
            this.btnFix.Enabled = false;
            this.btnFix.Location = new System.Drawing.Point(353, 100);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(144, 23);
            this.btnFix.TabIndex = 6;
            this.btnFix.Text = "&Fix";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "csv files|*.csv|CSV files|*.CSV|txt files|*.txt|TXT files|*.txt";
            this.openFileDialog1.Title = "Pick a file to fix...";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "CSV";
            this.saveFileDialog1.FileName = "newFile.csv";
            this.saveFileDialog1.Filter = "csv file|*.csv|CSV file|*.CSV";
            this.saveFileDialog1.Title = "Pick a folder to leave the fixed file in...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 146);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.btnPickNewFolder);
            this.Controls.Add(this.btnPickOriginalFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Linda\'s Contact Format Fixer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPickOriginalFile;
        private System.Windows.Forms.Button btnPickNewFolder;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

