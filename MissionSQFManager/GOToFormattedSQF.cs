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
        public static string[] FormatGameObjects(GameObject[] gameObjects)
        {
            string[] formattedArray = new string[gameObjects.Length];

            if (!Utils.GetConfigXML(out XmlDocument xmlDoc)) return formattedArray;

            XmlNodeList Clist = xmlDoc.GetElementsByTagName("Format");


            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject gameObject = gameObjects[i];

                if (gameObject == null) System.Diagnostics.Trace.TraceError($"Game object at index {i} was null!");

                string comma = (i < gameObjects.Length) ? "," : "";
                string isInit = (!string.IsNullOrEmpty(gameObject.init)) ? "true" : "false";
                formattedArray[i] = string.Format(Clist[0].InnerText, $"\"{gameObject.className}\"", $"[{gameObject.position}]", gameObject.direction, $"\"{gameObject.init}\"", isInit, comma);
            }

            return formattedArray;
        }
    }
}
