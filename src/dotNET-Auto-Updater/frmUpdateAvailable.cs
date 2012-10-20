using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace dotNET_Auto_Updater
{
    public partial class frmUpdateAvailable : Form
    {
        public string tempfilenamepath = "";
        public string temppath = Path.GetTempPath();

        public frmUpdateAvailable()
        {
            InitializeComponent();
        }

        private void btnRemindMeLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateNow_Click(object sender, EventArgs e)
        {
            DownloadFile(this.lblUrl.Text);
            //InstallUpdate();
        }

        private void btnSkipThisVersion_Click(object sender, EventArgs e)
        {

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progDownload.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
            InstallUpdate();
        }

        private void DownloadFile(string remote_file)
        {
            //MessageBox.Show(remote_file);
            string extension = Path.GetExtension(remote_file);
            //string filename = Path.GetFileName(remote_file);
            string tempfilename = Guid.NewGuid().ToString() + extension;

            tempfilenamepath = Path.Combine(temppath, tempfilename);

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(remote_file), tempfilenamepath);
        }

        private void InstallUpdate()
        {
            // get the commandline 
            String cmdLine = Environment.CommandLine;
            String workingDir = Environment.CurrentDirectory;

            // generate the batch file path
            String cmd = Path.Combine(temppath, Guid.NewGuid() + ".cmd");
            String installerCMD;

            // get the file type
            if (Path.GetExtension(tempfilenamepath).ToLower().Equals(".exe"))
            {
                // build the command line 
                installerCMD = tempfilenamepath;
            }
            else if (Path.GetExtension(tempfilenamepath).ToLower().Equals(".msi"))
            {
                // build the command line
                installerCMD = "msiexec /i \"" + tempfilenamepath + "\"";
            }
            else
            {
                //sparkle.ReportDiagnosticMessage("Updater not supported, please execute " + tempfilename + " manually");
                MessageBox.Show("Updater not supported, please execute " + tempfilenamepath + " manually", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return;
            }

            // generate the batch file
            //sparkle.ReportDiagnosticMessage("Generating MSI batch in " + Path.GetFullPath(cmd));

            StreamWriter write = new StreamWriter(cmd);

            write.WriteLine(installerCMD);
            write.WriteLine("cd " + workingDir);
            write.WriteLine(cmdLine);

            write.Close();

            // report
            //sparkle.ReportDiagnosticMessage("Going to execute batch: " + cmd);

            // start the installer helper
            Process process = new Process();
            process.StartInfo.FileName = cmd;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();

            // quit the app
            Environment.Exit(0);
        }
    }
}
