using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSQFManager
{
    public class SQFConverter
    {
        public static GameObject[] SQFToGameObjects(string file)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            GameObject gameObject = null;

            int openQuotePos = -1;
            int closingQuotePos = -1;
            int positionStart = -1;
            int dirStart = -1;
            int dirEnd = -1;

            for (int i = 0; i < file.Length; i++)
            {

                char cur = file[i];

                //Console.WriteLine($"{cur} a");

                if (IsCreateVehicle(file, i))
                {
                    //If we have looped around from last time make sure to add false for set vector as it was not there.
                    if (gameObject != null)
                    {
                        //The data set for this object is complete!
                        gameObject.isVectorUp = false;
                        gameObjects.Add(gameObject);

                        dirEnd = -1;
                    }

                    //Start tracking class name.
                    openQuotePos = i + 1;
                }

                bool isClosingQuote = ((i > openQuotePos && openQuotePos > 0) && cur == '"');
                if (isClosingQuote)
                {
                    closingQuotePos = i + 1;

                    int classNameLength = (closingQuotePos - openQuotePos);

                    string classname = file.Substring(openQuotePos, classNameLength);
                    gameObject = new GameObject(classname);

                    openQuotePos = -1;
                }

                if (closingQuotePos > 0 && cur == ']')
                {
                    positionStart = (closingQuotePos + 2);

                    gameObject.position = file.Substring(positionStart, (i - closingQuotePos) - 1);

                    closingQuotePos = -1;
                }

                if (positionStart > 0 && IsSetDir(file, i))
                {
                    dirStart = (i + 1);
                }

                if (dirStart > 0 && cur == ';')
                {
                    dirEnd = (i - 1);
                    gameObject.direction = file.Substring(dirStart, dirEnd - dirStart);

                    dirStart = -1;
                }

                if (dirEnd > 0 && IsSetVectorUp(file, i))
                {
                    //The data set for this object is complete!
                    gameObject.isVectorUp = true;
                    gameObjects.Add(gameObject);

                    dirEnd = -1;
                }
            }

            return gameObjects.ToArray();
        }

        private static bool IsCreateVehicle(string sqf, int charPos)
        {
            return (charPos > 2 && (sqf[charPos] == '[') && (sqf[charPos - 1] == ' ') && (sqf[charPos - 2] == 'e'));
        }

        private static bool IsSetDir(string sqf, int charPos)
        {
            return ((sqf[charPos] == ' ') && (sqf[charPos - 1] == 'r') && (sqf[charPos - 2] == 'i') && (sqf[charPos - 3] == 'D'));
        }

        private static bool IsSetVectorUp(string sqf, int charPos)
        {
            return ((sqf[charPos] == 'V') && (sqf[charPos + 1] == 'e') && (sqf[charPos + 2] == 'c') && (sqf[charPos + 3] == 't'));

        }
    }
}
