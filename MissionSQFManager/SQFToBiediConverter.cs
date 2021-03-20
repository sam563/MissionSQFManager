using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSQFManager
{
    class SQFToBiediConverter
    {
        public static void ConvertInputsToBiedi()
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
                if (SQFToBiedi(fileName)) i++;
            }

            watch.Stop();

            if (i < 1) return;

            Console.WriteLine("");
            Console.WriteLine($"Converted {i} .sqf files to .biedi in {watch.ElapsedMilliseconds}ms.");
        }

        public static bool SQFToBiedi(string fileName)
        {
            string file = File.ReadAllText(Path.Combine(Utils.GetInputPath(), fileName));

            if (file.Length < 1)
            {
                Utils.WriteError("File is empty!");
                return false;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            GameObject[] gameObjects = SQFConverter.SQFToGameObjects(file);

            List<string> lines = new List<string>();

            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject go = gameObjects[i];

                int preLines = lines.Count;

                lines.Add($"class _vehicle_{i}");
                lines.Add("{");
                lines.Add("    objectType=\"vehicle\";");
                lines.Add("    class Arguments");
                lines.Add("    {");
                lines.Add($"        POSITION={go.position};");
                lines.Add($"        TYPE={go.className};");
                lines.Add($"		AZIMUT={go.direction};");
                if (go.isVectorUp) lines.Add($"		INIT=\"this setVectorUp[0, 0, 1]; \";");
                lines.Add("		PARENT=\"\";");
                lines.Add("	};");
                lines.Add("};");

                for (int j = preLines; j < lines.Count; j++)
                {
                    Console.WriteLine(lines[j]);
                }
            }

            string directory = Utils.GetOutputPath();
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            string biedi = Path.ChangeExtension(Path.GetFileName(fileName), ".biedi");

            string path = Path.Combine(Utils.GetOutputPath(), biedi);

            File.WriteAllLines(path, lines);

            watch.Stop();

            Console.WriteLine("");
            Console.WriteLine($"Converted {fileName} to {biedi} in {watch.ElapsedMilliseconds}ms. Warning: indentations are not accurately represented in the console.");

            return true;
        }
    }
}
