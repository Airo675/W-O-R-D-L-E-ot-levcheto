using System;
using System.Linq;

namespace Wordle_clone
{
    class Program
    {
        static void Main(string[] args)
        {
            program();
            void program()
            {
                String status = "Napishi Duma:";
            char[,] poznatiBukvi = new Char[5, 5];
            int[,] statusNaBukvi = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    poznatiBukvi[i, j] = ' ';
                    statusNaBukvi[i, j] = 0;
                }
            }
            String doluLqvo = "\u255A",
                doluDqsno = "\u255D",
                goreDqsno = "\u2557",
                goreLqvo = "\u2554",
                doluConnector = "\u2569",
                goreConnector = "\u2566",
                dqsnoConnector = "\u2563",
                lqvoConnector = "\u2560",
                vertical = "\u2551",
                horizontal = "\u2550",
                everyConnector = "\u256C";
            Words words = new Words();
            Random random = new Random();
            int chislo = random.Next(0, 2314);
            String duma = words.dailyWords[chislo];
            
            for (int i = 0; i < 6; i++)
            {
                if (i == 5)
                {
                    status = $"Gubish! Dumata beshe {duma}. Isk li pak? y/n";
                    print();
                    String a = Console.ReadLine();
                    if (a.Contains("y"))
                    {
                        program();                       
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                print();
                String input = Console.ReadLine();
                if (!words.validWords.Contains(input.ToLower()))
                {
                    status = "Nevalidna duma. Probvai pak";
                    print();
                    i--;
                }
                else
                {
                    if (input.ToLower().Contains(duma))
                    {
                        status = "Pechelish! Isk li pak? y/n";
                        for (int j = 0; j < 5; j++)
                        {
                            poznatiBukvi[i, j] = duma[j];
                            statusNaBukvi[i, j] = 2;
                            print();
                        }
                        String a = Console.ReadLine();
                        if (a.Contains("y"))
                        {
                            program();                       
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        status = "Napishi Duma:";
                        for (int j = 0; j < 5; j++)
                        {
                            poznatiBukvi[i, j] = input.ToLower()[j];
                            if (duma.Contains(input[j]) && input[j] == duma[j])
                            {
                                statusNaBukvi[i, j] = 2;
                            }
                            else if (duma.Contains(input[j]))
                            {
                                statusNaBukvi[i, j] = 1;
                            }
                            else
                            {
                                statusNaBukvi[i, j] = 0;
                            }
                        }
                    }
                }
            }

            void print()
            {
                Console.Clear();
                Console.WriteLine(
                    $"{goreLqvo}{horizontal}{horizontal}{horizontal}{goreConnector}{horizontal}{horizontal}{horizontal}{goreConnector}{horizontal}{horizontal}{horizontal}{goreConnector}{horizontal}{horizontal}{horizontal}{goreConnector}{horizontal}{horizontal}{horizontal}{goreDqsno}");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{vertical}");
                    for (int j = 0; j < 5; j++)
                    {
                        switch (statusNaBukvi[i,j])
                        {
                            case 0: Console.Write($" {poznatiBukvi[i,j]} {vertical}"); break;
                            case 1: Console.BackgroundColor = ConsoleColor.DarkYellow; Console.Write($" {poznatiBukvi[i,j]} ");
                                Console.BackgroundColor = ConsoleColor.Black; Console.Write($"{vertical}"); break;
                            case 2: Console.BackgroundColor = ConsoleColor.Green; Console.Write($" {poznatiBukvi[i,j]} ");
                                Console.BackgroundColor = ConsoleColor.Black; Console.Write($"{vertical}"); break;
                        }
                    }
                    Console.Write("\r\n");

                    if (i < 4)
                    {
                        Console.Write($"{lqvoConnector}{horizontal}{horizontal}{horizontal}{everyConnector}{horizontal}{horizontal}{horizontal}{everyConnector}{horizontal}{horizontal}{horizontal}{everyConnector}{horizontal}{horizontal}{horizontal}{everyConnector}{horizontal}{horizontal}{horizontal}{dqsnoConnector}\r\n");
                    }
                    else
                    {
                        Console.Write($"{doluLqvo}{horizontal}{horizontal}{horizontal}{doluConnector}{horizontal}{horizontal}{horizontal}{doluConnector}{horizontal}{horizontal}{horizontal}{doluConnector}{horizontal}{horizontal}{horizontal}{doluConnector}{horizontal}{horizontal}{horizontal}{doluDqsno}\r\n");
                    }
                }

                Console.WriteLine("W - O - R - D - L - E");
                Console.WriteLine("O T   L E V C H E T O");
                Console.WriteLine($"\r\n{status}");
            }
            }
        }
    }
}