using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    class GOClassNameCorrector
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

        public static GameObject[] ReplaceClassnamesFromConfig(GameObject[] gameObjects)
        {
            var result = new GameObject[gameObjects.Length];

            if (!GetClassNamesFromXML(out var classnames)) return gameObjects;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                result[i] = GameObject.Copy(gameObjects[i]);

                for (int j = 0; j < classnames.Length; j++)
                {
                    if (gameObjects[i].className == classnames[j].original) result[i].className = classnames[j].replacement;
                }
            }

            return result;
        }

        private static bool GetClassNamesFromXML(out ClassNames[] classnames)
        {
            classnames = null;

            if (!Utils.GetConfigXML(out XmlDocument xmlDoc)) return false;

            XmlNodeList Clist = xmlDoc.GetElementsByTagName("Classname");

            var classnamesList = new List<ClassNames>();

            for (int i = 0; i < Clist.Count; i++)
            {
                var currentAttributes = Clist[i].Attributes;

                string originalClassname = currentAttributes.GetNamedItem("original").InnerText;
                string replacementClassname = currentAttributes.GetNamedItem("replacement").InnerText;

                classnamesList.Add(new ClassNames(originalClassname, replacementClassname));
            }

            classnames = classnamesList.ToArray();

            return true;
        }
    }
}
