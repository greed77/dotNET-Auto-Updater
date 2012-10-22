namespace dotNET_Auto_Updater
{
    partial class frmUpdateAvailable
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
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersionAvailable = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblChangelog = new System.Windows.Forms.Label();
            this.webChangelog = new System.Windows.Forms.WebBrowser();
            this.btnUpdateNow = new System.Windows.Forms.Button();
            this.btnSkipThisVersion = new System.Windows.Forms.Button();
            this.btnRemindMeLater = new System.Windows.Forms.Button();
            this.progDownload = new System.Windows.Forms.ProgressBar();
            this.lblUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current version:";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(110, 9);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentVersion.TabIndex = 1;
            this.lblCurrentVersion.Text = "lblCurrentVersion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version available:";
            // 
            // lblVersionAvailable
            // 
            this.lblVersionAvailable.AutoSize = true;
            this.lblVersionAvailable.Location = new System.Drawing.Point(110, 34);
            this.lblVersionAvailable.Name = "lblVersionAvailable";
            this.lblVersionAvailable.Size = new System.Drawing.Size(95, 13);
            this.lblVersionAvailable.TabIndex = 3;
            this.lblVersionAvailable.Text = "lblVersionAvailable";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 59);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "lblTitle";
            // 
            // lblChangelog
            // 
            this.lblChangelog.AutoSize = true;
            this.lblChangelog.Location = new System.Drawing.Point(12, 84);
            this.lblChangelog.Name = "lblChangelog";
            this.lblChangelog.Size = new System.Drawing.Size(64, 13);
            this.lblChangelog.TabIndex = 5;
            this.lblChangelog.Text = "Change log:";
            // 
            // webChangelog
            // 
            this.webChangelog.AllowNavigation = false;
            this.webChangelog.AllowWebBrowserDrop = false;
            this.webChangelog.IsWebBrowserContextMenuEnabled = false;
            this.webChangelog.Location = new System.Drawing.Point(12, 100);
            this.webChangelog.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChangelog.Name = "webChangelog";
            this.webChangelog.Size = new System.Drawing.Size(424, 199);
            this.webChangelog.TabIndex = 6;
            // 
            // btnUpdateNow
            // 
            this.btnUpdateNow.Location = new System.Drawing.Point(332, 331);
            this.btnUpdateNow.Name = "btnUpdateNow";
            this.btnUpdateNow.Size = new System.Drawing.Size(104, 32);
            this.btnUpdateNow.TabIndex = 7;
            this.btnUpdateNow.Text = "Update now";
            this.btnUpdateNow.UseVisualStyleBackColor = true;
            this.btnUpdateNow.Click += new System.EventHandler(this.btnUpdateNow_Click);
            // 
            // btnSkipThisVersion
            // 
            this.btnSkipThisVersion.Location = new System.Drawing.Point(172, 331);
            this.btnSkipThisVersion.Name = "btnSkipThisVersion";
            this.btnSkipThisVersion.Size = new System.Drawing.Size(104, 32);
            this.btnSkipThisVersion.TabIndex = 8;
            this.btnSkipThisVersion.Text = "Skip this version";
            this.btnSkipThisVersion.UseVisualStyleBackColor = true;
            this.btnSkipThisVersion.Click += new System.EventHandler(this.btnSkipThisVersion_Click);
            // 
            // btnRemindMeLater
            // 
            this.btnRemindMeLater.Location = new System.Drawing.Point(12, 331);
            this.btnRemindMeLater.Name = "btnRemindMeLater";
            this.btnRemindMeLater.Size = new System.Drawing.Size(104, 32);
            this.btnRemindMeLater.TabIndex = 9;
            this.btnRemindMeLater.Text = "Remind me later";
            this.btnRemindMeLater.UseVisualStyleBackColor = true;
            this.btnRemindMeLater.Click += new System.EventHandler(this.btnRemindMeLater_Click);
            // 
            // progDownload
            // 
            this.progDownload.Location = new System.Drawing.Point(12, 305);
            this.progDownload.Name = "progDownload";
            this.progDownload.Size = new System.Drawing.Size(424, 23);
            this.progDownload.TabIndex = 10;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(254, 59);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(30, 13);
            this.lblUrl.TabIndex = 11;
            this.lblUrl.Text = "lblUrl";
            this.lblUrl.Visible = false;
            // 
            // frmUpdateAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 375);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.progDownload);
            this.Controls.Add(this.btnRemindMeLater);
            this.Controls.Add(this.btnSkipThisVersion);
            this.Controls.Add(this.btnUpdateNow);
            this.Controls.Add(this.webChangelog);
            this.Controls.Add(this.lblChangelog);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblVersionAvailable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateAvailable";
            this.Text = "Update available";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblCurrentVersion;
        internal System.Windows.Forms.Label lblVersionAvailable;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblChangelog;
        internal System.Windows.Forms.WebBrowser webChangelog;
        private System.Windows.Forms.Button btnUpdateNow;
        private System.Windows.Forms.Button btnSkipThisVersion;
        private System.Windows.Forms.Button btnRemindMeLater;
        private System.Windows.Forms.ProgressBar progDownload;
        internal System.Windows.Forms.Label lblUrl;
    }
}