using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace dotNET_Auto_Updater
{
    public partial class frmUpdateAvailable : Form
    {
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
            string extension = Path.GetExtension(this.lblUrl.Text);
            string filename = Path.GetFileName(this.lblUrl.Text);
            string tempPath = System.IO.Path.GetTempPath();
            string tempfilename = Path.Combine(tempPath, filename);

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(this.lblUrl.Text), tempfilename);
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
        }
    }
}
