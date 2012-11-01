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
        public string update_source = "";

        public frmUpdateAvailable()
        {
            InitializeComponent();
            update_source = "app";
        }

        public frmUpdateAvailable(string type)
        {
            InitializeComponent();
            update_source = type;
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
            switch(this.update_source)
            {
                case "self":
                    Properties.Settings.Default.SkipVersionSelf = clsUpdateCheck.self_update_version.ToString();
                    break;
                default:
                    Properties.Settings.Default.SkipVersion = clsUpdateCheck.update_version.ToString();
                    break;
            }
            //Properties.Settings.Default.SkipVersion = clsUpdateCheck.update_version.ToString();
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
            string remote_url = "";
            switch (this.update_source)
            {
                case "self":
                    remote_url = clsUpdateCheck.self_update_url;
                    break;
                default:
                    remote_url = clsUpdateCheck.update_url;
                    break;
            }

            string extension = Path.GetExtension(remote_url);
            string tempfilename = Guid.NewGuid().ToString() + extension;

            tempfilenamepath = Path.Combine(temppath, tempfilename);

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(remote_url), tempfilenamepath);
        }

        private void InstallUpdate()
        {
            string action = "";
            switch (this.update_source)
            {
                case "self":
                    action = clsUpdateCheck.self_update_action;
                    break;
                default:
                    action = clsUpdateCheck.update_action;
                    break;
            }

            // get the commandline 
            String cmdLine = Environment.CommandLine;
            String workingDir = Environment.CurrentDirectory;

            // generate the batch file path
            String cmd = Path.Combine(temppath, Guid.NewGuid() + ".cmd");
            String installerCMD;

            Debug.WriteLine(action);

            // check if update is copy
            if (action == "copy")
            {
                // build command line to copy file
                installerCMD = "copy " + tempfilenamepath + " " + System.Reflection.Assembly.GetCallingAssembly().Location;
                //Debug.WriteLine(installerCMD);

                // generate the batch file
                //sparkle.ReportDiagnosticMessage("Generating MSI batch in " + Path.GetFullPath(cmd));

                StreamWriter write = new StreamWriter(cmd);

                write.WriteLine(installerCMD);
                write.WriteLine("cd " + workingDir);
                write.WriteLine(cmdLine);

                write.Close();
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
            }

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
