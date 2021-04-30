using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace MissionSQFManager
{
    public class SQFToGOConverter
    {
        private static GameObject[] gameObjects;

        public static GameObject[] GameObjects { get => gameObjects; private set => gameObjects = value; }

        public static GameObject[] SQFToGameObjects(string file)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            GameObject gameObject = null; //Current

            string flag = string.Empty;

            int startPos = -1;

            for (int i = 0; i < file.Length; i++)
            {
                char cur = file[i];

                if (cur == 'c')
                {
                    string vehicle = "createVehicle";
                    string unit = "createUnit";

                    if (((i - 1) + vehicle.Length <= file.Length) && (file.Substring(i, vehicle.Length) == vehicle))
                    {
                        if (gameObject != null) gameObjects.Add(gameObject);
                        gameObject = new GameObject
                        {
                            type = GameObject.Type.Vehicle
                        };
                        flag = "type";

                        continue;
                    }
                    else if (((i - 1) + unit.Length <= file.Length) && (file.Substring(i, unit.Length) == unit))
                    {
                        if (gameObject != null) gameObjects.Add(gameObject);
                        gameObject = new GameObject
                        {
                            type = GameObject.Type.Unit
                        };
                        flag = "type";
                        continue;
                    }
                }

                if (flag == "type" && cur == '"')
                {
                    startPos = i;
                    flag = "classnameOpen";
                    continue;
                }

                if (flag == "classnameOpen" && cur == '"')
                {
                    int textStart = startPos + 1;

                    int textLength = ((i - startPos) - 1);
                    gameObject.className = file.Substring(textStart, textLength);
                    flag = "classnameClose";
                    continue;
                }

                
                if (flag == "classnameClose" && cur == '[')
                {
                    startPos = i;
                    flag = "positionOpen";
                    continue;
                }

                if (flag == "positionOpen" && cur == ']')
                {
                    string position = file.Substring((startPos + 1), (i - (startPos + 1)));

                    if (Vector3.TryParse(position, out Vector3 result))
                    {
                        gameObject.position = result;
                        flag = "positionClose";
                        startPos = -1;
                        continue;
                    }
                }

                
                if (flag == "positionClose" && cur == 's')
                {
                    string dir = "setDir";
                    string s = file.Substring(i, dir.Length);

                    if (s == dir)
                    {
                        flag = "setDir";
                        continue;
                    }
                }

                if (flag == "setDir" && startPos < 0 && (char.IsDigit(cur) || cur == '-'))
                {
                    startPos = i;
                    flag = "startDirection";
                    continue;
                }

                if (flag == "startDirection" && startPos > 0 && cur == ';')
                {
                    string s = file.Substring(startPos, i - startPos);
                    if (float.TryParse(s, out float dir))
                    {
                        gameObject.direction = dir;
                        startPos = -1;
                        flag = "endDirection";
                    }
                }
                
                if (flag == "endDirection" && cur == 's')
                {
                    string init = "setVehicleInit";
                    if (file.Length >= ((i - 1) + init.Length))
                    {
                        string s = file.Substring(i, init.Length);
                        if (s == init)
                        {
                            flag = "init";
                            continue;
                        }
                    }
                }
                
                if (flag == "init" && cur == '"')
                {
                    startPos = i;
                    flag = "initClose";
                    continue;
                }

                
                if (flag == "initClose" && cur == ';')
                {
                    string s = file.Substring((startPos + 1), (i - startPos));
                    gameObject.init = s;

                    flag = string.Empty;
                    startPos = -1;

                    continue;
                }
            }

            var goArr = gameObjects.ToArray();
            GameObjects = goArr; //Cache gameobjects
            return GameObjects;
        }
    }
}
