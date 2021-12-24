using System.Collections.Generic;

namespace MissionSQFManager
{
    public class SQFToGOConverter
    {
        //Keywords used to check for points of interest within the SQF file
        private const string vehicleKeyword = "createVehicle";
        private const string unitKeyword = "createUnit";
        private const string directionKeyword = "setDir";
        private const string initKeyword = "setVehicleInit";

        public static GameObject[] SQFToGameObjects(string sqf)
        {
            List<GameObject> gameObjects = new List<GameObject>(); //All gameobjects extracted from the inputted SQF

            GameObject gameObject = null; //Current gameobject we're putting together

            ReferencePoint state = ReferencePoint.Default; //A flag to mark the state so we know what we're currently looking for

            int startPos = -1; //The index of the position in the file at which marks the start of the desired value within the SQF

            for (int i = 0; i < sqf.Length; i++)
            {
                char currentChar = sqf[i];

                if (currentChar == 'c')
                {
                    if (((i + vehicleKeyword.Length) <= sqf.Length) && (sqf.Substring(i, vehicleKeyword.Length) == vehicleKeyword))
                    {
                        if (gameObject != null) gameObjects.Add(gameObject);
                        gameObject = new GameObject
                        {
                            type = GameObject.Type.Object
                        };
                        state = ReferencePoint.Type;

                        continue;
                    }
                    else if (((i + unitKeyword.Length) <= sqf.Length) && (sqf.Substring(i, unitKeyword.Length) == unitKeyword))
                    {
                        if (gameObject != null) gameObjects.Add(gameObject);
                        gameObject = new GameObject
                        {
                            type = GameObject.Type.Unit
                        };
                        state = ReferencePoint.Type;
                        continue;
                    }
                }

                if (state == ReferencePoint.Type && currentChar == '"')
                {
                    startPos = i;
                    state = ReferencePoint.ClassnameStart;
                    continue;
                }

                if (state == ReferencePoint.ClassnameStart && currentChar == '"')
                {
                    int textStart = startPos + 1;

                    int textLength = ((i - startPos) - 1);
                    gameObject.className = sqf.Substring(textStart, textLength);

                    string[] vehicles = Utils.GetAllVehicleClassnames();

                    if (vehicles != null && gameObject.type == GameObject.Type.Object)
                    {
                        //Check if the object is a vehicle by comparing its classname to vehicles array
                        for (int j = 0; j < vehicles.Length; j++)
                        {
                            if (gameObject.className == vehicles[j])
                            {
                                gameObject.type = GameObject.Type.Vehicle;
                                break;
                            }
                        }
                    }

                    state = ReferencePoint.ClassnameEnd;
                    continue;
                }

                if (state == ReferencePoint.ClassnameEnd && currentChar == '[')
                {
                    startPos = i;
                    state = ReferencePoint.PositionStart;
                    continue;
                }

                if (state == ReferencePoint.PositionStart && currentChar == ']')
                {
                    string position = sqf.Substring((startPos + 1), (i - (startPos + 1)));

                    if (Vector3.TryParse(position, out Vector3 result))
                    {
                        gameObject.position = result;
                        state = ReferencePoint.PositionEnd;
                        startPos = -1;
                        continue;
                    }
                }

                
                if (state == ReferencePoint.PositionEnd && currentChar == 's')
                {
                    string s = sqf.Substring(i, directionKeyword.Length);

                    if (s == directionKeyword)
                    {
                        state = ReferencePoint.DirectionStart;
                        startPos = i + directionKeyword.Length + 1;
                        continue;
                    }
                }

                if (state == ReferencePoint.DirectionStart && startPos > 0 && currentChar == ';')
                {
                    string s = sqf.Substring(startPos, i - startPos);
                    if (float.TryParse(s, out float dir))
                    {
                        gameObject.direction = dir;
                        startPos = -1;
                        state = ReferencePoint.DirectionEnd;
                    }
                }
                
                if (state == ReferencePoint.DirectionEnd && currentChar == 's')
                {
                    if (sqf.Length >= (i + initKeyword.Length))
                    {
                        string s = sqf.Substring(i, initKeyword.Length);
                        if (s == initKeyword)
                        {
                            state = ReferencePoint.InitStart;
                            continue;
                        }
                    }
                }
                
                if (state == ReferencePoint.InitStart && currentChar == '"')
                {
                    startPos = i;
                    state = ReferencePoint.InitEnd;
                    continue;
                }

                
                if (state == ReferencePoint.InitEnd && currentChar == ';')
                {
                    string s = sqf.Substring((startPos + 1), (i - startPos));
                    gameObject.init = s;

                    state = ReferencePoint.Default;
                    startPos = -1;

                    continue;
                }
            }

            if (gameObject != null) gameObjects.Add(gameObject); //We will never loop back around to another classname so add the gameobject in progress!

            return gameObjects.ToArray();
        }

        private enum ReferencePoint
        {
            Default,
            Type,
            ClassnameStart,
            ClassnameEnd,
            PositionStart,
            PositionEnd,
            DirectionStart,
            DirectionEnd,
            InitStart,
            InitEnd
        }
    }
}
