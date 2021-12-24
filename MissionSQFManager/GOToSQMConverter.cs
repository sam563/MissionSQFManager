using System.Collections.Generic;

namespace MissionSQFManager
{
    public class GOToSQMConverter
    {
        public static string[] GOToSQM(GameObject[] gameObjects)
        {
            string[] GetObjectLines(int index, GameObject go)
            {
                List<string> result = new List<string>(
                    new string[]
                    {
                        $"		class Item{index}",
                        "		{",
                        $"			position[]={{{go.position.x},{go.position.z},{go.position.y}}};",
                        $"			special=\"NONE\";",
                        $"			azimut=-{go.direction};",
                        $"			id={index};",
                        $"			side=\"EMPTY\";",
                        $"			vehicle=\"{go.className}\";",
                        $"			skill=0.60000002;"
                    }
                );
                if (!string.IsNullOrEmpty(go.init)) result.Add($"			init=\"{go.init}\"");
                result.Add("		};");

                return result.ToArray();
            }

            List<string> lines = new List<string>(
                new string[]
                {
                    "	class Vehicles",
                    "	{",
                    $"		items={gameObjects.Length};"
                }
            );

            for (int i = 0; i < gameObjects.Length; i++)
            {
                lines.AddRange(GetObjectLines(i, gameObjects[i]));
            }

            lines.Add("	};");

            return lines.ToArray();
        }
    }
}