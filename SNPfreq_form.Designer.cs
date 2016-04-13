namespace SNPfreq
{
    partial class SNPfreq_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.seqFileTextBox = new System.Windows.Forms.TextBox();
            this.snpFileTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.seqFolderPathButton = new System.Windows.Forms.Button();
            this.snpFolderPathButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.windowSizeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.createTaggedSeqButton = new System.Windows.Forms.Button();
            this.snpMinTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectOuputpuFolderButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.runMovingWinButton = new System.Windows.Forms.Button();
            this.extractGenesButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sequences Intervals File";
            // 
            // seqFileTextBox
            // 
            this.seqFileTextBox.Location = new System.Drawing.Point(166, 24);
            this.seqFileTextBox.Name = "seqFileTextBox";
            this.seqFileTextBox.Size = new System.Drawing.Size(390, 20);
            this.seqFileTextBox.TabIndex = 1;
            this.seqFileTextBox.Text = "C:\\Users\\darakjia\\Desktop\\Transcripts_loci2.txt";
            // 
            // snpFileTextBox
            // 
            this.snpFileTextBox.Location = new System.Drawing.Point(166, 69);
            this.snpFileTextBox.Name = "snpFileTextBox";
            this.snpFileTextBox.Size = new System.Drawing.Size(390, 20);
            this.snpFileTextBox.TabIndex = 4;
            this.snpFileTextBox.Text = "C:\\Users\\darakjia\\Desktop\\SNP_loci.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SNP Locations File";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // seqFolderPathButton
            // 
            this.seqFolderPathButton.Location = new System.Drawing.Point(572, 22);
            this.seqFolderPathButton.Name = "seqFolderPathButton";
            this.seqFolderPathButton.Size = new System.Drawing.Size(75, 23);
            this.seqFolderPathButton.TabIndex = 2;
            this.seqFolderPathButton.Text = "Browse";
            this.seqFolderPathButton.UseVisualStyleBackColor = true;
            this.seqFolderPathButton.Click += new System.EventHandler(this.seqFolderPathButton_Click);
            // 
            // snpFolderPathButton
            // 
            this.snpFolderPathButton.Location = new System.Drawing.Point(572, 67);
            this.snpFolderPathButton.Name = "snpFolderPathButton";
            this.snpFolderPathButton.Size = new System.Drawing.Size(75, 23);
            this.snpFolderPathButton.TabIndex = 5;
            this.snpFolderPathButton.Text = "Browse";
            this.snpFolderPathButton.UseVisualStyleBackColor = true;
            this.snpFolderPathButton.Click += new System.EventHandler(this.snpFolderPathButton_Click);
            // 
            // windowSizeTextBox
            // 
            this.windowSizeTextBox.Location = new System.Drawing.Point(166, 157);
            this.windowSizeTextBox.Name = "windowSizeTextBox";
            this.windowSizeTextBox.Size = new System.Drawing.Size(65, 20);
            this.windowSizeTextBox.TabIndex = 10;
            this.windowSizeTextBox.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Window size (in bp)";
            // 
            // createTaggedSeqButton
            // 
            this.createTaggedSeqButton.Location = new System.Drawing.Point(163, 250);
            this.createTaggedSeqButton.Name = "createTaggedSeqButton";
            this.createTaggedSeqButton.Size = new System.Drawing.Size(196, 23);
            this.createTaggedSeqButton.TabIndex = 14;
            this.createTaggedSeqButton.Text = "Create SNP-Tagged Sequence";
            this.createTaggedSeqButton.UseVisualStyleBackColor = true;
            this.createTaggedSeqButton.Click += new System.EventHandler(this.createTaggedSeqButton_Click);
            // 
            // snpMinTextBox
            // 
            this.snpMinTextBox.Location = new System.Drawing.Point(166, 197);
            this.snpMinTextBox.Name = "snpMinTextBox";
            this.snpMinTextBox.Size = new System.Drawing.Size(65, 20);
            this.snpMinTextBox.TabIndex = 12;
            this.snpMinTextBox.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Find >=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SNPs within the window indicated above";
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(165, 113);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(390, 20);
            this.outputFolderTextBox.TabIndex = 7;
            this.outputFolderTextBox.Text = "D:\\";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Directory for output";
            // 
            // selectOuputpuFolderButton
            // 
            this.selectOuputpuFolderButton.Location = new System.Drawing.Point(572, 111);
            this.selectOuputpuFolderButton.Name = "selectOuputpuFolderButton";
            this.selectOuputpuFolderButton.Size = new System.Drawing.Size(75, 23);
            this.selectOuputpuFolderButton.TabIndex = 8;
            this.selectOuputpuFolderButton.Text = "Browse";
            this.selectOuputpuFolderButton.UseVisualStyleBackColor = true;
            this.selectOuputpuFolderButton.Click += new System.EventHandler(this.selectOuputpuFolderButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(374, 250);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(194, 23);
            this.filterButton.TabIndex = 15;
            this.filterButton.Text = "Filter Sequences";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // runMovingWinButton
            // 
            this.runMovingWinButton.Location = new System.Drawing.Point(163, 279);
            this.runMovingWinButton.Name = "runMovingWinButton";
            this.runMovingWinButton.Size = new System.Drawing.Size(196, 23);
            this.runMovingWinButton.TabIndex = 16;
            this.runMovingWinButton.Text = "Run Moving Windows";
            this.runMovingWinButton.UseVisualStyleBackColor = true;
            this.runMovingWinButton.Click += new System.EventHandler(this.runMovingWinButton_Click);
            // 
            // extractGenesButton
            // 
            this.extractGenesButton.Location = new System.Drawing.Point(374, 279);
            this.extractGenesButton.Name = "extractGenesButton";
            this.extractGenesButton.Size = new System.Drawing.Size(194, 23);
            this.extractGenesButton.TabIndex = 17;
            this.extractGenesButton.Text = "Extract Genes from Result";
            this.extractGenesButton.UseVisualStyleBackColor = true;
            this.extractGenesButton.Click += new System.EventHandler(this.extractGenesButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(265, 321);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(196, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SNPfreq_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 422);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.extractGenesButton);
            this.Controls.Add(this.runMovingWinButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.selectOuputpuFolderButton);
            this.Controls.Add(this.outputFolderTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.snpMinTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.createTaggedSeqButton);
            this.Controls.Add(this.windowSizeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.snpFolderPathButton);
            this.Controls.Add(this.seqFolderPathButton);
            this.Controls.Add(this.snpFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seqFileTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SNPfreq_form";
            this.Text = "SNPfreq";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox seqFileTextBox;
        private System.Windows.Forms.TextBox snpFileTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button seqFolderPathButton;
        private System.Windows.Forms.Button snpFolderPathButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox windowSizeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createTaggedSeqButton;
        private System.Windows.Forms.TextBox snpMinTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectOuputpuFolderButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button runMovingWinButton;
        private System.Windows.Forms.Button extractGenesButton;
        /// <summary>
        /// Internally accessible for file existence verification
        /// </summary>
        internal System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Button cancelButton;
    }
}

