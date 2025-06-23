using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bua_ProgrammingLanguage.Bua_Assets
{
    public static class Commands
    {
        public static void RunCommand(string command)
        {
            command = command.Trim();

            string[] cmd = command.Split(' ');

            if(cmd[0] == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[Error] ");
                Console.ResetColor();
                Console.WriteLine("Command is Empty.");
            }
            else if(cmd[0] == "help")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("List of avaliable commands:");
                Console.ResetColor();
                ShowCommand("help", "Show this message");
                ShowCommand("exit", "Exit Bua interpeter");
                ShowCommand("clear", "Clears the console");
                ShowCommand("print <text>", "Prints text");
            }
            else if (cmd[0] == "exit")
            {
                Environment.Exit(0);
            }
            else if (cmd[0] == "clear")
            {
                Console.Clear();
            }
            else if (cmd[0] == "print")
            {
                if (cmd.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[Error] ");
                    Console.ResetColor();
                    Console.WriteLine("print requires an argument.");
                }
                else
                {
                    Console.WriteLine(string.Join(" ", cmd.Skip(1)));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[Error] ");
                Console.ResetColor();
                Console.WriteLine("Invalid Command");
            }
        }
        private static void ShowCommand(string name, string description)
        {
            Console.WriteLine($"{name} -- {description}");
        }
    }
}
