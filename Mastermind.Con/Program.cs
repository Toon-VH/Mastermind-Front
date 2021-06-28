using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Mastermind.Core;

namespace Mastermind.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Title();
            var mastermind = new MastermindEngine();

            /*Console.WriteLine(
                "Please enter the amount of colors you want to use ? Or press enter to use default game settings (6)");
            if (int.TryParse(Console.ReadLine(), out var result)) mastermind.ColorsAmount = result;

            Console.WriteLine("PLease enter row lenght ? Or press enter to use default game settings (4)");
            if (int.TryParse(Console.ReadLine(), out result)) mastermind.ColorsAmount = result;

            Console.WriteLine("Please enter a game lenght ? Or press enter to use default game settings (9)");
            if (int.TryParse(Console.ReadLine(), out result)) mastermind.ColorsAmount = result;*/

            Print(mastermind);
            do
            {
                foreach (var value in Enum.GetValues(typeof(AttemptColor)))
                {
                    Console.ForegroundColor = GetConsoleColor((AttemptColor) value);
                    Console.Write($"({value.ToString()[0]}){value.ToString().Substring(1)}    ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
                var attempt = "";
                Regex regex = new Regex(@"^[RGBMYC]{4}$", RegexOptions.IgnoreCase);
                Console.Write("Code: ");
                attempt = Console.ReadLine();
                if (!regex.IsMatch(attempt))
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Please enter a valid input:");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempt = Console.ReadLine();
                    } while (!regex.IsMatch(attempt));
                }

                mastermind.SaveAttempt(CodeToArray(attempt, mastermind.RowLength));
                mastermind.CalculateHints();
                Console.Clear();
                Title();
                Print(mastermind);
            } while (!mastermind.Validate() && mastermind.Attempts.Count < 9);

            if (mastermind.Validate())
            {
                Win(mastermind.Code);
            }
            else
            {
                Lost(mastermind.Code);
            }
        }

        private static AttemptColor[] CodeToArray(string code, int length)
        {
            var result = new AttemptColor[length];

            for (var i = 0; i < code.Length; i++)
            {
                result[i] = StringToColor(code[i]);
            }

            return result;
        }

        private static AttemptColor StringToColor(char color)
        {
            AttemptColor result;
            switch (char.ToUpper(color))
            {
                case 'R':
                    result = AttemptColor.Red;
                    break;
                case 'G':
                    result = AttemptColor.Green;
                    break;
                case 'Y':
                    result = AttemptColor.Yellow;
                    break;
                case 'B':
                    result = AttemptColor.Blue;
                    break;
                case 'M':
                    result = AttemptColor.Magenta;
                    break;
                case 'C':
                    result = AttemptColor.Cyan;
                    break;

                default:
                    result = AttemptColor.Red;
                    break;
            }

            return result;
        }

        private static void Print(MastermindEngine core)
        {
            var counter = 1;
            core.Attempts.ForEach(a =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{counter++} ");
                a.AttemptColors.ToList().ForEach(ac =>
                {
                    Console.ForegroundColor = GetConsoleColor(ac);
                    Console.Write(ac.ToString()[0] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\tHint {a.CorrectPositionColor}/{a.CorrectColor}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            });
            var emptyLines = core.GameLenght - core.Attempts.Count;
            for (int i = 0; i < emptyLines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{counter++} ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
                for (int j = 0; j < core.RowLength; j++)
                {
                    Console.Write("- ");
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }

        private static ConsoleColor GetConsoleColor(AttemptColor color)
        {
            ConsoleColor result;
            switch (color)
            {
                case AttemptColor.Red:
                    result = ConsoleColor.Red;
                    break;
                case AttemptColor.Green:
                    result = ConsoleColor.Green;
                    break;
                case AttemptColor.Blue:
                    result = ConsoleColor.Blue;
                    break;
                case AttemptColor.Magenta:
                    result = ConsoleColor.Magenta;
                    break;
                case AttemptColor.Yellow:
                    result = ConsoleColor.Yellow;
                    break;
                case AttemptColor.Cyan:
                    result = ConsoleColor.Cyan;
                    break;
                default:
                    result = ConsoleColor.White;
                    break;
            }

            return result;
        }

        private static void Lost(AttemptColor[] code)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(AsciiStrings.Lost);
            Console.Write("The code was: ");
            code.ToList().ForEach(color => Console.Write(color + " "));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Win(AttemptColor[] code)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(AsciiStrings.Win);
            Console.Write("The code was: ");
            code.ToList().ForEach(color => Console.Write(color + " "));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(AsciiStrings.Mastermind);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}