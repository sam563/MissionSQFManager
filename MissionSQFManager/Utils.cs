using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MissionSQFManager
{
    public class Utils
    {
        public static void DebugWindow(object msg)
        {
            System.Windows.Forms.MessageBox.Show(msg.ToString(), "Debug");
        }

        public static bool GetElementFromConfig(string elementTag, out string result)
        {
            result = string.Empty;
            if (!GetConfigXML(out XmlDocument xmlDoc)) return false;
            result = xmlDoc.GetElementsByTagName(elementTag)[0].InnerText;

            return true;
        }

        public static bool GetConfigXML(out XmlDocument xmlDoc)
        {
            xmlDoc = new XmlDocument();
            string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Config.xml");

            if (File.Exists(xmlPath))
            {
                xmlDoc.Load(xmlPath);
                return true;
            }
            else
            {
                System.Diagnostics.Trace.TraceError($"Could not find config at {xmlPath}!");
                return false;
            }
        }

        public static bool FindNextChar(string text, int currentCharIndex, out char character, params char[] blacklists)
        {
            if (FindNextChar(text, currentCharIndex, out int charPos, blacklists))
            {
                character = text[charPos];
                return true;
            }
            else
            {
                character = new char();
                return false;
            }
        }

        public static bool FindNextChar(string text, int currentCharIndex, out int charPos, params char[] blacklists)
        {
            charPos = -1;

            for (int i = (currentCharIndex + 1); i < text.Length; i++)
            {
                char cur = text[i];

                bool isBlacklisted = false;

                for (int j = 1; j < blacklists.Length; j++)
                {
                    if (cur == blacklists[i])
                    {
                        isBlacklisted = true;
                        break;
                    }
                }

                if (isBlacklisted) continue;

                charPos = i;
                return true;
            }

            return false;
        }

        public static bool FindPreviousChar(string text, int currentCharIndex, out char character, params char[] blacklists)
        {
            if (FindPreviousChar(text, currentCharIndex, out int charPos, blacklists))
            {
                character = text[charPos];
                return true;
            }
            else
            {
                character = new char();
                return false;
            }
        }

        public static bool FindPreviousChar(string text, int currentCharIndex, out int charPos, params char[] blacklists)
        {
            charPos = -1;

            for (int i = (currentCharIndex - 1); i >= 0; i--)
            {
                char cur = text[i];

                bool isBlacklisted = false;

                for (int j = 1; j < blacklists.Length; j++)
                {
                    if (cur == blacklists[j])
                    {
                        isBlacklisted = true;
                        break;
                    }
                }

                if (isBlacklisted) continue;

                charPos = i;
                return true;
            }

            return false;
        }
    }
}
