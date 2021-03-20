using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    public class SQFFormatter
    {
        public static void FormatInputFiles()
        {
            var fileNames = Utils.GetFileNamesInInput();

            if (fileNames.Length <= 0)
            {
                Utils.WriteError("No files in input directory!");
                return;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int i = 0;
            foreach (string fileName in fileNames)
            {
                if (FormatCodeToOutput(fileName)) i++;
            }

            watch.Stop();

            if (i < 1) return;

            Console.WriteLine("");
            Console.WriteLine($"Formatted code for {i} files in {watch.ElapsedMilliseconds}ms.");
        }

        public static bool FormatCodeToOutput(string inputFileName)
        {
            string file = File.ReadAllText(Path.Combine(Utils.GetInputPath(), inputFileName));

            if (file.Length <= 0)
            {
                Utils.WriteError($"File {inputFileName} is empty!");
                return false;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var gameObjects = SQFConverter.SQFToGameObjects(file);

            if (gameObjects.Length <= 0)
            {
                Utils.WriteError($"Unexpected file {inputFileName}, expected data was not found!");
                return false;
            }

            string[] formattedLines = FormatGameObjectArray(gameObjects);

            string directory = Utils.GetOutputPath();
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            File.WriteAllLines(Path.Combine(Utils.GetOutputPath(), inputFileName), formattedLines);
            Console.WriteLine("");
            Console.WriteLine($"Successfully compacted code for file {inputFileName} to {formattedLines.Length} lines in {watch.ElapsedMilliseconds}ms.");
            return true;
        }

        private static string[] FormatGameObjectArray(GameObject[] gameObjects)
        {
            string[] formattedArray = new string[gameObjects.Length];

            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (GameObjectToFormattedString(out string line, gameObjects[i]))
                {
                    formattedArray[i] = line;

                    Console.WriteLine(line);
                }
            }

            return formattedArray;
        }

        private static bool GameObjectToFormattedString(out string line, GameObject gameObject)
        {
            line = "";

            if (!Utils.GetConfigXML(out XmlDocument xmlDoc)) return false;

            XmlNodeList Clist = xmlDoc.GetElementsByTagName("Format");

            line = string.Format(Clist[0].InnerText, gameObject.className, gameObject.position, gameObject.direction, gameObject.isVectorUp);

            return true;
        }
    }
}
