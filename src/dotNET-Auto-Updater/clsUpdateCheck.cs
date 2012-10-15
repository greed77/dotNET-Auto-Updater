using System;
using System.Xml;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace dotNET_Auto_Updater
{
    public class clsUpdateCheck
    {
        public static void Start(string update_xml)
        {
            string update_title = "";
            string update_url = "";
            Version update_version = new Version("0.0.0.0");
            string update_changelog = "";

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
                }

                Version current_version = Assembly.GetEntryAssembly().GetName().Version;
                Debug.WriteLine(current_version.ToString());

                frmUpdateAvailable frm = new frmUpdateAvailable();

                frm.lblCurrentVersion.Text = current_version.ToString();
                frm.lblTitle.Text = update_title.ToString();
                frm.lblVersionAvailable.Text = update_version.ToString();
                frm.lblUrl.Text = update_url.ToString();
                //frm.lblChangelog.Text = update_changelog.ToString();

                WebClient client = new WebClient();
                String htmlCode = client.DownloadString(update_changelog.ToString());
                frm.webChangelog.DocumentText = htmlCode;

                if (update_version > current_version)
                {
                    Debug.WriteLine("update is available");

                    frm.Show();
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
    }
}
