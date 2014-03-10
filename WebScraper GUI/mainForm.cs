using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WebScraper_GUI
{
    public partial class mainForm : Form
    {
        private Process process = null;
        private static readonly String defaultPathForCommand = @"..\..\..\WebSraper Command Line\bin\Debug\WebSraper Command Line.exe";

        public mainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            this.txtCommandPath.Text = defaultPathForCommand;
        }

        private void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                txtTexto.Text += outLine.Data + Environment.NewLine;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (process != null)
                process.Close();
        }

        private void btnBrowseCommand_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCommandPath.Text = ofd.FileName;
            }
        }

        private void btnBrowseURLOrFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtURLOrFile.Text = ofd.FileName;
            }
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            txtTexto.Text = "";

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = this.txtCommandPath.Text; // specify exe name.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.Arguments = this.constructArguments();

            using (process = Process.Start(start))
            {
                process.BeginOutputReadLine();

                process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);

                while (!process.HasExited) ;
            }
        }

        private String constructArguments()
        {
            String commandOptions = txtURLOrFile.Text + " " + txtWordList.Text;

            if (this.chkCountCharacters.Checked)
                commandOptions += " -c";

            if (this.chkWordCount.Checked)
                commandOptions += " -w";

            if (this.chkVerbose.Checked)
                commandOptions += " -v";

            return commandOptions;            
        }

        private void chkWordCount_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (!chk.Checked)
            {
                txtWordList.Text = "";
                txtWordList.Enabled = false;
            }
            else
            {
                txtWordList.Enabled = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            txtTexto.Text = "";

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = this.txtCommandPath.Text; // specify exe name.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.Arguments = "-h";

            process = Process.Start(start);
            process.BeginOutputReadLine();

            process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
        }
    }
}
