namespace WebScraper_GUI
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnScrap = new System.Windows.Forms.Button();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtCommandPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseCommand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWordList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtURLOrFile = new System.Windows.Forms.TextBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkWordCount = new System.Windows.Forms.CheckBox();
            this.chkCountCharacters = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseURLOrFile = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScrap
            // 
            this.btnScrap.Location = new System.Drawing.Point(412, 86);
            this.btnScrap.Name = "btnScrap";
            this.btnScrap.Size = new System.Drawing.Size(75, 23);
            this.btnScrap.TabIndex = 0;
            this.btnScrap.Text = "Start Scrap";
            this.btnScrap.UseVisualStyleBackColor = true;
            this.btnScrap.Click += new System.EventHandler(this.btnScrap_Click);
            // 
            // txtTexto
            // 
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.Location = new System.Drawing.Point(15, 129);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ReadOnly = true;
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTexto.Size = new System.Drawing.Size(475, 214);
            this.txtTexto.TabIndex = 1;
            // 
            // txtCommandPath
            // 
            this.txtCommandPath.Location = new System.Drawing.Point(99, 6);
            this.txtCommandPath.Name = "txtCommandPath";
            this.txtCommandPath.Size = new System.Drawing.Size(307, 20);
            this.txtCommandPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command path:";
            // 
            // btnBrowseCommand
            // 
            this.btnBrowseCommand.Location = new System.Drawing.Point(412, 4);
            this.btnBrowseCommand.Name = "btnBrowseCommand";
            this.btnBrowseCommand.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCommand.TabIndex = 4;
            this.btnBrowseCommand.Text = "Browse...";
            this.btnBrowseCommand.UseVisualStyleBackColor = true;
            this.btnBrowseCommand.Click += new System.EventHandler(this.btnBrowseCommand_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Options:";
            // 
            // txtWordList
            // 
            this.txtWordList.Enabled = false;
            this.txtWordList.Location = new System.Drawing.Point(73, 60);
            this.txtWordList.Name = "txtWordList";
            this.txtWordList.Size = new System.Drawing.Size(414, 20);
            this.txtWordList.TabIndex = 6;
            this.toolTip.SetToolTip(this.txtWordList, "Comma separated word list");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Word List:";
            // 
            // txtURLOrFile
            // 
            this.txtURLOrFile.Location = new System.Drawing.Point(105, 33);
            this.txtURLOrFile.Name = "txtURLOrFile";
            this.txtURLOrFile.Size = new System.Drawing.Size(301, 20);
            this.txtURLOrFile.TabIndex = 12;
            this.toolTip.SetToolTip(this.txtURLOrFile, "Comma separated word list");
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(65, 90);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(65, 17);
            this.chkVerbose.TabIndex = 8;
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // chkWordCount
            // 
            this.chkWordCount.AutoSize = true;
            this.chkWordCount.Location = new System.Drawing.Point(136, 90);
            this.chkWordCount.Name = "chkWordCount";
            this.chkWordCount.Size = new System.Drawing.Size(88, 17);
            this.chkWordCount.TabIndex = 9;
            this.chkWordCount.Text = "Count Words";
            this.chkWordCount.UseVisualStyleBackColor = true;
            this.chkWordCount.CheckedChanged += new System.EventHandler(this.chkWordCount_CheckedChanged_1);
            // 
            // chkCountCharacters
            // 
            this.chkCountCharacters.AutoSize = true;
            this.chkCountCharacters.Location = new System.Drawing.Point(230, 91);
            this.chkCountCharacters.Name = "chkCountCharacters";
            this.chkCountCharacters.Size = new System.Drawing.Size(108, 17);
            this.chkCountCharacters.TabIndex = 10;
            this.chkCountCharacters.Text = "Count Characters";
            this.chkCountCharacters.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Output from command line:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "URL or Text File:";
            // 
            // btnBrowseURLOrFile
            // 
            this.btnBrowseURLOrFile.Location = new System.Drawing.Point(412, 31);
            this.btnBrowseURLOrFile.Name = "btnBrowseURLOrFile";
            this.btnBrowseURLOrFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseURLOrFile.TabIndex = 14;
            this.btnBrowseURLOrFile.Text = "Browse...";
            this.btnBrowseURLOrFile.UseVisualStyleBackColor = true;
            this.btnBrowseURLOrFile.Click += new System.EventHandler(this.btnBrowseURLOrFile_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(354, 86);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(52, 23);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 355);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBrowseURLOrFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtURLOrFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkCountCharacters);
            this.Controls.Add(this.chkWordCount);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWordList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommandPath);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.btnScrap);
            this.Name = "mainForm";
            this.Text = "Web Scraper V1.0 GUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScrap;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.TextBox txtCommandPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWordList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.CheckBox chkWordCount;
        private System.Windows.Forms.CheckBox chkCountCharacters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURLOrFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseURLOrFile;
        private System.Windows.Forms.Button btnHelp;
    }
}

