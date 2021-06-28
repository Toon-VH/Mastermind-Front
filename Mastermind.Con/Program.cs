using System;
using System.Linq;
using Mastermind.Core;

namespace Mastermind.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                                 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------. .----------------. 
                                | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
                                | | ____    ____ | || |      __      | || |    _______   | || |  _________   | || |  _________   | || |  _______     | || | ____    ____ | || |     _____    | || | ____  _____  | || |  ________    | |
                                | ||_   \  /   _|| || |     /  \     | || |   /  ___  |  | || | |  _   _  |  | || | |_   ___  |  | || | |_   __ \    | || ||_   \  /   _|| || |    |_   _|   | || ||_   \|_   _| | || | |_   ___ `.  | |
                                | |  |   \/   |  | || |    / /\ \    | || |  |  (__ \_|  | || | |_/ | | \_|  | || |   | |_  \_|  | || |   | |__) |   | || |  |   \/   |  | || |      | |     | || |  |   \ | |   | || |   | |   `. \ | |
                                | |  | |\  /| |  | || |   / ____ \   | || |   '.___`-.   | || |     | |      | || |   |  _|  _   | || |   |  __ /    | || |  | |\  /| |  | || |      | |     | || |  | |\ \| |   | || |   | |    | | | |
                                | | _| |_\/_| |_ | || | _/ /    \ \_ | || |  |`\____) |  | || |    _| |_     | || |  _| |___/ |  | || |  _| |  \ \_  | || | _| |_\/_| |_ | || |     _| |_    | || | _| |_\   |_  | || |  _| |___.' / | |
                                | ||_____||_____|| || ||____|  |____|| || |  |_______.'  | || |   |_____|    | || | |_________|  | || | |____| |___| | || ||_____||_____|| || |    |_____|   | || ||_____|\____| | || | |________.'  | |
                                | |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |
                                | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
                                 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
                                ");

            var mastermind = new MastermindEngine();

            Console.WriteLine(
                "Please enter the amount of colors you want to use ? Or press enter to use default game settings (6)");
            if (int.TryParse(Console.ReadLine(), out var result)) mastermind.ColorsAmount = result;

            Console.WriteLine("PLease enter row lenght ? Or press enter to use default game settings (4)");
            if (int.TryParse(Console.ReadLine(), out result)) mastermind.ColorsAmount = result;

            Console.WriteLine("Please enter a game lenght ? Or press enter to use default game settings (9)");
            if (int.TryParse(Console.ReadLine(), out result)) mastermind.ColorsAmount = result;

            Print(mastermind);
            do
            {
                foreach (var value in Enum.GetValues(typeof(AttemptColor)))
                {
                    Console.Write($"({value.ToString()[0]}){value.ToString().Substring(1)}    ");
                }
                Console.WriteLine();
                Console.Write("Code: ");
                var attempt = Console.ReadLine();
                mastermind.SaveAttempt(CodeToArray(attempt, mastermind.RowLength));
                mastermind.CalculateHints();
                Print(mastermind);
            } while (!mastermind.Validate());
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
                case 'P':
                    result = AttemptColor.Purple;
                    break;
                case 'O':
                    result = AttemptColor.Orange;
                    break;

                default:
                    result = AttemptColor.Red;
                    break;
            }

            return result;
        }

        private static void Print(MastermindEngine core)
        {
            core.Attempts.ForEach(a =>
            {
                a.AttemptColors.ToList().ForEach(ac => { Console.Write(ac.ToString()[0] + " "); });
                Console.Write($"\tHint {a.CorrectPositionColor}/{a.CorrectColor}");
                Console.WriteLine();
            });
            var emptyLines = core.GameLenght - core.Attempts.Count;
            for (int i = 0; i < emptyLines; i++)
            {
                for (int j = 0; j < core.RowLength; j++)
                {
                    Console.Write("- ");
                }

                Console.WriteLine();
            }
        }
    }
}