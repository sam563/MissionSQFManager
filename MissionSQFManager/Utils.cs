using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    public class Utils
    {
        public static void DebugWindow(object msg)
        {
            System.Windows.Forms.MessageBox.Show(msg.ToString(), "Debug");
        }

        public static bool GetElementFromConfig(string elementTag, out string result)
        {
            result = string.Empty;
            if (!GetConfigXML(out XmlDocument xmlDoc)) return false;
            result = xmlDoc.GetElementsByTagName(elementTag)[0].InnerText;

            return true;
        }

        public static bool GetConfigXML(out XmlDocument xmlDoc)
        {
            xmlDoc = new XmlDocument();
            string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Config.xml");

            if (File.Exists(xmlPath))
            {
                xmlDoc.Load(xmlPath);
                return true;
            }
            else
            {
                System.Diagnostics.Trace.TraceError($"Could not find config at {xmlPath}!");
                return false;
            }
        }
    }
}
