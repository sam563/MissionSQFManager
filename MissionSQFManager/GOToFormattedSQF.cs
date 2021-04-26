using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    public class GOToFormattedSQF
    {
        public static bool GetFormatFromConfig(out string format)
        {
            format = string.Empty;
            if (!Utils.GetConfigXML(out XmlDocument xmlDoc)) return false;

            format = xmlDoc.GetElementsByTagName("Format")[0].InnerText;
            return true;
        }

        public static string[] FormatGameObjects(GameObject[] gameObjects, string format)
        {
            string[] formattedArray = new string[gameObjects.Length];

            if (string.IsNullOrEmpty(format))
            {
                if (!GetFormatFromConfig(out format)) return null;
            }

            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject gameObject = gameObjects[i];

                if (gameObject == null) System.Diagnostics.Trace.TraceError($"Game object at index {i} was null!");

                string comma = (i >= (gameObjects.Length - 1)) ? "" : ",";
                string isInit = (!string.IsNullOrEmpty(gameObject.init)) ? "true" : "false";

                formattedArray[i] = Format(format, $"\"{gameObject.className}\"", $"[{gameObject.position}]", gameObject.direction, $"\"{gameObject.init}\"", isInit, comma);
            }

            return formattedArray;
        }

        private static string Format(string format, params object[] args)
        {
            char magicChar = '%';

            for (int i = 0; i < args.Length; i++)
            {
                string replace = string.Concat(magicChar, i);

                format = format.Replace(replace, args[i].ToString());
            }

            return format;
        }
    }
}
