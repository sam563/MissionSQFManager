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
        public static void WriteError(string errorMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error, {errorMsg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string GetInputPath() => (Path.Combine(Directory.GetCurrentDirectory(), Program.inputFolder));

        public static string GetOutputPath() => (Path.Combine(Directory.GetCurrentDirectory(), Program.outputFolder));

        public static bool GetConfigXML(out XmlDocument xmlDoc)
        {
            xmlDoc = new XmlDocument();
            string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), Program.configName);

            if (File.Exists(xmlPath))
            {
                xmlDoc.Load(xmlPath);
                return true;
            }
            else
            {
                WriteError($"Could not find config at {xmlPath}!");
                return false;
            }
        }

        public static string[] GetFileNamesInInput()
        {
            var paths = Directory.GetFiles(GetInputPath());

            if (paths.Length <= 0)
            {
                return paths;
            }

            string[] names = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                names[i] = Path.GetFileName(paths[i]);
            }

            return names;
        }

        public static char FindNextNoneSpaceChar(string text, int position)
        {
            for (int i = (position + 1); i < text.Length; i++)
            {
                char cur = text[i];

                if (cur != ' ') return cur;
            }

            return new char();
        }

        public static char FinddPreviousNoneSpaceChar(string text, int position)
        {
            for (int i = (position - 1); i <= 0; i--)
            {
                char cur = text[i];

                if (cur != ' ') return cur;
            }

            return new char();
        }
    }
}
