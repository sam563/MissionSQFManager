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
        public static string[] FormatGameObjects(GameObject[] gameObjects, string format, int indentations, string prefix, string suffix)
        {
            var formatted = new List<string>();

            if (string.IsNullOrEmpty(format)) return null;

            string indents = string.Empty;

            for (int i = 0; i < indentations; i++)
            {
                indents += "	";
            }

            if (!string.IsNullOrEmpty(prefix)) formatted.Add(prefix);

            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject gameObject = gameObjects[i];

                if (gameObject == null) System.Diagnostics.Trace.TraceError($"Game object at index {i} was null!");

                string comma = (i >= (gameObjects.Length - 1)) ? "" : ",";
                string isInit = (!string.IsNullOrEmpty(gameObject.init)) ? "true" : "false";

                formatted.Add(Format($"{indents}{format}", $"\"{gameObject.className}\"", $"[{gameObject.position}]", gameObject.direction, $"\"{gameObject.init}\"", isInit, comma));
            }

            if (!string.IsNullOrEmpty(suffix)) formatted.Add(suffix);

            return formatted.ToArray();
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
