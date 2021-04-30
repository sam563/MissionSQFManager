﻿using System;
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
            List<string> GetObjectLines(int index, GameObject go)
            {
                string type = ((go.type == GameObject.Type.Unit) ? "unit" : "vehicle");

                List<string> result = new List<string>(
                    new string[]
                    {
                        $"class _{type}_{index}",
                        "{",
                        $"    objectType=\"{type}\";",
                        "    class Arguments",
                        "    {",
                        $"		POSITION=[{go.position}];",
                        $"		TYPE=\"{go.className}\";",
                        $"		AZIMUT={go.direction};",
                    }
                );

                if (!string.IsNullOrEmpty(go.init)) result.Add($"		INIT =\"{go.init}\";");

                result.AddRange(
                    new string[]
                    {
                        "		PARENT=\"\";",
                        "    };",
                        "};"
                    }
                );

                return result;
            }

            List<string> lines = new List<string>();

            for (int i = 0; i < gameObjects.Length; i++)
            {
                lines.AddRange(GetObjectLines(i, gameObjects[i]));
            }

            return lines.ToArray();
        }
    }
}
