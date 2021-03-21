using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace FacebookDeskAppLogic
{
    public class AppSettings
    {
            private const string k_fileName = "appSettings.xml";
            private static readonly string sr_RemaindersDataPath = Path.Combine(Environment.CurrentDirectory, k_fileName);

            public Point LastWindowLocation { get; set; }

            public Size LastWindowSize { get; set; }

            public bool RememberUser { get; set; }

            public string LastAccessToken { get; set; }

            private AppSettings()
            {
                LastWindowLocation = new Point(20, 50);
                LastWindowSize = new Size(1000, 500);
                RememberUser = false;
                LastAccessToken = null;
            }

            public static AppSettings LoadFromFile()
            {
                AppSettings set = new AppSettings();
                try
                {
                    if (File.Exists(sr_RemaindersDataPath))
                    {
                        using (Stream fileStream = new FileStream(sr_RemaindersDataPath, FileMode.OpenOrCreate))
                        {
                            XmlSerializer mySerializer = new XmlSerializer(typeof(AppSettings));
                            set = mySerializer.Deserialize(fileStream) as AppSettings;
                        }
                    }
                    else
                    {
                        File.Create(sr_RemaindersDataPath);
                    }
                    return set;
                }
                catch (Exception e)
                {
                    throw new Exception("Error failed to load settings.");
                }
            }

            public void SaveToFile()
            {
                try
                {
                    using (Stream fileStream = new FileStream(sr_RemaindersDataPath, FileMode.Truncate))
                    {
                        XmlSerializer mySerializer = new XmlSerializer(this.GetType());
                        mySerializer.Serialize(fileStream, this);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error failed to save settings.");
                }
            }
        }
}
