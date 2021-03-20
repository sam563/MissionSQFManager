using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    class SQFClassNameCorrector
    {
        class ClassNames
        {
            public ClassNames(string original, string replacement)
            {
                this.original = original;
                this.replacement = replacement;
            }

            public string original;
            public string replacement;
        }

        public static void ReplaceClassNamesOfInputFiles()
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
                if (ReplaceClassnames(fileName)) i++;
            }

            watch.Stop();

            if (i < 1) return;

            Console.WriteLine("");
            Console.WriteLine($"Replaced classnames for {i} files in {watch.ElapsedMilliseconds}ms.");
        }

        public static bool ReplaceClassnames(string fileName)
        {
            string file = File.ReadAllText(Path.Combine(Utils.GetInputPath(), fileName));

            if (file.Length < 1)
            {
                Utils.WriteError("File is empty!");
                return false;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (!GetClassNamesFromXML(out List<ClassNames> classNames))
            {
                watch.Stop();
                return false;
            }

            for (int i = 0; i < classNames.Count; i++)
            {
                file = file.Replace(classNames[i].original, classNames[i].replacement);
            }

            string directory = Utils.GetOutputPath();
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            File.WriteAllText(Path.Combine(Utils.GetOutputPath(), fileName), file);

            watch.Stop();

            Console.WriteLine($"Replaced classnames for file {fileName} from ({classNames.Count}) nodes in {watch.ElapsedMilliseconds}ms.");
            return true;
        }

        private static bool GetClassNamesFromXML(out List<ClassNames> classnames)
        {
            classnames = new List<ClassNames>();

            if (!Utils.GetConfigXML(out XmlDocument xmlDoc)) return false;

            XmlNodeList Clist = xmlDoc.GetElementsByTagName("Classname");

            for (int i = 0; i < Clist.Count; i++)
            {
                var currentAttributes = Clist[i].Attributes;

                string originalClassname = currentAttributes.GetNamedItem("original").InnerText;
                string replacementClassname = currentAttributes.GetNamedItem("replacement").InnerText;

                classnames.Add(new ClassNames(originalClassname, replacementClassname));
            }

            return true;
        }
    }
}
