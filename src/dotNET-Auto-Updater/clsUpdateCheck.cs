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

            XmlDocument xml = new XmlDocument();
            xml.Load(update_xml); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList items = xml.SelectNodes("/items/item");
            foreach (XmlNode item in items)
            {
                update_title = item["title"].InnerText;
                update_version = new Version(item["version"].InnerText);
                update_changelog = item["changelog"].InnerText;
                update_url = item["url"].InnerText;
                Debug.WriteLine("title:" + update_title);
                Debug.WriteLine("version:" + update_version);
                Debug.WriteLine("url:" + update_url);
                Debug.WriteLine("changelog:" + update_changelog);
            }

            Version current_version = Assembly.GetEntryAssembly().GetName().Version;
            Debug.WriteLine(current_version.ToString());

            frmUpdateAvailable frm = new frmUpdateAvailable();

            frm.lblCurrentVersion.Text = current_version.ToString();
            frm.lblTitle.Text = update_title.ToString();
            frm.lblVersionAvailable.Text = update_version.ToString();
            //frm.lblChangelog.Text = update_changelog.ToString();

            frm.webChangelog.Navigate(update_changelog.ToString());

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
    }
}
