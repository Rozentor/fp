﻿using System.Linq;
using CommandLine;
using TagCloud.Utility;
using TagCloud.Utility.Container;

namespace TagCloud.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Clear();
                Parser.Default
                    .ParseArguments<Options>(args)
                    .WithParsed(Run);
                System.Console.WriteLine("Waiting for next command... ( write \"exit\" to exit)");
                args = System.Console.ReadLine()?.Split(' ');
                
                if (args != null && args.Contains("exit"))
                    break;
            }
        }

        private static void Run(Options options)
        {
            TagCloudProgram.Execute(options)
                .OnFail(System.Console.WriteLine)
                .Then(x => System.Console.WriteLine($"Picture saved to {options.PathToPicture}"));
        }
    }
}