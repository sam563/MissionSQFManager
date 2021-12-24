using System.IO;
using System.Xml;

namespace MissionSQFManager
{
    public class Utils
    {
        public const string configName = "Config.xml";

        private static string[] vehicleClassnames = null;

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
            string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), configName);

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

        public static string[] GetAllVehicleClassnames()
        {
            if (vehicleClassnames == null)
            {
                vehicleClassnames = GetAllVehicleClassnamesFromConfig();
            }

            return vehicleClassnames;
        }

        private static string[] GetAllVehicleClassnamesFromConfig()
        {
            if (!GetConfigXML(out XmlDocument doc)) return null;
            var vehicles = doc.SelectSingleNode("/Config/Vehicles");

            if (vehicles == null) return null;

            string[] classnames = new string[vehicles.ChildNodes.Count];

            for (int i = 0; i < vehicles.ChildNodes.Count; i++)
            {
                XmlNode classname = vehicles.ChildNodes[i];
                if (classname == null || classname.Attributes == null) continue;
                XmlNode cnItem = classname.Attributes.GetNamedItem("classname");
                if (cnItem == null) continue;

                classnames[i] = cnItem.InnerText;
            }

            return classnames;
        }
    }
}
