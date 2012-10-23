using System;
using System.Xml;
using System.Reflection;
using System.Diagnostics;
using System.Net;
//using System.Windows.Forms;

namespace dotNET_Auto_Updater
{
    public class clsUpdateCheck
    {
        public static string self_update_url = "https://raw.github.com/greed77/dotNET-Auto-Updater/master/AutoUpdate.xml";
        public static string self_update_title = "";
        public static Version self_update_version = new Version("0.0.0.0");
        public static string self_update_changelog = "";
        public static string self_update_action = "";

        public static string update_title = "";
        public static string update_url = "";
        public static Version update_version = new Version("0.0.0.0");
        public static string update_changelog = "";
        public static string update_action = "";

        public static Version skip_version = new Version(Properties.Settings.Default.SkipVersion);
        
        public static void CheckForUpdates(string update_xml, bool force_update = false)
        {
            // update self first, if needed
            SelfUpdate();

            // next check for updates to app
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(update_xml);

                XmlNodeList items = xml.SelectNodes("/items/item");
                foreach (XmlNode item in items)
                {
                    update_title = item["title"].InnerText;
                    Debug.WriteLine("title:" + update_title);
                    
                    update_version = new Version(item["version"].InnerText);
                    Debug.WriteLine("version:" + update_version);
                    
                    update_changelog = item["changelog"].InnerText;
                    Debug.WriteLine("changelog:" + update_changelog);
                    
                    update_url = item["url"].InnerText;
                    Debug.WriteLine("url:" + update_url);

                    update_action = item["action"].InnerText;
                    Debug.WriteLine("action:" + update_action);
                }

                Version current_version = Assembly.GetEntryAssembly().GetName().Version;
                Debug.WriteLine(current_version.ToString());

                frmUpdateAvailable frm = new frmUpdateAvailable();

                frm.lblCurrentVersion.Text = current_version.ToString();
                frm.lblTitle.Text = update_title.ToString();
                frm.lblVersionAvailable.Text = update_version.ToString();
                frm.lblUrl.Text = update_url.ToString();

                WebClient client = new WebClient();
                String htmlCode = client.DownloadString(update_changelog.ToString());
                frm.webChangelog.DocumentText = htmlCode;

                if (update_version > current_version)
                {
                    Debug.WriteLine("update is available");
                    if (update_version != skip_version || force_update == true)
                    {
                        frm.Show();
                    }
                }
                else
                {
                    Debug.WriteLine("no update");
                }
            }
            catch (Exception level1)
            {
                Debug.WriteLine(level1);
            }
        }

        private static void SelfUpdate()
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(self_update_url);

                XmlNodeList items = xml.SelectNodes("/items/item");
                foreach (XmlNode item in items)
                {
                    self_update_title = item["title"].InnerText;
                    Debug.WriteLine("title:" + self_update_title);

                    self_update_version = new Version(item["version"].InnerText);
                    Debug.WriteLine("version:" + self_update_version);

                    self_update_changelog = item["changelog"].InnerText;
                    Debug.WriteLine("changelog:" + self_update_changelog);

                    self_update_url = item["url"].InnerText;
                    Debug.WriteLine("url:" + self_update_url);

                    self_update_action = item["action"].InnerText;
                    Debug.WriteLine("action:" + self_update_action);
                }

                Version self_current_version = Assembly.GetCallingAssembly().GetName().Version;
                Debug.WriteLine(self_current_version.ToString());

                //frmUpdateAvailable frm = new frmUpdateAvailable();

                //frm.lblCurrentVersion.Text = self_current_version.ToString();
                //frm.lblTitle.Text = update_title.ToString();
                //frm.lblVersionAvailable.Text = update_version.ToString();
                //frm.lblUrl.Text = update_url.ToString();

                //WebClient client = new WebClient();
                //String htmlCode = client.DownloadString(update_changelog.ToString());
                //frm.webChangelog.DocumentText = htmlCode;

                //if (self_update_version > self_current_version)
                //{
                //    Debug.WriteLine("update is available");
                //    if (update_version != skip_version || force_update == true)
                //    {
                //        frm.Show();
                //    }
                //}
                //else
                //{
                //    Debug.WriteLine("no update");
                //}
            }
            catch (Exception level1)
            {
                Debug.WriteLine(level1);
            }
        }
    }
}
