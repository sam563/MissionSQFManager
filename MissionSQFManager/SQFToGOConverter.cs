using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    public class SQFToGOConverter
    {
        //private static List<GameObject> gameObjects;

        //public static List<GameObject> GetGameObjectsFromFile(string file)
        //{
        //    if (gameObjects == null || gameObjects.Count <= 0)
        //    {
        //        return SQFToGameObjects(file);
        //    }

        //    return gameObjects;
        //}

        public static GameObject[] SQFToGameObjects(string file)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            GameObject gameObject = null;

            string patternStartPoint = "";

            void CheckSetStartPoint(string landmarkID)
            {
                /*
                In order to know when to start a new gameobject we must know what parameter is the starting point
                for example if the starting point is the Classname as soon as we get back to the Classname we know
                we must start a new gameObject.
                */
                if (gameObject == null || patternStartPoint == landmarkID)
                {
                    if (gameObject != null) gameObjects.Add(gameObject); //Only add it if we're back to the start of the pattern. Not if we are defining it as the start
                    gameObject = new GameObject();
                    patternStartPoint = landmarkID;
                }
            }

            int openQuotePos = -1;
            int openPositionPos = -1;

            for (int i = 0; i < file.Length; i++)
            {
                char cur = file[i];

                if (cur == 'c')
                {
                    string vehicle = "createVehicle";
                    string unit = "createUnit";

                    if (((i - 1) + vehicle.Length <= file.Length) && (file.Substring((i - 1), vehicle.Length) == vehicle))
                    {
                        CheckSetStartPoint("type");
                        gameObject.type = GameObject.Type.Vehicle;
                    }
                    else if (((i - 1) + unit.Length <= file.Length) && (file.Substring((i - 1), unit.Length) == unit))
                    {
                        CheckSetStartPoint("type");
                        gameObject.type = GameObject.Type.Unit;
                    }

                    continue;
                }

                if (openQuotePos < 0 && cur == '"') openQuotePos = i; //Check if we found an opening quote

                if (openQuotePos < i && openQuotePos >= 0 && cur == '"')
                {

                    int textStart = openQuotePos + 1;
                    //Console.WriteLine($"Currently at char {i}, open quote at {openQuotePos}. Length {i - textStart}");
                    string text = file.Substring(textStart, (i - openQuotePos) - 1);

                    //Now determine if the string is a classname or init
                    if (!StringContainsSpace(text))
                    {
                        if (!IsClassName(text)) continue;

                        CheckSetStartPoint("classname");
                        gameObject.className = text;
                    }
                    else
                    {
                        CheckSetStartPoint("init");
                        gameObject.init = text;
                    }

                    openQuotePos = -1;

                    continue;
                }

                if (cur == '[' && char.IsDigit(Utils.FindNextNoneSpaceChar(file, i))) openPositionPos = i;

                if (openPositionPos < i && openPositionPos > 0 && cur == ']')
                {
                    string position = file.Substring((openPositionPos + 1), ((i - 1) - (openPositionPos + 1)));

                    Vector3.TryParse(position, out Vector3 result);

                    CheckSetStartPoint("position");
                    gameObject.position = result;

                    openPositionPos = -1;

                    continue;
                }

                if (char.IsDigit(cur) && !char.IsDigit(file[i + 1])) //Are we looking at the end of a number?
                {
                    //Rule out the posibility of it being a number in a position
                    if (Utils.FindNextNoneSpaceChar(file, i) == ',') continue; 
                    
                    int j;
                    for (j = i; j >= 0; j--)
                    {
                        if (!char.IsDigit(file[j]) && file[j] != '.') break;
                    }

                    //Now we're at the start of the number...
                    int startNum = j + 1;

                    //Now make sure there is no comma that comes directly before it.
                    if (Utils.FinddPreviousNoneSpaceChar(file, startNum) == ',') continue;
                    
                    //We should now know this is a direction.

                }
            }

            return gameObjects.ToArray();
        }

        private static bool IsClassName(string s)
        {
            string[] blackLists =
            {
                "NONE",
                "CAN_COLLIDE",
                "FLY"
            };

            foreach (string blackList in blackLists)
            {
                if (s == blackList) return false;
            }

            return true;
        }

        private static bool StringContainsSpace(string text)
        {
            return text.Contains(' ');
        }
    }
}
