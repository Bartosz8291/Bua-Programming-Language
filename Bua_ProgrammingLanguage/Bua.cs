using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bua_ProgrammingLanguage.Bua_Assets;

namespace Bua_ProgrammingLanguage
{
    public static class Bua
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Bua 1.0.0 32-bit");
                Console.WriteLine("Type \"help\" for a list of avaliable commands.");

                while (true)
                {
                    Console.Write("> ");
                    var command = Console.ReadLine();
                    Commands.RunCommand(command);
                }
            }
            else
            {
                string filePath = args[0];

                if (!filePath.EndsWith(".bua", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[Error] ");
                    Console.ResetColor();
                    Console.WriteLine("Only .bua files are accepted.");
                    return;
                }

                if (File.Exists(filePath))
                {
                    var code = File.ReadAllText(filePath);
                    var lines = code.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        Commands.RunCommand(line.Trim());
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[Error] ");
                    Console.ResetColor();
                    Console.WriteLine("File does not exist.");
                }
            }
        }
    }
}
