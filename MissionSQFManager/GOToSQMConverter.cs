using System;
using System.Collections.Generic;
using System.Globalization;

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
                        $"			position[]={{{Math.Round(go.position.x, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture)},{Math.Round(go.position.x, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture)},{Math.Round(go.position.x, SQFMMForm.decimalPlaces).ToString(CultureInfo.InvariantCulture)}}};",
                        $"			special=\"NONE\";",
                        $"			azimut={go.GetDirectionAsString()};",
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