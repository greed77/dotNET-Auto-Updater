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
            DownloadUpdate();
            InstallUpdate();
        }

        private void btnSkipThisVersion_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SkipVersion = clsUpdateCheck.update_version.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("You won't be reminded about an update to this version.","Skip this version",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
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

        private void DownloadUpdate()
        {
            string extension = Path.GetExtension(clsUpdateCheck.update_url);
            string tempfilename = Guid.NewGuid().ToString() + extension;

            tempfilenamepath = Path.Combine(temppath, tempfilename);

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(clsUpdateCheck.update_url), tempfilenamepath);
        }

        private void InstallUpdate()
        {
            // get the commandline 
            String cmdLine = Environment.CommandLine;
            String workingDir = Environment.CurrentDirectory;

            // generate the batch file path
            String cmd = Path.Combine(temppath, Guid.NewGuid() + ".cmd");
            String installerCMD;

            // check if update is copy
            if (clsUpdateCheck.self_update_action == "copy")
            {
            }
            else
            {
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
}
