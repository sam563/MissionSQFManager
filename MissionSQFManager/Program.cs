using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MissionSQFManager
{
    class Program
    {
        public const string title = "SQFMissionManager";
        public const string inputFolder = "Input";
        public const string outputFolder = "Output";
        public const string configName = "Config.xml";

        static void Main(string[] args)
        {
            Console.Title = title;

            Commands.RegisterCommands();
            Commands.DisplayHelp();

            //Console.WriteLine($"Input: {Utils.GetInputPath()}");
            //Console.WriteLine($"Output: {Utils.GetOutputPath()}");

            //Make sure input directory exists
            if (!Directory.Exists(Utils.GetInputPath())) Directory.CreateDirectory(Utils.GetInputPath());

            while (true)
            {
                HandleInput(Console.ReadLine());
            }
        }

        private static void HandleInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return;

            Commands.CallCommand(input);
        }
    }

}
