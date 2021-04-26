using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSQFManager
{
    class GOToBiediConverter
    {
        public static string[] GOToBiedi(GameObject[] gameObjects)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject go = gameObjects[i];

                lines.AddRange( new string[]
                    { $"class _vehicle_{i}",
                    "{",
                    "    objectType=\"vehicle\";",
                    "    class Arguments",
                    "    {",
                    $"        POSITION=[{go.position}];",
                    $"        TYPE=\"{go.className}\";",
                    $"		AZIMUT={go.direction};",
                    (!string.IsNullOrEmpty(go.init)) ? $"      INIT =\"{go.init}\";" : "",
                    "		PARENT=\"\";",
                    "	};",
                    "};"}
                );
            }

            return lines.ToArray();
        }
    }
}
