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
            //This is quite convoluted but we want to try to support modified sqf files so being as generic as possible

            List<GameObject> gameObjects = new List<GameObject>();

            GameObject gameObject = null;

            string patternStartPoint = "";

            int openQuotePos = -1;
            int openPositionPos = -1;

            bool isSingleQuote = false;
            bool ignoreContent = false;

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
                    openQuotePos = -1;
                    openPositionPos = -1;
                }
            }

            for (int i = 0; i < file.Length; i++)
            {
                char cur = file[i];

                if (cur == 'c')
                {
                    string vehicle = "createVehicle";
                    string unit = "createUnit";

                    if (((i - 1) + vehicle.Length <= file.Length) && (file.Substring(i, vehicle.Length) == vehicle))
                    {
                        CheckSetStartPoint("type");
                        gameObject.type = GameObject.Type.Vehicle;
                        continue;
                    }
                    else if (((i - 1) + unit.Length <= file.Length) && (file.Substring(i, unit.Length) == unit))
                    {
                        CheckSetStartPoint("type");
                        gameObject.type = GameObject.Type.Unit;
                        continue;
                    }
                }

                if (ignoreContent && cur == ']') ignoreContent = false; //We have reached the end of the addons array

                //Check if we found an opening quote
                if (!ignoreContent && openQuotePos < 0 && (cur == '"' || cur == '\''))
                {
                    openQuotePos = i;
                }

                char endQuote = isSingleQuote ? '\'' : '"';
                bool isStringception = ((i + 1 < file.Length) && file[i + 1] == endQuote) || (i > 0 && file[i - 1] == endQuote); //If theres a second quote next to it, its instructions within a string
                if (openQuotePos < i && openQuotePos >= 0 && cur == endQuote && !isStringception)
                {
                    //We found a closing quote

                    int textStart = openQuotePos + 1;
                    //Console.WriteLine($"Currently at char {i}, open quote at {openQuotePos}. Length {i - textStart}");

                    int textLength = ((i - openQuotePos) - 1);
                    string text = file.Substring(textStart, textLength);

                    //Now determine if the string is a classname or init
                    if (!text.Contains(' '))
                    {
                        if (IsClassName(text))
                        {
                            CheckSetStartPoint("classname");
                            gameObject.className = text;
                        }
                    }
                    else
                    {
                        CheckSetStartPoint("init");
                        gameObject.init = text;
                    }

                    openQuotePos = -1;

                    continue;
                }

                if (Utils.FindNextChar(file, i, out char nextChar, ' '))
                {
                    if (cur == '[' && char.IsDigit(nextChar)) openPositionPos = i;

                    //Make sure we're not reading strings from within addons
                    string addons = "activateAddons";

                    if (Utils.FindPreviousChar(file, i, out int character, ' '))
                    {
                        if (file[character] == 's')
                        {
                            int start = ((character - addons.Length) + 1);

                            if (file.Length >= addons.Length && start >= 0)
                            {

                                //Trace.WriteLine($"Start: {start}, Length: {addons.Length} Position: {i}");
                                var s = file.Substring(start, addons.Length);
                                //Trace.WriteLine(s);

                                if (s == addons)
                                {
                                    ignoreContent = true;
                                    continue;
                                }
                            }
                        }
                    }
                }

                if (openPositionPos < i && openPositionPos > 0 && cur == ']')
                {
                    if (Utils.FindPreviousChar(file, i, out char prev, ' ') && char.IsDigit(prev))
                    {
                        string position = file.Substring((openPositionPos + 1), (i - (openPositionPos + 1)));

                        if (Vector3.TryParse(position, out Vector3 result))
                        {
                            CheckSetStartPoint("position");
                            gameObject.position = result;

                            openPositionPos = -1;
                            continue;
                        }
                    }
                }

                //char[] numberChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', 'e' };

                //if (char.IsDigit(cur) && !numberChars.Contains(file[i + 1])) //Are we looking at the end of a number?
                //{
                //    if (Utils.FindPreviousChar(file, i, out int startNum, numberChars))
                //    {
                //        startNum++;

                //        //charPos now at start of number...
                //        if (Utils.FindPreviousChar(file, startNum, out int charPos, ' '))
                //        {
                //            string dir = "setDir";

                //            var s = file.Substring((charPos - dir.Length) + 1, dir.Length);
                //            Trace.WriteLine(s);

                //            if (s == dir)
                //            {
                //                if (float.TryParse(file.Substring(startNum, (i - startNum)), out float result))
                //                {
                //                    gameObject.direction = result;
                //                    CheckSetStartPoint("Direction");
                //                }
                //            }
                //        }
                //    }
                //}
            }

            var goArr = gameObjects.ToArray();
            GameObjects = goArr; //Cache gameobjects
            return goArr;
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
    }
}
